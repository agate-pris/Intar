using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector2I22F10 : IEquatable<Vector2I22F10>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public I22F10 X;
        public I22F10 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I22F10(I22F10 x, I22F10 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I22F10(I22F10 value) : this(value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I22F10(Vector2I22F10 xy) : this(xy.X, xy.Y) { }

        // Constants
        // ---------------------------------------

        public static Vector2I22F10 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I22F10(I22F10.Zero);
        }
        public static Vector2I22F10 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I22F10(I22F10.One);
        }
        public static Vector2I22F10 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I22F10(I22F10.One, I22F10.Zero);
        }
        public static Vector2I22F10 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I22F10(I22F10.Zero, I22F10.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I22F10 operator +(Vector2I22F10 a, Vector2I22F10 b) => new Vector2I22F10(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I22F10 operator -(Vector2I22F10 a, Vector2I22F10 b) => new Vector2I22F10(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I22F10 operator *(Vector2I22F10 a, Vector2I22F10 b) => new Vector2I22F10(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I22F10 operator *(Vector2I22F10 a, I22F10 b) => new Vector2I22F10(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I22F10 operator *(I22F10 a, Vector2I22F10 b) => new Vector2I22F10(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I22F10 operator /(Vector2I22F10 a, Vector2I22F10 b) => new Vector2I22F10(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I22F10 operator /(Vector2I22F10 a, I22F10 b) => new Vector2I22F10(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I22F10 operator /(I22F10 a, Vector2I22F10 b) => new Vector2I22F10(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2I22F10 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I22F10(X, X); }
        public readonly Vector2I22F10 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I22F10(X, Y); }
        public readonly Vector2I22F10 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I22F10(Y, X); }
        public readonly Vector2I22F10 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I22F10(Y, Y); }
        public readonly Vector3I22F10 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I22F10(X, X, X); }
        public readonly Vector3I22F10 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I22F10(X, X, Y); }
        public readonly Vector3I22F10 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I22F10(X, Y, X); }
        public readonly Vector3I22F10 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I22F10(X, Y, Y); }
        public readonly Vector3I22F10 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I22F10(Y, X, X); }
        public readonly Vector3I22F10 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I22F10(Y, X, Y); }
        public readonly Vector3I22F10 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I22F10(Y, Y, X); }
        public readonly Vector3I22F10 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I22F10(Y, Y, Y); }
        public readonly Vector4I22F10 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(X, X, X, X); }
        public readonly Vector4I22F10 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(X, X, X, Y); }
        public readonly Vector4I22F10 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(X, X, Y, X); }
        public readonly Vector4I22F10 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(X, X, Y, Y); }
        public readonly Vector4I22F10 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(X, Y, X, X); }
        public readonly Vector4I22F10 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(X, Y, X, Y); }
        public readonly Vector4I22F10 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(X, Y, Y, X); }
        public readonly Vector4I22F10 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(X, Y, Y, Y); }
        public readonly Vector4I22F10 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(Y, X, X, X); }
        public readonly Vector4I22F10 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(Y, X, X, Y); }
        public readonly Vector4I22F10 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(Y, X, Y, X); }
        public readonly Vector4I22F10 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(Y, X, Y, Y); }
        public readonly Vector4I22F10 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(Y, Y, X, X); }
        public readonly Vector4I22F10 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(Y, Y, X, Y); }
        public readonly Vector4I22F10 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(Y, Y, Y, X); }
        public readonly Vector4I22F10 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I22F10(Y, Y, Y, Y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2I22F10 lhs, Vector2I22F10 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2I22F10 lhs, Vector2I22F10 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2I22F10 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2I22F10({X}, {Y})";

        // IEquatable<Vector2I22F10>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2I22F10 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2I22F10({x}, {y})";
        }
    }
}
