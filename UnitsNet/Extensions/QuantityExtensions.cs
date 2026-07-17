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
    /// <summary>
    ///     Gets the <see cref="UnitsNet.QuantityInfo"/> for the given quantity instance, looked up via
    ///     <see cref="UnitsNetSetup.Default"/>.
    /// </summary>
    /// <remarks>
    ///     Use the static <c>TSelf.Info</c> directly when you have a typed quantity reference for the best performance.
    ///     This extension is convenient when working with an <see cref="IQuantity"/> reference where the concrete
    ///     type is not known at compile time.
    /// </remarks>
    /// <param name="quantity">The quantity instance.</param>
    /// <returns>The <see cref="UnitsNet.QuantityInfo"/> registered in <see cref="UnitsNetSetup.Default"/> for the quantity's runtime type.</returns>
    public static QuantityInfo GetQuantityInfo(this IQuantity quantity)
    {
        return UnitsNetSetup.Default.Quantities.GetQuantityInfo(quantity.GetType());
    }

    /// <inheritdoc cref="GetQuantityInfo(IQuantity)"/>
    /// <typeparam name="TUnit">The unit enum type of the quantity.</typeparam>
    public static QuantityInfo<TUnit> GetQuantityInfo<TUnit>(this IQuantity<TUnit> quantity)
        where TUnit : struct, Enum
    {
        return (QuantityInfo<TUnit>)UnitsNetSetup.Default.Quantities.GetQuantityInfo(quantity.GetType());
    }

    /// <summary>
    ///     Gets the <see cref="UnitInfo"/> for the unit this quantity was constructed with.
    /// </summary>
    /// <remarks>
    ///     Picked by overload resolution for callers that only have an <see cref="IQuantity"/> reference.
    ///     Concretely-typed callers (e.g. a <c>Mass</c> receiver) bind to the
    ///     <see cref="GetUnitInfo{TQuantity,TUnit}(IQuantity{TQuantity,TUnit})"/> overload and get the
    ///     more specific <see cref="UnitInfo{TQuantity,TUnit}"/> return.
    /// </remarks>
    /// <param name="quantity">The quantity.</param>
    /// <returns>The <see cref="UnitInfo"/> for the quantity's unit.</returns>
    public static UnitInfo GetUnitInfo(this IQuantity quantity)
    {
        return quantity.GetQuantityInfo()[quantity.UnitKey];
    }

    /// <summary>
    ///     Gets the <see cref="UnitInfo{TQuantity,TUnit}"/> for the unit this quantity was constructed with.
    /// </summary>
    /// <remarks>
    ///     Picked by overload resolution for concretely-typed receivers (e.g. <c>Mass</c>) where C# can
    ///     infer both <typeparamref name="TQuantity"/> and <typeparamref name="TUnit"/> from the receiver's
    ///     <see cref="IQuantity{TSelf,TUnit}"/> implementation. Callers with only an <see cref="IQuantity"/>
    ///     reference fall back to the non-generic <see cref="GetUnitInfo(IQuantity)"/> overload.
    /// </remarks>
    /// <typeparam name="TQuantity">The quantity type.</typeparam>
    /// <typeparam name="TUnit">The unit enum type.</typeparam>
    /// <param name="quantity">The quantity.</param>
    /// <returns>The <see cref="UnitInfo{TQuantity,TUnit}"/> for the quantity's unit.</returns>
    public static UnitInfo<TQuantity, TUnit> GetUnitInfo<TQuantity, TUnit>(this IQuantity<TQuantity, TUnit> quantity)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
#if NET
        return TQuantity.Info[quantity.Unit];
#else
        // Azure CI build failed on binding QuantityInfo through IQuantity<TUnit>, so cast to expose the fully typed indexer.
        // This is likely a .NET SDK version compatibility thing, did not bother looking closer at it.
        var quantityInfo = (QuantityInfo<TQuantity, TUnit>)quantity.QuantityInfo;
        return quantityInfo[quantity.Unit];
#endif
    }

    /// <inheritdoc cref="IQuantity.As(UnitKey)" />
    /// <remarks>This should be using UnitConverter.Default.ConvertValue(quantity, toUnit) </remarks>
    internal static double GetValue<TQuantity>(this TQuantity quantity, UnitKey toUnit)
        where TQuantity : IQuantity
    {
        return quantity.As(toUnit);
    }

    /// <summary>
    ///     Converts the quantity to a value in the unit determined by the specified <see cref="UnitSystem" />.
    ///     If multiple units are found for the given <see cref="UnitSystem" />, the first match will be used.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity being converted.</typeparam>
    /// <param name="quantity">The quantity to convert.</param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> to which the quantity value should be converted.</param>
    /// <returns>The value of the quantity in the specified unit system.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="unitSystem" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if no matching unit is found for the given <see cref="UnitSystem" />.
    /// </exception>
    public static double As<TQuantity>(this TQuantity quantity, UnitSystem unitSystem)
        where TQuantity : IQuantity
    {
#if NET
        return quantity.GetValue(quantity.GetQuantityInfo().GetDefaultUnit(unitSystem).UnitKey);
#else
        return quantity.GetValue(quantity.QuantityInfo.GetDefaultUnit(unitSystem).UnitKey);
#endif
    }

    /// <summary>
    ///     Converts the specified quantity to a new quantity with a unit determined by the given <see cref="UnitSystem" />.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity to be converted. Must implement <see cref="IQuantityOfType{TQuantity}" />.
    /// </typeparam>
    /// <param name="quantity">The quantity to convert.</param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> used to determine the target unit.</param>
    /// <returns>
    ///     A new quantity of type <typeparamref name="TQuantity" /> with the unit determined by the specified
    ///     <see cref="UnitSystem" />.
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
    public static TQuantity ToUnit<TQuantity>(this TQuantity quantity, UnitSystem unitSystem)
        where TQuantity : IQuantityOfType<TQuantity>
    {
#if NET
        QuantityInfo quantityInfo = TQuantity.Info;
        UnitKey unitKey = quantityInfo.GetDefaultUnit(unitSystem).UnitKey;
        return TQuantity.Create(quantity.As(unitKey), unitKey);
#else
        QuantityInfo quantityInfo = ((IQuantity)quantity).QuantityInfo;
        UnitKey unitKey = quantityInfo.GetDefaultUnit(unitSystem).UnitKey;
        return quantity.QuantityInfo.Create(quantity.As(unitKey), unitKey);
#endif
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
    [Obsolete("This method will be removed from the interface in the next major update.")]
    public static IQuantity ToUnit(this IQuantity quantity, UnitSystem unitSystem)
    {
         QuantityInfo quantityInfo = quantity.QuantityInfo;
         UnitKey unitKey = quantityInfo.GetDefaultUnit(unitSystem).UnitKey;
         return quantityInfo.From(quantity.As(unitKey), unitKey);
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
    [Obsolete("This method will be removed from the interface in the next major update.")]
    public static IQuantity<TUnit> ToUnit<TUnit>(this IQuantity<TUnit> quantity, UnitSystem unitSystem)
        where TUnit : struct, Enum
    {
         QuantityInfo<TUnit> quantityInfo = quantity.QuantityInfo;
         TUnit unit = quantityInfo.GetDefaultUnit(unitSystem);
         return quantityInfo.From(quantity.As(unit), unit);
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
        var sumOfValues = firstQuantity.Value;
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
        var sumOfValues = firstQuantity.GetValue(unitKey);
        var nbValues = 1;
        while (enumerator.MoveNext())
        {
            sumOfValues += enumerator.Current!.GetValue(unitKey);
            nbValues++;
        }

#if NET
        return TQuantity.From(sumOfValues / nbValues, unit);
#else
        return firstQuantity.QuantityInfo.From(sumOfValues / nbValues, unit);
#endif
    }
}
