[assembly: System.CLSCompliant(true)]

namespace System.Numerics
{
    /// <summary>
    /// Extends <c>BigInteger</c> to support the calculation of square roots.
    /// </summary>
    /// <seealso cref="System.Numerics.BigInteger" />
    public static class BigIntegerExtender
    {
        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// <remarks>An extension method for <c>BigInteger</c> that use Newton's method.</remarks>
        /// <param name="value">The <c>BigInteger</c> object whose square root is to be found.</param>
        /// <returns>Returns the square root of <paramref name="value" />.</returns>
        /// <exception cref="System.ArithmeticException">Thrown when <paramref name="value" /> is negative.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sqrt")]
        public static BigInteger Sqrt(this BigInteger value)
        {
            if (value.Sign < 0)
                throw new ArithmeticException("NaN");

            // 0 * 0 = 0.
            // 1 * 1 = 1.
            if (value.IsZero || value.IsOne)
                return value;

            // An initial approximation of the square root of n.
            BigInteger squareRoot = value / 2;

            // Newton's method.
            while (true)
            {
                var lowerBound = BigInteger.Pow(squareRoot, 2);
                var upperSquareRoot = squareRoot + BigInteger.One;
                var upperBound = BigInteger.Pow(upperSquareRoot, 2);

                if (lowerBound == value)
                    return squareRoot;

                else if (upperBound == value)
                    return upperSquareRoot;

                else if ((lowerBound < value) && (upperBound > value))
                    return squareRoot;

                // x_(n+1) = (x_n + S / x_n) / 2
                squareRoot += (value / squareRoot);
                squareRoot /= 2;
            }
        }
    }
}