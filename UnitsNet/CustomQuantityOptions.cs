// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using JetBrains.Annotations;

namespace UnitsNet
{
    /// <summary>
    /// Try to parse a quantity.
    /// </summary>
    /// <param name="formatProvider">The culture and localization to parse numbers and unit abbreviations.</param>
    /// <param name="str">The string to parse.</param>
    /// <param name="quantity">The resulting quantity.</param>
    public delegate bool TryParseQuantity(IFormatProvider formatProvider, string str, out IQuantity quantity);

    /// <summary>
    /// Try to create a quantity given a number and a unit. Can fail if the unit enum value does not map to a quantity.
    /// </summary>
    /// <param name="value">Numeric value.</param>
    /// <param name="unit">The unit.</param>
    /// <param name="quantity">The resulting quantity.</param>
    public delegate bool TryCreateQuantity(QuantityValue value, Enum unit, out IQuantity quantity);

    /// <summary>
    /// Options for constructing and parsing third-party quantities that are not handled by the generated code.
    /// These quantities are typically added via <see cref="QuantityFactory"/>.<see cref="QuantityFactory.AddUnit"/>.
    /// </summary>
    public class CustomQuantityOptions
    {
        /// <inheritdoc cref="TryParseQuantity"/>
        public TryParseQuantity TryParse { get; }

        /// <inheritdoc cref="TryCreateQuantity"/>
        public TryCreateQuantity TryCreate { get; }

        /// <summary>
        /// Create options for parsing and constructing custom quantities.
        /// </summary>
        /// <param name="tryParse">The parse function.</param>
        /// <param name="tryCreate">The factory function.</param>
        public CustomQuantityOptions([NotNull] TryParseQuantity tryParse, [NotNull] TryCreateQuantity tryCreate)
        {
            TryParse = tryParse ?? throw new ArgumentNullException(nameof(tryParse));
            TryCreate = tryCreate ?? throw new ArgumentNullException(nameof(tryCreate));
        }
    }
}
