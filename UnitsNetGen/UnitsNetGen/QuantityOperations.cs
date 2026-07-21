// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Concurrent;
using System.Globalization;

namespace UnitsNetGen;

/// <summary>Shared conversion, parsing, and formatting behavior for generated quantities.</summary>
public static class QuantityOperations
{
    /// <summary>Converts a value between two generated units.</summary>
    public static double Convert<TUnit>(double value, TUnit fromUnit, TUnit toUnit, IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        _ = GetUnitInfo(fromUnit, metadata);
        _ = GetUnitInfo(toUnit, metadata);
        return metadata.FromBase(metadata.ToBase(value, fromUnit), toUnit);
    }

    /// <summary>Attempts to parse a numeric value and generated unit name or abbreviation.</summary>
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
        foreach (SuffixCandidate<TUnit> candidate in SuffixCache<TUnit>.Get(metadata, culture))
        {
            if (TryReadValue(
                    trimmed,
                    candidate.Suffix,
                    candidate.CaseSensitive,
                    formatProvider,
                    out value))
            {
                unit = candidate.Unit;
                return true;
            }
        }

        return GetUnitInfo(metadata.BaseUnit, metadata).GetAbbreviations(culture).Contains(string.Empty) &&
               TryReadValue(trimmed, string.Empty, true, formatProvider, out value);
    }

    /// <summary>Formats a value followed by the localized abbreviation for its unit.</summary>
    public static string Format<TUnit>(
        double value,
        TUnit unit,
        string? format,
        IFormatProvider? formatProvider,
        IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        UnitInfo<TUnit> info = GetUnitInfo(unit, metadata);
        var culture = formatProvider as CultureInfo ?? CultureInfo.CurrentCulture;
        return $"{value.ToString(format, formatProvider ?? culture)} {info.GetDefaultAbbreviation(culture)}".TrimEnd();
    }

    /// <summary>Converts a value to the quantity's base unit.</summary>
    public static double GetBaseValue<TUnit>(double value, TUnit unit, IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        _ = GetUnitInfo(unit, metadata);
        return metadata.ToBase(value, unit);
    }

    /// <summary>Gets metadata for a generated unit.</summary>
    public static UnitInfo<TUnit> GetUnitInfo<TUnit>(TUnit unit, IQuantityMetadata<TUnit> metadata)
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

    /// <summary>Gets the first selected unit compatible with an immutable unit-system policy.</summary>
    public static TUnit GetUnit<TUnit>(UnitSystem unitSystem, IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(unitSystem);
        if (TryGetUnit(unitSystem, metadata, out TUnit unit))
        {
            return unit;
        }

        throw new ArgumentException(
            $"No selected unit for {metadata.Name} is compatible with {unitSystem.BaseUnits}.",
            nameof(unitSystem));
    }

    /// <summary>Attempts to get the first selected unit compatible with an immutable unit-system policy.</summary>
    public static bool TryGetUnit<TUnit>(
        UnitSystem? unitSystem,
        IQuantityMetadata<TUnit> metadata,
        out TUnit unit)
        where TUnit : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(metadata);
        unit = metadata.BaseUnit;
        if (unitSystem is null)
        {
            return false;
        }

        if (metadata.BaseDimensions.IsDimensionless())
        {
            return true;
        }

        foreach (UnitInfo<TUnit> candidate in metadata.Units.OrderBy(
                     candidate => candidate.SingularName,
                     StringComparer.Ordinal))
        {
            if (candidate.BaseUnits.IsSubsetOf(unitSystem.BaseUnits))
            {
                unit = candidate.Unit;
                return true;
            }
        }

        return false;
    }

    /// <summary>Gets the preferred localized abbreviation for a generated unit.</summary>
    public static string GetAbbreviation<TUnit>(
        TUnit unit,
        IFormatProvider? formatProvider,
        IQuantityMetadata<TUnit> metadata)
        where TUnit : struct, Enum =>
        GetUnitInfo(unit, metadata).GetDefaultAbbreviation(formatProvider as CultureInfo);

    /// <summary>Attempts to parse a generated unit name or localized abbreviation.</summary>
    public static bool TryParseUnit<TUnit>(
        string? text,
        IFormatProvider? formatProvider,
        IQuantityMetadata<TUnit> metadata,
        out TUnit unit)
        where TUnit : struct, Enum
    {
        unit = metadata.BaseUnit;
        if (text is null)
        {
            return false;
        }

        string value = text.Trim();
        var culture = formatProvider as CultureInfo ?? CultureInfo.CurrentCulture;
        if (value.Length == 0 &&
            GetUnitInfo(metadata.BaseUnit, metadata).GetAbbreviations(culture).Contains(string.Empty))
        {
            return true;
        }

        foreach (SuffixCandidate<TUnit> candidate in SuffixCache<TUnit>.Get(metadata, culture))
        {
            StringComparison comparison = candidate.CaseSensitive
                ? StringComparison.Ordinal
                : StringComparison.OrdinalIgnoreCase;
            if (string.Equals(value, candidate.Suffix, comparison))
            {
                unit = candidate.Unit;
                return true;
            }
        }

        return false;
    }

    private static bool TryReadValue(
        string text,
        string suffix,
        bool caseSensitive,
        IFormatProvider? formatProvider,
        out double value)
    {
        value = default;
        StringComparison comparison = caseSensitive
            ? StringComparison.Ordinal
            : StringComparison.OrdinalIgnoreCase;
        if (!text.EndsWith(suffix, comparison))
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

    private sealed class SuffixCandidate<TUnit>
        where TUnit : struct, Enum
    {
        public SuffixCandidate(string suffix, TUnit unit, bool caseSensitive)
        {
            Suffix = suffix;
            Unit = unit;
            CaseSensitive = caseSensitive;
        }

        public string Suffix { get; }

        public TUnit Unit { get; }

        public bool CaseSensitive { get; }
    }

    private static class SuffixCache<TUnit>
        where TUnit : struct, Enum
    {
        private static readonly ConcurrentDictionary<(IQuantityMetadata<TUnit>, string), SuffixCandidate<TUnit>[]> Cache = new();

        public static IReadOnlyList<SuffixCandidate<TUnit>> Get(
            IQuantityMetadata<TUnit> metadata,
            CultureInfo culture) =>
            Cache.GetOrAdd((metadata, culture.Name), key => Create(key.Item1, culture));

        private static SuffixCandidate<TUnit>[] Create(
            IQuantityMetadata<TUnit> metadata,
            CultureInfo culture) =>
            metadata.Units
                .SelectMany(unit =>
                    unit.GetAbbreviations(culture)
                        .Select(abbreviation => new SuffixCandidate<TUnit>(abbreviation, unit.Unit, true))
                        .Concat(new[]
                        {
                            new SuffixCandidate<TUnit>(unit.SingularName, unit.Unit, false),
                            new SuffixCandidate<TUnit>(unit.PluralName, unit.Unit, false),
                        }))
                .Where(candidate => candidate.Suffix.Length > 0)
                .OrderByDescending(candidate => candidate.Suffix.Length)
                .ThenBy(candidate => candidate.Suffix, StringComparer.Ordinal)
                .ToArray();
    }
}
