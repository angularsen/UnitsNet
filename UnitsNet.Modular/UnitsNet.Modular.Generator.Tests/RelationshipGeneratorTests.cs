// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class RelationshipGeneratorTests
{
    [Fact]
    public void ReciprocalPair_GeneratesCompilableInverseMembers()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNet.Modular;

            [QuantitySpec("UnitsNet.ReciprocalLength")]
            internal interface ReciprocalLengthSpec;

            [UnitsNetModule("UnitsNet.Modular")]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>,
                IInclude<ReciprocalLengthSpec>;
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
                "global::UnitsNet.Modular.ReciprocalLength Inverse() => new global::UnitsNet.Modular.ReciprocalLength",
                StringComparison.Ordinal));
    }

    [Fact]
    public void BuiltInRelation_GeneratesMultiplicationAndInferredDivision()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.MassSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.AccelerationSpec>,
                IInclude<UnitsNet.Modular.BuiltIns.ForceSpec>;
            """);

        string generated = string.Join("\n", run.Result.GeneratedTrees.Select(tree => tree.ToString()));
        Assert.Contains(
            "operator *(global::UnitsNet.Mass left, global::UnitsNet.Acceleration right)",
            generated,
            StringComparison.Ordinal);
        Assert.Contains(
            "operator /(global::UnitsNet.Force left, global::UnitsNet.Acceleration right)",
            generated,
            StringComparison.Ordinal);
    }

    [Fact]
    public void StructuredRelation_CrossesNamespacesAndUsesUnselectedAnchorUnits()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNet.Modular;

            [QuantitySpec("Fictional.Width")]
            internal interface WidthSpec;

            [QuantitySpec("Fictional.AreaLike")]
            internal interface AreaLikeSpec;

            [UnitSet("Meter")]
            internal interface MeterOnlyUnitSet;

            [UnitSet("SquareMeter")]
            internal interface SquareMeterOnlyUnitSet;

            [UnitsNetModule]
            internal interface Module :
                IInclude<UnitsNet.Modular.BuiltIns.LengthSpec, MeterOnlyUnitSet>,
                IInclude<WidthSpec, MeterOnlyUnitSet>,
                IInclude<AreaLikeSpec, SquareMeterOnlyUnitSet>;
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
            "operator *(global::Fictional.Width left, global::UnitsNet.Length right)",
            width,
            StringComparison.Ordinal);
        Assert.DoesNotContain("WidthUnit.Foot", width, StringComparison.Ordinal);
        Assert.DoesNotContain("LengthUnit.Foot", width, StringComparison.Ordinal);
        Assert.DoesNotContain("AreaLikeUnit.SquareFoot", width, StringComparison.Ordinal);
    }

    [Fact]
    public void UnknownRelationQuantity_ReportsDiagnosticInsteadOfSilentlyDroppingRelation()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.LengthSpec>;
            """,
            ("Unknown.unitsnet.relations.json", """
                [
                  {
                    "result": { "quantity": "UnitsNet.Length", "unit": "Meter" },
                    "left": { "quantity": "ThirdParty.DoesNotExist", "unit": "Value" },
                    "operator": "*",
                    "right": { "quantity": "UnitsNet.Length", "unit": "Meter" }
                  }
                ]
                """));

        Diagnostic diagnostic = Assert.Single(run.Result.Diagnostics, item => item.Id == "UNM011");
        Assert.Contains("Quantity ID 'ThirdParty.DoesNotExist' is unknown", diagnostic.GetMessage(), StringComparison.Ordinal);
    }
}
