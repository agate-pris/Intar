using System;
using System.Runtime.CompilerServices;

#if UNITY_5_6_OR_NEWER
using UnityEngine;
#endif

namespace AgatePris.Intar.Fixed {
    [Serializable]

#if !UNITY_5_6_OR_NEWER
    readonly
#endif

    public struct I10F54 : IEquatable<I10F54>, IFormattable {
        // Consts
        // ------

        public const int IntNbits = 10;
        public const int FracNbits = 54;

        const long oneRepr = 1L << FracNbits;

        // Fields
        // ------

#if UNITY_5_6_OR_NEWER
        [SerializeField]
#else
        readonly
#endif

        long bits;

        // Properties
        // ----------

        public readonly long Bits {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => bits;
        }

        // Static readonly properties
        // --------------------------

        public static readonly I10F54 Zero = FromNum(0);
        public static readonly I10F54 One = FromNum(1);

        // Constructors
        // ------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        I10F54(long bits) {
            this.bits = bits;
        }

        // Static methods
        // --------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I10F54 FromBits(long bits) => new I10F54(bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I10F54 FromNum(long num) => FromBits(num * oneRepr);

        // Arithmetic Operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I10F54 operator +(I10F54 left, I10F54 right) {
            return FromBits(left.Bits + right.Bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I10F54 operator -(I10F54 left, I10F54 right) {
            return FromBits(left.Bits - right.Bits);
        }

        // 128 ビット整数型は .NET 7 以降にしか無いので,
        // 乗算, 除算演算子は .NET 7 以降でのみ使用可能.

#if NET7_0_OR_GREATER

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I10F54 operator *(I10F54 left, I10F54 right) {
            Int128 l = left.Bits;
            return FromBits((long)(l * right.Bits / oneRepr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I10F54 operator /(I10F54 left, I10F54 right) {
            Int128 l = left.Bits;
            return FromBits((long)(l * oneRepr / right.Bits));
        }

#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I10F54 operator -(I10F54 x) => FromBits(-x.Bits);

        // Comparison operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(I10F54 lhs, I10F54 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(I10F54 lhs, I10F54 rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(I10F54 left, I10F54 right) => left.Bits < right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(I10F54 left, I10F54 right) => left.Bits > right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(I10F54 left, I10F54 right) => left.Bits <= right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(I10F54 left, I10F54 right) => left.Bits >= right.Bits;

        // Methods
        // -------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I10F54 Min(I10F54 other) => FromBits(System.Math.Min(bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I10F54 Max(I10F54 other) => FromBits(System.Math.Max(bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I10F54 Clamp(I10F54 min, I10F54 max) => FromBits(Math.Clamp(bits, min.Bits, max.Bits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I10F54 Abs() => FromBits(System.Math.Abs(bits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I9F55 LosslessMul(I63F1 other) => I9F55.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I8F56 LosslessMul(I62F2 other) => I8F56.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I7F57 LosslessMul(I61F3 other) => I7F57.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I6F58 LosslessMul(I60F4 other) => I6F58.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I5F59 LosslessMul(I59F5 other) => I5F59.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I4F60 LosslessMul(I58F6 other) => I4F60.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I3F61 LosslessMul(I57F7 other) => I3F61.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I2F62 LosslessMul(I56F8 other) => I2F62.FromBits(bits * other.Bits);

        // Explicit conversion operators
        // -----------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator int(I10F54 x) => (int)(x.bits / oneRepr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator uint(I10F54 x) => (uint)(x.bits / oneRepr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator long(I10F54 x) => x.bits / oneRepr;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator ulong(I10F54 x) => (ulong)(x.bits / oneRepr);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float(I10F54 x) {
            const float k = 1.0f / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double(I10F54 x) {
            const double k = 1.0 / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator decimal(I10F54 x) {
            const decimal k = 1.0M / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I31F1(I10F54 x) => I31F1.FromBits((int)(x.Bits / (1L << 53)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I30F2(I10F54 x) => I30F2.FromBits((int)(x.Bits / (1L << 52)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I29F3(I10F54 x) => I29F3.FromBits((int)(x.Bits / (1L << 51)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I28F4(I10F54 x) => I28F4.FromBits((int)(x.Bits / (1L << 50)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I27F5(I10F54 x) => I27F5.FromBits((int)(x.Bits / (1L << 49)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I26F6(I10F54 x) => I26F6.FromBits((int)(x.Bits / (1L << 48)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I25F7(I10F54 x) => I25F7.FromBits((int)(x.Bits / (1L << 47)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I24F8(I10F54 x) => I24F8.FromBits((int)(x.Bits / (1L << 46)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I23F9(I10F54 x) => I23F9.FromBits((int)(x.Bits / (1L << 45)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I22F10(I10F54 x) => I22F10.FromBits((int)(x.Bits / (1L << 44)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I21F11(I10F54 x) => I21F11.FromBits((int)(x.Bits / (1L << 43)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I20F12(I10F54 x) => I20F12.FromBits((int)(x.Bits / (1L << 42)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I19F13(I10F54 x) => I19F13.FromBits((int)(x.Bits / (1L << 41)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I18F14(I10F54 x) => I18F14.FromBits((int)(x.Bits / (1L << 40)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I17F15(I10F54 x) => I17F15.FromBits((int)(x.Bits / (1L << 39)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I16F16(I10F54 x) => I16F16.FromBits((int)(x.Bits / (1L << 38)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I15F17(I10F54 x) => I15F17.FromBits((int)(x.Bits / (1L << 37)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I14F18(I10F54 x) => I14F18.FromBits((int)(x.Bits / (1L << 36)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I13F19(I10F54 x) => I13F19.FromBits((int)(x.Bits / (1L << 35)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I12F20(I10F54 x) => I12F20.FromBits((int)(x.Bits / (1L << 34)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I11F21(I10F54 x) => I11F21.FromBits((int)(x.Bits / (1L << 33)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I10F22(I10F54 x) => I10F22.FromBits((int)(x.Bits / (1L << 32)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I9F23(I10F54 x) => I9F23.FromBits((int)(x.Bits / (1L << 31)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I8F24(I10F54 x) => I8F24.FromBits((int)(x.Bits / (1L << 30)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I7F25(I10F54 x) => I7F25.FromBits((int)(x.Bits / (1L << 29)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I6F26(I10F54 x) => I6F26.FromBits((int)(x.Bits / (1L << 28)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I5F27(I10F54 x) => I5F27.FromBits((int)(x.Bits / (1L << 27)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I4F28(I10F54 x) => I4F28.FromBits((int)(x.Bits / (1L << 26)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I3F29(I10F54 x) => I3F29.FromBits((int)(x.Bits / (1L << 25)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I2F30(I10F54 x) => I2F30.FromBits((int)(x.Bits / (1L << 24)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U31F1(I10F54 x) => U31F1.FromBits((uint)(x.Bits / (1L << 53)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U30F2(I10F54 x) => U30F2.FromBits((uint)(x.Bits / (1L << 52)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U29F3(I10F54 x) => U29F3.FromBits((uint)(x.Bits / (1L << 51)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U28F4(I10F54 x) => U28F4.FromBits((uint)(x.Bits / (1L << 50)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U27F5(I10F54 x) => U27F5.FromBits((uint)(x.Bits / (1L << 49)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U26F6(I10F54 x) => U26F6.FromBits((uint)(x.Bits / (1L << 48)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U25F7(I10F54 x) => U25F7.FromBits((uint)(x.Bits / (1L << 47)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U24F8(I10F54 x) => U24F8.FromBits((uint)(x.Bits / (1L << 46)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U23F9(I10F54 x) => U23F9.FromBits((uint)(x.Bits / (1L << 45)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U22F10(I10F54 x) => U22F10.FromBits((uint)(x.Bits / (1L << 44)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U21F11(I10F54 x) => U21F11.FromBits((uint)(x.Bits / (1L << 43)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U20F12(I10F54 x) => U20F12.FromBits((uint)(x.Bits / (1L << 42)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U19F13(I10F54 x) => U19F13.FromBits((uint)(x.Bits / (1L << 41)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U18F14(I10F54 x) => U18F14.FromBits((uint)(x.Bits / (1L << 40)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U17F15(I10F54 x) => U17F15.FromBits((uint)(x.Bits / (1L << 39)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U16F16(I10F54 x) => U16F16.FromBits((uint)(x.Bits / (1L << 38)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U15F17(I10F54 x) => U15F17.FromBits((uint)(x.Bits / (1L << 37)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U14F18(I10F54 x) => U14F18.FromBits((uint)(x.Bits / (1L << 36)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U13F19(I10F54 x) => U13F19.FromBits((uint)(x.Bits / (1L << 35)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U12F20(I10F54 x) => U12F20.FromBits((uint)(x.Bits / (1L << 34)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U11F21(I10F54 x) => U11F21.FromBits((uint)(x.Bits / (1L << 33)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U10F22(I10F54 x) => U10F22.FromBits((uint)(x.Bits / (1L << 32)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U9F23(I10F54 x) => U9F23.FromBits((uint)(x.Bits / (1L << 31)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U8F24(I10F54 x) => U8F24.FromBits((uint)(x.Bits / (1L << 30)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U7F25(I10F54 x) => U7F25.FromBits((uint)(x.Bits / (1L << 29)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U6F26(I10F54 x) => U6F26.FromBits((uint)(x.Bits / (1L << 28)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U5F27(I10F54 x) => U5F27.FromBits((uint)(x.Bits / (1L << 27)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U4F28(I10F54 x) => U4F28.FromBits((uint)(x.Bits / (1L << 26)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U3F29(I10F54 x) => U3F29.FromBits((uint)(x.Bits / (1L << 25)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U2F30(I10F54 x) => U2F30.FromBits((uint)(x.Bits / (1L << 24)));

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is I10F54 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => bits.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((double)this).ToString();

        // IEquatable<I10F54>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(I10F54 rhs) => bits == rhs.bits;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            return ((double)this).ToString(format, formatProvider);
        }
    }
}
