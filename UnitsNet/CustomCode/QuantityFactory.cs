using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
        public void AddUnit(Type quantityType)
        {
            var quantityInfoProperty = quantityType.GetProperty("QuantityInfo");
            if (quantityInfoProperty == null)
            {
                throw new UnitsNetException($"Invalid type registration {quantityType.Name}. Type must implement IQuantity.");
            }
            var info = (QuantityInfo)(quantityInfoProperty.GetValue(null,null));

            KnownQuantities[info.Name] = info;
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
        public bool TryFrom(QuantityValue value, Enum unit, out IQuantity quantity)
        {
            // Implicit cast to QuantityValue would prevent TryFrom from being called,
            // so we need to explicitly check this here for double arguments.
            if (double.IsNaN((double)value) || double.IsInfinity((double)value))
            {
                quantity = default;
                return false;
            }

            var unitTypeName = unit.GetType().Name;
            if (!KnownQuantities.ContainsKey(unitTypeName))
            {
                quantity = default;
                return false;
            }

            try
            {
                quantity = (IQuantity)Activator.CreateInstance
                    (
                    KnownQuantities[unitTypeName].UnitType,
                    BindingFlags.CreateInstance,
                    null,
                    value,
                    unit
                    );
                return quantity != null;
            }
            catch (Exception)
            {
                quantity = default;
                return false;
            }
            
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

            var result = KnownQuantities[quantityType.Name].Builder(formatProvider,quantityString);

            if (result.Item2) quantity = result.Item1;

            return result.Item2;
        }
    }

}

