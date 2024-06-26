using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector2I29F3 : IEquatable<Vector2I29F3>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public I29F3 X;
        public I29F3 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I29F3(I29F3 x, I29F3 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I29F3(I29F3 value) : this(value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I29F3(Vector2I29F3 xy) : this(xy.X, xy.Y) { }

        // Constants
        // ---------------------------------------

        public static Vector2I29F3 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I29F3(I29F3.Zero);
        }
        public static Vector2I29F3 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I29F3(I29F3.One);
        }
        public static Vector2I29F3 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I29F3(I29F3.One, I29F3.Zero);
        }
        public static Vector2I29F3 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I29F3(I29F3.Zero, I29F3.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I29F3 operator +(Vector2I29F3 a, Vector2I29F3 b) => new Vector2I29F3(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I29F3 operator -(Vector2I29F3 a, Vector2I29F3 b) => new Vector2I29F3(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I29F3 operator *(Vector2I29F3 a, Vector2I29F3 b) => new Vector2I29F3(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I29F3 operator *(Vector2I29F3 a, I29F3 b) => new Vector2I29F3(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I29F3 operator *(I29F3 a, Vector2I29F3 b) => new Vector2I29F3(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I29F3 operator /(Vector2I29F3 a, Vector2I29F3 b) => new Vector2I29F3(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I29F3 operator /(Vector2I29F3 a, I29F3 b) => new Vector2I29F3(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I29F3 operator /(I29F3 a, Vector2I29F3 b) => new Vector2I29F3(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2I29F3 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I29F3(X, X); }
        public readonly Vector2I29F3 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I29F3(X, Y); }
        public readonly Vector2I29F3 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I29F3(Y, X); }
        public readonly Vector2I29F3 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I29F3(Y, Y); }
        public readonly Vector3I29F3 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I29F3(X, X, X); }
        public readonly Vector3I29F3 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I29F3(X, X, Y); }
        public readonly Vector3I29F3 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I29F3(X, Y, X); }
        public readonly Vector3I29F3 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I29F3(X, Y, Y); }
        public readonly Vector3I29F3 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I29F3(Y, X, X); }
        public readonly Vector3I29F3 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I29F3(Y, X, Y); }
        public readonly Vector3I29F3 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I29F3(Y, Y, X); }
        public readonly Vector3I29F3 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I29F3(Y, Y, Y); }
        public readonly Vector4I29F3 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(X, X, X, X); }
        public readonly Vector4I29F3 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(X, X, X, Y); }
        public readonly Vector4I29F3 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(X, X, Y, X); }
        public readonly Vector4I29F3 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(X, X, Y, Y); }
        public readonly Vector4I29F3 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(X, Y, X, X); }
        public readonly Vector4I29F3 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(X, Y, X, Y); }
        public readonly Vector4I29F3 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(X, Y, Y, X); }
        public readonly Vector4I29F3 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(X, Y, Y, Y); }
        public readonly Vector4I29F3 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(Y, X, X, X); }
        public readonly Vector4I29F3 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(Y, X, X, Y); }
        public readonly Vector4I29F3 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(Y, X, Y, X); }
        public readonly Vector4I29F3 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(Y, X, Y, Y); }
        public readonly Vector4I29F3 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(Y, Y, X, X); }
        public readonly Vector4I29F3 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(Y, Y, X, Y); }
        public readonly Vector4I29F3 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(Y, Y, Y, X); }
        public readonly Vector4I29F3 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I29F3(Y, Y, Y, Y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2I29F3 lhs, Vector2I29F3 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2I29F3 lhs, Vector2I29F3 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2I29F3 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2I29F3({X}, {Y})";

        // IEquatable<Vector2I29F3>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2I29F3 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2I29F3({x}, {y})";
        }
    }
}
