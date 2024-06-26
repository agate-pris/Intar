using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector4U22F10 : IEquatable<Vector4U22F10>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public U22F10 X;
        public U22F10 Y;
        public U22F10 Z;
        public U22F10 W;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(U22F10 x, U22F10 y, U22F10 z, U22F10 w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(U22F10 value) : this(value, value, value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(U22F10 x, U22F10 y, Vector2U22F10 zw) : this(x, y, zw.X, zw.Y) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(U22F10 x, Vector3U22F10 yzw) : this(x, yzw.X, yzw.Y, yzw.Z) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(Vector2U22F10 xy, Vector2U22F10 zw) : this(xy.X, xy.Y, zw.X, zw.Y) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(Vector4U22F10 xyzw) : this(xyzw.X, xyzw.Y, xyzw.Z, xyzw.W) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(U22F10 x, Vector2U22F10 yz, U22F10 w) : this(x, yz.X, yz.Y, w) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(Vector3U22F10 xyz, U22F10 w) : this(xyz.X, xyz.Y, xyz.Z, w) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4U22F10(Vector2U22F10 xy, U22F10 z, U22F10 w) : this(xy.X, xy.Y, z, w) { }

        // Constants
        // ---------------------------------------

        public static Vector4U22F10 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4U22F10(U22F10.Zero);
        }
        public static Vector4U22F10 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4U22F10(U22F10.One);
        }
        public static Vector4U22F10 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4U22F10(U22F10.One, U22F10.Zero, U22F10.Zero, U22F10.Zero);
        }
        public static Vector4U22F10 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4U22F10(U22F10.Zero, U22F10.One, U22F10.Zero, U22F10.Zero);
        }
        public static Vector4U22F10 UnitZ {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4U22F10(U22F10.Zero, U22F10.Zero, U22F10.One, U22F10.Zero);
        }
        public static Vector4U22F10 UnitW {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4U22F10(U22F10.Zero, U22F10.Zero, U22F10.Zero, U22F10.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4U22F10 operator +(Vector4U22F10 a, Vector4U22F10 b) => new Vector4U22F10(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z,
            a.W + b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4U22F10 operator -(Vector4U22F10 a, Vector4U22F10 b) => new Vector4U22F10(
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z,
            a.W - b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4U22F10 operator *(Vector4U22F10 a, Vector4U22F10 b) => new Vector4U22F10(
            a.X * b.X,
            a.Y * b.Y,
            a.Z * b.Z,
            a.W * b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4U22F10 operator *(Vector4U22F10 a, U22F10 b) => new Vector4U22F10(
            a.X * b,
            a.Y * b,
            a.Z * b,
            a.W * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4U22F10 operator *(U22F10 a, Vector4U22F10 b) => new Vector4U22F10(
            a * b.X,
            a * b.Y,
            a * b.Z,
            a * b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4U22F10 operator /(Vector4U22F10 a, Vector4U22F10 b) => new Vector4U22F10(
            a.X / b.X,
            a.Y / b.Y,
            a.Z / b.Z,
            a.W / b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4U22F10 operator /(Vector4U22F10 a, U22F10 b) => new Vector4U22F10(
            a.X / b,
            a.Y / b,
            a.Z / b,
            a.W / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4U22F10 operator /(U22F10 a, Vector4U22F10 b) => new Vector4U22F10(
            a / b.X,
            a / b.Y,
            a / b.Z,
            a / b.W);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2U22F10 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(X, X); }
        public readonly Vector2U22F10 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(X, Y); }
        public readonly Vector2U22F10 XZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(X, Z); }
        public readonly Vector2U22F10 XW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(X, W); }
        public readonly Vector2U22F10 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(Y, X); }
        public readonly Vector2U22F10 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(Y, Y); }
        public readonly Vector2U22F10 YZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(Y, Z); }
        public readonly Vector2U22F10 YW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(Y, W); }
        public readonly Vector2U22F10 ZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(Z, X); }
        public readonly Vector2U22F10 ZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(Z, Y); }
        public readonly Vector2U22F10 ZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(Z, Z); }
        public readonly Vector2U22F10 ZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(Z, W); }
        public readonly Vector2U22F10 WX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(W, X); }
        public readonly Vector2U22F10 WY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(W, Y); }
        public readonly Vector2U22F10 WZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(W, Z); }
        public readonly Vector2U22F10 WW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2U22F10(W, W); }
        public readonly Vector3U22F10 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, X, X); }
        public readonly Vector3U22F10 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, X, Y); }
        public readonly Vector3U22F10 XXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, X, Z); }
        public readonly Vector3U22F10 XXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, X, W); }
        public readonly Vector3U22F10 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, Y, X); }
        public readonly Vector3U22F10 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, Y, Y); }
        public readonly Vector3U22F10 XYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, Y, Z); }
        public readonly Vector3U22F10 XYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, Y, W); }
        public readonly Vector3U22F10 XZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, Z, X); }
        public readonly Vector3U22F10 XZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, Z, Y); }
        public readonly Vector3U22F10 XZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, Z, Z); }
        public readonly Vector3U22F10 XZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, Z, W); }
        public readonly Vector3U22F10 XWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, W, X); }
        public readonly Vector3U22F10 XWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, W, Y); }
        public readonly Vector3U22F10 XWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, W, Z); }
        public readonly Vector3U22F10 XWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(X, W, W); }
        public readonly Vector3U22F10 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, X, X); }
        public readonly Vector3U22F10 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, X, Y); }
        public readonly Vector3U22F10 YXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, X, Z); }
        public readonly Vector3U22F10 YXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, X, W); }
        public readonly Vector3U22F10 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, Y, X); }
        public readonly Vector3U22F10 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, Y, Y); }
        public readonly Vector3U22F10 YYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, Y, Z); }
        public readonly Vector3U22F10 YYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, Y, W); }
        public readonly Vector3U22F10 YZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, Z, X); }
        public readonly Vector3U22F10 YZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, Z, Y); }
        public readonly Vector3U22F10 YZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, Z, Z); }
        public readonly Vector3U22F10 YZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, Z, W); }
        public readonly Vector3U22F10 YWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, W, X); }
        public readonly Vector3U22F10 YWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, W, Y); }
        public readonly Vector3U22F10 YWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, W, Z); }
        public readonly Vector3U22F10 YWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Y, W, W); }
        public readonly Vector3U22F10 ZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, X, X); }
        public readonly Vector3U22F10 ZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, X, Y); }
        public readonly Vector3U22F10 ZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, X, Z); }
        public readonly Vector3U22F10 ZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, X, W); }
        public readonly Vector3U22F10 ZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, Y, X); }
        public readonly Vector3U22F10 ZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, Y, Y); }
        public readonly Vector3U22F10 ZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, Y, Z); }
        public readonly Vector3U22F10 ZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, Y, W); }
        public readonly Vector3U22F10 ZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, Z, X); }
        public readonly Vector3U22F10 ZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, Z, Y); }
        public readonly Vector3U22F10 ZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, Z, Z); }
        public readonly Vector3U22F10 ZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, Z, W); }
        public readonly Vector3U22F10 ZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, W, X); }
        public readonly Vector3U22F10 ZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, W, Y); }
        public readonly Vector3U22F10 ZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, W, Z); }
        public readonly Vector3U22F10 ZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(Z, W, W); }
        public readonly Vector3U22F10 WXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, X, X); }
        public readonly Vector3U22F10 WXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, X, Y); }
        public readonly Vector3U22F10 WXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, X, Z); }
        public readonly Vector3U22F10 WXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, X, W); }
        public readonly Vector3U22F10 WYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, Y, X); }
        public readonly Vector3U22F10 WYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, Y, Y); }
        public readonly Vector3U22F10 WYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, Y, Z); }
        public readonly Vector3U22F10 WYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, Y, W); }
        public readonly Vector3U22F10 WZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, Z, X); }
        public readonly Vector3U22F10 WZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, Z, Y); }
        public readonly Vector3U22F10 WZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, Z, Z); }
        public readonly Vector3U22F10 WZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, Z, W); }
        public readonly Vector3U22F10 WWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, W, X); }
        public readonly Vector3U22F10 WWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, W, Y); }
        public readonly Vector3U22F10 WWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, W, Z); }
        public readonly Vector3U22F10 WWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3U22F10(W, W, W); }
        public readonly Vector4U22F10 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, X, X); }
        public readonly Vector4U22F10 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, X, Y); }
        public readonly Vector4U22F10 XXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, X, Z); }
        public readonly Vector4U22F10 XXXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, X, W); }
        public readonly Vector4U22F10 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, Y, X); }
        public readonly Vector4U22F10 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, Y, Y); }
        public readonly Vector4U22F10 XXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, Y, Z); }
        public readonly Vector4U22F10 XXYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, Y, W); }
        public readonly Vector4U22F10 XXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, Z, X); }
        public readonly Vector4U22F10 XXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, Z, Y); }
        public readonly Vector4U22F10 XXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, Z, Z); }
        public readonly Vector4U22F10 XXZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, Z, W); }
        public readonly Vector4U22F10 XXWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, W, X); }
        public readonly Vector4U22F10 XXWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, W, Y); }
        public readonly Vector4U22F10 XXWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, W, Z); }
        public readonly Vector4U22F10 XXWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, X, W, W); }
        public readonly Vector4U22F10 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, X, X); }
        public readonly Vector4U22F10 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, X, Y); }
        public readonly Vector4U22F10 XYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, X, Z); }
        public readonly Vector4U22F10 XYXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, X, W); }
        public readonly Vector4U22F10 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, Y, X); }
        public readonly Vector4U22F10 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, Y, Y); }
        public readonly Vector4U22F10 XYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, Y, Z); }
        public readonly Vector4U22F10 XYYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, Y, W); }
        public readonly Vector4U22F10 XYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, Z, X); }
        public readonly Vector4U22F10 XYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, Z, Y); }
        public readonly Vector4U22F10 XYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, Z, Z); }
        public readonly Vector4U22F10 XYZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, Z, W); }
        public readonly Vector4U22F10 XYWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, W, X); }
        public readonly Vector4U22F10 XYWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, W, Y); }
        public readonly Vector4U22F10 XYWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, W, Z); }
        public readonly Vector4U22F10 XYWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Y, W, W); }
        public readonly Vector4U22F10 XZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, X, X); }
        public readonly Vector4U22F10 XZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, X, Y); }
        public readonly Vector4U22F10 XZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, X, Z); }
        public readonly Vector4U22F10 XZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, X, W); }
        public readonly Vector4U22F10 XZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, Y, X); }
        public readonly Vector4U22F10 XZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, Y, Y); }
        public readonly Vector4U22F10 XZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, Y, Z); }
        public readonly Vector4U22F10 XZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, Y, W); }
        public readonly Vector4U22F10 XZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, Z, X); }
        public readonly Vector4U22F10 XZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, Z, Y); }
        public readonly Vector4U22F10 XZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, Z, Z); }
        public readonly Vector4U22F10 XZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, Z, W); }
        public readonly Vector4U22F10 XZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, W, X); }
        public readonly Vector4U22F10 XZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, W, Y); }
        public readonly Vector4U22F10 XZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, W, Z); }
        public readonly Vector4U22F10 XZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, Z, W, W); }
        public readonly Vector4U22F10 XWXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, X, X); }
        public readonly Vector4U22F10 XWXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, X, Y); }
        public readonly Vector4U22F10 XWXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, X, Z); }
        public readonly Vector4U22F10 XWXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, X, W); }
        public readonly Vector4U22F10 XWYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, Y, X); }
        public readonly Vector4U22F10 XWYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, Y, Y); }
        public readonly Vector4U22F10 XWYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, Y, Z); }
        public readonly Vector4U22F10 XWYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, Y, W); }
        public readonly Vector4U22F10 XWZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, Z, X); }
        public readonly Vector4U22F10 XWZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, Z, Y); }
        public readonly Vector4U22F10 XWZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, Z, Z); }
        public readonly Vector4U22F10 XWZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, Z, W); }
        public readonly Vector4U22F10 XWWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, W, X); }
        public readonly Vector4U22F10 XWWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, W, Y); }
        public readonly Vector4U22F10 XWWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, W, Z); }
        public readonly Vector4U22F10 XWWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(X, W, W, W); }
        public readonly Vector4U22F10 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, X, X); }
        public readonly Vector4U22F10 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, X, Y); }
        public readonly Vector4U22F10 YXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, X, Z); }
        public readonly Vector4U22F10 YXXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, X, W); }
        public readonly Vector4U22F10 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, Y, X); }
        public readonly Vector4U22F10 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, Y, Y); }
        public readonly Vector4U22F10 YXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, Y, Z); }
        public readonly Vector4U22F10 YXYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, Y, W); }
        public readonly Vector4U22F10 YXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, Z, X); }
        public readonly Vector4U22F10 YXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, Z, Y); }
        public readonly Vector4U22F10 YXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, Z, Z); }
        public readonly Vector4U22F10 YXZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, Z, W); }
        public readonly Vector4U22F10 YXWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, W, X); }
        public readonly Vector4U22F10 YXWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, W, Y); }
        public readonly Vector4U22F10 YXWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, W, Z); }
        public readonly Vector4U22F10 YXWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, X, W, W); }
        public readonly Vector4U22F10 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, X, X); }
        public readonly Vector4U22F10 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, X, Y); }
        public readonly Vector4U22F10 YYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, X, Z); }
        public readonly Vector4U22F10 YYXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, X, W); }
        public readonly Vector4U22F10 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, Y, X); }
        public readonly Vector4U22F10 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, Y, Y); }
        public readonly Vector4U22F10 YYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, Y, Z); }
        public readonly Vector4U22F10 YYYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, Y, W); }
        public readonly Vector4U22F10 YYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, Z, X); }
        public readonly Vector4U22F10 YYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, Z, Y); }
        public readonly Vector4U22F10 YYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, Z, Z); }
        public readonly Vector4U22F10 YYZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, Z, W); }
        public readonly Vector4U22F10 YYWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, W, X); }
        public readonly Vector4U22F10 YYWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, W, Y); }
        public readonly Vector4U22F10 YYWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, W, Z); }
        public readonly Vector4U22F10 YYWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Y, W, W); }
        public readonly Vector4U22F10 YZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, X, X); }
        public readonly Vector4U22F10 YZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, X, Y); }
        public readonly Vector4U22F10 YZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, X, Z); }
        public readonly Vector4U22F10 YZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, X, W); }
        public readonly Vector4U22F10 YZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, Y, X); }
        public readonly Vector4U22F10 YZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, Y, Y); }
        public readonly Vector4U22F10 YZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, Y, Z); }
        public readonly Vector4U22F10 YZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, Y, W); }
        public readonly Vector4U22F10 YZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, Z, X); }
        public readonly Vector4U22F10 YZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, Z, Y); }
        public readonly Vector4U22F10 YZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, Z, Z); }
        public readonly Vector4U22F10 YZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, Z, W); }
        public readonly Vector4U22F10 YZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, W, X); }
        public readonly Vector4U22F10 YZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, W, Y); }
        public readonly Vector4U22F10 YZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, W, Z); }
        public readonly Vector4U22F10 YZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, Z, W, W); }
        public readonly Vector4U22F10 YWXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, X, X); }
        public readonly Vector4U22F10 YWXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, X, Y); }
        public readonly Vector4U22F10 YWXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, X, Z); }
        public readonly Vector4U22F10 YWXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, X, W); }
        public readonly Vector4U22F10 YWYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, Y, X); }
        public readonly Vector4U22F10 YWYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, Y, Y); }
        public readonly Vector4U22F10 YWYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, Y, Z); }
        public readonly Vector4U22F10 YWYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, Y, W); }
        public readonly Vector4U22F10 YWZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, Z, X); }
        public readonly Vector4U22F10 YWZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, Z, Y); }
        public readonly Vector4U22F10 YWZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, Z, Z); }
        public readonly Vector4U22F10 YWZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, Z, W); }
        public readonly Vector4U22F10 YWWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, W, X); }
        public readonly Vector4U22F10 YWWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, W, Y); }
        public readonly Vector4U22F10 YWWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, W, Z); }
        public readonly Vector4U22F10 YWWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Y, W, W, W); }
        public readonly Vector4U22F10 ZXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, X, X); }
        public readonly Vector4U22F10 ZXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, X, Y); }
        public readonly Vector4U22F10 ZXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, X, Z); }
        public readonly Vector4U22F10 ZXXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, X, W); }
        public readonly Vector4U22F10 ZXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, Y, X); }
        public readonly Vector4U22F10 ZXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, Y, Y); }
        public readonly Vector4U22F10 ZXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, Y, Z); }
        public readonly Vector4U22F10 ZXYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, Y, W); }
        public readonly Vector4U22F10 ZXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, Z, X); }
        public readonly Vector4U22F10 ZXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, Z, Y); }
        public readonly Vector4U22F10 ZXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, Z, Z); }
        public readonly Vector4U22F10 ZXZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, Z, W); }
        public readonly Vector4U22F10 ZXWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, W, X); }
        public readonly Vector4U22F10 ZXWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, W, Y); }
        public readonly Vector4U22F10 ZXWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, W, Z); }
        public readonly Vector4U22F10 ZXWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, X, W, W); }
        public readonly Vector4U22F10 ZYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, X, X); }
        public readonly Vector4U22F10 ZYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, X, Y); }
        public readonly Vector4U22F10 ZYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, X, Z); }
        public readonly Vector4U22F10 ZYXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, X, W); }
        public readonly Vector4U22F10 ZYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, Y, X); }
        public readonly Vector4U22F10 ZYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, Y, Y); }
        public readonly Vector4U22F10 ZYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, Y, Z); }
        public readonly Vector4U22F10 ZYYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, Y, W); }
        public readonly Vector4U22F10 ZYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, Z, X); }
        public readonly Vector4U22F10 ZYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, Z, Y); }
        public readonly Vector4U22F10 ZYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, Z, Z); }
        public readonly Vector4U22F10 ZYZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, Z, W); }
        public readonly Vector4U22F10 ZYWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, W, X); }
        public readonly Vector4U22F10 ZYWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, W, Y); }
        public readonly Vector4U22F10 ZYWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, W, Z); }
        public readonly Vector4U22F10 ZYWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Y, W, W); }
        public readonly Vector4U22F10 ZZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, X, X); }
        public readonly Vector4U22F10 ZZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, X, Y); }
        public readonly Vector4U22F10 ZZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, X, Z); }
        public readonly Vector4U22F10 ZZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, X, W); }
        public readonly Vector4U22F10 ZZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, Y, X); }
        public readonly Vector4U22F10 ZZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, Y, Y); }
        public readonly Vector4U22F10 ZZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, Y, Z); }
        public readonly Vector4U22F10 ZZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, Y, W); }
        public readonly Vector4U22F10 ZZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, Z, X); }
        public readonly Vector4U22F10 ZZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, Z, Y); }
        public readonly Vector4U22F10 ZZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, Z, Z); }
        public readonly Vector4U22F10 ZZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, Z, W); }
        public readonly Vector4U22F10 ZZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, W, X); }
        public readonly Vector4U22F10 ZZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, W, Y); }
        public readonly Vector4U22F10 ZZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, W, Z); }
        public readonly Vector4U22F10 ZZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, Z, W, W); }
        public readonly Vector4U22F10 ZWXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, X, X); }
        public readonly Vector4U22F10 ZWXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, X, Y); }
        public readonly Vector4U22F10 ZWXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, X, Z); }
        public readonly Vector4U22F10 ZWXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, X, W); }
        public readonly Vector4U22F10 ZWYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, Y, X); }
        public readonly Vector4U22F10 ZWYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, Y, Y); }
        public readonly Vector4U22F10 ZWYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, Y, Z); }
        public readonly Vector4U22F10 ZWYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, Y, W); }
        public readonly Vector4U22F10 ZWZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, Z, X); }
        public readonly Vector4U22F10 ZWZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, Z, Y); }
        public readonly Vector4U22F10 ZWZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, Z, Z); }
        public readonly Vector4U22F10 ZWZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, Z, W); }
        public readonly Vector4U22F10 ZWWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, W, X); }
        public readonly Vector4U22F10 ZWWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, W, Y); }
        public readonly Vector4U22F10 ZWWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, W, Z); }
        public readonly Vector4U22F10 ZWWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(Z, W, W, W); }
        public readonly Vector4U22F10 WXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, X, X); }
        public readonly Vector4U22F10 WXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, X, Y); }
        public readonly Vector4U22F10 WXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, X, Z); }
        public readonly Vector4U22F10 WXXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, X, W); }
        public readonly Vector4U22F10 WXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, Y, X); }
        public readonly Vector4U22F10 WXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, Y, Y); }
        public readonly Vector4U22F10 WXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, Y, Z); }
        public readonly Vector4U22F10 WXYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, Y, W); }
        public readonly Vector4U22F10 WXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, Z, X); }
        public readonly Vector4U22F10 WXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, Z, Y); }
        public readonly Vector4U22F10 WXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, Z, Z); }
        public readonly Vector4U22F10 WXZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, Z, W); }
        public readonly Vector4U22F10 WXWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, W, X); }
        public readonly Vector4U22F10 WXWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, W, Y); }
        public readonly Vector4U22F10 WXWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, W, Z); }
        public readonly Vector4U22F10 WXWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, X, W, W); }
        public readonly Vector4U22F10 WYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, X, X); }
        public readonly Vector4U22F10 WYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, X, Y); }
        public readonly Vector4U22F10 WYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, X, Z); }
        public readonly Vector4U22F10 WYXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, X, W); }
        public readonly Vector4U22F10 WYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, Y, X); }
        public readonly Vector4U22F10 WYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, Y, Y); }
        public readonly Vector4U22F10 WYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, Y, Z); }
        public readonly Vector4U22F10 WYYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, Y, W); }
        public readonly Vector4U22F10 WYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, Z, X); }
        public readonly Vector4U22F10 WYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, Z, Y); }
        public readonly Vector4U22F10 WYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, Z, Z); }
        public readonly Vector4U22F10 WYZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, Z, W); }
        public readonly Vector4U22F10 WYWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, W, X); }
        public readonly Vector4U22F10 WYWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, W, Y); }
        public readonly Vector4U22F10 WYWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, W, Z); }
        public readonly Vector4U22F10 WYWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Y, W, W); }
        public readonly Vector4U22F10 WZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, X, X); }
        public readonly Vector4U22F10 WZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, X, Y); }
        public readonly Vector4U22F10 WZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, X, Z); }
        public readonly Vector4U22F10 WZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, X, W); }
        public readonly Vector4U22F10 WZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, Y, X); }
        public readonly Vector4U22F10 WZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, Y, Y); }
        public readonly Vector4U22F10 WZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, Y, Z); }
        public readonly Vector4U22F10 WZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, Y, W); }
        public readonly Vector4U22F10 WZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, Z, X); }
        public readonly Vector4U22F10 WZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, Z, Y); }
        public readonly Vector4U22F10 WZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, Z, Z); }
        public readonly Vector4U22F10 WZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, Z, W); }
        public readonly Vector4U22F10 WZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, W, X); }
        public readonly Vector4U22F10 WZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, W, Y); }
        public readonly Vector4U22F10 WZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, W, Z); }
        public readonly Vector4U22F10 WZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, Z, W, W); }
        public readonly Vector4U22F10 WWXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, X, X); }
        public readonly Vector4U22F10 WWXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, X, Y); }
        public readonly Vector4U22F10 WWXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, X, Z); }
        public readonly Vector4U22F10 WWXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, X, W); }
        public readonly Vector4U22F10 WWYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, Y, X); }
        public readonly Vector4U22F10 WWYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, Y, Y); }
        public readonly Vector4U22F10 WWYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, Y, Z); }
        public readonly Vector4U22F10 WWYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, Y, W); }
        public readonly Vector4U22F10 WWZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, Z, X); }
        public readonly Vector4U22F10 WWZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, Z, Y); }
        public readonly Vector4U22F10 WWZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, Z, Z); }
        public readonly Vector4U22F10 WWZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, Z, W); }
        public readonly Vector4U22F10 WWWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, W, X); }
        public readonly Vector4U22F10 WWWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, W, Y); }
        public readonly Vector4U22F10 WWWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, W, Z); }
        public readonly Vector4U22F10 WWWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4U22F10(W, W, W, W); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector4U22F10 lhs, Vector4U22F10 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector4U22F10 lhs, Vector4U22F10 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector4U22F10 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y, Z, W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector4U22F10({X}, {Y}, {Z}, {W})";

        // IEquatable<Vector4U22F10>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector4U22F10 other)
            => other.X == X
            && other.Y == Y
            && other.Z == Z
            && other.W == W;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = X.ToString(format, formatProvider);
            var y = Y.ToString(format, formatProvider);
            var z = Z.ToString(format, formatProvider);
            var w = W.ToString(format, formatProvider);
            return $"Vector4U22F10({x}, {y}, {z}, {w})";
        }
    }
}
