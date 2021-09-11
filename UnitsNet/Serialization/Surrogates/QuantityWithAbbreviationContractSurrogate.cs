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
                return typeof(QuantityWithAbbreviationContract<decimal, string>);
            }

            if (typeof(IQuantity).IsAssignableFrom(type))
            {
                return typeof(QuantityWithAbbreviationContract<double, string>);
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
                return new QuantityWithAbbreviationContract<decimal, string>(decimalQuantity.Value, quantity.QuantityInfo.Name, unit);
            }

            return new QuantityWithAbbreviationContract<double, string>(quantity.Value, quantity.QuantityInfo.Name, unit);
        }

        /// <inheritdoc />
        public override object GetDeserializedObject(object obj, Type targetType)
        {
            return obj switch
            {
                QuantityWithAbbreviationContract<double, string> doubleValue =>
                    FromQuantityWithAbbreviation(doubleValue.Value, doubleValue.QuantityType, doubleValue.Unit),
                QuantityWithAbbreviationContract<decimal, string> decimalValue =>
                    FromQuantityWithAbbreviation(decimalValue.Value, decimalValue.QuantityType, decimalValue.Unit),
                _ => obj
            };
        }

        private static IQuantity FromQuantityWithAbbreviation(QuantityValue value, string quantityType, string unitAbbreviation)
        {
            return Quantity.ByName.TryGetValue(quantityType, out var quantityInfo)
                ? Quantity.From(value, UnitParser.Default.Parse(unitAbbreviation, quantityInfo.UnitType, CultureInfo.InvariantCulture))
                : throw new SerializationException($"Unknown quantity type: '{quantityType}'");
        }
    }
}
#endif
