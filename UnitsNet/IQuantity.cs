// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

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
    ///     The unit this quantity was constructed with -or- BaseUnit if default ctor was used.
    /// </summary>
    Enum Unit { get; }

    /// <summary>
    ///     The value this quantity was constructed with. See also <see cref="Unit" />.
    /// </summary>
    QuantityValue Value { get; }

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
///     wrong unit enum type and not having to cast from <see cref="Enum" />.
/// </summary>
/// <example>
///     IQuantity{LengthUnit} length;
///     QuantityValue centimeters = length.As(LengthUnit.Centimeter); // Type safety on enum type
/// </example>
/// <typeparam name="TUnitType">The unit type of the quantity.</typeparam>
public interface IQuantity<TUnitType> : IQuantity
    where TUnitType : struct, Enum
{
    /// <inheritdoc cref="IQuantity.Unit" />
    new TUnitType Unit { get; }

    /// <inheritdoc cref="IQuantity.QuantityInfo" />
    new QuantityInfo<TUnitType> QuantityInfo { get; }
    
#if NET
    QuantityInfo IQuantity.QuantityInfo
    {
        get => QuantityInfo;
    }

    Enum IQuantity.Unit
    {
        get => Unit;
    }
#endif
}

/// <inheritdoc cref="IQuantity" />
/// <remarks>
///     This is a specialization of <see cref="IQuantity" /> that is used (internally) for constraining certain
///     methods, without having to include the unit type as additional generic parameter.
/// </remarks>
/// <typeparam name="TQuantity"></typeparam>
public interface IQuantityOfType<out TQuantity> : IQuantity
    where TQuantity : IQuantity
{
#if NET
    internal static abstract TQuantity Create(QuantityValue value, UnitKey unit);
#else
    /// <inheritdoc cref="IQuantity.QuantityInfo" />
    new IQuantityInstanceInfo<TQuantity> QuantityInfo { get; }
#endif
}

/// <summary>
///     An <see cref="IQuantity{TUnitType}" /> that supports generic equality comparison with tolerance.
/// </summary>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
public interface IQuantity<TSelf, TUnitType> : IQuantityOfType<TSelf>, IQuantity<TUnitType>
    where TSelf : IQuantity<TSelf, TUnitType>
    where TUnitType : struct, Enum
{
    /// <inheritdoc cref="IQuantity.QuantityInfo" />
    new QuantityInfo<TSelf, TUnitType> QuantityInfo { get; }

#if NET
    /// <summary>
    ///     Creates an instance of the quantity from a specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the quantity.</param>
    /// <param name="unit">The unit of the quantity.</param>
    /// <returns>An instance of the quantity with the specified value and unit.</returns>
    static abstract TSelf From(QuantityValue value, TUnitType unit);

    static TSelf IQuantityOfType<TSelf>.Create(QuantityValue value, UnitKey unit) => TSelf.From(value, unit.ToUnit<TUnitType>());

    QuantityInfo<TUnitType> IQuantity<TUnitType>.QuantityInfo
    {
        get => QuantityInfo;
    }
#endif
}
