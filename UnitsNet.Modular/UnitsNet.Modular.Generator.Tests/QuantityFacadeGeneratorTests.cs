// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class QuantityFacadeGeneratorTests
{
    [Fact]
    public void DefaultBuiltInModule_EmitsSourceCompatibleQuantityFacade()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            namespace Application.Units;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>;

            internal static class Consumer
            {
                public static void Use(global::UnitsNet.UnitSystem unitSystem)
                {
                    var length = new global::UnitsNet.Length(1, unitSystem);
                    _ = global::UnitsNet.Length.From(1, unitSystem);
                    _ = length.As(unitSystem);
                    _ = length.ToUnit(unitSystem);
                    global::UnitsNet.QuantityInfo<global::UnitsNet.Length, global::UnitsNet.Units.LengthUnit> info =
                        global::UnitsNet.Length.Info;
                    global::UnitsNet.UnitInfo<global::UnitsNet.Units.LengthUnit> meter =
                        info[global::UnitsNet.Units.LengthUnit.Meter];
                    _ = meter.Value;
                    _ = meter.Name;
                    _ = info.BaseUnit.Value;
                    _ = info.Units;
                    _ = global::UnitsNet.Quantity.From(1, "Length", unitSystem);
                    _ = global::UnitsNet.Quantity.TryFrom(1, "Length", unitSystem, out _);
                }
            }
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string facade = GetFacade(run);
        Assert.Contains("namespace UnitsNet", facade, StringComparison.Ordinal);
        Assert.DoesNotContain("namespace Application.Units", facade, StringComparison.Ordinal);
        Assert.Contains("public static partial class Quantity", facade, StringComparison.Ordinal);
        Assert.Contains("global::UnitsNet.IQuantity<double> From(", facade, StringComparison.Ordinal);
        Assert.Contains("global::UnitsNet.UnitSystem unitSystem", facade, StringComparison.Ordinal);
        Assert.Contains("global::UnitsNet.QuantityRegistry Registry", facade, StringComparison.Ordinal);
    }

    [Fact]
    public void AttributedSpecOutsideBuiltInNamespace_ResolvesBuiltInBySemanticId()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            namespace Application.Units;

            [QuantitySpec("UnitsNet.Length")]
            internal interface DistanceSpec;

            [UnitsNetModule]
            internal interface Module : IInclude<DistanceSpec>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.Contains(
            run.Result.Results.SelectMany(result => result.GeneratedSources),
            source => source.HintName.EndsWith("_Length.g.cs", StringComparison.Ordinal));
        Assert.Contains("namespace UnitsNet", GetFacade(run), StringComparison.Ordinal);
    }

    [Fact]
    public void NamespaceOverride_EmitsQuantityFacadeInRequestedNamespace()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            namespace Application.Units;

            [UnitsNetModule("Application.Generated")]
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string facade = GetFacade(run);
        Assert.Contains("namespace Application.Generated", facade, StringComparison.Ordinal);
        Assert.DoesNotContain("namespace Application.Units", facade, StringComparison.Ordinal);
    }

    [Fact]
    public void DefaultCustomOnlyModule_EmitsQuantityFacadeInOwnerNamespace()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNet.Modular;

            namespace Application.Units;

            [QuantitySpec("Fictional.Widget")]
            internal interface WidgetSpec;

            [UnitsNetModule]
            internal interface Module : IInclude<WidgetSpec>;
            """,
            ("Widget.unitsnet.json", """
                {
                  "Name": "Widget",
                  "Namespace": "Fictional",
                  "BaseUnit": "Piece",
                  "Units": [
                    {
                      "SingularName": "Piece",
                      "PluralName": "Pieces",
                      "FromUnitToBaseFunc": "{x}",
                      "FromBaseToUnitFunc": "{x}"
                    }
                  ]
                }
                """));

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string facade = GetFacade(run);
        Assert.Contains("namespace Application.Units", facade, StringComparison.Ordinal);
    }

    private static string GetFacade(GeneratorTestHost.TestRun run) =>
        run.Result.Results
            .SelectMany(result => result.GeneratedSources)
            .Single(source => source.HintName.EndsWith("_Quantity.g.cs", StringComparison.Ordinal))
            .SourceText
            .ToString();
}
