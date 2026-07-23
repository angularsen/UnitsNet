using System.Numerics;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    /// <summary>
    ///     Gets the QuantityValue representing the value zero.
    /// </summary>
    public static QuantityValue Zero { get; } = new(BigInteger.Zero);

    /// <summary>
    ///     Gets the QuantityValue representing the number one.
    /// </summary>
    public static QuantityValue One { get; } = new(BigInteger.One);

    /// <summary>
    /// Gets the constant value representing negative one (-1) as a <see cref="QuantityValue"/>.
    /// </summary>
    /// <remarks>
    /// This property is useful for operations requiring a predefined representation of negative one
    /// in the context of <see cref="QuantityValue"/> arithmetic or comparisons.
    /// </remarks>
    public static QuantityValue MinusOne { get; } = new(BigInteger.MinusOne);

    /// <summary>
    ///     The value representing the positive infinity.
    /// </summary>
    public static QuantityValue PositiveInfinity { get; } = new(BigInteger.One, BigInteger.Zero);

    /// <summary>
    ///     The value representing the negative infinity.
    /// </summary>
    public static QuantityValue NegativeInfinity { get; } = new(BigInteger.MinusOne, BigInteger.Zero);

    /// <summary>
    ///     The value representing the result of dividing zero by zero.
    /// </summary>
    public static QuantityValue NaN { get; } = new(BigInteger.Zero, BigInteger.Zero);

    /// <summary>
    ///     Represents the PI constant as a rational fraction, representing the number 3.141592653589793.
    /// </summary>
    /// <remarks>This is equivalent to calling <code>FromDoubleRounded(Math.PI, 16)</code></remarks>
    public static readonly QuantityValue PI = new(3141592653589793, 1000000000000000);

    internal static readonly BigInteger Ten = new(10); // TODO see about this one


#if NET7_0_OR_GREATER
    static int INumberBase<QuantityValue>.Radix => 10;
    static QuantityValue ISignedNumber<QuantityValue>.NegativeOne => MinusOne;
    static QuantityValue IAdditiveIdentity<QuantityValue, QuantityValue>.AdditiveIdentity => Zero;
    static QuantityValue IMultiplicativeIdentity<QuantityValue, QuantityValue>.MultiplicativeIdentity => One;

    static bool INumberBase<QuantityValue>.IsNormal(QuantityValue value)
    {
        return IsFinite(value);
    }

    static bool INumberBase<QuantityValue>.IsRealNumber(QuantityValue value)
    {
        return !IsNaN(value);
    }

    static bool INumberBase<QuantityValue>.IsComplexNumber(QuantityValue value)
    {
        return false;
    }

    static bool INumberBase<QuantityValue>.IsImaginaryNumber(QuantityValue value)
    {
        return false;
    }

    static bool INumberBase<QuantityValue>.IsSubnormal(QuantityValue value)
    {
        return false;
    }

#endif

    /// <summary>
    ///     Determines whether the given QuantityValue is in canonical form.
    /// </summary>
    /// <param name="value">The QuantityValue to check.</param>
    /// <returns>True if the QuantityValue is in canonical form, otherwise false.</returns>
    /// <remarks>
    ///     A QuantityValue is considered to be in canonical form if its denominator is one,
    ///     or if its numerator and denominator are coprime numbers (their greatest common divisor is one).
    /// </remarks>
    public static bool IsCanonical(QuantityValue value)
    {
        var (numerator, denominator) = value;
        if (denominator.IsOne)
        {
            return true;
        }

        if (numerator.IsZero)
        {
            return denominator.IsZero; // if we want to consider NaN as "canonical"
        }

        if (denominator.IsZero)
        {
            return numerator.IsOne || numerator == BigInteger.MinusOne;
        }

        return BigInteger.GreatestCommonDivisor(numerator, denominator).IsOne;
    }

    /// <summary>
    ///     Determines whether the given <see cref="QuantityValue" /> has a finite decimal expansion.
    /// </summary>
    /// <param name="value">The <see cref="QuantityValue" /> to evaluate.</param>
    /// <returns>
    ///     <c>true</c> if the <paramref name="value" /> has a finite decimal expansion; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     A <see cref="QuantityValue" /> has a finite decimal expansion if its denominator, when reduced to its lowest terms,
    ///     is composed only of the prime factors 2 and/or 5.
    /// </remarks>
    public static bool HasFiniteDecimalExpansion(QuantityValue value)
    {
        BigInteger denominator = Reduce(value).Denominator;
        return HasNonDecimalFactors(denominator);
    }

    /// <summary>
    /// Determines whether the given denominator contains factors other than 2 and 5, 
    /// which are the prime factors of decimal numbers.
    /// </summary>
    /// <param name="denominator">The denominator to check for non-decimal factors.</param>
    /// <returns>
    /// <see langword="true"/> if the denominator contains only factors of 2 and 5; 
    /// otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// This method is used to verify if a number has a finite decimal expansion 
    /// by analyzing its denominator in reduced fractional form.
    /// </remarks>
    public static bool HasNonDecimalFactors(BigInteger denominator)
    {
        if (denominator.IsOne)
        {
            return true;
        }

        if (denominator.IsZero)
        {
            return false;
        }

        BigInteger divisor = Ten;
        while (true)
        {
            var quotient = BigInteger.DivRem(denominator, divisor, out BigInteger remainder);
            if (remainder.IsZero)
            {
                if (quotient.IsOne)
                {
                    return true;
                }

                denominator = quotient;
            }
            else
            {
                break;
            }
        }

        divisor = 5;
        while (true)
        {
            var quotient = BigInteger.DivRem(denominator, divisor, out BigInteger remainder);
            if (remainder.IsZero)
            {
                if (quotient.IsOne)
                {
                    return true;
                }

                denominator = quotient;
            }
            else
            {
                break;
            }
        }
        
        divisor = 2;
        while (true)
        {
            var quotient = BigInteger.DivRem(denominator, divisor, out BigInteger remainder);
            if (remainder.IsZero)
            {
                if (quotient.IsOne)
                {
                    return true;
                }

                denominator = quotient;
            }
            else
            {
                break;
            }
        }

        return false;
    }

    /// <summary>Determines if a value represents an even integral number.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is an even integer; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsEvenInteger(QuantityValue value)
    {
        var (numerator, denominator) = value;
        if (denominator.IsOne)
        {
            return numerator.IsEven;
        }

        if (denominator.IsZero)
        {
            return false;
        }

        // TODO see about first checking the magnitudes
        var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
        return remainder.IsZero && quotient.IsEven;
    }

    /// <summary>Determines if a value is finite.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is finite; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsFinite(QuantityValue value)
    {
        return !value.Denominator.IsZero;
    }

    /// <summary>Determines if a value is infinite.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is infinite; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsInfinity(QuantityValue value)
    {
        return value.Denominator.IsZero && !value.Numerator.IsZero;
    }

    /// <summary>Determines if a value represents an integral number.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is an integer; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsInteger(QuantityValue value)
    {
        var denominator = value.Denominator;
        if (denominator.IsOne)
        {
            return true;
        }

        if (denominator.IsZero)
        {
            return false;
        }

        var numerator = BigInteger.Abs(value.Numerator);
        if (numerator.IsZero)
        {
            return true;
        }

        return numerator >= denominator && (numerator % denominator).IsZero;
    }

    /// <summary>Determines if a value is NaN.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is NaN; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsNaN(QuantityValue value)
    {
        return value.Denominator.IsZero && value.Numerator.IsZero;
    }

    /// <summary>Determines if a value represents a negative real number.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> represents negative zero or a negative real number; otherwise,
    ///     <see langword="false" />.
    /// </returns>
    public static bool IsNegative(QuantityValue value)
    {
        return value.Numerator.Sign < 0;
    }

    /// <summary>Determines if a value is negative infinity.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is negative infinity; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsNegativeInfinity(QuantityValue value)
    {
        return value.Denominator.IsZero && value.Numerator.Sign < 0;
    }

    /// <summary>Determines if a value represents an odd integral number.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is an odd integer; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsOddInteger(QuantityValue value)
    {
        var (numerator, denominator) = value;
        if (denominator.IsOne)
        {
            return !numerator.IsEven;
        }

        if (denominator.IsZero)
        {
            return false;
        }

        // TODO see about first checking the magnitudes
        var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);
        return remainder.IsZero && !quotient.IsEven;
    }

    /// <summary>Determines if a value represents zero or a positive real number.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> represents (positive) zero or a positive real number;
    ///     otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsPositive(QuantityValue value)
    {
        return value.Numerator.Sign > 0;
    }

    /// <summary>Determines if a value is positive infinity.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is positive infinity; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsPositiveInfinity(QuantityValue value)
    {
        return value.Denominator.IsZero && value.Numerator.Sign > 0;
    }

    /// <summary>Determines if a value is zero.</summary>
    /// <param name="value">The value to be checked.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is zero; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsZero(QuantityValue value)
    {
        return value.Numerator.IsZero && !value.Denominator.IsZero;
    }

    /// <summary>
    ///     Returns the absolute value of a specified <see cref="QuantityValue" />.
    /// </summary>
    /// <param name="value">A <see cref="QuantityValue" />.</param>
    /// <returns>The absolute value of <paramref name="value" />.</returns>
    public static QuantityValue Abs(QuantityValue value)
    {
        return new QuantityValue(BigInteger.Abs(value.Numerator), value.Denominator);
    }
}
