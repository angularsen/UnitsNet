// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;

namespace UnitsNet;

/// <summary>
/// Provides extension methods applicable to all quantities in the UnitsNet library.
/// </summary>
public static class QuantityExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="other"></param>
    /// <param name="tolerance"></param>
    /// <returns></returns>
    public static bool Equals(this IQuantity quantity, IQuantity? other, IQuantity tolerance)
    {
        if (quantity is null) throw new ArgumentNullException(nameof(quantity));
        if (tolerance is null) throw new ArgumentNullException(nameof(tolerance), "Tolerance cannot be null. Use a zero quantity instead.");
        if (other is null) return false;

        // TODO Defer to implementations in LinearQuantityExtensions, AffineQuantityExtensions, LogdecimalQuantityExtensions, etc. Several tests in QuantityExtensionsTests break on this default implementation.
        UnitKey quantityUnit = quantity.UnitKey;
        return Comparison.EqualsAbsolute(quantity.Value, other.GetValue(quantityUnit), tolerance.GetValue(quantityUnit));
    }

    /// <inheritdoc cref="IQuantity.As(UnitKey)" />
    /// <remarks>This should be using UnitConverter.Default.ConvertValue(quantity, toUnit) </remarks>
    internal static double GetValue(this IQuantity quantity, UnitKey toUnit)
    {
        return quantity.As(toUnit);
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

        return firstQuantity.QuantityInfo.From(sumOfValues / nbValues, unit);
    }
}
