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
    ///         <para>
    ///             Only supports the double-valued quantities. This surrogate definition is mostly here for
    ///             backward-compatibility with the UnitsNetJsonConverter.
    ///             Unless you are in a position that requires such compatibility or in one where you don't expect to be
    ///             working with decimal-valued quantities, make sure to have a look at the
    ///             <see cref="GenericQuantityDataContractSurrogate" /> or the
    ///             <see cref="ExtendedQuantityDataContractSurrogate" />.
    ///         </para>
    ///     </remarks>
    /// </summary>
    public class BasicQuantityContractSurrogate : QuantityDataContractSurrogateBase
    {
        /// <inheritdoc />
        public override Type GetDataContractType(Type type)
        {
            return typeof(IQuantity).IsAssignableFrom(type) ? typeof(QuantityValueContract<double, string>) : type;
        }

        /// <inheritdoc />
        public override object GetDeserializedObject(object obj, Type targetType)
        {
            return obj switch
            {
                QuantityValueContract<double, string> doubleQuantity => FromQuantityValue(doubleQuantity.Value, doubleQuantity.Unit),
                _ => obj
            };
        }


        /// <inheritdoc />
        public override object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is not IQuantity quantity) return obj;
            var unit = $"{quantity.QuantityInfo.UnitType.Name}.{quantity.Unit}";
            return new QuantityValueContract<double, string>(quantity.Value, unit);
        }
    }
}
#endif
