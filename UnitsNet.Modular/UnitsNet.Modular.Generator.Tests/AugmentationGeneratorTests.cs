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
                IInclude<UnitsNet.Modular.BuiltIns.AreaSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>;
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
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.AreaSpec>;
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
                IInclude<UnitsNet.Modular.BuiltIns.AccelerationSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.AreaSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.ForceSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.MassSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.MassFractionSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.PressureSpec>;
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
                IInclude<UnitsNet.Modular.BuiltIns.AmountOfSubstanceSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.DensitySpec>,
                IInclude<UnitsNet.Modular.BuiltIns.MassSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.MassConcentrationSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.MolaritySpec>,
                IInclude<UnitsNet.Modular.BuiltIns.MolarMassSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.VolumeSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.VolumeConcentrationSpec>;
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
                IInclude<UnitsNet.Modular.BuiltIns.ElectricApparentPowerSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.ElectricCurrentSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.ElectricPotentialSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.EnergySpec>,
                IInclude<UnitsNet.Modular.BuiltIns.EnergyDensitySpec>,
                IInclude<UnitsNet.Modular.BuiltIns.RatioSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.VolumeSpec>;
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
                IInclude<UnitsNet.Modular.BuiltIns.AmplitudeRatioSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.ElectricPotentialSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.ElectricResistanceSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.LevelSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.PowerSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.PowerRatioSpec>;
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
                IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.MassSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.PressureSpec>;
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
            internal interface MeterOnlyUnitSet;

            [UnitSet("regex:^Kilogram$")]
            internal interface KilogramOnlyUnitSet;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.LengthSpec, MeterOnlyUnitSet>,
                IInclude<UnitsNet.Modular.BuiltIns.MassSpec, KilogramOnlyUnitSet>;
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
