// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet;

/// <summary>
///     Provides extension methods for logarithmic quantities, enabling operations such as equality checks,
///     summation, arithmetic mean, and geometric mean calculations.
/// </summary>
public static class LogarithmicQuantityExtensions
{
    /// <inheritdoc cref="EqualsAbsolute{TQuantity,TOther,TTolerance}" />
    public static bool Equals<TQuantity, TOther, TTolerance>(this TQuantity quantity, TOther? other, TTolerance tolerance)
        where TQuantity : ILogarithmicQuantity<TQuantity>
        where TOther : IQuantityInstance<TQuantity>
        where TTolerance : IQuantityInstance<TQuantity>
    {
        return other is not null && quantity.EqualsAbsolute(other, tolerance);
    }

    /// <inheritdoc cref="EqualsAbsolute{TQuantity,TOther,TTolerance}" />
    /// <exception cref="ArgumentException">
    ///     Thrown when the <paramref name="tolerance" /> is not of the same type as the
    ///     <paramref name="quantity" />.
    /// </exception>
    public static bool Equals<TQuantity>(this TQuantity quantity, IQuantity? other, IQuantity tolerance)
        where TQuantity : ILogarithmicQuantity<TQuantity>
    {
        if (other is not TQuantity otherInstance)
        {
            return false;
        }

        // TODO see about this (I think the exception should take precedence to the null check, but the QuantityTests disagree)
        if (tolerance is not TQuantity toleranceQuantity)
        {
            throw ExceptionHelper.CreateArgumentException<TQuantity>(tolerance, nameof(tolerance));
        }

        return quantity.EqualsAbsolute(otherInstance, toleranceQuantity);
    }

    /// <summary>
    ///     <para> Compares the logarithmic equality of the current quantity to another quantity, given a specified tolerance. </para>
    ///     <example>
    ///         In this example, the two power ratios will be considered equal if the value of `b` is within 0.5 decibels of
    ///         `a`.
    ///         <code>
    ///     var a = PowerRatio.FromDecibelMilliwatts(30);   // Reference power of 1 mW
    ///     var b = PowerRatio.FromDecibelMilliwatts(29.8); // Slightly less than `a`
    ///     var tolerance = PowerRatio.FromDecibelMilliwatts(0.5);  // 0.5 dBm tolerance
    ///     a.Equals(b, tolerance); // true, as 30 dBm equals 29.8 dBm +/- 0.5 dBm
    ///     </code>
    ///     </example>
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity being compared.</typeparam>
    /// <typeparam name="TOther">The type of the other quantity being compared.</typeparam>
    /// <typeparam name="TTolerance">The type of the tolerance value.</typeparam>
    /// <param name="quantity">The logarithmic quantity to compare.</param>
    /// <param name="other">The other quantity to compare to.</param>
    /// <param name="tolerance">The tolerance value for the maximum allowed difference.</param>
    /// <returns>
    ///     True if the absolute difference between the two quantities, when converted to linear space, is not greater
    ///     than the specified tolerance.
    /// </returns>
    /// <exception cref="UnitNotFoundException">Thrown when no unit information is found for one of the specified enum value.</exception>
    /// <remarks>
    ///     This method converts the quantities and the tolerance to linear space before performing the comparison, an
    ///     operation which doesn't produce an exact value.
    ///     <para>
    ///         It is generally advised against specifying "zero" tolerance, preferring the use of the default equality
    ///         comparer, which is significantly more performant.
    ///     </para>
    /// </remarks>
    public static bool EqualsAbsolute<TQuantity, TOther, TTolerance>(this TQuantity quantity, TOther other, TTolerance tolerance)
        where TQuantity : ILogarithmicQuantity<TQuantity>
        where TOther : IQuantityInstance<TQuantity>
        where TTolerance : IQuantityInstance<TQuantity>
    {
        UnitKey quantityUnit = quantity.UnitKey;
#if NET
        QuantityValue scalingFactor = TQuantity.LogarithmicScalingFactor;
#else
        QuantityValue scalingFactor = quantity.LogarithmicScalingFactor;
#endif
        var valueInLinearSpace = quantity.Value.ToLinearSpace(scalingFactor);
        var otherValueInLinearSpace = other.GetValue(quantityUnit).ToLinearSpace(scalingFactor);
        var toleranceInLinearSpace = Math.Abs(tolerance.GetValue(quantityUnit).ToLinearSpace(scalingFactor));
        return Math.Abs(valueInLinearSpace - otherValueInLinearSpace) <= toleranceInLinearSpace;
    }

    /// <summary>
    ///     Sums a sequence of logarithmic quantities, such as PowerRatio and AmplitudeRatio.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the logarithmic quantity.</typeparam>
    /// <param name="quantities">The sequence of logarithmic quantities to sum.</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The sum of the logarithmic quantities in the unit of the first element in the sequence.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, each quantity is converted to linear space (in the unit of the first element),
    ///     summed, and then the result is converted back to logarithmic space using the same unit.
    /// </remarks>
    public static TQuantity Sum<TQuantity>(this IEnumerable<TQuantity> quantities, byte significantDigits = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity>
    {
        if (quantities is null)
        {
            throw new ArgumentNullException(nameof(quantities));
        }
        
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw ExceptionHelper.CreateInvalidOperationOnEmptyCollectionException();
        }

        TQuantity firstQuantity = enumerator.Current!;
#if NET
        QuantityValue logarithmicScalingFactor = TQuantity.LogarithmicScalingFactor;
#else
        QuantityValue logarithmicScalingFactor = firstQuantity.LogarithmicScalingFactor;
#endif
        UnitKey resultUnit = firstQuantity.UnitKey;
        var resultValue = firstQuantity.Value.ToLinearSpace(logarithmicScalingFactor);
        while (enumerator.MoveNext())
        {
            resultValue += enumerator.Current!.GetValue(resultUnit).ToLinearSpace(logarithmicScalingFactor);
        }
#if NET
        return TQuantity.Create(resultValue.ToLogSpace(logarithmicScalingFactor, significantDigits), resultUnit);
#else
        return firstQuantity.QuantityInfo.Create(resultValue.ToLogSpace(logarithmicScalingFactor, significantDigits), resultUnit);
#endif
    }

    /// <summary>
    ///     Computes the sum of a sequence of logarithmic quantities, such as PowerRatio and AmplitudeRatio, by applying a
    ///     specified selector function to each element of the
    ///     sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the sum of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The sum of the logarithmic quantities in the unit of the first element in the sequence.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, each quantity is converted to linear space (in the unit of the first element),
    ///     summed, and then the result is converted back to logarithmic space using the same unit.
    /// </remarks>
    public static TQuantity Sum<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, byte significantDigits = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity>
    {
        return source.Select(selector).Sum(significantDigits);
    }

    /// <summary>
    ///     Sums a sequence of logarithmic quantities, such as PowerRatio and AmplitudeRatio, converting them to the
    ///     specified unit.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the logarithmic quantity.</typeparam>
    /// <typeparam name="TUnit">The unit type of the logarithmic quantity.</typeparam>
    /// <param name="quantities">The sequence of logarithmic quantities to sum.</param>
    /// <param name="targetUnit">The unit in which to express the sum.</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The sum of the logarithmic quantities in the specified unit.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     This method converts each logarithmic quantity to linear space, sums them, and then converts the result back to
    ///     logarithmic space.
    /// </remarks>
    public static TQuantity Sum<TQuantity, TUnit>(this IEnumerable<TQuantity> quantities, TUnit targetUnit, byte significantDigits = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        if (quantities is null)
        {
            throw new ArgumentNullException(nameof(quantities));
        }
        
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw ExceptionHelper.CreateInvalidOperationOnEmptyCollectionException();
        }

        var unitKey = UnitKey.ForUnit(targetUnit);
        TQuantity firstQuantity = enumerator.Current!;
#if NET
        QuantityValue logarithmicScalingFactor = TQuantity.LogarithmicScalingFactor;
#else
        QuantityValue logarithmicScalingFactor = firstQuantity.LogarithmicScalingFactor;
#endif
        var sumInLinearSpace = firstQuantity.GetValue(unitKey).ToLinearSpace(logarithmicScalingFactor);
        while (enumerator.MoveNext())
        {
            sumInLinearSpace += enumerator.Current!.GetValue(unitKey).ToLinearSpace(logarithmicScalingFactor);
        }

        return firstQuantity.QuantityInfo.From(sumInLinearSpace.ToLogSpace(logarithmicScalingFactor, significantDigits), targetUnit);
    }

    /// <summary>
    ///     Computes the sum of the sequence of <typeparamref name="TQuantity" /> values, such as PowerRatio and
    ///     AmplitudeRatio, that is obtained by invoking a
    ///     transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <typeparam name="TUnit">The type of the unit of the quantities.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the sum of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <param name="targetUnit">The desired unit type for the resulting quantity</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The sum of the projected quantities in the specified unit.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the source or selector is null.</exception>
    /// <remarks>
    ///     This method converts each logarithmic quantity to linear space, sums them, and then converts the result back to
    ///     logarithmic space.
    /// </remarks>
    public static TQuantity Sum<TSource, TQuantity, TUnit>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, TUnit targetUnit,
        byte significantDigits = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return source.Select(selector).Sum(targetUnit, significantDigits);
    }

    /// <summary>
    ///     Computes the arithmetic mean of a sequence of logarithmic quantities, such as PowerRatio and AmplitudeRatio.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the logarithmic quantity.</typeparam>
    /// <param name="quantities">The sequence of logarithmic quantities to average.</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The average of the logarithmic quantities in the unit of the first element in the sequence.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, each quantity is converted to linear space (in the unit of the first element),
    ///     averaged, and then the result is converted back to logarithmic space using the same unit.
    /// </remarks>
    public static TQuantity ArithmeticMean<TQuantity>(this IEnumerable<TQuantity> quantities, byte significantDigits = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity>
    {
        if (quantities is null)
        {
            throw new ArgumentNullException(nameof(quantities));
        }
        
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw ExceptionHelper.CreateInvalidOperationOnEmptyCollectionException();
        }

        TQuantity firstQuantity = enumerator.Current!;
#if NET
        QuantityValue logarithmicScalingFactor = TQuantity.LogarithmicScalingFactor;
#else
        QuantityValue logarithmicScalingFactor = firstQuantity.LogarithmicScalingFactor;
#endif
        UnitKey resultUnit = firstQuantity.UnitKey;
        var sumInLinearSpace = firstQuantity.Value.ToLinearSpace(logarithmicScalingFactor);
        var nbQuantities = 1;
        while (enumerator.MoveNext())
        {
            sumInLinearSpace += enumerator.Current!.GetValue(resultUnit).ToLinearSpace(logarithmicScalingFactor);
            nbQuantities++;
        }

        var avgInLinearSpace = sumInLinearSpace / nbQuantities;
#if NET
        return TQuantity.Create(avgInLinearSpace.ToLogSpace(logarithmicScalingFactor, significantDigits), resultUnit);
#else
        return firstQuantity.QuantityInfo.Create(avgInLinearSpace.ToLogSpace(logarithmicScalingFactor, significantDigits), resultUnit);
#endif
    }

    /// <summary>
    ///     Computes the average of a sequence of quantities by applying a specified selector function to each element of the
    ///     sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the sum of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The average of the logarithmic quantities in the unit of the first element in the sequence.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, each quantity is converted to linear space (in the unit of the first element),
    ///     averaged, and then the result is converted back to logarithmic space using the same unit.
    /// </remarks>
    public static TQuantity ArithmeticMean<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, byte significantDigits = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity>
    {
        return source.Select(selector).ArithmeticMean(significantDigits);
    }

    /// <summary>
    ///     Computes the arithmetic mean of a sequence of logarithmic quantities, such as PowerRatio and AmplitudeRatio.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the logarithmic quantity.</typeparam>
    /// <typeparam name="TUnit">The unit type of the logarithmic quantity.</typeparam>
    /// <param name="quantities">The sequence of logarithmic quantities to sum.</param>
    /// <param name="unit">The unit in which to express the sum.</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The arithmetic mean of the logarithmic quantities in the specified unit.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, each quantity is converted to linear space (in the specified unit),
    ///     averaged, and then the result is converted back to logarithmic space using the same unit.
    /// </remarks>
    public static TQuantity ArithmeticMean<TQuantity, TUnit>(this IEnumerable<TQuantity> quantities, TUnit unit, byte significantDigits = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        if (quantities is null)
        {
            throw new ArgumentNullException(nameof(quantities));
        }
        
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw ExceptionHelper.CreateInvalidOperationOnEmptyCollectionException();
        }

        var unitKey = UnitKey.ForUnit(unit);
        TQuantity firstQuantity = enumerator.Current!;
#if NET
        QuantityValue logarithmicScalingFactor = TQuantity.LogarithmicScalingFactor;
#else
        QuantityValue logarithmicScalingFactor = firstQuantity.LogarithmicScalingFactor;
#endif
        var sumInLinearSpace = firstQuantity.GetValue(unitKey).ToLinearSpace(logarithmicScalingFactor);
        var nbQuantities = 1;
        while (enumerator.MoveNext())
        {
            sumInLinearSpace += enumerator.Current!.GetValue(unitKey).ToLinearSpace(logarithmicScalingFactor);
            nbQuantities++;
        }
        
        var avgInLinearSpace = sumInLinearSpace / nbQuantities;
        return firstQuantity.QuantityInfo.From(avgInLinearSpace.ToLogSpace(logarithmicScalingFactor, significantDigits), unit);
    }

    /// <summary>
    ///     Computes the arithmetic mean of the sequence of <typeparamref name="TQuantity" /> values that are obtained by
    ///     invoking a
    ///     transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <typeparam name="TUnit">The type of the unit of the quantities.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the sum of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <param name="targetUnit">The desired unit type for the resulting quantity.</param>
    /// <param name="significantDigits">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The arithmetic mean of the logarithmic quantities in the specified unit.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, each quantity is converted to linear space (in the specified unit),
    ///     averaged, and then the result is converted back to logarithmic space using the same unit.
    /// </remarks>
    public static TQuantity ArithmeticMean<TSource, TQuantity, TUnit>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, TUnit targetUnit,
        byte significantDigits = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return source.Select(selector).ArithmeticMean(targetUnit, significantDigits);
    }


    /// <summary>
    ///     Computes the geometric mean of a sequence of logarithmic quantities, such as PowerRatio and AmplitudeRatio.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the logarithmic quantity.</typeparam>
    /// <param name="quantities">The sequence of logarithmic quantities to average.</param>
    /// <param name="accuracy">The accuracy for the square root calculation, expressed as number of significant digits. Default is 15.</param>
    /// <returns>The geometric mean of the logarithmic quantities in the unit of the first element in the sequence.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, calculates the n-th root of the product of the quantities, which for the
    ///     logarithmic quantities is equal to the sum the values, converted in unit of the first element.
    /// </remarks>
    public static TQuantity GeometricMean<TQuantity>(this IEnumerable<TQuantity> quantities, int accuracy = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity>
    {
        if (quantities is null)
        {
            throw new ArgumentNullException(nameof(quantities));
        }
        
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw ExceptionHelper.CreateInvalidOperationOnEmptyCollectionException();
        }

        TQuantity firstQuantity = enumerator.Current!;
        UnitKey resultUnit = firstQuantity.UnitKey;
        QuantityValue sumInLogSpace = firstQuantity.Value;
        var nbQuantities = 1;
        while (enumerator.MoveNext())
        {
            sumInLogSpace += enumerator.Current!.GetValue(resultUnit);
            nbQuantities++;
        }

        // var geometricMean = QuantityValue.Pow(sumInLogSpace, new QuantityValue(1, nbQuantities), significantDigits);
        var geometricMean = QuantityValue.RootN(sumInLogSpace, nbQuantities, accuracy);
#if NET
        return TQuantity.Create(geometricMean, resultUnit);
#else
        return firstQuantity.QuantityInfo.Create(geometricMean, resultUnit);
#endif
    }


    /// <summary>
    ///     Computes the geometric mean of a sequence of quantities by applying a specified selector function to each element
    ///     of the
    ///     sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the sum of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <param name="accuracy">The number of significant digits to retain in the result. Default is 15.</param>
    /// <returns>The geometric mean of the logarithmic quantities in the unit of the first element in the sequence.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, calculates the n-th root of the product of the quantities, which for the
    ///     logarithmic quantities is equal to the sum the values, converted in unit of the first element.
    /// </remarks>
    public static TQuantity GeometricMean<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, int accuracy = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity>
    {
        return source.Select(selector).GeometricMean(accuracy);
    }


    /// <summary>
    ///     Computes the geometric mean of a sequence of logarithmic quantities, such as PowerRatio and AmplitudeRatio, using
    ///     the specified unit.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the logarithmic quantity.</typeparam>
    /// <typeparam name="TUnit">The type of the unit of the quantities.</typeparam>
    /// <param name="quantities">The sequence of logarithmic quantities to average.</param>
    /// <param name="targetUnit">The desired unit type for the resulting quantity.</param>
    /// <param name="accuracy">The number of decimal places of accuracy for the square root calculation. Default is 15.</param>
    /// <returns>The geometric mean of the logarithmic quantities in the unit of the first element in the sequence.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, calculates the n-th root of the product of the quantities, which for the
    ///     logarithmic quantities is equal to the sum the values, converted in unit of the first element.
    /// </remarks>
    public static TQuantity GeometricMean<TQuantity, TUnit>(this IEnumerable<TQuantity> quantities, TUnit targetUnit, int accuracy = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        if (quantities is null)
        {
            throw new ArgumentNullException(nameof(quantities));
        }
        
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw ExceptionHelper.CreateInvalidOperationOnEmptyCollectionException();
        }

        var unitKey = UnitKey.ForUnit(targetUnit);
        TQuantity firstQuantity = enumerator.Current!;
        QuantityValue sumInLogSpace = firstQuantity.GetValue(unitKey);
        var nbQuantities = 1;
        while (enumerator.MoveNext())
        {
            sumInLogSpace += enumerator.Current!.GetValue(unitKey);
            nbQuantities++;
        }

        // var geometricMean = QuantityValue.Pow(sumInLogSpace, new QuantityValue(1, nbQuantities), significantDigits);
        var geometricMean = QuantityValue.RootN(sumInLogSpace, nbQuantities, accuracy);
        return firstQuantity.QuantityInfo.From(geometricMean, unitKey.ToUnit<TUnit>());
    }

    /// <summary>
    ///     Computes the geometric mean of the sequence of <typeparamref name="TQuantity" /> values that are obtained by
    ///     invoking a
    ///     transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <typeparam name="TUnit">The type of the unit of the quantities.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the sum of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <param name="targetUnit">The desired unit type for the resulting quantity.</param>
    /// <param name="accuracy">The number of decimal places of accuracy for the square root calculation. Default is 15.</param>
    /// <returns>The arithmetic mean of the logarithmic quantities in the specified unit.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     When the sequence is not empty, calculates the n-th root of the product of the quantities, which for the
    ///     logarithmic quantities is equal to the sum the values, converted in unit of the first element.
    /// </remarks>
    public static TQuantity GeometricMean<TSource, TQuantity, TUnit>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, TUnit targetUnit,
        int accuracy = 15)
        where TQuantity : ILogarithmicQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return source.Select(selector).GeometricMean(targetUnit, accuracy);
    }
}
