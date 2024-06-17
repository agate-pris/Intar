using AgatePris.Intar.Numerics;
using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar {
    [Serializable]
    public partial struct Matrix4x4I17F15 : IEquatable<Matrix4x4I17F15>, IFormattable {

        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public Vector4I17F15 C0;
        public Vector4I17F15 C1;
        public Vector4I17F15 C2;
        public Vector4I17F15 C3;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Constructors
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix4x4I17F15(Vector4I17F15 c0, Vector4I17F15 c1, Vector4I17F15 c2, Vector4I17F15 c3) {
            C0 = c0;
            C1 = c1;
            C2 = c2;
            C3 = c3;
        }

        // Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix4x4I17F15 lhs, Matrix4x4I17F15 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Matrix4x4I17F15 lhs, Matrix4x4I17F15 rhs) => !(lhs == rhs);

        // Methods
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4x4I17F15 SaturatingMul(Matrix4x4I17F15 left, Matrix4x4I17F15 right) {
            return new Matrix4x4I17F15(
                left.C0.SaturatingMul(right.C0.X).SaturatingAdd(left.C1.SaturatingMul(right.C0.Y)).SaturatingAdd(left.C2.SaturatingMul(right.C0.Z)).SaturatingAdd(left.C3.SaturatingMul(right.C0.W)),
                left.C0.SaturatingMul(right.C1.X).SaturatingAdd(left.C1.SaturatingMul(right.C1.Y)).SaturatingAdd(left.C2.SaturatingMul(right.C1.Z)).SaturatingAdd(left.C3.SaturatingMul(right.C1.W)),
                left.C0.SaturatingMul(right.C2.X).SaturatingAdd(left.C1.SaturatingMul(right.C2.Y)).SaturatingAdd(left.C2.SaturatingMul(right.C2.Z)).SaturatingAdd(left.C3.SaturatingMul(right.C2.W)),
                left.C0.SaturatingMul(right.C3.X).SaturatingAdd(left.C1.SaturatingMul(right.C3.Y)).SaturatingAdd(left.C2.SaturatingMul(right.C3.Z)).SaturatingAdd(left.C3.SaturatingMul(right.C3.W)));
        }

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Matrix4x4I17F15 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(C0, C1, C2, C3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() {
            var c0 = C0.ToString();
            var c1 = C1.ToString();
            var c2 = C2.ToString();
            var c3 = C3.ToString();
            return $"Matrix4x4I17F15(C0: {c0}, C1: {c1}, C2: {c2}, C3: {c3})";
        }

        // IEquatable<Matrix4x4I17F15>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Matrix4x4I17F15 other) =>
            C0 == other.C0 &&
            C1 == other.C1 &&
            C2 == other.C2 &&
            C3 == other.C3;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var c0 = C0.ToString(format, formatProvider);
            var c1 = C1.ToString(format, formatProvider);
            var c2 = C2.ToString(format, formatProvider);
            var c3 = C3.ToString(format, formatProvider);
            return $"Matrix4x4I17F15(C0: {c0}, C1: {c1}, C2: {c2}, C3: {c3})";
        }
    }
}
