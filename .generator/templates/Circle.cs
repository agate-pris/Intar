{%- import "macros.cs" as macros %}
{%- set dim = dim | default(value=2) %}
{%- set components = ['X', 'Y', 'Z', 'W']|slice(end=dim) %}
{%- set component   = 'I17F15' %}
{%- set component_u = 'U17F15' %}
{%- if dim == 2 %}
{%- set name = 'circle' %}{% set type = 'Circle' ~ component %}{% elif dim == 3 %}
{%- set name = 'sphere' %}{% set type = 'Sphere' ~ component %}{% else %}
{{- throw(message='not implemented') }}
{%- endif -%}
using System;
using System.Runtime.CompilerServices;

#if UNITY_EDITOR

using UnityEngine;

#endif // UNITY_EDITOR

namespace {{ namespace }}.Geometry {
    [Serializable]
    public struct {{ type }} : IEquatable<{{ type }}>, IFormattable {

#if NET5_0_OR_GREATER
#pragma warning disable IDE0079 // 不要な抑制を削除します
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public {{ macros::vector_type(dim=dim, type=component) }} Center;
        public {{ component_u }} Radius;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning restore IDE0079 // 不要な抑制を削除します
#endif

        #region Construction
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public {{ type }}({{ macros::vector_type(dim=dim, type=component) }} center, {{ component_u }} radius) {
            Center = center;
            Radius = radius;
        }
        #endregion
        #region IEquatable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals({{ type }} other) {
            return Center.Equals(other.Center) && Radius.Equals(other.Radius);
        }
        #endregion
        #region IEqualityOperators
        {%- for op in ['==', '!='] %}
        {%- if op == '==' -%}
        {%- set combine = '&&' %}{% else %}
        {%- set combine = '||' %}{% endif %}
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator {{ op }}({{ type }} left, {{ type }} right) {
            return
                {%- for c in components -%}
                {#- #} left.Center.{{ c }} {{ op }} right.Center.{{ c }} {{ combine }}
                {%- endfor %}
                {#- #} left.Radius {{ op }} right.Radius;
        }
        {%- endfor %}
        #endregion
        #region Object
        public override bool Equals(object obj) {
            return obj is {{ type }} o && Equals(o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(
            Center, Radius
        );

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() {
            return $"{{ '{{' }}Center:{Center} Radius:{Radius}{{ '}}' }}";
        }
        #endregion
        #region IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider) {
            return $"{{ '{{' }}Center:{Center.ToString(format, formatProvider)} Radius:{Radius.ToString(format, formatProvider)}{{ '}}' }}";
        }
        #endregion
        #region IMultiplyOperators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ type }} operator *(AffineTransform{{ dim }}{{ component }} left, {{ type }} right) {
            {%- for c in components %}
            var s{{ c }} = left.DecomposeScale{{ c }}();
            {%- endfor %}
            return new {{ type }}(
                left * right.Center,
                right.Radius * sX
                {%- for i in range(start=1, end=dim) -%}
                .Max(s{{ components[i] }})
                {%- endfor %}
            );
        }
        {%- if dim == 2 %}
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ type }} operator *(AffineTransform3{{ component }} left, {{ type }} right) {
            return new AffineTransform2{{ component }}(
                new Matrix2x2{{ component }}(
                    left.RotationScale.C0.XY(),
                    left.RotationScale.C1.XY()
                ), left.Translation.XY()
            ) * right;
        }
        {%- endif %}
        #endregion
        #region Envelope
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Aabb{{ dim }}{{ component }} Envelope() {
            return new Aabb{{ dim }}{{ component }}(this);
        }
        #endregion
        #region Intersects
        /// <summary>Check if the {{ name }} intersects with a point.</summary>
        /// <param name="p">The point to check.</param>
        /// <returns>True if the {{ name }} intersects with the point, false otherwise.</returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        {%- if dim > 2 %}
        /// <item><description>The radius of the {{ name }} is very large.</description></item>
        {%- endif %}
        /// <item><description>The specified point is very far away.</description></item>
        /// </list>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects({{ macros::vector_type(dim=dim, type=component) }} p) {
            return Center.DistanceSquared(p) <= Radius.BigMul(Radius);
        }

        /// <summary>Check if the {{ name }} intersects with another {{ name }}.</summary>
        /// <param name="other">The other {{ name }} to check.</param>
        /// <returns>True if the {{ name }} intersects with the other {{ name }}, false otherwise.
        /// </returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        /// <item><description>The sum of the radius of the {{ name }} and the radius of the other
        /// {{ name }} is very large.</description></item>
        /// <item><description>The distance between the center of the {{ name }} and the center of
        /// the other {{ name }} is very large.</description></item>
        /// </list>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects({{ type }} other) {
            var r = Radius + other.Radius;
            return Center.DistanceSquared(other.Center) <= r.BigMul(r);
        }
        #endregion
        #region Overlaps
        /// <summary>Check if the {{ name }} overlaps with a point.</summary>
        /// <param name="p">The point to check.</param>
        /// <returns>True if the {{ name }} overlaps with the point, false otherwise.</returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        {%- if dim > 2 %}
        /// <item><description>The radius of the {{ name }} is very large.</description></item>
        {%- endif %}
        /// <item><description>The specified point is very far away.</description></item>
        /// </list>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps({{ macros::vector_type(dim=dim, type=component) }} other) {
            return Center.DistanceSquared(other) < Radius.BigMul(Radius);
        }

        /// <summary>Check if the {{ name }} overlaps with another {{ name }}.</summary>
        /// <param name="other">The other {{ name }} to check.</param>
        /// <returns>True if the {{ name }} overlaps with the other {{ name }}, false otherwise.
        /// </returns>
        /// <remarks>
        /// <div class="WARNING alert alert-info">
        /// <h5>WARNING</h5>
        /// <para>This method causes an <b>overflow</b> in the following case:</para>
        /// <list type="bullet">
        /// <item><description>The sum of the radius of the {{ name }} and the radius of the other
        /// {{ name }} is very large.</description></item>
        /// <item><description>The distance between the center of the {{ name }} and the center of
        /// the other {{ name }} is very large.</description></item>
        /// </list>
        /// </div>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps({{ type }} other) {
            var r = Radius + other.Radius;
            return Center.DistanceSquared(other.Center) < r.BigMul(r);
        }
        #endregion

#if UNITY_EDITOR

        #region Draw
        {%- if dim == 2 %}
        public void Draw(float z) {
            var x = (float)Center.X;
            var y = (float)Center.Y;
            var radius = (float)Radius;
            Gizmos.DrawLine(
                new Vector3(x, y, z),
                new Vector3(x + radius, y, z));
            const int div = 60;
            for (var i = 0; i < div; i++) {
                const float toRad = 2 * Mathf.PI / div;
                var th1 = i * toRad;
                var th2 = (i + 1) * toRad;
                var px = (Mathf.Cos(th1) * radius) + x;
                var py = (Mathf.Sin(th1) * radius) + y;
                var qx = (Mathf.Cos(th2) * radius) + x;
                var qy = (Mathf.Sin(th2) * radius) + y;
                Gizmos.DrawLine(
                    new Vector3(px, py, z),
                    new Vector3(qx, qy, z));
            }
        }
        {%- else %}
        public void Draw() {
            var center = new Vector3(
                (float)Center.X,
                (float)Center.Y,
                (float)Center.Z);
            Gizmos.DrawWireSphere(center, (float)Radius);
        }
        {%- endif %}
        public void Draw(AffineTransform3{{ component }} transform) {
            (transform * this).Draw({% if dim == 2 %}(float)transform.Translation.Z{% endif %});
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
