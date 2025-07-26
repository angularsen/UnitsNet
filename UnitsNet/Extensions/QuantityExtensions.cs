// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace UnitsNet;

/// <summary>
/// Provides extension methods applicable to all quantities in the UnitsNet library.
/// </summary>
public static class QuantityExtensions
{
    /// <inheritdoc cref="UnitConverter.ConvertValue(QuantityValue,UnitKey,UnitKey)" />
    internal static QuantityValue GetValue<TQuantity>(this TQuantity quantity, UnitKey toUnit)
        where TQuantity : IQuantity
    {
        return UnitConverter.Default.ConvertValue(quantity, toUnit);
    }

    /// <inheritdoc cref="UnitConverter.ConvertValue(QuantityValue,UnitKey,UnitKey)" />
    internal static QuantityValue ConvertValue<TQuantity>(this UnitConverter converter, TQuantity quantity, UnitKey toUnit)
        where TQuantity : IQuantity
    {
        return converter.ConvertValue(quantity.Value, quantity.UnitKey, toUnit);
    }

    /// <inheritdoc cref="UnitConverter.ConvertToUnit{TQuantity,TUnit}" />
    internal static TQuantity ConvertToUnit<TQuantity>(this UnitConverter converter, TQuantity quantity, UnitKey toUnit)
        where TQuantity : IQuantityInstance<TQuantity>
    {
        QuantityValue convertedValue = converter.ConvertValue(quantity.Value, quantity.UnitKey, toUnit);
#if NET
        return TQuantity.Create(convertedValue, toUnit);
#else
        return quantity.QuantityInfo.Create(convertedValue, toUnit);
#endif
    }
    
    /// <summary>
    ///     Returns the string representation of the specified quantity using the provided format provider.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity, which must implement <see cref="IQuantity" /> and
    ///     <see cref="IFormattable" />.
    /// </typeparam>
    /// <param name="quantity">The quantity to convert to a string.</param>
    /// <param name="formatProvider">
    ///     The format provider to use for localization and number formatting.
    ///     If <c>null</c>, the default is <see cref="CultureInfo.CurrentCulture" />.
    /// </param>
    /// <returns>A string representation of the quantity.</returns>
    public static string ToString<TQuantity>(this TQuantity quantity, IFormatProvider? formatProvider)
        where TQuantity : IQuantity, IFormattable
    {
        return quantity.ToString(null, formatProvider);
    }

    /// <summary>
    ///     Returns the string representation of the specified quantity using the provided format string.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity, which must implement <see cref="IQuantity" /> and
    ///     <see cref="IFormattable" />.
    /// </typeparam>
    /// <param name="quantity">The quantity to convert to a string.</param>
    /// <param name="format">
    ///     The format string to use for formatting the quantity.
    ///     If <c>null</c> or empty, the default format is used.
    /// </param>
    /// <returns>A string representation of the quantity.</returns>
    public static string ToString<TQuantity>(this TQuantity quantity, string? format)
        where TQuantity : IQuantity, IFormattable
    {
        return quantity.ToString(format, null);
    }

    // /// <inheritdoc cref="UnitConverter.ConvertToUnit{TQuantity,TUnit}" />
    // public static TQuantity ToUnit<TQuantity, TUnit>(this TQuantity quantity, UnitSystem unitSystem)
    //     where TQuantity : IQuantity<TQuantity, TUnit>
    //     where TUnit : struct, Enum
    // {
    //     return UnitConverter.Default.ConvertToUnit(quantity, quantity.QuantityInfo.GetDefaultUnit(unitSystem));
    // }

    // /// <summary>
    // /// 
    // /// </summary>
    // /// <param name="quantity"></param>
    // /// <param name="other"></param>
    // /// <param name="tolerance"></param>
    // /// <typeparam name="TQuantity"></typeparam>
    // /// <returns></returns>
    // [Obsolete(
    //     "This method was only created in order to facilitate the transition from the old IQuantity interface definition. Consider using the safer, and more performant extensions available on the IVectorQuantity, ILogarithmicQuantity or IAffineQuantity interfaces.")]
    // public static bool Equals<TQuantity>(this TQuantity quantity, TQuantity? other, TQuantity tolerance) where TQuantity : IQuantity
    // {
    //     if (other is null)
    //     {
    //         return false;
    //     }
    //
    //     var type = typeof(IVectorQuantity<>);
    //
    //     // if (quantity is IVectorQuantity<TQuantity> vectorQuantity && other is IVectorQuantity otherVectorQuantity)
    //     // {
    //     //     return VectorQuantityExtensions.Equals(vectorQuantity, otherVectorQuantity, tolerance);
    //     // }
    //     //
    //     // if (quantity is ILogarithmicQuantity logarithmicQuantity && other is ILogarithmicQuantity otherLogarithmicQuantity)
    //     // {
    //     //     return LogarithmicQuantityExtensions.Equals(logarithmicQuantity, otherLogarithmicQuantity, tolerance);
    //     // }
    //
    //     // if (quantity is IAffineQuantity affineQuantity && other is IAffineQuantity otherAffineQuantity)
    //     // {
    //     //     return AffineQuantityExtensions.Equals(affineQuantity, otherAffineQuantity, tolerance);
    //     // }
    //
    //     throw new InvalidOperationException("Unsupported quantity type.");
    // }

    /// <summary>
    ///     Calculates the arithmetic mean of a sequence of quantities.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity.</typeparam>
    /// <param name="quantities">The collection of quantities to average.</param>
    /// <returns>The average of the quantities, using the unit of the first element in the sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the collection is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the collection is empty.</exception>
    internal static TQuantity ArithmeticMean<TQuantity>(this IEnumerable<TQuantity> quantities)
        where TQuantity : IQuantityInstance<TQuantity>
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
        QuantityValue sumOfValues = firstQuantity.Value;
        var nbValues = 1;
        while (enumerator.MoveNext())
        {
            sumOfValues += enumerator.Current!.GetValue(resultUnit);
            nbValues++;
        }

#if NET
        return TQuantity.Create(sumOfValues / nbValues, resultUnit);
#else
        return firstQuantity.QuantityInfo.Create(sumOfValues / nbValues, resultUnit);
#endif
    }

    /// <summary>
    ///     Calculates the arithmetic mean of a sequence of quantities.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity.</typeparam>
    /// <typeparam name="TUnit">The unit type of the quantity.</typeparam>
    /// <param name="quantities">The collection of quantities to average.</param>
    /// <param name="unit">The unit in which to express the sum.</param>
    /// <returns>The average of the vector quantities in the specified unit.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the collection is empty.</exception>
    /// <remarks>
    ///     This method is slightly more performant than the alternative
    ///     <see cref="ArithmeticMean{TQuantity}(IEnumerable{TQuantity})" />
    ///     when most of the quantities in the collection are expected to be in the target unit.
    /// </remarks>
    internal static TQuantity ArithmeticMean<TQuantity, TUnit>(this IEnumerable<TQuantity> quantities, TUnit unit)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit: struct, Enum
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
        var unitKey = UnitKey.ForUnit(unit);
        QuantityValue sumOfValues = firstQuantity.GetValue(unitKey);
        var nbValues = 1;
        while (enumerator.MoveNext())
        {
            sumOfValues += enumerator.Current!.GetValue(unitKey);
            nbValues++;
        }

        return firstQuantity.QuantityInfo.From(sumOfValues / nbValues, unit);
    }
}
