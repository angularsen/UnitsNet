using System;
using System.Numerics;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity backed by a particular value type, such as <see cref="double"/> or <see cref="decimal"/>.
    /// </summary>
    /// <remarks>
    ///     Currently, only 3 quantities are backed by <see cref="decimal"/>: <see cref="Power"/>, <see cref="BitRate"/> and <see cref="Information"/>.
    ///     <br/><br/>
    ///     The future of decimal support is uncertain. We may either change everything to double to simplify, or use generics or <see cref="QuantityValue"/>
    ///     more broadly to better support any value type.
    ///     <br/><br/>
    ///     The <see cref="Power"/> quantity originally introduced decimal due to precision issues with large units and due to the implementation at that
    ///     time storing the value in the base unit. This is no longer as big of a problem after changing to unit-value representation, since you typically
    ///     convert to similar sized units. There is also the option of specifying conversion functions directly between any 2 units to further improve precision.
    ///     <br/><br/>
    ///     <see cref="BitRate"/>/<see cref="Information"/>, however, do map more naturally to decimal, since its smallest unit <see cref="InformationUnit.Bit"/> is an integer value,
    ///     similar to 100ns ticks as the smallest unit in <see cref="DateTime"/> and <see cref="TimeSpan"/>.
    /// </remarks>
    /// <typeparam name="TValueType">The value type of the quantity.</typeparam>
    public interface IValueQuantity<out TValueType> : IQuantity
#if NET7_0_OR_GREATER
        where TValueType : INumber<TValueType>
#else
        where TValueType : struct
#endif
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

        /// <summary>
        ///     Converts this <see cref="IValueQuantity{TValueType}"/> to an <see cref="IValueQuantity{TValueType}"/> in the given <paramref name="unit"/>.
        /// </summary>
        /// <param name="unit">
        ///     The unit <see cref="Enum"/> value. The <see cref="Enum"/> must be compatible with the units of the <see cref="IValueQuantity{TValueType}"/>.
        ///     For example, if the <see cref="IValueQuantity{TValueType}"/> is a <see cref="Length"/>, you should provide a <see cref="LengthUnit"/> value.
        /// </param>
        /// <exception cref="NotImplementedException">Conversion was not possible from this <see cref="IValueQuantity{TValueType}"/> to <paramref name="unit"/>.</exception>
        /// <returns>A new <see cref="IValueQuantity{TValueType}"/> in the given <paramref name="unit"/>.</returns>
        new IValueQuantity<TValueType> ToUnit(Enum unit);

        /// <summary>
        ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
        ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
        /// <returns>A new <see cref="IValueQuantity{TValueType}"/> with the determined unit.</returns>
        new IValueQuantity<TValueType> ToUnit(UnitSystem unitSystem);
    }
}
