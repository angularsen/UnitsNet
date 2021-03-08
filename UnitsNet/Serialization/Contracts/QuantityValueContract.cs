using System.Runtime.Serialization;

namespace UnitsNet.Serialization.Contracts
{
    /// <summary>
    ///     Can be used to represent a quantity using a different type-representation (e.g. replacing the Enum type with it's
    ///     string representation)
    /// </summary>
    /// <typeparam name="TValue">The type used to represent the quantity value (e.g. double / decimal / string) </typeparam>
    /// <typeparam name="TUnit">The type used to represent the quantity unit (e.g. enum / int / string) </typeparam>
    [DataContract]
    public class QuantityValueContract<TValue, TUnit>
    {
        /// <summary>
        ///     Initializes a new quantity with the given unit and value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="unit">The associated unit</param>
        public QuantityValueContract(TValue value, TUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        /// <summary>
        ///     The value.
        /// </summary>
        [DataMember(Order = 1)]
        public TValue Value { get; protected set; }

        /// <summary>
        ///     The unit of the value.
        /// </summary>
        [DataMember(Order = 2)]
        public TUnit Unit { get; protected set;}
    }
}
