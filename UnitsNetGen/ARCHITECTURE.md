# UnitsNetGen proof-of-concept architecture

## Goal

UnitsNetGen explores a compile-time composition model for a future UnitsNet architecture. A module
author selects only the quantities and units that belong in an assembly, while generated quantity
structs keep the strongly typed API and share a small runtime for conversion, parsing, and
formatting.

The generator, runtime, and generated types do not reuse the existing UnitsNet runtime or
code-generation model. UnitsNet and UnitsNetGen deliberately share the small `UnitsNet.Core`
contract assembly across the quantity catalog.

The experiment is inspired by
[the modular-package experiment](https://github.com/angularsen/UnitsNet/pull/1181),
[the source-generator discussion](https://github.com/angularsen/UnitsNet/issues/902), and
the current
[Roslyn source-generator model](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md).

## Feasibility conclusions

The idea is viable if the unit of composition is a **consumer-owned module assembly**:

1. A module declares an interface that selects quantity definitions.
2. One incremental generator resolves the selection and emits only the selected quantity and unit
   types into that module.
3. The application's domain, persistence, UI, and service projects reference that assembly normally.

The module boundary is important because a generated public type has the identity of the assembly
into which it is generated. If two unrelated assemblies both generate `Length`, those are distinct
CLR types. An application should therefore generate its quantities once in a shared internal
library, then reference that library everywhere else in the application.

Third parties publish **definition packages**, not compiled quantity structs. A definition package
contains JSON definitions, localizations, relationships, and small public definition markers. The
consumer remains responsible for selecting and compiling those definitions into its module.

Roslyn generators are additive and unordered; a generator cannot consume another generator's output
in the same compilation. Consequently, UnitsNetGen uses one generator for built-in and custom
definitions. Stable public authoring contracts live in the UnitsNetGen runtime so definition-marker
assemblies can reference one identity. Built-in catalog markers and profiles are internal bootstrap
source emitted during post-initialization.

## Developer experience

Select every unit for a built-in quantity by inheriting `IInclude<TDefinition>`:

```csharp
using UnitsNetGen.BuiltIns;
using UnitsNetGen.Generation;

[UnitsNetModule]
internal interface EngineeringUnits :
    IInclude<Length>,
    IInclude<Temperature>,
    IInclude<Information>
{
}
```

Pass a target namespace to the module attribute to generate a source-compatible concrete surface.
In compatibility mode, quantities use `UnitsNet` and unit enums use `UnitsNet.Units`:

```csharp
[UnitsNetModule("UnitsNet")]
internal interface CompatibilityUnits :
    IInclude<Length>,
    IInclude<Temperature>;
```

Select units with a regular expression by defining a named unit set:

```csharp
[UnitSet("regex:.*Meter$")]
internal interface MeterUnits;

[UnitsNetModule]
internal interface LeanUnits :
    IInclude<Length, MeterUnits>
{
}
```

Patterns prefixed with `regex:` use case-insensitive, culture-invariant regular expressions with a
timeout. Patterns prefixed with `glob:` support `*`, and bare patterns retain glob behavior for
convenience. The generator always includes the base unit so every selected quantity remains
convertible. It reports compile-time diagnostics for invalid expressions and patterns that match no
units.

Quantity profiles compose reusable catalog selections:

```csharp
using UnitsNetGen.Profiles;

[UnitsNetModule]
internal interface ApplicationUnits :
    IIncludeProfile<AllQuantities>,
    IInclude<HowMuchDefinition>;
```

`AllQuantities` contains the built-in catalog, while `AllSi` selects the SI relationship sample.
Consumers can define profiles from
`IInclude<TDefinition>` and nest them through `IIncludeProfile<TProfile>`. Profile selections are
defaults: direct selections on the module override a profile's unit selection for the same quantity.
The recommended application architecture has one module marker in its shared units project. Profiles
and direct includes compose the complete generated surface at that boundary.

Custom quantities use JSON definition files. The custom MSBuild item is converted to Roslyn
`AdditionalFiles` by package assets under `buildTransitive/`:

```xml
<ItemGroup>
  <UnitsNetGenDefinition Include="HowMuch.unitsnet.json" />
</ItemGroup>
```

The package registers `UnitsNetGenDefinition` as compiler-visible `AdditionalFiles` metadata early
from a `.props` file, then maps the consumer item after project items are evaluated from a
`.targets` file. This split keeps CLI and IDE design-time generator inputs consistent, including
ordinary filenames such as `Length.json` that cannot be identified by extension alone.

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
arithmetic operators, parentheses, `Math.PI`, `Math.E`, and an allowlist of numeric `Math`
functions.
The generator emits the validated expressions directly into conversion switches; it does not compile
expressions or use reflection at runtime. A definition package contains public marker types and JSON
definitions while the module that selects them owns the generated runtime types. Its package-local
`build/*.props` file exposes the JSON as compiler `AdditionalFiles` only to the project that
directly references it.

## Projects

- `UnitsNet.Core`: minimal modern value/unit contracts and a self-typed static contract shared by
  both implementations.
- `UnitsNetGen`: the lean conversion, parsing, formatting, and unit-metadata runtime.
- `UnitsNetGen.Generator`: the incremental generator, marker bootstrap source, built-in catalog,
  diagnostics, and emitters.
- `UnitsNetGen.Generator.Tests`: generator-driver coverage for diagnostics, stable output,
  incrementality, and all relationship shapes.
- `UnitsNetGen.Tests`: generated API and runtime behavior tests.
- `UnitsNetGen.Compatibility.Tests`: linked-output, selected public-API, unit-name, and
  shared-contract comparisons.
- `Samples/UnitsNetGen.AllSi.Sample`: the SI quantity chain from Length and Duration through Speed,
  Acceleration, Force, Pressure, Energy, and Power.
- `Samples/UnitsNetGen.Representative.Sample`: a varied catalog selection and conditional
  cross-quantity operators.
- `Samples/UnitsNetGen.Lean.Sample`: filtered Length and Information unit sets.
- `Samples/UnitsNetGen.Compatibility.UnitsNet.Sample`: the shared compatibility consumer using
  UnitsNet v6.
- `Samples/UnitsNetGen.Compatibility.Generated.Sample`: the exact same linked consumer source using
  generated quantities.
- `Samples/UnitsNetGen.Custom.Sample`: a fictional `HowMuch` quantity in its own namespace.
- `Samples/UnitsNetGen.NuGet.Sample`: an isolated real-consumer scenario using only a locally packed
  `PackageReference` and consumer-owned JSON.
- `Samples/DefinitionPackages/Fictional.Measurements.Definitions`: a packable definition-only NuGet
  containing markers, JSON definitions, localization, and structured relationships.
- `Samples/ConsumerOwned/ConsumerOwned.Units`: the package-facing application-owned generation
  boundary. It consumes locally packed runtime and definition packages.
- `Samples/ConsumerOwned/ConsumerOwned.Units.ProjectReferences`: a maintainer-facing twin that
  compiles the same linked module declaration with direct project references and explicit
  definition files.
- `Samples/ConsumerOwned/ConsumerOwned.Domain` and `ConsumerOwned.Reporting`: two downstream
  consumers sharing the exact generated CLR types from `ConsumerOwned.Units`.

Feature and compatibility samples use project references because they exercise generated behavior
inside this repository. `UnitsNetGen.NuGet.Sample` and `ConsumerOwned.Units` deliberately cross the
local package boundary: the former covers a minimal consumer-owned definition, while the latter
composes a separately packed definition recipe into a shared application assembly.

The compatibility test project uses aliased references to compare both implementations' selected
public API and unit names without introducing concrete-type ambiguity. The projects live in their
own solution and do not participate in the existing UnitsNet solution.

## Compatibility boundaries

The linked-source samples establish source compatibility for factories, properties, unit enums,
conversions, parsing, formatting, and operators. Compatibility tests compare the selected public
surfaces, enum names and stable values, runtime output, and shared Core contract behavior.

`UnitsNet.Core.IQuantity<TValue>` exposes only the stored numeric value.
`UnitsNet.Core.IQuantity<TUnit, TValue>` additionally exposes its strongly typed stored unit.
`UnitsNet.Core.IQuantity<TSelf, TUnit, TValue>` adds static semantic identity, base unit, and
construction together with strongly typed conversion. A generic library can therefore consume,
create, or convert either implementation even though their concrete types differ.

The Core capability hierarchy adapts UnitsNet's proven modern generic design without carrying over
`UnitKey`, quantity metadata, setup registries, or obsolete compatibility members:

- `ILinearQuantity<TSelf, TUnit>` advertises conventional arithmetic and additive zero;
- `IAffineQuantity<TSelf, TUnit>` identifies offset conversions without claiming conventional
  same-quantity arithmetic;
- `ILogarithmicQuantity<TSelf, TUnit>` identifies logarithmic arithmetic and scaling without
  claiming conventional generic-math semantics.

`QuantityMath.Sum` and `QuantityMath.Average` use those contracts for reusable mixed-unit linear
algorithms shared by UnitsNet and UnitsNetGen. The capability layer remains `double`-based while
numeric storage abstraction is evaluated separately.

`QuantityId` belongs to the quantity type rather than each value instance. Base-unit conversion is
derived behavior and is intentionally not part of the instance contract. Generated relationships
and equality use internal conversion helpers; reusable public conversion behavior belongs in
the quantity contract and algorithms backed by immutable definition metadata. Internal base values
are sufficient for relationships because all participating recipe quantities are generated into
one consumer-owned assembly; independently compiled modules cannot acquire cross-module operators.

UnitsNetGen deliberately does not emit substitute copies of legacy `UnitsNet.IQuantity` interfaces.
Exact legacy interface identity would require moving those interfaces to a canonical assembly and
coordinating that change with UnitsNet itself. The prototype instead targets concrete source
compatibility and the clean shared contracts.

The experiment does not provide binary compatibility between concrete quantity structs. CLR type
identity includes the defining assembly, so `UnitsNet.Length` from `UnitsNet.dll` and a type with
the same full name generated into an application assembly are not assignment-compatible.
Projects inside one application share its consumer-owned module. Independent applications exchange
shared contracts or explicit serialized data instead of assuming their generated structs have the
same identity.

The `UnitsNet.Core` project is a separate signed assembly and prerelease package. Local packing
gives Core and UnitsNetGen the same unique development version, packs them to the same output
directory, and records Core as a package dependency. This avoids stale same-version Core packages
in the NuGet cache while keeping the real-consumer samples and CI artifacts self-contained.

The package-facing samples import one repository-only MSBuild target that incrementally packs
changed UnitsNetGen or generator sources before restore, then refreshes their floating
`1.0.0-local.dev.*` dependencies before compilation. `ConsumerOwned.Units` registers the fictional
definition provider as an additional package, so the automation packs the runtime first and the
definition recipe second with the same unique version. Restore is restricted to the shared
`Artifacts/Nugets` development feed and can never fall back to a published package.

The dependency can also be invoked explicitly:

```powershell
dotnet msbuild `
  UnitsNetGen/Samples/UnitsNetGen.NuGet.Sample/UnitsNetGen.NuGet.Sample.csproj `
  -t:UpdateLocalUnitsNetGenPackages
```

This repository-only automation defaults on for Debug builds and off for other configurations. Set
`UnitsNetGenSampleUpdateLocalPackagesOnBuild=true` or `false` explicitly to override the default.
The older singular property and target names remain aliases for existing local commands.

`RepositoryLocalNuGetFeed` in the root `Directory.Build.props` gives every repository project the
shared `Artifacts/Nugets` path. The repository-level `NuGet.Config` exposes it to solution-wide IDE
package tooling, and generated packages remain gitignored. The UnitsNetGen package project supports
a plain `dotnet pack UnitsNetGen/UnitsNetGen/UnitsNetGen.csproj`, which creates a unique
`1.0.0-local.dev.*` package in that feed for the real-consumer samples. The dedicated `dev`
identifier prevents another local prerelease label from shadowing the floating dependency. Local
development versions are prereleases, so enable prerelease packages and refresh the feed in the IDE
after packing. Pass
`-p:UnitsNetGenPackForPublish=true` to create the MinVer-derived publish version instead; CI sets
this explicitly.

Run `pwsh UnitsNetGen/Samples/UnitsNetGen.NuGet.Sample/run.ps1` from the repository root for the
clean-room check. The script provides an isolated package cache and disables repository
`Directory.Build.*` imports; the sample build dependency performs the pack and restore before
executing the consumer.

## Versioning and CI

The combined `UnitsNetGen` package uses MinVer with the tag prefix `UnitsNetGen/`, a minimum version
of `1.0`, and `alpha.0` as the default prerelease identifiers. Existing `UnitsNet/*`, `JsonNet/*`,
and unprefixed tags are ignored. A release tag such as `UnitsNetGen/1.0.0-alpha.1` or
`UnitsNetGen/1.0.0` becomes the exact package version. Untagged builds receive a MinVer-generated
alpha version with commit height. `UnitsNetGen.Generator` remains an internal, non-packable project
because its generated code requires the runtime shipped in the combined package.

The local package automation passes a timestamped `MinVerVersionOverride` so repeated packages
containing uncommitted changes remain unique. The package includes complete NuGet metadata,
including its README, icon, XML API documentation, repository commit metadata, and portable PDBs
in an `.snupkg`.
GitHub Actions enables `ContinuousIntegrationBuild`, producing deterministic CI packages with
stable source paths
and Source Link metadata for the matching commit. Local development packages retain developer source
paths and may therefore be reported as non-deterministic by NuGet Package Explorer; they are not
publishing artifacts.

The separate `UnitsNetGen CI` workflow uses full Git history, builds and tests `UnitsNetGen.slnx`,
runs the minimal NuGet consumer with an isolated package cache, packs the combined package with its
MinVer version, and uploads it as a workflow artifact. It does not publish to NuGet.org.

## Analyzer dependency plumbing

`UnitsNetGen/Directory.Packages.props` and `UnitsNetGen/Directory.Build.targets` support development
with an analyzer `ProjectReference`; they are not copied into the shipped package. Project
references do not automatically expose private analyzer dependencies. The local target therefore
points Roslyn at the restored `System.Text.Json` support assemblies.

Packaged consumers do not configure any of this. The support assemblies are private files beside
`UnitsNetGen.Generator.dll` under `analyzers/dotnet/cs`, and the package declares no runtime
dependency on them. `_UnitsNetGenAnalyzerDependencyDirectory` is evaluated only while packing to
locate those
files; it is not a consumer-facing MSBuild property or API.

## Framework targets

The `UnitsNetGen` runtime and `UnitsNet.Core` supply assets for .NET 8, 9, and 10. The modern
UnitsNet v6 assets implement the shared Core contracts. Its existing `netstandard2.0` asset retains
the legacy API without referencing Core or exposing the experimental contracts.

The generator remains a `netstandard2.0` analyzer solely so current compiler and IDE hosts can load
it regardless of the consumer target. That analyzer target is an implementation constraint, not
runtime support for generated quantity modules.

On all supported runtime targets, generated quantities implement `IParsable<TSelf>` and applicable
Core capability and generic-math interfaces. Linear quantities support conventional arithmetic and
shared aggregation; affine quantities avoid same-quantity arithmetic; logarithmic quantities keep
their explicit logarithmic behavior. All generated quantities support generic comparison.

Further modern-target opportunities include allocation-free
`ISpanParsable<TSelf>`/`ISpanFormattable` paths, UTF-8 parsing and formatting, and optionally
abstracting the numeric storage type through generic math. Those require deliberate API and
performance design beyond this POC.

## Generated surface

For each selected definition, the generator emits:

- a unit enum containing only selected units;
- an immutable strongly typed quantity struct;
- typed `FromXxx()` factories, a generic `From(value, unit)` factory, and `.Xxx` conversion
  properties;
- static semantic identity and base-unit members through the self-typed Core contract;
- `As()`, `ToUnit()`, `Parse()`, `TryParse()`, and `ToString()`;
- default values normalized to zero in the base unit, matching UnitsNet;
- arithmetic selected by the definition's linear, affine, or logarithmic semantics;
- modern .NET generic parsing, comparison, and capability contracts;
- localized unit metadata that delegates shared behavior to the runtime;
- direct, validated conversion switches for affine and nonlinear conversions.

When all operands and results are selected, the generator emits relationships such as:

- `Length * Length -> Area`
- `Length / Duration -> Speed`
- `Speed / Duration -> Acceleration`
- `Mass * Acceleration -> Force`
- `Force / Area -> Pressure`
- `Force * Speed -> Power`
- `Power * Duration -> Energy`
- `Energy / Duration -> Power`

Relationship operators convert through the anchor units named by each equation. Selecting the
participating quantities controls whether an operator exists; anchor units do not need to be exposed
in the generated public unit enums. The generator uses the full immutable definitions to inline the
necessary private conversions and constructs the result in its selected base unit.

The built-in inventory comes from `Common/UnitRelations.json` rather than hardcoded quantity names.
The relation pipeline resolves endpoints globally by semantic quantity ID, generates both operand
orders for commutative multiplication, infers division, and honors `NoInferredDivision`. Generated
types may remain in different CLR namespaces because emitted signatures use fully qualified names.

Third-party packages and applications can add structured semantic relationships through
`UnitsNetGenRelation` MSBuild items:

```json
[
  {
    "result": { "quantity": "Fictional.HowMuchDistance", "unit": "SomeMeter" },
    "left": { "quantity": "Fictional.HowMuch", "unit": "Some" },
    "operator": "*",
    "right": { "quantity": "UnitsNet.Length", "unit": "Meter" }
  }
]
```

The existing UnitsNet string equations remain supported and are normalized to the same semantic
model. Structured relations are preferred for third-party packages because semantic IDs remain
unambiguous across namespaces.

## Catalog

The catalog model is designed for all UnitsNet quantity and unit definitions. Definitions come from
the UnitsNet JSON catalog and cover linear, affine, and logarithmic behavior; SI, non-SI,
decimal-prefix, and binary-prefix units; localized abbreviations; and cross-quantity relationships.

`AllQuantities` selects the available built-in catalog. `AllSi` exercises the complete SI
relationship chain in a focused sample, while the representative sample provides a faster varied
selection for
day-to-day generator iteration. JSON-backed third-party definitions participate in the same
selection, profile, conversion, localization, and relationship model as built-ins.

## Deliberate limitations

- This is a design probe for a future architecture, not yet a committed replacement for UnitsNet v6.
- Quantity values use `double` only.
- Serialization, unit systems, generic numeric storage, culture selection, and rich parse ambiguity
  handling are deferred.
- Regex/glob patterns filter expanded unit names, not abbreviations.
- Prefix expansion uses a common SI/binary prefix table; it does not yet reproduce every
  culture-specific prefix convention from UnitsNet v6.
- Definition packages contain recipes, not quantity structs. Independently generated application
  modules intentionally have distinct CLR type identities.
- The supported application pattern uses one module marker in one consumer-owned units project.
- Canonical precompiled third-party modules and operators between independently compiled modules are
  outside this prototype's scope.

## What this POC should prove

1. Omitting a quantity prevents its type and metadata from entering the consumer assembly.
2. Unit patterns reduce the generated enum and typed API.
3. Built-in and custom quantities share the same runtime behavior and strongly typed surface.
4. Cross-quantity APIs can be conditional rather than forcing a monolithic dependency graph.
5. No runtime reflection or assembly scanning is required.
