using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigIntegerExtenderTests
{
    [TestClass]
    public class BigIntegerExtenderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestSqrt_WhenValueIsNegative_ShouldThrowArithmeticException()
        {
            BigInteger.MinusOne.Sqrt();
        }

        [TestMethod]
        public void TestSqrt_WhenValueIsZero()
        {
            var value = BigInteger.Zero;
            bool isPerfect;

            Assert.AreEqual(value, value.Sqrt(out isPerfect));
            Assert.AreEqual(value.Sqrt(out isPerfect, true), value.Sqrt(false));

            Assert.IsTrue(isPerfect);
        }

        [TestMethod]
        public void TestSqrt_WhenValueIsOne()
        {
            var value = BigInteger.One;
            bool isPerfect;

            Assert.AreEqual(value, value.Sqrt(out isPerfect));
            Assert.AreEqual(value.Sqrt(out isPerfect, true), value.Sqrt(false));

            Assert.IsTrue(isPerfect);
        }

        [TestMethod]
        public void TestSqrt_WhenValueIsTwo()
        {
            BigInteger value = 2;
            bool isPerfect;

            Assert.AreEqual(value, value.Sqrt(out isPerfect, true));
            Assert.IsFalse(isPerfect);

            Assert.AreEqual(BigInteger.One, value.Sqrt(out isPerfect, false));
            Assert.IsFalse(isPerfect);
        }

        [TestMethod]
        public void TestSqrt_WhenIsPerfect()
        {
            BigInteger value = 4;
            bool isPerfect;

            Assert.AreEqual(2, value.Sqrt(out isPerfect));
            Assert.AreEqual(value.Sqrt(out isPerfect, true), value.Sqrt(false));

            Assert.IsTrue(isPerfect);
        }

        [TestMethod]
        public void TestSqrt_WhenIsNotPerfect()
        {
            BigInteger value = 3;
            bool isPerfect;

            Assert.AreEqual(2, value.Sqrt(out isPerfect, true));
            Assert.AreEqual(1, value.Sqrt(false));

            Assert.IsFalse(isPerfect);
        }

        [TestMethod]
        public void TestSqrt_WhenValueIsPositiveRandom()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            BigInteger value = rnd.Next();
            bool isPerfect;

            var upperSqrt = value.Sqrt(out isPerfect, true);
            var lowerSqrt = value.Sqrt(false);

            switch(isPerfect)
            {
                case true:
                    Assert.AreEqual(upperSqrt, lowerSqrt);
                    Assert.AreEqual(value, BigInteger.Pow(upperSqrt, 2));
                    break;

                case false:
                    Assert.AreNotEqual(upperSqrt, lowerSqrt);
                    Assert.IsTrue(BigInteger.Pow(upperSqrt, 2) > value);
                    Assert.IsTrue(BigInteger.Pow(lowerSqrt, 2) < value);
                    break;
            }
        }
    }
}
