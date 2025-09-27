// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

/// <summary>
///     We should try to push these extensions to the original library (working on the PRs)
/// </summary>
internal static class FractionExtensions
{
    public static readonly Fraction OneHalf = new(BigInteger.One, new BigInteger(2));
    public static readonly BigInteger Ten = new(10);

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

        // return FromDoubleRounded(System.Math.Pow(x.ToDouble(), power.ToDouble()));
        return PowRational(x, power);
    }

    private static Fraction PowRational(this Fraction x, Fraction power)
    {
        var numeratorRaised = Fraction.Pow(x, (int)power.Numerator);
        return numeratorRaised.Root((int)power.Denominator, 30);
    }

    public static Fraction Root(this Fraction number, int n, int nbDigits)
    {
        var precision = BigInteger.Pow(10, nbDigits);
        // Fraction x = number; // Initial guess
        var initialGuess = System.Math.Pow(number.ToDouble(), 1.0 / n);
        Fraction x = initialGuess == 0.0 ? number : FromDoubleRounded(initialGuess);
        Fraction xPrev;
        var minChange = new Fraction(1, precision);
        do
        {
            xPrev = x;
            x = ((n - 1) * x + number / Fraction.Pow(x, n - 1)) / n;
        } while ((x - xPrev).Abs() > minChange);

        return Fraction.Round(x, nbDigits);
    }

    /// <summary>
    ///     <inheritdoc cref="Fraction.FromDoubleRounded(double,int)" />
    /// </summary>
    public static Fraction FromDoubleRounded(double value, int nbSignificantDigits = 15)
    {
        return Fraction.FromDoubleRounded(value, nbSignificantDigits);
    }
}
