namespace Intar.Rand {
    public struct Xoroshiro128StarStar {
        ulong s0, s1;

        public Xoroshiro128StarStar(ulong s0, ulong s1) {
            this.s0 = s0;
            this.s1 = s1;
        }

        public ulong NextUInt64() {
            var s0 = this.s0;
            var s1 = this.s1;
            var result = unchecked(BitOperations.RotateLeft(s0 * 5, 7) * 9);
            s1 ^= s0;
            this.s0 = BitOperations.RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
            this.s1 = BitOperations.RotateLeft(s1, 37);
            return result;
        }
        public ulong NextUInt64(ulong maxValue) {
            var t = ulong.MaxValue / maxValue * maxValue;
            ulong result;
            do {
                result = NextUInt64();
            } while (t <= result);
            result %= maxValue;
            return result;
        }
        public ulong NextUInt64(ulong minValue, ulong maxValue) {
            var d = maxValue - minValue;
            var a = NextUInt64(d);
            return minValue + a;
        }
        public long NextInt64() => unchecked((long)NextUInt64());
        public long NextInt64(long maxValue) {
            var result = NextUInt64((ulong)maxValue);
            return (long)result;
        }
        public long NextInt64(long minValue, long maxValue) {
            unchecked {
                var d = (ulong)(maxValue - minValue);
                var a = (long)NextUInt64(d);
                return minValue + a;
            }
        }
        public int Next() => unchecked((int)NextInt64());
        public int Next(int maxValue) {
            var result = NextInt64(maxValue);
            return (int)result;
        }
        public int Next(int minValue, int maxValue) {
            var result = NextInt64(minValue, maxValue);
            return (int)result;
        }

        /// <summary>
        /// 0 以上 1 未満の乱数を返す｡
        /// </summary>
        public U17F15 NextU17F15() {
            return U17F15.FromBits((uint)NextUInt64(U17F15.OneRepr));
        }

        /// <summary>
        /// 0 以上 <paramref name="maxValue" /> 未満の乱数を返す｡
        /// </summary>
        /// <param name="maxValue">乱数の排他的上限｡ 0 より大きい値でなければならない｡</param>
        public U17F15 NextU17F15(U17F15 maxValue) {
            return U17F15.FromBits((uint)NextUInt64(maxValue.Bits));
        }

        /// <summary>
        /// <paramref name="minValue" /> 以上 <paramref name="maxValue" /> 未満の乱数を返す｡
        /// </summary>
        /// <param name="minValue">乱数の包括的下限｡</param>
        /// <param name="maxValue">乱数の排他的上限｡ <paramref name="minValue" /> より大きい値でなければならない｡</param>
        public U17F15 NextU17F15(U17F15 minValue, U17F15 maxValue) {
            return U17F15.FromBits((uint)NextUInt64(minValue.Bits, maxValue.Bits));
        }

        /// <summary>
        /// 0 以上 1 未満の乱数を返す｡
        /// </summary>
        public I17F15 NextI17F15() {
            return I17F15.FromBits((int)NextInt64(I17F15.OneRepr));
        }

        /// <summary>
        /// 0 以上 <paramref name="maxValue" /> 未満の乱数を返す｡
        /// </summary>
        /// <param name="maxValue">乱数の排他的上限｡ 0 より大きい値でなければならない｡</param>
        public I17F15 NextI17F15(I17F15 maxValue) {
            return I17F15.FromBits((int)NextInt64(maxValue.Bits));
        }

        /// <summary>
        /// <paramref name="minValue" /> 以上 <paramref name="maxValue" /> 未満の乱数を返す｡
        /// </summary>
        /// <param name="minValue">乱数の包括的下限｡</param>
        /// <param name="maxValue">乱数の排他的上限｡ <paramref name="minValue" /> より大きい値でなければならない｡</param>
        public I17F15 NextI17F15(I17F15 minValue, I17F15 maxValue) {
            return I17F15.FromBits((int)NextInt64(minValue.Bits, maxValue.Bits));
        }

        public void Jump() {
            const ulong k1 = 0xdf900294d8f554a5UL;
            const ulong k2 = 0x170865df4b3201fcUL;
            var s0 = 0UL;
            var s1 = 0UL;
            for (var i = 0; i < 64; ++i) {
                if ((k1 & (1UL << i)) != 0) {
                    s0 ^= this.s0;
                    s1 ^= this.s1;
                }
                _ = NextInt64();
            }
            for (var i = 0; i < 64; ++i) {
                if ((k2 & (1UL << i)) != 0) {
                    s0 ^= this.s0;
                    s1 ^= this.s1;
                }
                _ = NextInt64();
            }
            this.s0 = s0;
            this.s1 = s1;
        }

        public void LongJump() {
            const ulong k1 = 0xd2a98b26625eee7bUL;
            const ulong k2 = 0xdddf9b1090aa7ac1UL;
            var s0 = 0UL;
            var s1 = 0UL;
            for (var i = 0; i < 64; ++i) {
                if ((k1 & (1UL << i)) != 0) {
                    s0 ^= this.s0;
                    s1 ^= this.s1;
                }
                _ = NextInt64();
            }
            for (var i = 0; i < 64; ++i) {
                if ((k2 & (1UL << i)) != 0) {
                    s0 ^= this.s0;
                    s1 ^= this.s1;
                }
                _ = NextInt64();
            }
            this.s0 = s0;
            this.s1 = s1;
        }
    }
}
