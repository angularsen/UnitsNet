// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UnitsNetGen.Generator;

internal static class PrefixExpander
{
    private static readonly IReadOnlyDictionary<string, PrefixInfo> Prefixes = new Dictionary<string, PrefixInfo>(StringComparer.Ordinal)
    {
        ["Femto"] = new PrefixInfo("Femto", "f", 1e-15),
        ["Pico"] = new PrefixInfo("Pico", "p", 1e-12),
        ["Nano"] = new PrefixInfo("Nano", "n", 1e-9),
        ["Micro"] = new PrefixInfo("Micro", "μ", 1e-6),
        ["Milli"] = new PrefixInfo("Milli", "m", 1e-3),
        ["Centi"] = new PrefixInfo("Centi", "c", 1e-2),
        ["Deci"] = new PrefixInfo("Deci", "d", 1e-1),
        ["Deca"] = new PrefixInfo("Deca", "da", 1e1),
        ["Hecto"] = new PrefixInfo("Hecto", "h", 1e2),
        ["Kilo"] = new PrefixInfo("Kilo", "k", 1e3),
        ["Mega"] = new PrefixInfo("Mega", "M", 1e6),
        ["Giga"] = new PrefixInfo("Giga", "G", 1e9),
        ["Tera"] = new PrefixInfo("Tera", "T", 1e12),
        ["Peta"] = new PrefixInfo("Peta", "P", 1e15),
        ["Exa"] = new PrefixInfo("Exa", "E", 1e18),
        ["Kibi"] = new PrefixInfo("Kibi", "Ki", 1024),
        ["Mebi"] = new PrefixInfo("Mebi", "Mi", 1048576),
        ["Gibi"] = new PrefixInfo("Gibi", "Gi", 1073741824),
        ["Tebi"] = new PrefixInfo("Tebi", "Ti", 1099511627776),
        ["Pebi"] = new PrefixInfo("Pebi", "Pi", 1125899906842624),
        ["Exbi"] = new PrefixInfo("Exbi", "Ei", 1152921504606846976),
    };

    public static QuantityDefinition Expand(QuantityDefinition quantity)
    {
        var units = new List<UnitDefinition>(quantity.Units);
        foreach (UnitDefinition unit in quantity.Units)
        {
            foreach (string prefixName in unit.Prefixes)
            {
                if (!Prefixes.TryGetValue(prefixName, out PrefixInfo? prefix))
                {
                    throw new InvalidOperationException($"Unknown prefix '{prefixName}' in {quantity.Id}.{unit.SingularName}.");
                }

                string factor = prefix.Factor.ToString("R", CultureInfo.InvariantCulture);
                UnitLocalizationDefinition[] localizations = unit.Localizations.Select(localization =>
                {
                    IReadOnlyList<string> abbreviations = localization.AbbreviationsForPrefixes.TryGetValue(prefixName, out IReadOnlyList<string>? configured)
                        ? configured
                        : localization.Abbreviations.Select(abbreviation => prefix.Symbol + abbreviation).ToArray();
                    return new UnitLocalizationDefinition(localization.Culture, abbreviations);
                }).ToArray();

                units.Add(new UnitDefinition(
                    prefix.Name + LowerFirst(unit.SingularName),
                    prefix.Name + LowerFirst(unit.PluralName),
                    $"({unit.FromUnitToBaseExpression}) * {factor}",
                    $"({unit.FromBaseToUnitExpression}) / {factor}",
                    localizations));
            }
        }

        UnitDefinition[] distinct = units
            .GroupBy(unit => unit.SingularName, StringComparer.Ordinal)
            .Select(group => group.First())
            .ToArray();
        return new QuantityDefinition(
            quantity.Name,
            quantity.TargetNamespace,
            quantity.BaseUnit,
            distinct,
            quantity.SourcePath,
            quantity.IsLogarithmic,
            quantity.LogarithmicScalingFactor);
    }

    private static string LowerFirst(string value)
        => value.Length == 0 ? value : char.ToLowerInvariant(value[0]) + value.Substring(1);

    private sealed class PrefixInfo
    {
        public PrefixInfo(string name, string symbol, double factor)
        {
            Name = name;
            Symbol = symbol;
            Factor = factor;
        }

        public string Name { get; }

        public string Symbol { get; }

        public double Factor { get; }
    }
}
