// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet;

/// <summary>
///     Provides extension methods for performing operations on <see cref="QuantityValue" /> instances.
/// </summary>
public static class QuantityValueExtensions
{
    /// <summary>
    ///     Sums a collection of <see cref="QuantityValue" /> instances.
    /// </summary>
    /// <param name="values">The collection of <see cref="QuantityValue" /> instances to sum.</param>
    /// <returns>The sum of the <see cref="QuantityValue" /> instances.</returns>
    public static QuantityValue Sum(this IEnumerable<QuantityValue> values)
    {
        return values.Aggregate(QuantityValue.Zero, (total, value) => total + value);
    }

    /// <summary>
    ///     Calculates the average of a collection of <see cref="QuantityValue" /> instances.
    /// </summary>
    /// <param name="values">The collection of <see cref="QuantityValue" /> instances to average.</param>
    /// <returns>The average of the <see cref="QuantityValue" /> instances.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence contains no elements.</exception>
    public static QuantityValue Average(this IEnumerable<QuantityValue> values)
    {
        using IEnumerator<QuantityValue> e = values.GetEnumerator();
        if (!e.MoveNext())
        {
            throw new InvalidOperationException("Sequence contains no elements");
            // throw ExceptionHelper.CreateInvalidOperationOnEmptyCollectionException();
        }

        QuantityValue sum = e.Current;
        if (!e.MoveNext())
        {
            return sum;
        }

        long count = 1;
        do
        {
            sum += e.Current;
            count++;
        } while (e.MoveNext());

        return sum / count;
    }

    /// <summary>
    ///     Converts a logarithmic value to its linear space equivalent.
    /// </summary>
    /// <param name="logValue">The logarithmic value to be converted.</param>
    /// <param name="scalingFactor">The scaling factor used in the conversion. Default is 10.</param>
    /// <returns>The linear space equivalent of the logarithmic value.</returns>
    /// <remarks>
    ///     Most logarithmic operators need a simple scaling factor of 10. However, certain units such as the power ratio
    ///     need to use 20 instead.
    /// </remarks>
    internal static double ToLinearSpace(this QuantityValue logValue, QuantityValue scalingFactor)
    {
        return Math.Pow(10, (logValue / scalingFactor).ToDouble());
    }
    
    internal static QuantityValue ToLinearSpace(this QuantityValue logValue, QuantityValue scalingFactor, byte significantDigits)
    {
        return QuantityValue.FromDoubleRounded(logValue.ToLinearSpace(scalingFactor), significantDigits);
    }

    /// <summary>
    ///     Converts a linear value to its logarithmic space equivalent.
    /// </summary>
    /// <param name="value">The linear value to convert.</param>
    /// <param name="scalingFactor">The scaling factor to apply. Default is 10.</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The logarithmic space equivalent of the input value.</returns>
    /// <remarks>
    ///     Most logarithmic operators need a simple scaling factor of 10. However, certain units such as the power ratio
    ///     need to use 20 instead.
    /// </remarks>
    internal static QuantityValue ToLogSpace(this double value, QuantityValue scalingFactor, byte significantDigits = 15)
    {
        return scalingFactor * QuantityValue.FromDoubleRounded(Math.Log10(value), significantDigits);
    }

    /// <inheritdoc cref="ToLogSpace(double,UnitsNet.QuantityValue,byte)"/>
    internal static QuantityValue ToLogSpace(this QuantityValue value, QuantityValue scalingFactor, byte significantDigits = 15)
    {
        return value.ToDouble().ToLogSpace(scalingFactor, significantDigits);
    }

    /// <summary>
    ///     Adds two <see cref="QuantityValue" /> instances using logarithmic scaling.
    /// </summary>
    /// <param name="leftValue">The first <see cref="QuantityValue" /> to add.</param>
    /// <param name="rightValue">The second <see cref="QuantityValue" /> to add.</param>
    /// <param name="scalingFactor">The scaling factor to use for the logarithmic scaling. Default is 10.</param>
    /// <param name="significantDigits">The number of significant digits to use for the result. Default is 15.</param>
    /// <returns>The sum of the two <see cref="QuantityValue" /> instances, scaled logarithmically.</returns>
    /// <remarks>
    ///     Formula: scalingFactor * log10(10^(thisValue/scalingFactor) + 10^(otherValue/scalingFactor))
    ///     <para>
    ///         Most logarithmic operators need a simple scaling factor of 10. However, certain units such as the power ratio
    ///         need to use 20 instead.
    ///     </para>
    /// </remarks>
    internal static QuantityValue AddWithLogScaling(QuantityValue leftValue, QuantityValue rightValue, QuantityValue scalingFactor, byte significantDigits = 15)
    {
        return (leftValue.ToLinearSpace(scalingFactor) + rightValue.ToLinearSpace(scalingFactor))
            .ToLogSpace(scalingFactor, significantDigits);
    }

    /// <summary>
    ///     Subtract two <see cref="QuantityValue" /> instances using logarithmic scaling.
    /// </summary>
    /// <param name="leftValue">The <see cref="QuantityValue" /> to subtract from.</param>
    /// <param name="rightValue">The <see cref="QuantityValue" /> to subtract.</param>
    /// <param name="scalingFactor">The scaling factor to use for the logarithmic scaling. Default is 10.</param>
    /// <param name="significantDigits">The number of significant digits to use for the result. Default is 15.</param>
    /// <returns>The sum of the two <see cref="QuantityValue" /> instances, scaled logarithmically.</returns>
    /// <remarks>
    ///     Formula: scalingFactor * log10(10^(thisValue/scalingFactor) - 10^(otherValue/scalingFactor))
    ///     <para>
    ///         Most logarithmic operators need a simple scaling factor of 10. However, certain units such as the power ratio
    ///         need to use 20 instead.
    ///     </para>
    /// </remarks>
    internal static QuantityValue SubtractWithLogScaling(QuantityValue leftValue, QuantityValue rightValue, QuantityValue scalingFactor, byte significantDigits = 15)
    {
        return (leftValue.ToLinearSpace(scalingFactor) - rightValue.ToLinearSpace(scalingFactor))
            .ToLogSpace(scalingFactor, significantDigits);
    }
}
