using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector2I21F11 : IEquatable<Vector2I21F11>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public I21F11 X;
        public I21F11 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I21F11(I21F11 x, I21F11 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I21F11(I21F11 value) : this(value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I21F11(Vector2I21F11 xy) : this(xy.X, xy.Y) { }

        // Constants
        // ---------------------------------------

        public static Vector2I21F11 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I21F11(I21F11.Zero);
        }
        public static Vector2I21F11 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I21F11(I21F11.One);
        }
        public static Vector2I21F11 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I21F11(I21F11.One, I21F11.Zero);
        }
        public static Vector2I21F11 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector2I21F11(I21F11.Zero, I21F11.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I21F11 operator +(Vector2I21F11 a, Vector2I21F11 b) => new Vector2I21F11(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I21F11 operator -(Vector2I21F11 a, Vector2I21F11 b) => new Vector2I21F11(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I21F11 operator *(Vector2I21F11 a, Vector2I21F11 b) => new Vector2I21F11(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I21F11 operator *(Vector2I21F11 a, I21F11 b) => new Vector2I21F11(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I21F11 operator *(I21F11 a, Vector2I21F11 b) => new Vector2I21F11(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I21F11 operator /(Vector2I21F11 a, Vector2I21F11 b) => new Vector2I21F11(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I21F11 operator /(Vector2I21F11 a, I21F11 b) => new Vector2I21F11(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I21F11 operator /(I21F11 a, Vector2I21F11 b) => new Vector2I21F11(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2I21F11 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I21F11(X, X); }
        public readonly Vector2I21F11 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I21F11(X, Y); }
        public readonly Vector2I21F11 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I21F11(Y, X); }
        public readonly Vector2I21F11 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I21F11(Y, Y); }
        public readonly Vector3I21F11 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I21F11(X, X, X); }
        public readonly Vector3I21F11 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I21F11(X, X, Y); }
        public readonly Vector3I21F11 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I21F11(X, Y, X); }
        public readonly Vector3I21F11 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I21F11(X, Y, Y); }
        public readonly Vector3I21F11 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I21F11(Y, X, X); }
        public readonly Vector3I21F11 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I21F11(Y, X, Y); }
        public readonly Vector3I21F11 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I21F11(Y, Y, X); }
        public readonly Vector3I21F11 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I21F11(Y, Y, Y); }
        public readonly Vector4I21F11 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(X, X, X, X); }
        public readonly Vector4I21F11 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(X, X, X, Y); }
        public readonly Vector4I21F11 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(X, X, Y, X); }
        public readonly Vector4I21F11 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(X, X, Y, Y); }
        public readonly Vector4I21F11 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(X, Y, X, X); }
        public readonly Vector4I21F11 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(X, Y, X, Y); }
        public readonly Vector4I21F11 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(X, Y, Y, X); }
        public readonly Vector4I21F11 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(X, Y, Y, Y); }
        public readonly Vector4I21F11 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(Y, X, X, X); }
        public readonly Vector4I21F11 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(Y, X, X, Y); }
        public readonly Vector4I21F11 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(Y, X, Y, X); }
        public readonly Vector4I21F11 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(Y, X, Y, Y); }
        public readonly Vector4I21F11 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(Y, Y, X, X); }
        public readonly Vector4I21F11 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(Y, Y, X, Y); }
        public readonly Vector4I21F11 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(Y, Y, Y, X); }
        public readonly Vector4I21F11 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I21F11(Y, Y, Y, Y); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2I21F11 lhs, Vector2I21F11 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2I21F11 lhs, Vector2I21F11 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2I21F11 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2I21F11({X}, {Y})";

        // IEquatable<Vector2I21F11>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2I21F11 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2I21F11({x}, {y})";
        }
    }
}
