// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NETFRAMEWORK
using System;
using System.Globalization;
using System.Runtime.Serialization;
using UnitsNet.Serialization.Contracts;

namespace UnitsNet.Serialization.Surrogates
{
    /// <summary>
    ///     Can be used (e.g. with the default DataContractJsonSerializer) to enforce a string-based representation for all
    ///     units (enum), using the quantity type name along with the unit abbreviation format (e.g. {'1', 'kg', 'Mass'})
    /// </summary>
    public class QuantityWithAbbreviationContractSurrogate : QuantityDataContractSurrogateBase
    {
        /// <inheritdoc />
        public override Type GetDataContractType(Type type)
        {
            if (typeof(IDecimalQuantity).IsAssignableFrom(type))
            {
                return typeof(QuantityWithAbbreviationContract<string, decimal>);
            }

            if (typeof(IQuantity).IsAssignableFrom(type))
            {
                return typeof(QuantityWithAbbreviationContract<string, double>);
            }

            return type;
        }

        /// <inheritdoc />
        public override object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is not IQuantity quantity) return obj;
            var unit = quantity.ToString("a", CultureInfo.InvariantCulture);
            if (quantity is IDecimalQuantity decimalQuantity)
            {
                return new QuantityWithAbbreviationContract<string, decimal>(quantity.QuantityInfo.Name, decimalQuantity.Value, unit);
            }

            return new QuantityWithAbbreviationContract<string, double>(quantity.QuantityInfo.Name, quantity.Value, unit);
        }

        /// <inheritdoc />
        public override object GetDeserializedObject(object obj, Type targetType)
        {
            return obj switch
            {
                QuantityWithAbbreviationContract<string, double> doubleValue =>
                    FromQuantityWithAbbreviation(doubleValue.QuantityType, doubleValue.Value, doubleValue.Unit),
                QuantityWithAbbreviationContract<string, decimal> decimalValue =>
                    FromQuantityWithAbbreviation(decimalValue.QuantityType, decimalValue.Value, decimalValue.Unit),
                _ => obj
            };
        }

        private static IQuantity FromQuantityWithAbbreviation(string quantityType, QuantityValue value, string unitAbbreviation)
        {
            return Quantity.ByName.TryGetValue(quantityType, out var quantityInfo)
                ? Quantity.From(value, UnitParser.Default.Parse(unitAbbreviation, quantityInfo.UnitType, CultureInfo.InvariantCulture))
                : throw new SerializationException($"Unknown quantity type: '{quantityType}'");
        }
    }
}
#endif
