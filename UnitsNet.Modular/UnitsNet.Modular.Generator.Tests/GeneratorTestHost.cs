// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

namespace UnitsNet.Modular.Generator.Tests;

internal static class GeneratorTestHost
{
    public static TestRun Run(string source, params (string Path, string Text)[] additionalFiles)
    {
        CSharpCompilation compilation = CreateCompilation(source);
        GeneratorDriver driver = CreateDriver(additionalFiles)
            .RunGeneratorsAndUpdateCompilation(compilation, out Compilation output, out _);
        return new TestRun(driver.GetRunResult(), output);
    }

    public static CSharpCompilation CreateCompilation(string source)
    {
        string[] trustedAssemblies = ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES"))!
            .Split(Path.PathSeparator);
        var references = trustedAssemblies
            .Select(path => MetadataReference.CreateFromFile(path))
            .Concat(new[]
            {
                MetadataReference.CreateFromFile(typeof(UnitsNet.Modular.QuantityOperations).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(UnitsNet.Modular.IQuantity<>).Assembly.Location),
            })
            .GroupBy(reference => reference.Display, StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .ToArray();
        return CSharpCompilation.Create(
            "GeneratorTest",
            new[] { CSharpSyntaxTree.ParseText(source, ParseOptions, path: "Test.cs") },
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    }

    public static GeneratorDriver CreateDriver(params (string Path, string Text)[] additionalFiles)
        => CreateDriver(CreateAdditionalTexts(additionalFiles));

    public static GeneratorDriver CreateDriver(ImmutableArray<AdditionalText> additionalTexts)
    {
        return CSharpGeneratorDriver.Create(
            new[] { new UnitsNetModularGenerator().AsSourceGenerator() },
            additionalTexts,
            ParseOptions,
            optionsProvider: null,
            new GeneratorDriverOptions(IncrementalGeneratorOutputKind.None, trackIncrementalGeneratorSteps: true));
    }

    public static ImmutableArray<AdditionalText> CreateAdditionalTexts(
        params (string Path, string Text)[] additionalFiles)
    {
        return additionalFiles
            .Select(file => (AdditionalText)new InMemoryAdditionalText(file.Path, file.Text))
            .ToImmutableArray();
    }

    private static CSharpParseOptions ParseOptions { get; } =
        new(LanguageVersion.Latest, preprocessorSymbols: new[] { "NET8_0_OR_GREATER" });

    internal sealed record TestRun(GeneratorDriverRunResult Result, Compilation Compilation);

    private sealed class InMemoryAdditionalText : AdditionalText
    {
        private readonly SourceText _text;

        public InMemoryAdditionalText(string path, string text)
        {
            Path = path;
            _text = SourceText.From(text, Encoding.UTF8);
        }

        public override string Path { get; }

        public override SourceText GetText(CancellationToken cancellationToken = default) => _text;
    }
}
