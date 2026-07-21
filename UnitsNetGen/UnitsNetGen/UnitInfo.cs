// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen;

/// <summary>Runtime metadata for one generated unit.</summary>
public sealed class UnitInfo<TUnit>
    where TUnit : struct, Enum
{
    /// <summary>Initializes runtime metadata for a generated unit.</summary>
    public UnitInfo(TUnit unit, string singularName, string pluralName, params UnitLocalization[] localizations)
    {
        Unit = unit;
        SingularName = singularName;
        PluralName = pluralName;
        Localizations = localizations;
    }

    /// <summary>Gets the generated unit enum value.</summary>
    public TUnit Unit { get; }

    /// <summary>Gets the singular English name.</summary>
    public string SingularName { get; }

    /// <summary>Gets the plural English name.</summary>
    public string PluralName { get; }

    /// <summary>Gets the localized abbreviations.</summary>
    public IReadOnlyList<UnitLocalization> Localizations { get; }

    /// <summary>Gets abbreviations using the requested culture and fallback rules.</summary>
    public IReadOnlyList<string> GetAbbreviations(System.Globalization.CultureInfo? culture)
    {
        string cultureName = (culture ?? System.Globalization.CultureInfo.CurrentCulture).Name;
        while (cultureName.Length > 0)
        {
            UnitLocalization? exact = Localizations.FirstOrDefault(localization =>
                string.Equals(localization.Culture, cultureName, StringComparison.OrdinalIgnoreCase));
            if (exact is not null)
            {
                return exact.Abbreviations;
            }

            int separator = cultureName.LastIndexOf('-');
            cultureName = separator < 0 ? string.Empty : cultureName.Substring(0, separator);
        }

        UnitLocalization? english = Localizations.FirstOrDefault(localization =>
            string.Equals(localization.Culture, "en-US", StringComparison.OrdinalIgnoreCase));
        if (english is not null)
        {
            return english.Abbreviations;
        }

        return Localizations.FirstOrDefault()?.Abbreviations ?? Array.Empty<string>();
    }

    /// <summary>Gets the preferred abbreviation using the requested culture and fallback rules.</summary>
    public string GetDefaultAbbreviation(System.Globalization.CultureInfo? culture)
        => GetAbbreviations(culture).FirstOrDefault() ?? string.Empty;
}
