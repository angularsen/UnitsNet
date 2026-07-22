// Licensed under MIT No Attribution, see LICENSE file at the root.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace UnitsNetGen.Generator.Tests;

public sealed class IncrementalityGeneratorTests
{
    [Fact]
    public void UnchangedModule_IsCachedAcrossEquivalentCompilations()
    {
        const string source = """
            using UnitsNetGen.Generation;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNetGen.BuiltIns.Length>;
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
}
