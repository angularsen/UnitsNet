using System;
using System.Diagnostics;
using System.Globalization;

namespace UnitsNet.Debug;

/// <summary>
///     Serves as a debug display proxy for a quantity, providing a convenient way to view various components of the
///     quantity during debugging.
/// </summary>
/// <remarks>
///     This struct provides a structured view of a quantity's components such as abbreviation, unit, value, and convertor
///     during debugging.
///     Each component is represented by a nested struct, which can be expanded in the debugger to inspect its properties.
/// </remarks>
public readonly struct QuantityDebugProxy: IFormattable
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly IQuantity _quantity;

    /// <summary>
    ///     Serves as a debug display proxy for a quantity, providing a convenient way to view various components of the
    ///     quantity during debugging.
    /// </summary>
    /// <remarks>
    ///     This struct provides a structured view of a quantity's components such as abbreviation, unit, value, and convertor
    ///     during debugging.
    ///     Each component is represented by a nested struct, which can be expanded in the debugger to inspect its properties.
    /// </remarks>
    public QuantityDebugProxy(IQuantity quantity)
        // we want to avoid initializing the default configuration from the debug proxy (e.g. when debugging the configuration initialization)
        : this(quantity, GetConfiguration(quantity.QuantityInfo))
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityDebugProxy" /> class with the specified quantity and
    ///     configuration.
    /// </summary>
    /// <param name="quantity">The quantity to be displayed, providing value and unit information.</param>
    /// <param name="configuration">The configuration settings for formatting and displaying the quantity.</param>
    public QuantityDebugProxy(IQuantity quantity, UnitsNetSetup configuration)
    {
        _quantity = quantity;
        Configuration = configuration;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal UnitsNetSetup Configuration { get; }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal QuantityInfo QuantityInfo
    {
        get => _quantity.QuantityInfo;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal UnitKey UnitKey
    {
        get => _quantity.UnitKey;
    }

    internal QuantityDebugProxy ConvertTo(UnitInfo unit)
    {
        return new QuantityDebugProxy(ConvertToUnit(unit), Configuration);
    }

    internal IQuantity ConvertToUnit(UnitInfo unit)
    {
        return Configuration.UnitConverter.ConvertTo(_quantity, unit.UnitKey);
    }

    internal IQuantity ConvertToQuantity(QuantityInfo targetQuantity)
    {
        return Configuration.UnitConverter.ConvertTo(_quantity.Value, _quantity.UnitKey, targetQuantity);
    }

    /// <summary>
    ///     Gets the quantity information, which includes details about the quantity's definition
    ///     and its associated configuration.
    /// </summary>
    /// <value>
    ///     An instance of <see cref="QuantityInformation" /> that provides metadata and context
    ///     for the quantity represented by this <see cref="QuantityDebugProxy" />.
    /// </value>
    public QuantityInformation Quantity
    {
        get => new(this);
    }

    /// <summary>
    ///     Gets information about the unit associated with the quantity.
    /// </summary>
    /// <remarks>
    ///     This property provides detailed information about the unit, including its name, abbreviation, and other metadata.
    /// </remarks>
    public UnitInformation Unit
    {
        get => new(this, _quantity.QuantityInfo[_quantity.UnitKey]);
    }

    /// <summary>
    ///     Gets the display representation of the unit abbreviation for the quantity.
    /// </summary>
    /// <remarks>
    ///     This property provides a formatted display of the unit abbreviation based on the quantity and configuration.
    /// </remarks>
    /// <value>
    ///     An <see cref="UnitsNet.Debug.UnitAbbreviation" /> instance representing the unit abbreviation.
    /// </value>
    public UnitAbbreviation UnitAbbreviation
    {
        get => new(this);
    }

    /// <summary>
    ///     Gets the numeric value of the quantity represented by this instance.
    /// </summary>
    /// <remarks>
    ///     This property retrieves the underlying numeric value of the quantity,
    ///     which is represented as a <see cref="QuantityValue" />. It provides a way
    ///     to access the raw value of the quantity without any associated unit or formatting.
    /// </remarks>
    /// <value>
    ///     The numeric value of the quantity.
    /// </value>
    public QuantityValue Value
    {
        get => _quantity.Value;
    }

    /// <summary>
    ///     Gets the display formats for the value of the quantity.
    /// </summary>
    /// <remarks>
    ///     This property provides access to various string formats that can be used to represent
    ///     the value of the quantity in different ways, depending on the configuration and context.
    /// </remarks>
    public QuantityFormats ValueFormats => new(this);

    /// <summary>
    ///     Returns a string representation of the quantity using the configured formatter.
    /// </summary>
    /// <remarks>
    ///     This method utilizes the <see cref="UnitsNetSetup.Formatter" /> to format the quantity.
    ///     The output is typically intended for debugging or display purposes and adheres to the
    ///     formatting rules defined in the current configuration.
    /// </remarks>
    /// <returns>
    ///     A string representation of the quantity.
    /// </returns>
    public override string ToString()
    {
        return ToString(DefaultFormatSpecifier);
    }

    /// <summary>
    ///     Returns a string representation of the quantity debug proxy, formatted according to the specified format string.
    /// </summary>
    /// <param name="format">
    ///     A format string that specifies how the quantity should be formatted. If <c>null</c>, the default format specifier
    ///     is used.
    /// </param>
    /// <returns>
    ///     A string representation of the quantity debug proxy, formatted according to the specified format string.
    /// </returns>
    /// <remarks>
    ///     This method provides a way to customize the string representation of the quantity debug proxy for debugging
    ///     purposes.
    /// </remarks>
    public string ToString(string format)
    {
        return ToString(format, DefaultFormatProvider);
    }

    /// <summary>
    ///     Converts the quantity to its string representation using the specified format and format provider.
    /// </summary>
    /// <param name="format">
    ///     A standard or custom format string that determines how the quantity is formatted.
    ///     If <c>null</c>, a default format is used.
    /// </param>
    /// <param name="formatProvider">
    ///     An object that provides culture-specific formatting information. If <c>null</c>, the current culture is used.
    /// </param>
    /// <returns>
    ///     A string representation of the quantity, formatted according to the specified format and format provider.
    /// </returns>
    /// <remarks>
    ///     This method utilizes the <see cref="QuantityFormatter" /> to format the quantity.
    ///     The resulting string typically includes the quantity's value and its unit abbreviation.
    /// </remarks>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return Configuration.Formatter.Format(_quantity, format, formatProvider);
    }

    /// <summary>
    ///     The default display format string used for debugging quantities.
    /// </summary>
    /// <remarks>
    ///     This constant defines the format string applied to quantities when displayed in the debugger.
    ///     It utilizes the <see cref="QuantityFormats" /> to format the quantity's value and unit
    ///     in a concise and human-readable manner.
    /// </remarks>
    public const string DisplayFormat = "{UnitsNet.Debug.QuantityDebugProxy.Format(this), nq}";

    internal static UnitsNetSetup GetConfiguration(QuantityInfo quantityInfo)
    {
        if (UnitsNetSetup.DefaultConfiguration.IsValueCreated)
        {
            // we could check for UnitsNetSetup.Default.QuantityInfoLookup.ByName.ContainsKey(quantity.QuantityInfo.Name)
            // but that would cause the initialization of the lazy dictionary and would hide potential issues with quantities that are not part of the default configuration
            return UnitsNetSetup.Default;
        }

        return UnitsNetSetup.Create(builder => builder.WithQuantities([quantityInfo]));
    }

    /// <summary>
    ///     The default format string used for debugging representations of quantities.
    /// </summary>
    /// <remarks>
    ///     This format string is applied when no specific format is provided during the formatting
    ///     of a quantity for debugging purposes. The default value is "G", which represents the general format.
    /// </remarks>
    public static string DefaultFormatSpecifier = "G";

    /// <summary>
    ///     Gets or sets the default format provider used for formatting quantities in debug scenarios.
    /// </summary>
    /// <remarks>
    ///     This field determines the culture-specific formatting rules applied when formatting quantities.
    ///     If set to <c>null</c>, the default culture of the current thread is used.
    /// </remarks>
    public static CultureInfo? DefaultFormatProvider = null;

    /// <summary>
    ///     Formats the specified quantity into its string representation using the provided format.
    /// </summary>
    /// <param name="quantity">
    ///     The quantity to be formatted. This includes its value and associated unit.
    /// </param>
    /// <param name="format">
    ///     A standard or custom format string that determines how the quantity is formatted.
    ///     If <c>null</c>, a default format is used.
    /// </param>
    /// <returns>
    ///     A string representation of the quantity, formatted according to the specified format.
    /// </returns>
    /// <remarks>
    ///     This method creates a <see cref="QuantityDebugProxy" /> instance for the given quantity
    ///     and utilizes its <see cref="QuantityDebugProxy.ToString(string?, IFormatProvider?)" /> method
    ///     to generate the formatted string.
    /// </remarks>
    public static string Format<TQuantity>(TQuantity quantity, string? format = null)
        where TQuantity : IQuantity
    {
        try
        {
            UnitsNetSetup configuration = GetConfiguration(quantity.QuantityInfo);
            return configuration.Formatter.Format(quantity, format ?? DefaultFormatSpecifier, DefaultFormatProvider);
        }
        catch (Exception)
        {
            // the debugger's inline evaluator sometimes fails when working with Type objects (specifically on the first call)
            // see https://youtrack.jetbrains.com/issue/RSRP-499956/Local-Variable-Inline-Evaluation-Fails-for-System.Type
            return $"{{{quantity.Value} {quantity.QuantityInfo[quantity.UnitKey].PluralName}}}";
        }
    }
}
