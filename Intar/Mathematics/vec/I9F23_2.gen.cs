using AgatePris.Intar.Fixed;
using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Mathematics {
    [Serializable]
    public struct I9F23_2 : IEquatable<I9F23_2>, IFormattable {
        // Fields
        // ---------------------------------------

        public I9F23 x;
        public I9F23 y;

        // Constants
        // ---------------------------------------

        public static readonly I9F23_2 zero;

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public I9F23_2(I9F23 x, I9F23 y) {
            this.x = x;
            this.y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public I9F23_2(I9F23_2 xy) {
            x = xy.x;
            y = xy.y;
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 operator +(I9F23_2 a, I9F23_2 b) => new I9F23_2(
            a.x + b.x,
            a.y + b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 operator -(I9F23_2 a, I9F23_2 b) => new I9F23_2(
            a.x - b.x,
            a.y - b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 operator *(I9F23_2 a, I9F23_2 b) => new I9F23_2(
            a.x * b.x,
            a.y * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 operator *(I9F23_2 a, I9F23 b) => new I9F23_2(
            a.x * b,
            a.y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 operator *(I9F23 a, I9F23_2 b) => new I9F23_2(
            a * b.x,
            a * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 operator /(I9F23_2 a, I9F23_2 b) => new I9F23_2(
            a.x / b.x,
            a.y / b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 operator /(I9F23_2 a, I9F23 b) => new I9F23_2(
            a.x / b,
            a.y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 operator /(I9F23 a, I9F23_2 b) => new I9F23_2(
            a / b.x,
            a / b.y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly I9F23_2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_2(x, x); }
        public readonly I9F23_2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_2(x, y); }
        public readonly I9F23_2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_2(y, x); }
        public readonly I9F23_2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_2(y, y); }
        public readonly I9F23_3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_3(x, x, x); }
        public readonly I9F23_3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_3(x, x, y); }
        public readonly I9F23_3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_3(x, y, x); }
        public readonly I9F23_3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_3(x, y, y); }
        public readonly I9F23_3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_3(y, x, x); }
        public readonly I9F23_3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_3(y, x, y); }
        public readonly I9F23_3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_3(y, y, x); }
        public readonly I9F23_3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_3(y, y, y); }
        public readonly I9F23_4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(x, x, x, x); }
        public readonly I9F23_4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(x, x, x, y); }
        public readonly I9F23_4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(x, x, y, x); }
        public readonly I9F23_4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(x, x, y, y); }
        public readonly I9F23_4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(x, y, x, x); }
        public readonly I9F23_4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(x, y, x, y); }
        public readonly I9F23_4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(x, y, y, x); }
        public readonly I9F23_4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(x, y, y, y); }
        public readonly I9F23_4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(y, x, x, x); }
        public readonly I9F23_4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(y, x, x, y); }
        public readonly I9F23_4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(y, x, y, x); }
        public readonly I9F23_4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(y, x, y, y); }
        public readonly I9F23_4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(y, y, x, x); }
        public readonly I9F23_4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(y, y, x, y); }
        public readonly I9F23_4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(y, y, y, x); }
        public readonly I9F23_4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new I9F23_4(y, y, y, y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(I9F23_2 lhs, I9F23_2 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(I9F23_2 lhs, I9F23_2 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is I9F23_2 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"I9F23_2({x}, {y})";

        // IEquatable<I9F23_2>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(I9F23_2 other)
            => other.x == x
            && other.y == y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = this.x.ToString(format, formatProvider);
            var y = this.y.ToString(format, formatProvider);
            return $"I9F23_2({x}, {y})";
        }
    }

    public static partial class math {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 I9F23_2(I9F23 x, I9F23 y) => new I9F23_2(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I9F23_2 I9F23_2(I9F23_2 xy) => new I9F23_2(xy);
    }
}