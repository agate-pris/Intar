using AgatePris.Intar.Numerics;
using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar {
    [Serializable]
    public partial struct Matrix3x3I17F15 : IEquatable<Matrix3x3I17F15>, IFormattable {

        // Fields
        // ---------------------------------------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public Vector3I17F15 C0;
        public Vector3I17F15 C1;
        public Vector3I17F15 C2;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix3x3I17F15(Vector3I17F15 c0, Vector3I17F15 c1, Vector3I17F15 c2) {
            C0 = c0;
            C1 = c1;
            C2 = c2;
        }

        // Operators
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Matrix3x3I17F15 lhs, Matrix3x3I17F15 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Matrix3x3I17F15 lhs, Matrix3x3I17F15 rhs) => !(lhs == rhs);

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is Matrix3x3I17F15 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => HashCode.Combine(C0, C1, C2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() {
            var c0 = C0.ToString();
            var c1 = C1.ToString();
            var c2 = C2.ToString();
            return $"Matrix3x3I17F15(C0: {c0}, C1: {c1}, C2: {c2})";
        }

        // IEquatable<Matrix3x3I17F15>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Matrix3x3I17F15 other) =>
            C0 == other.C0 &&
            C1 == other.C1 &&
            C2 == other.C2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            var c0 = C0.ToString(format, formatProvider);
            var c1 = C1.ToString(format, formatProvider);
            var c2 = C2.ToString(format, formatProvider);
            return $"Matrix3x3I17F15(C0: {c0}, C1: {c1}, C2: {c2})";
        }
    }
}
