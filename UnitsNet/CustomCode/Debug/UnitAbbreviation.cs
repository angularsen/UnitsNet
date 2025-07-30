using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace UnitsNet.Debug;

/// <summary>
///     Represents the display information for unit abbreviations associated with a specific quantity.
/// </summary>
/// <remarks>
///     This struct provides access to default and parseable abbreviations for units, as well as the default abbreviation
///     for the current unit of the quantity.
/// </remarks>
[DebuggerDisplay("{DefaultAbbreviation}")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly struct UnitAbbreviation
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly QuantityDebugProxy _quantityProxy;

    internal UnitAbbreviation(QuantityDebugProxy quantityProxy)
    {
        _quantityProxy = quantityProxy;
        Abbreviations = quantityProxy.Configuration.UnitAbbreviations.GetUnitAbbreviations(quantityProxy.UnitKey, QuantityDebugProxy.DefaultFormatProvider);
    }

    /// <summary>
    ///     Gets the default abbreviation for the current unit of the quantity.
    /// </summary>
    /// <remarks>
    ///     The default abbreviation is determined based on the unit key of the quantity and the configured unit abbreviations
    ///     cache.
    /// </remarks>
    /// <value>
    ///     A <see cref="string" /> representing the default abbreviation for the current unit.
    /// </value>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit information is found for the specified unit key.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when no abbreviations are mapped for the specified unit.
    /// </exception>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string DefaultAbbreviation
    {
        get => Abbreviations[0];
    }

    /// <summary>
    ///     Gets a read-only list of unit abbreviations associated with the current quantity.
    /// </summary>
    /// <remarks>
    ///     This property provides all abbreviations that can represent the unit of the current quantity.
    ///     These abbreviations are culture-sensitive and may vary depending on the localization settings.
    /// </remarks>
    /// <value>
    ///     A read-only list of strings representing the unit abbreviations.
    /// </value>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown when no unit information is found for the specified unit key.
    /// </exception>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public IReadOnlyList<string> Abbreviations { get; }

    /// <summary>
    ///     Gets the collection of parseable unit abbreviations for the associated quantity.
    /// </summary>
    /// <remarks>
    ///     This property provides an array of <see cref="UnitsNet.Debug.UnitAbbreviations" /> objects,
    ///     each representing the abbreviations that can be parsed for a specific unit of the quantity.
    /// </remarks>
    public UnitAbbreviations[] UnitAbbreviations
    {
        get
        {
            QuantityDebugProxy quantityProxy = _quantityProxy;
            return quantityProxy.QuantityInfo.UnitInfos.Select(targetUnit => new UnitAbbreviations(quantityProxy, targetUnit)).ToArray();
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return DefaultAbbreviation;
    }
}

/// <summary>
///     Represents a collection of unit abbreviations for a specific unit of a quantity.
/// </summary>
/// <remarks>
///     This struct provides access to the unit's abbreviations and allows conversion of the quantity to the specified
///     unit.
/// </remarks>
[DebuggerDisplay("{ToString(), nq}")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly struct UnitAbbreviations
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private QuantityDebugProxy QuantityProxy { get; }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private UnitInfo TargetUnit { get; }

    internal UnitAbbreviations(QuantityDebugProxy quantityProxy, UnitInfo targetUnit)
    {
        QuantityProxy = quantityProxy;
        TargetUnit = targetUnit;
    }

    /// <summary>
    ///     Gets a debug proxy representation of the quantity associated with the current unit.
    /// </summary>
    /// <remarks>
    ///     This property provides a converted view of the quantity in the context of the specified unit,
    ///     enabling detailed inspection of its components during debugging.
    /// </remarks>
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public QuantityDebugProxy Quantity
    {
        get => QuantityProxy.ConvertTo(TargetUnit);
    }

    /// <summary>
    ///     Gets the list of abbreviations associated with the target unit.
    /// </summary>
    /// <remarks>
    ///     The abbreviations are retrieved from the <see cref="UnitAbbreviationsCache" /> configured in the
    ///     <see cref="QuantityDebugProxy" />. These abbreviations are culture-sensitive and may vary based on the
    ///     current culture or a fallback culture.
    /// </remarks>
    /// <value>
    ///     A read-only list of strings representing the abbreviations for the target unit.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public IReadOnlyList<string> Abbreviations
    {
        get => QuantityProxy.Configuration.UnitAbbreviations.GetAbbreviationsWithFallbackCulture(TargetUnit, QuantityDebugProxy.DefaultFormatProvider ?? CultureInfo.CurrentCulture);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return string.Join(", ", Abbreviations.Select(x => $"\"{x}\""));
    }
}
