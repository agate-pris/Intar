using Intar.Geometry;
using NUnit.Framework;

namespace Intar.Tests.Geometry {
    public class SphereTest {
        [Test]
        public static void TestPoint() {
            var p1 = Vector3I17F15.Zero;
            var p2 = Vector3I17F15.UnitX;
            var p3 = Vector3I17F15.UnitY;
            var p4 = Vector3I17F15.UnitZ;
            var p5 = Vector3I17F15.One;
            var s1 = new SphereI17F15(p1, U17F15.One);
            var s2 = new SphereI17F15(p2, U17F15.One);
            var s3 = new SphereI17F15(p3, U17F15.One);
            var s4 = new SphereI17F15(p4, U17F15.One);
            Assert.IsTrue(new SphereI17F15().Intersects(p1));
            Assert.IsFalse(new SphereI17F15().Overlaps(p1));
            Assert.IsTrue(s1.Intersects(p1));
            Assert.IsTrue(s1.Intersects(p2));
            Assert.IsTrue(s1.Intersects(p3));
            Assert.IsTrue(s1.Intersects(p4));
            Assert.IsTrue(s2.Intersects(p1));
            Assert.IsTrue(s3.Intersects(p1));
            Assert.IsTrue(s4.Intersects(p1));
            Assert.IsTrue(s1.Overlaps(p1));
            Assert.IsTrue(s2.Overlaps(p2));
            Assert.IsTrue(s3.Overlaps(p3));
            Assert.IsTrue(s4.Overlaps(p4));

            // 距離がちょうど半径に等しい場合 Intersects は真, Overlaps は偽を返す.
            Assert.IsFalse(s1.Overlaps(p2));
            Assert.IsFalse(s1.Overlaps(p3));
            Assert.IsFalse(s1.Overlaps(p4));

            // (1, 1, 1) は 単位球の外側にある.
            Assert.IsFalse(s1.Intersects(p5));
            Assert.IsFalse(s2.Intersects(p3));
            Assert.IsFalse(s2.Intersects(p4));
            Assert.IsFalse(s3.Intersects(p2));
            Assert.IsFalse(s3.Intersects(p4));
            Assert.IsFalse(s4.Intersects(p2));
            Assert.IsFalse(s4.Intersects(p3));
        }
        [Test]
        public static void TestSphere() {
            {
                var o = new SphereI17F15(Vector3I17F15.One * (I17F15)0.5f, U17F15.Zero);
                Assert.IsTrue(o.Intersects(o));
                Assert.IsFalse(o.Overlaps(o));
                var l = new SphereI17F15[] {
                    new SphereI17F15(Vector3I17F15.Zero, U17F15.One),
                    new SphereI17F15(Vector3I17F15.UnitX, U17F15.One),
                    new SphereI17F15(Vector3I17F15.UnitY, U17F15.One),
                    new SphereI17F15(Vector3I17F15.UnitZ, U17F15.One),
                    new SphereI17F15(Vector3I17F15.One, U17F15.One),
                };
                foreach (var a in l) {
                    Assert.IsTrue(o.Intersects(a));
                    Assert.IsTrue(a.Intersects(o));
                    Assert.IsTrue(o.Overlaps(a));
                    Assert.IsTrue(a.Overlaps(o));
                    foreach (var b in l) {
                        Assert.IsTrue(a.Intersects(b), $"a:{a} b:{b}");
                        Assert.IsTrue(a.Overlaps(b), $"a:{a} b:{b}");
                    }
                }
            }
            {
                var a = new SphereI17F15(Vector3I17F15.Zero, (U17F15)0.5f);
                var b = new SphereI17F15(Vector3I17F15.UnitX, (U17F15)0.5f);
                var c = new SphereI17F15(Vector3I17F15.One, (U17F15)0.5f);

                // 中心間の距離がちょうど半径の和に等しい場合
                // Intersects は真, Overlaps は偽を返す.
                Assert.IsTrue(a.Intersects(b));
                Assert.IsFalse(a.Overlaps(b));

                // (0, 0, 0) と (1, 1, 1) の距離は半径の和より大きい.
                Assert.IsFalse(a.Intersects(c));
                Assert.IsFalse(a.Overlaps(c));
            }
        }
        [Test]
        public static void TestEnvelope() {
            var center = new Vector3I17F15(
                I17F15.One,
                I17F15.One + I17F15.One,
                I17F15.One + I17F15.One + I17F15.One);
            var sphere = new SphereI17F15(center, U17F15.One + U17F15.One);
            var aabb = sphere.Envelope();
            Utility.AssertAreEqual(I17F15.NegativeOne, aabb.MinX);
            Utility.AssertAreEqual(I17F15.Zero, aabb.MinY);
            Utility.AssertAreEqual(I17F15.One, aabb.MinZ);
            Utility.AssertAreEqual(I17F15.One + I17F15.One + I17F15.One, aabb.MaxX);
            Utility.AssertAreEqual(I17F15.One + I17F15.One + I17F15.One + I17F15.One, aabb.MaxY);
            Utility.AssertAreEqual(
                I17F15.One + I17F15.One + I17F15.One + I17F15.One + I17F15.One, aabb.MaxZ);
        }
        [Test]
        public static void TestAffineTransform() {
            var sphere = new SphereI17F15(Vector3I17F15.UnitX, U17F15.One);
            var transform = AffineTransform3I17F15.Trs(
                Vector3I17F15.UnitY,
                QuaternionI2F30.Identity,
                Vector3I17F15.One);
            var transformed = transform * sphere;
            Utility.AssertAreEqual(I17F15.One, transformed.Center.X);
            Utility.AssertAreEqual(I17F15.One, transformed.Center.Y);
            Utility.AssertAreEqual(I17F15.Zero, transformed.Center.Z);
            Utility.AssertAreEqual(U17F15.One.Bits, transformed.Radius.Bits);
        }
    }
}
