// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace UnitsNetGen.Generator;

internal sealed class ModuleRequest
{
    public ModuleRequest(
        string name,
        string? targetNamespace,
        ImmutableArray<ModuleSelection> selections,
        SourceLocation location)
    {
        Name = name;
        TargetNamespace = targetNamespace;
        Selections = selections;
        Location = location;
        Fingerprint = string.Join(
            "\n",
            new[] { name, targetNamespace ?? string.Empty }
                .Concat(selections.Select(selection => selection.Fingerprint)));
    }

    public string Name { get; }

    public string? TargetNamespace { get; }

    public ImmutableArray<ModuleSelection> Selections { get; }

    public SourceLocation Location { get; }

    public string Fingerprint { get; }
}

internal sealed class ModuleSelection
{
    public ModuleSelection(
        string markerName,
        string? builtInName,
        string? definitionId,
        ImmutableArray<string> patterns,
        bool hasUnitSet,
        bool isDirect)
    {
        MarkerName = markerName;
        BuiltInName = builtInName;
        DefinitionId = definitionId;
        Patterns = patterns;
        HasUnitSet = hasUnitSet;
        IsDirect = isDirect;
        Fingerprint = string.Join(
            "|",
            markerName,
            builtInName ?? string.Empty,
            definitionId ?? string.Empty,
            hasUnitSet,
            isDirect,
            string.Join("\u001f", patterns));
    }

    public string MarkerName { get; }

    public string? BuiltInName { get; }

    public string? DefinitionId { get; }

    public ImmutableArray<string> Patterns { get; }

    public bool HasUnitSet { get; }

    public bool IsDirect { get; }

    public string Fingerprint { get; }

    public string? SemanticId => BuiltInName is null ? DefinitionId : "UnitsNet." + BuiltInName;
}

internal readonly struct SourceLocation
{
    public SourceLocation(string path, TextSpan sourceSpan, LinePositionSpan lineSpan)
    {
        Path = path;
        SourceSpan = sourceSpan;
        LineSpan = lineSpan;
    }

    public string Path { get; }

    public TextSpan SourceSpan { get; }

    public LinePositionSpan LineSpan { get; }

    public Location ToLocation() => string.IsNullOrEmpty(Path)
        ? Location.None
        : Location.Create(Path, SourceSpan, LineSpan);

    public static SourceLocation From(Location? location)
    {
        if (location is null || !location.IsInSource)
        {
            return default;
        }

        FileLinePositionSpan lineSpan = location.GetLineSpan();
        return new SourceLocation(lineSpan.Path, location.SourceSpan, lineSpan.Span);
    }
}

internal sealed class ModuleRequestComparer : IEqualityComparer<ModuleRequest>
{
    public static ModuleRequestComparer Instance { get; } = new();

    public bool Equals(ModuleRequest? x, ModuleRequest? y) =>
        ReferenceEquals(x, y) ||
        x is not null && y is not null &&
        string.Equals(x.Fingerprint, y.Fingerprint, StringComparison.Ordinal) &&
        string.Equals(x.Location.Path, y.Location.Path, StringComparison.Ordinal) &&
        x.Location.SourceSpan.Equals(y.Location.SourceSpan);

    public int GetHashCode(ModuleRequest obj) => obj.Fingerprint.GetHashCode();
}
