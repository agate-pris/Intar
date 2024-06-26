{% import "macros.cs" as macros %}

{% macro self_type() %}
    {{- macros::fixed_type(s = signed, i = int_nbits, f = frac_nbits) }}
{%- endmacro -%}

{%- macro self_bits_type() %}
    {{- macros::bits_type(s=signed, i=int_nbits, f=frac_nbits) }}
{%- endmacro -%}

{% macro self_wide_bits_type() %}
    {{- macros::wide_bits_type(s=signed, i=int_nbits, f=frac_nbits) }}
{%- endmacro -%}

{%- macro one_literal(t) %}
    {%- if t == "int"     -%}1
    {%- elif t == "uint"  -%}1U
    {%- elif t == "long"  -%}1L
    {%- elif t == "ulong" -%}1UL
    {%- else %}
        {{ throw(message=t) }}
    {%- endif %}
{%- endmacro %}

{%- macro def_conv(s, i, f) %}
    {#- 自身と異なる型の場合のみ定義する #}
    {%- if s != signed or i != int_nbits or f != frac_nbits %}
        {%- set sbt = self::self_bits_type() %}
        {%- set self_bits_type_one = self::one_literal(t = sbt) %}
        {%- set target_bits_type = macros::bits_type(s=s, i=i, f=f) -%}
        {%- set target_bits_type_one = self::one_literal(t = target_bits_type) %}
        {%- set target_type = macros::fixed_type(s=s, i=i, f=f) %}
        {%- set explicit = signed and s == false or frac_nbits > f or
            signed and s and int_nbits > i or
            signed and not s and int_nbits - 1 > i or
            not signed and s and int_nbits > i - 1 or
            not signed and not s and int_nbits > i
        %}
        {%- set cast =
            sbt == "int" and (target_bits_type == "uint" or target_bits_type == "ulong") or
            sbt == "uint" and (target_bits_type == "int") or
            sbt == "long" and (target_bits_type == "int" or target_bits_type == "uint" or target_bits_type == "ulong") or
            sbt == "ulong" and (target_bits_type == "int" or target_bits_type == "uint" or target_bits_type == "long")
        %}
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static
        {%- if explicit %} explicit
        {%- else %} implicit
        {%- endif %} operator {{ target_type }}(
        {{- self::self_type() }} x) => {{ target_type -}}
        .FromBits(
        {%- if f == frac_nbits -%}
            {%- if cast %}({{ target_bits_type }}){% endif -%}
            x.Bits
            {%- elif f > frac_nbits -%}
            {%- if cast %}({{ target_bits_type }}){% endif -%}
            x.Bits * (
                {{- target_bits_type_one }} << {{ f - frac_nbits -}}
            )
            {%- else -%}
            {%- if cast %}({{ target_bits_type }})({% endif -%}
            x.Bits / (
                {{- self_bits_type_one }} << {{ frac_nbits - f -}}
            )
            {%- if cast %}){% endif %}
        {%- endif -%}
        );
    {%- endif %}
{%- endmacro %}

{%- macro explicit_conversion_to_fixed() %}
{%- for i in range(start = 1, end = 31) %}
    {{- self::def_conv(s=true, i=32-i, f=i) }}
{%- endfor %}
{%- for i in range(start = 1, end = 31) %}
    {{- self::def_conv(s=false, i=32-i, f=i) }}
{%- endfor %}
{%- for i in range(start = 1, end = 63) %}
    {{- self::def_conv(s=true, i=64-i, f=i) }}
{%- endfor %}
{%- for i in range(start = 1, end = 63) %}
    {{- self::def_conv(s=false, i=64-i, f=i) }}
{%- endfor %}
{%- endmacro -%}

using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct {{ self::self_type() }} : IEquatable<{{ self::self_type() }}>, IFormattable {
        // Consts
        // ------

        public const int IntNbits = {{ int_nbits }};
        public const int FracNbits = {{ frac_nbits }};

        const {{ self::self_bits_type() }} oneRepr = 1{% if self::self_bits_type() == "int" -%}
        {%- elif self::self_bits_type() == "uint" -%}U
        {%- elif self::self_bits_type() == "long" -%}L
        {%- elif self::self_bits_type() == "ulong" -%}UL
        {%- else %}{{ throw(message = "self::self_bits_type returns unknown value.") }}
        {%- endif %} << FracNbits;

        // Fields
        // ------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public {{ self::self_bits_type() }} Bits;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        {{ self::self_type() }}({{ self::self_bits_type() }} bits) {
            Bits = bits;
        }

        // Static methods
        // --------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ self::self_type() }} FromBits({{ self::self_bits_type() }} bits) => new {{ self::self_type() }}(bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ self::self_type() }} FromNum({{ self::self_bits_type() }} num) => FromBits(num * oneRepr);

        // Static Properties
        // -----------------

        public static {{ self::self_type() }} Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => FromNum(0);
        }
        public static {{ self::self_type() }} One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => FromNum(1);
        }
        public static {{ self::self_type() }} MinValue {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => FromBits({{ self::self_bits_type() }}.MinValue);
        }
        public static {{ self::self_type() }} MaxValue {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => FromBits({{ self::self_bits_type() }}.MaxValue);
        }

        // Arithmetic Operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ self::self_type() }} operator +({{ self::self_type() }} left, {{ self::self_type() }} right) {
            return FromBits(left.Bits + right.Bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ self::self_type() }} operator -({{ self::self_type() }} left, {{ self::self_type() }} right) {
            return FromBits(left.Bits - right.Bits);
        }

{%- if int_nbits + frac_nbits == 64 %}

        // 128 ビット整数型は .NET 7 以降にしか無いので,
        // 乗算, 除算演算子は .NET 7 以降でのみ使用可能.

#if NET7_0_OR_GREATER

{%- endif %}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ self::self_type() }} operator *({{ self::self_type() }} left, {{ self::self_type() }} right) {
            {{ self::self_wide_bits_type() }} l = left.Bits;
            return FromBits(({{ self::self_bits_type() }})(l * right.Bits / oneRepr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ self::self_type() }} operator /({{ self::self_type() }} left, {{ self::self_type() }} right) {
            {{ self::self_wide_bits_type() }} l = left.Bits;
            return FromBits(({{ self::self_bits_type() }})(l * oneRepr / right.Bits));
        }

{%- if int_nbits + frac_nbits == 64 %}

#endif

{%- endif %}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ self::self_type() }} operator +({{ self::self_type() }} x) => FromBits(+x.Bits);

{%- if signed %}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {{ self::self_type() }} operator -({{ self::self_type() }} x) => FromBits(-x.Bits);
{%- endif %}

        // Comparison operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==({{ self::self_type() }} lhs, {{ self::self_type() }} rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=({{ self::self_type() }} lhs, {{ self::self_type() }} rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <({{ self::self_type() }} left, {{ self::self_type() }} right) => left.Bits < right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >({{ self::self_type() }} left, {{ self::self_type() }} right) => left.Bits > right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=({{ self::self_type() }} left, {{ self::self_type() }} right) => left.Bits <= right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=({{ self::self_type() }} left, {{ self::self_type() }} right) => left.Bits >= right.Bits;

        // Methods
        // -------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly {{ self::self_type() }} Min({{ self::self_type() }} other) => FromBits(Math.Min(Bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly {{ self::self_type() }} Max({{ self::self_type() }} other) => FromBits(Math.Max(Bits, other.Bits));
{%- if signed %}
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly {{ self::self_type() }} Abs() => FromBits(Math.Abs(Bits));
{%- endif %}

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly {{ self::self_type() }} LosslessMul(
            {{- self::self_bits_type() }} other) => FromBits(Bits * other);
{%- if int_nbits != 2 %}
{%- for i in range(start = 1, end = int_nbits - 1) %}
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly {% if signed %}I{% else %}U{% endif %}{{ int_nbits - i }}F{{ frac_nbits + i }} LosslessMul({% if signed %}I{% else %}U{% endif %}{{ int_nbits + frac_nbits - i }}F{{ i }} other) => {% if signed %}I{% else %}U{% endif %}{{ int_nbits - i }}F{{ frac_nbits + i }}.FromBits(Bits * other.Bits);
{%- endfor %}
{%- endif %}

{%- if int_nbits + frac_nbits == 32 %}

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly {% if signed %}I{% else %}U{% endif %}{{ int_nbits + 32 }}F{{ frac_nbits }} WideningMul(
            {{- self::self_bits_type() }} other) => {% if signed %}I{% else %}U{% endif %}{{ int_nbits + 32 }}F{{ frac_nbits }}.FromBits((
                {{- self::self_wide_bits_type() -}}
            )Bits * other);
{%- for i in range(start = 1, end = 31) %}
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly {% if signed %}I{% else %}U{% endif %}{{ int_nbits + 32 - i }}F{{ frac_nbits + i }} WideningMul({% if signed %}I{% else %}U{% endif %}{{ 32 - i }}F{{ i }} other) => {% if signed %}I{% else %}U{% endif %}{{ int_nbits +32 - i }}F{{ frac_nbits + i }}.FromBits(({% if signed %}long{% else %}ulong{% endif %})Bits * other.Bits);
{%- endfor %}

{%- endif %}

        // Conversion operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator int({{ self::self_type() }} x) => {% if self::self_bits_type() != "int" %}(int)({% endif %}x.Bits / oneRepr{% if self::self_bits_type() != "int" %}){% endif %};
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator uint({{ self::self_type() }} x) => {% if self::self_bits_type() != "uint" %}(uint)({% endif %}x.Bits / oneRepr{% if self::self_bits_type() != "uint" %}){% endif %};
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator long({{ self::self_type() }} x) => {% if self::self_bits_type() == "ulong" %}(long)({% endif %}x.Bits / oneRepr{% if self::self_bits_type() == "ulong" %}){% endif %};
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator ulong({{ self::self_type() }} x) => {% if signed %}(ulong)({% endif %}x.Bits / oneRepr{% if signed %}){% endif %};

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float({{ self::self_type() }} x) {
            const float k = 1.0f / oneRepr;
            return k * x.Bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double({{ self::self_type() }} x) {
            const double k = 1.0 / oneRepr;
            return k * x.Bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator decimal({{ self::self_type() }} x) {
            const decimal k = 1.0M / oneRepr;
            return k * x.Bits;
        }
{{ self::explicit_conversion_to_fixed() }}

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is {{ self::self_type() }} o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => Bits.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((double)this).ToString((IFormatProvider)null);

        // IEquatable<{{ self::self_type() }}>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals({{ self::self_type() }} other) => Bits == other.Bits;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            return ((double)this).ToString(format, formatProvider);
        }
    }
}
