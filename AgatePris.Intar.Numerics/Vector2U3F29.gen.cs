using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector2U3F29 : IEquatable<Vector2U3F29>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public U3F29 X;
        public U3F29 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U3F29(U3F29 x, U3F29 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U3F29(U3F29 value) : this(value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U3F29(Vector2U3F29 xy) : this(xy.X, xy.Y) { }

        // Constants
        // ---------------------------------------

        public static Vector2U3F29 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U3F29(U3F29.Zero);
        }
        public static Vector2U3F29 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U3F29(U3F29.One);
        }
        public static Vector2U3F29 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U3F29(U3F29.One, U3F29.Zero);
        }
        public static Vector2U3F29 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U3F29(U3F29.Zero, U3F29.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U3F29 operator +(Vector2U3F29 a, Vector2U3F29 b) => new Vector2U3F29(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U3F29 operator -(Vector2U3F29 a, Vector2U3F29 b) => new Vector2U3F29(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U3F29 operator *(Vector2U3F29 a, Vector2U3F29 b) => new Vector2U3F29(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U3F29 operator *(Vector2U3F29 a, U3F29 b) => new Vector2U3F29(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U3F29 operator *(U3F29 a, Vector2U3F29 b) => new Vector2U3F29(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U3F29 operator /(Vector2U3F29 a, Vector2U3F29 b) => new Vector2U3F29(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U3F29 operator /(Vector2U3F29 a, U3F29 b) => new Vector2U3F29(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U3F29 operator /(U3F29 a, Vector2U3F29 b) => new Vector2U3F29(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2U3F29 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U3F29(X, X); }
        public readonly Vector2U3F29 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U3F29(X, Y); }
        public readonly Vector2U3F29 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U3F29(Y, X); }
        public readonly Vector2U3F29 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U3F29(Y, Y); }
        public readonly Vector3U3F29 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U3F29(X, X, X); }
        public readonly Vector3U3F29 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U3F29(X, X, Y); }
        public readonly Vector3U3F29 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U3F29(X, Y, X); }
        public readonly Vector3U3F29 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U3F29(X, Y, Y); }
        public readonly Vector3U3F29 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U3F29(Y, X, X); }
        public readonly Vector3U3F29 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U3F29(Y, X, Y); }
        public readonly Vector3U3F29 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U3F29(Y, Y, X); }
        public readonly Vector3U3F29 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U3F29(Y, Y, Y); }
        public readonly Vector4U3F29 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(X, X, X, X); }
        public readonly Vector4U3F29 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(X, X, X, Y); }
        public readonly Vector4U3F29 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(X, X, Y, X); }
        public readonly Vector4U3F29 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(X, X, Y, Y); }
        public readonly Vector4U3F29 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(X, Y, X, X); }
        public readonly Vector4U3F29 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(X, Y, X, Y); }
        public readonly Vector4U3F29 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(X, Y, Y, X); }
        public readonly Vector4U3F29 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(X, Y, Y, Y); }
        public readonly Vector4U3F29 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(Y, X, X, X); }
        public readonly Vector4U3F29 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(Y, X, X, Y); }
        public readonly Vector4U3F29 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(Y, X, Y, X); }
        public readonly Vector4U3F29 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(Y, X, Y, Y); }
        public readonly Vector4U3F29 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(Y, Y, X, X); }
        public readonly Vector4U3F29 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(Y, Y, X, Y); }
        public readonly Vector4U3F29 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(Y, Y, Y, X); }
        public readonly Vector4U3F29 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U3F29(Y, Y, Y, Y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2U3F29 lhs, Vector2U3F29 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2U3F29 lhs, Vector2U3F29 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2U3F29 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2U3F29({X}, {Y})";

        // IEquatable<Vector2U3F29>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2U3F29 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2U3F29({x}, {y})";
        }
    }
}
