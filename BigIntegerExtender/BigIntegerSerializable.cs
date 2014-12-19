using System.Xml;
using System.Xml.Serialization;
using System.Globalization;

namespace System.Numerics
{
    /// <summary>
    /// A wrapper for <c>System.Numerics.BigInteger</c> to support serialization.
    /// </summary>
    [Serializable]
    public struct BigIntegerSerializable : IXmlSerializable
    {
        /// <seealso cref="System.Object.Equals(Object)"/>
        public override bool Equals(object obj)
        {
            if (obj is BigIntegerSerializable)
                return this.Equals((BigIntegerSerializable)obj);

            return this.Value.Equals(obj);
        }

        /// <summary>
        /// Returns a value that indicate whether the current instance
        /// and a specified <c>System.Numerics.BigIntegerSerializable</c> object
        /// have the same value.
        /// </summary>
        /// <param name="biS">The object to compare.</param>
        /// <returns></returns>
        public bool Equals(BigIntegerSerializable biS)
        {
            return this.Value.Equals(biS.Value);
        }

        /// <summary>
        /// Determines whether the specified <c>System.Numerics.BigIntegerSerializable</c> object instances
        /// are considered equal.
        /// </summary>
        /// <param name="biS1">The first <c>System.Numerics.BigIntegerSerializable</c> object to compare.</param>
        /// <param name="biS2">The second <c>System.Numerics.BigIntegerSerializable</c> object to compare.</param>
        /// <seealso cref="System.Numerics.BigIntegerSerializable.Equals(BigIntegerSerializable)" />
        public static bool operator ==(BigIntegerSerializable biS1, BigIntegerSerializable biS2)
        {
            return biS1.Equals(biS2);
        }

        /// <summary>
        /// Determines whether the specified <c>System.Numerics.BigIntegerSerializable</c> object instances
        /// are not considered equal.
        /// </summary>
        /// <param name="biS1">The first <c>System.Numerics.BigIntegerSerializable</c> object to compare.</param>
        /// <param name="biS2">The second <c>System.Numerics.BigIntegerSerializable</c> object to compare.</param>
        public static bool operator !=(BigIntegerSerializable biS1, BigIntegerSerializable biS2)
        {
            return !biS1.Equals(biS2);
        }

        /// <seealso cref="Object.GetHashCode" />
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        /// <summary>
        /// An implicit type conversion operator 
        /// from <c>System.Numerics.BigIntegerSerializable</c> 
        /// to <c>System.Numerics.BigInteger</c>.
        /// </summary>
        /// <param name="value">The <c>System.Numerics.BigIntegerSerializable</c> object to convert.</param>
        public static implicit operator BigInteger(BigIntegerSerializable value)
        {
            return value.Value;
        }

        /// <summary>
        /// An implicit type conversion operator
        /// from <c>System.Numerics.BigInteger</c> 
        /// to <c>System.Numerics.BigIntegerSerializable</c>.
        /// </summary>
        /// <param name="value">The <c>System.Numerics.BigInteger</c> object to convert.</param>
        public static implicit operator BigIntegerSerializable(BigInteger value)
        {
            return new BigIntegerSerializable
                {
                    Value = value
                };
        }


        /// <summary>
        /// An implicit type conversion operator
        /// from <c>System.Int64</c> 
        /// to <c>System.Numerics.BigIntegerSerializable</c>.
        /// </summary>
        /// <param name="value">The <c>System.Int64</c> object to convert.</param>
        public static implicit operator BigIntegerSerializable(Int64 value)
        {
            return new BigIntegerSerializable
                {
                    Value = (BigInteger)value
                };
        }

        /// <summary>Converts the numeric value of the current <c>System.Numerics.BigInteger</c> object
        /// to its equivalent string representation.</summary>
        public override string ToString()
        {
            return this.Value.ToString();
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
