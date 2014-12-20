using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace UnitTestBigIntegerExtender
{
    [TestClass]
    public class UnitTestBigIntegerSerializable
    {
        [TestMethod]
        public void TestImplicitOperator()
        {
            BigIntegerSerializable var1 = 3;
            BigIntegerSerializable var2 = BigInteger.One;
            BigInteger var3 = var1;
        }

        [TestMethod]
        public void TestEquals()
        {
            Int64 i = 3;
            BigIntegerSerializable biS = i;
            BigInteger bi = i;
            Object objBiS = biS;
            Object objBi = bi;

            Assert.AreEqual(biS, i);
            Assert.AreEqual(biS, biS);
            Assert.AreEqual(biS, bi);
            Assert.AreEqual(biS, objBiS);
            Assert.AreEqual(biS, objBi);
        }

        [TestMethod]
        public void TestSerialization()
        {
            for (var n = -mersenneN; n < 0; n++)
            {
                BigIntegerSerializable biS = n;
                var mem = new MemoryStream();
                var serializer = new XmlSerializer(biS.GetType());
                try
                {
                    serializer.Serialize(mem, biS);
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }

                BigInteger deserialized = mersenneN;
                try
                {
                    deserialized = (BigIntegerSerializable)serializer.Deserialize(mem);
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }

                Assert.AreEqual(biS, deserialized);
            }
        }

        private BigInteger mersenneN = 127;
    }
}
