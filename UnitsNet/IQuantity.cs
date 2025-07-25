﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity.
    /// </summary>
    public interface IQuantity : IFormattable
    {
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
        ///     <para>
        ///     Compare equality to <paramref name="other"/> given a <paramref name="tolerance"/> for the maximum allowed +/- difference.
        ///     </para>
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within 0.01 of a (0.01m or 1cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromMeters(2.1);
        ///     var tolerance = Length.FromCentimeters(10);
        ///     a.Equals(b, tolerance); // true, 2m equals 2.1m +/- 0.1m
        ///     </code>
        ///     </example>
        ///     <para>
        ///     It is generally advised against specifying "zero" tolerance, due to the nature of floating-point operations.
        ///     </para>
        /// </summary>
        /// <param name="other">The other quantity to compare to. Not equal if the quantity types are different.</param>
        /// <param name="tolerance">The absolute tolerance value. Must be greater than or equal to zero. Must be same quantity type as <paramref name="other"/>.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified tolerance.</returns>
        /// <exception cref="ArgumentException">Tolerance must be of the same quantity type.</exception>
        bool Equals(IQuantity? other, IQuantity tolerance);

        /// <summary>
        ///     The unit this quantity was constructed with -or- BaseUnit if default ctor was used.
        /// </summary>
        Enum Unit { get; }

        /// <summary>
        ///     The value this quantity was constructed with. See also <see cref="Unit"/>.
        /// </summary>
        double Value { get; }

        /// <summary>
        ///     Converts this <see cref="IQuantity"/> to an <see cref="IQuantity"/> in the given <paramref name="unit"/>.
        /// </summary>
        /// <param name="unit">
        ///     The unit <see cref="Enum"/> value. The <see cref="Enum"/> must be compatible with the units of the <see cref="IQuantity"/>.
        ///     For example, if the <see cref="IQuantity"/> is a <see cref="Length"/>, you should provide a <see cref="LengthUnit"/> value.
        /// </param>
        /// <exception cref="NotImplementedException">Conversion was not possible from this <see cref="IQuantity"/> to <paramref name="unit"/>.</exception>
        /// <returns>A new <see cref="IQuantity"/> in the given <paramref name="unit"/>.</returns>
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
        /// <param name="provider">Format to use for localization and number formatting. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        string ToString(IFormatProvider? provider);

        /// <summary>
        ///     Gets the unique key for the unit type and its corresponding value.
        /// </summary>
        /// <remarks>
        ///     This property is particularly useful when using an enum-based unit in a hash-based collection,
        ///     as it avoids the boxing that would normally occur when casting the enum to <see cref="Enum" />.
        /// </remarks>
        UnitKey UnitKey { get; }
    }

    /// <summary>
    ///     A stronger typed interface where the unit enum type is known, to avoid passing in the
    ///     wrong unit enum type and not having to cast from <see cref="Enum"/>.
    /// </summary>
    /// <example>
    ///     IQuantity{LengthUnit} length;
    ///     double centimeters = length.As(LengthUnit.Centimeter); // Type safety on enum type
    /// </example>
    /// <typeparam name="TUnitType">The unit type of the quantity.</typeparam>
    public interface IQuantity<TUnitType> : IQuantity
        where TUnitType : struct, Enum
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
        ///     Converts this <see cref="IQuantity{TUnitType}"/> to an <see cref="IQuantity{TUnitType}"/> in the given <paramref name="unit"/>.
        /// </summary>
        /// <param name="unit">The unit value.</param>
        /// <exception cref="NotImplementedException">Conversion was not possible from this <see cref="IQuantity"/> to <paramref name="unit"/>.</exception>
        /// <returns>A new <see cref="IQuantity{TUnitType}"/> in the given <paramref name="unit"/>.</returns>
        IQuantity<TUnitType> ToUnit(TUnitType unit);

        /// <summary>
        ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
        /// <returns>A new quantity with the determined unit.</returns>
        new IQuantity<TUnitType> ToUnit(UnitSystem unitSystem);

#if NET

        #region Implementation of IQuantity

        QuantityInfo IQuantity.QuantityInfo
        {
            get => QuantityInfo;
        }

        Enum IQuantity.Unit
        {
            get => Unit;
        }

        #endregion

#endif
    }

    /// <summary>
    ///     An <see cref="IQuantity{TUnitType}"/> that supports generic equality comparison with tolerance.
    /// </summary>
    /// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
    /// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
    public interface IQuantity<TSelf, TUnitType> : IQuantity<TUnitType>
        where TSelf : IQuantity<TSelf, TUnitType>
        where TUnitType : struct, Enum
    {
        /// <summary>
        ///     <para>
        ///     Compare equality to <paramref name="other"/> given a <paramref name="tolerance"/> for the maximum allowed +/- difference.
        ///     </para>
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within 0.01 of a (0.01m or 1cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromMeters(2.1);
        ///     var tolerance = Length.FromCentimeters(10);
        ///     a.Equals(b, tolerance); // true, 2m equals 2.1m +/- 0.1m
        ///     </code>
        ///     </example>
        ///     <para>
        ///     It is generally advised against specifying "zero" tolerance, due to the nature of floating-point operations.
        ///     </para>
        /// </summary>
        /// <param name="other">The other quantity to compare to.</param>
        /// <param name="tolerance">The absolute tolerance value. Must be greater than or equal to zero.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified tolerance.</returns>
        bool Equals(TSelf? other, TSelf tolerance);

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        new QuantityInfo<TSelf, TUnitType> QuantityInfo { get; }

#if NET7_0_OR_GREATER
        /// <summary>
        ///     Creates an instance of the quantity from a specified value and unit.
        /// </summary>
        /// <param name="value">The numerical value of the quantity.</param>
        /// <param name="unit">The unit of the quantity.</param>
        /// <returns>An instance of the quantity with the specified value and unit.</returns>
        static abstract TSelf From(double value, TUnitType unit);

#endif
    }
}
