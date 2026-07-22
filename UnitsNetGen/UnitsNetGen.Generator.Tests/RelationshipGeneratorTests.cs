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
                "ReciprocalLength Inverse() => ReciprocalLength.FromInverseMeters(1 / Meters);",
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
        Assert.Contains("operator *(Mass left, Acceleration right)", generated, StringComparison.Ordinal);
        Assert.Contains("operator /(Force left, Acceleration right)", generated, StringComparison.Ordinal);
    }
}
