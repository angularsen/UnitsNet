// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NETFRAMEWORK
using System;
using System.Globalization;
using UnitsNet.Serialization.Contracts;

namespace UnitsNet.Serialization.Surrogates
{
    /// <summary>
    ///     Can be used (e.g. with the default DataContractJsonSerializer) to enforce a string-based representation for all
    ///     units (enum), using the "{UnitType}.{UnitValue}" format (e.g. "MassUnit.Kilogram").
    ///     <para>
    ///         In addition, values using a decimal value-type are represented both as the standard (double) format as well as
    ///         using their string-value-representation.
    ///     </para>
    ///     <remarks>
    ///         The produced Json representation should (<i>normally</i>) be compatible with the one produced by the JsonNet
    ///         serializer.
    ///         For more information visit https://github.com/angularsen/UnitsNet#serialization
    ///     </remarks>
    /// </summary>
    public class ExtendedQuantityDataContractSurrogate : QuantityDataContractSurrogateBase
    {
        /// <inheritdoc />
        public override Type GetDataContractType(Type type)
        {
            if (typeof(IDecimalQuantity).IsAssignableFrom(type))
            {
                return typeof(ExtendedQuantityValueContract<string, string>);
            }

            if (typeof(IQuantity).IsAssignableFrom(type))
            {
                return typeof(QuantityValueContract<double, string>);
            }

            return type;
        }

        /// <inheritdoc />
        public override object GetDeserializedObject(object obj, Type targetType)
        {
            return obj switch
            {
                ExtendedQuantityValueContract<string, string> decimalQuantity
                    => FromQuantityValue(decimal.Parse(decimalQuantity.ValueString), decimalQuantity.Unit),
                QuantityValueContract<double, string> doubleQuantity
                    => FromQuantityValue(doubleQuantity.Value, doubleQuantity.Unit),
                _ => obj
            };
        }

        /// <inheritdoc />
        public override object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is not IQuantity quantity) return obj;
            var unit = $"{quantity.QuantityInfo.UnitType.Name}.{quantity.Unit}";
            if (quantity is IDecimalQuantity decimalQuantity)
            {
                return new ExtendedQuantityValueContract<string, string>(quantity.Value, unit,
                    decimalQuantity.Value.ToString(CultureInfo.InvariantCulture), "decimal");
            }

            return new QuantityValueContract<double, string>(quantity.Value, unit);
        }
    }
}
#endif
