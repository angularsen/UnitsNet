// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNetGen.Generator.Tests;

public sealed class AugmentationGeneratorTests
{
    [Fact]
    public void AreaAndLengthSelection_EmitsCircleAugmentation()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.Area>,
                IInclude<UnitsNetGen.BuiltIns.Length>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string areaSource = Assert.Single(
            run.Result.Results
                .SelectMany(result => result.GeneratedSources),
            source => source.HintName.EndsWith("_Area.g.cs", StringComparison.Ordinal))
            .SourceText
            .ToString();
        Assert.Contains("FromCircleDiameter(global::UnitsNetGen.Length diameter)", areaSource, StringComparison.Ordinal);
        Assert.Contains("FromCircleRadius(global::UnitsNetGen.Length radius)", areaSource, StringComparison.Ordinal);
    }

    [Fact]
    public void AreaWithoutLengthSelection_OmitsDependentAugmentation()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNetGen.BuiltIns.Area>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(
            run.Result.Results.SelectMany(result => result.GeneratedSources),
            source => source.SourceText.ToString().Contains("FromCircleRadius", StringComparison.Ordinal));
    }

    [Fact]
    public void MechanicalSelections_EmitCompatibleAugmentations()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.Acceleration>,
                IInclude<UnitsNetGen.BuiltIns.Area>,
                IInclude<UnitsNetGen.BuiltIns.Force>,
                IInclude<UnitsNetGen.BuiltIns.Mass>,
                IInclude<UnitsNetGen.BuiltIns.MassFraction>,
                IInclude<UnitsNetGen.BuiltIns.Pressure>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = string.Join(
            Environment.NewLine,
            run.Result.Results.SelectMany(result => result.GeneratedSources).Select(source => source.SourceText));
        Assert.Contains("GetComponentMass(global::UnitsNetGen.Mass totalMass)", generated, StringComparison.Ordinal);
        Assert.Contains("FromPressureByArea(global::UnitsNetGen.Pressure pressure", generated, StringComparison.Ordinal);
        Assert.Contains("FromMassByAcceleration(global::UnitsNetGen.Mass mass", generated, StringComparison.Ordinal);
        Assert.Contains("FromGravitationalForce(global::UnitsNetGen.Force force)", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void ChemistrySelections_EmitCompatibleAugmentations()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.AmountOfSubstance>,
                IInclude<UnitsNetGen.BuiltIns.Density>,
                IInclude<UnitsNetGen.BuiltIns.Mass>,
                IInclude<UnitsNetGen.BuiltIns.MassConcentration>,
                IInclude<UnitsNetGen.BuiltIns.Molarity>,
                IInclude<UnitsNetGen.BuiltIns.MolarMass>,
                IInclude<UnitsNetGen.BuiltIns.Volume>,
                IInclude<UnitsNetGen.BuiltIns.VolumeConcentration>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = string.Join(
            Environment.NewLine,
            run.Result.Results.SelectMany(result => result.GeneratedSources).Select(source => source.SourceText));
        Assert.Contains("double AvogadroConstant", generated, StringComparison.Ordinal);
        Assert.Contains("FromMass(global::UnitsNetGen.Mass mass", generated, StringComparison.Ordinal);
        Assert.Contains("ToMolarity(global::UnitsNetGen.MolarMass molecularWeight)", generated, StringComparison.Ordinal);
        Assert.Contains("ToVolumeConcentration(global::UnitsNetGen.Density componentDensity", generated, StringComparison.Ordinal);
        Assert.Contains("FromVolumes(global::UnitsNetGen.Volume componentVolume", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void EnergySelections_EmitCompatibleAugmentations()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.ElectricApparentPower>,
                IInclude<UnitsNetGen.BuiltIns.ElectricCurrent>,
                IInclude<UnitsNetGen.BuiltIns.ElectricPotential>,
                IInclude<UnitsNetGen.BuiltIns.Energy>,
                IInclude<UnitsNetGen.BuiltIns.EnergyDensity>,
                IInclude<UnitsNetGen.BuiltIns.Ratio>,
                IInclude<UnitsNetGen.BuiltIns.Volume>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = string.Join(
            Environment.NewLine,
            run.Result.Results.SelectMany(result => result.GeneratedSources).Select(source => source.SourceText));
        Assert.Contains("ElectricCurrent operator /(ElectricApparentPower power", generated, StringComparison.Ordinal);
        Assert.Contains("ElectricPotential operator /(ElectricApparentPower power", generated, StringComparison.Ordinal);
        Assert.Contains("CombustionEnergy(EnergyDensity energyDensity", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void LogarithmicSelections_EmitCompatibleAugmentations()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.AmplitudeRatio>,
                IInclude<UnitsNetGen.BuiltIns.ElectricPotential>,
                IInclude<UnitsNetGen.BuiltIns.ElectricResistance>,
                IInclude<UnitsNetGen.BuiltIns.Level>,
                IInclude<UnitsNetGen.BuiltIns.Power>,
                IInclude<UnitsNetGen.BuiltIns.PowerRatio>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = string.Join(
            Environment.NewLine,
            run.Result.Results.SelectMany(result => result.GeneratedSources).Select(source => source.SourceText));
        Assert.Contains("AmplitudeRatio(global::UnitsNetGen.ElectricPotential voltage)", generated, StringComparison.Ordinal);
        Assert.Contains("ToPowerRatio(global::UnitsNetGen.ElectricResistance impedance)", generated, StringComparison.Ordinal);
        Assert.Contains("Level(double quantity, double reference)", generated, StringComparison.Ordinal);
        Assert.Contains("PowerRatio(global::UnitsNetGen.Power power)", generated, StringComparison.Ordinal);
        Assert.Contains("ToAmplitudeRatio(global::UnitsNetGen.ElectricResistance impedance)", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void CompanionSelections_EmitFactoriesAndWrappers()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.Length>,
                IInclude<UnitsNetGen.BuiltIns.Mass>,
                IInclude<UnitsNetGen.BuiltIns.Pressure>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = string.Join(
            Environment.NewLine,
            run.Result.Results.SelectMany(result => result.GeneratedSources).Select(source => source.SourceText));
        Assert.Contains("FromFeetInches(double feet, double inches)", generated, StringComparison.Ordinal);
        Assert.Contains("FromStonePounds(double stone, double pounds)", generated, StringComparison.Ordinal);
        Assert.Contains("sealed class FeetInches", generated, StringComparison.Ordinal);
        Assert.Contains("sealed class StonePounds", generated, StringComparison.Ordinal);
        Assert.Contains("struct ReferencePressure", generated, StringComparison.Ordinal);
        Assert.Contains("enum PressureReference", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void FilteredCompoundUnits_OmitFactoriesThatReintroduceExcludedUnits()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitSet("regex:^Meter$")]
            internal interface MeterOnly;

            [UnitSet("regex:^Kilogram$")]
            internal interface KilogramOnly;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.Length, MeterOnly>,
                IInclude<UnitsNetGen.BuiltIns.Mass, KilogramOnly>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(
            run.Result.Results.SelectMany(result => result.GeneratedSources),
            source => source.SourceText.ToString().Contains("FromFeetInches", StringComparison.Ordinal));
        Assert.DoesNotContain(
            run.Result.Results.SelectMany(result => result.GeneratedSources),
            source => source.SourceText.ToString().Contains("FromStonePounds", StringComparison.Ordinal));
        Assert.DoesNotContain(
            run.Result.Results.SelectMany(result => result.GeneratedSources),
            source => source.SourceText.ToString().Contains("sealed class FeetInches", StringComparison.Ordinal));
        Assert.DoesNotContain(
            run.Result.Results.SelectMany(result => result.GeneratedSources),
            source => source.SourceText.ToString().Contains("sealed class StonePounds", StringComparison.Ordinal));
    }
}
