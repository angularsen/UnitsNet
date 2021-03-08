// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Runtime.Serialization;

namespace UnitsNet.Serialization.Contracts
{
    /// <summary>
    /// An extension to the basic quantity contract that allows for dual representation of a non-standard quantity (e.g. <see cref="IDecimalQuantity"/>).
    /// This contract is provided for compatibility with the JsonNet representation (see https://github.com/angularsen/UnitsNet#serialization)
    /// </summary>
    [DataContract]
    public class ExtendedQuantityValueContract<TValueType, TUnit>: QuantityValueContract<double, TUnit>
    {
        /// <summary>
        /// Initializes a new quantity with the given standard unit and value pair, plus their extended representation
        /// </summary>
        /// <param name="value">The standard (double) value</param>
        /// <param name="unit">The associated unit</param>
        /// <param name="valueString">The string representation of the actual value type</param>
        /// <param name="valueType">The value type associated with this given string representation</param>
        public ExtendedQuantityValueContract(double value, TUnit unit, string valueString, TValueType valueType) : base(value, unit)
        {
            ValueString = valueString;
            ValueType = valueType;
        }

        /// <summary>
        /// The string representation of the actual value type.
        /// </summary>
        [DataMember(Order = 3)]
        public string ValueString { get; protected set; }

        /// <summary>
        /// The value type associated with this given string representation.
        /// </summary>
        [DataMember(Order = 4)]
        public TValueType ValueType { get; protected set; }
    }
}
