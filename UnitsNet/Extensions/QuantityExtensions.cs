// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;

namespace UnitsNet;

/// <summary>
/// Provides extension methods applicable to all quantities in the UnitsNet library.
/// </summary>
public static class QuantityExtensions
{
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
}
