// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using JetBrains.Annotations;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity.
    /// </summary>
    public interface IQuantity : IFormattable
    {
        /// <summary>
        ///     The <see cref="QuantityType" /> of this quantity.
        /// </summary>
        QuantityType Type { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        BaseDimensions Dimensions { get; }

        /// <summary>
        ///     Information about the quantity type, such as unit values and names.
        /// </summary>
        QuantityInfo QuantityInfo { get; }

        /// <summary>
        ///     Gets the value in the given unit.
        /// </summary>
        /// <param name="unit">The unit enum value. The unit must be compatible, so for <see cref="Length"/> you should provide a <see cref="LengthUnit"/> value.</param>
        /// <returns>Value converted to the specified unit.</returns>
        /// <exception cref="InvalidCastException">Wrong unit enum type was given.</exception>
        double As(Enum unit);

        /// <summary>
        ///     Gets the value in the unit determined by the given <see cref="UnitSystem"/>. If multiple units were found for the given <see cref="UnitSystem"/>,
        ///     the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity value to.</param>
        /// <returns>The converted value.</returns>
        double As(UnitSystem unitSystem);

        /// <summary>
        ///     The unit this quantity was constructed with -or- BaseUnit if default ctor was used.
        /// </summary>
        Enum Unit { get; }

        /// <summary>
        ///     The value this quantity was constructed with. See also <see cref="Unit"/>.
        /// </summary>
        double Value { get; }

        /// <summary>
        ///     Converts to a quantity with the given unit representation, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="unit">The unit enum value. The unit must be compatible, so for <see cref="Length"/> you should provide a <see cref="LengthUnit"/> value.</param>
        /// <returns>A new quantity with the given unit.</returns>
        IQuantity ToUnit(Enum unit);

        /// <summary>
        ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
        /// <returns>A new quantity with the determined unit.</returns>
        IQuantity ToUnit(UnitSystem unitSystem);

        /// <summary>
        ///     Gets the string representation of value and unit. Uses two significant digits after radix.
        /// </summary>
        /// <returns>String representation.</returns>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        string ToString([CanBeNull] IFormatProvider provider);

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        [Obsolete(@"This method is deprecated and will be removed at a future release. Please use ToString(""s2"") or ToString(""s2"", provider) where 2 is an example of the number passed to significantDigitsAfterRadix.")]
        string ToString([CanBeNull] IFormatProvider provider, int significantDigitsAfterRadix);

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        [Obsolete("This method is deprecated and will be removed at a future release. Please use string.Format().")]
        string ToString([CanBeNull] IFormatProvider provider, [NotNull] string format, [NotNull] params object[] args);
    }

    /// <summary>
    ///     A stronger typed interface where the unit enum type is known, to avoid passing in the
    ///     wrong unit enum type and not having to cast from <see cref="Enum"/>.
    /// </summary>
    /// <example>
    ///     IQuantity{LengthUnit} length;
    ///     double centimeters = length.As(LengthUnit.Centimeter); // Type safety on enum type
    /// </example>
    public interface IQuantity<TUnitType> : IQuantity where TUnitType : Enum
    {
        /// <summary>
        ///     Convert to a unit representation <typeparamref name="TUnitType"/>.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        double As(TUnitType unit);

        /// <inheritdoc cref="IQuantity.Unit"/>
        new TUnitType Unit { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        new QuantityInfo<TUnitType> QuantityInfo { get; }

        /// <summary>
        ///     Converts to a quantity with the given unit representation, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <returns>A new quantity with the given unit.</returns>
        IQuantity<TUnitType> ToUnit(TUnitType unit);

        /// <summary>
        ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
        /// <returns>A new quantity with the determined unit.</returns>
        new IQuantity<TUnitType> ToUnit(UnitSystem unitSystem);
    }
}
