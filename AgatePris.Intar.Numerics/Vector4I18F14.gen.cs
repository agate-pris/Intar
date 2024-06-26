using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Numerics {
    [Serializable]
    public struct Vector4I18F14 : IEquatable<Vector4I18F14>, IFormattable {
        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public I18F14 X;
        public I18F14 Y;
        public I18F14 Z;
        public I18F14 W;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(I18F14 x, I18F14 y, I18F14 z, I18F14 w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(I18F14 value) : this(value, value, value, value) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(I18F14 x, I18F14 y, Vector2I18F14 zw) : this(x, y, zw.X, zw.Y) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(I18F14 x, Vector3I18F14 yzw) : this(x, yzw.X, yzw.Y, yzw.Z) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(Vector2I18F14 xy, Vector2I18F14 zw) : this(xy.X, xy.Y, zw.X, zw.Y) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(Vector4I18F14 xyzw) : this(xyzw.X, xyzw.Y, xyzw.Z, xyzw.W) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(I18F14 x, Vector2I18F14 yz, I18F14 w) : this(x, yz.X, yz.Y, w) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(Vector3I18F14 xyz, I18F14 w) : this(xyz.X, xyz.Y, xyz.Z, w) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I18F14(Vector2I18F14 xy, I18F14 z, I18F14 w) : this(xy.X, xy.Y, z, w) { }

        // Constants
        // ---------------------------------------

        public static Vector4I18F14 Zero {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4I18F14(I18F14.Zero);
        }
        public static Vector4I18F14 One {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4I18F14(I18F14.One);
        }
        public static Vector4I18F14 UnitX {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4I18F14(I18F14.One, I18F14.Zero, I18F14.Zero, I18F14.Zero);
        }
        public static Vector4I18F14 UnitY {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4I18F14(I18F14.Zero, I18F14.One, I18F14.Zero, I18F14.Zero);
        }
        public static Vector4I18F14 UnitZ {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4I18F14(I18F14.Zero, I18F14.Zero, I18F14.One, I18F14.Zero);
        }
        public static Vector4I18F14 UnitW {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vector4I18F14(I18F14.Zero, I18F14.Zero, I18F14.Zero, I18F14.One);
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I18F14 operator +(Vector4I18F14 a, Vector4I18F14 b) => new Vector4I18F14(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z,
            a.W + b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I18F14 operator -(Vector4I18F14 a, Vector4I18F14 b) => new Vector4I18F14(
            a.X - b.X,
            a.Y - b.Y,
            a.Z - b.Z,
            a.W - b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I18F14 operator *(Vector4I18F14 a, Vector4I18F14 b) => new Vector4I18F14(
            a.X * b.X,
            a.Y * b.Y,
            a.Z * b.Z,
            a.W * b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I18F14 operator *(Vector4I18F14 a, I18F14 b) => new Vector4I18F14(
            a.X * b,
            a.Y * b,
            a.Z * b,
            a.W * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I18F14 operator *(I18F14 a, Vector4I18F14 b) => new Vector4I18F14(
            a * b.X,
            a * b.Y,
            a * b.Z,
            a * b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I18F14 operator /(Vector4I18F14 a, Vector4I18F14 b) => new Vector4I18F14(
            a.X / b.X,
            a.Y / b.Y,
            a.Z / b.Z,
            a.W / b.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I18F14 operator /(Vector4I18F14 a, I18F14 b) => new Vector4I18F14(
            a.X / b,
            a.Y / b,
            a.Z / b,
            a.W / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I18F14 operator /(I18F14 a, Vector4I18F14 b) => new Vector4I18F14(
            a / b.X,
            a / b.Y,
            a / b.Z,
            a / b.W);

        // Swizzling Properties
        // ---------------------------------------

        public readonly Vector2I18F14 XX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(X, X); }
        public readonly Vector2I18F14 XY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(X, Y); }
        public readonly Vector2I18F14 XZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(X, Z); }
        public readonly Vector2I18F14 XW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(X, W); }
        public readonly Vector2I18F14 YX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(Y, X); }
        public readonly Vector2I18F14 YY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(Y, Y); }
        public readonly Vector2I18F14 YZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(Y, Z); }
        public readonly Vector2I18F14 YW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(Y, W); }
        public readonly Vector2I18F14 ZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(Z, X); }
        public readonly Vector2I18F14 ZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(Z, Y); }
        public readonly Vector2I18F14 ZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(Z, Z); }
        public readonly Vector2I18F14 ZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(Z, W); }
        public readonly Vector2I18F14 WX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(W, X); }
        public readonly Vector2I18F14 WY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(W, Y); }
        public readonly Vector2I18F14 WZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(W, Z); }
        public readonly Vector2I18F14 WW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I18F14(W, W); }
        public readonly Vector3I18F14 XXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, X, X); }
        public readonly Vector3I18F14 XXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, X, Y); }
        public readonly Vector3I18F14 XXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, X, Z); }
        public readonly Vector3I18F14 XXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, X, W); }
        public readonly Vector3I18F14 XYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, Y, X); }
        public readonly Vector3I18F14 XYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, Y, Y); }
        public readonly Vector3I18F14 XYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, Y, Z); }
        public readonly Vector3I18F14 XYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, Y, W); }
        public readonly Vector3I18F14 XZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, Z, X); }
        public readonly Vector3I18F14 XZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, Z, Y); }
        public readonly Vector3I18F14 XZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, Z, Z); }
        public readonly Vector3I18F14 XZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, Z, W); }
        public readonly Vector3I18F14 XWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, W, X); }
        public readonly Vector3I18F14 XWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, W, Y); }
        public readonly Vector3I18F14 XWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, W, Z); }
        public readonly Vector3I18F14 XWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(X, W, W); }
        public readonly Vector3I18F14 YXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, X, X); }
        public readonly Vector3I18F14 YXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, X, Y); }
        public readonly Vector3I18F14 YXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, X, Z); }
        public readonly Vector3I18F14 YXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, X, W); }
        public readonly Vector3I18F14 YYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, Y, X); }
        public readonly Vector3I18F14 YYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, Y, Y); }
        public readonly Vector3I18F14 YYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, Y, Z); }
        public readonly Vector3I18F14 YYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, Y, W); }
        public readonly Vector3I18F14 YZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, Z, X); }
        public readonly Vector3I18F14 YZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, Z, Y); }
        public readonly Vector3I18F14 YZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, Z, Z); }
        public readonly Vector3I18F14 YZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, Z, W); }
        public readonly Vector3I18F14 YWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, W, X); }
        public readonly Vector3I18F14 YWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, W, Y); }
        public readonly Vector3I18F14 YWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, W, Z); }
        public readonly Vector3I18F14 YWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Y, W, W); }
        public readonly Vector3I18F14 ZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, X, X); }
        public readonly Vector3I18F14 ZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, X, Y); }
        public readonly Vector3I18F14 ZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, X, Z); }
        public readonly Vector3I18F14 ZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, X, W); }
        public readonly Vector3I18F14 ZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, Y, X); }
        public readonly Vector3I18F14 ZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, Y, Y); }
        public readonly Vector3I18F14 ZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, Y, Z); }
        public readonly Vector3I18F14 ZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, Y, W); }
        public readonly Vector3I18F14 ZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, Z, X); }
        public readonly Vector3I18F14 ZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, Z, Y); }
        public readonly Vector3I18F14 ZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, Z, Z); }
        public readonly Vector3I18F14 ZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, Z, W); }
        public readonly Vector3I18F14 ZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, W, X); }
        public readonly Vector3I18F14 ZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, W, Y); }
        public readonly Vector3I18F14 ZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, W, Z); }
        public readonly Vector3I18F14 ZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(Z, W, W); }
        public readonly Vector3I18F14 WXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, X, X); }
        public readonly Vector3I18F14 WXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, X, Y); }
        public readonly Vector3I18F14 WXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, X, Z); }
        public readonly Vector3I18F14 WXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, X, W); }
        public readonly Vector3I18F14 WYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, Y, X); }
        public readonly Vector3I18F14 WYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, Y, Y); }
        public readonly Vector3I18F14 WYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, Y, Z); }
        public readonly Vector3I18F14 WYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, Y, W); }
        public readonly Vector3I18F14 WZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, Z, X); }
        public readonly Vector3I18F14 WZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, Z, Y); }
        public readonly Vector3I18F14 WZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, Z, Z); }
        public readonly Vector3I18F14 WZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, Z, W); }
        public readonly Vector3I18F14 WWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, W, X); }
        public readonly Vector3I18F14 WWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, W, Y); }
        public readonly Vector3I18F14 WWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, W, Z); }
        public readonly Vector3I18F14 WWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I18F14(W, W, W); }
        public readonly Vector4I18F14 XXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, X, X); }
        public readonly Vector4I18F14 XXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, X, Y); }
        public readonly Vector4I18F14 XXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, X, Z); }
        public readonly Vector4I18F14 XXXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, X, W); }
        public readonly Vector4I18F14 XXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, Y, X); }
        public readonly Vector4I18F14 XXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, Y, Y); }
        public readonly Vector4I18F14 XXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, Y, Z); }
        public readonly Vector4I18F14 XXYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, Y, W); }
        public readonly Vector4I18F14 XXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, Z, X); }
        public readonly Vector4I18F14 XXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, Z, Y); }
        public readonly Vector4I18F14 XXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, Z, Z); }
        public readonly Vector4I18F14 XXZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, Z, W); }
        public readonly Vector4I18F14 XXWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, W, X); }
        public readonly Vector4I18F14 XXWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, W, Y); }
        public readonly Vector4I18F14 XXWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, W, Z); }
        public readonly Vector4I18F14 XXWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, X, W, W); }
        public readonly Vector4I18F14 XYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, X, X); }
        public readonly Vector4I18F14 XYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, X, Y); }
        public readonly Vector4I18F14 XYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, X, Z); }
        public readonly Vector4I18F14 XYXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, X, W); }
        public readonly Vector4I18F14 XYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, Y, X); }
        public readonly Vector4I18F14 XYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, Y, Y); }
        public readonly Vector4I18F14 XYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, Y, Z); }
        public readonly Vector4I18F14 XYYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, Y, W); }
        public readonly Vector4I18F14 XYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, Z, X); }
        public readonly Vector4I18F14 XYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, Z, Y); }
        public readonly Vector4I18F14 XYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, Z, Z); }
        public readonly Vector4I18F14 XYZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, Z, W); }
        public readonly Vector4I18F14 XYWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, W, X); }
        public readonly Vector4I18F14 XYWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, W, Y); }
        public readonly Vector4I18F14 XYWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, W, Z); }
        public readonly Vector4I18F14 XYWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Y, W, W); }
        public readonly Vector4I18F14 XZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, X, X); }
        public readonly Vector4I18F14 XZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, X, Y); }
        public readonly Vector4I18F14 XZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, X, Z); }
        public readonly Vector4I18F14 XZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, X, W); }
        public readonly Vector4I18F14 XZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, Y, X); }
        public readonly Vector4I18F14 XZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, Y, Y); }
        public readonly Vector4I18F14 XZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, Y, Z); }
        public readonly Vector4I18F14 XZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, Y, W); }
        public readonly Vector4I18F14 XZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, Z, X); }
        public readonly Vector4I18F14 XZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, Z, Y); }
        public readonly Vector4I18F14 XZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, Z, Z); }
        public readonly Vector4I18F14 XZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, Z, W); }
        public readonly Vector4I18F14 XZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, W, X); }
        public readonly Vector4I18F14 XZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, W, Y); }
        public readonly Vector4I18F14 XZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, W, Z); }
        public readonly Vector4I18F14 XZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, Z, W, W); }
        public readonly Vector4I18F14 XWXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, X, X); }
        public readonly Vector4I18F14 XWXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, X, Y); }
        public readonly Vector4I18F14 XWXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, X, Z); }
        public readonly Vector4I18F14 XWXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, X, W); }
        public readonly Vector4I18F14 XWYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, Y, X); }
        public readonly Vector4I18F14 XWYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, Y, Y); }
        public readonly Vector4I18F14 XWYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, Y, Z); }
        public readonly Vector4I18F14 XWYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, Y, W); }
        public readonly Vector4I18F14 XWZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, Z, X); }
        public readonly Vector4I18F14 XWZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, Z, Y); }
        public readonly Vector4I18F14 XWZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, Z, Z); }
        public readonly Vector4I18F14 XWZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, Z, W); }
        public readonly Vector4I18F14 XWWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, W, X); }
        public readonly Vector4I18F14 XWWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, W, Y); }
        public readonly Vector4I18F14 XWWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, W, Z); }
        public readonly Vector4I18F14 XWWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(X, W, W, W); }
        public readonly Vector4I18F14 YXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, X, X); }
        public readonly Vector4I18F14 YXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, X, Y); }
        public readonly Vector4I18F14 YXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, X, Z); }
        public readonly Vector4I18F14 YXXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, X, W); }
        public readonly Vector4I18F14 YXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, Y, X); }
        public readonly Vector4I18F14 YXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, Y, Y); }
        public readonly Vector4I18F14 YXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, Y, Z); }
        public readonly Vector4I18F14 YXYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, Y, W); }
        public readonly Vector4I18F14 YXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, Z, X); }
        public readonly Vector4I18F14 YXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, Z, Y); }
        public readonly Vector4I18F14 YXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, Z, Z); }
        public readonly Vector4I18F14 YXZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, Z, W); }
        public readonly Vector4I18F14 YXWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, W, X); }
        public readonly Vector4I18F14 YXWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, W, Y); }
        public readonly Vector4I18F14 YXWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, W, Z); }
        public readonly Vector4I18F14 YXWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, X, W, W); }
        public readonly Vector4I18F14 YYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, X, X); }
        public readonly Vector4I18F14 YYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, X, Y); }
        public readonly Vector4I18F14 YYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, X, Z); }
        public readonly Vector4I18F14 YYXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, X, W); }
        public readonly Vector4I18F14 YYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, Y, X); }
        public readonly Vector4I18F14 YYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, Y, Y); }
        public readonly Vector4I18F14 YYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, Y, Z); }
        public readonly Vector4I18F14 YYYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, Y, W); }
        public readonly Vector4I18F14 YYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, Z, X); }
        public readonly Vector4I18F14 YYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, Z, Y); }
        public readonly Vector4I18F14 YYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, Z, Z); }
        public readonly Vector4I18F14 YYZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, Z, W); }
        public readonly Vector4I18F14 YYWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, W, X); }
        public readonly Vector4I18F14 YYWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, W, Y); }
        public readonly Vector4I18F14 YYWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, W, Z); }
        public readonly Vector4I18F14 YYWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Y, W, W); }
        public readonly Vector4I18F14 YZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, X, X); }
        public readonly Vector4I18F14 YZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, X, Y); }
        public readonly Vector4I18F14 YZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, X, Z); }
        public readonly Vector4I18F14 YZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, X, W); }
        public readonly Vector4I18F14 YZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, Y, X); }
        public readonly Vector4I18F14 YZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, Y, Y); }
        public readonly Vector4I18F14 YZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, Y, Z); }
        public readonly Vector4I18F14 YZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, Y, W); }
        public readonly Vector4I18F14 YZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, Z, X); }
        public readonly Vector4I18F14 YZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, Z, Y); }
        public readonly Vector4I18F14 YZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, Z, Z); }
        public readonly Vector4I18F14 YZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, Z, W); }
        public readonly Vector4I18F14 YZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, W, X); }
        public readonly Vector4I18F14 YZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, W, Y); }
        public readonly Vector4I18F14 YZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, W, Z); }
        public readonly Vector4I18F14 YZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, Z, W, W); }
        public readonly Vector4I18F14 YWXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, X, X); }
        public readonly Vector4I18F14 YWXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, X, Y); }
        public readonly Vector4I18F14 YWXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, X, Z); }
        public readonly Vector4I18F14 YWXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, X, W); }
        public readonly Vector4I18F14 YWYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, Y, X); }
        public readonly Vector4I18F14 YWYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, Y, Y); }
        public readonly Vector4I18F14 YWYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, Y, Z); }
        public readonly Vector4I18F14 YWYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, Y, W); }
        public readonly Vector4I18F14 YWZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, Z, X); }
        public readonly Vector4I18F14 YWZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, Z, Y); }
        public readonly Vector4I18F14 YWZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, Z, Z); }
        public readonly Vector4I18F14 YWZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, Z, W); }
        public readonly Vector4I18F14 YWWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, W, X); }
        public readonly Vector4I18F14 YWWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, W, Y); }
        public readonly Vector4I18F14 YWWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, W, Z); }
        public readonly Vector4I18F14 YWWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Y, W, W, W); }
        public readonly Vector4I18F14 ZXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, X, X); }
        public readonly Vector4I18F14 ZXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, X, Y); }
        public readonly Vector4I18F14 ZXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, X, Z); }
        public readonly Vector4I18F14 ZXXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, X, W); }
        public readonly Vector4I18F14 ZXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, Y, X); }
        public readonly Vector4I18F14 ZXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, Y, Y); }
        public readonly Vector4I18F14 ZXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, Y, Z); }
        public readonly Vector4I18F14 ZXYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, Y, W); }
        public readonly Vector4I18F14 ZXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, Z, X); }
        public readonly Vector4I18F14 ZXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, Z, Y); }
        public readonly Vector4I18F14 ZXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, Z, Z); }
        public readonly Vector4I18F14 ZXZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, Z, W); }
        public readonly Vector4I18F14 ZXWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, W, X); }
        public readonly Vector4I18F14 ZXWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, W, Y); }
        public readonly Vector4I18F14 ZXWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, W, Z); }
        public readonly Vector4I18F14 ZXWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, X, W, W); }
        public readonly Vector4I18F14 ZYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, X, X); }
        public readonly Vector4I18F14 ZYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, X, Y); }
        public readonly Vector4I18F14 ZYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, X, Z); }
        public readonly Vector4I18F14 ZYXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, X, W); }
        public readonly Vector4I18F14 ZYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, Y, X); }
        public readonly Vector4I18F14 ZYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, Y, Y); }
        public readonly Vector4I18F14 ZYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, Y, Z); }
        public readonly Vector4I18F14 ZYYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, Y, W); }
        public readonly Vector4I18F14 ZYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, Z, X); }
        public readonly Vector4I18F14 ZYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, Z, Y); }
        public readonly Vector4I18F14 ZYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, Z, Z); }
        public readonly Vector4I18F14 ZYZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, Z, W); }
        public readonly Vector4I18F14 ZYWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, W, X); }
        public readonly Vector4I18F14 ZYWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, W, Y); }
        public readonly Vector4I18F14 ZYWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, W, Z); }
        public readonly Vector4I18F14 ZYWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Y, W, W); }
        public readonly Vector4I18F14 ZZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, X, X); }
        public readonly Vector4I18F14 ZZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, X, Y); }
        public readonly Vector4I18F14 ZZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, X, Z); }
        public readonly Vector4I18F14 ZZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, X, W); }
        public readonly Vector4I18F14 ZZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, Y, X); }
        public readonly Vector4I18F14 ZZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, Y, Y); }
        public readonly Vector4I18F14 ZZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, Y, Z); }
        public readonly Vector4I18F14 ZZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, Y, W); }
        public readonly Vector4I18F14 ZZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, Z, X); }
        public readonly Vector4I18F14 ZZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, Z, Y); }
        public readonly Vector4I18F14 ZZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, Z, Z); }
        public readonly Vector4I18F14 ZZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, Z, W); }
        public readonly Vector4I18F14 ZZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, W, X); }
        public readonly Vector4I18F14 ZZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, W, Y); }
        public readonly Vector4I18F14 ZZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, W, Z); }
        public readonly Vector4I18F14 ZZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, Z, W, W); }
        public readonly Vector4I18F14 ZWXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, X, X); }
        public readonly Vector4I18F14 ZWXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, X, Y); }
        public readonly Vector4I18F14 ZWXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, X, Z); }
        public readonly Vector4I18F14 ZWXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, X, W); }
        public readonly Vector4I18F14 ZWYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, Y, X); }
        public readonly Vector4I18F14 ZWYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, Y, Y); }
        public readonly Vector4I18F14 ZWYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, Y, Z); }
        public readonly Vector4I18F14 ZWYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, Y, W); }
        public readonly Vector4I18F14 ZWZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, Z, X); }
        public readonly Vector4I18F14 ZWZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, Z, Y); }
        public readonly Vector4I18F14 ZWZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, Z, Z); }
        public readonly Vector4I18F14 ZWZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, Z, W); }
        public readonly Vector4I18F14 ZWWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, W, X); }
        public readonly Vector4I18F14 ZWWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, W, Y); }
        public readonly Vector4I18F14 ZWWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, W, Z); }
        public readonly Vector4I18F14 ZWWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(Z, W, W, W); }
        public readonly Vector4I18F14 WXXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, X, X); }
        public readonly Vector4I18F14 WXXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, X, Y); }
        public readonly Vector4I18F14 WXXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, X, Z); }
        public readonly Vector4I18F14 WXXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, X, W); }
        public readonly Vector4I18F14 WXYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, Y, X); }
        public readonly Vector4I18F14 WXYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, Y, Y); }
        public readonly Vector4I18F14 WXYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, Y, Z); }
        public readonly Vector4I18F14 WXYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, Y, W); }
        public readonly Vector4I18F14 WXZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, Z, X); }
        public readonly Vector4I18F14 WXZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, Z, Y); }
        public readonly Vector4I18F14 WXZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, Z, Z); }
        public readonly Vector4I18F14 WXZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, Z, W); }
        public readonly Vector4I18F14 WXWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, W, X); }
        public readonly Vector4I18F14 WXWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, W, Y); }
        public readonly Vector4I18F14 WXWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, W, Z); }
        public readonly Vector4I18F14 WXWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, X, W, W); }
        public readonly Vector4I18F14 WYXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, X, X); }
        public readonly Vector4I18F14 WYXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, X, Y); }
        public readonly Vector4I18F14 WYXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, X, Z); }
        public readonly Vector4I18F14 WYXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, X, W); }
        public readonly Vector4I18F14 WYYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, Y, X); }
        public readonly Vector4I18F14 WYYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, Y, Y); }
        public readonly Vector4I18F14 WYYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, Y, Z); }
        public readonly Vector4I18F14 WYYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, Y, W); }
        public readonly Vector4I18F14 WYZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, Z, X); }
        public readonly Vector4I18F14 WYZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, Z, Y); }
        public readonly Vector4I18F14 WYZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, Z, Z); }
        public readonly Vector4I18F14 WYZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, Z, W); }
        public readonly Vector4I18F14 WYWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, W, X); }
        public readonly Vector4I18F14 WYWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, W, Y); }
        public readonly Vector4I18F14 WYWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, W, Z); }
        public readonly Vector4I18F14 WYWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Y, W, W); }
        public readonly Vector4I18F14 WZXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, X, X); }
        public readonly Vector4I18F14 WZXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, X, Y); }
        public readonly Vector4I18F14 WZXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, X, Z); }
        public readonly Vector4I18F14 WZXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, X, W); }
        public readonly Vector4I18F14 WZYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, Y, X); }
        public readonly Vector4I18F14 WZYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, Y, Y); }
        public readonly Vector4I18F14 WZYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, Y, Z); }
        public readonly Vector4I18F14 WZYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, Y, W); }
        public readonly Vector4I18F14 WZZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, Z, X); }
        public readonly Vector4I18F14 WZZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, Z, Y); }
        public readonly Vector4I18F14 WZZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, Z, Z); }
        public readonly Vector4I18F14 WZZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, Z, W); }
        public readonly Vector4I18F14 WZWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, W, X); }
        public readonly Vector4I18F14 WZWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, W, Y); }
        public readonly Vector4I18F14 WZWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, W, Z); }
        public readonly Vector4I18F14 WZWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, Z, W, W); }
        public readonly Vector4I18F14 WWXX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, X, X); }
        public readonly Vector4I18F14 WWXY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, X, Y); }
        public readonly Vector4I18F14 WWXZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, X, Z); }
        public readonly Vector4I18F14 WWXW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, X, W); }
        public readonly Vector4I18F14 WWYX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, Y, X); }
        public readonly Vector4I18F14 WWYY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, Y, Y); }
        public readonly Vector4I18F14 WWYZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, Y, Z); }
        public readonly Vector4I18F14 WWYW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, Y, W); }
        public readonly Vector4I18F14 WWZX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, Z, X); }
        public readonly Vector4I18F14 WWZY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, Z, Y); }
        public readonly Vector4I18F14 WWZZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, Z, Z); }
        public readonly Vector4I18F14 WWZW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, Z, W); }
        public readonly Vector4I18F14 WWWX { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, W, X); }
        public readonly Vector4I18F14 WWWY { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, W, Y); }
        public readonly Vector4I18F14 WWWZ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, W, Z); }
        public readonly Vector4I18F14 WWWW { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I18F14(W, W, W, W); }

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector4I18F14 lhs, Vector4I18F14 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector4I18F14 lhs, Vector4I18F14 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector4I18F14 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(X, Y, Z, W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector4I18F14({X}, {Y}, {Z}, {W})";

        // IEquatable<Vector4I18F14>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector4I18F14 other)
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
            return $"Vector4I18F14({x}, {y}, {z}, {w})";
        }
    }
}
