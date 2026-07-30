// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class IncrementalityGeneratorTests
{
    private const string CustomModule = """
        using UnitsNet.Modular;

        [QuantitySpec("Sample.Distance")]
        internal interface DistanceSpec;

        [QuantitySpec("Sample.Weight")]
        internal interface WeightSpec;

        [UnitsNetModule]
        internal interface Module : IInclude<DistanceSpec>, IInclude<WeightSpec>;
        """;

    private const string DistanceSpec = """
        {
          "Name": "Distance",
          "Namespace": "Sample",
          "BaseUnit": "Meter",
          "Units": [
            {
              "SingularName": "Meter",
              "PluralName": "Meters",
              "FromUnitToBaseFunc": "{x}",
              "FromBaseToUnitFunc": "{x}"
            }
          ]
        }
        """;

    private const string WeightSpec = """
        {
          "Name": "Weight",
          "Namespace": "Sample",
          "BaseUnit": "Gram",
          "Units": [
            {
              "SingularName": "Gram",
              "PluralName": "Grams",
              "FromUnitToBaseFunc": "{x}",
              "FromBaseToUnitFunc": "{x}"
            }
          ]
        }
        """;

    [Fact]
    public void UnchangedModule_IsCachedAcrossEquivalentCompilations()
    {
        const string source = """
            using UnitsNet.Modular;

            [UnitsNetModule]
            internal interface Module : IIncludeProfile<UnitsNet.Modular.Profiles.AllQuantitiesProfile>;
            """;
        CSharpCompilation first = GeneratorTestHost.CreateCompilation(source);
        GeneratorDriver driver = GeneratorTestHost.CreateDriver().RunGenerators(first);
        CSharpCompilation second = GeneratorTestHost.CreateCompilation(source);
        driver = driver.RunGenerators(second);

        GeneratorDriverRunResult result = driver.GetRunResult();
        IncrementalGeneratorRunStep[] moduleSteps = result.Results
            .SelectMany(generator => generator.TrackedSteps["Modules"])
            .ToArray();
        IncrementalGeneratorRunStep[] generationSteps = result.Results
            .SelectMany(generator => generator.TrackedSteps["GenerationInputs"])
            .ToArray();

        Assert.NotEmpty(moduleSteps);
        Assert.All(
            moduleSteps.SelectMany(step => step.Outputs),
            output => Assert.Equal(IncrementalStepRunReason.Unchanged, output.Reason));
        Assert.NotEmpty(generationSteps);
        Assert.All(
            generationSteps.SelectMany(step => step.Outputs),
            output => Assert.Equal(IncrementalStepRunReason.Cached, output.Reason));
    }

    [Fact]
    public void EquivalentAdditionalTextInstances_AreUnchangedByContent()
    {
        ImmutableArray<AdditionalText> firstFiles = GeneratorTestHost.CreateAdditionalTexts(
            ("Distance.unitsnet.json", DistanceSpec),
            ("Weight.unitsnet.json", WeightSpec));
        GeneratorDriver driver = GeneratorTestHost.CreateDriver(firstFiles)
            .RunGenerators(GeneratorTestHost.CreateCompilation(CustomModule));
        ImmutableArray<AdditionalText> equivalentFiles = GeneratorTestHost.CreateAdditionalTexts(
            ("Distance.unitsnet.json", DistanceSpec),
            ("Weight.unitsnet.json", WeightSpec));

        driver = driver
            .ReplaceAdditionalTexts(equivalentFiles)
            .RunGenerators(GeneratorTestHost.CreateCompilation(CustomModule));

        Assert.All(
            DefinitionOutputs(driver),
            output => Assert.Equal(IncrementalStepRunReason.Unchanged, output.Reason));
    }

    [Fact]
    public void ChangedDefinition_DoesNotInvalidateUnchangedDefinitionParsing()
    {
        ImmutableArray<AdditionalText> firstFiles = GeneratorTestHost.CreateAdditionalTexts(
            ("Distance.unitsnet.json", DistanceSpec),
            ("Weight.unitsnet.json", WeightSpec));
        GeneratorDriver driver = GeneratorTestHost.CreateDriver(firstFiles)
            .RunGenerators(GeneratorTestHost.CreateCompilation(CustomModule));
        ImmutableArray<AdditionalText> changedFiles = GeneratorTestHost.CreateAdditionalTexts(
            ("Distance.unitsnet.json", DistanceSpec.Replace("\"Meters\"", "\"Metres\"", StringComparison.Ordinal)),
            ("Weight.unitsnet.json", WeightSpec));

        driver = driver
            .ReplaceAdditionalTexts(changedFiles)
            .RunGenerators(GeneratorTestHost.CreateCompilation(CustomModule));

        Assert.Collection(
            DefinitionOutputs(driver),
            output => Assert.Equal(IncrementalStepRunReason.Modified, output.Reason),
            output => Assert.Equal(IncrementalStepRunReason.Unchanged, output.Reason));
    }

    private static (object Value, IncrementalStepRunReason Reason)[] DefinitionOutputs(GeneratorDriver driver) =>
        driver.GetRunResult().Results
            .SelectMany(generator => generator.TrackedSteps["Definitions"])
            .SelectMany(step => step.Outputs)
            .ToArray();
}
