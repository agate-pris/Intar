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

    struct U2F30 : IEquatable<U2F30>, IFormattable {
        // Consts
        // ------

        public const int IntNbits = 2;
        public const int FracNbits = 30;

        const uint oneRepr = 1U << FracNbits;

        // Fields
        // ------

#if UNITY_5_6_OR_NEWER
        [SerializeField]
#else
        readonly
#endif

        uint bits;

        // Properties
        // ----------

        public readonly uint Bits {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => bits;
        }

        // Static readonly properties
        // --------------------------

        public static readonly U2F30 Zero = FromNum(0);
        public static readonly U2F30 One = FromNum(1);
        public static readonly U2F30 MinValue = FromBits(uint.MinValue);
        public static readonly U2F30 MaxValue = FromBits(uint.MaxValue);

        // Constructors
        // ------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        U2F30(uint bits) {
            this.bits = bits;
        }

        // Static methods
        // --------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U2F30 FromBits(uint bits) => new U2F30(bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U2F30 FromNum(uint num) => FromBits(num * oneRepr);

        // Arithmetic Operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U2F30 operator +(U2F30 left, U2F30 right) {
            return FromBits(left.Bits + right.Bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U2F30 operator -(U2F30 left, U2F30 right) {
            return FromBits(left.Bits - right.Bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U2F30 operator *(U2F30 left, U2F30 right) {
            ulong l = left.Bits;
            return FromBits((uint)(l * right.Bits / oneRepr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U2F30 operator /(U2F30 left, U2F30 right) {
            ulong l = left.Bits;
            return FromBits((uint)(l * oneRepr / right.Bits));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static U2F30 operator +(U2F30 x) => FromBits(+x.Bits);

        // Comparison operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(U2F30 lhs, U2F30 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(U2F30 lhs, U2F30 rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(U2F30 left, U2F30 right) => left.Bits < right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(U2F30 left, U2F30 right) => left.Bits > right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(U2F30 left, U2F30 right) => left.Bits <= right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(U2F30 left, U2F30 right) => left.Bits >= right.Bits;

        // Methods
        // -------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U2F30 Min(U2F30 other) => FromBits(System.Math.Min(bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U2F30 Max(U2F30 other) => FromBits(System.Math.Max(bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U2F30 Clamp(U2F30 min, U2F30 max) => FromBits(Math.Clamp(bits, min.Bits, max.Bits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U2F30 LosslessMul(uint other) => FromBits(bits * other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U34F30 WideningMul(uint other) => U34F30.FromBits((ulong)bits * other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U33F31 WideningMul(U31F1 other) => U33F31.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U32F32 WideningMul(U30F2 other) => U32F32.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U31F33 WideningMul(U29F3 other) => U31F33.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U30F34 WideningMul(U28F4 other) => U30F34.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U29F35 WideningMul(U27F5 other) => U29F35.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U28F36 WideningMul(U26F6 other) => U28F36.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U27F37 WideningMul(U25F7 other) => U27F37.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U26F38 WideningMul(U24F8 other) => U26F38.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U25F39 WideningMul(U23F9 other) => U25F39.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U24F40 WideningMul(U22F10 other) => U24F40.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U23F41 WideningMul(U21F11 other) => U23F41.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U22F42 WideningMul(U20F12 other) => U22F42.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U21F43 WideningMul(U19F13 other) => U21F43.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U20F44 WideningMul(U18F14 other) => U20F44.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U19F45 WideningMul(U17F15 other) => U19F45.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U18F46 WideningMul(U16F16 other) => U18F46.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U17F47 WideningMul(U15F17 other) => U17F47.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U16F48 WideningMul(U14F18 other) => U16F48.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U15F49 WideningMul(U13F19 other) => U15F49.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U14F50 WideningMul(U12F20 other) => U14F50.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U13F51 WideningMul(U11F21 other) => U13F51.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U12F52 WideningMul(U10F22 other) => U12F52.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U11F53 WideningMul(U9F23 other) => U11F53.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U10F54 WideningMul(U8F24 other) => U10F54.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U9F55 WideningMul(U7F25 other) => U9F55.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U8F56 WideningMul(U6F26 other) => U8F56.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U7F57 WideningMul(U5F27 other) => U7F57.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U6F58 WideningMul(U4F28 other) => U6F58.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U5F59 WideningMul(U3F29 other) => U5F59.FromBits((ulong)bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public U4F60 WideningMul(U2F30 other) => U4F60.FromBits((ulong)bits * other.Bits);

        // Implicit conversion operators
        // -----------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U34F30(U2F30 x) => U34F30.FromBits(x.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U33F31(U2F30 x) => U33F31.FromBits((ulong)x.Bits << 1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U32F32(U2F30 x) => U32F32.FromBits((ulong)x.Bits << 2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U31F33(U2F30 x) => U31F33.FromBits((ulong)x.Bits << 3);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U30F34(U2F30 x) => U30F34.FromBits((ulong)x.Bits << 4);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U29F35(U2F30 x) => U29F35.FromBits((ulong)x.Bits << 5);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U28F36(U2F30 x) => U28F36.FromBits((ulong)x.Bits << 6);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U27F37(U2F30 x) => U27F37.FromBits((ulong)x.Bits << 7);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U26F38(U2F30 x) => U26F38.FromBits((ulong)x.Bits << 8);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U25F39(U2F30 x) => U25F39.FromBits((ulong)x.Bits << 9);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U24F40(U2F30 x) => U24F40.FromBits((ulong)x.Bits << 10);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U23F41(U2F30 x) => U23F41.FromBits((ulong)x.Bits << 11);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U22F42(U2F30 x) => U22F42.FromBits((ulong)x.Bits << 12);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U21F43(U2F30 x) => U21F43.FromBits((ulong)x.Bits << 13);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U20F44(U2F30 x) => U20F44.FromBits((ulong)x.Bits << 14);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U19F45(U2F30 x) => U19F45.FromBits((ulong)x.Bits << 15);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U18F46(U2F30 x) => U18F46.FromBits((ulong)x.Bits << 16);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U17F47(U2F30 x) => U17F47.FromBits((ulong)x.Bits << 17);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U16F48(U2F30 x) => U16F48.FromBits((ulong)x.Bits << 18);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U15F49(U2F30 x) => U15F49.FromBits((ulong)x.Bits << 19);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U14F50(U2F30 x) => U14F50.FromBits((ulong)x.Bits << 20);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U13F51(U2F30 x) => U13F51.FromBits((ulong)x.Bits << 21);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U12F52(U2F30 x) => U12F52.FromBits((ulong)x.Bits << 22);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U11F53(U2F30 x) => U11F53.FromBits((ulong)x.Bits << 23);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U10F54(U2F30 x) => U10F54.FromBits((ulong)x.Bits << 24);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U9F55(U2F30 x) => U9F55.FromBits((ulong)x.Bits << 25);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U8F56(U2F30 x) => U8F56.FromBits((ulong)x.Bits << 26);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U7F57(U2F30 x) => U7F57.FromBits((ulong)x.Bits << 27);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U6F58(U2F30 x) => U6F58.FromBits((ulong)x.Bits << 28);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U5F59(U2F30 x) => U5F59.FromBits((ulong)x.Bits << 29);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U4F60(U2F30 x) => U4F60.FromBits((ulong)x.Bits << 30);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U3F61(U2F30 x) => U3F61.FromBits((ulong)x.Bits << 31);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator U2F62(U2F30 x) => U2F62.FromBits((ulong)x.Bits << 32);

        // Explicit conversion operators
        // -----------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator int(U2F30 x) => (int)(x.bits / oneRepr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator uint(U2F30 x) => x.bits / oneRepr;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator long(U2F30 x) => x.bits / oneRepr;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator ulong(U2F30 x) => x.bits / oneRepr;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float(U2F30 x) {
            const float k = 1.0f / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double(U2F30 x) {
            const double k = 1.0 / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator decimal(U2F30 x) {
            const decimal k = 1.0M / oneRepr;
            return k * x.bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I31F1(U2F30 x) => I31F1.FromBits((int)(x.Bits / (1U << 29)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I30F2(U2F30 x) => I30F2.FromBits((int)(x.Bits / (1U << 28)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I29F3(U2F30 x) => I29F3.FromBits((int)(x.Bits / (1U << 27)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I28F4(U2F30 x) => I28F4.FromBits((int)(x.Bits / (1U << 26)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I27F5(U2F30 x) => I27F5.FromBits((int)(x.Bits / (1U << 25)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I26F6(U2F30 x) => I26F6.FromBits((int)(x.Bits / (1U << 24)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I25F7(U2F30 x) => I25F7.FromBits((int)(x.Bits / (1U << 23)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I24F8(U2F30 x) => I24F8.FromBits((int)(x.Bits / (1U << 22)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I23F9(U2F30 x) => I23F9.FromBits((int)(x.Bits / (1U << 21)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I22F10(U2F30 x) => I22F10.FromBits((int)(x.Bits / (1U << 20)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I21F11(U2F30 x) => I21F11.FromBits((int)(x.Bits / (1U << 19)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I20F12(U2F30 x) => I20F12.FromBits((int)(x.Bits / (1U << 18)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I19F13(U2F30 x) => I19F13.FromBits((int)(x.Bits / (1U << 17)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I18F14(U2F30 x) => I18F14.FromBits((int)(x.Bits / (1U << 16)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I17F15(U2F30 x) => I17F15.FromBits((int)(x.Bits / (1U << 15)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I16F16(U2F30 x) => I16F16.FromBits((int)(x.Bits / (1U << 14)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I15F17(U2F30 x) => I15F17.FromBits((int)(x.Bits / (1U << 13)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I14F18(U2F30 x) => I14F18.FromBits((int)(x.Bits / (1U << 12)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I13F19(U2F30 x) => I13F19.FromBits((int)(x.Bits / (1U << 11)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I12F20(U2F30 x) => I12F20.FromBits((int)(x.Bits / (1U << 10)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I11F21(U2F30 x) => I11F21.FromBits((int)(x.Bits / (1U << 9)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I10F22(U2F30 x) => I10F22.FromBits((int)(x.Bits / (1U << 8)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I9F23(U2F30 x) => I9F23.FromBits((int)(x.Bits / (1U << 7)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I8F24(U2F30 x) => I8F24.FromBits((int)(x.Bits / (1U << 6)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I7F25(U2F30 x) => I7F25.FromBits((int)(x.Bits / (1U << 5)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I6F26(U2F30 x) => I6F26.FromBits((int)(x.Bits / (1U << 4)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I5F27(U2F30 x) => I5F27.FromBits((int)(x.Bits / (1U << 3)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I4F28(U2F30 x) => I4F28.FromBits((int)(x.Bits / (1U << 2)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I3F29(U2F30 x) => I3F29.FromBits((int)(x.Bits / (1U << 1)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U31F1(U2F30 x) => U31F1.FromBits(x.Bits / (1U << 29));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U30F2(U2F30 x) => U30F2.FromBits(x.Bits / (1U << 28));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U29F3(U2F30 x) => U29F3.FromBits(x.Bits / (1U << 27));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U28F4(U2F30 x) => U28F4.FromBits(x.Bits / (1U << 26));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U27F5(U2F30 x) => U27F5.FromBits(x.Bits / (1U << 25));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U26F6(U2F30 x) => U26F6.FromBits(x.Bits / (1U << 24));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U25F7(U2F30 x) => U25F7.FromBits(x.Bits / (1U << 23));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U24F8(U2F30 x) => U24F8.FromBits(x.Bits / (1U << 22));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U23F9(U2F30 x) => U23F9.FromBits(x.Bits / (1U << 21));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U22F10(U2F30 x) => U22F10.FromBits(x.Bits / (1U << 20));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U21F11(U2F30 x) => U21F11.FromBits(x.Bits / (1U << 19));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U20F12(U2F30 x) => U20F12.FromBits(x.Bits / (1U << 18));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U19F13(U2F30 x) => U19F13.FromBits(x.Bits / (1U << 17));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U18F14(U2F30 x) => U18F14.FromBits(x.Bits / (1U << 16));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U17F15(U2F30 x) => U17F15.FromBits(x.Bits / (1U << 15));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U16F16(U2F30 x) => U16F16.FromBits(x.Bits / (1U << 14));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U15F17(U2F30 x) => U15F17.FromBits(x.Bits / (1U << 13));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U14F18(U2F30 x) => U14F18.FromBits(x.Bits / (1U << 12));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U13F19(U2F30 x) => U13F19.FromBits(x.Bits / (1U << 11));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U12F20(U2F30 x) => U12F20.FromBits(x.Bits / (1U << 10));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U11F21(U2F30 x) => U11F21.FromBits(x.Bits / (1U << 9));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U10F22(U2F30 x) => U10F22.FromBits(x.Bits / (1U << 8));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U9F23(U2F30 x) => U9F23.FromBits(x.Bits / (1U << 7));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U8F24(U2F30 x) => U8F24.FromBits(x.Bits / (1U << 6));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U7F25(U2F30 x) => U7F25.FromBits(x.Bits / (1U << 5));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U6F26(U2F30 x) => U6F26.FromBits(x.Bits / (1U << 4));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U5F27(U2F30 x) => U5F27.FromBits(x.Bits / (1U << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U4F28(U2F30 x) => U4F28.FromBits(x.Bits / (1U << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U3F29(U2F30 x) => U3F29.FromBits(x.Bits / (1U << 1));

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is U2F30 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => bits.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((double)this).ToString((IFormatProvider)null);

        // IEquatable<U2F30>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(U2F30 other) => bits == other.bits;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            return ((double)this).ToString(format, formatProvider);
        }
    }
}