using System;
using System.Runtime.CompilerServices;

#if UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

namespace Intar.Geometry {
    [Serializable]
    public struct Segment3I17F15 : IEquatable<Segment3I17F15>, IFormattable {
        #region P1, P2

#if NET5_0_OR_GREATER
#pragma warning disable IDE0079 // 不要な抑制を削除します
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public Vector3I17F15 P1;
        public Vector3I17F15 P2;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning restore IDE0079 // 不要な抑制を削除します
#endif

        #endregion
        #region Construction
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Segment3I17F15(Vector3I17F15 p1, Vector3I17F15 p2) {
            P1 = p1;
            P2 = p2;
        }
        #endregion
        #region IEquatable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Segment3I17F15 other) {
            return P1.Equals(other.P1) && P2.Equals(other.P2);
        }
        #endregion
        #region IEqualityOperators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Segment3I17F15 left, Segment3I17F15 right) {
            return left.Equals(right);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Segment3I17F15 left, Segment3I17F15 right) {
            return !left.Equals(right);
        }
        #endregion
        #region Object
        public override bool Equals(object obj) {
            return obj is Segment3I17F15 o && Equals(o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(P1, P2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() {
            return $"{{P1:{P1} P2:{P2}}}";
        }
        #endregion
        #region IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) {
            return $"{{P1:{P1.ToString(format, formatProvider)} P2:{P2.ToString(format, formatProvider)}}}";
        }
        #endregion
        #region IMultiplyOperators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Segment3I17F15 operator *(AffineTransform3I17F15 left, Segment3I17F15 right) {
            return new Segment3I17F15(left * right.P1, left * right.P2);
        }
        #endregion
        #region Envelope
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aabb3I17F15 Envelope() {
            return new Aabb3I17F15(this);
        }
        #endregion
        #region ClosestPoint
        /// <summary>
        /// 線分上で最も点 p に近い点を求める。
        /// 線分が極端に短い場合 P1 を返す。
        /// 線分が極端に長い場合、または点 p が極端に遠い場合、
        /// オーバーフローを引き起こす。
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3I17F15 ClosestPoint(Vector3I17F15 p) {
            var v = P2 - P1;

            // あとで除算するので小数部のビット数を 15 にする.
            // 線分が極端に長い場合 v ･ v はオーバーフローする.
            var vv = v.Dot(v).Bits / I17F15.OneRepr;
            if (vv == 0) {
                return P1;
            }

            // 点 p が極端に遠い場合 u ･ v はオーバーフローする.

            var u = p - P1;
            var uv = u.Dot(v).Bits;

            // ドット積の小数部のビット数は 30 になるので,
            // これを vv で割ると, その小数部のビット数は 15 になる.

#if NET5_0_OR_GREATER

            var tBits = Math.Clamp(uv / vv, 0, I17F15.OneRepr);

#else

            var tBits = Mathi.Clamp(uv / vv, 0, I17F15.OneRepr);

#endif

            var t = I17F15.FromBits((int)tBits);
            return P1 + (v * t);
        }
        #endregion
        #region Intersects

        // 線分と点の交差判定は実装しない.

        /// <summary>Check if the segment intersects with a sphere.</summary>
        /// <param name="sphere">The sphere to check.</param>
        /// <returns>True if the segment intersects with the sphere, false otherwise.</returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        /// <item><description>The segment is very long.</description></item>
        /// <item><description>The distance between the segment and the center of the sphere is
        /// very large.</description></item>
        /// </list>
        /// </div>
        /// <div class="NOTE alert alert-info">
        /// <h5>NOTE</h5><para>The accuracy reduces when the segment is very short.</para>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(SphereI17F15 sphere) {
            var closestPoint = ClosestPoint(sphere.Center);
            var distanceSquared = (closestPoint - sphere.Center).LengthSquared();
            return distanceSquared <= sphere.Radius.BigMul(sphere.Radius);
        }
        #endregion
        #region Overlaps

        /// <summary>Check if the segment overlaps with a sphere.
        /// </summary>
        /// <param name="sphere">The sphere to check.</param>
        /// <returns>True if the segment overlaps with the sphere,
        /// false otherwise.</returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following
        /// case:</para>
        /// <list type="bullet">
        /// <item><description>The segment is very long.
        /// </description></item>
        /// <item><description>The distance between the segment and the
        /// center of the sphere is very large.</description></item>
        /// </list>
        /// </div>
        /// <div class="NOTE alert alert-info">
        /// <h5>NOTE</h5><para>The accuracy reduces when the segment is
        /// very short.</para>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps(SphereI17F15 sphere) {
            var closestPoint = ClosestPoint(sphere.Center);
            var distanceSquared = (closestPoint - sphere.Center).LengthSquared();
            return distanceSquared < sphere.Radius.BigMul(sphere.Radius);
        }
        #endregion

#if UNITY_EDITOR

        #region Draw
        public void Draw() {
            var p1 = new Vector3((float)P1.X, (float)P1.Y, (float)P1.Z);
            var p2 = new Vector3((float)P2.X, (float)P2.Y, (float)P2.Z);
            Gizmos.DrawLine(p1, p2);
        }
        public void Draw(AffineTransform3I17F15 transform) {
            (transform * this).Draw();
        }
        public void Draw(Matrix4x4 matrix) {
            Draw((AffineTransform3I17F15)matrix);
        }
        public void Draw(Transform transform) {
            Draw(transform.localToWorldMatrix);
        }
        #endregion

#endif // UNITY_EDITOR

    }
} // namespace Intar.Geometry
