// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using System.IO;

namespace UnitsNet.Tests;

/// <summary>
///     Checks the unit definitions in Common/UnitDefinitions for mistakes that conversion tests don't catch: base units
///     that disagree with the conversion, and abbreviations that make parsing ambiguous.
/// </summary>
/// <remarks>
///     Each test has a list of known violations, so that the tests catch new mistakes while existing ones are fixed
///     separately. Remove an entry when fixing it.
/// </remarks>
public class UnitDefinitionsTests
{
    /// <summary>
    ///     Units whose <see cref="UnitInfo.BaseUnits" /> don't give the unit's conversion factor, as "Quantity.Unit".
    /// </summary>
    /// <remarks>
    ///     The conversions of these units are correct; their base units are wrong. Prefixed units inherit the base units of
    ///     the unit they are prefixed from.
    /// </remarks>
    private static readonly HashSet<string> KnownWrongBaseUnits =
    [
        // Knot per second is nautical mile per hour per second, which has no single time unit.
        "Acceleration.KnotPerMinute", "Acceleration.KnotPerSecond",
        // Pound per square foot, not per thousand square feet.
        "AreaDensity.PoundPerThousandSquareFeet",
        // Volt per second is kg·m²·s⁻⁴·A⁻¹, so a different time unit changes the factor by its fourth power.
        "ElectricPotentialChangeRate.VoltPerHour", "ElectricPotentialChangeRate.KilovoltPerHour", "ElectricPotentialChangeRate.MegavoltPerHour",
        "ElectricPotentialChangeRate.MicrovoltPerHour", "ElectricPotentialChangeRate.MillivoltPerHour",
        "ElectricPotentialChangeRate.VoltPerMinute", "ElectricPotentialChangeRate.KilovoltPerMinute", "ElectricPotentialChangeRate.MegavoltPerMinute",
        "ElectricPotentialChangeRate.MicrovoltPerMinute", "ElectricPotentialChangeRate.MillivoltPerMinute",
        "ElectricPotentialChangeRate.VoltPerMicrosecond", "ElectricPotentialChangeRate.KilovoltPerMicrosecond",
        "ElectricPotentialChangeRate.MegavoltPerMicrosecond", "ElectricPotentialChangeRate.MicrovoltPerMicrosecond",
        "ElectricPotentialChangeRate.MillivoltPerMicrosecond",
        // Pascal second per cubic meter is kg·m⁻⁴·s⁻¹, so these base units don't express minutes, liters or milliliters.
        "FluidResistance.PascalMinutePerCubicMeter", "FluidResistance.PascalMinutePerLiter", "FluidResistance.PascalSecondPerMilliliter",
        // Watt per square meter is kg·s⁻³, so these base units don't express square millimeters.
        "HeatFlux.WattPerSquareMillimeter", "HeatFlux.CentiwattPerSquareMillimeter", "HeatFlux.DeciwattPerSquareMillimeter",
        "HeatFlux.MicrowattPerSquareMillimeter", "HeatFlux.MilliwattPerSquareMillimeter", "HeatFlux.NanowattPerSquareMillimeter",
        // Pascal per second is kg·m⁻¹·s⁻³, so a minute changes the factor by its cube, and pound-force isn't pound.
        "PressureChangeRate.PascalPerMinute", "PressureChangeRate.KilopascalPerMinute", "PressureChangeRate.MegapascalPerMinute",
        "PressureChangeRate.PoundForcePerSquareInchPerSecond", "PressureChangeRate.KilopoundForcePerSquareInchPerSecond",
        "PressureChangeRate.MegapoundForcePerSquareInchPerSecond", "PressureChangeRate.PoundForcePerSquareInchPerMinute",
        "PressureChangeRate.KilopoundForcePerSquareInchPerMinute", "PressureChangeRate.MegapoundForcePerSquareInchPerMinute",
        // The roentgen is 2.58e-4 C/kg, not 1 C/kg.
        "RadiationExposure.Roentgen", "RadiationExposure.Microroentgen", "RadiationExposure.Milliroentgen",
        // The curie is 3.7e10 Bq and the rutherford 1e6 Bq, not 1 per second.
        "Radioactivity.Curie", "Radioactivity.Kilocurie", "Radioactivity.Megacurie", "Radioactivity.Gigacurie", "Radioactivity.Teracurie",
        "Radioactivity.Rutherford", "Radioactivity.Kilorutherford", "Radioactivity.Megarutherford", "Radioactivity.Gigarutherford",
        "Radioactivity.Terarutherford",
        // Square decimeter is 1e-2 m², but a liter per meter is 1e-3 m².
        "VolumePerLength.LiterPerMeter"
    ];

    /// <summary>
    ///     Abbreviations shared by several units of the same quantity, as "Quantity abbreviation".
    /// </summary>
    private static readonly HashSet<string> KnownAmbiguousAbbreviations =
    [
        // The DTP and printer's point and pica are both commonly written this way. UnitParserTests covers the ambiguity.
        "Length pt", "Length pica",
        // The same unit under two names.
        "Force кгс",
        // The long (UK) and short (US) hundredweight are both written cwt.
        "Mass cwt",
        // Mistranslations: 英亩 is acre (hectare is 公顷), 纳米 is nanometer (nautical mile is 海里), and мил is mil.
        "Area 英亩", "Length 纳米", "Length мил"
    ];

    /// <summary>
    ///     Abbreviations with the Greek small letter mu (U+03BC) instead of the micro sign (U+00B5), as "Quantity.Unit".
    /// </summary>
    private static readonly HashSet<string> KnownGreekMuAbbreviations =
    [
        "DoseAreaProduct.GraySquareMicrometer", "DoseAreaProduct.CentigraySquareMicrometer", "DoseAreaProduct.DecigraySquareMicrometer",
        "DoseAreaProduct.MicrograySquareMicrometer", "DoseAreaProduct.MilligraySquareMicrometer",
        "ElectricCurrentGradient.AmperePerMicrosecond",
        "ElectricPotentialChangeRate.VoltPerMicrosecond", "ElectricPotentialChangeRate.KilovoltPerMicrosecond",
        "ElectricPotentialChangeRate.MegavoltPerMicrosecond", "ElectricPotentialChangeRate.MicrovoltPerMicrosecond",
        "ElectricPotentialChangeRate.MillivoltPerMicrosecond",
        "MassConcentration.GramPerMicroliter", "MassConcentration.CentigramPerMicroliter", "MassConcentration.DecigramPerMicroliter",
        "MassConcentration.MicrogramPerMicroliter", "MassConcentration.MilligramPerMicroliter", "MassConcentration.NanogramPerMicroliter",
        "MassConcentration.PicogramPerMicroliter"
    ];

    public static IEnumerable<object[]> QuantityNames => Quantity.Infos.Select(info => new object[] { info.Name });

    [Theory]
    [MemberData(nameof(QuantityNames))]
    public void BaseUnits_GiveTheUnitConversionFactor(string quantityName)
    {
        List<string> mismatches = BaseUnitsMismatches(Quantity.ByName[quantityName])
            .Where(mismatch => !KnownWrongBaseUnits.Contains(mismatch.Key))
            .Select(mismatch => mismatch.Message)
            .ToList();

        Assert.True(mismatches.Count == 0, string.Join(Environment.NewLine, mismatches));
    }

    [Theory]
    [MemberData(nameof(QuantityNames))]
    public void Abbreviations_AreUniqueWithinQuantity(string quantityName)
    {
        List<string> duplicates = AmbiguousAbbreviations(Quantity.ByName[quantityName])
            .Where(duplicate => !KnownAmbiguousAbbreviations.Contains(duplicate.Key))
            .Select(duplicate => duplicate.Message)
            .ToList();

        Assert.True(duplicates.Count == 0, "Abbreviations shared by several units, which makes parsing them ambiguous:" + Environment.NewLine +
                                           string.Join(Environment.NewLine, duplicates));
    }

    [Fact]
    public void Abbreviations_UseMicroSignForMicroPrefix()
    {
        List<string> abbreviations = GreekMuAbbreviations()
            .Where(abbreviation => !KnownGreekMuAbbreviations.Contains(abbreviation.Key))
            .Select(abbreviation => abbreviation.Message)
            .ToList();

        Assert.True(abbreviations.Count == 0, "Abbreviations with the Greek mu instead of the micro sign, which parsing doesn't treat the same:" +
                                              Environment.NewLine + string.Join(Environment.NewLine, abbreviations));
    }

    [Fact]
    public void AbbreviationCultures_IncludeSatelliteAssemblies()
    {
        // Otherwise the abbreviation tests would silently only check en-US.
        Assert.Contains(AbbreviationCultures, culture => culture.Name == "ru-RU");
    }

    [Fact]
    public void KnownViolations_AreStillViolations()
    {
        // Keeps the lists of known violations from going stale: remove an entry from its list when fixing it.
        var violations = new HashSet<string>(Quantity.Infos.SelectMany(BaseUnitsMismatches).Select(mismatch => mismatch.Key));
        violations.UnionWith(Quantity.Infos.SelectMany(AmbiguousAbbreviations).Select(duplicate => duplicate.Key));
        violations.UnionWith(GreekMuAbbreviations().Select(abbreviation => abbreviation.Key));

        string[] fixedViolations = KnownWrongBaseUnits.Concat(KnownAmbiguousAbbreviations).Concat(KnownGreekMuAbbreviations)
            .Where(known => !violations.Contains(known))
            .ToArray();

        Assert.True(fixedViolations.Length == 0, "No longer violations, remove them from the lists of known violations: " + string.Join(", ", fixedViolations));
    }

    /// <summary>
    ///     Units whose <see cref="UnitInfo.BaseUnits" /> give a different factor than their conversion, keyed by "Quantity.Unit".
    /// </summary>
    private static IEnumerable<(string Key, string Message)> BaseUnitsMismatches(QuantityInfo quantityInfo)
    {
        BaseDimensions dimensions = quantityInfo.BaseDimensions;

        // Base units that don't cover the quantity's dimensions have no comparable factor, so those units are skipped.
        UnitInfo[] unitsWithBaseUnits = quantityInfo.UnitInfos
            .Where(unit => unit.BaseUnits != BaseUnits.Undefined && CoversDimensions(unit.BaseUnits, dimensions) && IsLinear(unit))
            .ToArray();

        // Compare the units with each other, relative to the one made of SI base units if there is one. A quantity's
        // base unit isn't necessarily made of SI base units, so the factors are only meaningful relative to each other.
        UnitInfo? reference = unitsWithBaseUnits.FirstOrDefault(unit => SiFactor(unit.BaseUnits, dimensions) == QuantityValue.One)
                              ?? unitsWithBaseUnits.FirstOrDefault();
        if (reference is null) yield break;

        QuantityValue referenceRatio = Factor(reference) / SiFactor(reference.BaseUnits, dimensions);
        foreach (UnitInfo unit in unitsWithBaseUnits)
        {
            QuantityValue expectedFactor = SiFactor(unit.BaseUnits, dimensions) * referenceRatio;
            QuantityValue actualFactor = Factor(unit);
            if (!IsClose(actualFactor, expectedFactor))
            {
                yield return ($"{quantityInfo.Name}.{unit.Name}",
                    $"{quantityInfo.Name}.{unit.Name}: BaseUnits {unit.BaseUnits} give {expectedFactor.ToDouble():G6} {quantityInfo.BaseUnitInfo.Name}, " +
                    $"but its conversion gives {actualFactor.ToDouble():G6} (compared to {reference.Name}).");
            }
        }
    }

    /// <summary>
    ///     Abbreviations of several units of the quantity in the same culture, keyed by "Quantity abbreviation".
    /// </summary>
    private static IEnumerable<(string Key, string Message)> AmbiguousAbbreviations(QuantityInfo quantityInfo)
    {
        return
            from culture in AbbreviationCultures
            from duplicate in quantityInfo.UnitInfos
                .SelectMany(unit => UnitAbbreviationsCache.Default.GetUnitAbbreviations(unit, culture).Distinct().Select(abbreviation => (unit, abbreviation)))
                .GroupBy(x => x.abbreviation)
                .Where(units => units.Count() > 1)
            select ($"{quantityInfo.Name} {duplicate.Key}",
                $"{quantityInfo.Name} {culture.Name} \"{duplicate.Key}\": {string.Join(", ", duplicate.Select(x => x.unit.Name))}");
    }

    /// <summary>
    ///     Abbreviations with the Greek small letter mu instead of the micro sign, keyed by "Quantity.Unit".
    /// </summary>
    private static IEnumerable<(string Key, string Message)> GreekMuAbbreviations()
    {
        // Prefixed units are generated with the micro sign (U+00B5), and parsing doesn't treat the Greek mu as the same.
        const string greekMu = "\u03BC";
        return
            from quantityInfo in Quantity.Infos
            from unit in quantityInfo.UnitInfos
            from culture in AbbreviationCultures
            from abbreviation in UnitAbbreviationsCache.Default.GetUnitAbbreviations(unit, culture)
            where abbreviation.Contains(greekMu)
            select ($"{quantityInfo.Name}.{unit.Name}", $"{quantityInfo.Name}.{unit.Name} {culture.Name} \"{abbreviation}\"");
    }

    /// <summary>
    ///     The cultures with abbreviations: the neutral resources (en-US) and each satellite assembly.
    /// </summary>
    private static IEnumerable<CultureInfo> AbbreviationCultures
    {
        get
        {
            yield return CultureInfo.GetCultureInfo("en-US");
            // The test output directory, rather than the assembly location, which test runners on .NET Framework can shadow copy
            // without the satellite assemblies.
            foreach (string directory in Directory.GetDirectories(AppContext.BaseDirectory).OrderBy(directory => directory, StringComparer.Ordinal))
            {
                if (File.Exists(Path.Combine(directory, "UnitsNet.resources.dll")))
                {
                    yield return CultureInfo.GetCultureInfo(Path.GetFileName(directory));
                }
            }
        }
    }

    private static bool CoversDimensions(BaseUnits baseUnits, BaseDimensions dimensions)
    {
        return (dimensions.Length != 0) == baseUnits.Length.HasValue &&
               (dimensions.Mass != 0) == baseUnits.Mass.HasValue &&
               (dimensions.Time != 0) == baseUnits.Time.HasValue &&
               (dimensions.Current != 0) == baseUnits.Current.HasValue &&
               (dimensions.Temperature != 0) == baseUnits.Temperature.HasValue &&
               (dimensions.Amount != 0) == baseUnits.Amount.HasValue &&
               (dimensions.LuminousIntensity != 0) == baseUnits.LuminousIntensity.HasValue;
    }

    /// <summary>
    ///     Whether the unit converts to the base unit by a factor, possibly with an offset (such as degrees Celsius).
    /// </summary>
    private static bool IsLinear(UnitInfo unit)
    {
        QuantityValue zero = unit.ConversionToBase.Evaluate(0);
        return unit.ConversionToBase.Evaluate(2) - zero == 2 * (unit.ConversionToBase.Evaluate(1) - zero);
    }

    /// <summary>
    ///     The size of the unit in the quantity's base unit, ignoring any offset.
    /// </summary>
    private static QuantityValue Factor(UnitInfo unit)
    {
        return unit.ConversionToBase.Evaluate(1) - unit.ConversionToBase.Evaluate(0);
    }

    /// <summary>
    ///     The size of a unit made of <paramref name="baseUnits" />, in the SI unit made of SI base units.
    /// </summary>
    private static QuantityValue SiFactor(BaseUnits baseUnits, BaseDimensions dimensions)
    {
        return Power(baseUnits.Length, dimensions.Length) *
               Power(baseUnits.Mass, dimensions.Mass) *
               Power(baseUnits.Time, dimensions.Time) *
               Power(baseUnits.Current, dimensions.Current) *
               Power(baseUnits.Temperature, dimensions.Temperature) *
               Power(baseUnits.Amount, dimensions.Amount) *
               Power(baseUnits.LuminousIntensity, dimensions.LuminousIntensity);

        // The base unit of each of these quantities is the SI base unit, such as the meter for Length.
        static QuantityValue Power<TUnit>(TUnit? unit, int exponent) where TUnit : struct, Enum
        {
            if (unit is null || exponent == 0) return QuantityValue.One;
            QuantityValue factor = Factor(Quantity.GetUnitInfo(UnitKey.ForUnit(unit.Value)));
            QuantityValue result = QuantityValue.One;
            for (var i = 0; i < Math.Abs(exponent); i++)
            {
                result = exponent > 0 ? result * factor : result / factor;
            }

            return result;
        }
    }

    private static bool IsClose(QuantityValue actual, QuantityValue expected)
    {
        return Math.Abs((actual / expected).ToDouble() - 1) < 1e-12;
    }
}
