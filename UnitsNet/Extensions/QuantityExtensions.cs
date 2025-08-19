// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;

// ReSharper disable once CheckNamespace
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
        where TQuantity : IQuantityOfType<TQuantity>
    {
        QuantityValue convertedValue = converter.ConvertValue(quantity.Value, quantity.UnitKey, toUnit);
#if NET
        return TQuantity.Create(convertedValue, toUnit);
#else
        return quantity.QuantityInfo.Create(convertedValue, toUnit);
#endif
    }
    
    /// <inheritdoc cref="UnitConverter.ConvertValue{TQuantity,TUnit}" />
    public static QuantityValue As<TQuantity, TUnit>(this TQuantity quantity, TUnit unit)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return UnitConverter.Default.ConvertValue(quantity, unit);
    }

    /// <summary>
    ///     Gets the value in the unit determined by the given <see cref="UnitSystem" />. If multiple units were found for the
    ///     given <see cref="UnitSystem" />,
    ///     the first match will be used.
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> to convert the quantity value to.</param>
    /// <returns>The converted value.</returns>
    public static QuantityValue As<TQuantity>(this TQuantity quantity, UnitSystem unitSystem)
        where TQuantity : IQuantity
    {
        return quantity.GetValue(quantity.QuantityInfo.GetDefaultUnit(unitSystem).UnitKey);
    }

    /// <inheritdoc cref="UnitConverter.ConvertToUnit{TQuantity,TUnit}" />
    public static TQuantity ToUnit<TQuantity, TUnit>(this TQuantity quantity, TUnit unit)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return UnitConverter.Default.ConvertToUnit(quantity, unit);
    }

    /// <inheritdoc cref="UnitConverter.ConvertToUnit{TQuantity,TUnit}" />
    public static TQuantity ToUnit<TQuantity, TUnit>(this TQuantity quantity, TUnit unit, UnitConverter unitConverter)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return unitConverter.ConvertToUnit(quantity, unit);
    }

    /// <inheritdoc cref="UnitConverter.ConvertToUnit{TQuantity,TUnit}" />
    public static TQuantity ToUnit<TQuantity>(this TQuantity quantity, UnitSystem unitSystem)
        where TQuantity : IQuantityOfType<TQuantity>
    {
#if NET
        QuantityInfo quantityInfo = quantity.QuantityInfo;
#else
        QuantityInfo quantityInfo = ((IQuantity)quantity).QuantityInfo;
#endif
        return UnitConverter.Default.ConvertToUnit(quantity, quantityInfo.GetDefaultUnit(unitSystem).UnitKey);
    }
    
    /// <inheritdoc cref="UnitConverter.ConvertValue(QuantityValue,UnitKey,UnitKey)" />
    [Obsolete("This method will be removed in the next major update. Consider using the UnitConverter.Default.ConvertValue(quantity, unit) method instead.")]
    public static QuantityValue As(this IQuantity quantity, UnitKey unit)
    {
        return UnitConverter.Default.ConvertValue(quantity, unit);
    }
    
    /// <inheritdoc cref="UnitConverter.ConvertTo{TQuantity}" />
    [Obsolete("This method will be removed in the next major update. Consider using the UnitConverter.Default.ConvertTo(quantity, unit) method instead.")]
    public static IQuantity ToUnit(this IQuantity quantity, UnitKey unit)
    {
         return UnitConverter.Default.ConvertTo(quantity, unit);
    }
    
    /// <summary>
    ///     Converts this <see cref="IQuantity{TUnitType}"/> to an <see cref="IQuantity{TUnitType}"/> in the given <paramref name="unit"/>.
    /// </summary>
    /// <param name="quantity">The quantity to convert.</param>
    /// <param name="unit">The unit value.</param>
    /// <exception cref="UnitNotFoundException">Thrown when the <paramref name="unit" /> is not recognized.</exception>
    /// <returns>A new <see cref="IQuantity{TUnitType}"/> in the given <paramref name="unit"/>.</returns>
    [Obsolete("This method will be removed in the next major update. Consider using the UnitConverter.Default.ConvertToUnit(quantity, unit) method instead.")]
    public static IQuantity<TUnit> ToUnit<TUnit>(this IQuantity<TUnit> quantity, TUnit unit)
        where TUnit : struct, Enum
    {
        QuantityValue convertedValue = UnitConverter.Default.ConvertValue(quantity.Value, quantity.Unit, unit);
        return quantity.QuantityInfo.From(convertedValue, unit);
    }

    /// <summary>
    ///     Converts the specified quantity to a new quantity with a unit determined by the given <see cref="UnitSystem" />.
    /// </summary>
    /// <param name="quantity">The quantity to convert.</param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> used to determine the target unit.</param>
    /// <returns>
    ///     A new quantity of the same type with the unit determined by the specified <see cref="UnitSystem" />.
    /// </returns>
    /// <remarks>
    ///     If multiple units are associated with the given <see cref="UnitSystem" />, the first matching unit will be used.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="unitSystem" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if no matching unit is found for the specified <see cref="UnitSystem" />.
    /// </exception>
    [Obsolete("This method will be removed in the next major update. Consider using the UnitConverter.Default.ConvertTo(quantity, unit) method instead.")]
    public static IQuantity ToUnit(this IQuantity quantity, UnitSystem unitSystem)
    {
         return UnitConverter.Default.ConvertTo(quantity, quantity.QuantityInfo.GetDefaultUnit(unitSystem).UnitKey);
    }

    /// <summary>
    ///     Converts the specified quantity to a new quantity with a unit determined by the given <see cref="UnitSystem" />.
    /// </summary>
    /// <param name="quantity">The quantity to convert.</param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> used to determine the target unit.</param>
    /// <returns>
    ///     A new quantity of the same type with the unit determined by the specified <see cref="UnitSystem" />.
    /// </returns>
    /// <remarks>
    ///     If multiple units are associated with the given <see cref="UnitSystem" />, the first matching unit will be used.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="unitSystem" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if no matching unit is found for the specified <see cref="UnitSystem" />.
    /// </exception>
    [Obsolete("This method will be removed in the next major update. Consider using the UnitConverter.Default.ConvertToUnit(quantity, unit) method instead.")]
    public static IQuantity<TUnit> ToUnit<TUnit>(this IQuantity<TUnit> quantity, UnitSystem unitSystem)
        where TUnit : struct, Enum
    {
         QuantityInfo<TUnit> quantityInfo = quantity.QuantityInfo;
         UnitInfo<TUnit> targetUnitInfo = quantityInfo.GetDefaultUnit(unitSystem);
         QuantityValue convertedValue = UnitConverter.Default.ConvertValue(quantity.Value, quantity.Unit, targetUnitInfo.Value);
         return quantityInfo.From(convertedValue, targetUnitInfo.Value);
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

    /// <summary>
    ///     Calculates the arithmetic mean of a sequence of quantities.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity.</typeparam>
    /// <param name="quantities">The collection of quantities to average.</param>
    /// <returns>The average of the quantities, using the unit of the first element in the sequence.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the collection is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the collection is empty.</exception>
    internal static TQuantity ArithmeticMean<TQuantity>(this IEnumerable<TQuantity> quantities)
        where TQuantity : IQuantityOfType<TQuantity>
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
