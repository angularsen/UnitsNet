// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics;
using UnitsNet.Units;

namespace UnitsNet;

/// <inheritdoc />
[DebuggerDisplay("{Name} ({Value})")]
public sealed class UnitDefinition<TUnit> : IUnitDefinition<TUnit>
    where TUnit : struct, Enum
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitDefinition{TUnit}" /> class for the base unit.
    /// </summary>
    /// <param name="value">The enum value for this unit, for example <see cref="LengthUnit.Meter" />.</param>
    /// <param name="pluralName">The plural name of the unit, such as "Centimeters".</param>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> for this unit.</param>
    public UnitDefinition(TUnit value, string pluralName, BaseUnits baseUnits)
        : this(value, value.ToString(), pluralName, baseUnits)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitDefinition{TUnit}" /> class.
    /// </summary>
    /// <param name="value">The enum value for this unit, for example <see cref="LengthUnit.Meter" />.</param>
    /// <param name="pluralName">The plural name of the unit, such as "Centimeters".</param>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> for this unit.</param>
    /// <param name="conversionFromBase">The conversion expression from the base unit to this unit.</param>
    /// <param name="conversionToBase">The conversion expression from this unit to the base unit.</param>
    public UnitDefinition(TUnit value, string pluralName, BaseUnits baseUnits,
        ConversionExpression conversionFromBase,
        ConversionExpression conversionToBase)
        : this(value, value.ToString(), pluralName, baseUnits, conversionFromBase, conversionToBase)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitDefinition{TUnit}" /> class.
    /// </summary>
    /// <param name="value">The enum value for this unit, for example <see cref="LengthUnit.Meter" />.</param>
    /// <param name="pluralName">The plural name of the unit, such as "Centimeters".</param>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> for this unit.</param>
    /// <param name="conversionFromBase">The conversion coefficient from the base unit to this unit.</param>
    public UnitDefinition(TUnit value, string pluralName, BaseUnits baseUnits, QuantityValue conversionFromBase)
        : this(value, value.ToString(), pluralName, baseUnits, conversionFromBase)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitDefinition{TUnit}" /> class for the base unit.
    /// </summary>
    /// <param name="value">The enum value representing the unit, for example <see cref="LengthUnit.Meter" />.</param>
    /// <param name="singularName">The singular name of the unit, such as "Centimeter".</param>
    /// <param name="pluralName">The plural name of the unit, such as "Centimeters".</param>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> associated with this unit.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="value" />, <paramref name="singularName" />, <paramref name="pluralName" />, or
    ///     <paramref name="baseUnits" /> is <c>null</c>.
    /// </exception>
    public UnitDefinition(TUnit value, string singularName, string pluralName, BaseUnits baseUnits)
        : this(value, singularName, pluralName, baseUnits, QuantityValue.One, QuantityValue.One)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitDefinition{TUnit}" /> class.
    /// </summary>
    /// <param name="value">The enum value representing the unit, for example <see cref="LengthUnit.Meter" />.</param>
    /// <param name="singularName">The singular name of the unit, such as "Centimeter".</param>
    /// <param name="pluralName">The plural name of the unit, such as "Centimeters".</param>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> associated with this unit.</param>
    /// <param name="conversionFromBase">The conversion coefficient from the base unit to this unit.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="value" />, <paramref name="singularName" />, <paramref name="pluralName" />, or
    ///     <paramref name="baseUnits" /> is <c>null</c>.
    /// </exception>
    public UnitDefinition(TUnit value, string singularName, string pluralName, BaseUnits baseUnits, QuantityValue conversionFromBase)
        : this(value, singularName, pluralName, baseUnits, conversionFromBase, QuantityValue.Inverse(conversionFromBase))
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitDefinition{TUnit}" /> class.
    /// </summary>
    /// <param name="value">The enum value representing the unit, for example <see cref="LengthUnit.Meter" />.</param>
    /// <param name="singularName">The singular name of the unit, such as "Centimeter".</param>
    /// <param name="pluralName">The plural name of the unit, such as "Centimeters".</param>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> associated with this unit.</param>
    /// <param name="conversionFromBase">The conversion expression from the base unit to this unit.</param>
    /// <param name="conversionToBase">The conversion expression from this unit to the base unit.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="value" />, <paramref name="singularName" />, <paramref name="pluralName" />, or
    ///     <paramref name="baseUnits" /> is <c>null</c>.
    /// </exception>
    public UnitDefinition(TUnit value, string singularName, string pluralName, BaseUnits baseUnits,
        ConversionExpression conversionFromBase,
        ConversionExpression conversionToBase)
    {
        Value = value;
        Name = singularName ?? throw new ArgumentNullException(nameof(singularName));
        PluralName = pluralName ?? throw new ArgumentNullException(nameof(pluralName));
        BaseUnits = baseUnits ?? throw new ArgumentNullException(nameof(baseUnits));
        ConversionFromBase = conversionFromBase;
        ConversionToBase = conversionToBase;
    }

    /// <summary>
    ///     The enum value of the unit, such as <see cref="LengthUnit.Centimeter" />.
    /// </summary>
    public TUnit Value { get; }

    /// <summary>
    ///     The singular name of the unit, such as "Centimeter".
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     The plural name of the unit, such as "Centimeters".
    /// </summary>
    public string PluralName { get; }

    /// <summary>
    ///     Gets the <see cref="BaseUnits" /> for this unit.
    /// </summary>
    public BaseUnits BaseUnits { get; }

    /// <inheritdoc />
    public ConversionExpression ConversionFromBase { get; }

    /// <inheritdoc />
    public ConversionExpression ConversionToBase { get; }
}
