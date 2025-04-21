// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;
using System.Resources;

namespace UnitsNet;

/// <inheritdoc cref="IQuantityInfo" />
[DebuggerDisplay("{Name} ({QuantityType.FullName})")]
public abstract class QuantityInfo : IQuantityInfo
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfo" /> class.
    /// </summary>
    /// <param name="name">The name of the quantity.</param>
    /// <param name="quantityType">The type representing the quantity.</param>
    /// <param name="baseDimensions">The base dimensions of the quantity.</param>
    /// <param name="unitAbbreviations">
    ///     When provided, the resource manager used for localizing the quantity's unit abbreviations.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="name" />, <paramref name="quantityType" />, or <paramref name="baseDimensions" /> is
    ///     <c>null</c>.
    /// </exception>
    protected QuantityInfo(string name, Type quantityType, BaseDimensions baseDimensions, ResourceManager? unitAbbreviations)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        QuantityType = quantityType ?? throw new ArgumentNullException(nameof(quantityType));
        BaseDimensions = baseDimensions ?? throw new ArgumentNullException(nameof(baseDimensions));
        UnitAbbreviations = unitAbbreviations;
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public Type QuantityType { get; }

    /// <inheritdoc cref="QuantityType" />
    [Obsolete("Replaced by the QuantityType property.")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public Type ValueType
    {
        get => QuantityType;
    }

    /// <inheritdoc />
    public abstract Type UnitType { get; }

    /// <inheritdoc />
    public BaseDimensions BaseDimensions { get; }

    /// <inheritdoc />
    public ResourceManager? UnitAbbreviations { get; }

    /// <inheritdoc />
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public IQuantity Zero
    {
        get => GetGenericZero();
    }

    /// <inheritdoc cref="Zero" />
    protected internal abstract IQuantity GetGenericZero();

    /// <inheritdoc />
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public UnitInfo BaseUnitInfo
    {
        get => GetGenericBaseUnitInfo();
    }
    
    /// <inheritdoc cref="BaseUnitInfo" />
    protected internal abstract UnitInfo GetGenericBaseUnitInfo();

    /// <inheritdoc />
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public IReadOnlyList<UnitInfo> UnitInfos
    {
        get => GetGenericUnitInfos();
    }

    /// <inheritdoc cref="UnitInfos" />
    protected internal abstract IReadOnlyList<UnitInfo> GetGenericUnitInfos();

    /// <inheritdoc />
    public abstract UnitInfo this[UnitKey unit] { get; }

    // /// <inheritdoc />
    // public abstract bool TryGetUnitInfo(UnitKey unit, [NotNullWhen(true)] out UnitInfo? unitInfo);

    /// <inheritdoc />
    public UnitInfo GetUnitInfoFor(BaseUnits baseUnits)
    {
        return UnitInfos.GetUnitInfoFor(baseUnits);
    }

    /// <inheritdoc />
    public IEnumerable<UnitInfo> GetUnitInfosFor(BaseUnits baseUnits)
    {
        return UnitInfos.GetUnitInfosFor(baseUnits);
    }

    /// <summary>
    ///     Creates an instance of <see cref="IQuantity" /> from the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the quantity.</param>
    /// <param name="unitKey">The unit of the quantity, represented as an enumeration.</param>
    /// <returns>An instance of <see cref="IQuantity" /> representing the specified value and unit.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitKey" /> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="unitKey" /> is not a valid unit for this quantity.</exception>
    internal abstract IQuantity From(QuantityValue value, UnitKey unitKey);

    /// <inheritdoc />
    public override string ToString()
    {
        return Name;
    }
}

/// <inheritdoc cref="QuantityInfo" />
/// <remarks>
///     This is a specialization of <see cref="QuantityInfo" />, for when the unit type is known.
///     Typically, you obtain this by looking it up statically from <see cref="Length.Info" /> or
///     <see cref="Length.QuantityInfo" />, or dynamically via <see cref="IQuantity{TUnitType}.QuantityInfo" />.
/// </remarks>
/// <typeparam name="TUnit">The unit enum type, such as <see cref="LengthUnit" />. </typeparam>
public abstract class QuantityInfo<TUnit> : QuantityInfo//, IQuantityInfo<TUnit>
    where TUnit : struct, Enum
{
    /// <inheritdoc />
    protected QuantityInfo(string name, Type quantityType, BaseDimensions baseDimensions, ResourceManager? unitAbbreviations = null)
        : base(name, quantityType, baseDimensions, unitAbbreviations)
    {
    }

    #region Implementation of IQuantityInfo<TUnit>

    /// <inheritdoc cref="QuantityInfo.BaseUnitInfo" />
    public new UnitInfo<TUnit> BaseUnitInfo
    {
        get => GetBaseUnitInfo();
    }
    
    /// <inheritdoc cref="BaseUnitInfo" />
    protected internal abstract UnitInfo<TUnit> GetBaseUnitInfo();

    /// <inheritdoc cref="QuantityInfo.Zero" />
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public new IQuantity<TUnit> Zero
    {
        get => GetZero();
    }

    /// <inheritdoc cref="Zero" />
    protected internal abstract IQuantity<TUnit> GetZero();

    /// <inheritdoc cref="QuantityInfo.UnitInfos" />
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public new IReadOnlyList<UnitInfo<TUnit>> UnitInfos
    {
        get => GetUnitInfos();
    }

    /// <inheritdoc cref="UnitInfos" />
    protected internal abstract IReadOnlyList<UnitInfo<TUnit>> GetUnitInfos();

    /// <inheritdoc cref="GetUnitInfo" />
    public UnitInfo<TUnit> this[TUnit unit]
    {
        get => GetUnitInfo(unit);
    }

    /// <summary>
    ///     Retrieves the unit information for the specified unit.
    /// </summary>
    /// <param name="unit">The unit for which to retrieve information.</param>
    /// <returns>An <see cref="UnitInfo{TUnit}" /> instance containing information about the specified unit.</returns>
    /// <exception cref="ArgumentException">Thrown if the specified unit is not valid for this quantity.</exception>
    protected internal abstract UnitInfo<TUnit> GetUnitInfo(TUnit unit);
    
    //  /// <inheritdoc cref="QuantityInfo.TryGetUnitInfo" />
    // public abstract bool TryGetUnitInfo(TUnit unit, [NotNullWhen(true)] out UnitInfo<TUnit>? unitInfo);
    
    /// <inheritdoc cref="QuantityInfo.GetUnitInfoFor" />
    public new UnitInfo<TUnit> GetUnitInfoFor(BaseUnits baseUnits)
    {
        return UnitInfos.GetUnitInfoFor(baseUnits);
    }
    
    /// <inheritdoc cref="QuantityInfo.GetUnitInfosFor" />
    public new IEnumerable<UnitInfo<TUnit>> GetUnitInfosFor(BaseUnits baseUnits)
    {
        return UnitInfos.GetUnitInfosFor(baseUnits);
    }
    
    /// <inheritdoc cref="QuantityInfo.From" />
    public IQuantity<TUnit> From(QuantityValue value, TUnit unit)
    {
        return CreateGenericQuantity(value, unit);
    }

    /// <inheritdoc cref="From(UnitsNet.QuantityValue,TUnit)" />
    protected internal abstract IQuantity<TUnit> CreateGenericQuantity(QuantityValue value, TUnit unit);

    #endregion

    #region Overrides of QuantityInfo

    /// <inheritdoc />
    public override Type UnitType
    {
        get => typeof(TUnit);
    }

    /// <inheritdoc />
    protected internal override IQuantity GetGenericZero()
    {
        return Zero;
    }

    /// <inheritdoc />
    protected internal override UnitInfo GetGenericBaseUnitInfo()
    {
        return BaseUnitInfo;
    }

    /// <inheritdoc />
    protected internal override IReadOnlyList<UnitInfo> GetGenericUnitInfos()
    {
        return UnitInfos;
    }

    /// <inheritdoc />
    public override UnitInfo this[UnitKey unit]
    {
        get => this[unit.ToUnit<TUnit>()];
    }

    // /// <inheritdoc />
    // public override bool TryGetUnitInfo(UnitKey unit, [NotNullWhen(true)] out UnitInfo? unitInfo)
    // {
    //     if (unit.UnitType == typeof(TUnit) && TryGetUnitInfo(unit.ToUnit<TUnit>(), out UnitInfo<TUnit>? unitMapping))
    //     {
    //         unitInfo = unitMapping;
    //         return true;
    //     }
    //
    //     unitInfo = null;
    //     return false;
    // }

    /// <inheritdoc />
    internal override IQuantity From(QuantityValue value, UnitKey unitKey)
    {
        return From(value, unitKey.ToUnit<TUnit>());
    }

    #endregion
}

/// <inheritdoc cref="IQuantityInfo" />
public abstract class QuantityInfoBase<TQuantity, TUnit, TUnitInfo> : QuantityInfo<TUnit>, IQuantityInstanceInfo<TQuantity>
    where TQuantity : IQuantity<TUnit>
    where TUnit : struct, Enum
    where TUnitInfo : UnitInfo<TUnit>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfoBase{TQuantity, TUnit, TUnitMapping}" /> class.
    /// </summary>
    /// <param name="name">The name of the quantity.</param>
    /// <param name="zero">The zero value of the quantity.</param>
    /// <param name="baseDimensions">The base dimensions of the quantity.</param>
    /// <param name="fromDelegate">The delegate for creating a quantity from a value and unit.</param>
    /// <param name="unitAbbreviations">
    ///     When provided, the resource manager used for localizing the quantity's unit abbreviations.
    /// </param>
    protected QuantityInfoBase(string name, TQuantity zero, BaseDimensions baseDimensions, QuantityFromDelegate<TQuantity, TUnit> fromDelegate,
        ResourceManager? unitAbbreviations)
        : base(name, zero.GetType(), baseDimensions, unitAbbreviations)
    {
        Zero = zero;
        FromDelegate = fromDelegate;
    }

    private QuantityFromDelegate<TQuantity, TUnit> FromDelegate { get; }

    
    #region Implementation of IQuantityInfo<TQuantity, TUnit>

    /// <inheritdoc cref="IQuantityInfo.Zero" />
    public new TQuantity Zero { get; }

    /// <inheritdoc cref="IQuantityInfo.UnitInfos" />
    public new abstract IReadOnlyList<TUnitInfo> UnitInfos { get; }

    /// <inheritdoc cref="IQuantityInfo.BaseUnitInfo" />
    public new abstract TUnitInfo BaseUnitInfo { get; }

    /// <inheritdoc cref="IQuantityInfo.this" />
    public new abstract TUnitInfo this[TUnit unit] { get; }

    /// <inheritdoc cref="QuantityInfo{TUnit}" />
    public abstract bool TryGetUnitInfo(TUnit unit, [NotNullWhen(true)] out TUnitInfo? unitInfo);

    /// <inheritdoc cref="IQuantityInfo.GetUnitInfosFor" />
    public new IEnumerable<TUnitInfo> GetUnitInfosFor(BaseUnits baseUnits)
    {
        return UnitInfos.GetUnitInfosFor(baseUnits);
    }

    /// <inheritdoc cref="IQuantityInfo.GetUnitInfoFor" />
    public new TUnitInfo GetUnitInfoFor(BaseUnits baseUnits)
    {
        return UnitInfos.GetUnitInfoFor(baseUnits);
    }

    /// <summary>
    ///     Creates an instance of the quantity from the specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the quantity.</param>
    /// <param name="unit">The unit of the quantity.</param>
    /// <returns>An instance of <typeparamref name="TQuantity" /> representing the specified value and unit.</returns>
    public new TQuantity From(QuantityValue value, TUnit unit)
    {
        return FromDelegate(value, unit);
    }

    // /// <inheritdoc cref="From(UnitsNet.QuantityValue,TUnit)"/>
    // public new TQuantity From(QuantityValue value, Enum unit)
    // {
    //     if (unit is not TUnit typedUnit)
    //     {
    //         throw new ArgumentException($"The given unit is of type {unit.GetType()}. Only {typeof(TUnit)} is supported.", nameof(unit));
    //     }
    //
    //     return From(value, typedUnit);
    // }

    /// <inheritdoc />
    TQuantity IQuantityInstanceInfo<TQuantity>.Create(QuantityValue value, UnitKey unitKey)
    {
        return From(value, unitKey.ToUnit<TUnit>());
    }

    #endregion
    
    #region Overrides of QuantityInfo<TUnit>

    /// <inheritdoc />
    protected internal override IQuantity<TUnit> GetZero()
    {
        return Zero;
    }

    /// <inheritdoc />
    protected internal override UnitInfo<TUnit> GetBaseUnitInfo()
    {
        return BaseUnitInfo;
    }

    /// <inheritdoc />
    protected internal override IReadOnlyList<UnitInfo<TUnit>> GetUnitInfos()
    {
        return UnitInfos;
    }

    /// <inheritdoc />
    protected internal override UnitInfo<TUnit> GetUnitInfo(TUnit unit)
    {
        return this[unit];
    }

    // /// <inheritdoc />
    // public override bool TryGetUnitInfo(TUnit unit, [NotNullWhen(true)] out UnitInfo<TUnit>? unitInfo)
    // {
    //     if (TryGetUnitInfo(unit, out TUnitInfo? unitMapping))
    //     {
    //         unitInfo = unitMapping;
    //         return true;
    //     }
    //
    //     unitInfo = null;
    //     return false;
    // }

    /// <inheritdoc />
    protected internal override IQuantity<TUnit> CreateGenericQuantity(QuantityValue value, TUnit unit)
    {
        return From(value, unit);
    }

    #endregion
}

/// <inheritdoc cref="QuantityInfoBase{TQuantity,TUnit,TUnitMapping}" />
public class QuantityInfo<TQuantity, TUnit> : QuantityInfoBase<TQuantity, TUnit, UnitInfo<TQuantity, TUnit>>//, IQuantityInfo<TQuantity, TUnit>
    where TQuantity : IQuantity<TQuantity, TUnit>
    where TUnit : struct, Enum
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly Dictionary<TUnit, UnitInfo<TQuantity, TUnit>> _unitMappings;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly UnitInfo<TQuantity, TUnit>[] _unitInfos;
    
    #if NET
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfo{TQuantity, TUnit}" /> class using the default quantity name.
    /// </summary>
    /// <param name="unitMappings">A collection of unit mapping configurations.</param>
    /// <param name="baseUnit">The base unit of the quantity.</param>
    /// <param name="baseDimensions">The base dimensions of the quantity.</param>
    /// <param name="unitAbbreviations">
    ///     When provided, the resource manager used for localizing the quantity's unit abbreviations.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitMappings" /> is <c>null</c>.</exception>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit mapping configuration is found for the specified <paramref name="baseUnit" />.
    /// </exception>
    public QuantityInfo(TUnit baseUnit, IEnumerable<IUnitDefinition<TUnit>> unitMappings, BaseDimensions baseDimensions, ResourceManager? unitAbbreviations = null)
        : this(typeof(TQuantity).Name, baseUnit, unitMappings, baseDimensions, TQuantity.From, unitAbbreviations)
    {
    }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfo{TQuantity, TUnit}" /> class.
    /// </summary>
    /// <param name="name">The name of the quantity.</param>
    /// <param name="unitMappings">A collection of unit mapping configurations.</param>
    /// <param name="baseUnit">The base unit of the quantity.</param>
    /// <param name="baseDimensions">The base dimensions of the quantity.</param>
    /// <param name="unitAbbreviations">
    ///     When provided, the resource manager used for localizing the quantity's unit abbreviations.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitMappings" /> is <c>null</c>.</exception>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit mapping configuration is found for the specified <paramref name="baseUnit" />.
    /// </exception>
    public QuantityInfo(string name, TUnit baseUnit, IEnumerable<IUnitDefinition<TUnit>> unitMappings, BaseDimensions baseDimensions, ResourceManager? unitAbbreviations = null)
        : this(name, baseUnit, unitMappings, TQuantity.From(QuantityValue.Zero, baseUnit), baseDimensions, TQuantity.From, unitAbbreviations)
    {
    }
    
    #endif

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfo{TQuantity, TUnit}" /> class using the default quantity name.
    /// </summary>
    /// <param name="unitMappings">A collection of unit mapping configurations.</param>
    /// <param name="baseUnit">The base unit of the quantity.</param>
    /// <param name="baseDimensions">The base dimensions of the quantity.</param>
    /// <param name="fromDelegate">A delegate to create a quantity from a value and unit.</param>
    /// <param name="unitAbbreviations">
    ///     When provided, the resource manager used for localizing the quantity's unit abbreviations.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitMappings" /> is <c>null</c>.</exception>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit mapping configuration is found for the specified <paramref name="baseUnit" />.
    /// </exception>
    public QuantityInfo(TUnit baseUnit, IEnumerable<IUnitDefinition<TUnit>> unitMappings, BaseDimensions baseDimensions,
        QuantityFromDelegate<TQuantity, TUnit> fromDelegate, ResourceManager? unitAbbreviations = null)
        : this(typeof(TQuantity).Name, baseUnit, unitMappings, baseDimensions, fromDelegate, unitAbbreviations)
    {
    }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfo{TQuantity, TUnit}" /> class.
    /// </summary>
    /// <param name="name">The name of the quantity.</param>
    /// <param name="unitMappings">A collection of unit mapping configurations.</param>
    /// <param name="baseUnit">The base unit of the quantity.</param>
    /// <param name="baseDimensions">The base dimensions of the quantity.</param>
    /// <param name="fromDelegate">A delegate to create a quantity from a value and unit.</param>
    /// <param name="unitAbbreviations">
    ///     When provided, the resource manager used for localizing the quantity's unit abbreviations.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitMappings" /> is <c>null</c>.</exception>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit mapping configuration is found for the specified <paramref name="baseUnit" />.
    /// </exception>
    public QuantityInfo(string name, TUnit baseUnit, IEnumerable<IUnitDefinition<TUnit>> unitMappings, BaseDimensions baseDimensions,
        QuantityFromDelegate<TQuantity, TUnit> fromDelegate, ResourceManager? unitAbbreviations = null)
        : this(name, baseUnit, unitMappings, fromDelegate(QuantityValue.Zero, baseUnit), baseDimensions, fromDelegate, unitAbbreviations)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfo{TQuantity, TUnit}" /> class.
    /// </summary>
    /// <param name="name">The name of the quantity.</param>
    /// <param name="baseUnit">The base unit of the quantity.</param>
    /// <param name="unitMappings">A collection of unit mapping configurations.</param>
    /// <param name="zero">The zero value of the quantity.</param>
    /// <param name="baseDimensions">The base dimensions of the quantity.</param>
    /// <param name="fromDelegate">A delegate to create a quantity from a value and unit.</param>
    /// <param name="unitAbbreviations">
    ///     When provided, the resource manager used for localizing the quantity's unit abbreviations.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitMappings" /> is <c>null</c>.</exception>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit mapping configuration is found for the specified <paramref name="baseUnit" />.
    /// </exception>
    public QuantityInfo(string name, TUnit baseUnit, IEnumerable<IUnitDefinition<TUnit>> unitMappings, TQuantity zero, BaseDimensions baseDimensions,
        QuantityFromDelegate<TQuantity, TUnit> fromDelegate, ResourceManager? unitAbbreviations = null)
        : base(name, zero, baseDimensions, fromDelegate, unitAbbreviations)
    {
        if (unitMappings == null)
        {
            throw new ArgumentNullException(nameof(unitMappings));
        }
#if NET
        _unitInfos = unitMappings.Select(unit => new UnitInfo<TQuantity, TUnit>(this, unit)).ToArray();
        _unitMappings = _unitInfos.ToDictionary(info => info.Value);
#else
        _unitMappings = unitMappings.ToDictionary(unit => unit.Value, unit => new UnitInfo<TQuantity, TUnit>(this, unit), UnitEqualityComparer<TUnit>.Default);
        _unitInfos = _unitMappings.Values.ToArray();
#endif
        if (!_unitMappings.TryGetValue(baseUnit, out UnitInfo<TQuantity, TUnit>? baseUnitInfo))
        {
            throw new UnitNotFoundException($"No unit mapping configuration found for the specified base unit: {baseUnit}");
        }

        BaseUnitInfo = baseUnitInfo;
    }

    /// <summary>
    ///     Gets a read-only collection of the units associated with this quantity.
    /// </summary>
    /// <value>
    ///     A collection of units of type <typeparamref name="TUnit" />.
    /// </value>
    public IReadOnlyCollection<TUnit> Units
    {
        get => _unitMappings.Keys;
    }

    #region Overrides of QuantityInfoBase<TQuantity,TUnit,UnitInfo<TQuantity,TUnit>>

    /// <inheritdoc cref="QuantityInfo{TQuantity,TUnitType}.BaseUnitInfo" />
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    public override UnitInfo<TQuantity, TUnit> BaseUnitInfo { get; }

    /// <inheritdoc />
    public override UnitInfo<TQuantity, TUnit> this[TUnit unit]
    {
        get => _unitMappings[unit];
    }

    /// <inheritdoc />
    public override bool TryGetUnitInfo(TUnit unit, [NotNullWhen(true)] out UnitInfo<TQuantity, TUnit>? unitInfo)
    {
        return _unitMappings.TryGetValue(unit, out unitInfo);
    }

    /// <inheritdoc cref="QuantityInfo{TQuantity,TUnit}.UnitInfos" />
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    public sealed override IReadOnlyList<UnitInfo<TQuantity, TUnit>> UnitInfos
    {
        get => _unitInfos;
    }

    #endregion

    #region Explicit implementation of IQuantityInfo<TUnit>
    
    // [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    // IReadOnlyCollection<UnitInfo<TUnit>> IQuantityInfo<TUnit>.UnitInfos
    // {
    //     get => UnitInfos;
    // }

    // [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    // UnitInfo<TUnit> IQuantityInfo<TUnit>.BaseUnitInfo
    // {
    //     get => BaseUnitInfo;
    // }

    // IUnitInfo<TUnit> IQuantityInfo<TUnit>.this[TUnit unit]
    // {
    //     get => this[unit];
    // }

    // bool IQuantityInfo<TUnit>.TryGetUnitInfo(TUnit unit, [NotNullWhen(true)] out IUnitInfo<TUnit>? unitInfo)
    // {
    //     if (TryGetUnitInfo(unit, out UnitInfo<TQuantity, TUnit>? info))
    //     {
    //         unitInfo = info;
    //         return true;
    //     }
    //
    //     unitInfo = null;
    //     return false;
    // }

    // IUnitInfo<TUnit> IQuantityInfo<TUnit>.GetUnitInfoFor(BaseUnits baseUnits)
    // {
    //     return GetUnitInfoFor(baseUnits);
    // }

    // IEnumerable<IUnitInfo<TUnit>> IQuantityInfo<TUnit>.GetUnitInfosFor(BaseUnits baseUnits)
    // {
    //     return GetUnitInfosFor(baseUnits);
    // }

    // IQuantity<TUnit> IQuantityInfo<TUnit>.From(QuantityValue value, TUnit unit)
    // {
    //     return From(value, unit);
    // }

    // [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    // IQuantity<TUnit> IQuantityInfo<TUnit>.Zero
    // {
    //     get => Zero;
    // }

    
    // /// <inheritdoc />
    // TQuantity IQuantityInstanceInfo<TQuantity>.Create(QuantityValue value, UnitKey unitKey)
    // {
    //     return From(value, unitKey.ToUnit<TUnit>());
    // }
    
    #endregion

    #region Implementation of IQuantityInfo<TQuantity,TUnit>

    // [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    // IReadOnlyCollection<UnitInfo<TQuantity, TUnit>> IQuantityInfo<TQuantity, TUnit>.UnitInfos
    // {
    //     get => UnitInfos;
    // }

    // [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    // IUnitInfo<TQuantity, TUnit> IQuantityInfo<TQuantity, TUnit>.BaseUnitInfo
    // {
    //     get => BaseUnitInfo;
    // }

    // UnitInfo<TQuantity, TUnit> IQuantityInfo<TQuantity, TUnit>.this[TUnit unit]
    // {
    //     get => this[unit];
    // }

    // UnitInfo<TQuantity, TUnit> IQuantityInfo<TQuantity, TUnit>.GetUnitInfoFor(BaseUnits baseUnits)
    // {
    //     return GetUnitInfoFor(baseUnits);
    // }

    // IEnumerable<UnitInfo<TQuantity, TUnit>> IQuantityInfo<TQuantity, TUnit>.GetUnitInfosFor(BaseUnits baseUnits)
    // {
    //     return GetUnitInfosFor(baseUnits);
    // }

    #endregion
}
