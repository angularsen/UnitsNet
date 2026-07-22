// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNetGen.Generator.Tests;

public sealed class DiagnosticGeneratorTests
{
    [Fact]
    public void UnitSetWithoutAttribute_ReportsAtModuleDeclaration()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            internal interface MissingUnitSet;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNetGen.BuiltIns.Length, MissingUnitSet>;
            """);

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNG012");
        Assert.Equal(LocationKind.ExternalFile, diagnostic.Location.Kind);
        Assert.Equal("Test.cs", diagnostic.Location.GetLineSpan().Path);
        Assert.Equal(5, diagnostic.Location.GetLineSpan().StartLinePosition.Line);
    }

    [Fact]
    public void DifferentDefinitionsWithSameGeneratedType_ReportCollision()
    {
        const string unit = """
            "BaseUnit": "Value",
            "Units": [
              { "SingularName": "Value", "PluralName": "Values", "FromUnitToBaseFunc": "{x}", "FromBaseToUnitFunc": "{x}" }
            ]
            """;
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNetGen.Generation;

            [QuantityDefinition("First.Widget")]
            internal interface FirstWidget;

            [QuantityDefinition("Second.Widget")]
            internal interface SecondWidget;

            [UnitsNetModule("Application.Units")]
            internal interface Module : IInclude<FirstWidget>, IInclude<SecondWidget>;
            """,
            ("First.unitsnet.json", "{ \"Name\": \"Widget\", \"Namespace\": \"First\", " + unit + " }"),
            ("Second.unitsnet.json", "{ \"Name\": \"Widget\", \"Namespace\": \"Second\", " + unit + " }"));

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNG013");
        Assert.Contains("Application.Units.Widget", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.Equal(LocationKind.ExternalFile, diagnostic.Location.Kind);
        Assert.Equal("Test.cs", diagnostic.Location.GetLineSpan().Path);
    }
}
