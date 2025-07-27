// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using UnitsNet.Units;
using UnitsNet;
#if NET
using System.Numerics;
#endif

namespace UnitsNet;

/// <summary>
///     Provides extension methods for affine quantities, such as the <see cref="Temperature" />, enabling comparison and
///     averaging operations.
/// </summary>
public static class AffineQuantityExtensions
{
#if NET
    /// <inheritdoc cref="EqualsAbsolute{TQuantity,TOffset}" />
    public static bool Equals<TQuantity, TOffset>(this TQuantity quantity, TQuantity? other, TOffset tolerance)
        where TQuantity : IAffineQuantity<TQuantity, TOffset>, ISubtractionOperators<TQuantity, TQuantity, TOffset>
        where TOffset : IQuantityInstance<TOffset>, IAdditiveIdentity<TOffset, TOffset>
    {
        return other != null && quantity.EqualsAbsolute(other, tolerance);
    }
    
    /// <inheritdoc cref="EqualsAbsolute{TQuantity,TOffset}" />
    /// <exception cref="ArgumentException">
    ///     Thrown when the <paramref name="tolerance" /> is not of the same type as the
    ///     <paramref name="quantity" />.
    /// </exception>
    public static bool Equals<TQuantity, TOffset>(this TQuantity quantity, IQuantity? other, TOffset tolerance)
        where TQuantity : IAffineQuantity<TQuantity, TOffset>, ISubtractionOperators<TQuantity, TQuantity, TOffset>
        where TOffset : IQuantityInstance<TOffset>, IAdditiveIdentity<TOffset, TOffset>
    {
        if (other is not TQuantity otherInstance)
        {
            return false;
        }

        // // TODO see about this (I think the exception should take precedence to the null check, but the QuantityTests disagree)
        // if (tolerance is not TOffset toleranceQuantity)
        // {
        //     throw ExceptionHelper.CreateArgumentException<TQuantity>(tolerance, nameof(tolerance));
        // }

        return quantity.EqualsAbsolute(otherInstance, tolerance);
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
    /// <typeparam name="TOffset">The type of the tolerance quantity.</typeparam>
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
    public static bool EqualsAbsolute<TQuantity, TOffset>(this TQuantity quantity, TQuantity other, TOffset tolerance)
        where TQuantity : IAffineQuantity<TQuantity, TOffset>, ISubtractionOperators<TQuantity, TQuantity, TOffset>
        where TOffset : IQuantityInstance<TOffset>, IAdditiveIdentity<TOffset, TOffset>
    {
        if (double.IsNegative(tolerance.Value))
        {
            throw ExceptionHelper.CreateArgumentOutOfRangeExceptionForNegativeTolerance(nameof(tolerance));
        }

        TOffset difference = quantity - other;
        return double.Abs(difference.Value) <= tolerance.GetValue(difference.UnitKey);
    }
#else
    /// <inheritdoc cref="EqualsAbsolute" />
    public static bool Equals(this Temperature quantity, Temperature other, TemperatureDelta tolerance)
    {
        return quantity.EqualsAbsolute(other, tolerance);
        // return other.HasValue && quantity.EqualsAbsolute(other.Value, tolerance);
    }

    /// <inheritdoc cref="EqualsAbsolute" />
    /// <exception cref="ArgumentException">
    ///     Thrown when the <paramref name="tolerance" /> is not of the same type as the
    ///     <paramref name="quantity" />.
    /// </exception>
    public static bool Equals(this Temperature quantity, IQuantity? other, TemperatureDelta tolerance)
    {
        if (other is not Temperature otherInstance)
        {
            return false;
        }

        // TODO see about this (I think the exception should take precedence to the null check, but the QuantityTests disagree)
        // if (tolerance is not TemperatureDelta toleranceQuantity)
        // {
        //     throw ExceptionHelper.CreateArgumentException<TemperatureDelta>(tolerance, nameof(tolerance));
        // }

        return quantity.EqualsAbsolute(otherInstance, tolerance);
    }

    /// <summary>
    ///     <para>
    ///         Compare equality to <paramref name="other" /> given a <paramref name="tolerance" /> for the maximum allowed +/-
    ///         difference.
    ///     </para>
    ///     <example>
    ///         In this example, the two temperatures will be considered equal if the value of b is within 0.5 degrees Celsius
    ///         of a.
    ///         <code>
    /// var a = Temperature.FromDegreesCelsius(25);
    /// var b = Temperature.FromDegreesCelsius(25.4);
    /// var tolerance = TemperatureDelta.FromDegreesCelsius(0.5);
    /// a.Equals(b, tolerance); // true, 25°C equals 25.4°C +/- 0.5°C
    /// </code>
    ///     </example>
    /// </summary>
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
    public static bool EqualsAbsolute(this Temperature quantity, Temperature other, TemperatureDelta tolerance)
    {
        if (tolerance.Value < 0)
        {
            throw ExceptionHelper.CreateArgumentOutOfRangeExceptionForNegativeTolerance(nameof(tolerance));
        }

        TemperatureDelta difference = quantity - other;
        return Math.Abs(difference.Value) <= tolerance.GetValue(UnitKey.ForUnit(difference.Unit));
    }
#endif

    /// <summary>
    ///     Calculates the average of a collection of <see cref="Temperature" /> values.
    /// </summary>
    /// <param name="temperatures">The collection of <see cref="Temperature" /> values to average.</param>
    /// <returns>The average <see cref="Temperature" />, in the unit of the first element in the sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="temperatures" /> collection is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the <paramref name="temperatures" /> collection is empty.</exception>
    public static Temperature Average(this IEnumerable<Temperature> temperatures)
    {
        return temperatures.ArithmeticMean();
    }

    /// <summary>
    ///     Calculates the average of a collection of <see cref="Temperature" /> values.
    /// </summary>
    /// <param name="temperatures">The collection of <see cref="Temperature" /> values to average.</param>
    /// <param name="unit">The unit in which to express the average.</param>
    /// <returns>The average <see cref="Temperature" />, in the specified unit.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="temperatures" /> collection is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the <paramref name="temperatures" /> collection is empty.</exception>
    /// <remarks>
    ///     This method is slightly more performant than the alternative
    ///     <see cref="Average(IEnumerable{Temperature})" />
    ///     when most of the quantities in the collection are expected to be in the target unit.
    /// </remarks>
    public static Temperature Average(this IEnumerable<Temperature> temperatures, TemperatureUnit unit)
    {
        return temperatures.ArithmeticMean(unit);
    }
}
