using AgatePris.Intar.Numerics;
using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Mathematics {
    [Serializable]
    public struct Vector2I13F19 : IEquatable<Vector2I13F19>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public I13F19 X;
        public I13F19 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constants
        // ---------------------------------------

        public static readonly Vector2I13F19 zero;

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I13F19(I13F19 x, I13F19 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I13F19(Vector2I13F19 xy) {
            X = xy.X;
            Y = xy.Y;
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I13F19 operator +(Vector2I13F19 a, Vector2I13F19 b) => new Vector2I13F19(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I13F19 operator -(Vector2I13F19 a, Vector2I13F19 b) => new Vector2I13F19(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I13F19 operator *(Vector2I13F19 a, Vector2I13F19 b) => new Vector2I13F19(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I13F19 operator *(Vector2I13F19 a, I13F19 b) => new Vector2I13F19(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I13F19 operator *(I13F19 a, Vector2I13F19 b) => new Vector2I13F19(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I13F19 operator /(Vector2I13F19 a, Vector2I13F19 b) => new Vector2I13F19(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I13F19 operator /(Vector2I13F19 a, I13F19 b) => new Vector2I13F19(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I13F19 operator /(I13F19 a, Vector2I13F19 b) => new Vector2I13F19(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

#pragma warning disable IDE1006 // 命名スタイル

        public readonly Vector2I13F19 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I13F19(X, X); }
        public readonly Vector2I13F19 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I13F19(X, Y); }
        public readonly Vector2I13F19 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I13F19(Y, X); }
        public readonly Vector2I13F19 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I13F19(Y, Y); }
        public readonly Vector3I13F19 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I13F19(X, X, X); }
        public readonly Vector3I13F19 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I13F19(X, X, Y); }
        public readonly Vector3I13F19 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I13F19(X, Y, X); }
        public readonly Vector3I13F19 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I13F19(X, Y, Y); }
        public readonly Vector3I13F19 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I13F19(Y, X, X); }
        public readonly Vector3I13F19 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I13F19(Y, X, Y); }
        public readonly Vector3I13F19 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I13F19(Y, Y, X); }
        public readonly Vector3I13F19 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I13F19(Y, Y, Y); }
        public readonly Vector4I13F19 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(X, X, X, X); }
        public readonly Vector4I13F19 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(X, X, X, Y); }
        public readonly Vector4I13F19 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(X, X, Y, X); }
        public readonly Vector4I13F19 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(X, X, Y, Y); }
        public readonly Vector4I13F19 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(X, Y, X, X); }
        public readonly Vector4I13F19 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(X, Y, X, Y); }
        public readonly Vector4I13F19 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(X, Y, Y, X); }
        public readonly Vector4I13F19 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(X, Y, Y, Y); }
        public readonly Vector4I13F19 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(Y, X, X, X); }
        public readonly Vector4I13F19 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(Y, X, X, Y); }
        public readonly Vector4I13F19 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(Y, X, Y, X); }
        public readonly Vector4I13F19 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(Y, X, Y, Y); }
        public readonly Vector4I13F19 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(Y, Y, X, X); }
        public readonly Vector4I13F19 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(Y, Y, X, Y); }
        public readonly Vector4I13F19 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(Y, Y, Y, X); }
        public readonly Vector4I13F19 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I13F19(Y, Y, Y, Y); }

#pragma warning restore IDE1006 // 命名スタイル

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2I13F19 lhs, Vector2I13F19 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2I13F19 lhs, Vector2I13F19 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2I13F19 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2I13F19({X}, {Y})";

        // IEquatable<Vector2I13F19>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2I13F19 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2I13F19({x}, {y})";
        }
    }
}
