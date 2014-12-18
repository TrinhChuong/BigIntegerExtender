using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Primen.UnitTest
{
    [TestClass]
    public class UnitTestBigIntegerExtender
    {
        [TestMethod]
        public void TestNegativeSqrt()
        {
            for (var n = -mersenneN; n < BigInteger.Zero; n++)
            {
                bool isThrown = false;

                try
                {
                    TestSqrt(n);
                }
                catch(ArithmeticException)
                {
                    isThrown = true;
                }
                finally
                {
                    if (!isThrown)
                        Assert.Fail();
                }
            }
                
        }

        [TestMethod]
        public void TestZeroSqrt()
        {
            TestSqrt(BigInteger.Zero);
        }

        [TestMethod]
        public void TestPositiveSqrt()
        {
            for (var n = BigInteger.One; n < mersenneN; n++)
                TestSqrt(n);
        }

        private void TestSqrt(BigInteger value)
        {
            bool lowerIsPerfect;
            var lowerSqrt = ((BigInteger)(value)).Sqrt(out lowerIsPerfect, false);

            bool upperIsPerfect;
            var upperSqrt = ((BigInteger)(value)).Sqrt(out upperIsPerfect, true);

            Assert.AreEqual(lowerIsPerfect, upperIsPerfect);

            switch (lowerIsPerfect)
            {
                case true:
                    Assert.AreEqual(lowerSqrt, upperSqrt);
                    Assert.AreEqual(BigInteger.Pow(lowerSqrt, 2), value);
                    break;

                case false:
                    Assert.AreNotEqual(lowerSqrt, upperSqrt);
                    Assert.AreEqual(lowerSqrt + BigInteger.One, upperSqrt);
                    Assert.IsTrue(BigInteger.Pow(lowerSqrt, 2) < value);
                    Assert.IsTrue(BigInteger.Pow(upperSqrt, 2) > value);
                    break;
            }
        }

        private BigInteger mersenneN = 127;
    }
}
