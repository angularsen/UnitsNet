using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace UnitsNet.Debug;

/// <summary>
///     Represents information about a specific unit within a quantity.
/// </summary>
/// <remarks>
///     This struct provides details about a unit, including its definition and possible conversions.
///     It is used to encapsulate unit-related metadata and operations within the context of a quantity.
/// </remarks>
[DebuggerDisplay("{Definition.Name, nq}")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly struct UnitInformation
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly QuantityDebugProxy _quantityProxy;

    internal UnitInformation(QuantityDebugProxy quantityProxy, UnitInfo unitInfo)
    {
        _quantityProxy = quantityProxy;
        Definition = unitInfo;
    }

    /// <summary>
    ///     Gets the definition of the unit, including its metadata and associated details.
    /// </summary>
    /// <remarks>
    ///     This property provides access to the unit's definition, which includes its name, value, and other metadata.
    ///     It is useful for retrieving information about the specific unit represented within the context of a quantity.
    /// </remarks>
    // [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public UnitInfo Definition { get; }

    /// <summary>
    ///     Gets the collection of unit conversions associated with the current unit.
    /// </summary>
    /// <remarks>
    ///     Each <see cref="UnitConversion" /> in the collection represents a possible conversion
    ///     from the current unit to another unit within the same quantity.
    ///     This property is useful for enumerating all available conversions for a unit.
    /// </remarks>
    public UnitConversion[] UnitConversions
    {
        get
        {
            QuantityDebugProxy quantityProxy = _quantityProxy;
            return quantityProxy.QuantityInfo.UnitInfos.Select(unit => new UnitConversion(quantityProxy, unit)).ToArray();
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Definition.ToString();
    }
}

/// <summary>
///     Represents a unit conversion for a specific quantity and unit type.
/// </summary>
/// <remarks>
///     This struct provides functionality to convert a quantity to a specific unit and retrieve its display
///     representation.
///     It is primarily used internally within the <see cref="QuantityDebugProxy" /> struct.
/// </remarks>
[DebuggerDisplay("{TargetUnit.Value, nq}")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly struct UnitConversion
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private QuantityDebugProxy QuantityProxy { get; }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private UnitInfo TargetUnit { get; }

    internal UnitConversion(QuantityDebugProxy quantityProxy, UnitInfo targetUnit)
    {
        QuantityProxy = quantityProxy;
        TargetUnit = targetUnit;
    }

    /// <summary>
    ///     Gets the quantity representation after converting to the specified unit.
    /// </summary>
    /// <remarks>
    ///     This property provides a <see cref="QuantityDebugProxy" /> instance that represents the quantity
    ///     converted to the unit specified by the <see cref="UnitConversion" />.
    ///     It utilizes the <see cref="UnitConverter" /> for the conversion process.
    /// </remarks>
    /// <value>
    ///     A <see cref="QuantityDebugProxy" /> instance representing the converted quantity.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public QuantityDebugProxy Quantity
    {
        get => QuantityProxy.ConvertTo(TargetUnit);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return TargetUnit.ToString();
    }
}
