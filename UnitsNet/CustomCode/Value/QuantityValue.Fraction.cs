using System.Numerics;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    /// <summary>
    ///     Deconstructs the QuantityValue object into its numerator and denominator components.
    /// </summary>
    /// <param name="numerator">Output parameter for the numerator component.</param>
    /// <param name="denominator">Output parameter for the denominator component.</param>
    public void Deconstruct(out BigInteger numerator, out BigInteger denominator)
    {
        numerator = Numerator;
        denominator = Denominator;
    }

    /// <summary>
    ///     Calculates and returns the reciprocal of the specified <see cref="QuantityValue" />.
    /// </summary>
    /// <param name="value">A <see cref="QuantityValue" /> whose reciprocal is to be calculated.</param>
    /// <returns>A new <see cref="QuantityValue" /> that is the reciprocal of the input value.</returns>
    /// <remarks>
    ///     In mathematics, a multiplicative inverse or reciprocal for a number x, denoted by 1/x or x^-1, is a
    ///     number
    ///     which when multiplied by x yields the multiplicative identity, 1. The multiplicative inverse of a fraction a/b is
    ///     b/a. For the multiplicative inverse of a real number, divide 1 by the number. For example, the reciprocal of 5 is
    ///     one fifth (1/5 or 0.2), and the reciprocal of 0.25 is 1 divided by 0.25, or 4.
    /// </remarks>
    public static QuantityValue Inverse(QuantityValue value)
    {
        return FromTerms(value.Denominator, value.Numerator);
    }

    /// <summary>
    ///     Reduces the specified <see cref="QuantityValue" /> to its simplest form.
    /// </summary>
    /// <param name="value">The <see cref="QuantityValue" /> to be reduced.</param>
    /// <returns>A new <see cref="QuantityValue" /> that is the reduced form of the input value.</returns>
    public static QuantityValue Reduce(QuantityValue value)
    {
        var numerator = value.Numerator;
        var denominator = value.Denominator;
        if (denominator.IsZero)
        {
            return numerator.Sign switch
            {
                1 => PositiveInfinity,
                -1 => NegativeInfinity,
                _ => NaN
            };
        }

        if (numerator.IsZero)
        {
            return Zero;
        }

        if (numerator.IsOne || denominator.IsOne || numerator == BigInteger.MinusOne)
        {
            return new QuantityValue(numerator, denominator);
        }

        var gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);

        return gcd.IsOne
            ? new QuantityValue(numerator, denominator)
            : new QuantityValue(numerator / gcd, denominator / gcd);
    }
}
