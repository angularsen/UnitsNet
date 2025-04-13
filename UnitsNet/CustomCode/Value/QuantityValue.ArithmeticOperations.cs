using System.Numerics;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    /// <summary>
    ///     Adds two QuantityValue instances.
    /// </summary>
    /// <param name="a">The first QuantityValue.</param>
    /// <param name="b">The second QuantityValue.</param>
    /// <returns>The sum of the two QuantityValue instances.</returns>
    public static QuantityValue operator +(QuantityValue a, QuantityValue b)
    {
        var numerator1 = a.Numerator;
        if (numerator1.IsZero)
        {
            // `a` is either NaN (NaN + b == NaN) or Zero (0 + b == b)
            return a.Denominator.IsZero ? a : b;
        }

        var numerator2 = b.Numerator;
        if (numerator2.IsZero)
        {
            // 'b' is either NaN (a + NaN == NaN) or Zero (a + 0 == a)
            return b.Denominator.IsZero ? b : a;
        }

        // both fractions are non-zero numbers
        var denominator1 = a.Denominator;
        var denominator2 = b.Denominator;

        if (denominator1.IsZero)
        {
            // `a` is (+/-) Infinity
            if (!denominator2.IsZero)
            {
                return a; // Inf + b = Inf
            }

            // adding infinities
            return (numerator1.Sign + numerator2.Sign) switch
            {
                2 => PositiveInfinity,
                -2 => NegativeInfinity,
                _ => NaN
            };
        }

        if (denominator2.IsZero)
        {
            return b; // (+/-) Infinity
        }

        // both values are non-zero
        if (denominator1 == denominator2)
        {
            return new QuantityValue(numerator1 + numerator2, denominator1);
        }

        if (denominator1.IsOne)
        {
            return new QuantityValue(numerator1 * denominator2 + numerator2, denominator2);
        }

        if (denominator2.IsOne)
        {
            return new QuantityValue(numerator1 + numerator2 * denominator1, denominator1);
        }

        var gcd = BigInteger.GreatestCommonDivisor(denominator1, denominator2);
        if (gcd.IsOne)
        {
            return new QuantityValue(numerator1 * denominator2 + numerator2 * denominator1, denominator1 * denominator2);
        }

        if (gcd == denominator1)
        {
            return new QuantityValue(denominator2 / gcd * numerator1 + numerator2, denominator2);
        }

        if (gcd == denominator2)
        {
            return new QuantityValue(numerator1 + denominator1 / gcd * numerator2, denominator1);
        }

        var thisMultiplier = denominator1 / gcd;
        var otherMultiplier = denominator2 / gcd;

        var calculatedNumerator = numerator1 * otherMultiplier + numerator2 * thisMultiplier;
        var leastCommonMultiple = thisMultiplier * denominator2;

        return new QuantityValue(calculatedNumerator, leastCommonMultiple);
    }

    /// <summary>
    ///     Increments the QuantityValue by one.
    /// </summary>
    /// <param name="value">The QuantityValue to be incremented.</param>
    /// <returns>A new QuantityValue that represents the original value incremented by one.</returns>
    public static QuantityValue operator ++(QuantityValue value)
    {
        return value + One;
    }

    /// <summary>
    ///     Subtracts one QuantityValue from another.
    /// </summary>
    /// <param name="a">The QuantityValue to subtract from.</param>
    /// <param name="b">The QuantityValue to subtract.</param>
    /// <returns>The difference between the two QuantityValue instances.</returns>
    public static QuantityValue operator -(QuantityValue a, QuantityValue b)
    {
        return a + -b;
    }

    /// <summary>
    ///     Returns the same value for the given QuantityValue. This unary plus operator doesn't change the value.
    /// </summary>
    /// <param name="value">The QuantityValue to return.</param>
    /// <returns>The same QuantityValue that was passed in.</returns>
    public static QuantityValue operator +(QuantityValue value)
    {
        return value;
    }

    /// <summary>
    ///     Returns the negated value of the operand
    /// </summary>
    /// <param name="v">Value to negate</param>
    /// <returns>-v</returns>
    public static QuantityValue operator -(QuantityValue v)
    {
        return new QuantityValue(-v.Numerator, v.Denominator);
    }

    /// <summary>
    ///     Decrements the value of the specified QuantityValue by one.
    /// </summary>
    /// <param name="value">The QuantityValue to decrement.</param>
    /// <returns>A new QuantityValue that is the value of the input QuantityValue minus one.</returns>
    public static QuantityValue operator --(QuantityValue value)
    {
        return value - One;
    }

    /// <summary>
    ///     Multiplies two QuantityValue instances.
    /// </summary>
    /// <param name="a">The first QuantityValue.</param>
    /// <param name="b">The second QuantityValue.</param>
    /// <returns>The product of the two QuantityValue instances.</returns>
    public static QuantityValue operator *(QuantityValue a, QuantityValue b)
    {
        // we want to skip the multiplications if we know the result is going to be 0/b or a/0
        var numerator1 = a.Numerator;
        var denominator1 = a.Denominator;
        if (denominator1.IsZero)
        {
            // `a` is NaN or Infinity
            return new QuantityValue(numerator1.Sign * b.Numerator.Sign, BigInteger.Zero);
        }

        var numerator2 = b.Numerator;
        var denominator2 = b.Denominator;
        if (denominator2.IsZero)
        {
            // 'b' is NaN or Infinity
            return new QuantityValue(numerator1.Sign * numerator2.Sign, BigInteger.Zero);
        }

        if (numerator1.IsZero || numerator2.IsZero)
        {
            return Zero;
        }

        return new QuantityValue(MultiplyTerms(numerator1, numerator2), MultiplyTerms(denominator1, denominator2));
    }

    private static BigInteger MultiplyTerms(BigInteger a, BigInteger b)
    {
        if (a.IsOne)
        {
            return b;
        }

        return b.IsOne ? a : a * b;
    }

    /// <summary>
    ///     Divides one QuantityValue by another.
    /// </summary>
    /// <param name="a">The QuantityValue to divide.</param>
    /// <param name="b">The QuantityValue to divide by.</param>
    /// <returns>The quotient of the two QuantityValue instances.</returns>
    public static QuantityValue operator /(QuantityValue a, QuantityValue b)
    {
        // we want to skip the multiplications if we know the result is going to be 0/b or a/0
        var numerator2 = b.Numerator;
        var denominator2 = b.Denominator;
        if (denominator2.IsZero)
        {
            // dividing by NaN or Infinity produces NaN or Zero
            return numerator2.IsZero || a.Denominator.IsZero ? NaN : Zero;
        }

        var numerator1 = a.Numerator;
        var denominator1 = a.Denominator;
        if (denominator1.IsZero)
        {
            // `a` is NaN or Infinity
            return numerator1.Sign switch
            {
                // +/- Infinity divided by a number
                1 => numerator2.Sign < 0 ? NegativeInfinity : PositiveInfinity,
                -1 => numerator2.Sign < 0 ? PositiveInfinity : NegativeInfinity,
                // NaN divided by a number
                _ => NaN
            };
        }

        if (numerator1.IsZero)
        {
            return numerator2.IsZero ? NaN : Zero;
        }

        if (numerator2.IsZero)
        {
            return new QuantityValue(numerator1.Sign, BigInteger.Zero);
        }

        // adjust the signs such that the divisor is positive (prevent a negative sign in the resulting denominator)
        if (numerator2.Sign == -1)
        {
            numerator1 = -numerator1;
            numerator2 = -numerator2;
        }

        // attempt to reduce the denominators
        switch (denominator1.CompareTo(denominator2))
        {
            case 1:
            {
                if (denominator2.IsOne)
                {
                    // {123/10} / {456/1}
                    return new QuantityValue(numerator1,
                        numerator2.IsOne ? denominator1 : denominator1 * numerator2);
                }

                var gcd = BigInteger.GreatestCommonDivisor(denominator1, denominator2);
                if (gcd == denominator2)
                {
                    denominator1 /= denominator2;
                    return new QuantityValue(numerator1,
                        numerator2.IsOne ? denominator1 : denominator1 * numerator2);
                }

                if (!gcd.IsOne)
                {
                    denominator1 /= gcd;
                    denominator2 /= gcd;
                }

                var numerator = numerator1.IsOne
                    ? denominator2
                    : numerator1 == BigInteger.MinusOne
                        ? -denominator2
                        : numerator1 * denominator2;

                var denominator = numerator2.IsOne
                    ? denominator1
                    : denominator1 * numerator2;

                return new QuantityValue(numerator, denominator);
            }
            case -1:
            {
                if (denominator1.IsOne)
                {
                    // {123/1} / {456/10}
                    return new QuantityValue(
                        numerator1.IsOne ? denominator2 : numerator1 == BigInteger.MinusOne ? -denominator2 : numerator1 * denominator2,
                        numerator2);
                }

                var gcd = BigInteger.GreatestCommonDivisor(denominator2, denominator1);
                if (gcd == denominator1)
                {
                    denominator2 /= denominator1;
                    return new QuantityValue(
                        numerator1.IsOne ? denominator2 : numerator1 == BigInteger.MinusOne ? -denominator2 : numerator1 * denominator2,
                        numerator2);
                }

                if (!gcd.IsOne)
                {
                    denominator1 /= gcd;
                    denominator2 /= gcd;
                }

                var numerator = numerator1.IsOne
                    ? denominator2
                    : numerator1 == BigInteger.MinusOne
                        ? -denominator2
                        : numerator1 * denominator2;

                var denominator = numerator2.IsOne
                    ? denominator1
                    : denominator1 * numerator2;

                return new QuantityValue(numerator, denominator);
            }
            default:
            {
                return new QuantityValue(numerator1, numerator2);
            }
        }
    }

    /// <summary>
    ///     Returns the remainder of dividing one QuantityValue by another.
    /// </summary>
    /// <param name="a">The QuantityValue to divide.</param>
    /// <param name="b">The QuantityValue to divide by.</param>
    /// <returns>The remainder of the division of the two QuantityValue instances.</returns>
    public static QuantityValue operator %(QuantityValue a, QuantityValue b)
    {
        var numerator1 = a.Numerator;
        var denominator1 = a.Denominator;
        var numerator2 = b.Numerator;
        var denominator2 = b.Denominator;

        if (numerator2.IsZero)
        {
            return NaN; // x / 0 == NaN
        }

        if (numerator1.IsZero)
        {
            return denominator1.IsZero
                ? NaN // 0 / NaN == NaN
                : Zero; // 0 / x == 0 (where x != 0)
        }

        if (denominator1.IsZero)
        {
            // a/0 (infinity)
            return NaN;
        }

        if (denominator2.IsZero)
        {
            // a % infinity
            return a;
        }

        if (denominator1 == denominator2)
        {
            return new QuantityValue(numerator1 % numerator2, denominator1);
        }

        var gcd = BigInteger.GreatestCommonDivisor(denominator1, denominator2);
        if (gcd.IsOne)
        {
            return new QuantityValue(
                numerator1 * denominator2 % (numerator2 * denominator1),
                denominator1 * denominator2);
        }

        if (gcd == denominator1)
        {
            return new QuantityValue(denominator2 / gcd * numerator1 % numerator2, denominator2);
        }

        if (gcd == denominator2)
        {
            return new QuantityValue(numerator1 % (denominator1 / gcd * numerator2), denominator1);
        }

        var thisMultiplier = denominator1 / gcd;
        var otherMultiplier = denominator2 / gcd;

        var leastCommonMultiple = thisMultiplier * denominator2;

        var numerator = numerator1 * otherMultiplier;
        var denominator = numerator2 * thisMultiplier;

        var remainder = numerator % denominator;

        return new QuantityValue(remainder, leastCommonMultiple);
    }
}