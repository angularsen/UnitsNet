using System;
using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    /// Factory for <see cref="IQuantity"/>.
    /// </summary>
    public interface IQuantityFactory
    {
        /// <summary>
        /// Dynamically constructs a quantity of the given <see cref="QuantityInfo"/> with the value in the quantity's base units.
        /// </summary>
        /// <param name="quantityInfo">The <see cref="QuantityInfo"/> of the quantity to create.</param>
        /// <param name="value">The value to construct the quantity with.</param>
        /// <returns>The created quantity.</returns>
        IQuantity FromQuantityInfo(QuantityInfo quantityInfo, QuantityValue value);

        /// <summary>
        ///     Try to dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <param name="quantity">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns><c>True</c> if successful with <paramref name="quantity"/> assigned the value, otherwise <c>false</c>.</returns>
        bool TryFrom(QuantityValue value, Enum unit, out IQuantity? quantity);

        /// <summary>
        ///     Try to dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <param name="quantity">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns>The parsed quantity.</returns>
        bool TryParse(IFormatProvider? formatProvider, Type quantityType, string quantityString, out IQuantity? quantity);
    }
}
