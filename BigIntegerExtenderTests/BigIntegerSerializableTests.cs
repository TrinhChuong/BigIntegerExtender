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
            BigInteger originalValueToBigInteger = originalValue;
            Object originalValueToObject = originalValue;

            BigIntegerSerializable differentValue = BigInteger.Zero;
            BigInteger differentValueToBigInteger = differentValue;
            Object differentValueToObject = differentValue;

            Assert.AreNotEqual(originalValue, differentValue);
            Assert.IsTrue(originalValue != differentValue);
            Assert.IsFalse(originalValue == differentValue);

            Assert.AreEqual(originalValue, originalValueToBigInteger);
            Assert.AreEqual(originalValue, originalValueToObject);

            Assert.AreNotEqual(originalValue, differentValueToBigInteger);
            Assert.AreNotEqual(originalValue, differentValueToObject);
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
    }
}
