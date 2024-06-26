using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector2U20F12 : IEquatable<Vector2U20F12>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public U20F12 X;
        public U20F12 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U20F12(U20F12 x, U20F12 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U20F12(U20F12 value) : this(value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U20F12(Vector2U20F12 xy) : this(xy.X, xy.Y) { }

        // Constants
        // ---------------------------------------

        public static Vector2U20F12 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U20F12(U20F12.Zero);
        }
        public static Vector2U20F12 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U20F12(U20F12.One);
        }
        public static Vector2U20F12 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U20F12(U20F12.One, U20F12.Zero);
        }
        public static Vector2U20F12 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U20F12(U20F12.Zero, U20F12.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U20F12 operator +(Vector2U20F12 a, Vector2U20F12 b) => new Vector2U20F12(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U20F12 operator -(Vector2U20F12 a, Vector2U20F12 b) => new Vector2U20F12(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U20F12 operator *(Vector2U20F12 a, Vector2U20F12 b) => new Vector2U20F12(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U20F12 operator *(Vector2U20F12 a, U20F12 b) => new Vector2U20F12(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U20F12 operator *(U20F12 a, Vector2U20F12 b) => new Vector2U20F12(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U20F12 operator /(Vector2U20F12 a, Vector2U20F12 b) => new Vector2U20F12(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U20F12 operator /(Vector2U20F12 a, U20F12 b) => new Vector2U20F12(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U20F12 operator /(U20F12 a, Vector2U20F12 b) => new Vector2U20F12(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2U20F12 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U20F12(X, X); }
        public readonly Vector2U20F12 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U20F12(X, Y); }
        public readonly Vector2U20F12 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U20F12(Y, X); }
        public readonly Vector2U20F12 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U20F12(Y, Y); }
        public readonly Vector3U20F12 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U20F12(X, X, X); }
        public readonly Vector3U20F12 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U20F12(X, X, Y); }
        public readonly Vector3U20F12 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U20F12(X, Y, X); }
        public readonly Vector3U20F12 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U20F12(X, Y, Y); }
        public readonly Vector3U20F12 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U20F12(Y, X, X); }
        public readonly Vector3U20F12 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U20F12(Y, X, Y); }
        public readonly Vector3U20F12 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U20F12(Y, Y, X); }
        public readonly Vector3U20F12 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U20F12(Y, Y, Y); }
        public readonly Vector4U20F12 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(X, X, X, X); }
        public readonly Vector4U20F12 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(X, X, X, Y); }
        public readonly Vector4U20F12 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(X, X, Y, X); }
        public readonly Vector4U20F12 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(X, X, Y, Y); }
        public readonly Vector4U20F12 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(X, Y, X, X); }
        public readonly Vector4U20F12 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(X, Y, X, Y); }
        public readonly Vector4U20F12 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(X, Y, Y, X); }
        public readonly Vector4U20F12 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(X, Y, Y, Y); }
        public readonly Vector4U20F12 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(Y, X, X, X); }
        public readonly Vector4U20F12 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(Y, X, X, Y); }
        public readonly Vector4U20F12 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(Y, X, Y, X); }
        public readonly Vector4U20F12 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(Y, X, Y, Y); }
        public readonly Vector4U20F12 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(Y, Y, X, X); }
        public readonly Vector4U20F12 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(Y, Y, X, Y); }
        public readonly Vector4U20F12 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(Y, Y, Y, X); }
        public readonly Vector4U20F12 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U20F12(Y, Y, Y, Y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2U20F12 lhs, Vector2U20F12 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2U20F12 lhs, Vector2U20F12 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2U20F12 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2U20F12({X}, {Y})";

        // IEquatable<Vector2U20F12>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2U20F12 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2U20F12({x}, {y})";
        }
    }
}
