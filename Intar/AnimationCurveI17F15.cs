using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#if UNITY_2020_3_OR_NEWER
using Unity.Collections;
#endif

#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace Intar {
    public enum WeightedMode {
        None = 0,
        In = 1,
        Out = 2,
        Both = 3,
    }

    enum TangentMode {
        Free,
        Auto,
        Linear,
        Constant,
        ClampedAuto,
    }

    [Serializable]
    public struct KeyframeI17F15 {
#pragma warning disable IDE0079 // 不要な抑制を削除します
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
        public I17F15 Time;
        public I17F15 Value;
        public I17F15 InTangent;
        public I17F15 OutTangent;
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning restore IDE0079 // 不要な抑制を削除します
#if UNITY_5_3_OR_NEWER
        [SerializeField]
#endif // UNITY_5_3_OR_NEWER
        internal int tangentMode;
#pragma warning disable IDE0079 // 不要な抑制を削除します
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
        public WeightedMode WeightedMode;
        public I17F15 InWeight;
        public I17F15 OutWeight;
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning restore IDE0079 // 不要な抑制を削除します
        public KeyframeI17F15(
            I17F15 time, I17F15 value,
            I17F15 inTangent, I17F15 outTangent
        ) {
            Time = time;
            Value = value;
            InTangent = inTangent;
            OutTangent = outTangent;
            tangentMode = 0;
            WeightedMode = WeightedMode.None;
            InWeight = I17F15.Zero;
            OutWeight = I17F15.Zero;
        }
        public KeyframeI17F15(
            I17F15 time, I17F15 value
        ) : this(time, value, I17F15.Zero, I17F15.Zero) { }

        /// <summary>
        /// <c>UnityEngine.Keyframe</c> の同形式のコンストラクタと同様に
        /// <c>WeightedMode</c> を <c>WeightedMode.Both</c> に設定する.
        /// </summary>
        public KeyframeI17F15(
            I17F15 time, I17F15 value,
            I17F15 inTangent, I17F15 outTangent,
            I17F15 inWeight, I17F15 outWeight
        ) {
            Time = time;
            Value = value;
            InTangent = inTangent;
            OutTangent = outTangent;
            tangentMode = 0;
            WeightedMode = WeightedMode.Both;
            InWeight = inWeight;
            OutWeight = outWeight;
        }
        internal TangentMode GetLeftTangentMode() {
            return (TangentMode)((tangentMode >> 1) & 0b1111);
        }
        internal TangentMode GetRightTangentMode() {
            return (TangentMode)((tangentMode >> 5) & 0b1111);
        }
        internal bool HasInWeight() {
            return (WeightedMode & WeightedMode.In) != WeightedMode.None;
        }
        internal bool HasOutWeight() {
            return (WeightedMode & WeightedMode.Out) != WeightedMode.None;
        }
    }

#if UNITY_2022_2_OR_NEWER
    [GenerateTestsForBurstCompatibility]
#elif UNITY_2020_3_OR_NEWER
    [BurstCompatible]
#endif
    public struct AnimationCurveEvaluator {
        static long Mul(long a, long b) => a * b / I17F15.OneRepr;
        static long Div(long a, long b) => a * I17F15.OneRepr / b;

        internal static I17F15 HermiteInterpolate(I17F15 time,
            KeyframeI17F15 left,
            KeyframeI17F15 right,
            I17F15 defaultValue) {

            if (left.Time == right.Time) {
                return defaultValue;
            }
            var dx = right.Time.WideBits - left.Time.Bits;

            var m0 = Mul(left.OutTangent.Bits, dx);
            var m1 = Mul(right.InTangent.Bits, dx);
            var t = Div(time.WideBits - left.Time.Bits, dx);

            // 極端な値が与えられた場合オーバーフローを引き起こすが許容する.
            return HermiteInterpolate(t, left.Value.Bits, m0, m1, right.Value.Bits);
        }

        static I17F15 HermiteInterpolate(long t, long p0, long m0, long m1, long p1) {
            // 3 次エルミート補間は単位区間 [0, 1] について, t = 0 における始点 p0, t = 1 における
            // 終点 p1, t = 0 における開始接ベクトル m0, t = 1 における終了接ベクトル m1 を
            // 与えられた時, 以下の多項式で表される.
            //
            // p(t) = ( 2 * t^3 - 3 * t^2 + 1) * p0
            //      + (     t^3 - 2 * t^2 + t) * m0
            //      + (-2 * t^3 + 3 * t^2    ) * p1
            //      + (     t^3 -     t^2    ) * m1
            //
            // 誤差を小さくするため以下のように式変形する.
            //
            // p(t) = t * (t * (t * a + b) + c) + d とるすと a, b, c, d は以下のようになる.
            //
            // a = m0 + m1 -  2 * (p1 - p0)
            // b = 3 * (p1 - p0) - 2 * m0 - m1
            // c = m0
            // d = p0

            var pd = p1 - p0;

            var a = m0 + m1 - (2 * pd);
            var b = (3 * pd) - (2 * m0) - m1;

            // 極端な値が与えられた場合オーバーフローを引き起こすが許容する.

            var bits = Mul(t, a) + b;
            bits = Mul(t, bits) + m0;
            bits = Mul(t, bits) + p0;
            return I17F15.FromBits((int)bits);
        }

        /// <summary>
        /// 重みを Q30 固定小数点に変換する.
        /// <c>UnityEngine.AnimationCurve</c> と同様,
        /// 重みは [0, 1] の範囲にクランプする.
        /// </summary>
        static long WeightBits(I17F15 weight) {
            var bits = weight.Bits;
            bits = bits < 0 ? 0 : bits;
            bits = bits > I17F15.OneRepr ? I17F15.OneRepr : bits;
            return (long)bits << 15;
        }

        internal static I17F15 BezierInterpolate(I17F15 time,
            KeyframeI17F15 left,
            KeyframeI17F15 right,
            I17F15 defaultValue) {

            if (left.Time == right.Time) {
                return defaultValue;
            }

            // 重み付きの補間は 3 次ベジェ曲線 (x(t), y(t)) の評価に帰着する.
            // x(t) = time を満たす媒介変数 t を求め, その t で y(t) を評価する.
            // 計算は以下の手順で行う.
            //
            // 1. 時間を単位区間 [0, 1] に正規化する.
            //    重みは [0, 1] にクランプされるため, 正規化により
            //    x 方向のベジェ制御点もすべて [0, 1] に収まる.
            //    これにより x 方向の計算を Q30 固定小数点で行える.
            // 2. x(t) = u を満たす t を二分探索で求める.
            //    重みが [0, 1] の範囲にある限り x(t) は単調非減少であるため,
            //    t の各ビットを上位から順に確定させる二分探索で解ける.
            //    ニュートン法と異なり除算を使用しないため微少な値同士の除算による
            //    精度の低下がなく, x'(t) = 0 となる点 (重みが両側とも 1 の場合
            //    t = 1/2 で生じる) があっても問題ない. また反復回数が入力に
            //    依存しないため結果は決定論的である.
            // 3. 求めた t で y(t) を評価する.

            const long one = 1L << 30;

            var dx = right.Time.WideBits - left.Time.Bits;

            // 時間を単位区間に正規化する (Q30). 呼び出し元で
            // left.Time <= time < right.Time が保証されているため
            // u は [0, 1) の範囲に収まる.
            var u = ((time.WideBits - left.Time.Bits) << 30) / dx;

            // 重みを持たない側の重みは 1/3 として扱う.
            // (UnityEngine.AnimationCurve 準拠)
            var outWeight = left.HasOutWeight() ? WeightBits(left.OutWeight) : one / 3;
            var inWeight = right.HasInWeight() ? WeightBits(right.InWeight) : one / 3;

            // x 方向のベジェ制御点 (Q30). 時間の正規化により
            // x0 = 0, x3 = 1 となるため制御点は重みのみから決まる.
            //
            // x1 = outWeight
            // x2 = 1 - inWeight
            //
            // x(t) = 3 * (1 - t)^2 * t * x1 + 3 * (1 - t) * t^2 * x2 + t^3
            //      = ((a * t + b) * t + c) * t
            //
            // a = 1 + 3 * (x1 - x2)
            // b = 3 * (x2 - 2 * x1)
            // c = 3 * x1
            //
            // x1, x2 が [0, 1] に収まるため, t が [0, 1] の範囲において
            // ホーナー法の中間値はすべて 64 ビットに収まる.
            // (|a| <= 4, |b| <= 6, |c| <= 3, |a * t + b| <= 6,
            // |(a * t + b) * t + c| <= 3)
            var x1 = outWeight;
            var x2 = one - inWeight;
            var a = one + (3 * (x1 - x2));
            var b = 3 * (x2 - (2 * x1));
            var c = 3 * x1;

            // x(t) <= u を満たす最大の t を二分探索で求める (Q30).
            long t = 0;
            for (var bit = one >> 1; bit != 0; bit >>= 1) {
                var tt = t | bit;
                var x = (a * tt / one) + b;
                x = (x * tt / one) + c;
                x = x * tt / one;
                if (x <= u) {
                    t = tt;
                }
            }

            // y 方向のベジェ制御点 (Q15).
            //
            // y1 = y0 + outWeight * dx * outTangent
            // y2 = y3 - inWeight * dx * inTangent
            //
            // 極端な値が与えられた場合オーバーフローを引き起こすが許容する.
            var owdx = outWeight * dx / one;
            var iwdx = inWeight * dx / one;
            var y0 = (long)left.Value.Bits;
            var y3 = (long)right.Value.Bits;
            var y1 = y0 + Mul(left.OutTangent.Bits, owdx);
            var y2 = y3 - Mul(right.InTangent.Bits, iwdx);

            // y(t) = (1 - t)^3 * y0 + 3 * (1 - t)^2 * t * y1
            //      + 3 * (1 - t) * t^2 * y2 + t^3 * y3
            //      = ((d * t + e) * t + f) * t + y0
            //
            // d = y3 - y0 + 3 * (y1 - y2)
            // e = 3 * (y0 + y2) - 6 * y1
            // f = 3 * (y1 - y0)
            var d = y3 - y0 + (3 * (y1 - y2));
            var e = (3 * (y0 + y2)) - (6 * y1);
            var f = 3 * (y1 - y0);

            var bits = (d * t / one) + e;
            bits = (bits * t / one) + f;
            bits = (bits * t / one) + y0;
            return I17F15.FromBits((int)bits);
        }
    }

    public enum WrapMode {
        Clamp = 1,
        Loop,
        PingPong = 4,
    }

    [Serializable]
    public class AnimationCurveI17F15 {
        #region keys, Keys, Length, AddKey, MoveKey, RemoveKey, ClearKeys, Indexer
#if UNITY_5_3_OR_NEWER
        [SerializeField]
#endif // UNITY_5_3_OR_NEWER
        List<KeyframeI17F15> keys;
        public KeyframeI17F15[] Keys {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => keys.ToArray();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {
                keys.Clear();
                if (value == null) {
                    return;
                }
                keys.AddRange(value);
                Utility.InsertionSort(keys, (a, b) => a.Time.CompareTo(b.Time));
            }
        }
        public int Length {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => keys.Count;
        }
        public int AddKey(KeyframeI17F15 key) {
            // key を挿入する位置を探す。
            for (var i = 0; i < keys.Count; i++) {
                if (key.Time < keys[i].Time) {
                    keys.Insert(i, key);
                    return i;
                }

                // すでに key が存在する場合は何もしない。
                if (key.Time == keys[i].Time) {
                    return -1;
                }
            }
            keys.Add(key);
            return keys.Count - 1;
        }
        public int MoveKey(int index, KeyframeI17F15 key) {
            RemoveKey(index);
            return AddKey(key);
        }
        public void RemoveKey(int index) {
            keys.RemoveAt(index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ClearKeys() => keys.Clear();
        public KeyframeI17F15 this[int index] {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => keys[index];
        }
        #endregion
        #region PreWrapMode, PostWrapMode
#pragma warning disable IDE0079 // 不要な抑制を削除します
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
        public WrapMode PostWrapMode;
        public WrapMode PreWrapMode;
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning restore IDE0079 // 不要な抑制を削除します
        #endregion
        #region LoopTime, PingPongTime
        /// <summary>
        /// ループした時間を計算する.
        /// </summary>
        /// <remarks>
        /// <c>begin</c> と <c>end</c> が同値の場合 <c>null</c> を返す.
        /// <c>AddKey</c> は <c>Time</c> が同値の場合ただその操作を無視するため,
        /// <c>begin</c> と <c>end</c> が同値になることはない.
        /// (キー数が 1 つになるか否かによって判別できる.)
        /// </remarks>
        internal static I17F15? LoopTime(I17F15 begin, I17F15 end, I17F15 time) {
            var duration = end - begin;

            // 周期長が 0 の場合 null を返す.
            if (duration == I17F15.Zero) {
                return null;
            }

            // time が [begin, end) の範囲に収まるように調整する.
            return begin + Utility.FlooredRem(time - begin, duration);
        }
        internal static I17F15? PingPongTime(I17F15 begin, I17F15 end, I17F15 time) {
            var halfDuration = end - begin;

            // 周期長が 0 の場合 null を返す.
            if (halfDuration == I17F15.Zero) {
                return null;
            }
            var duration = I17F15.FromBits(2 * halfDuration.Bits);

            // time が [begin, end] の範囲に収まるように調整する.
            time = Utility.TruncatedRem(time - begin, duration).Abs();
            time = 0 == time.Bits / halfDuration.Bits
                ? time
                : duration - time;
            return begin + time;
        }
        #endregion
        #region FindKey
        internal int FindKey(I17F15 time) {
            var i = 0;
            var c = keys == null ? 0 : keys.Count;
            for (; i < c; i++) {
                if (time < keys[i].Time) {
                    break;
                }
            }
            return i;
        }
        #endregion
        #region Evaluate
        public I17F15 Evaluate(I17F15 time) {
            switch (keys.Count) {
                default: break;
                case 0: return I17F15.Zero;
                case 1: return keys[0].Value;
            }

            var first = keys[0];
            var last = keys[keys.Count - 1];

            if (last.Time <= time) {
                switch (PostWrapMode) {
                    default: throw new NotImplementedException($"{PostWrapMode}");
#if false
                    case 0: {
                        // 周期長が 0 の場合, 最後の値を返す.
                        // それ以外の場合 Loop と同様.
                        // (UnityEngine.AnimationCurve 準拠)
                        var t = LoopTime(first.Time, last.Time, time);
                        if (!t.HasValue) {
                            return last.Value;
                        }
                        time = t.Value;
                        break;
                    }
#endif
                    case WrapMode.Clamp: return last.Value;
                    case WrapMode.Loop: {
                        // 周期長が 0 の場合, 最初の値を返す.
                        // (UnityEngine.AnimationCurve 準拠)
                        var t = LoopTime(first.Time, last.Time, time);
                        if (!t.HasValue) {
                            return first.Value;
                        }
                        time = t.Value;
                        break;
                    }
                    case WrapMode.PingPong: {
                        // 周期長が 0 の場合, 最後の値を返す.
                        // (UnityEngine.AnimationCurve 準拠)
                        var t = PingPongTime(first.Time, last.Time, time);
                        if (!t.HasValue) {
                            return last.Value;
                        }
                        time = t.Value;
                        break;
                    }
                }
            } else if (time <= first.Time) {
                // 周期長が 0 の場合, 最初の if 節と,
                // この else if 節の両方の条件を満たす場合,
                // 必ず if 節の中で早期リターンするため,
                // この else if 節を if 節にする必要はない.
                // もし if 節にした場合, 条件式を評価するコストが増える.

                switch (PreWrapMode) {
                    default: throw new NotImplementedException($"{PreWrapMode}");
#if false
                    case 0: {
                        // 周期長が 0 の場合, 最後の値を返す.
                        // それ以外の場合 Loop と同様.
                        // (UnityEngine.AnimationCurve 準拠)
                        var t = LoopTime(first.Time, last.Time, time);
                        if (!t.HasValue) {
                            return last.Value;
                        }
                        time = t.Value;
                        break;
                    }
#endif
                    case WrapMode.Clamp: return first.Value;
                    case WrapMode.Loop: {
                        // 周期長が 0 の場合 I17F15.Zero を返す.
                        // (UnityEngine.AnimationCurve は NaN を返す.)
                        var t = LoopTime(first.Time, last.Time, time);
                        if (!t.HasValue) {
                            return I17F15.Zero;
                        }
                        time = t.Value;
                        break;
                    }
                    case WrapMode.PingPong: {
                        // 周期長が 0 の場合, 最後の値を返す.
                        // (UnityEngine.AnimationCurve 準拠)
                        var t = PingPongTime(first.Time, last.Time, time);
                        if (!t.HasValue) {
                            return last.Value;
                        }
                        time = t.Value;
                        break;
                    }
                }
            }

            // first.Time < time の場合のみ補間処理を行う.
            if (time <= first.Time) {
                return first.Value;
            }

            {
                var i = FindKey(time);
                if (i == keys.Count) {
                    return last.Value;
                } else {
                    var l = keys[i - 1];
                    var r = keys[i];
                    if (TangentMode.Constant == l.GetRightTangentMode() ||
                        TangentMode.Constant == r.GetLeftTangentMode()) {
                        return l.Value;
                    }
                    if (l.HasOutWeight() || r.HasInWeight()) {
                        return AnimationCurveEvaluator.BezierInterpolate(time, l, r, l.Value);
                    }
                    return AnimationCurveEvaluator.HermiteInterpolate(time, l, r, l.Value);
                }
            }
        }
        #endregion
        #region Constructor
        public AnimationCurveI17F15() {
            PreWrapMode = WrapMode.Clamp;
            PostWrapMode = WrapMode.Clamp;
            keys = new List<KeyframeI17F15>();
        }
        #endregion
        #region Conversion
#if UNITY_5_3_OR_NEWER
        public static explicit operator AnimationCurve(AnimationCurveI17F15 a) {
            var curve = new AnimationCurve();
            if (a.keys != null) {
                foreach (var key in a.keys) {
                    _ = curve.AddKey(new Keyframe(
                        (float)key.Time,
                        (float)key.Value,
                        (float)key.InTangent,
                        (float)key.OutTangent,
                        (float)key.InWeight,
                        (float)key.OutWeight
                    ) {
                        weightedMode = (UnityEngine.WeightedMode)key.WeightedMode,
                    });
                }
            }
            return curve;
        }
#endif
        #endregion
    }
} // namespace Intar
