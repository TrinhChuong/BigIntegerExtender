[assembly: System.CLSCompliant(true)]

namespace System.Numerics
{
    /// <summary>
    /// Extends <c>System.Numerics.BigInteger</c> to support the calculation of square roots.
    /// </summary>
    public static class BigIntegerExtender
    {
        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// <remarks>An extension method for <c>System.Numerics.BigInteger</c>.</remarks>
        /// <param name="value">The number whose square root is to be found.</param>
        /// <param name="isPerfect">If <c>BigInteger.Pow(value.Sqrt(), 2) = value</c> it is <c>true</c>, otherwise it is <c>false</c>.</param>
        /// <param name="ceiling">If the square root is not perfect, it rounds up it if it is <c>true</c>.</param>
        /// <exception cref="System.ArithmeticException">Thrown when <paramref name="value" /> is negative.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#"), 
            System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"),
            System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sqrt")]
        public static BigInteger Sqrt(this BigInteger value, out bool isPerfect, bool ceiling = true)
        {
            if (value.Sign < 0)
                throw new ArithmeticException("NaN");

            // 0 * 0 = 0.
            // 1 * 1 = 1.
            if (value.IsZero || value.IsOne)
            {
                isPerfect = true;
                return value;
            }

            // An initial approximation of the square root of n.
            BigInteger squareRoot = value / 2;

            // It uses Newton's method.
            while (true)
            {
                var lowerBound = BigInteger.Pow(squareRoot, 2);

                if (lowerBound == value)
                {
                    isPerfect = true;
                    return squareRoot;
                }

                var upperSquareRoot = squareRoot + BigInteger.One;
                var upperBound = BigInteger.Pow(upperSquareRoot, 2);

                if ((lowerBound < value) && (upperBound > value))
                {
                    isPerfect = false;

                    if (ceiling)
                        return upperSquareRoot;
                    else
                        return squareRoot;
                }
                
                // x_(n+1) = (x_n + S / x_n) / 2
                squareRoot += (value / squareRoot);
                squareRoot /= 2;
            }
        }

        /// <summary>
        /// Returns the square root of a specified number.
        /// </summary>
        /// <remarks>An extension method for <c>System.Numerics.BigInteger</c>.</remarks>
        /// <param name="value">The number whose square root is to be found.</param>
        /// <param name="ceiling">If the square root is not perfect, it rounds up it if it is <c>true</c>.</param>
        /// <exception cref="System.ArithmeticException">Thrown when <paramref name="value" /> is negative.</exception>
        /// <seealso cref="BigIntegerExtender.Sqrt(BigInteger, out bool, bool)" />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), 
            System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sqrt")]
        public static BigInteger Sqrt(this BigInteger value, bool ceiling = true)
        {
            bool isPerfect;
            return value.Sqrt(out isPerfect, ceiling);
        }
    }
}
