using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector2U7F25 : IEquatable<Vector2U7F25>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public U7F25 X;
        public U7F25 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U7F25(U7F25 x, U7F25 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U7F25(U7F25 value) : this(value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U7F25(Vector2U7F25 xy) : this(xy.X, xy.Y) { }

        // Constants
        // ---------------------------------------

        public static Vector2U7F25 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U7F25(U7F25.Zero);
        }
        public static Vector2U7F25 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U7F25(U7F25.One);
        }
        public static Vector2U7F25 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U7F25(U7F25.One, U7F25.Zero);
        }
        public static Vector2U7F25 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U7F25(U7F25.Zero, U7F25.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U7F25 operator +(Vector2U7F25 a, Vector2U7F25 b) => new Vector2U7F25(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U7F25 operator -(Vector2U7F25 a, Vector2U7F25 b) => new Vector2U7F25(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U7F25 operator *(Vector2U7F25 a, Vector2U7F25 b) => new Vector2U7F25(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U7F25 operator *(Vector2U7F25 a, U7F25 b) => new Vector2U7F25(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U7F25 operator *(U7F25 a, Vector2U7F25 b) => new Vector2U7F25(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U7F25 operator /(Vector2U7F25 a, Vector2U7F25 b) => new Vector2U7F25(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U7F25 operator /(Vector2U7F25 a, U7F25 b) => new Vector2U7F25(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U7F25 operator /(U7F25 a, Vector2U7F25 b) => new Vector2U7F25(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2U7F25 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U7F25(X, X); }
        public readonly Vector2U7F25 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U7F25(X, Y); }
        public readonly Vector2U7F25 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U7F25(Y, X); }
        public readonly Vector2U7F25 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U7F25(Y, Y); }
        public readonly Vector3U7F25 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U7F25(X, X, X); }
        public readonly Vector3U7F25 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U7F25(X, X, Y); }
        public readonly Vector3U7F25 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U7F25(X, Y, X); }
        public readonly Vector3U7F25 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U7F25(X, Y, Y); }
        public readonly Vector3U7F25 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U7F25(Y, X, X); }
        public readonly Vector3U7F25 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U7F25(Y, X, Y); }
        public readonly Vector3U7F25 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U7F25(Y, Y, X); }
        public readonly Vector3U7F25 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U7F25(Y, Y, Y); }
        public readonly Vector4U7F25 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(X, X, X, X); }
        public readonly Vector4U7F25 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(X, X, X, Y); }
        public readonly Vector4U7F25 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(X, X, Y, X); }
        public readonly Vector4U7F25 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(X, X, Y, Y); }
        public readonly Vector4U7F25 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(X, Y, X, X); }
        public readonly Vector4U7F25 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(X, Y, X, Y); }
        public readonly Vector4U7F25 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(X, Y, Y, X); }
        public readonly Vector4U7F25 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(X, Y, Y, Y); }
        public readonly Vector4U7F25 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(Y, X, X, X); }
        public readonly Vector4U7F25 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(Y, X, X, Y); }
        public readonly Vector4U7F25 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(Y, X, Y, X); }
        public readonly Vector4U7F25 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(Y, X, Y, Y); }
        public readonly Vector4U7F25 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(Y, Y, X, X); }
        public readonly Vector4U7F25 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(Y, Y, X, Y); }
        public readonly Vector4U7F25 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(Y, Y, Y, X); }
        public readonly Vector4U7F25 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U7F25(Y, Y, Y, Y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2U7F25 lhs, Vector2U7F25 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2U7F25 lhs, Vector2U7F25 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2U7F25 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2U7F25({X}, {Y})";

        // IEquatable<Vector2U7F25>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2U7F25 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2U7F25({x}, {y})";
        }
    }
}
