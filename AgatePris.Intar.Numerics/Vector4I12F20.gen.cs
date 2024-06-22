using AgatePris.Intar.Numerics;
using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Mathematics {
    [Serializable]
    public struct Vector4I12F20 : IEquatable<Vector4I12F20>, IFormattable {
        // Fields
        // ---------------------------------------

        public I12F20 x;
        public I12F20 y;
        public I12F20 z;
        public I12F20 w;

        // Constants
        // ---------------------------------------

        public static readonly Vector4I12F20 zero;

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I12F20(I12F20 x, I12F20 y, I12F20 z, I12F20 w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I12F20(I12F20 x, I12F20 y, Vector2I12F20 zw) {
            this.x = x;
            this.y = y;
            z = zw.x;
            w = zw.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I12F20(I12F20 x, Vector3I12F20 yzw) {
            this.x = x;
            y = yzw.x;
            z = yzw.y;
            w = yzw.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I12F20(Vector2I12F20 xy, Vector2I12F20 zw) {
            x = xy.x;
            y = xy.y;
            z = zw.x;
            w = zw.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I12F20(Vector4I12F20 xyzw) {
            x = xyzw.x;
            y = xyzw.y;
            z = xyzw.z;
            w = xyzw.w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I12F20(I12F20 x, Vector2I12F20 yz, I12F20 w) {
            this.x = x;
            y = yz.x;
            z = yz.y;
            this.w = w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I12F20(Vector3I12F20 xyz, I12F20 w) {
            x = xyz.x;
            y = xyz.y;
            z = xyz.z;
            this.w = w;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector4I12F20(Vector2I12F20 xy, I12F20 z, I12F20 w) {
            x = xy.x;
            y = xy.y;
            this.z = z;
            this.w = w;
        }

        // Arithmetic Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I12F20 operator +(Vector4I12F20 a, Vector4I12F20 b) => new Vector4I12F20(
            a.x + b.x,
            a.y + b.y,
            a.z + b.z,
            a.w + b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I12F20 operator -(Vector4I12F20 a, Vector4I12F20 b) => new Vector4I12F20(
            a.x - b.x,
            a.y - b.y,
            a.z - b.z,
            a.w - b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I12F20 operator *(Vector4I12F20 a, Vector4I12F20 b) => new Vector4I12F20(
            a.x * b.x,
            a.y * b.y,
            a.z * b.z,
            a.w * b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I12F20 operator *(Vector4I12F20 a, I12F20 b) => new Vector4I12F20(
            a.x * b,
            a.y * b,
            a.z * b,
            a.w * b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I12F20 operator *(I12F20 a, Vector4I12F20 b) => new Vector4I12F20(
            a * b.x,
            a * b.y,
            a * b.z,
            a * b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I12F20 operator /(Vector4I12F20 a, Vector4I12F20 b) => new Vector4I12F20(
            a.x / b.x,
            a.y / b.y,
            a.z / b.z,
            a.w / b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I12F20 operator /(Vector4I12F20 a, I12F20 b) => new Vector4I12F20(
            a.x / b,
            a.y / b,
            a.z / b,
            a.w / b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4I12F20 operator /(I12F20 a, Vector4I12F20 b) => new Vector4I12F20(
            a / b.x,
            a / b.y,
            a / b.z,
            a / b.w);

        // Swizzling Properties
        // ---------------------------------------

#pragma warning disable IDE1006 // 命名スタイル

        public readonly Vector2I12F20 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(x, x); }
        public readonly Vector2I12F20 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(x, y); }
        public readonly Vector2I12F20 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(x, z); }
        public readonly Vector2I12F20 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(x, w); }
        public readonly Vector2I12F20 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(y, x); }
        public readonly Vector2I12F20 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(y, y); }
        public readonly Vector2I12F20 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(y, z); }
        public readonly Vector2I12F20 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(y, w); }
        public readonly Vector2I12F20 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(z, x); }
        public readonly Vector2I12F20 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(z, y); }
        public readonly Vector2I12F20 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(z, z); }
        public readonly Vector2I12F20 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(z, w); }
        public readonly Vector2I12F20 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(w, x); }
        public readonly Vector2I12F20 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(w, y); }
        public readonly Vector2I12F20 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(w, z); }
        public readonly Vector2I12F20 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector2I12F20(w, w); }
        public readonly Vector3I12F20 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, x, x); }
        public readonly Vector3I12F20 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, x, y); }
        public readonly Vector3I12F20 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, x, z); }
        public readonly Vector3I12F20 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, x, w); }
        public readonly Vector3I12F20 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, y, x); }
        public readonly Vector3I12F20 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, y, y); }
        public readonly Vector3I12F20 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, y, z); }
        public readonly Vector3I12F20 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, y, w); }
        public readonly Vector3I12F20 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, z, x); }
        public readonly Vector3I12F20 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, z, y); }
        public readonly Vector3I12F20 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, z, z); }
        public readonly Vector3I12F20 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, z, w); }
        public readonly Vector3I12F20 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, w, x); }
        public readonly Vector3I12F20 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, w, y); }
        public readonly Vector3I12F20 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, w, z); }
        public readonly Vector3I12F20 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(x, w, w); }
        public readonly Vector3I12F20 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, x, x); }
        public readonly Vector3I12F20 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, x, y); }
        public readonly Vector3I12F20 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, x, z); }
        public readonly Vector3I12F20 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, x, w); }
        public readonly Vector3I12F20 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, y, x); }
        public readonly Vector3I12F20 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, y, y); }
        public readonly Vector3I12F20 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, y, z); }
        public readonly Vector3I12F20 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, y, w); }
        public readonly Vector3I12F20 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, z, x); }
        public readonly Vector3I12F20 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, z, y); }
        public readonly Vector3I12F20 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, z, z); }
        public readonly Vector3I12F20 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, z, w); }
        public readonly Vector3I12F20 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, w, x); }
        public readonly Vector3I12F20 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, w, y); }
        public readonly Vector3I12F20 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, w, z); }
        public readonly Vector3I12F20 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(y, w, w); }
        public readonly Vector3I12F20 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, x, x); }
        public readonly Vector3I12F20 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, x, y); }
        public readonly Vector3I12F20 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, x, z); }
        public readonly Vector3I12F20 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, x, w); }
        public readonly Vector3I12F20 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, y, x); }
        public readonly Vector3I12F20 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, y, y); }
        public readonly Vector3I12F20 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, y, z); }
        public readonly Vector3I12F20 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, y, w); }
        public readonly Vector3I12F20 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, z, x); }
        public readonly Vector3I12F20 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, z, y); }
        public readonly Vector3I12F20 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, z, z); }
        public readonly Vector3I12F20 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, z, w); }
        public readonly Vector3I12F20 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, w, x); }
        public readonly Vector3I12F20 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, w, y); }
        public readonly Vector3I12F20 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, w, z); }
        public readonly Vector3I12F20 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(z, w, w); }
        public readonly Vector3I12F20 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, x, x); }
        public readonly Vector3I12F20 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, x, y); }
        public readonly Vector3I12F20 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, x, z); }
        public readonly Vector3I12F20 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, x, w); }
        public readonly Vector3I12F20 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, y, x); }
        public readonly Vector3I12F20 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, y, y); }
        public readonly Vector3I12F20 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, y, z); }
        public readonly Vector3I12F20 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, y, w); }
        public readonly Vector3I12F20 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, z, x); }
        public readonly Vector3I12F20 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, z, y); }
        public readonly Vector3I12F20 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, z, z); }
        public readonly Vector3I12F20 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, z, w); }
        public readonly Vector3I12F20 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, w, x); }
        public readonly Vector3I12F20 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, w, y); }
        public readonly Vector3I12F20 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, w, z); }
        public readonly Vector3I12F20 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector3I12F20(w, w, w); }
        public readonly Vector4I12F20 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, x, x); }
        public readonly Vector4I12F20 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, x, y); }
        public readonly Vector4I12F20 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, x, z); }
        public readonly Vector4I12F20 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, x, w); }
        public readonly Vector4I12F20 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, y, x); }
        public readonly Vector4I12F20 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, y, y); }
        public readonly Vector4I12F20 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, y, z); }
        public readonly Vector4I12F20 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, y, w); }
        public readonly Vector4I12F20 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, z, x); }
        public readonly Vector4I12F20 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, z, y); }
        public readonly Vector4I12F20 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, z, z); }
        public readonly Vector4I12F20 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, z, w); }
        public readonly Vector4I12F20 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, w, x); }
        public readonly Vector4I12F20 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, w, y); }
        public readonly Vector4I12F20 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, w, z); }
        public readonly Vector4I12F20 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, x, w, w); }
        public readonly Vector4I12F20 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, x, x); }
        public readonly Vector4I12F20 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, x, y); }
        public readonly Vector4I12F20 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, x, z); }
        public readonly Vector4I12F20 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, x, w); }
        public readonly Vector4I12F20 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, y, x); }
        public readonly Vector4I12F20 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, y, y); }
        public readonly Vector4I12F20 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, y, z); }
        public readonly Vector4I12F20 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, y, w); }
        public readonly Vector4I12F20 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, z, x); }
        public readonly Vector4I12F20 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, z, y); }
        public readonly Vector4I12F20 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, z, z); }
        public readonly Vector4I12F20 xyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, z, w); }
        public readonly Vector4I12F20 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, w, x); }
        public readonly Vector4I12F20 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, w, y); }
        public readonly Vector4I12F20 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, w, z); }
        public readonly Vector4I12F20 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, y, w, w); }
        public readonly Vector4I12F20 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, x, x); }
        public readonly Vector4I12F20 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, x, y); }
        public readonly Vector4I12F20 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, x, z); }
        public readonly Vector4I12F20 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, x, w); }
        public readonly Vector4I12F20 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, y, x); }
        public readonly Vector4I12F20 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, y, y); }
        public readonly Vector4I12F20 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, y, z); }
        public readonly Vector4I12F20 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, y, w); }
        public readonly Vector4I12F20 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, z, x); }
        public readonly Vector4I12F20 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, z, y); }
        public readonly Vector4I12F20 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, z, z); }
        public readonly Vector4I12F20 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, z, w); }
        public readonly Vector4I12F20 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, w, x); }
        public readonly Vector4I12F20 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, w, y); }
        public readonly Vector4I12F20 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, w, z); }
        public readonly Vector4I12F20 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, z, w, w); }
        public readonly Vector4I12F20 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, x, x); }
        public readonly Vector4I12F20 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, x, y); }
        public readonly Vector4I12F20 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, x, z); }
        public readonly Vector4I12F20 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, x, w); }
        public readonly Vector4I12F20 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, y, x); }
        public readonly Vector4I12F20 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, y, y); }
        public readonly Vector4I12F20 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, y, z); }
        public readonly Vector4I12F20 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, y, w); }
        public readonly Vector4I12F20 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, z, x); }
        public readonly Vector4I12F20 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, z, y); }
        public readonly Vector4I12F20 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, z, z); }
        public readonly Vector4I12F20 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, z, w); }
        public readonly Vector4I12F20 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, w, x); }
        public readonly Vector4I12F20 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, w, y); }
        public readonly Vector4I12F20 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, w, z); }
        public readonly Vector4I12F20 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(x, w, w, w); }
        public readonly Vector4I12F20 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, x, x); }
        public readonly Vector4I12F20 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, x, y); }
        public readonly Vector4I12F20 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, x, z); }
        public readonly Vector4I12F20 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, x, w); }
        public readonly Vector4I12F20 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, y, x); }
        public readonly Vector4I12F20 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, y, y); }
        public readonly Vector4I12F20 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, y, z); }
        public readonly Vector4I12F20 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, y, w); }
        public readonly Vector4I12F20 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, z, x); }
        public readonly Vector4I12F20 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, z, y); }
        public readonly Vector4I12F20 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, z, z); }
        public readonly Vector4I12F20 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, z, w); }
        public readonly Vector4I12F20 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, w, x); }
        public readonly Vector4I12F20 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, w, y); }
        public readonly Vector4I12F20 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, w, z); }
        public readonly Vector4I12F20 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, x, w, w); }
        public readonly Vector4I12F20 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, x, x); }
        public readonly Vector4I12F20 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, x, y); }
        public readonly Vector4I12F20 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, x, z); }
        public readonly Vector4I12F20 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, x, w); }
        public readonly Vector4I12F20 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, y, x); }
        public readonly Vector4I12F20 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, y, y); }
        public readonly Vector4I12F20 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, y, z); }
        public readonly Vector4I12F20 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, y, w); }
        public readonly Vector4I12F20 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, z, x); }
        public readonly Vector4I12F20 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, z, y); }
        public readonly Vector4I12F20 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, z, z); }
        public readonly Vector4I12F20 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, z, w); }
        public readonly Vector4I12F20 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, w, x); }
        public readonly Vector4I12F20 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, w, y); }
        public readonly Vector4I12F20 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, w, z); }
        public readonly Vector4I12F20 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, y, w, w); }
        public readonly Vector4I12F20 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, x, x); }
        public readonly Vector4I12F20 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, x, y); }
        public readonly Vector4I12F20 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, x, z); }
        public readonly Vector4I12F20 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, x, w); }
        public readonly Vector4I12F20 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, y, x); }
        public readonly Vector4I12F20 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, y, y); }
        public readonly Vector4I12F20 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, y, z); }
        public readonly Vector4I12F20 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, y, w); }
        public readonly Vector4I12F20 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, z, x); }
        public readonly Vector4I12F20 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, z, y); }
        public readonly Vector4I12F20 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, z, z); }
        public readonly Vector4I12F20 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, z, w); }
        public readonly Vector4I12F20 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, w, x); }
        public readonly Vector4I12F20 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, w, y); }
        public readonly Vector4I12F20 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, w, z); }
        public readonly Vector4I12F20 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, z, w, w); }
        public readonly Vector4I12F20 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, x, x); }
        public readonly Vector4I12F20 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, x, y); }
        public readonly Vector4I12F20 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, x, z); }
        public readonly Vector4I12F20 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, x, w); }
        public readonly Vector4I12F20 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, y, x); }
        public readonly Vector4I12F20 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, y, y); }
        public readonly Vector4I12F20 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, y, z); }
        public readonly Vector4I12F20 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, y, w); }
        public readonly Vector4I12F20 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, z, x); }
        public readonly Vector4I12F20 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, z, y); }
        public readonly Vector4I12F20 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, z, z); }
        public readonly Vector4I12F20 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, z, w); }
        public readonly Vector4I12F20 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, w, x); }
        public readonly Vector4I12F20 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, w, y); }
        public readonly Vector4I12F20 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, w, z); }
        public readonly Vector4I12F20 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(y, w, w, w); }
        public readonly Vector4I12F20 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, x, x); }
        public readonly Vector4I12F20 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, x, y); }
        public readonly Vector4I12F20 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, x, z); }
        public readonly Vector4I12F20 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, x, w); }
        public readonly Vector4I12F20 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, y, x); }
        public readonly Vector4I12F20 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, y, y); }
        public readonly Vector4I12F20 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, y, z); }
        public readonly Vector4I12F20 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, y, w); }
        public readonly Vector4I12F20 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, z, x); }
        public readonly Vector4I12F20 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, z, y); }
        public readonly Vector4I12F20 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, z, z); }
        public readonly Vector4I12F20 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, z, w); }
        public readonly Vector4I12F20 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, w, x); }
        public readonly Vector4I12F20 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, w, y); }
        public readonly Vector4I12F20 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, w, z); }
        public readonly Vector4I12F20 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, x, w, w); }
        public readonly Vector4I12F20 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, x, x); }
        public readonly Vector4I12F20 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, x, y); }
        public readonly Vector4I12F20 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, x, z); }
        public readonly Vector4I12F20 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, x, w); }
        public readonly Vector4I12F20 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, y, x); }
        public readonly Vector4I12F20 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, y, y); }
        public readonly Vector4I12F20 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, y, z); }
        public readonly Vector4I12F20 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, y, w); }
        public readonly Vector4I12F20 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, z, x); }
        public readonly Vector4I12F20 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, z, y); }
        public readonly Vector4I12F20 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, z, z); }
        public readonly Vector4I12F20 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, z, w); }
        public readonly Vector4I12F20 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, w, x); }
        public readonly Vector4I12F20 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, w, y); }
        public readonly Vector4I12F20 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, w, z); }
        public readonly Vector4I12F20 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, y, w, w); }
        public readonly Vector4I12F20 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, x, x); }
        public readonly Vector4I12F20 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, x, y); }
        public readonly Vector4I12F20 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, x, z); }
        public readonly Vector4I12F20 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, x, w); }
        public readonly Vector4I12F20 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, y, x); }
        public readonly Vector4I12F20 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, y, y); }
        public readonly Vector4I12F20 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, y, z); }
        public readonly Vector4I12F20 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, y, w); }
        public readonly Vector4I12F20 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, z, x); }
        public readonly Vector4I12F20 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, z, y); }
        public readonly Vector4I12F20 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, z, z); }
        public readonly Vector4I12F20 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, z, w); }
        public readonly Vector4I12F20 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, w, x); }
        public readonly Vector4I12F20 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, w, y); }
        public readonly Vector4I12F20 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, w, z); }
        public readonly Vector4I12F20 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, z, w, w); }
        public readonly Vector4I12F20 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, x, x); }
        public readonly Vector4I12F20 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, x, y); }
        public readonly Vector4I12F20 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, x, z); }
        public readonly Vector4I12F20 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, x, w); }
        public readonly Vector4I12F20 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, y, x); }
        public readonly Vector4I12F20 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, y, y); }
        public readonly Vector4I12F20 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, y, z); }
        public readonly Vector4I12F20 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, y, w); }
        public readonly Vector4I12F20 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, z, x); }
        public readonly Vector4I12F20 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, z, y); }
        public readonly Vector4I12F20 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, z, z); }
        public readonly Vector4I12F20 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, z, w); }
        public readonly Vector4I12F20 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, w, x); }
        public readonly Vector4I12F20 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, w, y); }
        public readonly Vector4I12F20 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, w, z); }
        public readonly Vector4I12F20 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(z, w, w, w); }
        public readonly Vector4I12F20 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, x, x); }
        public readonly Vector4I12F20 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, x, y); }
        public readonly Vector4I12F20 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, x, z); }
        public readonly Vector4I12F20 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, x, w); }
        public readonly Vector4I12F20 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, y, x); }
        public readonly Vector4I12F20 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, y, y); }
        public readonly Vector4I12F20 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, y, z); }
        public readonly Vector4I12F20 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, y, w); }
        public readonly Vector4I12F20 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, z, x); }
        public readonly Vector4I12F20 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, z, y); }
        public readonly Vector4I12F20 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, z, z); }
        public readonly Vector4I12F20 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, z, w); }
        public readonly Vector4I12F20 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, w, x); }
        public readonly Vector4I12F20 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, w, y); }
        public readonly Vector4I12F20 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, w, z); }
        public readonly Vector4I12F20 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, x, w, w); }
        public readonly Vector4I12F20 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, x, x); }
        public readonly Vector4I12F20 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, x, y); }
        public readonly Vector4I12F20 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, x, z); }
        public readonly Vector4I12F20 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, x, w); }
        public readonly Vector4I12F20 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, y, x); }
        public readonly Vector4I12F20 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, y, y); }
        public readonly Vector4I12F20 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, y, z); }
        public readonly Vector4I12F20 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, y, w); }
        public readonly Vector4I12F20 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, z, x); }
        public readonly Vector4I12F20 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, z, y); }
        public readonly Vector4I12F20 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, z, z); }
        public readonly Vector4I12F20 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, z, w); }
        public readonly Vector4I12F20 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, w, x); }
        public readonly Vector4I12F20 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, w, y); }
        public readonly Vector4I12F20 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, w, z); }
        public readonly Vector4I12F20 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, y, w, w); }
        public readonly Vector4I12F20 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, x, x); }
        public readonly Vector4I12F20 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, x, y); }
        public readonly Vector4I12F20 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, x, z); }
        public readonly Vector4I12F20 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, x, w); }
        public readonly Vector4I12F20 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, y, x); }
        public readonly Vector4I12F20 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, y, y); }
        public readonly Vector4I12F20 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, y, z); }
        public readonly Vector4I12F20 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, y, w); }
        public readonly Vector4I12F20 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, z, x); }
        public readonly Vector4I12F20 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, z, y); }
        public readonly Vector4I12F20 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, z, z); }
        public readonly Vector4I12F20 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, z, w); }
        public readonly Vector4I12F20 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, w, x); }
        public readonly Vector4I12F20 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, w, y); }
        public readonly Vector4I12F20 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, w, z); }
        public readonly Vector4I12F20 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, z, w, w); }
        public readonly Vector4I12F20 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, x, x); }
        public readonly Vector4I12F20 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, x, y); }
        public readonly Vector4I12F20 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, x, z); }
        public readonly Vector4I12F20 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, x, w); }
        public readonly Vector4I12F20 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, y, x); }
        public readonly Vector4I12F20 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, y, y); }
        public readonly Vector4I12F20 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, y, z); }
        public readonly Vector4I12F20 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, y, w); }
        public readonly Vector4I12F20 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, z, x); }
        public readonly Vector4I12F20 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, z, y); }
        public readonly Vector4I12F20 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, z, z); }
        public readonly Vector4I12F20 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, z, w); }
        public readonly Vector4I12F20 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, w, x); }
        public readonly Vector4I12F20 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, w, y); }
        public readonly Vector4I12F20 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, w, z); }
        public readonly Vector4I12F20 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new Vector4I12F20(w, w, w, w); }

#pragma warning restore IDE1006 // 命名スタイル

        // Comparison Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector4I12F20 lhs, Vector4I12F20 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector4I12F20 lhs, Vector4I12F20 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Vector4I12F20 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(x, y, z, w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => $"Vector4I12F20({x}, {y}, {z}, {w})";

        // IEquatable<Vector4I12F20>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Vector4I12F20 other)
            => other.x == x
            && other.y == y
            && other.z == z
            && other.w == w;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var x = this.x.ToString(format, formatProvider);
            var y = this.y.ToString(format, formatProvider);
            var z = this.z.ToString(format, formatProvider);
            var w = this.w.ToString(format, formatProvider);
            return $"Vector4I12F20({x}, {y}, {z}, {w})";
        }
    }
}
