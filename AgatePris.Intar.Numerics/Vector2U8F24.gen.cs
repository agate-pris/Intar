using AgatePris.Intar.Numerics;
using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Mathematics {
    [Serializable]
    public struct U8F24_2 : IEquatable<U8F24_2>, IFormattable {
        // Fields
        // ---------------------------------------

        public U8F24 x;
        public U8F24 y;

        // Constants
        // ---------------------------------------

        public static readonly U8F24_2 zero;

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public U8F24_2(U8F24 x, U8F24 y) {
            this.x = x;
            this.y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public U8F24_2(U8F24_2 xy) {
            x = xy.x;
            y = xy.y;
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U8F24_2 operator +(U8F24_2 a, U8F24_2 b) => new U8F24_2(
            a.x + b.x,
            a.y + b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U8F24_2 operator -(U8F24_2 a, U8F24_2 b) => new U8F24_2(
            a.x - b.x,
            a.y - b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U8F24_2 operator *(U8F24_2 a, U8F24_2 b) => new U8F24_2(
            a.x * b.x,
            a.y * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U8F24_2 operator *(U8F24_2 a, U8F24 b) => new U8F24_2(
            a.x * b,
            a.y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U8F24_2 operator *(U8F24 a, U8F24_2 b) => new U8F24_2(
            a * b.x,
            a * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U8F24_2 operator /(U8F24_2 a, U8F24_2 b) => new U8F24_2(
            a.x / b.x,
            a.y / b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U8F24_2 operator /(U8F24_2 a, U8F24 b) => new U8F24_2(
            a.x / b,
            a.y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U8F24_2 operator /(U8F24 a, U8F24_2 b) => new U8F24_2(
            a / b.x,
            a / b.y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly U8F24_2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_2(x, x); }
        public readonly U8F24_2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_2(x, y); }
        public readonly U8F24_2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_2(y, x); }
        public readonly U8F24_2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_2(y, y); }
        public readonly U8F24_3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_3(x, x, x); }
        public readonly U8F24_3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_3(x, x, y); }
        public readonly U8F24_3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_3(x, y, x); }
        public readonly U8F24_3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_3(x, y, y); }
        public readonly U8F24_3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_3(y, x, x); }
        public readonly U8F24_3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_3(y, x, y); }
        public readonly U8F24_3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_3(y, y, x); }
        public readonly U8F24_3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_3(y, y, y); }
        public readonly U8F24_4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(x, x, x, x); }
        public readonly U8F24_4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(x, x, x, y); }
        public readonly U8F24_4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(x, x, y, x); }
        public readonly U8F24_4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(x, x, y, y); }
        public readonly U8F24_4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(x, y, x, x); }
        public readonly U8F24_4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(x, y, x, y); }
        public readonly U8F24_4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(x, y, y, x); }
        public readonly U8F24_4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(x, y, y, y); }
        public readonly U8F24_4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(y, x, x, x); }
        public readonly U8F24_4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(y, x, x, y); }
        public readonly U8F24_4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(y, x, y, x); }
        public readonly U8F24_4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(y, x, y, y); }
        public readonly U8F24_4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(y, y, x, x); }
        public readonly U8F24_4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(y, y, x, y); }
        public readonly U8F24_4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(y, y, y, x); }
        public readonly U8F24_4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new U8F24_4(y, y, y, y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(U8F24_2 lhs, U8F24_2 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(U8F24_2 lhs, U8F24_2 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is U8F24_2 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"U8F24_2({x}, {y})";

        // IEquatable<U8F24_2>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(U8F24_2 other)
            => other.x == x
            && other.y == y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = this.x.ToString(format, formatProvider);
            var y = this.y.ToString(format, formatProvider);
            return $"U8F24_2({x}, {y})";
        }
    }
}
