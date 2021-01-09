using System;

namespace UnitsNet
{
        /// <inheritdoc />
    public class QuantityFactory : IQuantityFactory
    {
        /// <inheritdoc />
        public IQuantity FromQuantityInfo(QuantityInfo quantityInfo, QuantityValue value)
        {
            return Quantity.FromQuantityInfo(quantityInfo, value);
        }

        /// <inheritdoc />
        public bool TryFrom(QuantityValue value, Enum unit, out IQuantity? quantity)
        {
            return Quantity.TryFrom(value, unit, out quantity);
        }

        /// <inheritdoc />
        public bool TryParse(IFormatProvider? formatProvider, Type quantityType, string quantityString, out IQuantity? quantity)
        {
            return Quantity.TryParse(formatProvider, quantityType, quantityString, out quantity);
        }
    }
}
