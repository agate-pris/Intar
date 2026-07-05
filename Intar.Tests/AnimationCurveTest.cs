using Intar.Rand;
using NUnit.Framework;
using System;

namespace Intar.Tests {
    public partial class AnimationCurveTest {
        static readonly WrapMode[] wrapModesI17F15 = new WrapMode[] {
#if false
            0,
#endif
            WrapMode.Clamp,
            WrapMode.Loop,
            WrapMode.PingPong,
        };

        [Test]
        public static void TestKeyframeI17F15() {
            var a = I17F15.FromBits(1000);
            var b = I17F15.FromBits(2000);
            var c = I17F15.FromBits(3000);
            var d = I17F15.FromBits(4000);
            var e = I17F15.FromBits(5000);
            var k = new KeyframeI17F15();
            Assert.IsTrue(I17F15.Zero == k.Time);
            Assert.IsTrue(I17F15.Zero == k.Value);
            Assert.IsTrue(I17F15.Zero == k.InTangent);
            Assert.IsTrue(I17F15.Zero == k.OutTangent);
            Assert.IsTrue(WeightedMode.None == k.WeightedMode);
            Assert.IsTrue(I17F15.Zero == k.InWeight);
            Assert.IsTrue(I17F15.Zero == k.OutWeight);
            k = new KeyframeI17F15(a, b);
            Assert.IsTrue(a == k.Time);
            Assert.IsTrue(b == k.Value);
            Assert.IsTrue(I17F15.Zero == k.InTangent);
            Assert.IsTrue(I17F15.Zero == k.OutTangent);
            Assert.IsTrue(WeightedMode.None == k.WeightedMode);
            Assert.IsTrue(I17F15.Zero == k.InWeight);
            Assert.IsTrue(I17F15.Zero == k.OutWeight);
            k = new KeyframeI17F15(b, c, d, e);
            Assert.IsTrue(b == k.Time);
            Assert.IsTrue(c == k.Value);
            Assert.IsTrue(d == k.InTangent);
            Assert.IsTrue(e == k.OutTangent);
            Assert.IsTrue(WeightedMode.None == k.WeightedMode);
            Assert.IsTrue(I17F15.Zero == k.InWeight);
            Assert.IsTrue(I17F15.Zero == k.OutWeight);

            // UnityEngine.Keyframe の同形式のコンストラクタと同様に
            // WeightedMode が Both に設定されることをテスト.
            k = new KeyframeI17F15(a, b, c, d, d, e);
            Assert.IsTrue(a == k.Time);
            Assert.IsTrue(b == k.Value);
            Assert.IsTrue(c == k.InTangent);
            Assert.IsTrue(d == k.OutTangent);
            Assert.IsTrue(WeightedMode.Both == k.WeightedMode);
            Assert.IsTrue(d == k.InWeight);
            Assert.IsTrue(e == k.OutWeight);
        }

        [Test]
        public static void TestAnimationCurveI17F15Constructor() {
            var curve = new AnimationCurveI17F15();
            Assert.AreEqual(curve.PreWrapMode, WrapMode.Clamp);
            Assert.AreEqual(curve.PostWrapMode, WrapMode.Clamp);
            Assert.AreEqual(0, curve.Length);
            Assert.IsNotNull(curve.Keys);

            // Length と Keys のアクセス順序が逆でも正しく動作することを確認
            curve = new AnimationCurveI17F15();
            Assert.IsNotNull(curve.Keys);
            Assert.AreEqual(0, curve.Length);
        }

        [Test]
        public static void TestIndexerI17F15() {
            var curve = new AnimationCurveI17F15();
            for (var i = 0; i < 3; i++) {
                for (var j = -1; j <= curve.Length; j++) {
                    if (j < 0 || j == curve.Length) {
                        // AnimationCurveI17F15 は ArgumentOutOfRangeException をスローする.
                        var e = Assert.Throws<ArgumentOutOfRangeException>(() => {
                            _ = curve[j];
                        }, $"i:{i} j:{j}");
                    } else {
                        Assert.DoesNotThrow(() => {
                            _ = curve[j];
                        }, $"i:{i} j:{j}");
                    }
                }
                var t = (I17F15)(i + 1);
                var v = (I17F15)((i + 1) * 2);
                _ = curve.AddKey(new KeyframeI17F15(t, v));
            }
        }

        [Test]
        public static void TestAddKeyI17F15() {
            var curve = new AnimationCurveI17F15();
            var k1 = new KeyframeI17F15((I17F15)2, (I17F15)2);
            var k2 = new KeyframeI17F15((I17F15)2, (I17F15)3);
            var k3 = new KeyframeI17F15((I17F15)4, (I17F15)4);
            var k4 = new KeyframeI17F15((I17F15)3, (I17F15)3);
            var k5 = new KeyframeI17F15((I17F15)1, (I17F15)1);
            var i = curve.AddKey(k1);
            Utility.AssertAreEqual(1, curve.Length);
            Utility.AssertAreEqual(0, i);
            Utility.AssertAreEqual(k1.Time, curve[i].Time);
            Utility.AssertAreEqual(k1.Value, curve[i].Value);
            Utility.AssertAreEqual(-1, curve.AddKey(k2));
            Utility.AssertAreEqual(1, curve.Length);
            Utility.AssertAreEqual(k1.Time, curve[i].Time);
            Utility.AssertAreEqual(k1.Value, curve[i].Value);
            i = curve.AddKey(k3);
            Utility.AssertAreEqual(2, curve.Length);
            Utility.AssertAreEqual(1, i);
            Utility.AssertAreEqual(k1.Time, curve[0].Time);
            Utility.AssertAreEqual(k1.Value, curve[0].Value);
            Utility.AssertAreEqual(k3.Time, curve[i].Time);
            Utility.AssertAreEqual(k3.Value, curve[i].Value);
            i = curve.AddKey(k4);
            Utility.AssertAreEqual(3, curve.Length);
            Utility.AssertAreEqual(1, i);
            Utility.AssertAreEqual(k1.Time, curve[0].Time);
            Utility.AssertAreEqual(k1.Value, curve[0].Value);
            Utility.AssertAreEqual(k4.Time, curve[i].Time);
            Utility.AssertAreEqual(k4.Value, curve[i].Value);
            Utility.AssertAreEqual(k3.Time, curve[2].Time);
            Utility.AssertAreEqual(k3.Value, curve[2].Value);
            i = curve.AddKey(k5);
            Utility.AssertAreEqual(4, curve.Length);
            Utility.AssertAreEqual(0, i);
            Utility.AssertAreEqual(k5.Time, curve[i].Time);
            Utility.AssertAreEqual(k5.Value, curve[i].Value);
            Utility.AssertAreEqual(k1.Time, curve[1].Time);
            Utility.AssertAreEqual(k1.Value, curve[1].Value);
            Utility.AssertAreEqual(k4.Time, curve[2].Time);
            Utility.AssertAreEqual(k4.Value, curve[2].Value);
            Utility.AssertAreEqual(k3.Time, curve[3].Time);
            Utility.AssertAreEqual(k3.Value, curve[3].Value);
        }

        [Test]
        public static void TestSetKeysI17F15() {
            var curve = new AnimationCurveI17F15();
            Assert.AreEqual(0, curve.Length);
            curve.Keys = Array.Empty<KeyframeI17F15>();
            Assert.AreEqual(0, curve.Length);
            curve.Keys = null;
            Assert.AreEqual(0, curve.Length);

            var keys = new KeyframeI17F15[] {
                new KeyframeI17F15(I17F15.FromBits(4000), I17F15.FromBits(5000)),
                new KeyframeI17F15(I17F15.FromBits(4000), I17F15.FromBits(4000)),
                new KeyframeI17F15(I17F15.FromBits(3000), I17F15.FromBits(4000)),
                new KeyframeI17F15(I17F15.FromBits(3000), I17F15.FromBits(3000)),
                new KeyframeI17F15(I17F15.FromBits(2000), I17F15.FromBits(3000)),
                new KeyframeI17F15(I17F15.FromBits(2000), I17F15.FromBits(2000)),
                new KeyframeI17F15(I17F15.FromBits(1000), I17F15.FromBits(2000)),
                new KeyframeI17F15(I17F15.FromBits(1000), I17F15.FromBits(1000)),
            };
            curve.Keys = keys;

            // Keys 設定時, 値が安定ソートされることをテスト
            Assert.AreEqual(8, curve.Length);
            Assert.AreEqual(keys[6], curve[0]);
            Assert.AreEqual(keys[7], curve[1]);
            Assert.AreEqual(keys[4], curve[2]);
            Assert.AreEqual(keys[5], curve[3]);
            Assert.AreEqual(keys[2], curve[4]);
            Assert.AreEqual(keys[3], curve[5]);
            Assert.AreEqual(keys[0], curve[6]);
            Assert.AreEqual(keys[1], curve[7]);
        }

        [Test]
        public static void TestClearKeys() {
            var curve = new AnimationCurveI17F15();

            // 初期状態で ClearKeys を呼んでも問題ないことをテスト
            curve.ClearKeys();
            Utility.AssertAreEqual(0, curve.Length);

            _ = curve.AddKey(new KeyframeI17F15((I17F15)1, (I17F15)1));
            Utility.AssertAreEqual(1, curve.Length);

            curve.ClearKeys();
            Utility.AssertAreEqual(0, curve.Length);
        }

        [Test]
        public static void TestRemoveKeyI17F15() {
            var curve = new AnimationCurveI17F15();

            // AnimationCurveI17F15 は ArgumentOutOfRangeException をスローする.

            _ = Assert.Throws<ArgumentOutOfRangeException>(() => {
                curve.RemoveKey(0);
            });

            _ = curve.AddKey(new KeyframeI17F15((I17F15)1, (I17F15)1));
            Utility.AssertAreEqual(1, curve.Length);

            _ = Assert.Throws<ArgumentOutOfRangeException>(() => {
                curve.RemoveKey(-1);
            });

            curve.RemoveKey(0);
            Utility.AssertAreEqual(0, curve.Length);

            _ = Assert.Throws<ArgumentOutOfRangeException>(() => {
                curve.RemoveKey(0);
            });
        }

        [Test]
        public static void TestMoveKeyI17F15() {
            var curve = new AnimationCurveI17F15();

            // AnimationCurveI17F15 はインデックスが不正な場合
            // ArgumentOutOfRangeException をスローする.
            var e = Assert.Throws<ArgumentOutOfRangeException>(() => {
                _ = curve.MoveKey(0, new KeyframeI17F15((I17F15)1, (I17F15)1));
            });

            var i = curve.AddKey(new KeyframeI17F15((I17F15)1, (I17F15)1));
            Utility.AssertAreEqual(0, i);
            Utility.AssertAreEqual(1, curve.Length);
            Utility.AssertAreEqual((I17F15)1, curve[i].Time);
            Utility.AssertAreEqual((I17F15)1, curve[i].Value);
            i = curve.MoveKey(0, new KeyframeI17F15((I17F15)2, (I17F15)2));
            Utility.AssertAreEqual(0, i);
            Utility.AssertAreEqual(1, curve.Length);
            Utility.AssertAreEqual((I17F15)2, curve[i].Time);
            Utility.AssertAreEqual((I17F15)2, curve[i].Value);

            i = curve.AddKey(new KeyframeI17F15((I17F15)3, (I17F15)3));
            Utility.AssertAreEqual(1, i);
            Utility.AssertAreEqual(2, curve.Length);
            Utility.AssertAreEqual((I17F15)2, curve[0].Time);
            Utility.AssertAreEqual((I17F15)2, curve[0].Value);
            Utility.AssertAreEqual((I17F15)3, curve[1].Time);
            Utility.AssertAreEqual((I17F15)3, curve[1].Value);

            i = curve.MoveKey(0, new KeyframeI17F15((I17F15)4, (I17F15)4));
            Utility.AssertAreEqual(1, i);
            Utility.AssertAreEqual(2, curve.Length);
            Utility.AssertAreEqual((I17F15)3, curve[0].Time);
            Utility.AssertAreEqual((I17F15)3, curve[0].Value);
            Utility.AssertAreEqual((I17F15)4, curve[1].Time);
            Utility.AssertAreEqual((I17F15)4, curve[1].Value);

            i = curve.MoveKey(1, new KeyframeI17F15((I17F15)1, (I17F15)1));
            Utility.AssertAreEqual(0, i);
            Utility.AssertAreEqual(2, curve.Length);
            Utility.AssertAreEqual((I17F15)1, curve[0].Time);
            Utility.AssertAreEqual((I17F15)1, curve[0].Value);
            Utility.AssertAreEqual((I17F15)3, curve[1].Time);
            Utility.AssertAreEqual((I17F15)3, curve[1].Value);

            // KeyframeI17F15.Time が既存のキーと重複する場合,
            // 例外をスローせず指定したインデックスのキーを削除し -1 を返す.

            i = curve.MoveKey(0, new KeyframeI17F15((I17F15)3, (I17F15)5));
            Utility.AssertAreEqual(-1, i);
            Utility.AssertAreEqual(1, curve.Length);
            Utility.AssertAreEqual((I17F15)3, curve[0].Time);
            Utility.AssertAreEqual((I17F15)3, curve[0].Value);
        }

        /// <summary>
        /// キー数が 0 または 1 の場合,
        /// それぞれ PreWrapMode, PostWrapMode に関わらず
        /// どこで評価しても 0 またはそのキーの値であることをテスト.
        /// </summary>
        static void TestEvaluateLessThanTwoKeysI17F15(WrapMode preWrapMode, WrapMode postWrapMode, KeyframeI17F15? keyFrame) {
            var randomNumberGenerator = new Xoroshiro128StarStar(1, 2);
            var value = keyFrame.HasValue ? keyFrame.Value.Value : I17F15.Zero;
            var rng = randomNumberGenerator;
            var curve = new AnimationCurveI17F15 {
                PreWrapMode = preWrapMode,
                PostWrapMode = postWrapMode,
            };
            if (keyFrame.HasValue) {
                _ = curve.AddKey(keyFrame.Value);
                Utility.AssertAreEqual(value, curve.Evaluate(keyFrame.Value.Time));
            }
            Utility.AssertAreEqual(value, curve.Evaluate(I17F15.Zero));
            Utility.AssertAreEqual(value, curve.Evaluate(I17F15.One));
            Utility.AssertAreEqual(value, curve.Evaluate(I17F15.NegativeOne));
            for (var i = 0; i < 100; i++) {
                const int k = 1 << 15;
                var randomNumber = I17F15.FromBits(rng.Next(0, 1 + k));
                Utility.AssertAreEqual(value, curve.Evaluate(randomNumber));
                Utility.AssertAreEqual(value, curve.Evaluate(randomNumber + I17F15.One));
                Utility.AssertAreEqual(value, curve.Evaluate(randomNumber - I17F15.One));
            }
        }

        [Test]
        public static void TestEvaluateLessThanTwoKeysI17F15() {
            var values = new I17F15[] {
                I17F15.Zero,
                I17F15.One,
                I17F15.NegativeOne,
            };
            var randomNumberGenerator = new Xoroshiro128StarStar(1, 2);
            foreach (var preWrapMode in wrapModesI17F15) {
                foreach (var postWrapMode in wrapModesI17F15) {
                    // キー無しの場合常に評価値が 0 になることをテスト
                    TestEvaluateLessThanTwoKeysI17F15(preWrapMode, postWrapMode, null);

                    foreach (var v1 in values) {
                        foreach (var v2 in values) {
                            // 時間と値が境界値のキー 1 つの場合
                            // 常に評価値が値と同値になることをテスト
                            TestEvaluateLessThanTwoKeysI17F15(preWrapMode, postWrapMode, new KeyframeI17F15(v1, v2));
                        }

                        var rng = randomNumberGenerator;
                        for (var i = 0; i < 100; i++) {
                            var v2 = I17F15.FromBits(rng.Next(-32768, 32768));

                            // 時間が境界値, 値が乱数のキー 1 つの場合または
                            // 時間が乱数, 値が境界値のキー 1 つの場合
                            // 各々常に評価値が値と同値になることをテスト
                            TestEvaluateLessThanTwoKeysI17F15(preWrapMode, postWrapMode, new KeyframeI17F15(v1, v2));
                            TestEvaluateLessThanTwoKeysI17F15(preWrapMode, postWrapMode, new KeyframeI17F15(v2, v1));
                        }
                    }
                    {
                        // 時間と値が乱数のキー 1 つの場合
                        // 評価値が常に値と同値になることをテスト
                        var rng1 = randomNumberGenerator;
                        for (var i = 10; i < 10; i++) {
                            var rng2 = randomNumberGenerator;
                            var time = I17F15.FromBits(rng1.Next(-32768, 32768));
                            for (var j = 10; j < 10; j++) {
                                var value = I17F15.FromBits(rng2.Next(-32768, 32768));
                                TestEvaluateLessThanTwoKeysI17F15(preWrapMode, postWrapMode, new KeyframeI17F15(time, value));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// キー数が 2 つの場合,
        /// それぞれのキーの時間で評価した時,
        /// その評価値が PreWrapMode 及び PostWrapMode に応じた値になることをテスト.
        /// </summary>
        [Test]
        public static void TestEvaluateTwoKeysI17F15() {
            var curve = new AnimationCurveI17F15();

            {
                // 左右のいずれか, または両方のタンジェントが Constant の場合,
                // その区間内で一定値になることをテスト.
                var t = (I17F15)1;
                var expected = (I17F15)1.5F;
                var k1 = new KeyframeI17F15((I17F15)0.5F, expected);
                var k2 = new KeyframeI17F15((I17F15)1.25F, (I17F15)0.25F);
                k1.tangentMode = ((int)TangentMode.Constant) << 5;
                _ = curve.AddKey(k1);
                _ = curve.AddKey(k2);
                Utility.AssertAreEqual(expected, curve.Evaluate(t));
                k2.tangentMode = ((int)TangentMode.Constant) << 1;
                curve.MoveKey(1, k2);
                Utility.AssertAreEqual(expected, curve.Evaluate(t));
                k1.tangentMode = 0;
                curve.MoveKey(0, k1);
                Utility.AssertAreEqual(expected, curve.Evaluate(t));
            }

            curve.ClearKeys();
            _ = curve.AddKey(new KeyframeI17F15((I17F15)0.5, (I17F15)1.5, (I17F15)1.5, (I17F15)1.5));
            _ = curve.AddKey(new KeyframeI17F15((I17F15)1.25, (I17F15)0.25, (I17F15)0.25, (I17F15)0.25));
            {
                var actual = curve.Evaluate((I17F15)0.875);
                Utility.AssertAreEqual(32512, actual.Bits);
                Utility.AssertAreEqual(0.99218738079071045, (double)actual, 1e-3F);
            }

            curve.ClearKeys();
            _ = curve.AddKey(new KeyframeI17F15((I17F15)1, (I17F15)0, (I17F15)1, (I17F15)1));
            _ = curve.AddKey(new KeyframeI17F15((I17F15)2, (I17F15)1, (I17F15)1, (I17F15)1));

            // 基本的にループ時, [0, 1) の範囲に収まるように評価されることをテスト.
            // また PreWrapMode, PostWrapMode が Default の場合
            // Loop と同じ挙動であることをテスト.
            foreach (var preWrapMode in wrapModesI17F15) {
                curve.PreWrapMode = preWrapMode;
                foreach (var postWrapMode in wrapModesI17F15) {
                    curve.PostWrapMode = postWrapMode;
                    Utility.AssertAreEqual((I17F15)0.000F, curve.Evaluate((I17F15)1.000F));
                    Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)1.125F));
                    Utility.AssertAreEqual((I17F15)0.875F, curve.Evaluate((I17F15)1.875F));
                    switch (preWrapMode) {
                        default:
                        throw new NotImplementedException(preWrapMode.ToString());

#if false
                        case 0:
#endif
                        case WrapMode.Loop:
                        Utility.AssertAreEqual((I17F15)0.875F, curve.Evaluate((I17F15)(-0.125F)));
                        Utility.AssertAreEqual((I17F15)0.000F, curve.Evaluate((I17F15)(+0.000F)));
                        Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)(+0.125F)));
                        Utility.AssertAreEqual((I17F15)0.875F, curve.Evaluate((I17F15)(+0.875F)));
                        break;

                        case WrapMode.Clamp:
                        Utility.AssertAreEqual((I17F15)0, curve.Evaluate((I17F15)(-0.125F)));
                        Utility.AssertAreEqual((I17F15)0, curve.Evaluate((I17F15)(+0.000F)));
                        Utility.AssertAreEqual((I17F15)0, curve.Evaluate((I17F15)(+0.125F)));
                        Utility.AssertAreEqual((I17F15)0, curve.Evaluate((I17F15)(+0.875F)));
                        break;

                        case WrapMode.PingPong:
                        Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)(-1.125F)));
                        Utility.AssertAreEqual((I17F15)0.000F, curve.Evaluate((I17F15)(-1.000F)));
                        Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)(-0.875F)));
                        Utility.AssertAreEqual((I17F15)0.875F, curve.Evaluate((I17F15)(-0.125F)));
                        Utility.AssertAreEqual((I17F15)1.000F, curve.Evaluate((I17F15)(+0.000F)));
                        Utility.AssertAreEqual((I17F15)0.875F, curve.Evaluate((I17F15)(+0.125F)));
                        Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)(+0.875F)));
                        break;
                    }
                    switch (postWrapMode) {
                        default:
                        throw new NotImplementedException(preWrapMode.ToString());

#if false
                        case 0:
#endif
                        case WrapMode.Loop:
                        Utility.AssertAreEqual((I17F15)0.000F, curve.Evaluate((I17F15)2.000F));
                        Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)2.125F));
                        Utility.AssertAreEqual((I17F15)0.875F, curve.Evaluate((I17F15)2.875F));
                        Utility.AssertAreEqual((I17F15)0.000F, curve.Evaluate((I17F15)3.000F));
                        Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)3.125F));
                        break;

                        case WrapMode.Clamp:
                        Utility.AssertAreEqual((I17F15)1, curve.Evaluate((I17F15)2.000F));
                        Utility.AssertAreEqual((I17F15)1, curve.Evaluate((I17F15)2.125F));
                        Utility.AssertAreEqual((I17F15)1, curve.Evaluate((I17F15)2.875F));
                        Utility.AssertAreEqual((I17F15)1, curve.Evaluate((I17F15)3.000F));
                        Utility.AssertAreEqual((I17F15)1, curve.Evaluate((I17F15)3.125F));
                        break;

                        case WrapMode.PingPong:
                        Utility.AssertAreEqual((I17F15)1.000F, curve.Evaluate((I17F15)2.000F));
                        Utility.AssertAreEqual((I17F15)0.875F, curve.Evaluate((I17F15)2.125F));
                        Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)2.875F));
                        Utility.AssertAreEqual((I17F15)0.000F, curve.Evaluate((I17F15)3.000F));
                        Utility.AssertAreEqual((I17F15)0.125F, curve.Evaluate((I17F15)3.125F));
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 周期長が 0 のカーブのテスト
        /// </summary>
        [Test]
        public static void TestEvaluateZeroDurationI17F15() {
            for (var flag = 0; flag < 1; flag++) {
                I17F15 first, second, third, last;
                if (flag == 0) {
                    first = (I17F15)1;
                    second = (I17F15)4;
                    third = (I17F15)3;
                    last = (I17F15)2;
                } else {
                    first = (I17F15)2;
                    second = (I17F15)3;
                    third = (I17F15)4;
                    last = (I17F15)1;
                }
                var curve = new AnimationCurveI17F15 {
                    Keys = new KeyframeI17F15[] {
                        new KeyframeI17F15((I17F15)1, first),
                        new KeyframeI17F15((I17F15)1, second),
                        new KeyframeI17F15((I17F15)1, third),
                        new KeyframeI17F15((I17F15)1, last),
                    }
                };
                for (var t = 0; t <= 2; t++) {
                    foreach (var pre in wrapModesI17F15) {
                        curve.PreWrapMode = pre;
                        foreach (var post in wrapModesI17F15) {
                            curve.PostWrapMode = post;
                            var time = (I17F15)t;
                            var actual = curve.Evaluate(time);
                            I17F15 expected;
                            if (t == 0) {
                                switch (pre) {
                                    default:
                                    throw new NotImplementedException($"time:{t} preWrapMode:{pre} postWrapMode:{post}");

#if false
                                    case 0:
#endif
                                    case WrapMode.PingPong:
                                    expected = last;
                                    break;

                                    case WrapMode.Clamp:
                                    expected = first;
                                    break;

                                    case WrapMode.Loop:
                                    expected = I17F15.Zero;
                                    break;
                                }
                            } else {
                                switch (post) {
                                    default:
                                    throw new NotImplementedException($"time:{t} preWrapMode:{pre} postWrapMode:{post}");

#if false
                                    case 0:
#endif
                                    case WrapMode.Clamp:
                                    case WrapMode.PingPong:
                                    expected = last;
                                    break;

                                    case WrapMode.Loop:
                                    expected = first;
                                    break;
                                }
                            }
                            Utility.AssertAreEqual(expected, actual, $"time:{t} preWrapMode:{pre} postWrapMode:{post} expected:{expected} actual:{actual}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// キーとキーの間の時間が 0 のカーブのテスト
        /// </summary>
        [Test]
        public static void TestEvaluateZeroIntervalI17F15() {
            // キーの時間が同じ場合, 後に追加されたキーの値が評価されることをテスト.
            var curve = new AnimationCurveI17F15 {
                Keys = new KeyframeI17F15[] {
                    new KeyframeI17F15((I17F15)1, (I17F15)1),
                    new KeyframeI17F15((I17F15)1, (I17F15)2),
                    new KeyframeI17F15((I17F15)2, (I17F15)2),
                    new KeyframeI17F15((I17F15)2, (I17F15)3),
                    new KeyframeI17F15((I17F15)3, (I17F15)3),
                    new KeyframeI17F15((I17F15)3, (I17F15)4),
                }
            };
            for (var t = 0; t <= 6; t++) {
                foreach (var pre in wrapModesI17F15) {
                    curve.PreWrapMode = pre;
                    foreach (var post in wrapModesI17F15) {
                        curve.PostWrapMode = post;
                        var actual = curve.Evaluate((I17F15)t);

                        I17F15 expected;
                        switch (t) {
                            default: throw new NotImplementedException($"time:{t} preWrapMode:{pre} postWrapMode:{post}");
                            case 0:
                            switch (pre) {
                                default:
                                throw new NotImplementedException($"time:{t} preWrapMode:{pre} postWrapMode:{post}");

#if false
                                case 0:
#endif
                                case WrapMode.Loop:
                                case WrapMode.PingPong:
                                expected = (I17F15)3;
                                break;

                                case WrapMode.Clamp:
                                expected = (I17F15)1;
                                break;
                            }
                            break;

                            case 1:
                            expected = (I17F15)1;
                            break;
                            case 2:
                            expected = (I17F15)3;
                            break;
                            case 3:
                            switch (post) {
                                default:
                                throw new NotImplementedException($"time:{t} preWrapMode:{pre} postWrapMode:{post}");

#if false
                                case 0:
#endif
                                case WrapMode.Loop:
                                expected = (I17F15)1;
                                break;

                                case WrapMode.Clamp:
                                case WrapMode.PingPong:
                                expected = (I17F15)4;
                                break;
                            }
                            break;

                            case 4:
                            switch (post) {
                                default:
                                throw new NotImplementedException($"time:{t} preWrapMode:{pre} postWrapMode:{post}");

#if false
                                case 0:
#endif
                                case WrapMode.Loop:
                                case WrapMode.PingPong:
                                expected = (I17F15)3;
                                break;

                                case WrapMode.Clamp:
                                expected = (I17F15)4;
                                break;
                            }
                            break;

                            case 5:
                            switch (post) {
                                default:
                                throw new NotImplementedException($"time:{t} preWrapMode:{pre} postWrapMode:{post}");

#if false
                                case 0:
#endif
                                case WrapMode.Loop:
                                case WrapMode.PingPong:
                                expected = (I17F15)1;
                                break;

                                case WrapMode.Clamp:
                                expected = (I17F15)4;
                                break;
                            }
                            break;

                            case 6:
                            switch (post) {
                                default:
                                throw new NotImplementedException($"time:{t} preWrapMode:{pre} postWrapMode:{post}");

#if false
                                case 0:
#endif
                                case WrapMode.Loop:
                                case WrapMode.PingPong:
                                expected = (I17F15)3;
                                break;

                                case WrapMode.Clamp:
                                expected = (I17F15)4;
                                break;
                            }
                            break;
                        }
                        Utility.AssertAreEqual(expected, actual, $"time:{t} preWrapMode:{pre} postWrapMode:{post} expected:{expected} actual:{actual}");
                    }
                }
            }
        }

        /// <summary>
        /// 重み付きベジェ補間の倍精度による参照実装.
        /// 実装と同様, 時間を単位区間に正規化し x(t) = u を
        /// 二分探索で解いた後 y(t) を評価する.
        /// </summary>
        static double BezierReference(
            double time,
            double outTime, double outValue, double outTangent, double outWeight,
            double inTime, double inValue, double inTangent, double inWeight
        ) {
            var dx = inTime - outTime;
            var u = (time - outTime) / dx;
            var x1 = outWeight;
            var x2 = 1 - inWeight;
            var a = 1 + (3 * (x1 - x2));
            var b = 3 * (x2 - (2 * x1));
            var c = 3 * x1;
            double lo = 0;
            double hi = 1;
            for (var i = 0; i < 64; i++) {
                var mid = 0.5 * (lo + hi);
                var x = (((((a * mid) + b) * mid) + c) * mid);
                if (x <= u) {
                    lo = mid;
                } else {
                    hi = mid;
                }
            }
            var t = lo;
            var y0 = outValue;
            var y3 = inValue;
            var y1 = y0 + (outWeight * dx * outTangent);
            var y2 = y3 - (inWeight * dx * inTangent);
            var d = y3 - y0 + (3 * (y1 - y2));
            var e = (3 * (y0 + y2)) - (6 * y1);
            var f = 3 * (y1 - y0);
            return (((((d * t) + e) * t) + f) * t) + y0;
        }

        /// <summary>
        /// 両端の重みが 0 の場合, タンジェントに関わらず
        /// キーとキーを結ぶ直線になることをテスト.
        /// (制御点がキーと一致するため.)
        /// </summary>
        [Test]
        public static void TestEvaluateWeightedZeroWeightI17F15() {
            var curve = new AnimationCurveI17F15();
            _ = curve.AddKey(new KeyframeI17F15(
                (I17F15)0, (I17F15)1, (I17F15)100, (I17F15)100,
                I17F15.Zero, I17F15.Zero
            ));
            _ = curve.AddKey(new KeyframeI17F15(
                (I17F15)1, (I17F15)3, (I17F15)(-100), (I17F15)(-100),
                I17F15.Zero, I17F15.Zero
            ));
            for (var i = 0; i <= 16; i++) {
                var time = I17F15.FromBits(i * (I17F15.OneRepr / 16));
                var expected = 1 + (2 * (double)time);
                var actual = (double)curve.Evaluate(time);
                Utility.AssertAreEqual(expected, actual, 4.0 / 32768, $"time:{time}");
            }
        }

        /// <summary>
        /// 両端の重みが 1 の対称なカーブのテスト.
        /// t = 1/2 において x'(t) = 0 となるため,
        /// ニュートン法では求解が困難なケースである.
        /// </summary>
        [Test]
        public static void TestEvaluateWeightedOneWeightI17F15() {
            var curve = new AnimationCurveI17F15();
            _ = curve.AddKey(new KeyframeI17F15(
                (I17F15)0, (I17F15)0, I17F15.Zero, I17F15.Zero,
                I17F15.One, I17F15.One
            ));
            _ = curve.AddKey(new KeyframeI17F15(
                (I17F15)1, (I17F15)1, I17F15.Zero, I17F15.Zero,
                I17F15.One, I17F15.One
            ));

            // 端点は正確に評価されることをテスト.
            Utility.AssertAreEqual((I17F15)0, curve.Evaluate((I17F15)0));
            Utility.AssertAreEqual((I17F15)1, curve.Evaluate((I17F15)1));

            // 対称性より中点の評価値は 1/2 になる.
            // ただしこの点はカーブの接線が垂直になるため,
            // 時間の微少な変化に対する評価値の感度が本質的に高い.
            // (これは浮動小数点による実装でも同様である.)
            Utility.AssertAreEqual(0.5, (double)curve.Evaluate((I17F15)0.5), 2e-3);

            // 単調非減少であることをテスト.
            var prev = curve.Evaluate(I17F15.Zero);
            for (var i = 1; i <= 64; i++) {
                var time = I17F15.FromBits(i * (I17F15.OneRepr / 64));
                var value = curve.Evaluate(time);
                Assert.IsTrue(prev <= value, $"time:{time} prev:{prev} value:{value}");
                prev = value;
            }
        }

        /// <summary>
        /// 補間に使用されない側の重みフラグは
        /// 補間結果に影響しないことをテスト.
        /// (左キーの In, 右キーの Out は補間に使用されない.)
        /// </summary>
        [Test]
        public static void TestEvaluateWeightedUnusedWeightI17F15() {
            var expected = new AnimationCurveI17F15();
            _ = expected.AddKey(new KeyframeI17F15((I17F15)0, (I17F15)0, (I17F15)1, (I17F15)1));
            _ = expected.AddKey(new KeyframeI17F15((I17F15)1, (I17F15)1, (I17F15)(-2), (I17F15)(-2)));

            var actual = new AnimationCurveI17F15();
            _ = actual.AddKey(new KeyframeI17F15((I17F15)0, (I17F15)0, (I17F15)1, (I17F15)1) {
                WeightedMode = WeightedMode.In,
                InWeight = I17F15.One,
                OutWeight = I17F15.One,
            });
            _ = actual.AddKey(new KeyframeI17F15((I17F15)1, (I17F15)1, (I17F15)(-2), (I17F15)(-2)) {
                WeightedMode = WeightedMode.Out,
                InWeight = I17F15.One,
                OutWeight = I17F15.One,
            });

            // 補間に使用されない側の重みのみが設定されている場合,
            // 重み無しの補間と完全に一致する.
            for (var i = 0; i <= 32; i++) {
                var time = I17F15.FromBits(i * (I17F15.OneRepr / 32));
                Utility.AssertAreEqual(expected.Evaluate(time), actual.Evaluate(time), $"time:{time}");
            }
        }

        /// <summary>
        /// 重みが 1/3 の場合, 重み無しの 3 次エルミート補間と
        /// 同一の曲線になることをテスト.
        /// </summary>
        [Test]
        public static void TestEvaluateWeightedDefaultWeightI17F15() {
            var oneThird = I17F15.FromBits((I17F15.OneRepr + 1) / 3);
            var hermite = new AnimationCurveI17F15();
            _ = hermite.AddKey(new KeyframeI17F15((I17F15)0, (I17F15)0, (I17F15)2, (I17F15)2));
            _ = hermite.AddKey(new KeyframeI17F15((I17F15)1, (I17F15)1, (I17F15)(-1), (I17F15)(-1)));

            var weighted = new AnimationCurveI17F15();
            _ = weighted.AddKey(new KeyframeI17F15(
                (I17F15)0, (I17F15)0, (I17F15)2, (I17F15)2, oneThird, oneThird
            ));
            _ = weighted.AddKey(new KeyframeI17F15(
                (I17F15)1, (I17F15)1, (I17F15)(-1), (I17F15)(-1), oneThird, oneThird
            ));

            // 1/3 は I17F15 で正確に表現できないため僅かな誤差を許容する.
            for (var i = 0; i <= 32; i++) {
                var time = I17F15.FromBits(i * (I17F15.OneRepr / 32));
                var e = (double)hermite.Evaluate(time);
                var a = (double)weighted.Evaluate(time);
                Utility.AssertAreEqual(e, a, 1e-3, $"time:{time}");
            }
        }

        /// <summary>
        /// [0, 1] の範囲外の重みは評価時にクランプされることをテスト.
        /// </summary>
        [Test]
        public static void TestEvaluateWeightedClampI17F15() {
            AnimationCurveI17F15 MakeCurve(I17F15 w0, I17F15 w1) {
                var curve = new AnimationCurveI17F15();
                _ = curve.AddKey(new KeyframeI17F15(
                    (I17F15)0, (I17F15)0, (I17F15)1, (I17F15)1, w0, w0
                ));
                _ = curve.AddKey(new KeyframeI17F15(
                    (I17F15)1, (I17F15)1, (I17F15)(-1), (I17F15)(-1), w1, w1
                ));
                return curve;
            }
            var expected = MakeCurve(I17F15.One, I17F15.Zero);
            var actual = MakeCurve((I17F15)2, (I17F15)(-1));
            for (var i = 0; i <= 32; i++) {
                var time = I17F15.FromBits(i * (I17F15.OneRepr / 32));
                Utility.AssertAreEqual(expected.Evaluate(time), actual.Evaluate(time), $"time:{time}");
            }
        }

        /// <summary>
        /// 重み付きの補間を倍精度の参照実装と比較するテスト.
        /// </summary>
        /// <remarks>
        /// カーブの接線が垂直に近い点では時間の微少な変化に対する
        /// 評価値の感度が本質的に高く, 単純な絶対誤差での比較は適さない.
        /// そのため参照実装を時間の近傍でも評価し, その範囲を
        /// 許容誤差だけ広げた区間に評価値が収まることを確認する.
        /// </remarks>
        [TestCase(1000)]
        public static void TestEvaluateWeightedRandomI17F15(int testCount) {
            var rng = new Xoroshiro128StarStar(1, 2);
            for (var testIndex = 0; testIndex < testCount; testIndex++) {
                var outTime = I17F15.FromBits(rng.Next(-4 * I17F15.OneRepr, 4 * I17F15.OneRepr));
                var inTime = outTime + I17F15.FromBits(rng.Next(32, 4 * I17F15.OneRepr));
                var outValue = I17F15.FromBits(rng.Next(-8 * I17F15.OneRepr, 8 * I17F15.OneRepr));
                var inValue = I17F15.FromBits(rng.Next(-8 * I17F15.OneRepr, 8 * I17F15.OneRepr));
                var outTangent = I17F15.FromBits(rng.Next(-16 * I17F15.OneRepr, 16 * I17F15.OneRepr));
                var inTangent = I17F15.FromBits(rng.Next(-16 * I17F15.OneRepr, 16 * I17F15.OneRepr));
                var outWeight = I17F15.FromBits(rng.Next(0, I17F15.OneRepr + 1));
                var inWeight = I17F15.FromBits(rng.Next(0, I17F15.OneRepr + 1));
                var mode = (WeightedMode)rng.Next(1, 4);

                var curve = new AnimationCurveI17F15();
                _ = curve.AddKey(new KeyframeI17F15(
                    outTime, outValue, outTangent, outTangent, outWeight, outWeight
                ) {
                    WeightedMode = mode,
                });
                _ = curve.AddKey(new KeyframeI17F15(
                    inTime, inValue, inTangent, inTangent, inWeight, inWeight
                ) {
                    WeightedMode = mode,
                });

                // キーの時間ではキーの値が正確に評価されることをテスト.
                Utility.AssertAreEqual(outValue, curve.Evaluate(outTime));
                Utility.AssertAreEqual(inValue, curve.Evaluate(inTime));

                // 補間に使用される重み. 重みを持たない側は 1/3.
                var ow = (mode & WeightedMode.Out) != 0 ? (double)outWeight : 1.0 / 3;
                var iw = (mode & WeightedMode.In) != 0 ? (double)inWeight : 1.0 / 3;

                for (var i = 0; i < 32; i++) {
                    var time = outTime + I17F15.FromBits(
                        (int)(rng.NextInt64(1, (inTime - outTime).Bits))
                    );
                    var actual = (double)curve.Evaluate(time);

                    // 時間の近傍 (前後 2 LSB) で参照実装を評価する.
                    var h = 2.0 / 32768;
                    var lo = double.MaxValue;
                    var hi = double.MinValue;
                    for (var j = -1; j <= 1; j++) {
                        var t = Math.Max(
                            (double)outTime,
                            Math.Min((double)inTime, (double)time + (j * h))
                        );
                        var y = BezierReference(
                            t,
                            (double)outTime, (double)outValue, (double)outTangent, ow,
                            (double)inTime, (double)inValue, (double)inTangent, iw
                        );
                        lo = Math.Min(lo, y);
                        hi = Math.Max(hi, y);
                    }
                    const double delta = 5e-3;
                    if (actual < lo - delta || actual > hi + delta) {
                        Assert.Fail(
                            $"testIndex:{testIndex} time:{time} actual:{actual} " +
                            $"expected:[{lo}, {hi}] outTime:{outTime} inTime:{inTime} " +
                            $"outValue:{outValue} inValue:{inValue} " +
                            $"outTangent:{outTangent} inTangent:{inTangent} " +
                            $"outWeight:{outWeight} inWeight:{inWeight} mode:{mode}"
                        );
                    }
                }
            }
        }
    }
}
