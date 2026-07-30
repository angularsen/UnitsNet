// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class FullCatalogGeneratorTests
{
    private const string Source = """
        using UnitsNet.Modular;
        using UnitsNet.Modular.Profiles;

        [UnitsNetModule]
        internal interface FullCatalogModule : IIncludeProfile<AllQuantities>;
        """;

    private readonly ITestOutputHelper _output;

    public FullCatalogGeneratorTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void FullCatalog_GeneratesDeterministicallyWithinPrototypeBudgets()
    {
        var stopwatch = Stopwatch.StartNew();
        GeneratorTestHost.TestRun first = GeneratorTestHost.Run(Source);
        stopwatch.Stop();

        Assert.DoesNotContain(first.Result.Diagnostics, diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        Assert.DoesNotContain(
            first.Compilation.GetDiagnostics(),
            diagnostic => diagnostic.Severity == DiagnosticSeverity.Error);
        GeneratedSourceResult[] firstSources = first.Result.Results
            .SelectMany(result => result.GeneratedSources)
            .OrderBy(source => source.HintName, StringComparer.Ordinal)
            .ToArray();
        Assert.Equal(
            129,
            firstSources.Count(source =>
                source.SourceText.ToString().Contains("public readonly partial struct", StringComparison.Ordinal)));
        Assert.Contains(firstSources, source => source.HintName.EndsWith("_Registry.g.cs", StringComparison.Ordinal));
        Assert.Contains(firstSources, source => source.HintName.EndsWith("_Extensions.g.cs", StringComparison.Ordinal));

        long sourceCharacters = firstSources.Sum(source => (long)source.SourceText.Length);
        _output.WriteLine($"Full catalog generated {firstSources.Length} sources and {sourceCharacters:N0} characters in {stopwatch.Elapsed}.");
        Assert.InRange(sourceCharacters, 1, 20_000_000);
        Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(30), $"Full catalog generation took {stopwatch.Elapsed}.");

        GeneratorTestHost.TestRun second = GeneratorTestHost.Run(Source);
        GeneratedSourceResult[] secondSources = second.Result.Results
            .SelectMany(result => result.GeneratedSources)
            .OrderBy(source => source.HintName, StringComparer.Ordinal)
            .ToArray();
        Assert.Equal(
            firstSources.Select(source => (source.HintName, source.SourceText.ToString())),
            secondSources.Select(source => (source.HintName, source.SourceText.ToString())));
    }
}
