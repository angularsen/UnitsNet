using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;

namespace UnitsNet
{
    /// <summary>
    /// 
    /// </summary>
    public class QuantityFactory
    {
        /// <summary>
        /// A default instance of a QuantityFactory.  Can construct all of the types defined in the core UnitsNet.
        /// </summary>
        public static QuantityFactory Default { get; }

        static QuantityFactory()
        {
            Default = new QuantityFactory();
        }

        /// <summary>
        /// Default constructor.  Uses a list of types from the Quantity object.
        /// </summary>
        public QuantityFactory()
        {
            KnownQuantities = Quantity.Infos.ToDictionary(x => x.Name, x => x);
        }

        /// <summary>
        /// A dictionary of info structs for each known type.
        /// </summary>
        public Dictionary<string, QuantityInfo> KnownQuantities;

        /// <summary>
        ///     Adds a type defined in an external assembly for serialisation
        /// </summary>
        /// <param name="quantityType">The quantity type.</param>
        /// <param name="unitType">The unit type for the quantity.</param>
        public void AddUnit(Type quantityType,Type unitType)
        {
            //var baseUnitProperty = quantityType.GetProperty("BaseUnit");

            var quantityInfoProperty = quantityType.GetProperty("QuantityInfo");
            if (quantityInfoProperty == null)
            {
                throw new UnitsNetException($"Invalid type registration {quantityType.Name}. Type must implement IQuantity and have a static BaseUnit property.");
            }

            var baseUnit = Enum.ToObject(unitType, 1);

            var parameters = new object[] {1.0, baseUnit};
            var instance = (IQuantity)Activator.CreateInstance
            (
                quantityType,
                BindingFlags.CreateInstance,
                null,
                parameters,
                CultureInfo.InvariantCulture
            );
            var info = (QuantityInfo)(quantityInfoProperty.GetValue(instance, null));

            KnownQuantities[info.ValueType.Name] = info;
        }

        /// <summary>
        ///     Dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public IQuantity From(QuantityValue value, Enum unit)
        {
            var unitTypeName = unit.GetType().Name;
            var quantityName = unitTypeName.Substring(0, unitTypeName.Length - "Unit".Length);
            if (!KnownQuantities.ContainsKey(quantityName))
            {
                throw new UnitsNetException($"Unknown unit type {unit.GetType().Name}");
            }

            var success = TryFrom(value, unit, out IQuantity quantity);

            if (!success)
            {
                throw new UnitsNetException($"Unable to create IQuantity with unit {Enum.GetName(unit.GetType(),unit)}.");
            }

            return quantity;
        }


        /// <summary>
        /// Try to create an IQuantity based on a value and a unit
        /// </summary>
        /// <param name="value">The number of the quantity.</param>
        /// <param name="unit">The unit of measure for the quantity.</param>
        /// <param name="quantity">The value in which to return the IQuantity.</param>
        /// <returns>True is creation of the IQuantity was successful.</returns>
        public bool TryFrom(double value, Enum unit, out IQuantity quantity)
        {
            if (double.IsNaN((double)value) || double.IsInfinity((double)value))
            {
                quantity = default;
                return false;
            }

            return TryFrom((QuantityValue) value, unit, out quantity);
        }


        /// <inheritdoc cref = "Parse(IFormatProvider, System.Type,string)" />
        public bool TryFrom(QuantityValue value, Enum unit, out IQuantity quantity)
        {
            var unitTypeName = unit.GetType().Name;
            var quantityTypeName = unitTypeName.Remove(unitTypeName.Length - "Unit".Length);
            if (!KnownQuantities.ContainsKey(quantityTypeName))
            {
                quantity = default;
                return false;
            }

            var result = KnownQuantities[quantityTypeName].TryFrom(value, unit);
            quantity = result.Item1;
            return result.Item2;

            
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        public IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        public IQuantity Parse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
            {
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");
            }

            if (TryParse(formatProvider, quantityType, quantityString, out IQuantity quantity))
                return quantity;

            throw new ArgumentException($"Quantity string could not be parsed to quantity {quantityType}.");
        }

        /// <inheritdoc cref="TryParse(IFormatProvider, System.Type,string,out IQuantity)"/>
        public bool TryParse(Type quantityType, string quantityString, out IQuantity quantity)
        {
            return TryParse(null, quantityType, quantityString, out quantity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatProvider"></param>
        /// <param name="quantityType"></param>
        /// <param name="quantityString"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool TryParse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString, out IQuantity quantity)
        {
            if (!KnownQuantities.ContainsKey(quantityType.Name))
            {
                quantity = default;
                return false;
            }

            quantity = default;

            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
            {
                return false;
            }

            var result = KnownQuantities[quantityType.Name].TryParse(formatProvider,quantityString);

            if (result.Item2) quantity = result.Item1;

            return result.Item2;
        }

        /// <summary>
        /// Gets the name of a unit type base on a Quantity value.
        /// </summary>
        /// <param name="value">The value for which to get the unit name.</param>
        /// <returns>A unit type name (Mass, Length, etc).</returns>
        public string UnitTypeName(IQuantity value)
        {
            var result = value.QuantityInfo.UnitType.Name;
            if (!KnownQuantities.ContainsKey(value.GetType().Name))
            {
                throw new UnitsNetException($"Unknown type {value.GetType().Name}");
            }

            return KnownQuantities[value.GetType().Name].Name;
            
        }

        public IQuantity FromValueAndUnit(QuantityValue value,string unit)
        {
            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            string unitEnumTypeName = unit.Split('.')[0];
            string unitEnumValue = unit.Split('.')[1];
            string quantityTypeName = unitEnumTypeName.Remove(unitEnumTypeName.Length - 4);

            Type unitEnumType;
            if (!KnownQuantities.ContainsKey(quantityTypeName))
            {
                throw new UnitsNetException($"Unit type {quantityTypeName} not known.");
            }

            unitEnumType = KnownQuantities[quantityTypeName].UnitType;
            
            Enum unitValue = (Enum)Enum.Parse(unitEnumType, unitEnumValue); // Ex: MassUnit.Kilogram

            return From(value, unitValue);
        }

        public bool CanBuild(Type objectType)
        {
            return KnownQuantities.ContainsKey(objectType.Name);
        }
    }

}

