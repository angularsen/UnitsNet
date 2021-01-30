using System;
using UnitsNet.InternalHelpers;

namespace UnitsNet
{
    /// <inheritdoc />
    public sealed class QuantityFactory : IQuantityFactory
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
        internal IQuantity From(QuantityValue value, Enum unit)
        {
            if (TryFrom(value, unit, out IQuantity? quantity))
                return quantity!;

            // TODO: refer to specific quantity factory
            throw new ArgumentException(
                $"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a third-party enum type defined outside UnitsNet library?");
        }

        /// <inheritdoc />
        internal static IQuantity Parse(IFormatProvider? formatProvider, Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");

            if (Quantity.TryParse(formatProvider, quantityType, quantityString, out IQuantity? quantity))
                return quantity!;

            throw new ArgumentException($"Quantity string could not be parsed to quantity {quantityType}.");
        }

        /// <inheritdoc />
        public bool TryParse(IFormatProvider? formatProvider, Type quantityType, string quantityString, out IQuantity? quantity)
        {
            return Quantity.TryParse(formatProvider, quantityType, quantityString, out quantity);
        }

        /// <inheritdoc />
        internal bool TryFrom(double value, Enum unit, out IQuantity? quantity)
        {
            // Implicit cast to QuantityValue would prevent TryFrom from being called,
            // so we need to explicitly check this here for double arguments.
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                quantity = default(IQuantity);
                return false;
            }

            return Quantity.TryFrom((QuantityValue)value, unit, out quantity);
        }

        /// <inheritdoc />
        internal IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);
    }
}
