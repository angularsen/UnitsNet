using System.Globalization;
using Fractions;

namespace CodeGen.Helpers;

/// <summary>
/// Helper methods for parsing Fraction values with culture-invariant formatting.
/// </summary>
internal static class FractionHelper
{
    /// <summary>
    /// Attempts to parse a string representation of a number into a normalized Fraction, using invariant culture.<br />
    /// It supports various number formats including integers, floating point, and scientific notation.
    /// </summary>
    /// <param name="value">The string representation of the number to parse.</param>
    /// <param name="result">When this method returns, contains the Fraction equivalent of the number contained in value, if the conversion succeeded, or default if the conversion failed.</param>
    /// <returns>true if value was converted successfully; otherwise, false.</returns>
    /// <remarks>
    /// The fraction is normalized, e.g. "2/4" is reduced to "1/2".
    /// <br />
    /// This method uses NumberStyles.Number | NumberStyles.Float to support:
    /// - Integers: "42", "-123"
    /// - Floating point: "3.14", "-2.5"
    /// - Scientific notation: "1.5e3", "2.5E-4"
    /// - Leading/trailing whitespace
    ///
    /// All parsing uses InvariantCulture to ensure consistent behavior regardless of system culture settings.
    /// </remarks>
    public static bool TryParseInvariant(string value, out Fraction result)
    {
        return Fraction.TryParse(
            value,
            NumberStyles.Number | NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out result);
    }
}
