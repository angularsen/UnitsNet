// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics;
using UnitsNet.Units;

namespace UnitsNet;

/// <summary>
///     Information about the unit, such as its name and value.
///     This is useful to enumerate units and present names with quantities and units
///     chosen dynamically at runtime, such as unit conversion apps or allowing the user to change the
///     unit representation.
/// </summary>
/// <remarks>
///     Typically you obtain this by looking it up via <see cref="QuantityInfo.UnitInfos" />.
/// </remarks>
public abstract class UnitInfo : IUnitDefinition//, IUnitInfo
{
    // /// <summary>
    // ///     Initializes a new instance of the <see cref="UnitInfo" /> class with the specified unit details.
    // /// </summary>
    // /// <param name="name">The singular name of the unit. Cannot be <c>null</c>.</param>
    // /// <param name="pluralName">The plural name of the unit. Cannot be <c>null</c>.</param>
    // /// <param name="baseUnits">The base units associated with this unit. Cannot be <c>null</c>.</param>
    // /// <param name="conversionFromBase">
    // ///     The conversion expression to convert a value from the base unit to this unit.
    // /// </param>
    // /// <param name="conversionToBase">
    // ///     The conversion expression to convert a value from this unit to the base unit.
    // /// </param>
    // /// <exception cref="ArgumentNullException">
    // ///     Thrown when <paramref name="name" />, <paramref name="pluralName" />, or <paramref name="baseUnits" /> is
    // ///     <c>null</c>.
    // /// </exception>
    // protected UnitInfo(string name, string pluralName, BaseUnits baseUnits, ConversionExpression conversionFromBase, ConversionExpression conversionToBase)
    // {
    //     Name = name ?? throw new ArgumentNullException(nameof(name));
    //     PluralName = pluralName ?? throw new ArgumentNullException(nameof(pluralName));
    //     BaseUnits = baseUnits ?? throw new ArgumentNullException(nameof(baseUnits));
    //     ConversionFromBase = conversionFromBase;
    //     ConversionToBase = conversionToBase;
    // }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitInfo" /> class using the specified unit definition.
    /// </summary>
    /// <param name="mapping">
    ///     The unit definition containing details such as name, plural name, base units, and conversion
    ///     expressions.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="mapping" /> is <c>null</c>.</exception>
    protected internal UnitInfo(IUnitDefinition mapping)
    {
        if (mapping == null)
        {
            throw new ArgumentNullException(nameof(mapping));
        }

        Name = mapping.Name;
        PluralName = mapping.PluralName;
        BaseUnits = mapping.BaseUnits;
        ConversionFromBase = mapping.ConversionFromBase;
        ConversionToBase = mapping.ConversionToBase;
    }
    
    /// <inheritdoc />
    public override string ToString()
    {
        return Name;
    }
    
    #region Implementation of IUnitDefinition

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public string PluralName { get; }

    /// <inheritdoc />
    public BaseUnits BaseUnits { get; }

    /// <inheritdoc />
    public ConversionExpression ConversionFromBase { get; }

    /// <inheritdoc />
    public ConversionExpression ConversionToBase { get; }

    #endregion

    #region Implementation of IUnitInfo

    /// <summary>
    ///     The enum value of the unit, such as <see cref="LengthUnit.Centimeter" />.
    /// </summary>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public Enum Value
    {
        get => GetUnitValue();
    }

    /// <inheritdoc cref="Value" />
    protected abstract Enum GetUnitValue();
    
    /// <summary>
    ///     Get the parent quantity information.
    /// </summary>
    /// <remarks>
    ///     This property provides detailed information about the quantity to which this unit belongs,
    ///     including its name, unit values, and zero quantity. It is useful for enumerating units and
    ///     presenting names with quantities and units chosen dynamically at runtime.
    /// </remarks>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public QuantityInfo QuantityInfo
    {
        get => GetGenericInfo();
    }
    
    /// <inheritdoc cref="QuantityInfo" />
    protected internal abstract QuantityInfo GetGenericInfo();
    
    /// <summary>
    ///     Gets the unique key representing the unit type and its corresponding value.
    /// </summary>
    /// <remarks>
    ///     This key is particularly useful when using an enum-based unit in a hash-based collection,
    ///     as it avoids the boxing that would normally occur when casting the enum to <see cref="Enum" />.
    /// </remarks>
    public abstract UnitKey UnitKey { get; }
    
    /// <summary>
    ///     Name of the quantity this unit belongs to.
    /// </summary>
    [Obsolete("Please use the QuantityInfo.Name instead.")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string QuantityName
    {
        get => QuantityInfo.Name;
    }
    
    /// <summary>
    ///     Creates an instance of <see cref="IQuantity" /> from the specified <paramref name="value" />.
    /// </summary>
    /// <param name="value">The quantity value to convert.</param>
    /// <returns>An instance of <see cref="IQuantity" /> representing the specified <paramref name="value" />.</returns>
    /// <remarks>
    ///     This method utilizes the <see cref="QuantityInfo" /> associated with this unit to create the quantity.
    /// </remarks>
    public IQuantity From(QuantityValue value)
    {
        return CreateGenericQuantity(value);
    }

    /// <inheritdoc cref="From" />
    protected internal abstract IQuantity CreateGenericQuantity(QuantityValue value);

    #endregion
}

/// <inheritdoc cref="UnitInfo"/> />
/// <remarks>
///     Typically you obtain this by looking it up via <see cref="QuantityInfo{TUnit}.UnitInfos" />.
/// </remarks>
public abstract class UnitInfo<TUnit> : UnitInfo, IUnitDefinition<TUnit> //, IUnitInfo<TUnit>, IUnitDefinition<TUnit>
    where TUnit : struct, Enum
{
    // /// <summary>
    // ///     Initializes a new instance of the <see cref="UnitInfo{TUnit}" /> class.
    // /// </summary>
    // /// <param name="unit">The unit enumeration value represented by this instance.</param>
    // /// <param name="name">The singular name of the unit.</param>
    // /// <param name="pluralName">The plural name of the unit.</param>
    // /// <param name="baseUnits">The base units associated with this unit.</param>
    // /// <param name="conversionFromBase">
    // ///     The conversion expression to convert a value from the base unit to this unit.
    // /// </param>
    // /// <param name="conversionToBase">
    // ///     The conversion expression to convert a value from this unit to the base unit.
    // /// </param>
    // protected UnitInfo(TUnit unit, string name, string pluralName, BaseUnits baseUnits, ConversionExpression conversionFromBase, ConversionExpression conversionToBase)
    //     : base(name, pluralName, baseUnits, conversionFromBase, conversionToBase)
    // {
    //     Value = unit;
    // }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitInfo{TUnit}" /> class using the specified unit definition.
    /// </summary>
    /// <param name="mapping">
    ///     The unit definition containing details such as the unit value, name, plural name, base units, and conversion
    ///     expressions.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="mapping" /> is <c>null</c>.</exception>
    protected UnitInfo(IUnitDefinition<TUnit> mapping)
        : base(mapping)
    {
        Value = mapping.Value;
    }


    #region Implementation of IUnitInfo<TUnit>

    /// <inheritdoc  />
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    public new TUnit Value { get; }

    // /// <inheritdoc cref="UnitInfo.QuantityInfo" />
    // [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    // public new QuantityInfo<TUnit> QuantityInfo
    // {
    //     get => GetQuantityInfo();
    // }
    //
    // /// <inheritdoc cref="QuantityInfo" />
    // protected internal abstract QuantityInfo<TUnit> GetQuantityInfo();
    
    // /// <inheritdoc cref="UnitInfo.From" />
    // public new IQuantity<TUnit> From(QuantityValue value)
    // {
    //     return QuantityInfo.From(value, Value);
    // }

    #endregion
}

/// <summary>
///     Represents information about a specific unit of measurement for a given quantity type.
/// </summary>
/// <typeparam name="TQuantityInfo">The type of the quantity information associated with this unit.</typeparam>
/// <typeparam name="TQuantity">The type of the quantity associated with this unit.</typeparam>
/// <typeparam name="TUnit">The enumeration type representing the unit.</typeparam>
[DebuggerDisplay("{Name} ({Value})")]
public abstract class UnitInfoBase<TQuantityInfo, TQuantity, TUnit> : UnitInfo<TUnit>
    where TQuantityInfo : QuantityInfo<TQuantity, TUnit>
    where TQuantity : IQuantity<TQuantity, TUnit>
    where TUnit : struct, Enum
{
    // /// <summary>
    // ///     Initializes a new instance of the <see cref="UnitInfoBase{TQuantityInfo,TQuantity,TUnit}" /> class.
    // /// </summary>
    // /// <param name="quantityInfo">The quantity information associated with this unit.</param>
    // /// <param name="unit">The unit of measurement.</param>
    // /// <param name="singularName">The singular name of the unit.</param>
    // /// <param name="pluralName">The plural name of the unit.</param>
    // /// <param name="baseUnits">The base units associated with this unit.</param>
    // /// <param name="conversionFromBase">The conversion expression from the base unit to this unit.</param>
    // /// <param name="conversionToBase">The conversion expression from this unit to the base unit.</param>
    // protected UnitInfoBase(TQuantityInfo quantityInfo, TUnit unit, string singularName, string pluralName, BaseUnits baseUnits,
    //     ConversionExpression conversionFromBase,
    //     ConversionExpression conversionToBase)
    //     : base(unit, singularName, pluralName, baseUnits, conversionFromBase, conversionToBase)
    // {
    //     QuantityInfo = quantityInfo;
    // }

    // /// <summary>
    // ///     Initializes a new instance of the <see cref="UnitInfoBase{TQuantityInfo,TQuantity,TUnit}" /> class.
    // /// </summary>
    // /// <param name="quantityInfo">The quantity information associated with this unit.</param>
    // /// <param name="unit"></param>
    // /// <param name="pluralName">The plural name of the unit.</param>
    // /// <param name="baseUnits">The base units associated with this unit.</param>
    // /// <param name="conversionFromBase">The conversion expression from the base unit to this unit.</param>
    // /// <param name="conversionToBase">The conversion expression from this unit to the base unit.</param>
    // protected UnitInfoBase(TQuantityInfo quantityInfo, TUnit unit, string pluralName, BaseUnits baseUnits,
    //     ConversionExpression conversionFromBase,
    //     ConversionExpression conversionToBase)
    //     : this(quantityInfo, unit, unit.ToString(), pluralName, baseUnits, conversionFromBase, conversionToBase)
    // {
    // }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitInfoBase{TQuantityInfo, TQuantity, TUnit}" /> class
    ///     using the specified quantity information and unit mapping configuration.
    /// </summary>
    /// <param name="quantityInfo">The quantity information associated with this unit.</param>
    /// <param name="mapping">The unit mapping configuration containing unit details.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="mapping" /> is null.</exception>
    protected UnitInfoBase(TQuantityInfo quantityInfo, IUnitDefinition<TUnit> mapping)
        : base(mapping)
    {
        QuantityInfo = quantityInfo;
    }

    /// <inheritdoc cref="UnitInfo.QuantityInfo" />
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    public new TQuantityInfo QuantityInfo { get; }

    /// <inheritdoc />
    public override UnitKey UnitKey
    {
        get => UnitKey.ForUnit(Value);
    }

    /// <summary>
    ///     Converts a given <see cref="QuantityValue" /> to an instance of the quantity type associated with this unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>An instance of the quantity type associated with this unit.</returns>
    public new abstract TQuantity From(QuantityValue value);

    #region Overrides of UnitInfo

    // /// <inheritdoc />
    // protected internal sealed override QuantityInfo<TUnit> GetQuantityInfo()
    // {
    //     return QuantityInfo;
    // }

    /// <inheritdoc />
    protected internal sealed override IQuantity CreateGenericQuantity(QuantityValue value)
    {
        return From(value);
    }

    /// <inheritdoc />
    protected internal sealed override QuantityInfo GetGenericInfo()
    {
        return QuantityInfo;
    }

    /// <inheritdoc />
    protected override Enum GetUnitValue()
    {
        return Value;
    }

    #endregion
}

/// <inheritdoc cref="UnitInfoBase{TQuantityInfo,TQuantity,TUnit}" />
public sealed class UnitInfo<TQuantity, TUnit> : UnitInfoBase<QuantityInfo<TQuantity, TUnit>, TQuantity, TUnit> //, IUnitInfo<TQuantity, TUnit>
    where TQuantity : IQuantity<TQuantity, TUnit>
    where TUnit : struct, Enum
{
    // /// <inheritdoc />
    // public UnitInfo(QuantityInfo<TQuantity, TUnit> quantityInfo, TUnit value, string pluralName, BaseUnits baseUnits,
    //     ConversionExpression conversionFromBase,
    //     ConversionExpression conversionToBase)
    //     : base(quantityInfo, value, pluralName, baseUnits, conversionFromBase, conversionToBase)
    // {
    // }
    //
    // /// <inheritdoc />
    // public UnitInfo(QuantityInfo<TQuantity, TUnit> quantityInfo, TUnit value, string singularName, string pluralName, BaseUnits baseUnits,
    //     ConversionExpression conversionFromBase,
    //     ConversionExpression conversionToBase)
    //     : base(quantityInfo, value, singularName, pluralName, baseUnits, conversionFromBase, conversionToBase)
    // {
    // }

    /// <inheritdoc />
    internal UnitInfo(QuantityInfo<TQuantity, TUnit> quantityInfo, IUnitDefinition<TUnit> unitDefinition)
        : base(quantityInfo, unitDefinition)
    {
    }

    /// <inheritdoc cref="UnitInfoBase{TQuantityInfo,TQuantity,TUnit}.From" />
    public override TQuantity From(QuantityValue value)
    {
        return QuantityInfo.From(value, Value);
    }
}
