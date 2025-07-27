// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET7_0_OR_GREATER
using System.Numerics;

#endif

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity.
    /// </summary>
    public interface IQuantity : IFormattable
    {
        /// <summary>
        ///     The <see cref="BaseDimensions" /> of this quantity.
        /// </summary>
        BaseDimensions Dimensions { get; }

        /// <summary>
        ///     Information about the quantity type, such as unit values and names.
        /// </summary>
        QuantityInfo QuantityInfo { get; }

        /// <summary>
        ///     Gets the value in the given unit.
        /// </summary>
        /// <param name="unit">The unit enum value. The unit must be compatible, so for <see cref="Length"/> you should provide a <see cref="LengthUnit"/> value.</param>
        /// <returns>Value converted to the specified unit.</returns>
        /// <exception cref="InvalidCastException">Wrong unit enum type was given.</exception>
        double As(Enum unit);

        /// <summary>
        ///     Gets the value in the given unit key.
        /// </summary>
        /// <param name="unitKey">The unit key. The unit type must be compatible, so for <see cref="Length"/> you should provide a <see cref="LengthUnit"/> value.</param>
        /// <returns>Value converted to the specified unit.</returns>
        /// <exception cref="InvalidCastException">Wrong unit enum type was given.</exception>
        double As(UnitKey unitKey);

        /// <summary>
        ///     Gets the value in the unit determined by the given <see cref="UnitSystem"/>. If multiple units were found for the given <see cref="UnitSystem"/>,
        ///     the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity value to.</param>
        /// <returns>The converted value.</returns>
        double As(UnitSystem unitSystem);

        /// <summary>
        ///     The unit this quantity was constructed with -or- BaseUnit if default ctor was used.
        /// </summary>
        Enum Unit { get; }

        /// <summary>
        ///     The value this quantity was constructed with. See also <see cref="Unit"/>.
        /// </summary>
        double Value { get; }

        /// <summary>
        ///     Converts this <see cref="IQuantity"/> to an <see cref="IQuantity"/> in the given <paramref name="unit"/>.
        /// </summary>
        /// <param name="unit">
        ///     The unit <see cref="Enum"/> value. The <see cref="Enum"/> must be compatible with the units of the <see cref="IQuantity"/>.
        ///     For example, if the <see cref="IQuantity"/> is a <see cref="Length"/>, you should provide a <see cref="LengthUnit"/> value.
        /// </param>
        /// <exception cref="NotImplementedException">Conversion was not possible from this <see cref="IQuantity"/> to <paramref name="unit"/>.</exception>
        /// <returns>A new <see cref="IQuantity"/> in the given <paramref name="unit"/>.</returns>
        IQuantity ToUnit(Enum unit);

        /// <summary>
        ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>.
        ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
        /// </summary>
        /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
        /// <returns>A new quantity with the determined unit.</returns>
        IQuantity ToUnit(UnitSystem unitSystem);

        /// <summary>
        ///     Gets the unique key for the unit type and its corresponding value.
        /// </summary>
        /// <remarks>
        ///     This property is particularly useful when using an enum-based unit in a hash-based collection,
        ///     as it avoids the boxing that would normally occur when casting the enum to <see cref="Enum" />.
        /// </remarks>
        UnitKey UnitKey { get; }
    }

    /// <summary>
    ///     A stronger typed interface where the unit enum type is known, to avoid passing in the
    ///     wrong unit enum type and not having to cast from <see cref="Enum"/>.
    /// </summary>
    /// <example>
    ///     IQuantity{LengthUnit} length;
    ///     double centimeters = length.As(LengthUnit.Centimeter); // Type safety on enum type
    /// </example>
    /// <typeparam name="TUnitType">The unit type of the quantity.</typeparam>
    public interface IQuantity<TUnitType> : IQuantity
        where TUnitType : struct, Enum
    {
        /// <summary>
        ///     Convert to a unit representation <typeparamref name="TUnitType"/>.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        double As(TUnitType unit);

        /// <inheritdoc cref="IQuantity.Unit"/>
        new TUnitType Unit { get; }

        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        new QuantityInfo<TUnitType> QuantityInfo { get; }

        /// <summary>
        ///     Converts this <see cref="IQuantity{TUnitType}"/> to an <see cref="IQuantity{TUnitType}"/> in the given <paramref name="unit"/>.
        /// </summary>
        /// <param name="unit">The unit value.</param>
        /// <exception cref="NotImplementedException">Conversion was not possible from this <see cref="IQuantity"/> to <paramref name="unit"/>.</exception>
        /// <returns>A new <see cref="IQuantity{TUnitType}"/> in the given <paramref name="unit"/>.</returns>
        IQuantity<TUnitType> ToUnit(TUnitType unit);
        
        /// <inheritdoc cref="IQuantity.ToUnit(UnitSystem)"/>
        new IQuantity<TUnitType> ToUnit(UnitSystem unitSystem);

#if NET

        #region Implementation of IQuantity

        QuantityInfo IQuantity.QuantityInfo
        {
            get => QuantityInfo;
        }

        Enum IQuantity.Unit
        {
            get => Unit;
        }

        #endregion

#endif
    }

    /// <inheritdoc cref="IQuantity" />
    /// <remarks>
    ///     This is a specialization of <see cref="IQuantity" /> that is used (internally) for constraining certain
    ///     methods, without having to include the unit type as additional generic parameter.
    /// </remarks>
    /// <typeparam name="TQuantity"></typeparam>
    public interface IQuantityInstance<out TQuantity> : IQuantity
        where TQuantity : IQuantity
    {
#if NET
        internal static abstract TQuantity Create(double value, UnitKey unit);
#else
        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        new IQuantityInstanceInfo<TQuantity> QuantityInfo { get; }
#endif
    }

    /// <summary>
    ///     An <see cref="IQuantity{TUnitType}"/> that supports generic equality comparison with tolerance.
    /// </summary>
    /// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
    /// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
    public interface IQuantity<TSelf, TUnitType> : IQuantityInstance<TSelf>, IQuantity<TUnitType>
        where TSelf : IQuantity<TSelf, TUnitType>
        where TUnitType : struct, Enum
    {
        /// <inheritdoc cref="IQuantity.QuantityInfo"/>
        new QuantityInfo<TSelf, TUnitType> QuantityInfo { get; }

#if NET
        /// <summary>
        ///     Creates an instance of the quantity from a specified value and unit.
        /// </summary>
        /// <param name="value">The numerical value of the quantity.</param>
        /// <param name="unit">The unit of the quantity.</param>
        /// <returns>An instance of the quantity with the specified value and unit.</returns>
        static abstract TSelf From(double value, TUnitType unit);

        static TSelf IQuantityInstance<TSelf>.Create(double value, UnitKey unit) => TSelf.From(value, unit.ToUnit<TUnitType>());

        IQuantity<TUnitType> IQuantity<TUnitType>.ToUnit(TUnitType unit)
        {
            return TSelf.From(As(unit), unit);
        }

        IQuantity<TUnitType> IQuantity<TUnitType>.ToUnit(UnitSystem unitSystem)
        {
            TUnitType unit = QuantityInfo.GetDefaultUnit(unitSystem);
            return ToUnit(unit);
        }

#endif

    }

    /// <summary>
    ///     An <see cref="IQuantity{TSelf}"/> that (in .NET 7+) implements generic math interfaces for arithmetic operations.
    /// </summary>
    /// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
    /// <typeparam name="TOffset"></typeparam>
    public interface IAffineQuantity<TSelf, TOffset> : IQuantityInstance<TSelf>
    #if NET7_0_OR_GREATER
        , IAdditiveIdentity<TSelf, TOffset>
        where TOffset : IAdditiveIdentity<TOffset, TOffset>
    #endif
        where TSelf : IAffineQuantity<TSelf, TOffset>
    {
    #if NET7_0_OR_GREATER
        /// <summary>
        ///     The zero value of this quantity.
        /// </summary>
        static abstract TSelf Zero { get; }

        static TOffset IAdditiveIdentity<TSelf, TOffset>.AdditiveIdentity => TOffset.AdditiveIdentity;
    #endif
    }

    /// <summary>
    ///     An <see cref="IQuantity{TSelf, TUnitType}"/> that (in .NET 7+) implements generic math interfaces for arithmetic operations.
    /// </summary>
    /// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
    /// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
    /// <typeparam name="TOffset"></typeparam>
    public interface IAffineQuantity<TSelf, TUnitType, TOffset> : IQuantity<TSelf, TUnitType>, IAffineQuantity<TSelf, TOffset>
    #if NET7_0_OR_GREATER
        , IAdditionOperators<TSelf, TOffset, TSelf>
        , ISubtractionOperators<TSelf, TSelf, TOffset>
        where TOffset : IAdditiveIdentity<TOffset, TOffset>
    #endif
        where TSelf : IAffineQuantity<TSelf, TUnitType, TOffset>
        where TUnitType : struct, Enum
    {
    }


    /// <summary>
    ///     Represents a logarithmic quantity that supports arithmetic operations and implements generic math interfaces 
    ///     (in .NET 7+). This interface is designed for quantities that are logarithmic in nature, such as decibels.
    /// </summary>
    /// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
    /// <remarks>
    ///     Logarithmic quantities are different from linear quantities in that they represent values on a logarithmic scale.
    ///     This interface extends <see cref="IQuantity{TSelf, TUnitType}" /> and provides additional functionality specific 
    ///     to logarithmic quantities, including arithmetic operations and a logarithmic scaling factor.
    ///     The logarithmic scale assumed here is base-10.
    /// </remarks>
    public interface ILogarithmicQuantity<TSelf> : IQuantityInstance<TSelf>
    #if NET7_0_OR_GREATER
        , IMultiplicativeIdentity<TSelf, TSelf>
    #endif
        where TSelf : ILogarithmicQuantity<TSelf>
    {
    #if NET7_0_OR_GREATER
        /// <summary>
        ///     Gets the logarithmic scaling factor used to convert between linear and logarithmic units.
        ///     This factor is typically 10, but there are exceptions such as the PowerRatio, which uses 20.
        /// </summary>
        /// <value>
        ///     The logarithmic scaling factor.
        /// </value>
        static abstract double LogarithmicScalingFactor { get; }
        
        /// <summary>
        ///     The zero value of this quantity.
        /// </summary>
        static abstract TSelf Zero { get; }
        
        static TSelf IMultiplicativeIdentity<TSelf, TSelf>.MultiplicativeIdentity => TSelf.Zero;
    #else
        /// <summary>
        ///     Gets the logarithmic scaling factor used to convert between linear and logarithmic units.
        ///     This factor is typically 10, but there are exceptions such as the PowerRatio, which uses 20.
        /// </summary>
        /// <value>
        ///     The logarithmic scaling factor.
        /// </value>
        double LogarithmicScalingFactor { get; }
    #endif
    }

    /// <inheritdoc cref="ILogarithmicQuantity{TSelf}"/>
    /// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
    /// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
    public interface ILogarithmicQuantity<TSelf, TUnitType> : IQuantity<TSelf, TUnitType>, ILogarithmicQuantity<TSelf>
    #if NET7_0_OR_GREATER
        , IAdditionOperators<TSelf, TSelf, TSelf>
        , ISubtractionOperators<TSelf, TSelf, TSelf>
        , IMultiplyOperators<TSelf, double, TSelf>
        , IDivisionOperators<TSelf, double, TSelf>
        , IUnaryNegationOperators<TSelf, TSelf>
    #endif
        where TSelf : ILogarithmicQuantity<TSelf, TUnitType>
        where TUnitType : struct, Enum
    {
    }
}
