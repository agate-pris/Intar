using System;
using System.Runtime.CompilerServices;

#if UNITY_EDITOR

using UnityEngine;

#endif // UNITY_EDITOR

namespace Intar.Geometry {
    [Serializable]
    public struct SphereI17F15 : IEquatable<SphereI17F15>, IFormattable {

#if NET5_0_OR_GREATER
#pragma warning disable IDE0079 // 不要な抑制を削除します
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public Vector3I17F15 Center;
        public U17F15 Radius;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning restore IDE0079 // 不要な抑制を削除します
#endif

        #region Construction
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SphereI17F15(Vector3I17F15 center, U17F15 radius) {
            Center = center;
            Radius = radius;
        }
        #endregion
        #region IEquatable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(SphereI17F15 other) {
            return Center.Equals(other.Center) && Radius.Equals(other.Radius);
        }
        #endregion
        #region IEqualityOperators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(SphereI17F15 left, SphereI17F15 right) {
            return left.Center.X == right.Center.X && left.Center.Y == right.Center.Y && left.Center.Z == right.Center.Z && left.Radius == right.Radius;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(SphereI17F15 left, SphereI17F15 right) {
            return left.Center.X != right.Center.X || left.Center.Y != right.Center.Y || left.Center.Z != right.Center.Z || left.Radius != right.Radius;
        }
        #endregion
        #region Object
        public override bool Equals(object obj) {
            return obj is SphereI17F15 o && Equals(o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(
            Center, Radius
        );

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() {
            return $"{{Center:{Center} Radius:{Radius}}}";
        }
        #endregion
        #region IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) {
            return $"{{Center:{Center.ToString(format, formatProvider)} Radius:{Radius.ToString(format, formatProvider)}}}";
        }
        #endregion
        #region IMultiplyOperators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SphereI17F15 operator *(AffineTransform3I17F15 left, SphereI17F15 right) {
            var sX = left.DecomposeScaleX();
            var sY = left.DecomposeScaleY();
            var sZ = left.DecomposeScaleZ();
            return new SphereI17F15(
                left * right.Center,
                right.Radius * sX.Max(sY).Max(sZ)
            );
        }
        #endregion
        #region Envelope
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aabb3I17F15 Envelope() {
            return new Aabb3I17F15(this);
        }
        #endregion
        #region Intersects
        /// <summary>Check if the sphere intersects with a point.</summary>
        /// <param name="p">The point to check.</param>
        /// <returns>True if the sphere intersects with the point, false otherwise.</returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        /// <item><description>The radius of the sphere is very large.</description></item>
        /// <item><description>The specified point is very far away.</description></item>
        /// </list>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(Vector3I17F15 p) {
            return Center.DistanceSquared(p) <= Radius.BigMul(Radius);
        }

        /// <summary>Check if the sphere intersects with another sphere.</summary>
        /// <param name="other">The other sphere to check.</param>
        /// <returns>True if the sphere intersects with the other sphere, false otherwise.
        /// </returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        /// <item><description>The sum of the radius of the sphere and the radius of the other
        /// sphere is very large.</description></item>
        /// <item><description>The distance between the center of the sphere and the center of
        /// the other sphere is very large.</description></item>
        /// </list>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(SphereI17F15 other) {
            var r = Radius + other.Radius;
            return Center.DistanceSquared(other.Center) <= r.BigMul(r);
        }
        #endregion
        #region Overlaps
        /// <summary>Check if the sphere overlaps with a point.</summary>
        /// <param name="p">The point to check.</param>
        /// <returns>True if the sphere overlaps with the point, false otherwise.</returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        /// <item><description>The radius of the sphere is very large.</description></item>
        /// <item><description>The specified point is very far away.</description></item>
        /// </list>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps(Vector3I17F15 other) {
            return Center.DistanceSquared(other) < Radius.BigMul(Radius);
        }

        /// <summary>Check if the sphere overlaps with another sphere.</summary>
        /// <param name="other">The other sphere to check.</param>
        /// <returns>True if the sphere overlaps with the other sphere, false otherwise.
        /// </returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        /// <item><description>The sum of the radius of the sphere and the radius of the other
        /// sphere is very large.</description></item>
        /// <item><description>The distance between the center of the sphere and the center of
        /// the other sphere is very large.</description></item>
        /// </list>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps(SphereI17F15 other) {
            var r = Radius + other.Radius;
            return Center.DistanceSquared(other.Center) < r.BigMul(r);
        }
        #endregion

#if UNITY_EDITOR

        #region Draw
        public void Draw() {
            var center = new Vector3(
                (float)Center.X,
                (float)Center.Y,
                (float)Center.Z);
            Gizmos.DrawWireSphere(center, (float)Radius);
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
}
