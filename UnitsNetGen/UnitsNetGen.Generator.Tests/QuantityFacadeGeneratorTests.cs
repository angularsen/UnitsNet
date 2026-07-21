// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNetGen.Generator.Tests;

public sealed class QuantityFacadeGeneratorTests
{
    [Fact]
    public void DefaultModule_EmitsQuantityFacadeInOwnerNamespace()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            namespace Application.Units;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNetGen.BuiltIns.Length>;

            internal static class Consumer
            {
                public static void Use(UnitsNetGen.UnitSystem unitSystem)
                {
                    var length = new global::UnitsNetGen.Length(1, unitSystem);
                    _ = global::UnitsNetGen.Length.From(1, unitSystem);
                    _ = length.As(unitSystem);
                    _ = length.ToUnit(unitSystem);
                    _ = Quantity.From(1, "Length", unitSystem);
                    _ = Quantity.TryFrom(1, "Length", unitSystem, out _);
                }
            }
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string facade = GetFacade(run);
        Assert.Contains("namespace Application.Units", facade, StringComparison.Ordinal);
        Assert.Contains("public static partial class Quantity", facade, StringComparison.Ordinal);
        Assert.Contains("global::UnitsNet.Core.IQuantity<double> From(", facade, StringComparison.Ordinal);
        Assert.Contains("global::UnitsNetGen.UnitSystem unitSystem", facade, StringComparison.Ordinal);
        Assert.Contains("global::UnitsNetGen.QuantityRegistry Registry", facade, StringComparison.Ordinal);
    }

    [Fact]
    public void NamespaceOverride_EmitsQuantityFacadeInCompatibilityNamespace()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            namespace Application.Units;

            [UnitsNetModule("UnitsNet")]
            internal interface Module : IInclude<UnitsNetGen.BuiltIns.Length>;
            """);

        Assert.DoesNotContain(run.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(run.Compilation.GetDiagnostics(), diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string facade = GetFacade(run);
        Assert.Contains("namespace UnitsNet", facade, StringComparison.Ordinal);
        Assert.DoesNotContain("namespace Application.Units", facade, StringComparison.Ordinal);
    }

    private static string GetFacade(GeneratorTestHost.TestRun run) =>
        run.Result.Results
            .SelectMany(result => result.GeneratedSources)
            .Single(source => source.HintName.EndsWith("_Quantity.g.cs", StringComparison.Ordinal))
            .SourceText
            .ToString();
}
