using System.ComponentModel;
using System.Diagnostics;

namespace UnitsNet.Debug;

/// <summary>
///     Represents a display of string formats for a quantity, providing formatted string representations
///     such as general and short formats.
/// </summary>
/// <remarks>
///     This struct is used to format and display quantities in various string representations,
///     leveraging the configuration provided by <see cref="UnitsNetSetup" />.
/// </remarks>
// [DebuggerDisplay("{GeneralFormat}")]
// [DebuggerDisplay("{ShortFormat}")]
[DebuggerDisplay("{ToString()}")]
[EditorBrowsable(EditorBrowsableState.Never)]
public readonly struct QuantityFormats
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly QuantityDebugProxy _quantityProxy;

    internal QuantityFormats(QuantityDebugProxy quantityProxy)
    {
        _quantityProxy = quantityProxy;
    }

    /// <summary>
    ///     Gets the general string representation of the quantity using the default general format specifier ("G").
    /// </summary>
    /// <value>
    ///     A string representing the quantity in a general format.
    /// </value>
    /// <remarks>
    ///     This property utilizes the <see cref="UnitsNet.QuantityFormatter" /> to format the quantity
    ///     with the general format specifier defined by <see cref="GeneralFormatSpecifier" />.
    /// </remarks>
    public string GeneralFormat
    {
        get => _quantityProxy.ToString(GeneralFormatSpecifier);
    }

    /// <summary>
    ///     Gets the scientific format representation of the quantity.
    /// </summary>
    /// <remarks>
    ///     The scientific format uses the "E" format specifier, which represents the quantity
    ///     in exponential notation, suitable for displaying very large or very small values.
    /// </remarks>
    public string ScientificFormat
    {
        get => _quantityProxy.ToString(ScientificFormatSpecifier);
    }

    /// <summary>
    ///     Gets the fixed-point format representation of the quantity.
    /// </summary>
    /// <remarks>
    ///     This property formats the quantity using the fixed-point format specifier ("F").
    ///     It provides a string representation of the quantity with a fixed number of decimal places.
    /// </remarks>
    /// <value>
    ///     A string representing the quantity in fixed-point format.
    /// </value>
    public string FixedPointFormat
    {
        get => _quantityProxy.ToString(FixedPointFormatSpecifier);
    }

    /// <summary>
    ///     Gets the number format representation of the quantity.
    /// </summary>
    /// <remarks>
    ///     This property formats the quantity using the "N" format specifier, which typically represents
    ///     a numeric format with thousands separators and a fixed number of decimal places, depending on
    ///     the current culture settings.
    /// </remarks>
    /// <value>
    ///     A string representing the quantity in the number format.
    /// </value>
    public string NumberFormat
    {
        get => _quantityProxy.ToString(NumberFormatSpecifier);
    }

    /// <summary>
    ///     Gets the short format string representation of the quantity.
    /// </summary>
    /// <remarks>
    ///     The short format is typically a concise representation of the quantity,
    ///     formatted using the "s" format specifier. This is useful for scenarios
    ///     where a compact display of the quantity is required.
    /// </remarks>
    /// <returns>
    ///     A string representing the quantity in its short format.
    /// </returns>
    public string ShortFormat
    {
        get => _quantityProxy.ToString(ShortFormatSpecifier);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _quantityProxy.ToString();
    }

    /// <summary>
    ///     The default format specifier used for general formatting of quantities.
    /// </summary>
    /// <remarks>
    ///     This field defines the format string "G", which represents the general format for quantities.
    ///     It is primarily used to provide a consistent and human-readable representation of quantities
    ///     when no specific format is explicitly provided.
    /// </remarks>
    public static string GeneralFormatSpecifier = "G";

    /// <summary>
    ///     The default format specifier used for scientific formatting of quantities.
    /// </summary>
    /// <remarks>
    ///     This field defines the format string "E", which represents the scientific format for quantities.
    ///     It is primarily used to display quantities in exponential notation, providing a concise representation
    ///     of very large or very small values.
    /// </remarks>
    public static string ScientificFormatSpecifier = "E";

    /// <summary>
    ///     The default format specifier used for fixed-point formatting of quantities.
    /// </summary>
    /// <remarks>
    ///     This field defines the format string "F", which represents the fixed-point format for quantities.
    ///     It is primarily used to display quantities with a fixed number of decimal places, ensuring precision
    ///     and consistency in numerical representation.
    /// </remarks>
    public static string FixedPointFormatSpecifier = "F";

    /// <summary>
    ///     The default format specifier used for fixed-point formatting of quantities.
    /// </summary>
    /// <remarks>
    ///     This field defines the format string "F", which represents the fixed-point format for quantities.
    ///     It is primarily used to display quantities with a fixed number of decimal places, ensuring precision
    ///     and consistency in numerical representation.
    /// </remarks>
    /// <summary>
    ///     The default format specifier used for numeric formatting of quantities.
    /// </summary>
    /// <remarks>
    ///     This field defines the format string "N", which represents the numeric format for quantities.
    ///     It is used to display quantities with a standard numeric representation, including grouping
    ///     separators and a configurable number of decimal places.
    /// </remarks>
    public static string NumberFormatSpecifier = "N";

    /// <summary>
    ///     Specifies the format string used to represent a quantity in a short format.
    /// </summary>
    /// <remarks>
    ///     The short format specifier is typically used to produce a concise representation
    ///     of a quantity, often including only the numerical value and a minimal unit abbreviation.
    /// </remarks>
    public static string ShortFormatSpecifier = "S";
}
