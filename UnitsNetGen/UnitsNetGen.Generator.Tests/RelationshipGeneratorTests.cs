// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNetGen.Generator.Tests;

public sealed class RelationshipGeneratorTests
{
    [Fact]
    public void ReciprocalPair_GeneratesCompilableInverseMembers()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNetGen.Generation;

            [QuantityDefinition("UnitsNet.ReciprocalLength")]
            internal interface ReciprocalLengthDefinition;

            [UnitsNetModule("UnitsNetGen")]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.Length>,
                IInclude<ReciprocalLengthDefinition>;
            """,
            ("ReciprocalLength.unitsnet.json", """
                {
                  "Name": "ReciprocalLength",
                  "Namespace": "UnitsNet",
                  "BaseUnit": "InverseMeter",
                  "Units": [
                    {
                      "SingularName": "InverseMeter",
                      "PluralName": "InverseMeters",
                      "FromUnitToBaseFunc": "{x}",
                      "FromBaseToUnitFunc": "{x}",
                      "Localization": [
                        { "Culture": "en-US", "Abbreviations": [ "1/m" ] }
                      ]
                    }
                  ]
                }
                """));

        Diagnostic[] errors = run.Compilation.GetDiagnostics()
            .Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error)
            .ToArray();

        Assert.Empty(errors);
        Assert.Contains(
            run.Result.GeneratedTrees,
            tree => tree.ToString().Contains(
                "global::UnitsNetGen.ReciprocalLength Inverse() => new global::UnitsNetGen.ReciprocalLength",
                StringComparison.Ordinal));
    }

    [Fact]
    public void BuiltInRelation_GeneratesMultiplicationAndInferredDivision()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.Mass>,
                IInclude<UnitsNetGen.BuiltIns.Acceleration>,
                IInclude<UnitsNetGen.BuiltIns.Force>;
            """);

        string generated = string.Join("\n", run.Result.GeneratedTrees.Select(tree => tree.ToString()));
        Assert.Contains(
            "operator *(global::UnitsNetGen.Mass left, global::UnitsNetGen.Acceleration right)",
            generated,
            StringComparison.Ordinal);
        Assert.Contains(
            "operator /(global::UnitsNetGen.Force left, global::UnitsNetGen.Acceleration right)",
            generated,
            StringComparison.Ordinal);
    }

    [Fact]
    public void StructuredRelation_CrossesNamespacesAndUsesUnselectedAnchorUnits()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNetGen.Generation;

            [QuantityDefinition("Fictional.Width")]
            internal interface WidthDefinition;

            [QuantityDefinition("Fictional.AreaLike")]
            internal interface AreaLikeDefinition;

            [UnitSet("Meter")]
            internal interface MeterOnly;

            [UnitSet("SquareMeter")]
            internal interface SquareMeterOnly;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNetGen.BuiltIns.Length, MeterOnly>,
                IInclude<WidthDefinition, MeterOnly>,
                IInclude<AreaLikeDefinition, SquareMeterOnly>;
            """,
            ("Width.unitsnet.json", """
                {
                  "Name": "Width",
                  "Namespace": "Fictional",
                  "BaseUnit": "Meter",
                  "Units": [
                    { "SingularName": "Meter", "PluralName": "Meters", "FromUnitToBaseFunc": "{x}", "FromBaseToUnitFunc": "{x}" },
                    { "SingularName": "Foot", "PluralName": "Feet", "FromUnitToBaseFunc": "{x} * 0.3048", "FromBaseToUnitFunc": "{x} / 0.3048" }
                  ]
                }
                """),
            ("AreaLike.unitsnet.json", """
                {
                  "Name": "AreaLike",
                  "Namespace": "Fictional",
                  "BaseUnit": "SquareMeter",
                  "Units": [
                    { "SingularName": "SquareMeter", "PluralName": "SquareMeters", "FromUnitToBaseFunc": "{x}", "FromBaseToUnitFunc": "{x}" },
                    { "SingularName": "SquareFoot", "PluralName": "SquareFeet", "FromUnitToBaseFunc": "{x} * 0.09290304", "FromBaseToUnitFunc": "{x} / 0.09290304" }
                  ]
                }
                """),
            ("Fictional.unitsnet.relations.json", """
                [
                  {
                    "result": { "quantity": "Fictional.AreaLike", "unit": "SquareFoot" },
                    "left": { "quantity": "Fictional.Width", "unit": "Foot" },
                    "operator": "*",
                    "right": { "quantity": "UnitsNet.Length", "unit": "Foot" }
                  }
                ]
                """));

        Assert.Empty(run.Compilation.GetDiagnostics().Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error));
        string width = Assert.Single(
            run.Result.GeneratedTrees,
            tree => tree.FilePath.EndsWith("Fictional_Width.g.cs", StringComparison.Ordinal)).ToString();
        Assert.Contains(
            "operator *(global::Fictional.Width left, global::UnitsNetGen.Length right)",
            width,
            StringComparison.Ordinal);
        Assert.DoesNotContain("WidthUnit.Foot", width, StringComparison.Ordinal);
        Assert.DoesNotContain("LengthUnit.Foot", width, StringComparison.Ordinal);
        Assert.DoesNotContain("AreaLikeUnit.SquareFoot", width, StringComparison.Ordinal);
    }
}
