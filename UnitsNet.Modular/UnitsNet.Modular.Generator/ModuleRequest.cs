// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace UnitsNet.Modular.Generator;

internal sealed class ModuleRequest
{
    public ModuleRequest(
        string name,
        string ownerNamespace,
        string? targetNamespace,
        ImmutableArray<ModuleSelection> selections,
        SourceLocation location)
    {
        Name = name;
        OwnerNamespace = ownerNamespace;
        TargetNamespace = targetNamespace;
        Selections = selections;
        Location = location;
        Fingerprint = string.Join(
            "\n",
            new[] { name, ownerNamespace, targetNamespace ?? string.Empty }
                .Concat(selections.Select(selection => selection.Fingerprint)));
    }

    public string Name { get; }

    public string OwnerNamespace { get; }

    public string? TargetNamespace { get; }

    public string FacadeNamespace =>
        !string.IsNullOrWhiteSpace(TargetNamespace)
            ? TargetNamespace!
            : Selections.Any(
                selection => selection.SemanticId is not null &&
                             BuiltInCatalog.TryGetBySemanticId(selection.SemanticId, out _))
                ? "UnitsNet"
                : OwnerNamespace;

    public ImmutableArray<ModuleSelection> Selections { get; }

    public SourceLocation Location { get; }

    public string Fingerprint { get; }
}

internal sealed class ModuleSelection
{
    public ModuleSelection(
        string specName,
        string? semanticId,
        ImmutableArray<string> patterns,
        bool hasUnitSet,
        bool isDirect)
    {
        SpecName = specName;
        SemanticId = semanticId;
        Patterns = patterns;
        HasUnitSet = hasUnitSet;
        IsDirect = isDirect;
        Fingerprint = string.Join(
            "|",
            specName,
            semanticId ?? string.Empty,
            hasUnitSet,
            isDirect,
            string.Join("\u001f", patterns));
    }

    public string SpecName { get; }

    public string? SemanticId { get; }

    public ImmutableArray<string> Patterns { get; }

    public bool HasUnitSet { get; }

    public bool IsDirect { get; }

    public string Fingerprint { get; }
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

    public int GetHashCode(ModuleRequest obj)
    {
        unchecked
        {
            int hash = StringComparer.Ordinal.GetHashCode(obj.Fingerprint);
            hash = (hash * 397) ^ StringComparer.Ordinal.GetHashCode(obj.Location.Path ?? string.Empty);
            return (hash * 397) ^ obj.Location.SourceSpan.GetHashCode();
        }
    }
}
