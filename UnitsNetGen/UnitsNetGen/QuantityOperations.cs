// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Globalization;

namespace UnitsNetGen;

/// <summary>Shared conversion, parsing, and formatting behavior for generated quantities.</summary>
public static class QuantityOperations
{
    public static double Convert<TUnit>(double value, TUnit fromUnit, TUnit toUnit, IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        _ = GetUnit(fromUnit, metadata);
        _ = GetUnit(toUnit, metadata);
        return metadata.FromBase(metadata.ToBase(value, fromUnit), toUnit);
    }

    public static bool TryParse<TUnit>(
        string? text,
        IFormatProvider? formatProvider,
        IQuantityMetadata<TUnit> metadata,
        out double value,
        out TUnit unit)
        where TUnit : struct, Enum
    {
        value = default;
        unit = metadata.BaseUnit;

        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        string trimmed = text!.Trim();
        var culture = formatProvider as CultureInfo ?? CultureInfo.CurrentCulture;
        foreach (UnitInfo<TUnit> candidate in metadata.Units)
        {
            IEnumerable<string> suffixes = candidate.GetAbbreviations(culture)
                .Concat(new[] { candidate.SingularName, candidate.PluralName })
                .OrderByDescending(suffix => suffix.Length);
            foreach (string suffix in suffixes)
            {
                if (TryReadValue(trimmed, suffix, formatProvider, out value))
                {
                    unit = candidate.Unit;
                    return true;
                }
            }
        }

        return false;
    }

    public static string Format<TUnit>(
        double value,
        TUnit unit,
        string? format,
        IFormatProvider? formatProvider,
        IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        UnitInfo<TUnit> info = GetUnit(unit, metadata);
        var culture = formatProvider as CultureInfo ?? CultureInfo.CurrentCulture;
        return $"{value.ToString(format, formatProvider ?? culture)} {info.GetDefaultAbbreviation(culture)}".TrimEnd();
    }

    public static double GetBaseValue<TUnit>(double value, TUnit unit, IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        _ = GetUnit(unit, metadata);
        return metadata.ToBase(value, unit);
    }

    private static UnitInfo<TUnit> GetUnit<TUnit>(TUnit unit, IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        foreach (UnitInfo<TUnit> candidate in metadata.Units)
        {
            if (EqualityComparer<TUnit>.Default.Equals(candidate.Unit, unit))
            {
                return candidate;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(unit), unit, $"Unit is not generated for {metadata.Name}.");
    }

    private static bool TryReadValue(string text, string suffix, IFormatProvider? formatProvider, out double value)
    {
        value = default;
        if (!text.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        string number = text.Substring(0, text.Length - suffix.Length).TrimEnd();
        if (number.Length == 0)
        {
            return false;
        }

        const NumberStyles styles = NumberStyles.Float | NumberStyles.AllowThousands;
        if (double.TryParse(number, styles, formatProvider ?? CultureInfo.CurrentCulture, out value))
        {
            return true;
        }

        return formatProvider is null && double.TryParse(number, styles, CultureInfo.InvariantCulture, out value);
    }
}
