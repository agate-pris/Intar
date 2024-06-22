using AgatePris.Intar.Numerics;
using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Mathematics {
    [Serializable]
    public struct Vector2I23F9 : IEquatable<Vector2I23F9>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public I23F9 X;
        public I23F9 Y;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constants
        // ---------------------------------------

        public static readonly Vector2I23F9 zero;

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I23F9(I23F9 x, I23F9 y) {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I23F9(Vector2I23F9 xy) {
            X = xy.X;
            Y = xy.Y;
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I23F9 operator +(Vector2I23F9 a, Vector2I23F9 b) => new Vector2I23F9(
            a.X + b.X,
            a.Y + b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I23F9 operator -(Vector2I23F9 a, Vector2I23F9 b) => new Vector2I23F9(
            a.X - b.X,
            a.Y - b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I23F9 operator *(Vector2I23F9 a, Vector2I23F9 b) => new Vector2I23F9(
            a.X * b.X,
            a.Y * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I23F9 operator *(Vector2I23F9 a, I23F9 b) => new Vector2I23F9(
            a.X * b,
            a.Y * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I23F9 operator *(I23F9 a, Vector2I23F9 b) => new Vector2I23F9(
            a * b.X,
            a * b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I23F9 operator /(Vector2I23F9 a, Vector2I23F9 b) => new Vector2I23F9(
            a.X / b.X,
            a.Y / b.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I23F9 operator /(Vector2I23F9 a, I23F9 b) => new Vector2I23F9(
            a.X / b,
            a.Y / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I23F9 operator /(I23F9 a, Vector2I23F9 b) => new Vector2I23F9(
            a / b.X,
            a / b.Y);

        // Swizzling Properties
        // ---------------------------------------

#pragma warning disable IDE1006 // 命名スタイル

        public readonly Vector2I23F9 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I23F9(X, X); }
        public readonly Vector2I23F9 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I23F9(X, Y); }
        public readonly Vector2I23F9 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I23F9(Y, X); }
        public readonly Vector2I23F9 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I23F9(Y, Y); }
        public readonly Vector3I23F9 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I23F9(X, X, X); }
        public readonly Vector3I23F9 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I23F9(X, X, Y); }
        public readonly Vector3I23F9 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I23F9(X, Y, X); }
        public readonly Vector3I23F9 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I23F9(X, Y, Y); }
        public readonly Vector3I23F9 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I23F9(Y, X, X); }
        public readonly Vector3I23F9 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I23F9(Y, X, Y); }
        public readonly Vector3I23F9 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I23F9(Y, Y, X); }
        public readonly Vector3I23F9 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I23F9(Y, Y, Y); }
        public readonly Vector4I23F9 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(X, X, X, X); }
        public readonly Vector4I23F9 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(X, X, X, Y); }
        public readonly Vector4I23F9 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(X, X, Y, X); }
        public readonly Vector4I23F9 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(X, X, Y, Y); }
        public readonly Vector4I23F9 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(X, Y, X, X); }
        public readonly Vector4I23F9 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(X, Y, X, Y); }
        public readonly Vector4I23F9 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(X, Y, Y, X); }
        public readonly Vector4I23F9 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(X, Y, Y, Y); }
        public readonly Vector4I23F9 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(Y, X, X, X); }
        public readonly Vector4I23F9 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(Y, X, X, Y); }
        public readonly Vector4I23F9 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(Y, X, Y, X); }
        public readonly Vector4I23F9 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(Y, X, Y, Y); }
        public readonly Vector4I23F9 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(Y, Y, X, X); }
        public readonly Vector4I23F9 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(Y, Y, X, Y); }
        public readonly Vector4I23F9 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(Y, Y, Y, X); }
        public readonly Vector4I23F9 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I23F9(Y, Y, Y, Y); }

#pragma warning restore IDE1006 // 命名スタイル

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2I23F9 lhs, Vector2I23F9 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2I23F9 lhs, Vector2I23F9 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector2I23F9 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector2I23F9({X}, {Y})";

        // IEquatable<Vector2I23F9>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector2I23F9 other)
            => other.X == X
            && other.Y == Y;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            return $"Vector2I23F9({x}, {y})";
        }
    }
}
