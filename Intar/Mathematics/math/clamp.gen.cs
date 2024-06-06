// Unity 2018.3 以上の場合は Unity.Mathematics を使用する.
#if !UNITY_2018_3_OR_NEWER

using System.Runtime.CompilerServices;

namespace AgatePris.Intar.Mathematics {
#pragma warning disable CS8981 // 型名には、小文字の ASCII 文字のみが含まれています。このような名前は、プログラミング言語用に予約されている可能性があります。

    public static partial class math {
#pragma warning restore CS8981 // 型名には、小文字の ASCII 文字のみが含まれています。このような名前は、プログラミング言語用に予約されている可能性があります。
#pragma warning disable IDE1006 // 命名スタイル

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int min(int x, int y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint min(uint x, uint y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long min(long x, long y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong min(ulong x, ulong y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short min(short x, short y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort min(ushort x, ushort y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte min(byte x, byte y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte min(sbyte x, sbyte y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float min(float x, float y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double min(double x, double y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal min(decimal x, decimal y) => x < y ? x : y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int max(int x, int y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint max(uint x, uint y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long max(long x, long y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong max(ulong x, ulong y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short max(short x, short y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort max(ushort x, ushort y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte max(byte x, byte y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte max(sbyte x, sbyte y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float max(float x, float y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double max(double x, double y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal max(decimal x, decimal y) => x > y ? x : y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int clamp(int x, int a, int b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint clamp(uint x, uint a, uint b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long clamp(long x, long a, long b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong clamp(ulong x, ulong a, ulong b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short clamp(short x, short a, short b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort clamp(ushort x, ushort a, ushort b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte clamp(byte x, byte a, byte b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte clamp(sbyte x, sbyte a, sbyte b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float clamp(float x, float a, float b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double clamp(double x, double a, double b) => max(a, min(b, x));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal clamp(decimal x, decimal a, decimal b) => max(a, min(b, x));
#pragma warning restore IDE1006 // 命名スタイル

    }
}

#endif
