using System;
using System.Runtime.CompilerServices;

#if UNITY_5_6_OR_NEWER
using UnityEngine;
#endif

namespace AgatePris.Intar.Fixed {
    [Serializable]
    public

#if !UNITY_5_6_OR_NEWER
    readonly
#endif

    struct I6F58 : IEquatable<I6F58>, IFormattable {
        // Consts
        // ------

        public const int IntNbits = 6;
        public const int FracNbits = 58;

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

        public static readonly I6F58 Zero = FromNum(0);
        public static readonly I6F58 One = FromNum(1);
        public static readonly I6F58 MinValue = FromBits(long.MinValue);
        public static readonly I6F58 MaxValue = FromBits(long.MaxValue);

        // Constructors
        // ------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        I6F58(long bits) {
            this.bits = bits;
        }

        // Static methods
        // --------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I6F58 FromBits(long bits) => new I6F58(bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I6F58 FromNum(long num) => FromBits(num * oneRepr);

        // Arithmetic Operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I6F58 operator +(I6F58 left, I6F58 right) {
            return FromBits(left.Bits + right.Bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I6F58 operator -(I6F58 left, I6F58 right) {
            return FromBits(left.Bits - right.Bits);
        }

        // 128 ビット整数型は .NET 7 以降にしか無いので,
        // 乗算, 除算演算子は .NET 7 以降でのみ使用可能.

#if NET7_0_OR_GREATER

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I6F58 operator *(I6F58 left, I6F58 right) {
            Int128 l = left.Bits;
            return FromBits((long)(l * right.Bits / oneRepr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I6F58 operator /(I6F58 left, I6F58 right) {
            Int128 l = left.Bits;
            return FromBits((long)(l * oneRepr / right.Bits));
        }

#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I6F58 operator +(I6F58 x) => FromBits(+x.Bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I6F58 operator -(I6F58 x) => FromBits(-x.Bits);

        // Comparison operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(I6F58 lhs, I6F58 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(I6F58 lhs, I6F58 rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(I6F58 left, I6F58 right) => left.Bits < right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(I6F58 left, I6F58 right) => left.Bits > right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(I6F58 left, I6F58 right) => left.Bits <= right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(I6F58 left, I6F58 right) => left.Bits >= right.Bits;

        // Methods
        // -------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I6F58 Min(I6F58 other) => FromBits(System.Math.Min(bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I6F58 Max(I6F58 other) => FromBits(System.Math.Max(bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I6F58 Clamp(I6F58 min, I6F58 max) => FromBits(Math.Clamp(bits, min.Bits, max.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I6F58 Abs() => FromBits(System.Math.Abs(bits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I6F58 LosslessMul(long other) => FromBits(bits * other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I5F59 LosslessMul(I63F1 other) => I5F59.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I4F60 LosslessMul(I62F2 other) => I4F60.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I3F61 LosslessMul(I61F3 other) => I3F61.FromBits(bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public I2F62 LosslessMul(I60F4 other) => I2F62.FromBits(bits * other.Bits);

        // Conversion operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator int(I6F58 x) => (int)(x.bits / oneRepr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator uint(I6F58 x) => (uint)(x.bits / oneRepr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator long(I6F58 x) => x.bits / oneRepr;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator ulong(I6F58 x) => (ulong)(x.bits / oneRepr);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float(I6F58 x) {
            const float k = 1.0f / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double(I6F58 x) {
            const double k = 1.0 / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator decimal(I6F58 x) {
            const decimal k = 1.0M / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I31F1(I6F58 x) => I31F1.FromBits((int)(x.Bits / (1L << 57)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I30F2(I6F58 x) => I30F2.FromBits((int)(x.Bits / (1L << 56)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I29F3(I6F58 x) => I29F3.FromBits((int)(x.Bits / (1L << 55)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I28F4(I6F58 x) => I28F4.FromBits((int)(x.Bits / (1L << 54)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I27F5(I6F58 x) => I27F5.FromBits((int)(x.Bits / (1L << 53)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I26F6(I6F58 x) => I26F6.FromBits((int)(x.Bits / (1L << 52)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I25F7(I6F58 x) => I25F7.FromBits((int)(x.Bits / (1L << 51)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I24F8(I6F58 x) => I24F8.FromBits((int)(x.Bits / (1L << 50)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I23F9(I6F58 x) => I23F9.FromBits((int)(x.Bits / (1L << 49)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I22F10(I6F58 x) => I22F10.FromBits((int)(x.Bits / (1L << 48)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I21F11(I6F58 x) => I21F11.FromBits((int)(x.Bits / (1L << 47)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I20F12(I6F58 x) => I20F12.FromBits((int)(x.Bits / (1L << 46)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I19F13(I6F58 x) => I19F13.FromBits((int)(x.Bits / (1L << 45)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I18F14(I6F58 x) => I18F14.FromBits((int)(x.Bits / (1L << 44)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I17F15(I6F58 x) => I17F15.FromBits((int)(x.Bits / (1L << 43)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I16F16(I6F58 x) => I16F16.FromBits((int)(x.Bits / (1L << 42)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I15F17(I6F58 x) => I15F17.FromBits((int)(x.Bits / (1L << 41)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I14F18(I6F58 x) => I14F18.FromBits((int)(x.Bits / (1L << 40)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I13F19(I6F58 x) => I13F19.FromBits((int)(x.Bits / (1L << 39)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I12F20(I6F58 x) => I12F20.FromBits((int)(x.Bits / (1L << 38)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I11F21(I6F58 x) => I11F21.FromBits((int)(x.Bits / (1L << 37)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I10F22(I6F58 x) => I10F22.FromBits((int)(x.Bits / (1L << 36)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I9F23(I6F58 x) => I9F23.FromBits((int)(x.Bits / (1L << 35)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I8F24(I6F58 x) => I8F24.FromBits((int)(x.Bits / (1L << 34)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I7F25(I6F58 x) => I7F25.FromBits((int)(x.Bits / (1L << 33)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I6F26(I6F58 x) => I6F26.FromBits((int)(x.Bits / (1L << 32)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I5F27(I6F58 x) => I5F27.FromBits((int)(x.Bits / (1L << 31)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I4F28(I6F58 x) => I4F28.FromBits((int)(x.Bits / (1L << 30)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I3F29(I6F58 x) => I3F29.FromBits((int)(x.Bits / (1L << 29)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I2F30(I6F58 x) => I2F30.FromBits((int)(x.Bits / (1L << 28)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U31F1(I6F58 x) => U31F1.FromBits((uint)(x.Bits / (1L << 57)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U30F2(I6F58 x) => U30F2.FromBits((uint)(x.Bits / (1L << 56)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U29F3(I6F58 x) => U29F3.FromBits((uint)(x.Bits / (1L << 55)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U28F4(I6F58 x) => U28F4.FromBits((uint)(x.Bits / (1L << 54)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U27F5(I6F58 x) => U27F5.FromBits((uint)(x.Bits / (1L << 53)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U26F6(I6F58 x) => U26F6.FromBits((uint)(x.Bits / (1L << 52)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U25F7(I6F58 x) => U25F7.FromBits((uint)(x.Bits / (1L << 51)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U24F8(I6F58 x) => U24F8.FromBits((uint)(x.Bits / (1L << 50)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U23F9(I6F58 x) => U23F9.FromBits((uint)(x.Bits / (1L << 49)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U22F10(I6F58 x) => U22F10.FromBits((uint)(x.Bits / (1L << 48)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U21F11(I6F58 x) => U21F11.FromBits((uint)(x.Bits / (1L << 47)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U20F12(I6F58 x) => U20F12.FromBits((uint)(x.Bits / (1L << 46)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U19F13(I6F58 x) => U19F13.FromBits((uint)(x.Bits / (1L << 45)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U18F14(I6F58 x) => U18F14.FromBits((uint)(x.Bits / (1L << 44)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U17F15(I6F58 x) => U17F15.FromBits((uint)(x.Bits / (1L << 43)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U16F16(I6F58 x) => U16F16.FromBits((uint)(x.Bits / (1L << 42)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U15F17(I6F58 x) => U15F17.FromBits((uint)(x.Bits / (1L << 41)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U14F18(I6F58 x) => U14F18.FromBits((uint)(x.Bits / (1L << 40)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U13F19(I6F58 x) => U13F19.FromBits((uint)(x.Bits / (1L << 39)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U12F20(I6F58 x) => U12F20.FromBits((uint)(x.Bits / (1L << 38)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U11F21(I6F58 x) => U11F21.FromBits((uint)(x.Bits / (1L << 37)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U10F22(I6F58 x) => U10F22.FromBits((uint)(x.Bits / (1L << 36)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U9F23(I6F58 x) => U9F23.FromBits((uint)(x.Bits / (1L << 35)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U8F24(I6F58 x) => U8F24.FromBits((uint)(x.Bits / (1L << 34)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U7F25(I6F58 x) => U7F25.FromBits((uint)(x.Bits / (1L << 33)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U6F26(I6F58 x) => U6F26.FromBits((uint)(x.Bits / (1L << 32)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U5F27(I6F58 x) => U5F27.FromBits((uint)(x.Bits / (1L << 31)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U4F28(I6F58 x) => U4F28.FromBits((uint)(x.Bits / (1L << 30)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U3F29(I6F58 x) => U3F29.FromBits((uint)(x.Bits / (1L << 29)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U2F30(I6F58 x) => U2F30.FromBits((uint)(x.Bits / (1L << 28)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I63F1(I6F58 x) => I63F1.FromBits(x.Bits / (1L << 57));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I62F2(I6F58 x) => I62F2.FromBits(x.Bits / (1L << 56));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I61F3(I6F58 x) => I61F3.FromBits(x.Bits / (1L << 55));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I60F4(I6F58 x) => I60F4.FromBits(x.Bits / (1L << 54));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I59F5(I6F58 x) => I59F5.FromBits(x.Bits / (1L << 53));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I58F6(I6F58 x) => I58F6.FromBits(x.Bits / (1L << 52));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I57F7(I6F58 x) => I57F7.FromBits(x.Bits / (1L << 51));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I56F8(I6F58 x) => I56F8.FromBits(x.Bits / (1L << 50));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I55F9(I6F58 x) => I55F9.FromBits(x.Bits / (1L << 49));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I54F10(I6F58 x) => I54F10.FromBits(x.Bits / (1L << 48));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I53F11(I6F58 x) => I53F11.FromBits(x.Bits / (1L << 47));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I52F12(I6F58 x) => I52F12.FromBits(x.Bits / (1L << 46));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I51F13(I6F58 x) => I51F13.FromBits(x.Bits / (1L << 45));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I50F14(I6F58 x) => I50F14.FromBits(x.Bits / (1L << 44));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I49F15(I6F58 x) => I49F15.FromBits(x.Bits / (1L << 43));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I48F16(I6F58 x) => I48F16.FromBits(x.Bits / (1L << 42));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I47F17(I6F58 x) => I47F17.FromBits(x.Bits / (1L << 41));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I46F18(I6F58 x) => I46F18.FromBits(x.Bits / (1L << 40));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I45F19(I6F58 x) => I45F19.FromBits(x.Bits / (1L << 39));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I44F20(I6F58 x) => I44F20.FromBits(x.Bits / (1L << 38));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I43F21(I6F58 x) => I43F21.FromBits(x.Bits / (1L << 37));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I42F22(I6F58 x) => I42F22.FromBits(x.Bits / (1L << 36));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I41F23(I6F58 x) => I41F23.FromBits(x.Bits / (1L << 35));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I40F24(I6F58 x) => I40F24.FromBits(x.Bits / (1L << 34));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I39F25(I6F58 x) => I39F25.FromBits(x.Bits / (1L << 33));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I38F26(I6F58 x) => I38F26.FromBits(x.Bits / (1L << 32));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I37F27(I6F58 x) => I37F27.FromBits(x.Bits / (1L << 31));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I36F28(I6F58 x) => I36F28.FromBits(x.Bits / (1L << 30));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I35F29(I6F58 x) => I35F29.FromBits(x.Bits / (1L << 29));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I34F30(I6F58 x) => I34F30.FromBits(x.Bits / (1L << 28));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I33F31(I6F58 x) => I33F31.FromBits(x.Bits / (1L << 27));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I32F32(I6F58 x) => I32F32.FromBits(x.Bits / (1L << 26));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I31F33(I6F58 x) => I31F33.FromBits(x.Bits / (1L << 25));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I30F34(I6F58 x) => I30F34.FromBits(x.Bits / (1L << 24));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I29F35(I6F58 x) => I29F35.FromBits(x.Bits / (1L << 23));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I28F36(I6F58 x) => I28F36.FromBits(x.Bits / (1L << 22));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I27F37(I6F58 x) => I27F37.FromBits(x.Bits / (1L << 21));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I26F38(I6F58 x) => I26F38.FromBits(x.Bits / (1L << 20));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I25F39(I6F58 x) => I25F39.FromBits(x.Bits / (1L << 19));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I24F40(I6F58 x) => I24F40.FromBits(x.Bits / (1L << 18));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I23F41(I6F58 x) => I23F41.FromBits(x.Bits / (1L << 17));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I22F42(I6F58 x) => I22F42.FromBits(x.Bits / (1L << 16));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I21F43(I6F58 x) => I21F43.FromBits(x.Bits / (1L << 15));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I20F44(I6F58 x) => I20F44.FromBits(x.Bits / (1L << 14));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I19F45(I6F58 x) => I19F45.FromBits(x.Bits / (1L << 13));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I18F46(I6F58 x) => I18F46.FromBits(x.Bits / (1L << 12));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I17F47(I6F58 x) => I17F47.FromBits(x.Bits / (1L << 11));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I16F48(I6F58 x) => I16F48.FromBits(x.Bits / (1L << 10));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I15F49(I6F58 x) => I15F49.FromBits(x.Bits / (1L << 9));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I14F50(I6F58 x) => I14F50.FromBits(x.Bits / (1L << 8));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I13F51(I6F58 x) => I13F51.FromBits(x.Bits / (1L << 7));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I12F52(I6F58 x) => I12F52.FromBits(x.Bits / (1L << 6));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I11F53(I6F58 x) => I11F53.FromBits(x.Bits / (1L << 5));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I10F54(I6F58 x) => I10F54.FromBits(x.Bits / (1L << 4));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I9F55(I6F58 x) => I9F55.FromBits(x.Bits / (1L << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I8F56(I6F58 x) => I8F56.FromBits(x.Bits / (1L << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I7F57(I6F58 x) => I7F57.FromBits(x.Bits / (1L << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I5F59(I6F58 x) => I5F59.FromBits(x.Bits * (1L << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I4F60(I6F58 x) => I4F60.FromBits(x.Bits * (1L << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I3F61(I6F58 x) => I3F61.FromBits(x.Bits * (1L << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I2F62(I6F58 x) => I2F62.FromBits(x.Bits * (1L << 4));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U63F1(I6F58 x) => U63F1.FromBits((ulong)(x.Bits / (1L << 57)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U62F2(I6F58 x) => U62F2.FromBits((ulong)(x.Bits / (1L << 56)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U61F3(I6F58 x) => U61F3.FromBits((ulong)(x.Bits / (1L << 55)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U60F4(I6F58 x) => U60F4.FromBits((ulong)(x.Bits / (1L << 54)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U59F5(I6F58 x) => U59F5.FromBits((ulong)(x.Bits / (1L << 53)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U58F6(I6F58 x) => U58F6.FromBits((ulong)(x.Bits / (1L << 52)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U57F7(I6F58 x) => U57F7.FromBits((ulong)(x.Bits / (1L << 51)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U56F8(I6F58 x) => U56F8.FromBits((ulong)(x.Bits / (1L << 50)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U55F9(I6F58 x) => U55F9.FromBits((ulong)(x.Bits / (1L << 49)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U54F10(I6F58 x) => U54F10.FromBits((ulong)(x.Bits / (1L << 48)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U53F11(I6F58 x) => U53F11.FromBits((ulong)(x.Bits / (1L << 47)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U52F12(I6F58 x) => U52F12.FromBits((ulong)(x.Bits / (1L << 46)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U51F13(I6F58 x) => U51F13.FromBits((ulong)(x.Bits / (1L << 45)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U50F14(I6F58 x) => U50F14.FromBits((ulong)(x.Bits / (1L << 44)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U49F15(I6F58 x) => U49F15.FromBits((ulong)(x.Bits / (1L << 43)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U48F16(I6F58 x) => U48F16.FromBits((ulong)(x.Bits / (1L << 42)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U47F17(I6F58 x) => U47F17.FromBits((ulong)(x.Bits / (1L << 41)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U46F18(I6F58 x) => U46F18.FromBits((ulong)(x.Bits / (1L << 40)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U45F19(I6F58 x) => U45F19.FromBits((ulong)(x.Bits / (1L << 39)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U44F20(I6F58 x) => U44F20.FromBits((ulong)(x.Bits / (1L << 38)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U43F21(I6F58 x) => U43F21.FromBits((ulong)(x.Bits / (1L << 37)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U42F22(I6F58 x) => U42F22.FromBits((ulong)(x.Bits / (1L << 36)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U41F23(I6F58 x) => U41F23.FromBits((ulong)(x.Bits / (1L << 35)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U40F24(I6F58 x) => U40F24.FromBits((ulong)(x.Bits / (1L << 34)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U39F25(I6F58 x) => U39F25.FromBits((ulong)(x.Bits / (1L << 33)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U38F26(I6F58 x) => U38F26.FromBits((ulong)(x.Bits / (1L << 32)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U37F27(I6F58 x) => U37F27.FromBits((ulong)(x.Bits / (1L << 31)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U36F28(I6F58 x) => U36F28.FromBits((ulong)(x.Bits / (1L << 30)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U35F29(I6F58 x) => U35F29.FromBits((ulong)(x.Bits / (1L << 29)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U34F30(I6F58 x) => U34F30.FromBits((ulong)(x.Bits / (1L << 28)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U33F31(I6F58 x) => U33F31.FromBits((ulong)(x.Bits / (1L << 27)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U32F32(I6F58 x) => U32F32.FromBits((ulong)(x.Bits / (1L << 26)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U31F33(I6F58 x) => U31F33.FromBits((ulong)(x.Bits / (1L << 25)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U30F34(I6F58 x) => U30F34.FromBits((ulong)(x.Bits / (1L << 24)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U29F35(I6F58 x) => U29F35.FromBits((ulong)(x.Bits / (1L << 23)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U28F36(I6F58 x) => U28F36.FromBits((ulong)(x.Bits / (1L << 22)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U27F37(I6F58 x) => U27F37.FromBits((ulong)(x.Bits / (1L << 21)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U26F38(I6F58 x) => U26F38.FromBits((ulong)(x.Bits / (1L << 20)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U25F39(I6F58 x) => U25F39.FromBits((ulong)(x.Bits / (1L << 19)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U24F40(I6F58 x) => U24F40.FromBits((ulong)(x.Bits / (1L << 18)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U23F41(I6F58 x) => U23F41.FromBits((ulong)(x.Bits / (1L << 17)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U22F42(I6F58 x) => U22F42.FromBits((ulong)(x.Bits / (1L << 16)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U21F43(I6F58 x) => U21F43.FromBits((ulong)(x.Bits / (1L << 15)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U20F44(I6F58 x) => U20F44.FromBits((ulong)(x.Bits / (1L << 14)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U19F45(I6F58 x) => U19F45.FromBits((ulong)(x.Bits / (1L << 13)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U18F46(I6F58 x) => U18F46.FromBits((ulong)(x.Bits / (1L << 12)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U17F47(I6F58 x) => U17F47.FromBits((ulong)(x.Bits / (1L << 11)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U16F48(I6F58 x) => U16F48.FromBits((ulong)(x.Bits / (1L << 10)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U15F49(I6F58 x) => U15F49.FromBits((ulong)(x.Bits / (1L << 9)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U14F50(I6F58 x) => U14F50.FromBits((ulong)(x.Bits / (1L << 8)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U13F51(I6F58 x) => U13F51.FromBits((ulong)(x.Bits / (1L << 7)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U12F52(I6F58 x) => U12F52.FromBits((ulong)(x.Bits / (1L << 6)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U11F53(I6F58 x) => U11F53.FromBits((ulong)(x.Bits / (1L << 5)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U10F54(I6F58 x) => U10F54.FromBits((ulong)(x.Bits / (1L << 4)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U9F55(I6F58 x) => U9F55.FromBits((ulong)(x.Bits / (1L << 3)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U8F56(I6F58 x) => U8F56.FromBits((ulong)(x.Bits / (1L << 2)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U7F57(I6F58 x) => U7F57.FromBits((ulong)(x.Bits / (1L << 1)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U6F58(I6F58 x) => U6F58.FromBits((ulong)x.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U5F59(I6F58 x) => U5F59.FromBits((ulong)x.Bits * (1UL << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U4F60(I6F58 x) => U4F60.FromBits((ulong)x.Bits * (1UL << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U3F61(I6F58 x) => U3F61.FromBits((ulong)x.Bits * (1UL << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U2F62(I6F58 x) => U2F62.FromBits((ulong)x.Bits * (1UL << 4));

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is I6F58 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => bits.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((double)this).ToString((IFormatProvider)null);

        // IEquatable<I6F58>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(I6F58 other) => bits == other.bits;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            return ((double)this).ToString(format, formatProvider);
        }
    }
}