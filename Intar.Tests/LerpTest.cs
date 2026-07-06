using Intar.Rand;
using NUnit.Framework;

namespace Intar.Tests {
    public class LerpTest {
        [Test]
        public static void TestEndpoints() {
            var values = new I17F15[] {
                I17F15.MinValue,
                I17F15.MaxValue,
                I17F15.NegativeOne,
                I17F15.Zero,
                I17F15.One,
                I17F15.FromBits(1),
                I17F15.FromBits(-1),
            };
            foreach (var a in values) {
                foreach (var b in values) {
                    Utility.AssertAreEqual(a, a.Lerp(b, I17F15.Zero));
                    Utility.AssertAreEqual(b, a.Lerp(b, I17F15.One));

                    // t は 0 以上 1 以下の範囲に制限される｡
                    Utility.AssertAreEqual(a, a.Lerp(b, I17F15.NegativeOne));
                    Utility.AssertAreEqual(a, a.Lerp(b, I17F15.MinValue));
                    Utility.AssertAreEqual(b, a.Lerp(b, I17F15.One.Twice()));
                    Utility.AssertAreEqual(b, a.Lerp(b, I17F15.MaxValue));
                }
            }
        }

        [Test]
        public static void TestMidpoint() {
            var a = I17F15.Zero;
            var b = I17F15.One;
            var t = I17F15.One.Half();
            Utility.AssertAreEqual(t, a.Lerp(b, t));
        }

        [Test]
        public static void TestRandom() {
            var rng = new Xoroshiro128StarStar(1, 2);
            const double delta = 1.0 / (1 << 15);
            for (var i = 0; i < 9999; ++i) {
                var a = I17F15.FromBits(rng.Next());
                var b = I17F15.FromBits(rng.Next());
                var t = rng.NextI17F15();
                var expected = (double)a + ((double)b - (double)a) * (double)t;
                Utility.AssertAreEqual(expected, (double)a.Lerp(b, t), delta);
            }
        }

        [Test]
        public static void TestVector() {
            var rng = new Xoroshiro128StarStar(1, 2);
            for (var i = 0; i < 999; ++i) {
                var a = new Vector4I17F15(
                    I17F15.FromBits(rng.Next()),
                    I17F15.FromBits(rng.Next()),
                    I17F15.FromBits(rng.Next()),
                    I17F15.FromBits(rng.Next()));
                var b = new Vector4I17F15(
                    I17F15.FromBits(rng.Next()),
                    I17F15.FromBits(rng.Next()),
                    I17F15.FromBits(rng.Next()),
                    I17F15.FromBits(rng.Next()));
                var t = rng.NextI17F15();
                {
                    var actual = a.Lerp(b, t);
                    Utility.AssertAreEqual(a.X.Lerp(b.X, t), actual.X);
                    Utility.AssertAreEqual(a.Y.Lerp(b.Y, t), actual.Y);
                    Utility.AssertAreEqual(a.Z.Lerp(b.Z, t), actual.Z);
                    Utility.AssertAreEqual(a.W.Lerp(b.W, t), actual.W);
                }
                {
                    var actual = a.XYZ().Lerp(b.XYZ(), t);
                    Utility.AssertAreEqual(a.X.Lerp(b.X, t), actual.X);
                    Utility.AssertAreEqual(a.Y.Lerp(b.Y, t), actual.Y);
                    Utility.AssertAreEqual(a.Z.Lerp(b.Z, t), actual.Z);
                }
                {
                    var actual = a.XY().Lerp(b.XY(), t);
                    Utility.AssertAreEqual(a.X.Lerp(b.X, t), actual.X);
                    Utility.AssertAreEqual(a.Y.Lerp(b.Y, t), actual.Y);
                }
            }
        }
    }
}
