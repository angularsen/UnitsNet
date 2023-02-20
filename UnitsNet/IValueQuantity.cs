using System;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity backed by a particular value type.
    /// </summary>
    /// <typeparam name="TValueType">The value type of the quantity.</typeparam>
    public interface IValueQuantity<TValueType> : IQuantity
        where TValueType : struct
    {
        /// <summary>
        ///     The value this quantity was constructed with. See also <see cref="IQuantity.Unit"/>.
        /// </summary>
        new TValueType Value { get; }

        /// <summary>
        ///     Gets the value in the given unit.
        /// </summary>
        /// <param name="unit">The unit enum value. The unit must be compatible, so for <see cref="Length"/> you should provide a <see cref="LengthUnit"/> value.</param>
        /// <returns>Value converted to the specified unit.</returns>
        /// <exception cref="InvalidCastException">Wrong unit enum type was given.</exception>
        new TValueType As(Enum unit);

        /// <summary>
        ///     Gets the value in the unit determined by the given <see cref="UnitSystem"/>. If multiple units were found for the given <see cref="UnitSystem"/>,
        ///     the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity value to.</param>
        /// <returns>The converted value.</returns>
        new TValueType As(UnitSystem unitSystem);
    }
}
