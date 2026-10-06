// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    /// <summary>
    ///     Converts quantities to and from a <see cref="UnitOf{TQuantity}" />.
    /// </summary>
    public static class UnitOfExtensions
    {
        /// <summary>
        ///     Gets the value of the quantity in a <see cref="UnitOf{TQuantity}" />, such as a furlong of
        ///     <see cref="Length" />.
        /// </summary>
        /// <param name="quantity">The quantity to convert.</param>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The value in <paramref name="unit" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="unit" /> is <c>null</c>.</exception>
        public static double As<TQuantity>(this TQuantity quantity, UnitOf<TQuantity> unit)
            where TQuantity : IQuantity
        {
            if (unit is null) throw new ArgumentNullException(nameof(unit));
            return quantity.As(quantity.QuantityInfo.BaseUnitInfo.Value) / unit.ValueInBaseUnit;
        }

        /// <summary>
        ///     Creates a quantity from a value in a <see cref="UnitOf{TQuantity}" />, such as a furlong of
        ///     <see cref="Length" />.
        /// </summary>
        /// <param name="quantityInfo">The information of the quantity, such as <see cref="Length.Info" />.</param>
        /// <param name="value">The numerical value in <paramref name="unit" />.</param>
        /// <param name="unit">The unit of the value.</param>
        /// <returns>
        ///     The quantity in its base unit, since a quantity can only be in one of its own units.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="quantityInfo" /> or <paramref name="unit" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="quantityInfo" /> is not the information of <typeparamref name="TQuantity" />.
        /// </exception>
        public static TQuantity From<TQuantity>(this QuantityInfo quantityInfo, QuantityValue value, UnitOf<TQuantity> unit)
            where TQuantity : IQuantity
        {
            if (quantityInfo is null) throw new ArgumentNullException(nameof(quantityInfo));
            if (unit is null) throw new ArgumentNullException(nameof(unit));
            if (quantityInfo.ValueType != typeof(TQuantity))
            {
                throw new ArgumentException(
                    $"A unit of {typeof(TQuantity).Name} can't be used with {quantityInfo.Name}.", nameof(quantityInfo));
            }

            return (TQuantity)Quantity.From((double)value * unit.ValueInBaseUnit, quantityInfo.BaseUnitInfo.Value);
        }
    }
}
