using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector2I30F2 : IEquatable<Vector2I30F2>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public I30F2 X;
        public I30F2 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I30F2(I30F2 x, I30F2 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I30F2(I30F2 value) : this(value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I30F2(Vector2I30F2 xy) : this(xy.X, xy.Y) { }

        // Constants
        // ---------------------------------------

        public static Vector2I30F2 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I30F2(I30F2.Zero);
        }
        public static Vector2I30F2 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I30F2(I30F2.One);
        }
        public static Vector2I30F2 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I30F2(I30F2.One, I30F2.Zero);
        }
        public static Vector2I30F2 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I30F2(I30F2.Zero, I30F2.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I30F2 operator +(Vector2I30F2 a, Vector2I30F2 b) => new Vector2I30F2(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I30F2 operator -(Vector2I30F2 a, Vector2I30F2 b) => new Vector2I30F2(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I30F2 operator *(Vector2I30F2 a, Vector2I30F2 b) => new Vector2I30F2(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I30F2 operator *(Vector2I30F2 a, I30F2 b) => new Vector2I30F2(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I30F2 operator *(I30F2 a, Vector2I30F2 b) => new Vector2I30F2(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I30F2 operator /(Vector2I30F2 a, Vector2I30F2 b) => new Vector2I30F2(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I30F2 operator /(Vector2I30F2 a, I30F2 b) => new Vector2I30F2(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I30F2 operator /(I30F2 a, Vector2I30F2 b) => new Vector2I30F2(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2I30F2 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I30F2(X, X); }
        public readonly Vector2I30F2 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I30F2(X, Y); }
        public readonly Vector2I30F2 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I30F2(Y, X); }
        public readonly Vector2I30F2 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I30F2(Y, Y); }
        public readonly Vector3I30F2 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I30F2(X, X, X); }
        public readonly Vector3I30F2 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I30F2(X, X, Y); }
        public readonly Vector3I30F2 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I30F2(X, Y, X); }
        public readonly Vector3I30F2 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I30F2(X, Y, Y); }
        public readonly Vector3I30F2 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I30F2(Y, X, X); }
        public readonly Vector3I30F2 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I30F2(Y, X, Y); }
        public readonly Vector3I30F2 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I30F2(Y, Y, X); }
        public readonly Vector3I30F2 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I30F2(Y, Y, Y); }
        public readonly Vector4I30F2 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(X, X, X, X); }
        public readonly Vector4I30F2 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(X, X, X, Y); }
        public readonly Vector4I30F2 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(X, X, Y, X); }
        public readonly Vector4I30F2 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(X, X, Y, Y); }
        public readonly Vector4I30F2 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(X, Y, X, X); }
        public readonly Vector4I30F2 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(X, Y, X, Y); }
        public readonly Vector4I30F2 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(X, Y, Y, X); }
        public readonly Vector4I30F2 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(X, Y, Y, Y); }
        public readonly Vector4I30F2 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(Y, X, X, X); }
        public readonly Vector4I30F2 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(Y, X, X, Y); }
        public readonly Vector4I30F2 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(Y, X, Y, X); }
        public readonly Vector4I30F2 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(Y, X, Y, Y); }
        public readonly Vector4I30F2 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(Y, Y, X, X); }
        public readonly Vector4I30F2 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(Y, Y, X, Y); }
        public readonly Vector4I30F2 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(Y, Y, Y, X); }
        public readonly Vector4I30F2 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I30F2(Y, Y, Y, Y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2I30F2 lhs, Vector2I30F2 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2I30F2 lhs, Vector2I30F2 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2I30F2 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2I30F2({X}, {Y})";

        // IEquatable<Vector2I30F2>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2I30F2 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2I30F2({x}, {y})";
        }
    }
}
