using System.Runtime.CompilerServices;

namespace Intar {
    /// <summary>
    /// 線形補間を提供するクラス
    /// </summary>
    public static class LerpExtensions {

        /// <summary>
        /// 内部表現に対する線形補間｡
        /// <paramref name="t" /> は 0 以上 <see cref="I17F15.OneRepr" /> 以下でなければならない｡
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int LerpBits(int a, int b, int t) {
            return (int)(a + (((long)b - a) * t / I17F15.OneRepr));
        }

        /// <summary>
        /// 2 つの値の間を線形補間する｡
        /// <paramref name="t" /> は 0 以上 1 以下の範囲に制限される｡
        /// 計算は内部的に 64 ビット整数で行われるため､ オーバーフローは発生しない｡
        /// </summary>
        /// <param name="a"><paramref name="t" /> が 0 の時の値｡</param>
        /// <param name="b"><paramref name="t" /> が 1 の時の値｡</param>
        /// <param name="t">補間係数｡</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I17F15 Lerp(this I17F15 a, I17F15 b, I17F15 t) {
            t = t.Clamp(I17F15.Zero, I17F15.One);
            return I17F15.FromBits(LerpBits(a.Bits, b.Bits, t.Bits));
        }

        /// <summary>
        /// 2 つのベクトルの間を要素ごとに線形補間する｡
        /// <paramref name="t" /> は 0 以上 1 以下の範囲に制限される｡
        /// 計算は内部的に 64 ビット整数で行われるため､ オーバーフローは発生しない｡
        /// </summary>
        /// <param name="a"><paramref name="t" /> が 0 の時の値｡</param>
        /// <param name="b"><paramref name="t" /> が 1 の時の値｡</param>
        /// <param name="t">補間係数｡</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I17F15 Lerp(this Vector2I17F15 a, Vector2I17F15 b, I17F15 t) {
            t = t.Clamp(I17F15.Zero, I17F15.One);
            return new Vector2I17F15(
                I17F15.FromBits(LerpBits(a.X.Bits, b.X.Bits, t.Bits)),
                I17F15.FromBits(LerpBits(a.Y.Bits, b.Y.Bits, t.Bits)));
        }

        /// <summary>
        /// 2 つのベクトルの間を要素ごとに線形補間する｡
        /// <paramref name="t" /> は 0 以上 1 以下の範囲に制限される｡
        /// 計算は内部的に 64 ビット整数で行われるため､ オーバーフローは発生しない｡
        /// </summary>
        /// <param name="a"><paramref name="t" /> が 0 の時の値｡</param>
        /// <param name="b"><paramref name="t" /> が 1 の時の値｡</param>
        /// <param name="t">補間係数｡</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I17F15 Lerp(this Vector3I17F15 a, Vector3I17F15 b, I17F15 t) {
            t = t.Clamp(I17F15.Zero, I17F15.One);
            return new Vector3I17F15(
                I17F15.FromBits(LerpBits(a.X.Bits, b.X.Bits, t.Bits)),
                I17F15.FromBits(LerpBits(a.Y.Bits, b.Y.Bits, t.Bits)),
                I17F15.FromBits(LerpBits(a.Z.Bits, b.Z.Bits, t.Bits)));
        }

        /// <summary>
        /// 2 つのベクトルの間を要素ごとに線形補間する｡
        /// <paramref name="t" /> は 0 以上 1 以下の範囲に制限される｡
        /// 計算は内部的に 64 ビット整数で行われるため､ オーバーフローは発生しない｡
        /// </summary>
        /// <param name="a"><paramref name="t" /> が 0 の時の値｡</param>
        /// <param name="b"><paramref name="t" /> が 1 の時の値｡</param>
        /// <param name="t">補間係数｡</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I17F15 Lerp(this Vector4I17F15 a, Vector4I17F15 b, I17F15 t) {
            t = t.Clamp(I17F15.Zero, I17F15.One);
            return new Vector4I17F15(
                I17F15.FromBits(LerpBits(a.X.Bits, b.X.Bits, t.Bits)),
                I17F15.FromBits(LerpBits(a.Y.Bits, b.Y.Bits, t.Bits)),
                I17F15.FromBits(LerpBits(a.Z.Bits, b.Z.Bits, t.Bits)),
                I17F15.FromBits(LerpBits(a.W.Bits, b.W.Bits, t.Bits)));
        }
    }
}
