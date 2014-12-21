using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;

namespace BigIntegerExtenderTests
{
    [TestClass]
    public class BigIntegerSerializableTests
    {
        [TestMethod]
        public void TestEquals()
        {
            BigIntegerSerializable originalValue = BigInteger.One;
            int value1 = int.Parse(originalValue.ToString());
            BigInteger value2 = originalValue;
            Object value3 = originalValue;

            BigIntegerSerializable differentValue = BigInteger.Zero;
            int dValue1 = int.Parse(differentValue.ToString());
            BigInteger dValue2 = differentValue;
            Object dValue3 = differentValue;

            Assert.AreNotEqual(originalValue, differentValue);
            Assert.IsFalse(originalValue == differentValue);
            Assert.IsTrue(originalValue != differentValue);

            Assert.AreEqual(originalValue, value1);
            Assert.AreEqual(originalValue, value2);
            Assert.AreEqual(originalValue, value3);


            Assert.AreNotEqual(originalValue, dValue1);
            Assert.AreNotEqual(originalValue, dValue2);
            Assert.AreNotEqual(originalValue, dValue3);
        }

        [TestMethod]
        public void TestXmlSerialization()
        {
            BigIntegerSerializable value = BigInteger.MinusOne;
            var ms = new MemoryStream();
            var serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(ms, value);

            // Reset the position
            ms.Position = 0;

            value = (BigIntegerSerializable)serializer.Deserialize(ms);
        }

        // It is not a test, 
        // but guarantee that implicit type conversion operators
        // in System.Numerics.BigIntegerSerializable works.
        public void TestImplicitTypeConversionOperator()
        {
            BigIntegerSerializable originalValue = BigInteger.One;
            BigInteger value1 = originalValue;
            originalValue = 1;
        }
    }
}
