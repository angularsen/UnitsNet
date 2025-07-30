// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
        /// <exception cref="UnitNotFoundException">Thrown when the <paramref name="unit" /> is not recognized.</exception>
        [Obsolete("This method will be removed from the interface in the next major update. Consider using the UnitConverter.Default.ConvertValue(quantity, unit) method instead.")]
        QuantityValue As(Enum unit)
#if NET
            => this.GetValue(unit)
#endif
        ;

        // /// <summary>
        // ///     Gets the value in the unit determined by the given <see cref="UnitSystem"/>. If multiple units were found for the given <see cref="UnitSystem"/>,
        // ///     the first match will be used.
        // /// </summary>
        // /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity value to.</param>
        // /// <returns>The converted value.</returns>
        // QuantityValue As(UnitSystem unitSystem);

#if EXTENDED_EQUALS_INTERFACE
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
        /// </summary>
        /// <param name="other">The other quantity to compare to. Not equal if the quantity types are different.</param>
        /// <param name="tolerance">The absolute tolerance value. Must be greater than or equal to zero. Must be same quantity type as <paramref name="other"/>.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified tolerance.</returns>
        /// <exception cref="ArgumentException">Tolerance must be of the same quantity type.</exception>
        bool Equals(IQuantity? other, IQuantity tolerance);
#endif

        /// <summary>
        ///     The unit this quantity was constructed with -or- BaseUnit if default ctor was used.
        /// </summary>
        Enum Unit { get; }

        /// <summary>
        ///     The value this quantity was constructed with. See also <see cref="Unit"/>.
        /// </summary>
        QuantityValue Value { get; }

        /// <summary>
        ///     Converts this <see cref="IQuantity"/> to an <see cref="IQuantity"/> in the given <paramref name="unit"/>.
        /// </summary>
        /// <param name="unit">
        ///     The unit <see cref="Enum"/> value. The <see cref="Enum"/> must be compatible with the units of the <see cref="IQuantity"/>.
        ///     For example, if the <see cref="IQuantity"/> is a <see cref="Length"/>, you should provide a <see cref="LengthUnit"/> value.
        /// </param>
        /// <exception cref="ArgumentException">Wrong unit enum type was given.</exception>
        /// <exception cref="UnitNotFoundException">Thrown when the <paramref name="unit" /> is not recognized.</exception>
        /// <returns>A new <see cref="IQuantity"/> in the given <paramref name="unit"/>.</returns>
        [Obsolete("This method will be removed from the interface in the next major update. Consider using the UnitConverter.Default.ConvertTo(quantity, unit) method instead.")]
        IQuantity ToUnit(Enum unit)
#if NET
            => UnitConverter.Default.ConvertTo(this, unit)
#endif
        ;

        /// <summary>
        ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>.
        ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
        /// <exception cref="ArgumentException">Thrown when no units were found for the given UnitSystem.</exception>
        /// <returns>A new quantity with the determined unit.</returns>
        [Obsolete("This method will be removed from the interface in the next major update. Consider using the UnitConverter.Default.ConvertTo(quantity, unit) method instead.")]
        IQuantity ToUnit(UnitSystem unitSystem)
#if NET
            => UnitConverter.Default.ConvertTo(this, QuantityInfo.GetDefaultUnit(unitSystem).UnitKey)
#endif
        ;

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
        // /// <summary>
        // ///     Convert to a unit representation <typeparamref name="TUnitType"/>.
        // /// </summary>
        // /// <returns>Value converted to the specified unit.</returns>
        // QuantityValue As(TUnitType unit);

        /// <inheritdoc cref="IQuantity.Unit"/>
        new TUnitType Unit { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        new QuantityInfo<TUnitType> QuantityInfo { get; }

        /// <summary>
        ///     Converts this <see cref="IQuantity{TUnitType}"/> to an <see cref="IQuantity{TUnitType}"/> in the given <paramref name="unit"/>.
        /// </summary>
        /// <param name="unit">The unit value.</param>
        /// <exception cref="UnitNotFoundException">Thrown when the <paramref name="unit" /> is not recognized.</exception>
        /// <returns>A new <see cref="IQuantity{TUnitType}"/> in the given <paramref name="unit"/>.</returns>
        [Obsolete("This method will be removed from the interface in the next major update. Consider using the UnitConverter.Default.ConvertToUnit(quantity, unit) method instead.")]
        IQuantity<TUnitType> ToUnit(TUnitType unit);
        
        /// <inheritdoc cref="IQuantity.ToUnit(UnitSystem)"/>
        [Obsolete("This method will be removed from the interface in the next major update. Consider using the UnitConverter.Default.ConvertToUnit(quantity, unit) method instead.")]
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

    /// <inheritdoc cref="IQuantity" />
    /// <remarks>
    ///     This is a specialization of <see cref="IQuantity" /> that is used (internally) for constraining certain
    ///     methods, without having to include the unit type as additional generic parameter.
    /// </remarks>
    /// <typeparam name="TQuantity"></typeparam>
    public interface IQuantityInstance<out TQuantity> : IQuantity
        where TQuantity : IQuantity
    {
#if NET
        internal static abstract TQuantity Create(QuantityValue value, UnitKey unit);
#else
        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        new IQuantityInstanceInfo<TQuantity> QuantityInfo { get; }
#endif
    }

    /// <summary>
    ///     An <see cref="IQuantity{TUnitType}"/> that supports generic equality comparison with tolerance.
    /// </summary>
    /// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
    /// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
    public interface IQuantity<TSelf, TUnitType> : IQuantityInstance<TSelf>, IQuantity<TUnitType>
        where TSelf : IQuantity<TSelf, TUnitType>
        where TUnitType : struct, Enum
    {
        // /// <summary>
        // /// Converts the quantity to the specified unit.
        // /// </summary>
        // /// <param name="unit">The unit to convert to.</param>
        // /// <returns>A new instance of the quantity in the specified unit.</returns>
        // new TSelf ToUnit(TUnitType unit);

        // /// <inheritdoc cref="IQuantity{TUnitType}.ToUnit(UnitSystem)"/>
        // new TSelf ToUnit(UnitSystem unitSystem);
        
        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        new QuantityInfo<TSelf, TUnitType> QuantityInfo { get; }

#if NET
        /// <summary>
        ///     Creates an instance of the quantity from a specified value and unit.
        /// </summary>
        /// <param name="value">The numerical value of the quantity.</param>
        /// <param name="unit">The unit of the quantity.</param>
        /// <returns>An instance of the quantity with the specified value and unit.</returns>
        static abstract TSelf From(QuantityValue value, TUnitType unit);

        static TSelf IQuantityInstance<TSelf>.Create(QuantityValue value, UnitKey unit) => TSelf.From(value, unit.ToUnit<TUnitType>());

        IQuantity<TUnitType> IQuantity<TUnitType>.ToUnit(TUnitType unit)
        {
            return TSelf.From(UnitConverter.Default.ConvertValue(Value, Unit, unit), unit);
        }

        IQuantity<TUnitType> IQuantity<TUnitType>.ToUnit(UnitSystem unitSystem)
        {
            TUnitType unit = QuantityInfo.GetDefaultUnit(unitSystem);
            return TSelf.From(UnitConverter.Default.ConvertValue(Value, Unit, unit), unit);
        }

#endif

    }
}
