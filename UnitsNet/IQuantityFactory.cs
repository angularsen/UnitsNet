using System;

namespace UnitsNet
{
    /// <summary>
    /// Creates an IQuantity instance
    /// </summary>
    public interface IQuantityFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantityInfo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IQuantity FromQuantityInfo(QuantityInfo quantityInfo, QuantityValue value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        bool TryFrom(QuantityValue value, Enum unit, out IQuantity? quantity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatProvider"></param>
        /// <param name="quantityType"></param>
        /// <param name="quantityString"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        bool TryParse(IFormatProvider? formatProvider, Type quantityType, string quantityString, out IQuantity? quantity);
    }
}
