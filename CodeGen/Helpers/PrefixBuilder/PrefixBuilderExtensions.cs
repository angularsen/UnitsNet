// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using CodeGen.JsonTypes;

namespace CodeGen.Helpers.PrefixBuilder;

/// <summary>
///     Provides extension methods for working with <see cref="Prefix" />, <see cref="PrefixInfo" />,
///     and <see cref="BaseDimensions" /> types, enabling operations such as determining metric prefixes,
///     calculating decimal exponents, and retrieving non-zero exponents from base dimensions.
/// </summary>
/// <remarks>
///     This static class contains utility methods designed to simplify and enhance the manipulation
///     of prefix-related data and base dimensions in the context of code generation.
/// </remarks>
internal static class PrefixBuilderExtensions
{
    /// <summary>
    ///     Determines whether the specified <see cref="Prefix" /> is a metric prefix.
    /// </summary>
    /// <param name="prefix">The <see cref="Prefix" /> to evaluate.</param>
    /// <returns>
    ///     <c>true</c> if the <paramref name="prefix" /> is a metric prefix (ranging from <see cref="Prefix.Yocto" /> to
    ///     <see cref="Prefix.Yotta" />);
    ///     otherwise, <c>false</c>.
    /// </returns>
    internal static bool IsMetricPrefix(this Prefix prefix)
    {
        return prefix is >= Prefix.Yocto and <= Prefix.Yotta;
    }

    /// <summary>
    ///     Calculates the decimal exponent of a metric prefix factor.
    /// </summary>
    /// <param name="prefix">
    ///     The <see cref="PrefixInfo" /> instance representing the metric prefix whose decimal exponent is to be calculated.
    /// </param>
    /// <returns>
    ///     The decimal exponent as an integer, derived from the logarithm base 10 of the prefix factor.
    /// </returns>
    /// <remarks>
    ///     This method assumes that the factor is a valid numeric string representing a power of ten.
    /// </remarks>
    internal static int GetDecimalExponent(this PrefixInfo prefix)
    {
        return (int)Math.Log10(double.Parse(prefix.Factor.TrimEnd('d'), NumberStyles.Any, CultureInfo.InvariantCulture));
    }

    /// <summary>
    ///     Retrieves all non-zero exponents from the specified <see cref="BaseDimensions" /> instance.
    /// </summary>
    /// <param name="dimensions">
    ///     The <see cref="BaseDimensions" /> instance containing the exponents to evaluate.
    /// </param>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> of integers representing the non-zero exponents in the specified dimensions.
    /// </returns>
    /// <remarks>
    ///     This method iterates through the properties of the <see cref="BaseDimensions" /> instance and yields
    ///     only those exponents that are non-zero. The properties correspond to the base physical dimensions
    ///     such as time (T), length (L), mass (M), electric current (I), absolute temperature (Θ),
    ///     amount of substance (N), and luminous intensity (J).
    /// </remarks>
    internal static IEnumerable<int> GetNonZeroExponents(this BaseDimensions dimensions)
    {
        if (dimensions.I != 0)
        {
            yield return dimensions.I;
        }

        if (dimensions.J != 0)
        {
            yield return dimensions.J;
        }

        if (dimensions.L != 0)
        {
            yield return dimensions.L;
        }

        if (dimensions.M != 0)
        {
            yield return dimensions.M;
        }

        if (dimensions.N != 0)
        {
            yield return dimensions.N;
        }

        if (dimensions.T != 0)
        {
            yield return dimensions.T;
        }

        if (dimensions.Θ != 0)
        {
            yield return dimensions.Θ;
        }
    }
}
