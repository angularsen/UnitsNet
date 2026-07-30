// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class AugmentationGeneratorTests
{
    [Fact]
    public void AreaAndLengthSelection_EmitsCircleAugmentation()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.Area>,
                IInclude<UnitsNet.Modular.BuiltIns.Length>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string areaSource = Assert.Single(
            run.Result.Results
                .SelectMany(result => result.GeneratedSources),
            source => source.HintName.EndsWith("_Area.g.cs", StringComparison.Ordinal))
            .SourceText
            .ToString();
        Assert.Contains("FromCircleDiameter(global::UnitsNet.Length diameter)", areaSource, StringComparison.Ordinal);
        Assert.Contains("FromCircleRadius(global::UnitsNet.Length radius)", areaSource, StringComparison.Ordinal);
    }

    [Fact]
    public void AreaWithoutLengthSelection_OmitsDependentAugmentation()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.Area>;
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
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.Acceleration>,
                IInclude<UnitsNet.Modular.BuiltIns.Area>,
                IInclude<UnitsNet.Modular.BuiltIns.Force>,
                IInclude<UnitsNet.Modular.BuiltIns.Mass>,
                IInclude<UnitsNet.Modular.BuiltIns.MassFraction>,
                IInclude<UnitsNet.Modular.BuiltIns.Pressure>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = string.Join(
            Environment.NewLine,
            run.Result.Results.SelectMany(result => result.GeneratedSources).Select(source => source.SourceText));
        Assert.Contains("GetComponentMass(global::UnitsNet.Mass totalMass)", generated, StringComparison.Ordinal);
        Assert.Contains("FromPressureByArea(global::UnitsNet.Pressure pressure", generated, StringComparison.Ordinal);
        Assert.Contains("FromMassByAcceleration(global::UnitsNet.Mass mass", generated, StringComparison.Ordinal);
        Assert.Contains("FromGravitationalForce(global::UnitsNet.Force force)", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void ChemistrySelections_EmitCompatibleAugmentations()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.AmountOfSubstance>,
                IInclude<UnitsNet.Modular.BuiltIns.Density>,
                IInclude<UnitsNet.Modular.BuiltIns.Mass>,
                IInclude<UnitsNet.Modular.BuiltIns.MassConcentration>,
                IInclude<UnitsNet.Modular.BuiltIns.Molarity>,
                IInclude<UnitsNet.Modular.BuiltIns.MolarMass>,
                IInclude<UnitsNet.Modular.BuiltIns.Volume>,
                IInclude<UnitsNet.Modular.BuiltIns.VolumeConcentration>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = string.Join(
            Environment.NewLine,
            run.Result.Results.SelectMany(result => result.GeneratedSources).Select(source => source.SourceText));
        Assert.Contains("double AvogadroConstant", generated, StringComparison.Ordinal);
        Assert.Contains("FromMass(global::UnitsNet.Mass mass", generated, StringComparison.Ordinal);
        Assert.Contains("ToMolarity(global::UnitsNet.MolarMass molecularWeight)", generated, StringComparison.Ordinal);
        Assert.Contains("ToVolumeConcentration(global::UnitsNet.Density componentDensity", generated, StringComparison.Ordinal);
        Assert.Contains("FromVolumes(global::UnitsNet.Volume componentVolume", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void EnergySelections_EmitCompatibleAugmentations()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.ElectricApparentPower>,
                IInclude<UnitsNet.Modular.BuiltIns.ElectricCurrent>,
                IInclude<UnitsNet.Modular.BuiltIns.ElectricPotential>,
                IInclude<UnitsNet.Modular.BuiltIns.Energy>,
                IInclude<UnitsNet.Modular.BuiltIns.EnergyDensity>,
                IInclude<UnitsNet.Modular.BuiltIns.Ratio>,
                IInclude<UnitsNet.Modular.BuiltIns.Volume>;
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
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.AmplitudeRatio>,
                IInclude<UnitsNet.Modular.BuiltIns.ElectricPotential>,
                IInclude<UnitsNet.Modular.BuiltIns.ElectricResistance>,
                IInclude<UnitsNet.Modular.BuiltIns.Level>,
                IInclude<UnitsNet.Modular.BuiltIns.Power>,
                IInclude<UnitsNet.Modular.BuiltIns.PowerRatio>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = string.Join(
            Environment.NewLine,
            run.Result.Results.SelectMany(result => result.GeneratedSources).Select(source => source.SourceText));
        Assert.Contains("AmplitudeRatio(global::UnitsNet.ElectricPotential voltage)", generated, StringComparison.Ordinal);
        Assert.Contains("ToPowerRatio(global::UnitsNet.ElectricResistance impedance)", generated, StringComparison.Ordinal);
        Assert.Contains("Level(double quantity, double reference)", generated, StringComparison.Ordinal);
        Assert.Contains("PowerRatio(global::UnitsNet.Power power)", generated, StringComparison.Ordinal);
        Assert.Contains("ToAmplitudeRatio(global::UnitsNet.ElectricResistance impedance)", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void CompanionSelections_EmitFactoriesAndWrappers()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.Length>,
                IInclude<UnitsNet.Modular.BuiltIns.Mass>,
                IInclude<UnitsNet.Modular.BuiltIns.Pressure>;
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
            using UnitsNet.Modular;

            [UnitSet("regex:^Meter$")]
            internal interface MeterOnly;

            [UnitSet("regex:^Kilogram$")]
            internal interface KilogramOnly;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.Length, MeterOnly>,
                IInclude<UnitsNet.Modular.BuiltIns.Mass, KilogramOnly>;
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
