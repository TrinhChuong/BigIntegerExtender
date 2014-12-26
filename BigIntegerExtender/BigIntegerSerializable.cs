using System.Diagnostics.Contracts;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace System.Numerics
{
    /// <summary>
    /// A wrapper for <c>BigInteger</c> to support serialization.
    /// </summary>
    /// <seealso cref="System.Numerics.BigInteger" />
    [Serializable]
    public struct BigIntegerSerializable : IXmlSerializable, IEquatable<BigIntegerSerializable>
    {
        #region Equals
        /// <summary>
        /// Returns a value that indicates whether the current instance and a specified object have the same value.
        /// </summary>
        /// <remarks>
        /// If the <c>obj</c> parameter is not a <c>BigIntegerSerializable</c> value,
        /// but it is a data type for which an implicit conversion is defined,
        /// the <c>Equals(Object)</c> method converts <c>obj</c> to a <c>BigIntegerSerializable</c> value
        /// before it performs the comparison.
        /// </remarks>
        /// <param name="obj">The object to compare.</param>
        /// <returns>
        /// <c>true</c> if the <c>obj</c> parameter is a <c>BigIntegerSerializable</c> object
        /// or a type capable of implicit conversion to a <c>BigIntegerSerializable</c> value,
        /// and its value is equal to the value of the current <c>BigIntegerSerializable</c> object;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            else if (obj is BigIntegerSerializable)
                return this.Value.Equals(((BigIntegerSerializable)obj).Value);

            return this.Value.Equals(obj);
        }

        /// <summary>
        /// Returns a value that indicates whether the current instance
        /// and a specified <c>BigIntegerSerializable</c> object have the same value.
        /// </summary>
        /// <remarks>
        /// This method implements the <c>IEquatable</c> interface
        /// and performs slightly better than <c>Equals(Object)</c>
        /// because it does not have to convert the other parameter
        /// to a <c>BigIntegerSerializable</c> object.
        /// </remarks>
        /// <param name="other">The object to compare.</param>
        /// <returns>
        /// <c>true</c> if this <c>BigIntegerSerializable</c> object and other have the same value;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool IEquatable<BigIntegerSerializable>.Equals(BigIntegerSerializable other)
        {
            return this.Value.Equals(other.Value);
        }
        #endregion

        #region ImplicitOperators
        /// <summary>
        /// Returns a value that indicates whether the values
        /// of two <c>BigIntegerSerializable</c> objects are equal.
        /// </summary>
        /// <remarks>
        /// Languages that do not support custom operators
        /// can call the <c>BigIntegerSerializable.Equals(BigIntegerSerializable)</c> instance method instead.
        /// </remarks>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if the left and right parameters have the same value;
        /// otherwise, <c>false</c>.</returns>
        public static bool operator ==(BigIntegerSerializable left, BigIntegerSerializable right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Returns a value that indicates whether
        /// two <c>BigIntegerSerializable</c> objects have different values.
        /// </summary>
        /// <remarks>
        /// Languages that do not support custom operators
        /// can call the <c>BigIntegerSerializable.Equals(BigIntegerSerializable)</c> method
        /// and reversing its value.
        /// </remarks>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if the left and right parameters have different values;
        /// otherwise, <c>true</c>.</returns>
        public static bool operator !=(BigIntegerSerializable left, BigIntegerSerializable right)
        {
            return !left.Equals(right);
        }
        
        /// <summary>
        /// Defines an explicit conversion of a <c>BigIntegerSerializable</c> object
        /// to a <c>BigInteger</c> object.
        /// </summary>
        /// <param name="value">The value to convert to a <c>BigInteger</c> object.</param>
        /// <returns>An object that contains the value of the <c>value</c> parameter.</returns>
        public static implicit operator BigInteger(BigIntegerSerializable value)
        {
            return value.Value;
        }

        /// <summary>
        /// Defines an explicit conversion of a <c>BigInteger</c> object
        /// to a <c>BigIntegerSerializable</c> object.
        /// </summary>
        /// <param name="value">The value to convert to a <c>BigIntegerSerializable</c> object.</param>
        /// <returns>An object that contains the value of the <c>value</c> parameter.</returns>
        public static implicit operator BigIntegerSerializable(BigInteger value)
        {
            return new BigIntegerSerializable
            {
                Value = value
            };
        }
        #endregion

        #region IXmlSerializable
        /// <returns>Returns <c>null</c>.</returns>
        /// <seealso cref="System.Xml.Serialization.IXmlSerializable.GetSchema()" />
        Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates a <c>BigIntegerSerializable</c> object from its XML representation.
        /// </summary>
        /// <param name="reader">The XmlReader stream from which the object is deserialized. </param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="reader" /> is <c>null</c>.</exception>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            this.Value = BigInteger.Parse(reader.ReadString(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a <c>BigIntegerSerializable</c> object into its XML representation.
        /// </summary>
        /// <param name="writer">The <c>XmlWriter</c> stream to which the object is serialized.</param>
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteValue(this.Value.ToString(CultureInfo.InvariantCulture));
        }
        #endregion

        /// <summary>
        /// Returns the hash code for the current <c>BigIntegerSerializable</c> object.
        /// </summary>
        /// <remarks>It is equal calling <c>((BigInteger)this).GetHashCode()</c>.</remarks>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of the current <c>BigIntegerSerializable</c> object
        /// to its equivalent string representation.
        /// </summary>
        /// <remarks>
        /// For better ToString methods, <see cref="System.Numerics.BigInteger.ToString(IFormatProvider)" />,
        /// <see cref="System.Numerics.BigInteger.ToString(String)" />,
        /// <see cref="System.Numerics.BigInteger.ToString(String, IFormatProvider)" />.
        /// </remarks>
        /// <returns>The string representation of the current <c>BigIntegerSerializable</c> value.</returns>
        /// <seealso cref="System.Numerics.BigInteger.ToString()" />
        public override string ToString()
        {
            return this.Value.ToString();
        }
        
        private BigInteger Value;
    }
}