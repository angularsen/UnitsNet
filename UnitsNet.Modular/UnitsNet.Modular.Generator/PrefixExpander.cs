// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UnitsNet.Modular.Generator;

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

    public static QuantityDefinition Expand(
        QuantityDefinition quantity,
        BaseUnitPrefixCatalog? baseUnitPrefixes = null)
    {
        if (TryExpand(quantity, baseUnitPrefixes, out QuantityDefinition? expanded, out string? error))
        {
            return expanded!;
        }

        throw new InvalidOperationException(error);
    }

    public static bool TryExpand(
        QuantityDefinition quantity,
        BaseUnitPrefixCatalog? baseUnitPrefixes,
        out QuantityDefinition? expanded,
        out string? error)
    {
        var units = new List<UnitDefinition>(quantity.Units);
        foreach (UnitDefinition unit in quantity.Units)
        {
            foreach (string prefixName in unit.Prefixes)
            {
                if (!Prefixes.TryGetValue(prefixName, out PrefixInfo? prefix))
                {
                    expanded = null;
                    error = $"Unknown prefix '{prefixName}' in {quantity.Id}.{unit.SingularName}.";
                    return false;
                }

                string factor = prefix.Factor.ToString("R", CultureInfo.InvariantCulture);
                UnitLocalizationDefinition[] localizations = unit.Localizations.Select(localization =>
                {
                    IReadOnlyList<string> abbreviations = localization.AbbreviationsForPrefixes.TryGetValue(prefixName, out IReadOnlyList<string>? configured)
                        ? configured
                        : localization.Abbreviations.Select(abbreviation => prefix.Symbol + abbreviation).ToArray();
                    return new UnitLocalizationDefinition(localization.Culture, abbreviations);
                }).ToArray();

                BaseUnitsDefinition baseUnits = baseUnitPrefixes is null
                    ? unit.BaseUnits.Rename(
                        unit.SingularName,
                        prefix.Name + LowerFirst(unit.SingularName))
                    : GetPrefixedBaseUnits(
                        quantity.BaseDimensions,
                        unit.BaseUnits,
                        prefixName,
                        baseUnitPrefixes);
                units.Add(new UnitDefinition(
                    prefix.Name + LowerFirst(unit.SingularName),
                    prefix.Name + LowerFirst(unit.PluralName),
                    ConversionExpression.Substitute(
                        unit.FromUnitToBaseExpression,
                        $"x * {factor}"),
                    $"({unit.FromBaseToUnitExpression}) / {factor}",
                    baseUnits,
                    localizations));
            }
        }

        UnitDefinition[] distinct = units
            .GroupBy(unit => unit.SingularName, StringComparer.Ordinal)
            .Select(group => group.Last())
            .ToArray();
        expanded = new QuantityDefinition(
            quantity.Name,
            quantity.TargetNamespace,
            quantity.BaseUnit,
            distinct,
            quantity.SourcePath,
            quantity.IsLogarithmic,
            quantity.LogarithmicScalingFactor,
            quantity.SemanticId,
            quantity.AffineOffsetType,
            quantity.BaseDimensions,
            quantity.Augmentations);
        error = null;
        return true;
    }

    private static string LowerFirst(string value)
        => value.Length == 0 ? value : char.ToLowerInvariant(value[0]) + value.Substring(1);

    private static BaseUnitsDefinition GetPrefixedBaseUnits(
        BaseDimensionsDefinition dimensions,
        BaseUnitsDefinition baseUnits,
        string prefixName,
        BaseUnitPrefixCatalog catalog)
    {
        if (baseUnits.IsUndefined)
        {
            return BaseUnitsDefinition.Undefined;
        }

        int[] exponents =
        {
            dimensions.Length,
            dimensions.Mass,
            dimensions.Time,
            dimensions.Current,
            dimensions.Temperature,
            dimensions.Amount,
            dimensions.LuminousIntensity,
        };
        foreach (int exponent in exponents
                     .Where(value => value != 0)
                     .Distinct()
                     .OrderBy(Math.Abs)
                     .ThenByDescending(value => value))
        {
            if (dimensions.Amount == exponent &&
                catalog.TryApply(baseUnits.Amount, exponent, prefixName, out string? amount))
            {
                return Replace(baseUnits, amount: amount);
            }

            if (dimensions.Current == exponent &&
                catalog.TryApply(baseUnits.Current, exponent, prefixName, out string? current))
            {
                return Replace(baseUnits, current: current);
            }

            if (dimensions.Length == exponent &&
                catalog.TryApply(baseUnits.Length, exponent, prefixName, out string? length))
            {
                return Replace(baseUnits, length: length);
            }

            if (dimensions.LuminousIntensity == exponent &&
                catalog.TryApply(
                    baseUnits.LuminousIntensity,
                    exponent,
                    prefixName,
                    out string? luminousIntensity))
            {
                return Replace(baseUnits, luminousIntensity: luminousIntensity);
            }

            if (dimensions.Mass == exponent &&
                catalog.TryApply(baseUnits.Mass, exponent, prefixName, out string? mass))
            {
                return Replace(baseUnits, mass: mass);
            }

            if (dimensions.Temperature == exponent &&
                catalog.TryApply(
                    baseUnits.Temperature,
                    exponent,
                    prefixName,
                    out string? temperature))
            {
                return Replace(baseUnits, temperature: temperature);
            }

            if (dimensions.Time == exponent &&
                catalog.TryApply(baseUnits.Time, exponent, prefixName, out string? time))
            {
                return Replace(baseUnits, time: time);
            }
        }

        return BaseUnitsDefinition.Undefined;
    }

    private static BaseUnitsDefinition Replace(
        BaseUnitsDefinition source,
        string? length = null,
        string? mass = null,
        string? time = null,
        string? current = null,
        string? temperature = null,
        string? amount = null,
        string? luminousIntensity = null) =>
        new BaseUnitsDefinition(
            length ?? source.Length,
            mass ?? source.Mass,
            time ?? source.Time,
            current ?? source.Current,
            temperature ?? source.Temperature,
            amount ?? source.Amount,
            luminousIntensity ?? source.LuminousIntensity);

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

    internal sealed class BaseUnitPrefixCatalog
    {
        private static readonly IReadOnlyDictionary<string, int> MetricExponents =
            new Dictionary<string, int>(StringComparer.Ordinal)
            {
                ["Femto"] = -15,
                ["Pico"] = -12,
                ["Nano"] = -9,
                ["Micro"] = -6,
                ["Milli"] = -3,
                ["Centi"] = -2,
                ["Deci"] = -1,
                ["Deca"] = 1,
                ["Hecto"] = 2,
                ["Kilo"] = 3,
                ["Mega"] = 6,
                ["Giga"] = 9,
                ["Tera"] = 12,
                ["Peta"] = 15,
                ["Exa"] = 18,
            };

        private readonly IReadOnlyDictionary<string, PrefixScale> _scalesByUnit;
        private readonly IReadOnlyDictionary<PrefixScale, string> _unitsByScale;

        private BaseUnitPrefixCatalog(
            IReadOnlyDictionary<string, PrefixScale> scalesByUnit,
            IReadOnlyDictionary<PrefixScale, string> unitsByScale)
        {
            _scalesByUnit = scalesByUnit;
            _unitsByScale = unitsByScale;
        }

        public static BaseUnitPrefixCatalog Create(IEnumerable<QuantityDefinition> definitions)
        {
            var scalesByUnit = new Dictionary<string, PrefixScale>(StringComparer.Ordinal);
            var unitsByScale = new Dictionary<PrefixScale, string>();
            foreach (QuantityDefinition definition in definitions.Where(IsBaseQuantity))
            {
                var generatedNames = new HashSet<string>(
                    definition.Units
                        .Where(unit => unit.Prefixes.Count > 0)
                        .SelectMany(unit => unit.Prefixes.Select(
                            prefix => prefix + LowerFirst(unit.SingularName))),
                    StringComparer.Ordinal);
                foreach (UnitDefinition unit in definition.Units.Where(
                             unit => !generatedNames.Contains(unit.SingularName)))
                {
                    var unprefixed = new PrefixScale(unit.SingularName, 0);
                    scalesByUnit[unit.SingularName] = unprefixed;
                    unitsByScale[unprefixed] = unit.SingularName;
                    foreach (string prefixName in unit.Prefixes)
                    {
                        if (!MetricExponents.TryGetValue(prefixName, out int exponent))
                        {
                            continue;
                        }

                        string prefixedName = prefixName + LowerFirst(unit.SingularName);
                        var prefixed = new PrefixScale(unit.SingularName, exponent);
                        scalesByUnit[prefixedName] = prefixed;
                        unitsByScale[prefixed] = prefixedName;
                    }
                }
            }

            return new BaseUnitPrefixCatalog(scalesByUnit, unitsByScale);
        }

        public bool TryApply(
            string? unitName,
            int dimensionExponent,
            string prefixName,
            out string? prefixedUnitName)
        {
            if (unitName is not null &&
                dimensionExponent != 0 &&
                MetricExponents.TryGetValue(prefixName, out int prefixExponent) &&
                prefixExponent % dimensionExponent == 0 &&
                _scalesByUnit.TryGetValue(unitName, out PrefixScale current) &&
                _unitsByScale.TryGetValue(
                    new PrefixScale(
                        current.BaseUnit,
                        current.Exponent + (prefixExponent / dimensionExponent)),
                    out string? selected))
            {
                prefixedUnitName = selected;
                return true;
            }

            prefixedUnitName = null;
            return false;
        }

        private static bool IsBaseQuantity(QuantityDefinition definition)
        {
            return definition.SemanticId == "UnitsNet.Length" ||
                   definition.SemanticId == "UnitsNet.Mass" ||
                   definition.SemanticId == "UnitsNet.Duration" ||
                   definition.SemanticId == "UnitsNet.ElectricCurrent" ||
                   definition.SemanticId == "UnitsNet.Temperature" ||
                   definition.SemanticId == "UnitsNet.AmountOfSubstance" ||
                   definition.SemanticId == "UnitsNet.LuminousIntensity";
        }

        private sealed class PrefixScale : IEquatable<PrefixScale>
        {
            public PrefixScale(string baseUnit, int exponent)
            {
                BaseUnit = baseUnit;
                Exponent = exponent;
            }

            public string BaseUnit { get; }

            public int Exponent { get; }

            public bool Equals(PrefixScale? other) =>
                other is not null &&
                Exponent == other.Exponent &&
                string.Equals(BaseUnit, other.BaseUnit, StringComparison.Ordinal);

            public override bool Equals(object? obj) => Equals(obj as PrefixScale);

            public override int GetHashCode()
            {
                unchecked
                {
                    return (StringComparer.Ordinal.GetHashCode(BaseUnit) * 397) ^ Exponent;
                }
            }
        }
    }
}
