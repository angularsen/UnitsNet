// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen;

/// <summary>Localized abbreviations for one generated unit.</summary>
public sealed class UnitLocalization
{
    public UnitLocalization(string culture, params string[] abbreviations)
    {
        Culture = culture;
        Abbreviations = abbreviations;
    }

    public string Culture { get; }

    public IReadOnlyList<string> Abbreviations { get; }
}
