using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
#if NET8_0_OR_GREATER
using System.Collections.Frozen;
using QuantityByTypeLookupDictionary = System.Collections.Frozen.FrozenDictionary<System.Type, UnitsNet.QuantityInfo>;
#else
using QuantityByTypeLookupDictionary = System.Collections.Generic.Dictionary<System.Type, UnitsNet.QuantityInfo>;
#endif
using UnitByKeyLookupDictionary = System.Collections.Generic.Dictionary<UnitsNet.UnitKey, UnitsNet.UnitInfo>;

namespace UnitsNet;

/// <summary>
///     A collection of <see cref="QuantityInfo" />.
/// </summary>
/// <remarks>
///     Access type is <c>internal</c> until this class is matured and ready for external use.
/// </remarks>
internal class QuantityInfoLookup
{
    private readonly Lazy<SortedDictionary<string, QuantityInfo>> _quantitiesByName;
    private readonly Lazy<QuantityByTypeLookupDictionary> _quantitiesByType;
    private readonly Lazy<QuantityByTypeLookupDictionary> _quantitiesByUnitType;
    private readonly Lazy<UnitByKeyLookupDictionary> _unitsByKey;

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfoLookup" /> class.
    /// </summary>
    /// <param name="quantityInfos">A collection of quantity information objects.</param>
    public QuantityInfoLookup(IReadOnlyCollection<QuantityInfo> quantityInfos)
    {
        _quantitiesByName = new Lazy<SortedDictionary<string, QuantityInfo>>(() =>
            new SortedDictionary<string, QuantityInfo>(quantityInfos.ToDictionary(info => info.Name), StringComparer.OrdinalIgnoreCase));

#if NET8_0_OR_GREATER
        _quantitiesByType = new Lazy<QuantityByTypeLookupDictionary>(() => quantityInfos.ToFrozenDictionary(info => info.QuantityType));
        _quantitiesByUnitType = new Lazy<QuantityByTypeLookupDictionary>(() => quantityInfos.ToFrozenDictionary(info => info.UnitType));
#else
        _quantitiesByType = new Lazy<QuantityByTypeLookupDictionary>(() => quantityInfos.ToDictionary(info => info.QuantityType));
        _quantitiesByUnitType = new Lazy<QuantityByTypeLookupDictionary>(() => quantityInfos.ToDictionary(info => info.UnitType));
#endif
        _unitsByKey = new Lazy<UnitByKeyLookupDictionary>(() => quantityInfos.SelectMany(quantityInfo => quantityInfo.UnitInfos).ToDictionary(x => x.UnitKey));
    }

    /// <summary>
    ///     All enum value names of <see cref="Infos" />, such as "Length" and "Mass".
    /// </summary>
    public IReadOnlyCollection<string> Names => _quantitiesByName.Value.Keys;

    /// <summary>
    ///     A read-only dictionary that maps quantity names to their corresponding <see cref="QuantityInfo" />.
    /// </summary>
    public IReadOnlyDictionary<string, QuantityInfo> ByName => _quantitiesByName.Value;

    /// <summary>
    ///     All quantity information objects, such as <see cref="Length.Info" /> and <see cref="Mass.Info" />.
    /// </summary>
    public IReadOnlyCollection<QuantityInfo> Infos => _quantitiesByName.Value.Values;

    /// <summary>
    ///     Retrieves the <see cref="UnitInfo" /> for a specified <see cref="UnitKey" />.
    /// </summary>
    /// <param name="unitKey">The key representing the unit for which information is being requested.</param>
    /// <returns>The <see cref="UnitInfo" /> associated with the specified <paramref name="unitKey" />.</returns>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit information is found for the specified
    ///     <paramref name="unitKey" />.
    /// </exception>
    public UnitInfo GetUnitInfo(UnitKey unitKey)
    {
        if (!TryGetUnitInfo(unitKey, out UnitInfo? unitInfo))
        {
            throw new UnitNotFoundException($"No unit information found for the specified enum value: {unitKey}.");
        }

        return unitInfo;
    }

    /// <summary>
    ///     Try to get <see cref="UnitInfo" /> for a given unit enum value.
    /// </summary>
    public bool TryGetUnitInfo(UnitKey unitKey, [NotNullWhen(true)] out UnitInfo? unitInfo)
    {
        return _unitsByKey.Value.TryGetValue(unitKey, out unitInfo);
    }
    
    /// <summary>
    ///
    /// </summary>
    /// <param name="unitInfo"></param>
    public void AddUnitInfo(UnitInfo unitInfo)
    {
        _unitsByKey.Value.Add(unitInfo.UnitKey, unitInfo);
    }
    
    /// <summary>
    ///     Dynamically construct a quantity.
    /// </summary>
    /// <param name="value">Numeric value.</param>
    /// <param name="unit">Unit enum value.</param>
    /// <returns>An <see cref="IQuantity" /> object.</returns>
    /// <exception cref="UnitNotFoundException">Unit value is not a know unit enum type.</exception>
    public IQuantity From(double value, UnitKey unit)
    {
        // TODO Support custom units, currently only hardcoded built-in quantities are supported.
        return Quantity.TryFrom(value, (Enum)unit, out IQuantity? quantity)
            ? quantity
            : throw new UnitNotFoundException($"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a custom enum type defined outside the UnitsNet library?");
    }
    
    /// <summary>
    ///     Attempts to create a quantity from the specified value and unit.
    /// </summary>
    /// <param name="value">The value of the quantity.</param>
    /// <param name="unit">The unit of the quantity, represented as an <see cref="Enum" />.</param>
    /// <param name="quantity">
    ///     When this method returns, contains the created quantity if the conversion succeeded,
    ///     or <c>null</c> if the conversion failed. This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the quantity was successfully created; otherwise, <c>false</c>.
    /// </returns>
    public bool TryFrom(double value, [NotNullWhen(true)] Enum? unit, [NotNullWhen(true)] out IQuantity? quantity)
    {
        // TODO Support custom units, currently only hardcoded built-in quantities are supported.
        return Quantity.TryFrom(value, unit, out quantity);
    }

    /// <summary>
    ///     Retrieves the <see cref="QuantityInfo" /> associated with the specified quantity name.
    /// </summary>
    /// <param name="quantityName">The name of the quantity to retrieve information for.</param>
    /// <returns>The <see cref="QuantityInfo" /> associated with the specified quantity name.</returns>
    /// <exception cref="QuantityNotFoundException">
    ///     Thrown when no quantity information is found for the specified quantity name.
    /// </exception>
    internal QuantityInfo GetQuantityByName(string quantityName)
    {
        if (!ByName.TryGetValue(quantityName, out QuantityInfo? quantityInfo))
        {
            throw new QuantityNotFoundException($"No quantity information was found for the type: {quantityName}.")
            {
                Data = { ["quantityName"] = quantityName }
            };
        }

        return quantityInfo;
    }

    /// <summary>
    ///     Attempts to retrieve the <see cref="QuantityInfo" /> associated with the specified quantity name.
    /// </summary>
    /// <param name="quantityName">The name of the quantity to look up.</param>
    /// <param name="quantityInfo">
    ///     When this method returns, contains the <see cref="QuantityInfo" /> associated with the specified quantity name,
    ///     if the name is found; otherwise, <c>null</c>. This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the quantity name was found; otherwise, <c>false</c>.
    /// </returns>
    internal bool TryGetQuantityByName(string quantityName, [NotNullWhen(true)] out QuantityInfo? quantityInfo)
    {
        return ByName.TryGetValue(quantityName, out quantityInfo);
    }

    /// <summary>
    ///     Attempts to parse a unit information object based on its quantity and unit names.
    /// </summary>
    /// <param name="quantityName">
    ///     The invariant quantity name, such as "Length". This parameter does not support localization.
    /// </param>
    /// <param name="unitName">
    ///     The invariant unit enum name, such as "Meter". This parameter does not support localization.
    /// </param>
    /// <returns>
    ///     The <see cref="UnitInfo" /> object representing the unit information.
    /// </returns>
    /// <exception cref="QuantityNotFoundException">
    ///     Thrown when no quantity information is found for the specified quantity name.
    /// </exception>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit is found for the specified quantity name and unit name.
    /// </exception>
    internal UnitInfo GetUnitByName(string quantityName, string unitName)
    {
        QuantityInfo quantityInfo = GetQuantityByName(quantityName);
        UnitInfo? unitInfo = quantityInfo.UnitInfos.FirstOrDefault(unit => string.Equals(unit.Name, unitName, StringComparison.OrdinalIgnoreCase));
        return unitInfo ??
               throw new UnitNotFoundException($"No unit was found for quantity '{quantityName}' with the name: '{unitName}'.")
               {
                   Data = { ["quantityName"] = quantityName, ["unitName"] = unitName }
               };
    }
    
    /// <summary>
    ///     Attempts to parse unit information based on its quantity and unit names.
    /// </summary>
    /// <param name="quantityName">The invariant quantity name, such as "Length". This parameter does not support localization.</param>
    /// <param name="unitName">The invariant unit name, such as "Meter". This parameter does not support localization.</param>
    /// <param name="unitInfo">
    ///     When this method returns, contains the parsed unit information if the parsing succeeded, or <c>null</c> if the
    ///     parsing failed.
    /// </param>
    /// <returns><c>true</c> if the unit information was successfully parsed; otherwise, <c>false</c>.</returns>
    internal bool TryGetUnitByName(string quantityName, string unitName, [NotNullWhen(true)] out UnitInfo? unitInfo)
    {
        if (!TryGetQuantityByName(quantityName, out QuantityInfo? quantityInfo))
        {
            unitInfo = null;
            return false;
        }

        unitInfo = quantityInfo.UnitInfos.FirstOrDefault(unit => string.Equals(unit.Name, unitName, StringComparison.OrdinalIgnoreCase));
        return unitInfo is not null;
    }


    public bool TryGetQuantityByUnitType(Type unitType, [NotNullWhen(true)] out QuantityInfo? quantityInfo)
    {
        return _quantitiesByUnitType.Value.TryGetValue(unitType, out quantityInfo);
    }

    public QuantityInfo GetQuantityByUnitType(Type unitType)
    {
        if (TryGetQuantityByUnitType(unitType, out QuantityInfo? quantityInfo))
        {
            return quantityInfo;
        }

        throw new UnitNotFoundException($"No quantity was found with the specified unit type: '{unitType}'.") { Data = { ["unitType"] = unitType.Name } };
    }
}
