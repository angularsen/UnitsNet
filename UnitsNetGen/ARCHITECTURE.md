# UnitsNetGen proof-of-concept architecture

## Goal

UnitsNetGen explores a compile-time composition model for a future UnitsNet architecture. A module
author selects only the quantities and units that belong in an assembly, while generated quantity
structs keep the strongly typed API and share a small runtime for conversion, parsing, and formatting.

This is intentionally standalone. It does not reference or reuse any existing UnitsNet interface,
runtime type, generated type, or code-generation model.

The experiment is inspired by
[the modular-package experiment](https://github.com/angularsen/UnitsNet/pull/1181),
[the source-generator discussion](https://github.com/angularsen/UnitsNet/issues/902), and the current
[Roslyn source-generator model](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md).

## Feasibility conclusions

The idea is viable if the unit of composition is a **module assembly**:

1. A module declares an interface that selects quantity definitions.
2. One incremental generator resolves the selection and emits only the selected quantity and unit
   types into that module.
3. Applications and libraries reference the module assembly in the normal way.

The module boundary is important because a generated public type has the identity of the assembly
into which it is generated. If two unrelated assemblies both generate `Length`, those are distinct
CLR types. A reusable library should therefore generate its public quantities once and ship that
module, rather than require every downstream consumer to regenerate them.

Roslyn generators are additive and unordered; a generator cannot consume another generator's output
in the same compilation. Consequently, UnitsNetGen uses one generator for built-in and custom
definitions. Marker attributes and interfaces are constant bootstrap source emitted during
post-initialization, while all selected quantity output is produced by the same generation pipeline.

## Developer experience

Select every unit for a built-in quantity by inheriting `IInclude<TDefinition>`:

```csharp
using UnitsNetGen.BuiltIns;
using UnitsNetGen.Generation;

[UnitsNetModule]
internal interface EngineeringUnits :
    IInclude<Length>,
    IInclude<Force>,
    IInclude<Pressure>
{
}
```

Select units with a regular expression by defining a named unit set:

```csharp
[UnitSet("regex:.*Gram$")]
internal interface GramUnits;

[UnitsNetModule]
internal interface LeanUnits :
    IInclude<Length>,
    IInclude<Mass, GramUnits>
{
}
```

Patterns prefixed with `regex:` use case-insensitive, culture-invariant regular expressions with a
timeout. Patterns prefixed with `glob:` support `*`, and bare patterns retain glob behavior for
convenience. The generator always includes the base unit so every selected quantity remains
convertible. It reports compile-time diagnostics for invalid expressions and patterns that match no
units.

Custom quantities use JSON definition files. The custom MSBuild item is converted to Roslyn
`AdditionalFiles` by package assets under `buildTransitive/`:

```xml
<ItemGroup>
  <UnitsNetGenDefinition Include="HowMuch.unitsnet.json" />
</ItemGroup>
```

The package registers `UnitsNetGenDefinition` as compiler-visible `AdditionalFiles` metadata early
from a `.props` file, then maps the consumer item after project items are evaluated from a `.targets`
file. This split keeps CLI and IDE design-time generator inputs consistent, including ordinary
filenames such as `Length.json` that cannot be identified by extension alone.

The JSON shape follows the existing UnitsNet quantity definitions and adds an optional `Namespace`
for stable third-party identity; it defaults to `UnitsNetGen`, allowing files such as the existing
`Length.json` to be consumed unchanged. It supports localized abbreviations, prefix expansion, and
`FromUnitToBaseFunc`/`FromBaseToUnitFunc` expressions. A minimal marker binds type-safe module
selection to the JSON's logical `Namespace.Name` ID:

```csharp
namespace Fictional;

using UnitsNetGen.Generation;

[QuantityDefinition("Fictional.Measurements.HowMuch")]
public interface HowMuchDefinition;

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchDefinition>;
```

Definitions are read with `System.Text.Json`. Its .NET Standard support assemblies are bundled
privately beside the analyzer, while the generated/runtime library has no JSON-library dependency.
Conversion expressions are parsed as C# expressions and restricted to numeric literals, `x`,
arithmetic operators, parentheses, `Math.PI`, `Math.E`, and an allowlist of numeric `Math` functions.
The generator emits the validated expressions directly into conversion switches; it does not compile
expressions or use reflection at runtime. A definition package can contain public marker types and
JSON definitions while the module that selects them owns the generated runtime types.

## Projects

- `UnitsNetGen`: the lean runtime and the new `IQuantity<TUnit>` contract.
- `UnitsNetGen.Generator`: the incremental generator, marker bootstrap source, built-in catalog,
  diagnostics, and emitters.
- `UnitsNetGen.Tests`: generated API and runtime behavior tests.
- `Samples/UnitsNetGen.AllSi.Sample`: all ten POC quantities and conditional derived-quantity operators.
- `Samples/UnitsNetGen.Lean.Sample`: Length plus only Mass units matching `regex:.*Gram$`.
- `Samples/UnitsNetGen.Custom.Sample`: a fictional `HowMuch` quantity in its own namespace.
- `Samples/UnitsNetGen.NetStandard.Sample`: compile-time coverage for a generated module targeting `netstandard2.0`.
- `Samples/UnitsNetGen.NuGet.Sample`: an isolated real-consumer scenario using only a locally packed
  `PackageReference` and consumer-owned JSON.

The projects live in their own solution and do not participate in the existing UnitsNet solution.

The NuGet sample has a local-only MSBuild dependency that incrementally packs changed UnitsNetGen or
generator sources before restore, then refreshes its floating `1.0.0-local.*` package before
compilation. Its restore source is restricted to the shared `Artifacts/Nugets` development feed, so
it can never fall back to a published UnitsNetGen package. Running or building
`UnitsNetGen.NuGet.Sample` therefore uses the latest local source without introducing a project
reference or bypassing the NuGet package boundary.

The dependency can also be invoked explicitly:

```powershell
dotnet msbuild `
  UnitsNetGen/Samples/UnitsNetGen.NuGet.Sample/UnitsNetGen.NuGet.Sample.csproj `
  -t:UpdateLocalUnitsNetGenPackage
```

This repository-only automation defaults on for Debug builds and off for other configurations. Set
`UnitsNetGenSampleUpdateLocalPackageOnBuild=true` or `false` explicitly to override the default.

`RepositoryLocalNuGetFeed` in the root `Directory.Build.props` gives every repository project the
shared `Artifacts/Nugets` path. The repository-level `NuGet.Config` exposes it to solution-wide IDE
package tooling, and generated packages remain gitignored. The UnitsNetGen package project supports
a plain `dotnet pack UnitsNetGen/UnitsNetGen/UnitsNetGen.csproj`, which creates a unique
`1.0.0-local.*` package in that feed for the real-consumer sample. Since local versions are
prereleases, enable prerelease packages and refresh the feed in the IDE after packing. Pass
`-p:UnitsNetGenPackForPublish=true` to create the MinVer-derived publish version instead; CI sets this
explicitly.

Run `pwsh UnitsNetGen/Samples/UnitsNetGen.NuGet.Sample/run.ps1` from the repository root for the
clean-room check. The script provides an isolated package cache and disables repository
`Directory.Build.*` imports; the sample build dependency performs the pack and restore before
executing the consumer.

## Versioning and CI

The combined `UnitsNetGen` package uses MinVer with the tag prefix `UnitsNetGen/`, a minimum version
of `1.0`, and `alpha.0` as the default prerelease identifiers. Existing `UnitsNet/*`, `JsonNet/*`, and
unprefixed tags are ignored. A release tag such as `UnitsNetGen/1.0.0-alpha.1` or
`UnitsNetGen/1.0.0` becomes the exact package version. Untagged builds receive a MinVer-generated
alpha version with commit height. `UnitsNetGen.Generator` remains an internal, non-packable project
because its generated code requires the runtime shipped in the combined package.

The NuGet sample passes a timestamped `MinVerVersionOverride` so repeated packages containing
uncommitted changes remain unique. The package includes complete NuGet metadata, its README and icon,
XML API documentation, repository commit metadata, and portable PDBs in an `.snupkg`. GitHub Actions
enables `ContinuousIntegrationBuild`, producing deterministic CI packages with stable source paths
and Source Link metadata for the matching commit. Local development packages retain developer source
paths and may therefore be reported as non-deterministic by NuGet Package Explorer; they are not
publishing artifacts.

The separate `UnitsNetGen CI` workflow uses full Git history, builds and tests `UnitsNetGen.slnx`,
packs the combined package with its MinVer version, and uploads it as a workflow artifact. It does not
publish to NuGet.org.

## Analyzer dependency plumbing

`UnitsNetGen/Directory.Packages.props` and `UnitsNetGen/Directory.Build.targets` support development
with an analyzer `ProjectReference`; they are not copied into the shipped package. Project references
do not automatically expose private analyzer dependencies, so the local target points Roslyn at the
restored `System.Text.Json` support assemblies.

Packaged consumers do not configure any of this. The support assemblies are private files beside
`UnitsNetGen.Generator.dll` under `analyzers/dotnet/cs`, and the package declares no runtime dependency
on them. `_UnitsNetGenAnalyzerDependencyDirectory` is evaluated only while packing to locate those
files; it is not a consumer-facing MSBuild property or API.

## Framework targets

The `UnitsNetGen` package supplies runtime assets for `netstandard2.0` and `net10.0`. The generator
remains a `netstandard2.0` analyzer so current compiler hosts can load it regardless of the consumer
target. Executable samples and tests target .NET 10, while the dedicated .NET Standard sample proves
that the shared runtime and generated baseline API compile without newer framework contracts.

On .NET 10, generated quantities additionally implement `IParsable<TSelf>` and the applicable
generic-math operator interfaces from `System.Numerics`. This enables generic parsing, addition,
subtraction, scalar multiplication/division, and comparison without changing the portable API emitted
for `netstandard2.0`.

Further modern-target opportunities include allocation-free
`ISpanParsable<TSelf>`/`ISpanFormattable` paths, UTF-8 parsing and formatting, and optionally
abstracting the numeric storage type through generic math. Those require deliberate API and
performance design beyond this POC.

## Generated surface

For each selected definition, the generator emits:

- a unit enum containing only selected units;
- an immutable strongly typed quantity struct;
- typed `FromXxx()` factories and `.Xxx` conversion properties;
- `As()`, `ToUnit()`, `Parse()`, `TryParse()`, and `ToString()`;
- equality, comparison, same-quantity addition/subtraction, and scalar multiplication/division;
- .NET 10 generic parsing and generic-math contracts;
- localized unit metadata that delegates shared behavior to the runtime;
- direct, validated conversion switches for affine and nonlinear conversions.

When all operands/results are present, it also emits selected SI relationships:

- `Length * Length -> Area`
- `Length / Duration -> Speed`
- `Speed / Duration -> Acceleration`
- `Mass * Acceleration -> Force`
- `Force / Area -> Pressure`
- `Force * Length -> Energy`
- `Energy / Duration -> Power`

The relationship operators work in base units and return the result's base unit. They disappear when
a module omits one of the involved quantities, avoiding hidden dependencies.

## POC catalog

The embedded catalog is deliberately small: Length, Mass, Duration, Area, Speed, Acceleration, Force,
Pressure, Energy, and Power. JSON-backed custom definitions exercise multiple cultures, multiple
abbreviations, prefix expansion, arithmetic conversion expressions, and allowlisted nonlinear `Math`
functions.

## Deliberate limitations

- This is a design probe, not a compatibility layer for UnitsNet v6.
- Quantity values use `double` only.
- Serialization, unit systems, generic numeric storage, logarithmic quantity semantics, culture
  selection, and rich parse ambiguity handling are deferred.
- Regex/glob patterns filter expanded unit names, not abbreviations.
- Prefix expansion uses a common SI/binary prefix table; it does not yet reproduce every
  culture-specific prefix convention from UnitsNet v6.
- Third-party public API authors must ship a generated module to establish stable type identity.
- Multiple module marker interfaces in one project are merged into one generated set. Conflicting
  selections produce one union.

## What this POC should prove

1. Omitting a quantity prevents its type and metadata from entering the consumer assembly.
2. Unit patterns reduce the generated enum and typed API.
3. Built-in and custom quantities share the same runtime behavior and strongly typed surface.
4. Cross-quantity APIs can be conditional rather than forcing a monolithic dependency graph.
5. No runtime reflection or assembly scanning is required.
