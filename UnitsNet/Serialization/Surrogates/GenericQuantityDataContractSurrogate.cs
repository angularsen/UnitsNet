// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NETFRAMEWORK
using System;
using UnitsNet.Serialization.Contracts;

namespace UnitsNet.Serialization.Surrogates
{
    /// <summary>
    ///     Can be used (e.g. with the default DataContractJsonSerializer) to enforce a string-based representation for all
    ///     units (enum), using the "{UnitType}.{UnitValue}" format (e.g. "MassUnit.Kilogram").
    ///     <remarks>
    ///         <para>Supports both double and decimal valued quantities.</para>
    ///     </remarks>
    /// </summary>
    public class GenericQuantityDataContractSurrogate : QuantityDataContractSurrogateBase
    {
        /// <inheritdoc />
        public override Type GetDataContractType(Type type)
        {
            if (typeof(IDecimalQuantity).IsAssignableFrom(type))
            {
                return typeof(QuantityValueContract<decimal, string>);
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
                QuantityValueContract<double, string> doubleQuantity => FromQuantityValue(doubleQuantity.Value, doubleQuantity.Unit),
                QuantityValueContract<decimal, string> decimalQuantity => FromQuantityValue(decimalQuantity.Value, decimalQuantity.Unit),
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
                return new QuantityValueContract<decimal, string>(decimalQuantity.Value, unit);
            }

            return new QuantityValueContract<double, string>(quantity.Value, unit);
        }
    }
}
#endif
