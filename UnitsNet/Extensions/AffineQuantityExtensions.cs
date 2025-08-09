// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
    /// <inheritdoc cref="EqualsNotNull{TQuantity,TOther,TOffset}"/>
    public static bool Equals<TQuantity, TOther, TOffset>(this TQuantity quantity, TOther? other, TOffset tolerance)
        where TQuantity : IAffineQuantity<TQuantity, TOffset>, ISubtractionOperators<TQuantity, TOther, TOffset>
        where TOther : struct, IAffineQuantity<TQuantity, TOffset>
        where TOffset : IQuantityOfType<TOffset>, IAdditiveIdentity<TOffset, TOffset>
    {
        return other is not null && EqualsNotNull(quantity, other.Value, tolerance);
    }

    /// <inheritdoc cref="EqualsNotNull{TQuantity,TOther,TOffset}"/>
    public static bool Equals<TQuantity, TOther, TOffset>(this TQuantity quantity, TOther? other, TOffset tolerance)
        where TQuantity : IAffineQuantity<TQuantity, TOffset>, ISubtractionOperators<TQuantity, TOther, TOffset>
        where TOther : IAffineQuantity<TQuantity, TOffset>
        where TOffset : IQuantityOfType<TOffset>, IAdditiveIdentity<TOffset, TOffset>
    {
        return other is not null && EqualsNotNull(quantity, other, tolerance);
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
    ///         </code>
    ///     </example>
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity being compared.</typeparam>
    /// <typeparam name="TOther">The type of the other quantity being compared.</typeparam>
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
    private static bool EqualsNotNull<TQuantity, TOther, TOffset>(TQuantity quantity, TOther other, TOffset tolerance)
        where TQuantity : IAffineQuantity<TQuantity, TOffset>, ISubtractionOperators<TQuantity, TOther, TOffset>
        where TOther : IAffineQuantity<TQuantity, TOffset>
        where TOffset : IQuantityOfType<TOffset>, IAdditiveIdentity<TOffset, TOffset>
    {
        if (double.IsNegative(tolerance.Value))
        {
            throw ExceptionHelper.CreateArgumentOutOfRangeExceptionForNegativeTolerance(nameof(tolerance));
        }

        TOffset difference = quantity - other;
        return double.Abs(difference.Value) <= tolerance.GetValue(difference.UnitKey);
    }
#else
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
    ///         </code>
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
    public static bool Equals(this Temperature quantity, Temperature other, TemperatureDelta tolerance)
    {
        if (tolerance.Value < 0)
        {
            throw ExceptionHelper.CreateArgumentOutOfRangeExceptionForNegativeTolerance(nameof(tolerance));
        }

        TemperatureDelta difference = quantity - other;
        return Math.Abs(difference.Value) <= tolerance.GetValue(UnitKey.ForUnit(difference.Unit));
    }

    /// <inheritdoc cref="Equals(UnitsNet.Temperature,UnitsNet.Temperature,UnitsNet.TemperatureDelta)" />
    public static bool Equals(this Temperature quantity, IQuantity? other, TemperatureDelta tolerance)
    {
        return other is Temperature otherInstance && quantity.Equals(otherInstance, tolerance);
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
