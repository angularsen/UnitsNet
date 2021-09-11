// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Runtime.Serialization;

namespace UnitsNet.Serialization.Contracts
{
    /// <summary>
    ///     Can be used to represent a quantity, with it's unit defined using a common abbreviation (e.g. 'kg')
    ///     <remarks>
    ///         <para>
    ///             Given the ambiguous nature of the unit-abbreviation mapping, an addition identifier, associated with the
    ///             quantity type, is required
    ///         </para>
    ///     </remarks>
    /// </summary>
    /// <typeparam name="TQuantity">The quantity type identifier (e.g. int / string) </typeparam>
    /// <typeparam name="TValue">The type of value associated with this quantity (e.g. double / decimal) </typeparam>
    [DataContract]
    public class QuantityWithAbbreviationContract<TValue, TQuantity> : QuantityValueContract<TValue, string>
    {
        /// <summary>
        ///     Construct a quantity with abbreviation such as {42, "Mass", "kg"}
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="quantityType">>The quantity type identifier (e.g. int / string)</param>
        /// <param name="unitAbbreviation">The associated unit abbreviation (e.g. 'kg') </param>
        public QuantityWithAbbreviationContract(TValue value, TQuantity quantityType, string unitAbbreviation) : base(value, unitAbbreviation)
        {
            QuantityType = quantityType;
        }

        /// <summary>
        ///     The quantity type identifier.
        /// </summary>
        [DataMember(Order = 3)]
        public TQuantity QuantityType { get; protected set; }
    }
}
