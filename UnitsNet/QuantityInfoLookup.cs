using System.Linq;
#if NET8_0_OR_GREATER
using System.Collections.Frozen;
using QuantityByTypeLookupDictionary = System.Collections.Frozen.FrozenDictionary<System.Type, UnitsNet.QuantityInfo>;
using QuantityByNameLookupDictionary = System.Collections.Frozen.FrozenDictionary<string, UnitsNet.QuantityInfo>;
using UnitByKeyLookupDictionary = System.Collections.Frozen.FrozenDictionary<UnitsNet.UnitKey, UnitsNet.UnitInfo>;
#else
using QuantityByTypeLookupDictionary = System.Collections.Generic.Dictionary<System.Type, UnitsNet.QuantityInfo>;
using QuantityByNameLookupDictionary = System.Collections.Generic.Dictionary<string, UnitsNet.QuantityInfo>;
using UnitByKeyLookupDictionary = System.Collections.Generic.Dictionary<UnitsNet.UnitKey, UnitsNet.UnitInfo>;
#endif

namespace UnitsNet;

/// <summary>
///     A collection of <see cref="QuantityInfo" />.
/// </summary>
/// <remarks>
///     Access type is <c>internal</c> until this class is matured and ready for external use.
/// </remarks>
public class QuantityInfoLookup
{
    private readonly QuantityInfo[] _quantities;
    private readonly Lazy<QuantityByNameLookupDictionary> _quantitiesByName;
    private readonly Lazy<QuantityByTypeLookupDictionary> _quantitiesByType;
    private readonly Lazy<QuantityByTypeLookupDictionary> _quantitiesByUnitType;
    private readonly Lazy<UnitByKeyLookupDictionary> _unitsByKey;

    private QuantityByNameLookupDictionary GroupQuantitiesByName()
    {
#if NET8_0_OR_GREATER
        return _quantities.ToFrozenDictionary(info => info.Name, StringComparer.OrdinalIgnoreCase);
#else
        return _quantities.ToDictionary(info => info.Name, StringComparer.OrdinalIgnoreCase);
#endif
    }

    private QuantityByTypeLookupDictionary GroupQuantitiesByType()
    {
#if NET8_0_OR_GREATER
        return _quantities.ToFrozenDictionary(info => info.QuantityType);
#else
        return _quantities.ToDictionary(info => info.QuantityType);
#endif
    }

    private QuantityByTypeLookupDictionary GroupQuantitiesByUnitType()
    {
#if NET8_0_OR_GREATER
        return _quantities.ToFrozenDictionary(info => info.UnitType);
#else
        return _quantities.ToDictionary(info => info.UnitType);
#endif
    }

    private UnitByKeyLookupDictionary GroupUnitsByKey()
    {
#if NET8_0_OR_GREATER
        return _quantities.SelectMany(quantityInfo => quantityInfo.UnitInfos).ToFrozenDictionary(x => x.UnitKey);
#else
        return _quantities.SelectMany(quantityInfo => quantityInfo.UnitInfos).ToDictionary(x => x.UnitKey);
#endif
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityInfoLookup" /> class.
    /// </summary>
    /// <param name="quantityInfos">
    ///     A collection of <see cref="QuantityInfo" /> objects representing the quantities to be managed by this lookup.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="quantityInfos" /> parameter is <c>null</c>.
    /// </exception>
    /// <remarks>
    ///     This constructor organizes the provided quantity information into internal lookup structures
    ///     for efficient access by name, unit type, and unit key.
    /// </remarks>
    public QuantityInfoLookup(IEnumerable<QuantityInfo> quantityInfos)
    {
        _quantities = quantityInfos as QuantityInfo[] ?? quantityInfos.ToArray();
        _quantitiesByName = new Lazy<QuantityByNameLookupDictionary>(GroupQuantitiesByName);
        _quantitiesByType = new Lazy<QuantityByTypeLookupDictionary>(GroupQuantitiesByType);
        _quantitiesByUnitType = new Lazy<QuantityByTypeLookupDictionary>(GroupQuantitiesByUnitType);
        _unitsByKey = new Lazy<UnitByKeyLookupDictionary>(GroupUnitsByKey);
    }

    /// <summary>
    ///     All quantity names, such as "Length" and "Mass".
    /// </summary>
    public IReadOnlyCollection<string> Names => _quantitiesByName.Value.Keys;

    /// <summary>
    ///     A read-only dictionary that maps quantity names to their corresponding <see cref="QuantityInfo" />.
    /// </summary>
    public IReadOnlyDictionary<string, QuantityInfo> ByName => _quantitiesByName.Value;

    /// <summary>
    ///     All quantity information objects, such as <see cref="Length.Info" /> and <see cref="Mass.Info" />.
    /// </summary>
    public IReadOnlyList<QuantityInfo> Infos => _quantities;

    internal static QuantityInfoLookup Create(IEnumerable<QuantityInfo> defaultQuantities, Action<QuantitiesSelector> configureQuantities)
    {
        var selector = new QuantitiesSelector(() => defaultQuantities);
        configureQuantities(selector);
        return Create(selector);
    }

    internal static QuantityInfoLookup Create(QuantitiesSelector selector)
    {
        return new QuantityInfoLookup(selector.GetQuantityInfos());
    }

    /// <summary>
    ///     Retrieves the <see cref="QuantityInfo" /> associated with the specified quantity type.
    /// </summary>
    /// <param name="quantityType">The type of the quantity to retrieve information for.</param>
    /// <returns>The <see cref="QuantityInfo" /> for the specified quantity type.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the <paramref name="quantityType" /> is not of type <see cref="IQuantity" />.
    /// </exception>
    /// <exception cref="QuantityNotFoundException">
    ///     Thrown when the specified quantity type is not registered in the current configuration.
    /// </exception>
    public QuantityInfo GetQuantityInfo(Type quantityType)
    {
        if (TryGetQuantityInfo(quantityType, out QuantityInfo? quantityInfo))
        {
            return quantityInfo;
        }

        if (!typeof(IQuantity).IsAssignableFrom(quantityType))
        {
            throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");
        }

        throw new QuantityNotFoundException($"The specified quantity type is not registered in the current configuration: '{quantityType}'.");
    }

    /// <summary>
    ///     Try to get the <see cref="QuantityInfo" /> for a given quantity type.
    /// </summary>
    public bool TryGetQuantityInfo(Type quantityType, [NotNullWhen(true)] out QuantityInfo? quantityInfo)
    {
        return _quantitiesByType.Value.TryGetValue(quantityType, out quantityInfo);
    }

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
            // throw new UnitNotFoundException($"Unit not found in the list of {_unitsByKey.Value.Count} units:  unitKey.UnitType.GetHashCode = {unitKey.UnitType.GetHashCode()}, unitKey.Value={unitKey.UnitValue}, unitKey.UnitType.FullName = {unitKey.UnitType.FullName}");
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
    ///     Dynamically construct a quantity.
    /// </summary>
    /// <param name="value">Numeric value.</param>
    /// <param name="unit">Unit enum value.</param>
    /// <returns>An <see cref="IQuantity" /> object.</returns>
    /// <exception cref="UnitNotFoundException">Unit value is not a know unit enum type.</exception>
    public IQuantity From(QuantityValue value, UnitKey unit)
    {
        return GetUnitInfo(unit).From(value);
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
    public bool TryFrom(QuantityValue value, [NotNullWhen(true)] Enum? unit, [NotNullWhen(true)] out IQuantity? quantity)
    {
        if (unit == null)
        {
            quantity = null;
            return false;
        }
        
        if (!TryGetUnitInfo(unit, out UnitInfo? unitInfo))
        {
            quantity = null;
            return false;
        }

        quantity = unitInfo.From(value);
        return true;
    }

    /// <summary>
    ///     Retrieves the <see cref="QuantityInfo" /> associated with the specified quantity name.
    /// </summary>
    /// <param name="quantityName">The name of the quantity to retrieve information for.</param>
    /// <returns>The <see cref="QuantityInfo" /> associated with the specified quantity name.</returns>
    /// <exception cref="QuantityNotFoundException">
    ///     Thrown when no quantity information is found for the specified quantity name.
    /// </exception>
    public QuantityInfo GetQuantityByName(string quantityName)
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
    public bool TryGetQuantityByName(string quantityName, [NotNullWhen(true)] out QuantityInfo? quantityInfo)
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
    public UnitInfo GetUnitByName(string quantityName, string unitName)
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
    public bool TryGetUnitByName(string quantityName, string unitName, [NotNullWhen(true)] out UnitInfo? unitInfo)
    {
        if (!TryGetQuantityByName(quantityName, out QuantityInfo? quantityInfo))
        {
            unitInfo = null;
            return false;
        }

        unitInfo = quantityInfo.UnitInfos.FirstOrDefault(unit => string.Equals(unit.Name, unitName, StringComparison.OrdinalIgnoreCase));
        return unitInfo is not null;
    }

    /// <summary>
    ///     Attempts to retrieve the <see cref="QuantityInfo" /> associated with the specified unit type.
    /// </summary>
    /// <param name="unitType">The <see cref="Type" /> of the unit to look up.</param>
    /// <param name="quantityInfo">
    ///     When this method returns, contains the <see cref="QuantityInfo" /> associated with the specified unit type,
    ///     if the lookup was successful; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if a <see cref="QuantityInfo" /> associated with the specified unit type was found; otherwise,
    ///     <c>false</c>.
    /// </returns>
    public bool TryGetQuantityByUnitType(Type unitType, [NotNullWhen(true)] out QuantityInfo? quantityInfo)
    {
        return _quantitiesByUnitType.Value.TryGetValue(unitType, out quantityInfo);
    }

    /// <summary>
    ///     Retrieves the <see cref="QuantityInfo" /> associated with the specified unit type.
    /// </summary>
    /// <param name="unitType">The <see cref="Type" /> of the unit for which the quantity information is requested.</param>
    /// <returns>The <see cref="QuantityInfo" /> corresponding to the specified unit type.</returns>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no quantity is found for the specified unit type.
    ///     The exception includes additional data with the key "unitType" containing the name of the unit type.
    /// </exception>
    public QuantityInfo GetQuantityByUnitType(Type unitType)
    {
        if (TryGetQuantityByUnitType(unitType, out QuantityInfo? quantityInfo))
        {
            return quantityInfo;
        }

        throw new UnitNotFoundException($"No quantity was found with the specified unit type: '{unitType}'.") { Data = { ["unitType"] = unitType.Name } };
    }
}
