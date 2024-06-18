using System;
using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Fixed {
    [Serializable]
    public struct I5F27 : IEquatable<I5F27>, IFormattable {
        // Consts
        // ------

        public const int IntNbits = 5;
        public const int FracNbits = 27;

        const int oneRepr = 1 << FracNbits;

        // Fields
        // ------

#if NET5_0_OR_GREATER
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        public int Bits;

#if NET5_0_OR_GREATER
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
#endif

        // Static readonly properties
        // --------------------------

        public static readonly I5F27 Zero = FromNum(0);
        public static readonly I5F27 One = FromNum(1);
        public static readonly I5F27 MinValue = FromBits(int.MinValue);
        public static readonly I5F27 MaxValue = FromBits(int.MaxValue);

        // Constructors
        // ------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        I5F27(int bits) {
            Bits = bits;
        }

        // Static methods
        // --------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I5F27 FromBits(int bits) => new I5F27(bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I5F27 FromNum(int num) => FromBits(num * oneRepr);

        // Arithmetic Operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I5F27 operator +(I5F27 left, I5F27 right) {
            return FromBits(left.Bits + right.Bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I5F27 operator -(I5F27 left, I5F27 right) {
            return FromBits(left.Bits - right.Bits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I5F27 operator *(I5F27 left, I5F27 right) {
            long l = left.Bits;
            return FromBits((int)(l * right.Bits / oneRepr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I5F27 operator /(I5F27 left, I5F27 right) {
            long l = left.Bits;
            return FromBits((int)(l * oneRepr / right.Bits));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I5F27 operator +(I5F27 x) => FromBits(+x.Bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static I5F27 operator -(I5F27 x) => FromBits(-x.Bits);

        // Comparison operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(I5F27 lhs, I5F27 rhs) => lhs.Equals(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(I5F27 lhs, I5F27 rhs) => !(lhs == rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(I5F27 left, I5F27 right) => left.Bits < right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(I5F27 left, I5F27 right) => left.Bits > right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(I5F27 left, I5F27 right) => left.Bits <= right.Bits;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(I5F27 left, I5F27 right) => left.Bits >= right.Bits;

        // Methods
        // -------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I5F27 Min(I5F27 other) => FromBits(Math.Min(Bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I5F27 Max(I5F27 other) => FromBits(Math.Max(Bits, other.Bits));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I5F27 Abs() => FromBits(Math.Abs(Bits));

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I5F27 LosslessMul(int other) => FromBits(Bits * other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I4F28 LosslessMul(I31F1 other) => I4F28.FromBits(Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I3F29 LosslessMul(I30F2 other) => I3F29.FromBits(Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I2F30 LosslessMul(I29F3 other) => I2F30.FromBits(Bits * other.Bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I37F27 WideningMul(int other) => I37F27.FromBits((long)Bits * other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I36F28 WideningMul(I31F1 other) => I36F28.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I35F29 WideningMul(I30F2 other) => I35F29.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I34F30 WideningMul(I29F3 other) => I34F30.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I33F31 WideningMul(I28F4 other) => I33F31.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I32F32 WideningMul(I27F5 other) => I32F32.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I31F33 WideningMul(I26F6 other) => I31F33.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I30F34 WideningMul(I25F7 other) => I30F34.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I29F35 WideningMul(I24F8 other) => I29F35.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I28F36 WideningMul(I23F9 other) => I28F36.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I27F37 WideningMul(I22F10 other) => I27F37.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I26F38 WideningMul(I21F11 other) => I26F38.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I25F39 WideningMul(I20F12 other) => I25F39.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I24F40 WideningMul(I19F13 other) => I24F40.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I23F41 WideningMul(I18F14 other) => I23F41.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I22F42 WideningMul(I17F15 other) => I22F42.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I21F43 WideningMul(I16F16 other) => I21F43.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I20F44 WideningMul(I15F17 other) => I20F44.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I19F45 WideningMul(I14F18 other) => I19F45.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I18F46 WideningMul(I13F19 other) => I18F46.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I17F47 WideningMul(I12F20 other) => I17F47.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I16F48 WideningMul(I11F21 other) => I16F48.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I15F49 WideningMul(I10F22 other) => I15F49.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I14F50 WideningMul(I9F23 other) => I14F50.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I13F51 WideningMul(I8F24 other) => I13F51.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I12F52 WideningMul(I7F25 other) => I12F52.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I11F53 WideningMul(I6F26 other) => I11F53.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I10F54 WideningMul(I5F27 other) => I10F54.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I9F55 WideningMul(I4F28 other) => I9F55.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I8F56 WideningMul(I3F29 other) => I8F56.FromBits((long)Bits * other.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public readonly I7F57 WideningMul(I2F30 other) => I7F57.FromBits((long)Bits * other.Bits);

        // Conversion operators
        // --------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator int(I5F27 x) => x.Bits / oneRepr;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator uint(I5F27 x) => (uint)(x.Bits / oneRepr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator long(I5F27 x) => x.Bits / oneRepr;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator ulong(I5F27 x) => (ulong)(x.Bits / oneRepr);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float(I5F27 x) {
            const float k = 1.0f / oneRepr;
            return k * x.Bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double(I5F27 x) {
            const double k = 1.0 / oneRepr;
            return k * x.Bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator decimal(I5F27 x) {
            const decimal k = 1.0M / oneRepr;
            return k * x.Bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I31F1(I5F27 x) => I31F1.FromBits(x.Bits / (1 << 26));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I30F2(I5F27 x) => I30F2.FromBits(x.Bits / (1 << 25));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I29F3(I5F27 x) => I29F3.FromBits(x.Bits / (1 << 24));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I28F4(I5F27 x) => I28F4.FromBits(x.Bits / (1 << 23));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I27F5(I5F27 x) => I27F5.FromBits(x.Bits / (1 << 22));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I26F6(I5F27 x) => I26F6.FromBits(x.Bits / (1 << 21));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I25F7(I5F27 x) => I25F7.FromBits(x.Bits / (1 << 20));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I24F8(I5F27 x) => I24F8.FromBits(x.Bits / (1 << 19));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I23F9(I5F27 x) => I23F9.FromBits(x.Bits / (1 << 18));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I22F10(I5F27 x) => I22F10.FromBits(x.Bits / (1 << 17));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I21F11(I5F27 x) => I21F11.FromBits(x.Bits / (1 << 16));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I20F12(I5F27 x) => I20F12.FromBits(x.Bits / (1 << 15));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I19F13(I5F27 x) => I19F13.FromBits(x.Bits / (1 << 14));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I18F14(I5F27 x) => I18F14.FromBits(x.Bits / (1 << 13));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I17F15(I5F27 x) => I17F15.FromBits(x.Bits / (1 << 12));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I16F16(I5F27 x) => I16F16.FromBits(x.Bits / (1 << 11));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I15F17(I5F27 x) => I15F17.FromBits(x.Bits / (1 << 10));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I14F18(I5F27 x) => I14F18.FromBits(x.Bits / (1 << 9));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I13F19(I5F27 x) => I13F19.FromBits(x.Bits / (1 << 8));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I12F20(I5F27 x) => I12F20.FromBits(x.Bits / (1 << 7));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I11F21(I5F27 x) => I11F21.FromBits(x.Bits / (1 << 6));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I10F22(I5F27 x) => I10F22.FromBits(x.Bits / (1 << 5));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I9F23(I5F27 x) => I9F23.FromBits(x.Bits / (1 << 4));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I8F24(I5F27 x) => I8F24.FromBits(x.Bits / (1 << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I7F25(I5F27 x) => I7F25.FromBits(x.Bits / (1 << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I6F26(I5F27 x) => I6F26.FromBits(x.Bits / (1 << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I4F28(I5F27 x) => I4F28.FromBits(x.Bits * (1 << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I3F29(I5F27 x) => I3F29.FromBits(x.Bits * (1 << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I2F30(I5F27 x) => I2F30.FromBits(x.Bits * (1 << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U31F1(I5F27 x) => U31F1.FromBits((uint)(x.Bits / (1 << 26)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U30F2(I5F27 x) => U30F2.FromBits((uint)(x.Bits / (1 << 25)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U29F3(I5F27 x) => U29F3.FromBits((uint)(x.Bits / (1 << 24)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U28F4(I5F27 x) => U28F4.FromBits((uint)(x.Bits / (1 << 23)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U27F5(I5F27 x) => U27F5.FromBits((uint)(x.Bits / (1 << 22)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U26F6(I5F27 x) => U26F6.FromBits((uint)(x.Bits / (1 << 21)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U25F7(I5F27 x) => U25F7.FromBits((uint)(x.Bits / (1 << 20)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U24F8(I5F27 x) => U24F8.FromBits((uint)(x.Bits / (1 << 19)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U23F9(I5F27 x) => U23F9.FromBits((uint)(x.Bits / (1 << 18)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U22F10(I5F27 x) => U22F10.FromBits((uint)(x.Bits / (1 << 17)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U21F11(I5F27 x) => U21F11.FromBits((uint)(x.Bits / (1 << 16)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U20F12(I5F27 x) => U20F12.FromBits((uint)(x.Bits / (1 << 15)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U19F13(I5F27 x) => U19F13.FromBits((uint)(x.Bits / (1 << 14)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U18F14(I5F27 x) => U18F14.FromBits((uint)(x.Bits / (1 << 13)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U17F15(I5F27 x) => U17F15.FromBits((uint)(x.Bits / (1 << 12)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U16F16(I5F27 x) => U16F16.FromBits((uint)(x.Bits / (1 << 11)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U15F17(I5F27 x) => U15F17.FromBits((uint)(x.Bits / (1 << 10)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U14F18(I5F27 x) => U14F18.FromBits((uint)(x.Bits / (1 << 9)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U13F19(I5F27 x) => U13F19.FromBits((uint)(x.Bits / (1 << 8)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U12F20(I5F27 x) => U12F20.FromBits((uint)(x.Bits / (1 << 7)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U11F21(I5F27 x) => U11F21.FromBits((uint)(x.Bits / (1 << 6)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U10F22(I5F27 x) => U10F22.FromBits((uint)(x.Bits / (1 << 5)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U9F23(I5F27 x) => U9F23.FromBits((uint)(x.Bits / (1 << 4)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U8F24(I5F27 x) => U8F24.FromBits((uint)(x.Bits / (1 << 3)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U7F25(I5F27 x) => U7F25.FromBits((uint)(x.Bits / (1 << 2)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U6F26(I5F27 x) => U6F26.FromBits((uint)(x.Bits / (1 << 1)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U5F27(I5F27 x) => U5F27.FromBits((uint)x.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U4F28(I5F27 x) => U4F28.FromBits((uint)x.Bits * (1U << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U3F29(I5F27 x) => U3F29.FromBits((uint)x.Bits * (1U << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U2F30(I5F27 x) => U2F30.FromBits((uint)x.Bits * (1U << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I63F1(I5F27 x) => I63F1.FromBits(x.Bits / (1 << 26));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I62F2(I5F27 x) => I62F2.FromBits(x.Bits / (1 << 25));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I61F3(I5F27 x) => I61F3.FromBits(x.Bits / (1 << 24));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I60F4(I5F27 x) => I60F4.FromBits(x.Bits / (1 << 23));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I59F5(I5F27 x) => I59F5.FromBits(x.Bits / (1 << 22));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I58F6(I5F27 x) => I58F6.FromBits(x.Bits / (1 << 21));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I57F7(I5F27 x) => I57F7.FromBits(x.Bits / (1 << 20));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I56F8(I5F27 x) => I56F8.FromBits(x.Bits / (1 << 19));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I55F9(I5F27 x) => I55F9.FromBits(x.Bits / (1 << 18));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I54F10(I5F27 x) => I54F10.FromBits(x.Bits / (1 << 17));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I53F11(I5F27 x) => I53F11.FromBits(x.Bits / (1 << 16));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I52F12(I5F27 x) => I52F12.FromBits(x.Bits / (1 << 15));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I51F13(I5F27 x) => I51F13.FromBits(x.Bits / (1 << 14));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I50F14(I5F27 x) => I50F14.FromBits(x.Bits / (1 << 13));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I49F15(I5F27 x) => I49F15.FromBits(x.Bits / (1 << 12));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I48F16(I5F27 x) => I48F16.FromBits(x.Bits / (1 << 11));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I47F17(I5F27 x) => I47F17.FromBits(x.Bits / (1 << 10));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I46F18(I5F27 x) => I46F18.FromBits(x.Bits / (1 << 9));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I45F19(I5F27 x) => I45F19.FromBits(x.Bits / (1 << 8));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I44F20(I5F27 x) => I44F20.FromBits(x.Bits / (1 << 7));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I43F21(I5F27 x) => I43F21.FromBits(x.Bits / (1 << 6));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I42F22(I5F27 x) => I42F22.FromBits(x.Bits / (1 << 5));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I41F23(I5F27 x) => I41F23.FromBits(x.Bits / (1 << 4));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I40F24(I5F27 x) => I40F24.FromBits(x.Bits / (1 << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I39F25(I5F27 x) => I39F25.FromBits(x.Bits / (1 << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I38F26(I5F27 x) => I38F26.FromBits(x.Bits / (1 << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I37F27(I5F27 x) => I37F27.FromBits(x.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I36F28(I5F27 x) => I36F28.FromBits(x.Bits * (1L << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I35F29(I5F27 x) => I35F29.FromBits(x.Bits * (1L << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I34F30(I5F27 x) => I34F30.FromBits(x.Bits * (1L << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I33F31(I5F27 x) => I33F31.FromBits(x.Bits * (1L << 4));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I32F32(I5F27 x) => I32F32.FromBits(x.Bits * (1L << 5));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I31F33(I5F27 x) => I31F33.FromBits(x.Bits * (1L << 6));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I30F34(I5F27 x) => I30F34.FromBits(x.Bits * (1L << 7));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I29F35(I5F27 x) => I29F35.FromBits(x.Bits * (1L << 8));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I28F36(I5F27 x) => I28F36.FromBits(x.Bits * (1L << 9));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I27F37(I5F27 x) => I27F37.FromBits(x.Bits * (1L << 10));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I26F38(I5F27 x) => I26F38.FromBits(x.Bits * (1L << 11));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I25F39(I5F27 x) => I25F39.FromBits(x.Bits * (1L << 12));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I24F40(I5F27 x) => I24F40.FromBits(x.Bits * (1L << 13));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I23F41(I5F27 x) => I23F41.FromBits(x.Bits * (1L << 14));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I22F42(I5F27 x) => I22F42.FromBits(x.Bits * (1L << 15));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I21F43(I5F27 x) => I21F43.FromBits(x.Bits * (1L << 16));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I20F44(I5F27 x) => I20F44.FromBits(x.Bits * (1L << 17));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I19F45(I5F27 x) => I19F45.FromBits(x.Bits * (1L << 18));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I18F46(I5F27 x) => I18F46.FromBits(x.Bits * (1L << 19));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I17F47(I5F27 x) => I17F47.FromBits(x.Bits * (1L << 20));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I16F48(I5F27 x) => I16F48.FromBits(x.Bits * (1L << 21));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I15F49(I5F27 x) => I15F49.FromBits(x.Bits * (1L << 22));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I14F50(I5F27 x) => I14F50.FromBits(x.Bits * (1L << 23));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I13F51(I5F27 x) => I13F51.FromBits(x.Bits * (1L << 24));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I12F52(I5F27 x) => I12F52.FromBits(x.Bits * (1L << 25));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I11F53(I5F27 x) => I11F53.FromBits(x.Bits * (1L << 26));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I10F54(I5F27 x) => I10F54.FromBits(x.Bits * (1L << 27));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I9F55(I5F27 x) => I9F55.FromBits(x.Bits * (1L << 28));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I8F56(I5F27 x) => I8F56.FromBits(x.Bits * (1L << 29));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I7F57(I5F27 x) => I7F57.FromBits(x.Bits * (1L << 30));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I6F58(I5F27 x) => I6F58.FromBits(x.Bits * (1L << 31));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator I5F59(I5F27 x) => I5F59.FromBits(x.Bits * (1L << 32));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I4F60(I5F27 x) => I4F60.FromBits(x.Bits * (1L << 33));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I3F61(I5F27 x) => I3F61.FromBits(x.Bits * (1L << 34));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator I2F62(I5F27 x) => I2F62.FromBits(x.Bits * (1L << 35));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U63F1(I5F27 x) => U63F1.FromBits((ulong)(x.Bits / (1 << 26)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U62F2(I5F27 x) => U62F2.FromBits((ulong)(x.Bits / (1 << 25)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U61F3(I5F27 x) => U61F3.FromBits((ulong)(x.Bits / (1 << 24)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U60F4(I5F27 x) => U60F4.FromBits((ulong)(x.Bits / (1 << 23)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U59F5(I5F27 x) => U59F5.FromBits((ulong)(x.Bits / (1 << 22)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U58F6(I5F27 x) => U58F6.FromBits((ulong)(x.Bits / (1 << 21)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U57F7(I5F27 x) => U57F7.FromBits((ulong)(x.Bits / (1 << 20)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U56F8(I5F27 x) => U56F8.FromBits((ulong)(x.Bits / (1 << 19)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U55F9(I5F27 x) => U55F9.FromBits((ulong)(x.Bits / (1 << 18)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U54F10(I5F27 x) => U54F10.FromBits((ulong)(x.Bits / (1 << 17)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U53F11(I5F27 x) => U53F11.FromBits((ulong)(x.Bits / (1 << 16)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U52F12(I5F27 x) => U52F12.FromBits((ulong)(x.Bits / (1 << 15)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U51F13(I5F27 x) => U51F13.FromBits((ulong)(x.Bits / (1 << 14)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U50F14(I5F27 x) => U50F14.FromBits((ulong)(x.Bits / (1 << 13)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U49F15(I5F27 x) => U49F15.FromBits((ulong)(x.Bits / (1 << 12)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U48F16(I5F27 x) => U48F16.FromBits((ulong)(x.Bits / (1 << 11)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U47F17(I5F27 x) => U47F17.FromBits((ulong)(x.Bits / (1 << 10)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U46F18(I5F27 x) => U46F18.FromBits((ulong)(x.Bits / (1 << 9)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U45F19(I5F27 x) => U45F19.FromBits((ulong)(x.Bits / (1 << 8)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U44F20(I5F27 x) => U44F20.FromBits((ulong)(x.Bits / (1 << 7)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U43F21(I5F27 x) => U43F21.FromBits((ulong)(x.Bits / (1 << 6)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U42F22(I5F27 x) => U42F22.FromBits((ulong)(x.Bits / (1 << 5)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U41F23(I5F27 x) => U41F23.FromBits((ulong)(x.Bits / (1 << 4)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U40F24(I5F27 x) => U40F24.FromBits((ulong)(x.Bits / (1 << 3)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U39F25(I5F27 x) => U39F25.FromBits((ulong)(x.Bits / (1 << 2)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U38F26(I5F27 x) => U38F26.FromBits((ulong)(x.Bits / (1 << 1)));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U37F27(I5F27 x) => U37F27.FromBits((ulong)x.Bits);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U36F28(I5F27 x) => U36F28.FromBits((ulong)x.Bits * (1UL << 1));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U35F29(I5F27 x) => U35F29.FromBits((ulong)x.Bits * (1UL << 2));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U34F30(I5F27 x) => U34F30.FromBits((ulong)x.Bits * (1UL << 3));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U33F31(I5F27 x) => U33F31.FromBits((ulong)x.Bits * (1UL << 4));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U32F32(I5F27 x) => U32F32.FromBits((ulong)x.Bits * (1UL << 5));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U31F33(I5F27 x) => U31F33.FromBits((ulong)x.Bits * (1UL << 6));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U30F34(I5F27 x) => U30F34.FromBits((ulong)x.Bits * (1UL << 7));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U29F35(I5F27 x) => U29F35.FromBits((ulong)x.Bits * (1UL << 8));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U28F36(I5F27 x) => U28F36.FromBits((ulong)x.Bits * (1UL << 9));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U27F37(I5F27 x) => U27F37.FromBits((ulong)x.Bits * (1UL << 10));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U26F38(I5F27 x) => U26F38.FromBits((ulong)x.Bits * (1UL << 11));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U25F39(I5F27 x) => U25F39.FromBits((ulong)x.Bits * (1UL << 12));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U24F40(I5F27 x) => U24F40.FromBits((ulong)x.Bits * (1UL << 13));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U23F41(I5F27 x) => U23F41.FromBits((ulong)x.Bits * (1UL << 14));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U22F42(I5F27 x) => U22F42.FromBits((ulong)x.Bits * (1UL << 15));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U21F43(I5F27 x) => U21F43.FromBits((ulong)x.Bits * (1UL << 16));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U20F44(I5F27 x) => U20F44.FromBits((ulong)x.Bits * (1UL << 17));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U19F45(I5F27 x) => U19F45.FromBits((ulong)x.Bits * (1UL << 18));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U18F46(I5F27 x) => U18F46.FromBits((ulong)x.Bits * (1UL << 19));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U17F47(I5F27 x) => U17F47.FromBits((ulong)x.Bits * (1UL << 20));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U16F48(I5F27 x) => U16F48.FromBits((ulong)x.Bits * (1UL << 21));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U15F49(I5F27 x) => U15F49.FromBits((ulong)x.Bits * (1UL << 22));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U14F50(I5F27 x) => U14F50.FromBits((ulong)x.Bits * (1UL << 23));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U13F51(I5F27 x) => U13F51.FromBits((ulong)x.Bits * (1UL << 24));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U12F52(I5F27 x) => U12F52.FromBits((ulong)x.Bits * (1UL << 25));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U11F53(I5F27 x) => U11F53.FromBits((ulong)x.Bits * (1UL << 26));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U10F54(I5F27 x) => U10F54.FromBits((ulong)x.Bits * (1UL << 27));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U9F55(I5F27 x) => U9F55.FromBits((ulong)x.Bits * (1UL << 28));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U8F56(I5F27 x) => U8F56.FromBits((ulong)x.Bits * (1UL << 29));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U7F57(I5F27 x) => U7F57.FromBits((ulong)x.Bits * (1UL << 30));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U6F58(I5F27 x) => U6F58.FromBits((ulong)x.Bits * (1UL << 31));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U5F59(I5F27 x) => U5F59.FromBits((ulong)x.Bits * (1UL << 32));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U4F60(I5F27 x) => U4F60.FromBits((ulong)x.Bits * (1UL << 33));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U3F61(I5F27 x) => U3F61.FromBits((ulong)x.Bits * (1UL << 34));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static explicit operator U2F62(I5F27 x) => U2F62.FromBits((ulong)x.Bits * (1UL << 35));

        // Object
        // ---------------------------------------

        public override readonly bool Equals(object obj) => obj is I5F27 o && Equals(o);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => Bits.GetHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((double)this).ToString((IFormatProvider)null);

        // IEquatable<I5F27>
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(I5F27 other) => Bits == other.Bits;

        // IFormattable
        // ---------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) {
            return ((double)this).ToString(format, formatProvider);
        }
    }
}
