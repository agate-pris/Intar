using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector2U18F14 : IEquatable<Vector2U18F14>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public U18F14 X;
        public U18F14 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U18F14(U18F14 x, U18F14 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U18F14(U18F14 value) : this(value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2U18F14(Vector2U18F14 xy) : this(xy.X, xy.Y) { }

        // Constants
        // ---------------------------------------

        public static Vector2U18F14 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U18F14(U18F14.Zero);
        }
        public static Vector2U18F14 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U18F14(U18F14.One);
        }
        public static Vector2U18F14 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U18F14(U18F14.One, U18F14.Zero);
        }
        public static Vector2U18F14 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2U18F14(U18F14.Zero, U18F14.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U18F14 operator +(Vector2U18F14 a, Vector2U18F14 b) => new Vector2U18F14(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U18F14 operator -(Vector2U18F14 a, Vector2U18F14 b) => new Vector2U18F14(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U18F14 operator *(Vector2U18F14 a, Vector2U18F14 b) => new Vector2U18F14(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U18F14 operator *(Vector2U18F14 a, U18F14 b) => new Vector2U18F14(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U18F14 operator *(U18F14 a, Vector2U18F14 b) => new Vector2U18F14(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U18F14 operator /(Vector2U18F14 a, Vector2U18F14 b) => new Vector2U18F14(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U18F14 operator /(Vector2U18F14 a, U18F14 b) => new Vector2U18F14(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2U18F14 operator /(U18F14 a, Vector2U18F14 b) => new Vector2U18F14(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2U18F14 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U18F14(X, X); }
        public readonly Vector2U18F14 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U18F14(X, Y); }
        public readonly Vector2U18F14 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U18F14(Y, X); }
        public readonly Vector2U18F14 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U18F14(Y, Y); }
        public readonly Vector3U18F14 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U18F14(X, X, X); }
        public readonly Vector3U18F14 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U18F14(X, X, Y); }
        public readonly Vector3U18F14 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U18F14(X, Y, X); }
        public readonly Vector3U18F14 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U18F14(X, Y, Y); }
        public readonly Vector3U18F14 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U18F14(Y, X, X); }
        public readonly Vector3U18F14 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U18F14(Y, X, Y); }
        public readonly Vector3U18F14 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U18F14(Y, Y, X); }
        public readonly Vector3U18F14 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U18F14(Y, Y, Y); }
        public readonly Vector4U18F14 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(X, X, X, X); }
        public readonly Vector4U18F14 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(X, X, X, Y); }
        public readonly Vector4U18F14 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(X, X, Y, X); }
        public readonly Vector4U18F14 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(X, X, Y, Y); }
        public readonly Vector4U18F14 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(X, Y, X, X); }
        public readonly Vector4U18F14 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(X, Y, X, Y); }
        public readonly Vector4U18F14 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(X, Y, Y, X); }
        public readonly Vector4U18F14 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(X, Y, Y, Y); }
        public readonly Vector4U18F14 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(Y, X, X, X); }
        public readonly Vector4U18F14 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(Y, X, X, Y); }
        public readonly Vector4U18F14 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(Y, X, Y, X); }
        public readonly Vector4U18F14 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(Y, X, Y, Y); }
        public readonly Vector4U18F14 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(Y, Y, X, X); }
        public readonly Vector4U18F14 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(Y, Y, X, Y); }
        public readonly Vector4U18F14 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(Y, Y, Y, X); }
        public readonly Vector4U18F14 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U18F14(Y, Y, Y, Y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2U18F14 lhs, Vector2U18F14 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2U18F14 lhs, Vector2U18F14 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2U18F14 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2U18F14({X}, {Y})";

        // IEquatable<Vector2U18F14>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2U18F14 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2U18F14({x}, {y})";
        }
    }
}
