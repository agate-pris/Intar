using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace Intar.Tests.Rand {
    public class Xoroshiro128StarStarTest {
        [Test]
        public static void TestZero() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(0, 0);
            for (var i = 0; i < 100; ++i) {
                Utility.AssertAreEqual(0UL, rng.NextUInt64());
                Utility.AssertAreEqual(0L, rng.NextInt64());
                Utility.AssertAreEqual(0, rng.Next());
            }
        }

        [Test]
        public static void NextUInt64Test() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            var expected = new ulong[] {
                5760, 97769243520, 9706862127477703552, 9223447511460779954, 8358291023205304566,
                15695619998649302768, 8517900938696309774, 16586480348202605369,
                6959129367028440372, 16822147227405758281,
            };
            foreach (var e in expected) {
                Utility.AssertAreEqual(e, rng.NextUInt64());
            }
        }

        [Test]
        public static void NextInt64Test() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            var expected = new long[] {
                5760, 97769243520, -8739881946231848064, -9223296562248771662, 8358291023205304566,
                -2751124075060248848, 8517900938696309774, -1860263725506946247,
                6959129367028440372, -1624596846303793335
            };
            foreach (var e in expected) {
                Utility.AssertAreEqual(e, rng.NextInt64());
            }
        }

        [Test]
        public static void NextTest() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            var expected = new int[] {
                5760, -1015004288, 17280, -854288462, -948107018,
                -721273104, 586529806, 1822235449, -877126348, -1730695351,
            };
            foreach (var e in expected) {
                Utility.AssertAreEqual(e, rng.Next());
            }
        }

        [Test]
        public static void JumpTest() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            rng.Jump();
            var expected = new ulong[] {
                2464231652016875657, 11602794600843324846, 733764001042591551, 5324733124812429005,
                14635935237425590731, 4722186862080112093, 16160338188616420244,
                5488700251982350304, 9830647176479810634, 6282991482565129712,
            };
            foreach (var e in expected) {
                Utility.AssertAreEqual(e, unchecked((ulong)rng.NextInt64()));
            }
        }

        [Test]
        public static void LongJumpTest() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            rng.LongJump();
            var expected = new ulong[] {
                1154914562721061336, 6059381922964790418, 15458620134926953352, 6449629845481199462,
                16689757678599312554, 3412265672712362534, 15452021286289288989,
                14008746486977289672, 12513606066216797820, 17066077850955568493,
            };
            foreach (var e in expected) {
                Utility.AssertAreEqual(e, unchecked((ulong)rng.NextInt64()));
            }
        }

        [Test]
        public static void TestMinMax() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            var Dictionary = new Dictionary<int, int>();
            for (var i = 0; i < 9999; ++i) {
                var x = rng.Next(9);
                if (Dictionary.ContainsKey(x)) {
                    Dictionary[x] += 1;
                } else {
                    Dictionary[x] = 1;
                }
            }
            foreach (var kv in Dictionary) {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
            Dictionary.Clear();
            Console.WriteLine("");
            for (var i = 0; i < 9999; ++i) {
                var x = rng.Next(5, 9);
                if (Dictionary.ContainsKey(x)) {
                    Dictionary[x] += 1;
                } else {
                    Dictionary[x] = 1;
                }
            }
            foreach (var kv in Dictionary) {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
        }

        [Test]
        public static void NextU17F15Test() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            var min = U17F15.FromBits(1 << 14);
            var max = U17F15.FromBits(3 << 14);
            for (var i = 0; i < 9999; ++i) {
                {
                    var x = rng.NextU17F15();
                    Assert.IsTrue(U17F15.Zero <= x && x < U17F15.One);
                }
                {
                    var x = rng.NextU17F15(max);
                    Assert.IsTrue(U17F15.Zero <= x && x < max);
                }
                {
                    var x = rng.NextU17F15(min, max);
                    Assert.IsTrue(min <= x && x < max);
                }
            }
        }

        [Test]
        public static void NextI17F15Test() {
            var rng = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            var min = I17F15.FromBits(-3 << 14);
            var max = I17F15.FromBits(1 << 14);
            for (var i = 0; i < 9999; ++i) {
                {
                    var x = rng.NextI17F15();
                    Assert.IsTrue(I17F15.Zero <= x && x < I17F15.One);
                }
                {
                    var x = rng.NextI17F15(max);
                    Assert.IsTrue(I17F15.Zero <= x && x < max);
                }
                {
                    var x = rng.NextI17F15(min, max);
                    Assert.IsTrue(min <= x && x < max);
                }
            }
        }

        [Test]
        public static void NextFixedDeterminismTest() {
            var a = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            var b = new Intar.Rand.Xoroshiro128StarStar(1, 2);
            for (var i = 0; i < 100; ++i) {
                Utility.AssertAreEqual(a.NextU17F15().Bits, b.NextU17F15().Bits);
                Utility.AssertAreEqual(a.NextI17F15(), b.NextI17F15());
            }
        }
    }
}
