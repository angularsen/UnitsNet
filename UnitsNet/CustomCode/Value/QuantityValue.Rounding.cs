using System.Numerics;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    /// <summary>
    ///     Rounds the given QuantityValue to the specified number of digits.
    /// </summary>
    /// <param name="x">The QuantityValue to be rounded.</param>
    /// <param name="nbDigits">The number of decimal places in the return value.</param>
    /// <returns>A new QuantityValue that is the nearest number with the specified number of digits.</returns>
    public static QuantityValue Round(QuantityValue x, int nbDigits)
    {
        return Round(x, nbDigits, MidpointRounding.ToEven);
    }

    /// <summary>
    ///     Rounds the given QuantityValue to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="x">The QuantityValue to be rounded.</param>
    /// <param name="decimals">The number of significant decimal places (precision) in the return value.</param>
    /// <param name="mode">Specifies the strategy that mathematical rounding methods should use to round a number.</param>
    /// <returns>
    ///     The number that <paramref name="x" /> is rounded to using the <paramref name="mode" /> rounding strategy and
    ///     with a precision of <paramref name="decimals" />. If the precision of <paramref name="x" /> is less than
    ///     <paramref name="decimals" />, <paramref name="x" /> is returned unchanged.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">If <paramref name="decimals" /> is less than 0</exception>
    public static QuantityValue Round(QuantityValue x, int decimals, MidpointRounding mode)
    {
#if NET
        ArgumentOutOfRangeException.ThrowIfNegative(decimals);
#else
        if (decimals < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(decimals));
        }
#endif
        return Round(x.Numerator, x.Denominator, decimals, mode);
    }

    internal static QuantityValue Round(BigInteger numerator, BigInteger denominator, int decimals, MidpointRounding mode)
    {
        if (numerator.IsZero)
        {
            return new QuantityValue(numerator, denominator);
        }

        if (denominator.IsOne || denominator.IsZero)
        {
            return new QuantityValue(numerator, denominator);
        }

        var factor = PowerOfTen(decimals);
        var roundedNumerator = RoundToBigInteger(numerator * factor, denominator, mode);
        return new QuantityValue(roundedNumerator, factor);
    }

    /// <summary>
    ///     Rounds the given QuantityValue to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="fraction">The QuantityValue to be rounded.</param>
    /// <param name="mode">Specifies the strategy that mathematical rounding methods should use to round a number.</param>
    /// <returns>
    ///     The number as <see cref="BigInteger" /> that <paramref name="fraction" /> is rounded to using the
    ///     <paramref name="mode" /> rounding strategy.
    /// </returns>
    /// <exception cref="OverflowException">Thrown when the input is <see cref="NaN"/>, <see cref="PositiveInfinity"/> or <see cref="NegativeInfinity"/>.</exception>
    public static BigInteger Round(QuantityValue fraction, MidpointRounding mode)
    {
        return RoundToBigInteger(fraction.Numerator, fraction.Denominator, mode);
    }

    /// <summary>
    ///     Rounds the given QuantityValue to the specified precision using the specified rounding strategy.
    /// </summary>
    /// <param name="numerator">The numerator of the fraction to be rounded.</param>
    /// <param name="denominator">The denominator of the fraction to be rounded.</param>
    /// <param name="mode">Specifies the strategy that mathematical rounding methods should use to round a number.</param>
    /// <returns>The number rounded to using the <paramref name="mode" /> rounding strategy.</returns>
    /// <exception cref="OverflowException">Thrown when given Zero for the denominator.</exception>
    private static BigInteger RoundToBigInteger(BigInteger numerator, BigInteger denominator, MidpointRounding mode)
    {
        if (denominator.IsZero)
        {
            throw new OverflowException();
        }

        if (numerator.IsZero || denominator.IsOne)
        {
            return numerator;
        }

        return mode switch
        {
            MidpointRounding.AwayFromZero => RoundAwayFromZero(numerator, denominator),
            MidpointRounding.ToEven => RoundToEven(numerator, denominator),
#if NET
            MidpointRounding.ToZero => BigInteger.Divide(numerator, denominator),
            MidpointRounding.ToPositiveInfinity => RoundToPositiveInfinity(numerator, denominator),
            MidpointRounding.ToNegativeInfinity => RoundToNegativeInfinity(numerator, denominator),
#endif
            _ => throw new ArgumentOutOfRangeException(nameof(mode))
        };

        static BigInteger RoundAwayFromZero(BigInteger numerator, BigInteger denominator)
        {
            var halfDenominator = denominator >> 1;
            return numerator.Sign == 1
                ? BigInteger.Divide(numerator + halfDenominator, denominator)
                : BigInteger.Divide(numerator - halfDenominator, denominator);
        }

        static BigInteger RoundToEven(BigInteger numerator, BigInteger denominator)
        {
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
            if (remainder.IsZero)
            {
                return quotient;
            }

            if (numerator.Sign == 1)
            {
                // Both values are positive
                var midpoint = remainder << 1;
                if (midpoint > denominator || (midpoint == denominator && !quotient.IsEven))
                {
                    return quotient + BigInteger.One;
                }
            }
            else
            {
                // For negative values
                var midpoint = -remainder << 1;
                if (midpoint > denominator || (midpoint == denominator && !quotient.IsEven))
                {
                    return quotient - BigInteger.One;
                }
            }

            return quotient;
        }
#if NET
        static BigInteger RoundToPositiveInfinity(BigInteger numerator, BigInteger denominator)
        {
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
            return remainder.Sign == 1 ? quotient + BigInteger.One : quotient;
        }

        static BigInteger RoundToNegativeInfinity(BigInteger numerator, BigInteger denominator)
        {
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
            return remainder.Sign == -1 ? quotient - BigInteger.One : quotient;
        }
#endif
    }
}
