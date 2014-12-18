using System.Xml;
using System.Xml.Serialization;
using System.Globalization;

namespace System.Numerics
{
    /// <summary>A wrapper for <c>System.Numerics.BigInteger</c>.</summary>
    [Serializable]
    public struct BigIntegerSerializable : IXmlSerializable
    {
        public override bool Equals(object obj)
        {
            if (obj is BigIntegerSerializable)
                return this.Equals((BigIntegerSerializable)obj);

            return this.Value.Equals(obj);
        }

        public bool Equals(BigIntegerSerializable biS)
        {
            return this.Value.Equals(biS.Value);
        }

        public static bool operator ==(BigIntegerSerializable biS1, BigIntegerSerializable biS2)
        {
            return biS1.Equals(biS2);
        }

        public static bool operator !=(BigIntegerSerializable biS1, BigIntegerSerializable biS2)
        {
            return !biS1.Equals(biS2);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static implicit operator BigInteger(BigIntegerSerializable value)
        {
            return value.Value;
        }

        public static implicit operator BigIntegerSerializable(BigInteger value)
        {
            return new BigIntegerSerializable
                {
                    Value = value
                };
        }

        public static implicit operator BigIntegerSerializable(Int64 value)
        {
            return new BigIntegerSerializable
                {
                    Value = (BigInteger)value
                };
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public BigInteger ToBigInteger()
        {
            return this.Value;
        }

        Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="reader" /> is <c>null</c>.</exception>
        /// <exception cref="System.FormatException">Thrown when <paramref name="reader" /> is not a string rapresentation of a number.</exception>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            this.Value = BigInteger.Parse(reader.ReadString(), CultureInfo.InvariantCulture);
        }

        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="writer" /> is <c>null</c>.</exception>
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            writer.WriteValue(this.Value.ToString(CultureInfo.InvariantCulture));
        }

        private BigInteger Value;
    }
}
