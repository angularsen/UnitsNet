// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

/// <summary>
///     Adds the Pow(Fraction, Fraction) extension method for the Fraction type, which only supports the integer overload:
///     Pow(Fraction, int).
/// </summary>
internal static class FractionExtensions
{
    public static readonly Fraction OneHalf = new(BigInteger.One, new BigInteger(2));

    /// <summary>
    ///     Raises the specified <paramref name="x" /> to the power of <paramref name="power" />.
    /// </summary>
    /// <param name="x">The base <see cref="Fraction" /> to be raised to a power.</param>
    /// <param name="power">The exponent <see cref="Fraction" /> to which the base is raised.</param>
    /// <returns>
    ///     A <see cref="Fraction" /> representing the result of raising <paramref name="x" /> to the power of
    ///     <paramref name="power" />.
    /// </returns>
    /// <remarks>
    ///     This method supports integer exponents directly. For fractional exponents, it calculates the result using
    ///     a double-precision approximation, which may lead to a loss of precision.
    /// </remarks>
    public static Fraction Pow(this Fraction x, Fraction power)
    {
        if (power == Fraction.One)
        {
            return x;
        }

        if (x == Fraction.One)
        {
            return x;
        }

        power = power.Reduce();
        if (power.Denominator.IsOne)
        {
            return Fraction.Pow(x, (int)power);
        }

        // the only way we could reach this line is if we have a fractional power (e.g. square root), or any other custom expression which does not have an inverse.
        // there is currently no call that reaches this line, and we should try to keep it this way (avoiding the potential loss of precision)
        return Fraction.FromDoubleRounded(System.Math.Pow(x.ToDouble(), power.ToDouble()));
    }
}
