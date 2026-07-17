// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Globalization;

namespace UnitsNetGen;

/// <summary>Shared conversion, parsing, and formatting behavior for generated quantities.</summary>
public static class QuantityOperations
{
    public static double Convert<TUnit>(double value, TUnit fromUnit, TUnit toUnit, IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        UnitInfo<TUnit> from = GetUnit(fromUnit, metadata);
        UnitInfo<TUnit> to = GetUnit(toUnit, metadata);
        return to.FromBase(from.ToBase(value));
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

        string trimmed = text.Trim();
        foreach (UnitInfo<TUnit> candidate in metadata.Units.OrderByDescending(x => x.Abbreviation.Length))
        {
            if (TryReadValue(trimmed, candidate.Abbreviation, formatProvider, out value) ||
                TryReadValue(trimmed, candidate.SingularName, formatProvider, out value) ||
                TryReadValue(trimmed, candidate.PluralName, formatProvider, out value))
            {
                unit = candidate.Unit;
                return true;
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
        return $"{value.ToString(format, formatProvider ?? CultureInfo.CurrentCulture)} {info.Abbreviation}";
    }

    public static double GetBaseValue<TUnit>(double value, TUnit unit, IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
        => GetUnit(unit, metadata).ToBase(value);

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
