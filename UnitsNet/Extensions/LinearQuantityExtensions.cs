// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;

namespace UnitsNet;

/// <summary>
///     Provides extension methods for linear quantities, such as Mass and Length, enabling operations such as equality
///     checks, summation, and averaging.
/// </summary>
public static class LinearQuantityExtensions
{
    /// <inheritdoc cref="EqualsAbsolute{TQuantity,TOther,TTolerance}" />
    public static bool Equals<TQuantity, TOther, TTolerance>(this TQuantity quantity, TOther? other, TTolerance tolerance)
        where TQuantity : ILinearQuantity<TQuantity>
        where TOther : IQuantityInstance<TQuantity>
        where TTolerance : IQuantityInstance<TQuantity>
    {
        return other != null && quantity.EqualsAbsolute(other, tolerance);
    }

    /// <inheritdoc cref="EqualsAbsolute{TQuantity,TOther,TTolerance}" />
    /// <exception cref="ArgumentException">
    ///     Thrown when the <paramref name="tolerance" /> is not of the same type as the
    ///     <paramref name="quantity" />.
    /// </exception>
    public static bool Equals<TQuantity>(this TQuantity quantity, IQuantity? other, IQuantity tolerance)
        where TQuantity : ILinearQuantity<TQuantity>
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
    ///     <para>
    ///         Compare equality to <paramref name="other" /> given a <paramref name="tolerance" /> for the maximum allowed +/-
    ///         difference.
    ///     </para>
    ///     <example>
    ///         In this example, the two quantities will be equal if the value of b is within 0.01 of a (0.01m or 1cm).
    ///         <code>
    ///     var a = Length.FromMeters(2.0);
    ///     var b = Length.FromMeters(2.1);
    ///     var tolerance = Length.FromCentimeters(10);
    ///     a.Equals(b, tolerance); // true, 2m equals 2.1m +/- 0.1m
    ///     </code>
    ///     </example>
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity being compared.</typeparam>
    /// <typeparam name="TOther">The type of the other quantity being compared.</typeparam>
    /// <typeparam name="TTolerance">The type of the tolerance quantity.</typeparam>
    /// <param name="quantity">The quantity to compare.</param>
    /// <param name="other">The other quantity to compare to.</param>
    /// <param name="tolerance">The absolute tolerance value. Must be greater than or equal to zero.</param>
    /// <returns>True if the absolute difference between the two values is not greater than the specified tolerance.</returns>
    /// <exception cref="ArgumentOutOfRangeException"> Thrown when the <paramref name="tolerance" /> is negative.</exception>
    /// <exception cref="UnitNotFoundException">Thrown when no unit information is found for one of the specified enum value.</exception>
    /// <remarks>
    ///     It is generally advised against specifying "zero" tolerance, preferring the use of the default equality
    ///     comparer, which is significantly more performant.
    /// </remarks>
    public static bool EqualsAbsolute<TQuantity, TOther, TTolerance>(this TQuantity quantity, TOther other, TTolerance tolerance)
        where TQuantity : ILinearQuantity<TQuantity>
        where TOther : IQuantityInstance<TQuantity>
        where TTolerance : IQuantityInstance<TQuantity>
    {
        UnitKey quantityUnit = quantity.UnitKey;
        return Comparison.EqualsAbsolute(quantity.Value, other.GetValue(quantityUnit), tolerance.GetValue(quantityUnit));
    }

    /// <summary>
    ///     Sums a sequence of linear quantities, such as Mass and Length.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the linear quantity.</typeparam>
    /// <param name="quantities">The collection of linear quantities to sum.</param>
    /// <returns>
    ///     The sum of the linear quantities. If the sequence is empty, returns zero in the base unit.
    ///     In all other cases, the result will have the unit of the first element in the collection.
    /// </returns>
    public static TQuantity Sum<TQuantity>(this IEnumerable<TQuantity> quantities)
        where TQuantity : ILinearQuantity<TQuantity>
    {
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
#if NET
            return TQuantity.Zero;
#else
            // for a struct-constrained TQuantity we could simply return default here
            if (typeof(TQuantity).IsValueType)
            {
                return default!;
            }
            
            return (TQuantity)UnitsNetSetup.Default.QuantityInfoLookup.GetQuantityInfo(typeof(TQuantity)).Zero;
#endif
        }

        TQuantity firstQuantity = enumerator.Current!;
        UnitKey resultUnit = firstQuantity.UnitKey;
        var sumOfValues = firstQuantity.Value;
        while (enumerator.MoveNext())
        {
            sumOfValues += enumerator.Current!.GetValue(resultUnit);
        }

#if NET
        return TQuantity.Create(sumOfValues, resultUnit);
#else
        return firstQuantity.QuantityInfo.Create(sumOfValues, resultUnit);
#endif
    }
    
    /// <summary>
    ///     Computes the sum of a sequence of quantities by applying a specified selector function to each element of the
    ///     sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the sum of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <returns>
    ///     The sum of the projected quantities. If the sequence is empty, returns zero in the base unit; otherwise,
    ///     returns the sum in the unit of the first element.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the source or selector is null.</exception>
    public static TQuantity Sum<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector)
        where TQuantity : ILinearQuantity<TQuantity>
    {
        return source.Select(selector).Sum();
    }

    /// <summary>
    ///     Sums a sequence of linear quantities, such as Mass and Length.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the linear quantity.</typeparam>
    /// <typeparam name="TUnit">The unit type of the linear quantity.</typeparam>
    /// <param name="quantities">The collection of linear quantities to sum.</param>
    /// <param name="unit">The unit in which to express the sum.</param>
    /// <returns>The sum of the linear quantities in the specified unit.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the sequence is null.</exception>
    /// <remarks>
    ///     This method is slightly more performant than the alternative <see cref="Sum{TQuantity}(IEnumerable{TQuantity})" />
    ///     when most of the quantities in the sequence are expected to be in the target unit.
    /// </remarks>
    public static TQuantity Sum<TQuantity, TUnit>(this IEnumerable<TQuantity> quantities, TUnit unit)
        where TQuantity : ILinearQuantity<TQuantity>, IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        using IEnumerator<TQuantity> enumerator = quantities.GetEnumerator();
        if (!enumerator.MoveNext())
        {
#if NET
            return TQuantity.From(0, unit);
#else
            return (TQuantity)Quantity.From(0, UnitKey.ForUnit(unit));
#endif
        }

        var unitKey = UnitKey.ForUnit(unit);
        TQuantity firstQuantity = enumerator.Current!;
        var resultValue = firstQuantity.GetValue(unitKey);
        while (enumerator.MoveNext())
        {
            resultValue += enumerator.Current!.GetValue(unitKey);
        }

        return firstQuantity.QuantityInfo.From(resultValue, unit);
    }

    /// <summary>
    ///     Computes the sum of the sequence of <typeparamref name="TQuantity" /> values that are obtained by invoking a
    ///     transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <typeparam name="TUnit">The type of the unit of the quantities.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the sum of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <param name="targetUnit">The desired unit type for the resulting quantity</param>
    /// <returns>The sum of the projected quantities in the specified unit.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the source or selector is null.</exception>
    public static TQuantity Sum<TSource, TQuantity, TUnit>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, TUnit targetUnit)
        where TQuantity : ILinearQuantity<TQuantity>, IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return source.Select(selector).Sum(targetUnit);
    }

    /// <summary>
    ///     Calculates the arithmetic average of a sequence of linear quantities, such as Mass and Length.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the linear quantity.</typeparam>
    /// <param name="quantities">The sequence of linear quantities to average.</param>
    /// <returns>The average of the linear quantities, using the unit of the first element in the sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the sequence is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    public static TQuantity Average<TQuantity>(this IEnumerable<TQuantity> quantities)
        where TQuantity : ILinearQuantity<TQuantity>
    {
        return quantities.ArithmeticMean();
    }

    /// <summary>
    ///     Computes the arithmetic average of a sequence of quantities, such as Mass and Length, by applying a specified
    ///     selector
    ///     function to each element of the elements in the sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the average of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <returns>The average of the projected quantities in the unit of the first element in the sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the sequence is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    public static TQuantity Average<TSource, TQuantity>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector)
        where TQuantity : ILinearQuantity<TQuantity>
    {
        return source.Select(selector).Average();
    }

    /// <summary>
    ///     Calculates the average of a sequence of linear quantities, such as Mass and Length.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the linear quantity.</typeparam>
    /// <typeparam name="TUnit">The unit type of the linear quantity.</typeparam>
    /// <param name="quantities">The sequence of linear quantities to average.</param>
    /// <param name="targetUnit">The unit in which to express the average.</param>
    /// <returns>The average of the linear quantities in the specified unit.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    /// <remarks>
    ///     This method is slightly more performant than the alternative
    ///     <see cref="Average{TQuantity}(IEnumerable{TQuantity})" />
    ///     when most of the quantities in the sequence are expected to be in the target unit.
    /// </remarks>
    public static TQuantity Average<TQuantity, TUnit>(this IEnumerable<TQuantity> quantities, TUnit targetUnit)
        where TQuantity : ILinearQuantity<TQuantity>, IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return quantities.ArithmeticMean(targetUnit);
    }

    /// <summary>
    ///     Computes the average of the sequence of <typeparamref name="TQuantity" /> values, such as Mass and Length, that are
    ///     obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
    /// <typeparam name="TQuantity">The type of the quantity elements in the source sequence.</typeparam>
    /// <typeparam name="TUnit">The type of the unit of the quantities.</typeparam>
    /// <param name="source">A sequence of quantities to calculate the average of.</param>
    /// <param name="selector">A function to transform each element of the source sequence into a quantity.</param>
    /// <param name="targetUnit">The desired unit type for the resulting quantity.</param>
    /// <returns>The average of the projected quantities in the specified unit.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the sequence is empty.</exception>
    public static TQuantity Average<TSource, TQuantity, TUnit>(this IEnumerable<TSource> source, Func<TSource, TQuantity> selector, TUnit targetUnit)
        where TQuantity : ILinearQuantity<TQuantity>, IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return source.Select(selector).Average(targetUnit);
    }
}
