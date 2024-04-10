// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.Serialization;
using Fractions;

namespace UnitsNet;

/// <summary>
///     A type that supports implicit cast from all .NET numeric types, in order to avoid a large number of overloads
///     and binary size for all From(value, unit) factory methods, for each of the 700+ units in the library.
///     <see cref="QuantityValue" /> stores the value internally using a fraction represented by two
///     <see cref="BigInteger" />, allowing it to represent arbitrary values without loss of precision.
/// </summary>
/// <remarks>
///     <para>
///         At the time of this writing, this reduces the number of From(value, unit) overloads to 1/4th:
///         From 8 (int, long, double, decimal + each nullable) down to 2 (QuantityValue and QuantityValue?).
///         This also adds more numeric types with no extra overhead, such as float, short and byte.
///     </para>
/// </remarks>
[DataContract]
[TypeConverter(typeof (QuantityValueTypeConverter))]
public readonly partial struct QuantityValue : IFormattable, IConvertible, IEquatable<QuantityValue>, IComparable<QuantityValue>, IComparable
{
    /// <summary>
    ///     The value 0
    /// </summary>
    public static readonly QuantityValue Zero = new(Fraction.Zero);

    [DataMember(Name = "Fraction")]
    private readonly Fraction _fraction; // TODO the struct is missing the [DataContract] definition
    
    private QuantityValue(Fraction value)
    {
        _fraction = value;
    }

    /// <summary>
    ///     Construct using a value <paramref name="numerator" /> and <paramref name="denominator" />.
    /// </summary>
    /// <param name="numerator">Numerator</param>
    /// <param name="denominator">Denominator</param>
    public QuantityValue(BigInteger numerator, BigInteger denominator)
    {
        _fraction = new Fraction(numerator, denominator, true);
    }

    /// <summary>
    ///     Construct using a value <paramref name="numerator" /> and <paramref name="denominator" />.
    /// </summary>
    /// <param name="numerator">Numerator</param>
    /// <param name="denominator">Denominator</param>
    /// <param name="normalize">If <c>true</c> the fraction will be created as reduced/simplified fraction. </param>
    /// <remarks>Turning off the normalization is only allowed as part of an intermediate calculation (1/2 != 2/4).</remarks>
    internal QuantityValue(BigInteger numerator, BigInteger denominator, bool normalize)
    {
        _fraction = new Fraction(numerator, denominator, normalize);
    }

    /// <summary>
    ///     Deconstructs the QuantityValue object into its numerator and denominator components.
    /// </summary>
    /// <param name="numerator">Output parameter for the numerator component.</param>
    /// <param name="denominator">Output parameter for the denominator component.</param>
    public void Deconstruct(out BigInteger numerator, out BigInteger denominator)
    {
        numerator = _fraction.Numerator;
        denominator = _fraction.Denominator;
    }


    #region Math Operators

    /// <summary>
    ///     Adds two QuantityValue instances.
    /// </summary>
    /// <param name="a">The first QuantityValue.</param>
    /// <param name="b">The second QuantityValue.</param>
    /// <returns>The sum of the two QuantityValue instances.</returns>
    public static QuantityValue operator +(QuantityValue a, QuantityValue b)
    {
        return new QuantityValue(a._fraction + b._fraction);
    }

    /// <summary>
    ///     Subtracts one QuantityValue from another.
    /// </summary>
    /// <param name="a">The QuantityValue to subtract from.</param>
    /// <param name="b">The QuantityValue to subtract.</param>
    /// <returns>The difference between the two QuantityValue instances.</returns>
    public static QuantityValue operator -(QuantityValue a, QuantityValue b)
    {
        return new QuantityValue(a._fraction - b._fraction);
    }

    /// <summary>
    ///     Returns the negated value of the operand
    /// </summary>
    /// <param name="v">Value to negate</param>
    /// <returns>-v</returns>
    public static QuantityValue operator -(QuantityValue v)
    {
        return new QuantityValue(-1 * v._fraction);
    }

    /// <summary>
    ///     Multiplies two QuantityValue instances.
    /// </summary>
    /// <param name="a">The first QuantityValue.</param>
    /// <param name="b">The second QuantityValue.</param>
    /// <returns>The product of the two QuantityValue instances.</returns>
    public static QuantityValue operator *(QuantityValue a, QuantityValue b)
    {
        return new QuantityValue(a._fraction * b._fraction);
    }

    /// <summary>
    ///     Divides one QuantityValue by another.
    /// </summary>
    /// <param name="a">The QuantityValue to divide.</param>
    /// <param name="b">The QuantityValue to divide by.</param>
    /// <returns>The quotient of the two QuantityValue instances.</returns>
    public static QuantityValue operator /(QuantityValue a, QuantityValue b)
    {
        return new QuantityValue(a._fraction / b._fraction);
    }

    /// <summary>
    ///     Returns the remainder of dividing one QuantityValue by another.
    /// </summary>
    /// <param name="a">The QuantityValue to divide.</param>
    /// <param name="b">The QuantityValue to divide by.</param>
    /// <returns>The remainder of the division of the two QuantityValue instances.</returns>
    public static QuantityValue operator %(QuantityValue a, QuantityValue b)
    {
        return new QuantityValue(a._fraction % b._fraction);
    }

    /// <summary>
    ///     Raises a QuantityValue to the specified power.
    /// </summary>
    /// <param name="a">The QuantityValue to raise to the power.</param>
    /// <param name="power">The power to raise the QuantityValue to.</param>
    /// <returns>The QuantityValue raised to the specified power.</returns>
    public static QuantityValue operator ^(QuantityValue a, int power)
    {
        return new QuantityValue(Fraction.Pow(a._fraction, power));
    }

    /// <summary>
    ///     Raises a QuantityValue to the specified power.
    /// </summary>
    /// <param name="a">The QuantityValue to raise to the power.</param>
    /// <param name="power">The power to raise the QuantityValue to.</param>
    /// <returns>The QuantityValue raised to the specified power.</returns>
    public static QuantityValue Pow(QuantityValue a, int power)
    {
        return a ^ power;
    }

    /// <summary>
    ///     Calculates the square root of a given QuantityValue.
    /// </summary>
    /// <param name="a">The QuantityValue for which to calculate the square root.</param>
    /// <param name="accuracy">The number of decimal places of accuracy for the square root calculation. Default is 30.</param>
    /// <returns>A new QuantityValue that is the square root of the input QuantityValue.</returns>
    /// <exception cref="OverflowException">Thrown when the input QuantityValue is negative.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the accuracy is less than or equal to zero.</exception>
    /// <remarks>
    ///     Uses Babylonian Method of computing square roots: increasing the accuracy would result in longer calculation
    ///     times.
    /// </remarks>
    public static QuantityValue Sqrt(QuantityValue a, int accuracy = 30)
    {
        return new QuantityValue(a._fraction.Sqrt(accuracy));
    }

    /// <summary>
    ///     Returns the absolute value of a specified <see cref="QuantityValue" />.
    /// </summary>
    /// <param name="value">A <see cref="QuantityValue" />.</param>
    /// <returns>The absolute value of <paramref name="value" />.</returns>
    public static QuantityValue Abs(QuantityValue value)
    {
        return new QuantityValue(Fraction.Abs(value._fraction));
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
        return new QuantityValue(value._fraction.Reciprocal());
    }

    /// <summary>
    ///     Rounds the given QuantityValue to the specified number of digits.
    /// </summary>
    /// <param name="x">The QuantityValue to be rounded.</param>
    /// <param name="nbDigits">The number of decimal places in the return value.</param>
    /// <returns>A new QuantityValue that is the nearest number with the specified number of digits.</returns>
    public static QuantityValue Round(QuantityValue x, int nbDigits)
    {
        var factor = BigInteger.Pow(10, nbDigits);
        BigInteger numerator = x._fraction.Numerator * factor;
        BigInteger denominator = x._fraction.Denominator;
        BigInteger roundedNumerator;
        roundedNumerator = numerator.Sign < 0
            ? BigInteger.Divide(numerator - denominator / 2, denominator)
            : BigInteger.Divide(numerator + denominator / 2, denominator);

        return new QuantityValue(roundedNumerator, factor);
    }


    #endregion
    
}
