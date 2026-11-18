// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics;

namespace UnitsNet;

/// <summary>
///     A unit of <typeparamref name="TQuantity" />, described by its names and conversions, such as a furlong of
///     <see cref="Length" />.
/// </summary>
/// <remarks>
///     Quantities can be converted to and from the unit with
///     <see cref="QuantityExtensions.As{TQuantity}(TQuantity, UnitOf{TQuantity})" /> and
///     <see cref="QuantityInfoBase{TQuantity, TUnit, TUnitInfo}.From(QuantityValue, UnitOf{TQuantity})" />.
///     Since the unit is tied to its quantity, using it with another quantity doesn't compile.
/// </remarks>
/// <typeparam name="TQuantity">The quantity this is a unit of, such as <see cref="Length" />.</typeparam>
[DebuggerDisplay("{Name}")]
public sealed class UnitOf<TQuantity> : IUnitDefinition
    where TQuantity : IQuantity
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOf{TQuantity}" /> class.
    /// </summary>
    /// <param name="singularName">The singular name of the unit, such as "Furlong".</param>
    /// <param name="pluralName">The plural name of the unit, such as "Furlongs".</param>
    /// <param name="valueInBaseUnit">
    ///     The value of one of this unit in the base unit of the quantity, such as 201.168 for a furlong, which is 201.168
    ///     meters.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="singularName" /> or <paramref name="pluralName" /> is <c>null</c>.
    /// </exception>
    public UnitOf(string singularName, string pluralName, QuantityValue valueInBaseUnit)
        : this(singularName, pluralName, BaseUnits.Undefined, valueInBaseUnit)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOf{TQuantity}" /> class for a unit made of the base units of
    ///     UnitsNet, such as feet per day of <see cref="Speed" />.
    /// </summary>
    /// <param name="singularName">The singular name of the unit, such as "FootPerDay".</param>
    /// <param name="pluralName">The plural name of the unit, such as "FeetPerDay".</param>
    /// <param name="baseUnits">The base units the unit is made of, such as feet and days.</param>
    /// <param name="valueInBaseUnit">The value of one of this unit in the base unit of the quantity.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="singularName" />, <paramref name="pluralName" />, or <paramref name="baseUnits" /> is
    ///     <c>null</c>.
    /// </exception>
    public UnitOf(string singularName, string pluralName, BaseUnits baseUnits, QuantityValue valueInBaseUnit)
        : this(singularName, pluralName, baseUnits, QuantityValue.Inverse(valueInBaseUnit), valueInBaseUnit)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOf{TQuantity}" /> class.
    /// </summary>
    /// <param name="singularName">The singular name of the unit, such as "Furlong".</param>
    /// <param name="pluralName">The plural name of the unit, such as "Furlongs".</param>
    /// <param name="conversionFromBase">The conversion expression from the base unit of the quantity to this unit.</param>
    /// <param name="conversionToBase">The conversion expression from this unit to the base unit of the quantity.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="singularName" /> or <paramref name="pluralName" /> is <c>null</c>.
    /// </exception>
    public UnitOf(string singularName, string pluralName, ConversionExpression conversionFromBase, ConversionExpression conversionToBase)
        : this(singularName, pluralName, BaseUnits.Undefined, conversionFromBase, conversionToBase)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOf{TQuantity}" /> class for a unit made of the base units of
    ///     UnitsNet.
    /// </summary>
    /// <param name="singularName">The singular name of the unit.</param>
    /// <param name="pluralName">The plural name of the unit.</param>
    /// <param name="baseUnits">The base units the unit is made of.</param>
    /// <param name="conversionFromBase">The conversion expression from the base unit of the quantity to this unit.</param>
    /// <param name="conversionToBase">The conversion expression from this unit to the base unit of the quantity.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="singularName" />, <paramref name="pluralName" />, or <paramref name="baseUnits" /> is
    ///     <c>null</c>.
    /// </exception>
    public UnitOf(string singularName, string pluralName, BaseUnits baseUnits,
        ConversionExpression conversionFromBase, ConversionExpression conversionToBase)
    {
        Name = singularName ?? throw new ArgumentNullException(nameof(singularName));
        PluralName = pluralName ?? throw new ArgumentNullException(nameof(pluralName));
        BaseUnits = baseUnits ?? throw new ArgumentNullException(nameof(baseUnits));
        ConversionFromBase = conversionFromBase;
        ConversionToBase = conversionToBase;
    }

    /// <summary>
    ///     The singular name of the unit, such as "Furlong".
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     The plural name of the unit, such as "Furlongs".
    /// </summary>
    public string PluralName { get; }

    /// <inheritdoc />
    public ConversionExpression ConversionFromBase { get; }

    /// <inheritdoc />
    public ConversionExpression ConversionToBase { get; }

    /// <summary>
    ///     The base units the unit is made of, or <see cref="UnitsNet.BaseUnits.Undefined" /> if it isn't made of the base
    ///     units of UnitsNet, such as a furlong.
    /// </summary>
    public BaseUnits BaseUnits { get; }

    /// <summary>
    ///     Returns the name of the unit.
    /// </summary>
    public override string ToString()
    {
        return Name;
    }
}
