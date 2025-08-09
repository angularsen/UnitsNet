// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;

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
public abstract class UnitInfo : IUnitDefinition
{
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
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Name;
    }

    /// <summary>
    ///     Filters a collection of unit information based on the specified base units.
    /// </summary>
    /// <typeparam name="TUnitInfo">The type of the unit information.</typeparam>
    /// <param name="unitInfos">The collection of unit information to filter.</param>
    /// <param name="baseUnits">The base units to filter by.</param>
    /// <returns>An <see cref="IEnumerable{T}" /> containing the unit information that matches the specified base units.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="baseUnits" /> is null.</exception>
    internal static IEnumerable<TUnitInfo> GetUnitsWithBase<TUnitInfo>(IEnumerable<TUnitInfo> unitInfos, BaseUnits baseUnits)
        where TUnitInfo : UnitInfo
    {
        if (baseUnits is null)
        {
            throw new ArgumentNullException(nameof(baseUnits));
        }

        return unitInfos.Where(unitInfo => unitInfo.BaseUnits.IsSubsetOf(baseUnits));
    }

    /// <summary>
    ///     Gets the <see cref="UnitInfo" /> whose <see cref="UnitsNet.BaseUnits" /> is a subset of
    ///     <paramref name="baseUnits" />.
    /// </summary>
    /// <example>
    ///     Length.Info.GetUnitInfoFor(unitSystemWithFootAsLengthUnit) returns <see cref="UnitInfo" /> for
    ///     <see cref="LengthUnit.Foot" />.
    /// </example>
    /// <param name="unitInfos">The collection of unit information to filter.</param>
    /// <param name="baseUnits">The <see cref="UnitsNet.BaseUnits" /> to check against.</param>
    /// <returns>
    ///     The <see cref="UnitInfo" /> that has <see cref="UnitsNet.BaseUnits" /> that is a subset of
    ///     <paramref name="baseUnits" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="baseUnits" /> is null.</exception>
    /// <exception cref="InvalidOperationException">No unit was found that is a subset of <paramref name="baseUnits" />.</exception>
    /// <exception cref="InvalidOperationException">
    ///     More than one unit was found that is a subset of
    ///     <paramref name="baseUnits" />.
    /// </exception>
    internal static TUnitInfo GetUnitWithBase<TUnitInfo>(IEnumerable<TUnitInfo> unitInfos, BaseUnits baseUnits)
        where TUnitInfo : UnitInfo
    {
        using IEnumerator<TUnitInfo> enumerator = GetUnitsWithBase(unitInfos, baseUnits).GetEnumerator();

        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException($"No unit was found that is a subset of {nameof(baseUnits)}");
        }

        TUnitInfo firstUnitInfo = enumerator.Current!;
        if (enumerator.MoveNext())
        {
            throw new InvalidOperationException($"More than one unit was found that is a subset of {nameof(baseUnits)}");
        }

        return firstUnitInfo;
    }

    #region Implementation of IUnitDefinition

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public string PluralName { get; }

    /// <inheritdoc />
    public BaseUnits BaseUnits { get; }

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
    public IQuantity From(double value)
    {
        return CreateGenericQuantity(value);
    }

    /// <inheritdoc cref="From" />
    protected internal abstract IQuantity CreateGenericQuantity(double value);

    #endregion
}

/// <inheritdoc cref="UnitInfo" />
/// <remarks>
///     Typically you obtain this by looking it up via <see cref="QuantityInfo{TUnit}.UnitInfos" />.
/// </remarks>
public abstract class UnitInfo<TUnit> : UnitInfo, IUnitDefinition<TUnit>
    where TUnit : struct, Enum
{
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

    /// <inheritdoc />
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    public new TUnit Value { get; }
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
    ///     Converts a given <see cref="double" /> to an instance of the quantity type associated with this unit.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>An instance of the quantity type associated with this unit.</returns>
    public new abstract TQuantity From(double value);

    #region Overrides of UnitInfo

    /// <inheritdoc />
    protected internal sealed override IQuantity CreateGenericQuantity(double value)
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
public sealed class UnitInfo<TQuantity, TUnit> : UnitInfoBase<QuantityInfo<TQuantity, TUnit>, TQuantity, TUnit>
    where TQuantity : IQuantity<TQuantity, TUnit>
    where TUnit : struct, Enum
{
    /// <inheritdoc />
    internal UnitInfo(QuantityInfo<TQuantity, TUnit> quantityInfo, IUnitDefinition<TUnit> unitDefinition)
        : base(quantityInfo, unitDefinition)
    {
    }

    /// <inheritdoc cref="UnitInfoBase{TQuantityInfo,TQuantity,TUnit}.From" />
    public override TQuantity From(double value)
    {
        return QuantityInfo.From(value, Value);
    }
}
