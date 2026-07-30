// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class PrefixGeneratorTests
{
    [Fact]
    public void AffinePrefixedUnit_ScalesInputBeforeApplyingConversion()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNet.Modular;

            [QuantitySpec("Sample.Widget")]
            internal interface WidgetSpec;

            [UnitsNetModule]
            internal interface Module : IInclude<WidgetSpec>;
            """,
            ("Widget.unitsnet.json", """
                {
                  "Name": "Widget",
                  "Namespace": "Sample",
                  "BaseUnit": "Value",
                  "Units": [
                    {
                      "SingularName": "Value",
                      "PluralName": "Values",
                      "FromUnitToBaseFunc": "{x} + 10",
                      "FromBaseToUnitFunc": "{x} - 10",
                      "Prefixes": [ "Kilo" ]
                    }
                  ]
                }
                """));

        Assert.DoesNotContain(
            run.Compilation.GetDiagnostics(),
            diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        string generated = Assert.Single(
            run.Result.GeneratedTrees,
            tree => tree.FilePath.EndsWith("Sample_Widget.g.cs", StringComparison.Ordinal)).ToString();
        Assert.Contains("(x * 1000) + 10", generated, StringComparison.Ordinal);
        Assert.Contains("(x - 10) / 1000", generated, StringComparison.Ordinal);
    }
}
