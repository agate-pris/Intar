using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector3I27F5 : IEquatable<Vector3I27F5>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public I27F5 X;
        public I27F5 Y;
        public I27F5 Z;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3I27F5(I27F5 x, I27F5 y, I27F5 z) {
            X = x;
            Y = y;
            Z = z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3I27F5(I27F5 value) : this(value, value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3I27F5(I27F5 x, Vector2I27F5 yz) : this(x, yz.X, yz.Y) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3I27F5(Vector3I27F5 xyz) : this(xyz.X, xyz.Y, xyz.Z) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3I27F5(Vector2I27F5 xy, I27F5 z) : this(xy.X, xy.Y, z) { }

        // Constants
        // ---------------------------------------

        public static Vector3I27F5 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3I27F5(I27F5.Zero);
        }
        public static Vector3I27F5 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3I27F5(I27F5.One);
        }
        public static Vector3I27F5 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3I27F5(I27F5.One, I27F5.Zero, I27F5.Zero);
        }
        public static Vector3I27F5 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3I27F5(I27F5.Zero, I27F5.One, I27F5.Zero);
        }
        public static Vector3I27F5 UnitZ {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector3I27F5(I27F5.Zero, I27F5.Zero, I27F5.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I27F5 operator +(Vector3I27F5 a, Vector3I27F5 b) => new Vector3I27F5(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I27F5 operator -(Vector3I27F5 a, Vector3I27F5 b) => new Vector3I27F5(
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I27F5 operator *(Vector3I27F5 a, Vector3I27F5 b) => new Vector3I27F5(
            a.X * b.X,
            a.Y * b.Y,
            a.Z * b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I27F5 operator *(Vector3I27F5 a, I27F5 b) => new Vector3I27F5(
            a.X * b,
            a.Y * b,
            a.Z * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I27F5 operator *(I27F5 a, Vector3I27F5 b) => new Vector3I27F5(
            a * b.X,
            a * b.Y,
            a * b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I27F5 operator /(Vector3I27F5 a, Vector3I27F5 b) => new Vector3I27F5(
            a.X / b.X,
            a.Y / b.Y,
            a.Z / b.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I27F5 operator /(Vector3I27F5 a, I27F5 b) => new Vector3I27F5(
            a.X / b,
            a.Y / b,
            a.Z / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3I27F5 operator /(I27F5 a, Vector3I27F5 b) => new Vector3I27F5(
            a / b.X,
            a / b.Y,
            a / b.Z);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2I27F5 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(X, X); }
        public readonly Vector2I27F5 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(X, Y); }
        public readonly Vector2I27F5 XZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(X, Z); }
        public readonly Vector2I27F5 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(Y, X); }
        public readonly Vector2I27F5 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(Y, Y); }
        public readonly Vector2I27F5 YZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(Y, Z); }
        public readonly Vector2I27F5 ZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(Z, X); }
        public readonly Vector2I27F5 ZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(Z, Y); }
        public readonly Vector2I27F5 ZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I27F5(Z, Z); }
        public readonly Vector3I27F5 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, X, X); }
        public readonly Vector3I27F5 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, X, Y); }
        public readonly Vector3I27F5 XXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, X, Z); }
        public readonly Vector3I27F5 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, Y, X); }
        public readonly Vector3I27F5 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, Y, Y); }
        public readonly Vector3I27F5 XYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, Y, Z); }
        public readonly Vector3I27F5 XZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, Z, X); }
        public readonly Vector3I27F5 XZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, Z, Y); }
        public readonly Vector3I27F5 XZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(X, Z, Z); }
        public readonly Vector3I27F5 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, X, X); }
        public readonly Vector3I27F5 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, X, Y); }
        public readonly Vector3I27F5 YXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, X, Z); }
        public readonly Vector3I27F5 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, Y, X); }
        public readonly Vector3I27F5 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, Y, Y); }
        public readonly Vector3I27F5 YYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, Y, Z); }
        public readonly Vector3I27F5 YZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, Z, X); }
        public readonly Vector3I27F5 YZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, Z, Y); }
        public readonly Vector3I27F5 YZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Y, Z, Z); }
        public readonly Vector3I27F5 ZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, X, X); }
        public readonly Vector3I27F5 ZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, X, Y); }
        public readonly Vector3I27F5 ZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, X, Z); }
        public readonly Vector3I27F5 ZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, Y, X); }
        public readonly Vector3I27F5 ZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, Y, Y); }
        public readonly Vector3I27F5 ZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, Y, Z); }
        public readonly Vector3I27F5 ZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, Z, X); }
        public readonly Vector3I27F5 ZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, Z, Y); }
        public readonly Vector3I27F5 ZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I27F5(Z, Z, Z); }
        public readonly Vector4I27F5 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, X, X); }
        public readonly Vector4I27F5 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, X, Y); }
        public readonly Vector4I27F5 XXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, X, Z); }
        public readonly Vector4I27F5 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, Y, X); }
        public readonly Vector4I27F5 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, Y, Y); }
        public readonly Vector4I27F5 XXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, Y, Z); }
        public readonly Vector4I27F5 XXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, Z, X); }
        public readonly Vector4I27F5 XXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, Z, Y); }
        public readonly Vector4I27F5 XXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, X, Z, Z); }
        public readonly Vector4I27F5 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, X, X); }
        public readonly Vector4I27F5 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, X, Y); }
        public readonly Vector4I27F5 XYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, X, Z); }
        public readonly Vector4I27F5 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, Y, X); }
        public readonly Vector4I27F5 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, Y, Y); }
        public readonly Vector4I27F5 XYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, Y, Z); }
        public readonly Vector4I27F5 XYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, Z, X); }
        public readonly Vector4I27F5 XYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, Z, Y); }
        public readonly Vector4I27F5 XYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Y, Z, Z); }
        public readonly Vector4I27F5 XZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, X, X); }
        public readonly Vector4I27F5 XZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, X, Y); }
        public readonly Vector4I27F5 XZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, X, Z); }
        public readonly Vector4I27F5 XZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, Y, X); }
        public readonly Vector4I27F5 XZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, Y, Y); }
        public readonly Vector4I27F5 XZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, Y, Z); }
        public readonly Vector4I27F5 XZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, Z, X); }
        public readonly Vector4I27F5 XZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, Z, Y); }
        public readonly Vector4I27F5 XZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(X, Z, Z, Z); }
        public readonly Vector4I27F5 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, X, X); }
        public readonly Vector4I27F5 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, X, Y); }
        public readonly Vector4I27F5 YXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, X, Z); }
        public readonly Vector4I27F5 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, Y, X); }
        public readonly Vector4I27F5 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, Y, Y); }
        public readonly Vector4I27F5 YXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, Y, Z); }
        public readonly Vector4I27F5 YXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, Z, X); }
        public readonly Vector4I27F5 YXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, Z, Y); }
        public readonly Vector4I27F5 YXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, X, Z, Z); }
        public readonly Vector4I27F5 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, X, X); }
        public readonly Vector4I27F5 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, X, Y); }
        public readonly Vector4I27F5 YYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, X, Z); }
        public readonly Vector4I27F5 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, Y, X); }
        public readonly Vector4I27F5 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, Y, Y); }
        public readonly Vector4I27F5 YYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, Y, Z); }
        public readonly Vector4I27F5 YYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, Z, X); }
        public readonly Vector4I27F5 YYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, Z, Y); }
        public readonly Vector4I27F5 YYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Y, Z, Z); }
        public readonly Vector4I27F5 YZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, X, X); }
        public readonly Vector4I27F5 YZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, X, Y); }
        public readonly Vector4I27F5 YZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, X, Z); }
        public readonly Vector4I27F5 YZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, Y, X); }
        public readonly Vector4I27F5 YZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, Y, Y); }
        public readonly Vector4I27F5 YZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, Y, Z); }
        public readonly Vector4I27F5 YZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, Z, X); }
        public readonly Vector4I27F5 YZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, Z, Y); }
        public readonly Vector4I27F5 YZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Y, Z, Z, Z); }
        public readonly Vector4I27F5 ZXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, X, X); }
        public readonly Vector4I27F5 ZXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, X, Y); }
        public readonly Vector4I27F5 ZXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, X, Z); }
        public readonly Vector4I27F5 ZXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, Y, X); }
        public readonly Vector4I27F5 ZXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, Y, Y); }
        public readonly Vector4I27F5 ZXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, Y, Z); }
        public readonly Vector4I27F5 ZXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, Z, X); }
        public readonly Vector4I27F5 ZXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, Z, Y); }
        public readonly Vector4I27F5 ZXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, X, Z, Z); }
        public readonly Vector4I27F5 ZYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, X, X); }
        public readonly Vector4I27F5 ZYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, X, Y); }
        public readonly Vector4I27F5 ZYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, X, Z); }
        public readonly Vector4I27F5 ZYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, Y, X); }
        public readonly Vector4I27F5 ZYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, Y, Y); }
        public readonly Vector4I27F5 ZYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, Y, Z); }
        public readonly Vector4I27F5 ZYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, Z, X); }
        public readonly Vector4I27F5 ZYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, Z, Y); }
        public readonly Vector4I27F5 ZYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Y, Z, Z); }
        public readonly Vector4I27F5 ZZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, X, X); }
        public readonly Vector4I27F5 ZZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, X, Y); }
        public readonly Vector4I27F5 ZZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, X, Z); }
        public readonly Vector4I27F5 ZZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, Y, X); }
        public readonly Vector4I27F5 ZZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, Y, Y); }
        public readonly Vector4I27F5 ZZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, Y, Z); }
        public readonly Vector4I27F5 ZZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, Z, X); }
        public readonly Vector4I27F5 ZZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, Z, Y); }
        public readonly Vector4I27F5 ZZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I27F5(Z, Z, Z, Z); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector3I27F5 lhs, Vector3I27F5 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector3I27F5 lhs, Vector3I27F5 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector3I27F5 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y, Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector3I27F5({X}, {Y}, {Z})";

        // IEquatable<Vector3I27F5>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector3I27F5 other)
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
            return $"Vector3I27F5({x}, {y}, {z})";
        }
    }
}
