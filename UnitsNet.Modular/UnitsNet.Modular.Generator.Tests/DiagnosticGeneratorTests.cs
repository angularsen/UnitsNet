// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class DiagnosticGeneratorTests
{
    [Fact]
    public void LegacyUnitsNetReference_ReportsUnsupportedCombination()
    {
        CSharpCompilation legacyCompilation = GeneratorTestHost.CreateCompilation(
                "namespace UnitsNet; public sealed class LegacyRuntimeMarker;")
            .WithAssemblyName("UnitsNet");
        using var stream = new MemoryStream();
        Assert.True(legacyCompilation.Emit(stream).Success);

        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>;
            """,
            new[] { MetadataReference.CreateFromImage(stream.ToArray()) });

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM016");
        Assert.Contains("Remove the legacy UnitsNet package reference", diagnostic.GetMessage(), StringComparison.Ordinal);
    }

    [Fact]
    public void MultipleModules_ReportActionableDiagnosticWithoutCollidingGeneratedTypes()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface FirstModule : IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>;

            [UnitsNetModule]
            internal interface SecondModule : IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>;
            """);

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM014");
        Assert.Contains("FirstModule", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.Contains("SecondModule", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.Contains("one module", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.Equal("Test.cs", diagnostic.Location.GetLineSpan().Path);
        Assert.DoesNotContain(
            run.Compilation.GetDiagnostics(),
            item => item.Id is "CS0101" or "CS0102");
        Assert.DoesNotContain(
            run.Result.Results.SelectMany(result => result.GeneratedSources),
            source => source.SourceText.ToString().Contains("partial struct Length", StringComparison.Ordinal));
    }

    [Fact]
    public void AffineQuantityWithoutOffsetSelection_ReportsRequiredQuantity()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.TemperatureSpec>;
            """);

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM015");
        Assert.Contains("UnitsNet.Temperature", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.Contains("UnitsNet.TemperatureDelta", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.Equal("Test.cs", diagnostic.Location.GetLineSpan().Path);
        Assert.DoesNotContain(
            run.Compilation.GetDiagnostics(),
            item => item.Id is "CS0246" or "CS0101" or "CS0102");
        Assert.DoesNotContain(
            run.Result.Results.SelectMany(result => result.GeneratedSources),
            source => source.SourceText.ToString().Contains("partial struct Temperature", StringComparison.Ordinal));
    }

    [Fact]
    public void UnitSetWithoutAttribute_ReportsAtModuleDeclaration()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            internal interface MissingUnitSet;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.LengthSpec, MissingUnitSet>;
            """);

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM012");
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
            using UnitsNet.Modular;

            [QuantitySpec("First.Widget")]
            internal interface FirstWidgetSpec;

            [QuantitySpec("Second.Widget")]
            internal interface SecondWidgetSpec;

            [UnitsNetModule("Application.Units")]
            internal interface Module : IInclude<FirstWidgetSpec>, IInclude<SecondWidgetSpec>;
            """,
            ("First.unitsnet.json", "{ \"Name\": \"Widget\", \"Namespace\": \"First\", " + unit + " }"),
            ("Second.unitsnet.json", "{ \"Name\": \"Widget\", \"Namespace\": \"Second\", " + unit + " }"));

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM013");
        Assert.Contains("Application.Units.Widget", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.Equal(LocationKind.ExternalFile, diagnostic.Location.Kind);
        Assert.Equal("Test.cs", diagnostic.Location.GetLineSpan().Path);
    }

    [Fact]
    public void MalformedJson_ReportsTheJsonErrorLocation()
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
                    invalid
                  ]
                }
                """));

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM004");
        FileLinePositionSpan span = diagnostic.Location.GetLineSpan();
        Assert.Equal("Widget.unitsnet.json", span.Path);
        Assert.Equal(5, span.StartLinePosition.Line);
        Assert.True(span.StartLinePosition.Character > 0);
    }

    [Fact]
    public void UnknownPrefix_ReportsInvalidDefinitionInsteadOfCrashingGenerator()
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
                      "FromUnitToBaseFunc": "{x}",
                      "FromBaseToUnitFunc": "{x}",
                      "Prefixes": [ "Imaginary" ]
                    }
                  ]
                }
                """));

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM004");
        Assert.Contains("Unknown prefix 'Imaginary'", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.DoesNotContain(run.Result.Diagnostics, item => item.Id == "CS8785");
    }

    [Fact]
    public void DuplicateUnitName_ReportsDefinitionDiagnosticWithoutCompilerCollision()
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
                    { "SingularName": "Value", "PluralName": "Values", "FromUnitToBaseFunc": "{x}", "FromBaseToUnitFunc": "{x}" },
                    { "SingularName": "Value", "PluralName": "OtherValues", "FromUnitToBaseFunc": "{x}", "FromBaseToUnitFunc": "{x}" }
                  ]
                }
                """));

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM004");
        Assert.Contains("SingularName 'Value' is duplicated", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.DoesNotContain(
            run.Compilation.GetDiagnostics(),
            item => item.Id is "CS0101" or "CS0102" or "CS0111");
    }

    [Fact]
    public void InvalidCSharpIdentifier_ReportsDefinitionDiagnostic()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNet.Modular;

            [QuantitySpec("Sample.Bad-Widget")]
            internal interface WidgetSpec;

            [UnitsNetModule]
            internal interface Module : IInclude<WidgetSpec>;
            """,
            ("Widget.unitsnet.json", """
                {
                  "Name": "Bad-Widget",
                  "Namespace": "Sample",
                  "BaseUnit": "Value",
                  "Units": [
                    { "SingularName": "Value", "PluralName": "Values", "FromUnitToBaseFunc": "{x}", "FromBaseToUnitFunc": "{x}" }
                  ]
                }
                """));

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM004");
        Assert.Contains("not a valid C# identifier", diagnostic.GetMessage(), StringComparison.Ordinal);
        Assert.DoesNotContain(run.Result.Diagnostics, item => item.Id == "CS8785");
    }
}
