// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen;

/// <summary>Localized abbreviations for one generated unit.</summary>
public sealed class UnitLocalization
{
    /// <summary>Initializes abbreviations for a culture name.</summary>
    public UnitLocalization(string culture, params string[] abbreviations)
    {
        Culture = culture;
        Abbreviations = abbreviations;
    }

    /// <summary>Gets the culture name.</summary>
    public string Culture { get; }

    /// <summary>Gets the accepted abbreviations ordered by preference.</summary>
    public IReadOnlyList<string> Abbreviations { get; }
}
