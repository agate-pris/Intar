using Intar.Geometry;
using NUnit.Framework;

namespace Intar.Tests.Geometry {
    public class Segment3Test {
        [Test]
        public static void TestClosestPoint() {
            var segment = new Segment3I17F15(
                Vector3I17F15.Zero,
                Vector3I17F15.UnitX + Vector3I17F15.UnitX);
            {
                // 線分の始点より手前の点
                var p = segment.ClosestPoint(-Vector3I17F15.One);
                Utility.AssertAreEqual(I17F15.Zero, p.X);
                Utility.AssertAreEqual(I17F15.Zero, p.Y);
                Utility.AssertAreEqual(I17F15.Zero, p.Z);
            }
            {
                // 線分の終点より先の点
                var p = segment.ClosestPoint(new Vector3I17F15(
                    I17F15.One + I17F15.One + I17F15.One,
                    I17F15.One,
                    I17F15.One));
                Utility.AssertAreEqual(I17F15.One + I17F15.One, p.X);
                Utility.AssertAreEqual(I17F15.Zero, p.Y);
                Utility.AssertAreEqual(I17F15.Zero, p.Z);
            }
            {
                // 線分の中間に射影される点
                var p = segment.ClosestPoint(new Vector3I17F15(
                    I17F15.One,
                    I17F15.One,
                    I17F15.NegativeOne));
                Utility.AssertAreEqual(I17F15.One, p.X);
                Utility.AssertAreEqual(I17F15.Zero, p.Y);
                Utility.AssertAreEqual(I17F15.Zero, p.Z);
            }
            {
                // 長さ 0 の線分は P1 を返す.
                var degenerate = new Segment3I17F15(Vector3I17F15.One, Vector3I17F15.One);
                var p = degenerate.ClosestPoint(Vector3I17F15.Zero);
                Utility.AssertAreEqual(I17F15.One, p.X);
                Utility.AssertAreEqual(I17F15.One, p.Y);
                Utility.AssertAreEqual(I17F15.One, p.Z);
            }
        }
        [Test]
        public static void TestSphere() {
            var segment = new Segment3I17F15(
                Vector3I17F15.Zero,
                Vector3I17F15.UnitX + Vector3I17F15.UnitX);
            {
                // 線分の中間の真上にある球
                var sphere = new SphereI17F15(
                    new Vector3I17F15(I17F15.One, I17F15.One, I17F15.Zero),
                    U17F15.One);

                // 距離がちょうど半径に等しい場合 Intersects は真, Overlaps は偽を返す.
                Assert.IsTrue(segment.Intersects(sphere));
                Assert.IsFalse(segment.Overlaps(sphere));
            }
            {
                var sphere = new SphereI17F15(
                    new Vector3I17F15(I17F15.One, I17F15.One, I17F15.Zero),
                    (U17F15)1.5f);
                Assert.IsTrue(segment.Intersects(sphere));
                Assert.IsTrue(segment.Overlaps(sphere));
            }
            {
                // 線分から半径より遠い球
                var sphere = new SphereI17F15(
                    new Vector3I17F15(I17F15.One, I17F15.One + I17F15.One, I17F15.Zero),
                    U17F15.One);
                Assert.IsFalse(segment.Intersects(sphere));
                Assert.IsFalse(segment.Overlaps(sphere));
            }
        }
        [Test]
        public static void TestEnvelope() {
            var segment = new Segment3I17F15(
                new Vector3I17F15(I17F15.One, I17F15.NegativeOne, I17F15.Zero),
                new Vector3I17F15(I17F15.NegativeOne, I17F15.One, I17F15.One));
            var aabb = segment.Envelope();
            Utility.AssertAreEqual(I17F15.NegativeOne, aabb.MinX);
            Utility.AssertAreEqual(I17F15.NegativeOne, aabb.MinY);
            Utility.AssertAreEqual(I17F15.Zero, aabb.MinZ);
            Utility.AssertAreEqual(I17F15.One, aabb.MaxX);
            Utility.AssertAreEqual(I17F15.One, aabb.MaxY);
            Utility.AssertAreEqual(I17F15.One, aabb.MaxZ);
        }
        [Test]
        public static void TestAabb3() {
            var a = Aabb3I17F15.StrictFromMinMax(
                -Vector3I17F15.One,
                Vector3I17F15.One);
            var b = Aabb3I17F15.StrictFromMinMax(
                Vector3I17F15.One,
                Vector3I17F15.One + Vector3I17F15.One);
            var c = Aabb3I17F15.StrictFromMinMax(
                Vector3I17F15.One + Vector3I17F15.One,
                Vector3I17F15.One + Vector3I17F15.One + Vector3I17F15.One);

            // 境界がちょうど接している場合 Intersects は真, Overlaps は偽を返す.
            Assert.IsTrue(a.Intersects(b));
            Assert.IsFalse(a.Overlaps(b));

            Assert.IsFalse(a.Intersects(c));
            Assert.IsFalse(a.Overlaps(c));

            Assert.IsTrue(a.Intersects(Vector3I17F15.Zero));
            Assert.IsTrue(a.Overlaps(Vector3I17F15.Zero));
            Assert.IsTrue(a.Intersects(Vector3I17F15.One));
            Assert.IsFalse(a.Overlaps(Vector3I17F15.One));

            // Encapsulate で拡張できる.
            var d = new Aabb3I17F15(Vector3I17F15.Zero);
            d.Encapsulate(Vector3I17F15.One + Vector3I17F15.One + Vector3I17F15.One);
            Assert.IsTrue(d.Intersects(c));
        }
    }
}
