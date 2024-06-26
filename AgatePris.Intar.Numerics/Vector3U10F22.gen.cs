using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector3U10F22 : IEquatable<Vector3U10F22>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public U10F22 X;
        public U10F22 Y;
        public U10F22 Z;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3U10F22(U10F22 x, U10F22 y, U10F22 z) {
            X = x;
            Y = y;
            Z = z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3U10F22(U10F22 value) : this(value, value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3U10F22(U10F22 x, Vector2U10F22 yz) : this(x, yz.X, yz.Y) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3U10F22(Vector3U10F22 xyz) : this(xyz.X, xyz.Y, xyz.Z) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3U10F22(Vector2U10F22 xy, U10F22 z) : this(xy.X, xy.Y, z) { }

        // Constants
        // ---------------------------------------

        public static Vector3U10F22 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3U10F22(U10F22.Zero);
        }
        public static Vector3U10F22 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3U10F22(U10F22.One);
        }
        public static Vector3U10F22 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3U10F22(U10F22.One, U10F22.Zero, U10F22.Zero);
        }
        public static Vector3U10F22 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3U10F22(U10F22.Zero, U10F22.One, U10F22.Zero);
        }
        public static Vector3U10F22 UnitZ {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3U10F22(U10F22.Zero, U10F22.Zero, U10F22.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3U10F22 operator +(Vector3U10F22 a, Vector3U10F22 b) => new Vector3U10F22(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3U10F22 operator -(Vector3U10F22 a, Vector3U10F22 b) => new Vector3U10F22(
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3U10F22 operator *(Vector3U10F22 a, Vector3U10F22 b) => new Vector3U10F22(
            a.X * b.X,
            a.Y * b.Y,
            a.Z * b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3U10F22 operator *(Vector3U10F22 a, U10F22 b) => new Vector3U10F22(
            a.X * b,
            a.Y * b,
            a.Z * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3U10F22 operator *(U10F22 a, Vector3U10F22 b) => new Vector3U10F22(
            a * b.X,
            a * b.Y,
            a * b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3U10F22 operator /(Vector3U10F22 a, Vector3U10F22 b) => new Vector3U10F22(
            a.X / b.X,
            a.Y / b.Y,
            a.Z / b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3U10F22 operator /(Vector3U10F22 a, U10F22 b) => new Vector3U10F22(
            a.X / b,
            a.Y / b,
            a.Z / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3U10F22 operator /(U10F22 a, Vector3U10F22 b) => new Vector3U10F22(
            a / b.X,
            a / b.Y,
            a / b.Z);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2U10F22 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(X, X); }
        public readonly Vector2U10F22 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(X, Y); }
        public readonly Vector2U10F22 XZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(X, Z); }
        public readonly Vector2U10F22 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(Y, X); }
        public readonly Vector2U10F22 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(Y, Y); }
        public readonly Vector2U10F22 YZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(Y, Z); }
        public readonly Vector2U10F22 ZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(Z, X); }
        public readonly Vector2U10F22 ZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(Z, Y); }
        public readonly Vector2U10F22 ZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U10F22(Z, Z); }
        public readonly Vector3U10F22 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, X, X); }
        public readonly Vector3U10F22 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, X, Y); }
        public readonly Vector3U10F22 XXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, X, Z); }
        public readonly Vector3U10F22 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, Y, X); }
        public readonly Vector3U10F22 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, Y, Y); }
        public readonly Vector3U10F22 XYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, Y, Z); }
        public readonly Vector3U10F22 XZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, Z, X); }
        public readonly Vector3U10F22 XZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, Z, Y); }
        public readonly Vector3U10F22 XZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(X, Z, Z); }
        public readonly Vector3U10F22 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, X, X); }
        public readonly Vector3U10F22 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, X, Y); }
        public readonly Vector3U10F22 YXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, X, Z); }
        public readonly Vector3U10F22 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, Y, X); }
        public readonly Vector3U10F22 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, Y, Y); }
        public readonly Vector3U10F22 YYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, Y, Z); }
        public readonly Vector3U10F22 YZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, Z, X); }
        public readonly Vector3U10F22 YZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, Z, Y); }
        public readonly Vector3U10F22 YZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Y, Z, Z); }
        public readonly Vector3U10F22 ZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, X, X); }
        public readonly Vector3U10F22 ZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, X, Y); }
        public readonly Vector3U10F22 ZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, X, Z); }
        public readonly Vector3U10F22 ZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, Y, X); }
        public readonly Vector3U10F22 ZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, Y, Y); }
        public readonly Vector3U10F22 ZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, Y, Z); }
        public readonly Vector3U10F22 ZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, Z, X); }
        public readonly Vector3U10F22 ZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, Z, Y); }
        public readonly Vector3U10F22 ZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U10F22(Z, Z, Z); }
        public readonly Vector4U10F22 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, X, X); }
        public readonly Vector4U10F22 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, X, Y); }
        public readonly Vector4U10F22 XXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, X, Z); }
        public readonly Vector4U10F22 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, Y, X); }
        public readonly Vector4U10F22 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, Y, Y); }
        public readonly Vector4U10F22 XXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, Y, Z); }
        public readonly Vector4U10F22 XXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, Z, X); }
        public readonly Vector4U10F22 XXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, Z, Y); }
        public readonly Vector4U10F22 XXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, X, Z, Z); }
        public readonly Vector4U10F22 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, X, X); }
        public readonly Vector4U10F22 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, X, Y); }
        public readonly Vector4U10F22 XYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, X, Z); }
        public readonly Vector4U10F22 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, Y, X); }
        public readonly Vector4U10F22 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, Y, Y); }
        public readonly Vector4U10F22 XYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, Y, Z); }
        public readonly Vector4U10F22 XYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, Z, X); }
        public readonly Vector4U10F22 XYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, Z, Y); }
        public readonly Vector4U10F22 XYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Y, Z, Z); }
        public readonly Vector4U10F22 XZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, X, X); }
        public readonly Vector4U10F22 XZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, X, Y); }
        public readonly Vector4U10F22 XZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, X, Z); }
        public readonly Vector4U10F22 XZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, Y, X); }
        public readonly Vector4U10F22 XZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, Y, Y); }
        public readonly Vector4U10F22 XZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, Y, Z); }
        public readonly Vector4U10F22 XZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, Z, X); }
        public readonly Vector4U10F22 XZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, Z, Y); }
        public readonly Vector4U10F22 XZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(X, Z, Z, Z); }
        public readonly Vector4U10F22 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, X, X); }
        public readonly Vector4U10F22 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, X, Y); }
        public readonly Vector4U10F22 YXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, X, Z); }
        public readonly Vector4U10F22 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, Y, X); }
        public readonly Vector4U10F22 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, Y, Y); }
        public readonly Vector4U10F22 YXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, Y, Z); }
        public readonly Vector4U10F22 YXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, Z, X); }
        public readonly Vector4U10F22 YXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, Z, Y); }
        public readonly Vector4U10F22 YXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, X, Z, Z); }
        public readonly Vector4U10F22 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, X, X); }
        public readonly Vector4U10F22 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, X, Y); }
        public readonly Vector4U10F22 YYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, X, Z); }
        public readonly Vector4U10F22 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, Y, X); }
        public readonly Vector4U10F22 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, Y, Y); }
        public readonly Vector4U10F22 YYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, Y, Z); }
        public readonly Vector4U10F22 YYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, Z, X); }
        public readonly Vector4U10F22 YYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, Z, Y); }
        public readonly Vector4U10F22 YYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Y, Z, Z); }
        public readonly Vector4U10F22 YZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, X, X); }
        public readonly Vector4U10F22 YZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, X, Y); }
        public readonly Vector4U10F22 YZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, X, Z); }
        public readonly Vector4U10F22 YZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, Y, X); }
        public readonly Vector4U10F22 YZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, Y, Y); }
        public readonly Vector4U10F22 YZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, Y, Z); }
        public readonly Vector4U10F22 YZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, Z, X); }
        public readonly Vector4U10F22 YZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, Z, Y); }
        public readonly Vector4U10F22 YZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Y, Z, Z, Z); }
        public readonly Vector4U10F22 ZXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, X, X); }
        public readonly Vector4U10F22 ZXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, X, Y); }
        public readonly Vector4U10F22 ZXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, X, Z); }
        public readonly Vector4U10F22 ZXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, Y, X); }
        public readonly Vector4U10F22 ZXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, Y, Y); }
        public readonly Vector4U10F22 ZXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, Y, Z); }
        public readonly Vector4U10F22 ZXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, Z, X); }
        public readonly Vector4U10F22 ZXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, Z, Y); }
        public readonly Vector4U10F22 ZXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, X, Z, Z); }
        public readonly Vector4U10F22 ZYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, X, X); }
        public readonly Vector4U10F22 ZYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, X, Y); }
        public readonly Vector4U10F22 ZYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, X, Z); }
        public readonly Vector4U10F22 ZYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, Y, X); }
        public readonly Vector4U10F22 ZYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, Y, Y); }
        public readonly Vector4U10F22 ZYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, Y, Z); }
        public readonly Vector4U10F22 ZYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, Z, X); }
        public readonly Vector4U10F22 ZYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, Z, Y); }
        public readonly Vector4U10F22 ZYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Y, Z, Z); }
        public readonly Vector4U10F22 ZZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, X, X); }
        public readonly Vector4U10F22 ZZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, X, Y); }
        public readonly Vector4U10F22 ZZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, X, Z); }
        public readonly Vector4U10F22 ZZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, Y, X); }
        public readonly Vector4U10F22 ZZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, Y, Y); }
        public readonly Vector4U10F22 ZZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, Y, Z); }
        public readonly Vector4U10F22 ZZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, Z, X); }
        public readonly Vector4U10F22 ZZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, Z, Y); }
        public readonly Vector4U10F22 ZZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U10F22(Z, Z, Z, Z); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector3U10F22 lhs, Vector3U10F22 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector3U10F22 lhs, Vector3U10F22 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector3U10F22 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y, Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector3U10F22({X}, {Y}, {Z})";

        // IEquatable<Vector3U10F22>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector3U10F22 other)
            => other.X == X
            && other.Y == Y
            && other.Z == Z;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            var z = Z.ToString(format, formatProvider);
            return $"Vector3U10F22({x}, {y}, {z})";
        }
    }
}
