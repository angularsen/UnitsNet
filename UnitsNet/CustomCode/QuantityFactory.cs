using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;

namespace UnitsNet
{
    /// <summary>
    ///     Factory to construct <see cref="IQuantity" /> objects from built-in or externally configured
    ///     quantity types and unit enum types.
    /// </summary>
    public class QuantityFactory
    {
        /// <summary>
        ///     A dictionary of info structs for each known type.
        /// </summary>
        private readonly Dictionary<string, QuantityInfo> _configuredQuantities;

        static QuantityFactory()
        {
            Default = new QuantityFactory();
        }

        /// <summary>
        ///     Default constructor. Uses a list of types from the Quantity object.
        /// </summary>
        public QuantityFactory()
        {
            _configuredQuantities = Quantity.Infos.ToDictionary(x => x.Name, x => x);
        }

        /// <summary>
        ///     A default instance of a QuantityFactory.  Can construct all of the types defined in the core UnitsNet.
        /// </summary>
        public static QuantityFactory Default { get; }

        /// <summary>
        ///     A dictionary of info structs for each known type.
        /// </summary>
#if (!NET40)
        public IReadOnlyDictionary
#else
        public IDictionary
#endif
            <string, QuantityInfo> ConfiguredQuantities => _configuredQuantities;

        /// <summary>
        ///     Configures a new quantity type and its corresponding unit enum type.
        /// </summary>
        /// <example>
        ///     This can be useful to support serializing and deserializing third-party quantity types that implement <see cref="IQuantity"/>.
        /// </example>
        /// <param name="quantityInfo">Description of the quantity.</param>
        public void AddUnit(QuantityInfo quantityInfo)
        {
            var quantityName = quantityInfo.Name;
            _configuredQuantities[quantityName] = quantityInfo;
        }

        /// <summary>
        ///     Dynamically construct a quantity from a number and a unit enum.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity" /> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public IQuantity From(QuantityValue value, Enum unit)
        {
            var unitEnumType = unit.GetType();
            EnsureQuantityForUnitEnumIsConfigured(unitEnumType);

            var success = TryFrom(value, unit, out var quantity);
            if (!success)
            {
                throw new UnitsNetException($"Unable to create IQuantity with unit {Enum.GetName(unitEnumType, unit)}.");
            }

            return quantity;
        }

        /// <summary>
        ///     Try to create an IQuantity based on a value and a unit
        /// </summary>
        /// <param name="value">The number of the quantity.</param>
        /// <param name="unit">The unit of measure for the quantity.</param>
        /// <param name="quantity">The value in which to return the IQuantity.</param>
        /// <returns>True is creation of the IQuantity was successful.</returns>
        public bool TryFrom(double value, Enum unit, out IQuantity quantity)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                quantity = default;
                return false;
            }

            return TryFrom((QuantityValue) value, unit, out quantity);
        }


        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)" />
        public bool TryFrom(QuantityValue value, Enum unit, out IQuantity quantity)
        {
            var unitTypeName = unit.GetType().Name;
            var quantityTypeName = unitTypeName.Remove(unitTypeName.Length - "Unit".Length);
            if (!_configuredQuantities.TryGetValue(quantityTypeName, out QuantityInfo quantityInfo))
            {
                quantity = default;
                return false;
            }

            return quantityInfo.TryFrom(value, unit, out quantity);
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)" />
        public IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">
        ///     The format provider to use for lookup. Defaults to
        ///     <see cref="CultureInfo.CurrentUICulture" /> if null.
        /// </param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length" />.</param>
        /// <param name="quantityString">
        ///     Quantity string representation, such as "1.5 kg". Must be compatible with given quantity
        ///     type.
        /// </param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        public IQuantity Parse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
            {
                throw new ArgumentException($"Type {quantityType.FullName} must be of type UnitsNet.IQuantity.");
            }

            if (TryParse(formatProvider, quantityType, quantityString, out var quantity))
            {
                return quantity;
            }

            throw new ArgumentException($"Quantity string could not be parsed to quantity {quantityType.FullName}.");
        }

        /// <inheritdoc cref="TryParse(IFormatProvider, System.Type,string,out IQuantity)" />
        public bool TryParse(Type quantityType, string quantityString, out IQuantity quantity)
        {
            return TryParse(null, quantityType, quantityString, out quantity);
        }

        /// <summary>
        ///     Attempt to parse a Quantity from a type and a string consisting of value and unit.
        /// </summary>
        /// <param name="formatProvider">Language format</param>
        /// <param name="quantityType">The type of quantity to create</param>
        /// <param name="quantityString">A string representation of the quantity.</param>
        /// <param name="quantity">Output value</param>
        /// <returns>True is parsing succeeded</returns>
        public bool TryParse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString, out IQuantity quantity)
        {
            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
            {
                quantity = default;
                return false;
            }

            if (!_configuredQuantities.TryGetValue(quantityType.Name, out QuantityInfo quantityInfo))
            {
                quantity = default;
                return false;
            }

            return quantityInfo.TryParse(formatProvider, quantityString, out quantity);
        }

        /// <summary>
        ///     Produces a Quantity from a number as a QuantityValue and a unit as a string.
        /// </summary>
        /// <param name="value">The number of units.</param>
        /// <param name="unit">The unit as a string - e.g "MassUnit.Kilogram"</param>
        /// <returns>An IQuantity.</returns>
        public IQuantity FromValueAndUnit(QuantityValue value, string unit)
        {
            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            string unitEnumTypeName = unit.Split('.')[0];
            string unitEnumValue = unit.Split('.')[1];
            string quantityTypeName = unitEnumTypeName.Remove(unitEnumTypeName.Length - 4);

            if (!_configuredQuantities.ContainsKey(quantityTypeName))
            {
                throw new UnitsNetException($"Unit type {quantityTypeName} not known.");
            }

            var unitEnumType = _configuredQuantities[quantityTypeName].UnitType;

            var unitValue = (Enum) Enum.Parse(unitEnumType, unitEnumValue); // Ex: MassUnit.Kilogram

            return From(value, unitValue);
        }

        /// <summary>
        ///     A function to check if building a particular type is supported in this QuantityFactory.
        /// </summary>
        /// <param name="objectType">The type of object to check.</param>
        /// <returns>True if the type is supported.</returns>
        public bool CanCreate(Type objectType)
        {
            return _configuredQuantities.ContainsKey(objectType.Name);
        }

        private void EnsureQuantityForUnitEnumIsConfigured(Type unitEnumType)
        {
            // "LengthUnit"
            var unitTypeName = unitEnumType.Name;

            // "LengthUnit" => "Length"
            var quantityName = unitTypeName.Substring(0, unitTypeName.Length - "Unit".Length);

            if (!_configuredQuantities.ContainsKey(quantityName))
            {
                throw new UnitsNetException($"No quantity is configured for unit enum type {unitEnumType.FullName}. Make sure to call AddUnit() first.");
            }
        }
    }
}
