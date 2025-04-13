using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace UnitsNet.Debug;

/// <summary>
///     Represents detailed information about a quantity, including its definition, unit conversions, and quantity
///     conversions.
/// </summary>
/// <remarks>
///     This struct is primarily used for debugging purposes to provide a comprehensive view of a quantity's components.
///     It includes the quantity's definition, available unit conversions, and possible quantity conversions.
/// </remarks>
[DebuggerDisplay("{Definition.Name, nq}")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly struct QuantityInformation
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly QuantityDebugProxy _quantityProxy;

    internal QuantityInformation(QuantityDebugProxy quantityProxy)
    {
        _quantityProxy = quantityProxy;
        Definition = quantityProxy.QuantityInfo;
    }

    /// <summary>
    ///     Gets the definition of the quantity, which includes its name, base unit, and other metadata.
    /// </summary>
    /// <remarks>
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> provides detailed information about the quantity,
    ///     such as its name, available units, and base dimensions. This property is useful for understanding
    ///     the structure and characteristics of the quantity.
    /// </remarks>
    // [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public QuantityInfo Definition { get; }

    /// <summary>
    ///     Gets the array of unit conversions available for the quantity.
    /// </summary>
    /// <remarks>
    ///     Each element in the array represents a conversion of the quantity to a specific unit,
    ///     including its value in that unit, unit details, and formatted string representation.
    ///     This property provides a detailed view of how the quantity can be expressed in different units.
    /// </remarks>
    public ConvertedQuantity[] UnitConversions
    {
        get
        {
            QuantityDebugProxy quantityProxy = _quantityProxy;
            return Definition.UnitInfos.Select(unitInfo => new ConvertedQuantity(quantityProxy, unitInfo)).ToArray();
        }
    }

    /// <summary>
    ///     Gets the array of quantity conversions available for the current quantity.
    /// </summary>
    /// <remarks>
    ///     Each <see cref="QuantityConversion" /> represents a possible transformation from the current quantity
    ///     to another quantity type, enabling conversions between different quantity types within the UnitsNet library.
    /// </remarks>
    public QuantityConversion[] QuantityConversions
    {
        get
        {
            QuantityDebugProxy quantityProxy = _quantityProxy;
            return _quantityProxy.Configuration.UnitConverter.QuantityConversions.GetConversionsFrom(Definition)
                .Select(targetQuantity => new QuantityConversion(quantityProxy, targetQuantity)).ToArray();
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Definition.Name;
    }
}

/// <summary>
///     Represents a converted quantity, which includes the value of the quantity in a specific unit,
///     its associated unit information, and its abbreviation display.
/// </summary>
/// <remarks>
///     This struct is used to provide detailed information about a quantity converted to a specific unit,
///     including its value, unit details, and formatted string representation.
/// </remarks>
[DebuggerDisplay("{ToString(), nq}")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly struct ConvertedQuantity
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly QuantityDebugProxy _quantityProxy;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly UnitInfo _targetUnit;

    internal ConvertedQuantity(QuantityDebugProxy quantityProxy, UnitInfo targetUnit)
    {
        _quantityProxy = quantityProxy;
        _targetUnit = targetUnit;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private QuantityDebugProxy Converted
    {
        get => _quantityProxy.ConvertTo(_targetUnit);
    }

    /// <summary>
    ///     Gets detailed information about the unit associated with the converted quantity.
    /// </summary>
    /// <remarks>
    ///     This property provides metadata about the unit, including its definition and possible conversions.
    ///     It is useful for accessing unit-related details and performing operations within the context of the converted
    ///     quantity.
    /// </remarks>
    public UnitInformation Unit
    {
        get => new(_quantityProxy, _targetUnit);
    }

    /// <summary>
    ///     Gets the display information for the unit abbreviation of the converted quantity.
    /// </summary>
    /// <remarks>
    ///     This property provides access to the default and parseable abbreviations for the unit of the converted quantity.
    ///     It allows for consistent and localized representation of unit abbreviations.
    /// </remarks>
    public UnitAbbreviation UnitAbbreviation
    {
        get => new(Converted);
    }

    /// <summary>
    ///     Gets the numerical value of the converted quantity in its specific unit.
    /// </summary>
    /// <remarks>
    ///     This property provides the raw numerical representation of the quantity after it has been converted
    ///     to the specified unit. It is useful for calculations or comparisons involving the converted quantity.
    /// </remarks>
    public QuantityValue Value
    {
        get => Converted.Value;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Converted.ToString();
    }
}

/// <summary>
///     Represents a conversion between two quantities, allowing for the transformation of a quantity's value
///     from one unit system to another. This struct is used to facilitate conversions between different
///     quantity types within the context of the UnitsNet library.
/// </summary>
[DebuggerDisplay("{ToString()}")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly struct QuantityConversion
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly QuantityDebugProxy _quantityProxy;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly QuantityInfo _targetQuantity;

    internal QuantityConversion(QuantityDebugProxy quantityProxy, QuantityInfo targetQuantity)
    {
        _quantityProxy = quantityProxy;
        _targetQuantity = targetQuantity;
    }

    /// <summary>
    ///     Gets the converted quantity as an <see cref="IQuantity" /> instance.
    ///     This property performs the conversion of the original quantity to the target quantity type
    ///     using the specified unit conversion logic.
    /// </summary>
    /// <value>
    ///     The converted quantity represented as an <see cref="IQuantity" />.
    /// </value>
    /// <remarks>
    ///     This property utilizes the <see cref="UnitConverter" /> to transform the value and unit of the original quantity
    ///     into the corresponding representation in the target quantity type.
    /// </remarks>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public IQuantity Quantity
    {
        get => _quantityProxy.ConvertToQuantity(_targetQuantity);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _targetQuantity.ToString();
    }
}
