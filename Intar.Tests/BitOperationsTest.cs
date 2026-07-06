using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Intar.Tests {
    public class BitOperationsTest {
        static int PopCount(uint x) {
            var mask = 1U;
            var count = 0;
            while (mask != 0) {
                if ((mask & x) != 0) {
                    ++count;
                }
                mask <<= 1;
            }
            return count;
        }

        static int PopCount(ulong x) {
            var mask = 1UL;
            var count = 0;
            while (mask != 0) {
                if ((mask & x) != 0) {
                    ++count;
                }
                mask <<= 1;
            }
            return count;
        }

        static int LeadingZeroCount(uint x) {
            const int bitsOfInt = sizeof(int) * 8;
            for (var rhs = 1; rhs < bitsOfInt; rhs <<= 1) {
                x |= x >> rhs;
            }
            unchecked {
                return bitsOfInt - PopCount(x);
            }
        }

        static int LeadingZeroCount(ulong x) {
            const int bitsOfLong = sizeof(long) * 8;
            for (var rhs = 1; rhs < bitsOfLong; rhs <<= 1) {
                x |= x >> rhs;
            }
            unchecked {
                return bitsOfLong - PopCount(x);
            }
        }

        [Test]
        public static void TestLeadingZeroCountUint() {
            Utility.AssertAreEqual(32, BitOperations.LeadingZeroCount(0U));
            Utility.AssertAreEqual(0, BitOperations.LeadingZeroCount(uint.MaxValue));
            for (var i = 0; i < 32; ++i) {
                var x = 1U << i;
                Utility.AssertAreEqual(31 - i, BitOperations.LeadingZeroCount(x));
                Utility.AssertAreEqual(i == 31 ? 1 : 0, BitOperations.LeadingZeroCount(~x));

                for (var j = i + 1; j < 32; ++j) {
                    var y = 1U << j;
                    Utility.AssertAreEqual(31 - j, BitOperations.LeadingZeroCount(x | y));
                    Utility.AssertAreEqual(j == 31 ? (i == 30 ? 2 : 1) : 0, BitOperations.LeadingZeroCount(~(x | y)));
                }
            }

            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            for (var i = 0; i < 99999; ++i) {
                var x = unchecked((uint)rng.Next());
                var expected = LeadingZeroCount(x);
                var actual = BitOperations.LeadingZeroCount(x);
                if (expected != actual) {
                    Assert.Fail();
                }
            }
        }

        // uint の全数走査を行うため非常に時間がかかる.
        // 継続的インテグレーションでは実行しない.
        [Test]
        [Category("Exhaustive")]
        public static void TestLeadingZeroCountUintExhaustive() {
            Utility.AssertAreEqual(0, BitOperations.LeadingZeroCount(uint.MaxValue));

            var processorCount = Environment.ProcessorCount;
            var denominator = (ulong)processorCount;
            _ = Parallel.For(0, processorCount, n => {
                var curr = (ulong)n;
                var next = curr + 1;
                var begin = (uint)(uint.MaxValue * curr / denominator);
                var end = (uint)(uint.MaxValue * next / denominator);
                for (var x = begin; x < end; ++x) {
                    var expected = LeadingZeroCount(x);
                    var actual = BitOperations.LeadingZeroCount(x);
                    if (expected != actual) {
                        Assert.Fail();
                    }
                }
            });
        }

        [Test]
        public static void TestLeadingZeroCountUlong() {
            Utility.AssertAreEqual(64, BitOperations.LeadingZeroCount(0UL));
            Utility.AssertAreEqual(0, BitOperations.LeadingZeroCount(ulong.MaxValue));
            for (var i = 0; i < 64; ++i) {
                var x = 1UL << i;
                Utility.AssertAreEqual(63 - i, BitOperations.LeadingZeroCount(x));
                Utility.AssertAreEqual(i == 63 ? 1 : 0, BitOperations.LeadingZeroCount(~x));

                for (var j = i + 1; j < 64; ++j) {
                    var y = 1UL << j;
                    Utility.AssertAreEqual(63 - j, BitOperations.LeadingZeroCount(x | y));
                    Utility.AssertAreEqual(j == 63 ? (i == 62 ? 2 : 1) : 0, BitOperations.LeadingZeroCount(~(x | y)));
                }
            }

            var processorCount = Environment.ProcessorCount;
            _ = Parallel.For(0, processorCount, n => {
                var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
                for (var i = 0; i < n; ++i) {
                    rng.Jump();
                }
                for (var i = 0; i < 99999; ++i) {
                    var x = unchecked((ulong)rng.NextInt64());
                    var expected = LeadingZeroCount(x);
                    var actual = BitOperations.LeadingZeroCount(x);
                    if (expected != actual) {
                        Assert.Fail();
                    }
                }
            });
        }

        [Test]
        public static void TestPopCountUint() {
            Utility.AssertAreEqual(0, BitOperations.PopCount(0U));
            Utility.AssertAreEqual(32, BitOperations.PopCount(uint.MaxValue));
            for (var i = 0; i < 32; ++i) {
                var x = 1U << i;
                Utility.AssertAreEqual(1, BitOperations.PopCount(x));
                Utility.AssertAreEqual(31, BitOperations.PopCount(~x));

                for (var j = i + 1; j < 32; ++j) {
                    var y = 1U << j;
                    Utility.AssertAreEqual(2, BitOperations.PopCount(x | y));
                    Utility.AssertAreEqual(30, BitOperations.PopCount(~(x | y)));
                }
            }

            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            for (var i = 0; i < 99999; ++i) {
                var x = unchecked((uint)rng.Next());
                var expected = PopCount(x);
                var actual = BitOperations.PopCount(x);
                if (expected != actual) {
                    Assert.Fail();
                }
            }
        }

        // uint の全数走査を行うため非常に時間がかかる.
        // 継続的インテグレーションでは実行しない.
        [Test]
        [Category("Exhaustive")]
        public static void TestPopCountUintExhaustive() {
            Utility.AssertAreEqual(32, BitOperations.PopCount(uint.MaxValue));

            var processorCount = Environment.ProcessorCount;
            var denominator = (ulong)processorCount;
            _ = Parallel.For(0, processorCount, n => {
                var curr = (ulong)n;
                var next = curr + 1;
                var begin = (uint)(uint.MaxValue * curr / denominator);
                var end = (uint)(uint.MaxValue * next / denominator);
                for (var x = begin; x < end; ++x) {
                    var expected = PopCount(x);
                    var actual = BitOperations.PopCount(x);
                    if (expected != actual) {
                        Assert.Fail();
                    }
                }
            });
        }

        [Test]
        public static void TestPopCountUlong() {
            Utility.AssertAreEqual(0, BitOperations.PopCount(0UL));
            Utility.AssertAreEqual(64, BitOperations.PopCount(ulong.MaxValue));
            for (var i = 0; i < 64; ++i) {
                var x = 1UL << i;
                Utility.AssertAreEqual(1, BitOperations.PopCount(x));
                Utility.AssertAreEqual(63, BitOperations.PopCount(~x));

                for (var j = i + 1; j < 64; ++j) {
                    var y = 1UL << j;
                    Utility.AssertAreEqual(2, BitOperations.PopCount(x | y));
                    Utility.AssertAreEqual(62, BitOperations.PopCount(~(x | y)));
                }
            }

            var processorCount = Environment.ProcessorCount;
            _ = Parallel.For(0, processorCount, n => {
                var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
                for (var i = 0; i < n; ++i) {
                    rng.Jump();
                }
                for (var i = 0; i < 99999; ++i) {
                    var x = unchecked((ulong)rng.NextInt64());
                    var expected = PopCount(x);
                    var actual = BitOperations.PopCount(x);
                    if (expected != actual) {
                        Assert.Fail();
                    }
                }
            });
        }

        [Test]
        public static void TestRotateLeft() {
            for (var i = 0; i < 32; ++i) {
                Utility.AssertAreEqual(0U, BitOperations.RotateLeft(0U, i));
            }
            for (var i = 0; i < 64; ++i) {
                Utility.AssertAreEqual(0UL, BitOperations.RotateLeft(0UL, i));
            }
            {
                var k = new uint[] {
                    0x0000_FFFFU, 0x00FF_FF00U, 0xFFFF_0000U, 0xFF00_00FFU,
                };
                for (var i = 0; i < 4; ++i) {
                    Utility.AssertAreEqual(k[i], BitOperations.RotateLeft(k[i], 32));
                    Utility.AssertAreEqual(k[(i + 1) % 4], BitOperations.RotateLeft(k[i], 8));
                    Utility.AssertAreEqual(k[(i + 2) % 4], BitOperations.RotateLeft(k[i], 16));
                    Utility.AssertAreEqual(k[(i + 3) % 4], BitOperations.RotateLeft(k[i], 24));
                }
            }
            {
                var k = new ulong[] {
                    0x0000_0000_0000_FFFFUL, 0x0000_0000_FFFF_0000UL,
                    0x0000_FFFF_0000_0000UL, 0xFFFF_0000_0000_0000UL,
                };
                for (var i = 0; i < 4; ++i) {
                    Utility.AssertAreEqual(k[i], BitOperations.RotateLeft(k[i], 64));
                    Utility.AssertAreEqual(k[(i + 1) % 4], BitOperations.RotateLeft(k[i], 16));
                    Utility.AssertAreEqual(k[(i + 2) % 4], BitOperations.RotateLeft(k[i], 32));
                    Utility.AssertAreEqual(k[(i + 3) % 4], BitOperations.RotateLeft(k[i], 48));
                }
            }
        }

        [Test]
        public static void TestRotateRight() {
            for (var i = 0; i < 32; ++i) {
                Utility.AssertAreEqual(0U, BitOperations.RotateRight(0U, i));
            }
            for (var i = 0; i < 64; ++i) {
                Utility.AssertAreEqual(0UL, BitOperations.RotateRight(0UL, i));
            }
            {
                var k = new uint[] {
                    0xFFFF_0000U, 0x00FF_FF00U, 0x0000_FFFFU, 0xFF00_00FFU,
                };
                for (var i = 0; i < 4; ++i) {
                    Utility.AssertAreEqual(k[i], BitOperations.RotateRight(k[i], 32));
                    Utility.AssertAreEqual(k[(i + 1) % 4], BitOperations.RotateRight(k[i], 8));
                    Utility.AssertAreEqual(k[(i + 2) % 4], BitOperations.RotateRight(k[i], 16));
                    Utility.AssertAreEqual(k[(i + 3) % 4], BitOperations.RotateRight(k[i], 24));
                }
            }
            {
                var k = new ulong[] {
                    0xFFFF_0000_0000_0000UL, 0x0000_FFFF_0000_0000UL,
                    0x0000_0000_FFFF_0000UL, 0x0000_0000_0000_FFFFUL,
                };
                for (var i = 0; i < 4; ++i) {
                    Utility.AssertAreEqual(k[i], BitOperations.RotateRight(k[i], 64));
                    Utility.AssertAreEqual(k[(i + 1) % 4], BitOperations.RotateRight(k[i], 16));
                    Utility.AssertAreEqual(k[(i + 2) % 4], BitOperations.RotateRight(k[i], 32));
                    Utility.AssertAreEqual(k[(i + 3) % 4], BitOperations.RotateRight(k[i], 48));
                }
            }
        }
    }
}
