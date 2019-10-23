// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity.
    /// </summary>
    public interface IQuantityT<T> : IQuantity
    {
        /// <summary>
        ///     Gets the value in the given unit.
        /// </summary>
        /// <param name="unit">The unit enum value. The unit must be compatible, so for <see cref="Length{T}"/> you should provide a <see cref="LengthUnit"/> value.</param>
        /// <returns>Value converted to the specified unit.</returns>
        /// <exception cref="InvalidCastException">Wrong unit enum type was given.</exception>
        new T As( Enum unit );

        /// <summary>
        ///     Gets the value in the unit determined by the given <see cref="UnitSystem"/>. If multiple units were found for the given <see cref="UnitSystem"/>,
        ///     the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity value to.</param>
        /// <returns>The converted value.</returns>
        new T As( UnitSystem unitSystem );

        /// <summary>
        ///     The value this quantity was constructed with. See also <see cref="IQuantity.Unit"/>.
        /// </summary>
        new T Value { get; }

        /// <summary>
        ///     Converts to a quantity with the given unit representation, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="unit">The unit enum value. The unit must be compatible, so for <see cref="Length{T}"/> you should provide a <see cref="LengthUnit"/> value.</param>
        /// <returns>A new quantity with the given unit.</returns>
        new IQuantityT<T> ToUnit( Enum unit );

        /// <summary>
        ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
        /// <returns>A new quantity with the determined unit.</returns>
        new IQuantityT<T> ToUnit( UnitSystem unitSystem );
    }

    /// <summary>
    ///     A stronger typed interface where the unit enum type is known, to avoid passing in the
    ///     wrong unit enum type and not having to cast from <see cref="Enum"/>.
    /// </summary>
    /// <example>
    ///     IQuantity{LengthUnit} length;
    ///     double centimeters = length.As(LengthUnit.Centimeter); // Type safety on enum type
    /// </example>
    public interface IQuantityT<TUnitType, T> : IQuantity<TUnitType> where TUnitType : Enum
    {
        /// <summary>
        ///     Convert to a unit representation <typeparamref name="TUnitType"/>.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        new T As( TUnitType unit );

        /// <summary>
        ///     Converts to a quantity with the given unit representation, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <returns>A new quantity with the given unit.</returns>
        new IQuantityT<TUnitType, T> ToUnit( TUnitType unit );

        /// <summary>
        ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
        /// <returns>A new quantity with the determined unit.</returns>
        new IQuantityT<TUnitType, T> ToUnit( UnitSystem unitSystem );
    }
}
