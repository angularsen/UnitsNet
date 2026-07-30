# UnitsNet Modular proof-of-concept architecture

## Goal

UnitsNet.Modular explores a compile-time composition model for a future UnitsNet architecture. A module
author selects only the quantities and units that belong in an assembly, while generated quantity
structs keep the strongly typed API and share a small runtime for conversion, parsing, and
formatting.

The generator, runtime, and generated types do not reuse the existing UnitsNet runtime or
code-generation model. UnitsNet.Modular uses the small `UnitsNet.Core` contract assembly. The contracts
are designed for possible adoption by UnitsNet, but that integration is kept separate from the
standalone proof of concept.

The experiment is inspired by
[the modular-package experiment](https://github.com/angularsen/UnitsNet/pull/1181),
[the source-generator discussion](https://github.com/angularsen/UnitsNet/issues/902), and
the current
[Roslyn source-generator model](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md).

## Feasibility conclusions

The idea is viable if the unit of composition is a **consumer-owned module assembly**:

1. A module declares an interface that selects quantity specs.
2. One incremental generator resolves the selection and emits only the selected quantity and unit
   types into that module.
3. The application's domain, persistence, UI, and service projects reference that assembly normally.

The module boundary is important because a generated public type has the identity of the assembly
into which it is generated. If two unrelated assemblies both generate `Length`, those are distinct
CLR types. An application should therefore generate its quantities once in a shared internal
library, then reference that library everywhere else in the application.

Third parties publish **definition packages**, not compiled quantity structs. A definition package
contains JSON definitions, localizations, relationships, and small public quantity specs. The
consumer remains responsible for selecting and compiling those definitions into its module.

Roslyn generators are additive and unordered; a generator cannot consume another generator's output
in the same compilation. Consequently, UnitsNet.Modular uses one generator for built-in and custom
definitions. Stable public authoring contracts live in the UnitsNet.Modular runtime so definition-package
assemblies can reference one identity. Built-in catalog specs and profiles are internal bootstrap
source emitted during post-initialization.

## Developer experience

Authoring types use role-specific suffixes: quantity recipes are `*Spec`, reusable unit filters are
`*UnitSet`, and reusable selection groups are `*Profile`. This keeps an input such as `LengthSpec`
visually distinct from the generated `Length` quantity and `LengthUnit` enum.

Select every unit for a built-in quantity by inheriting `IInclude<TQuantitySpec>`:

```csharp
using UnitsNet.Modular.BuiltIns;
using UnitsNet.Modular;

[UnitsNetModule]
internal interface EngineeringUnits :
    IInclude<LengthSpec>,
    IInclude<TemperatureSpec>,
    IInclude<TemperatureDeltaSpec>,
    IInclude<InformationSpec>
{
}
```

Built-in recipes generate a source-compatible concrete surface by default: quantities use
`UnitsNet` and unit enums use `UnitsNet.Units`:

```csharp
[UnitsNetModule]
internal interface CompatibilityUnits :
    IInclude<LengthSpec>,
    IInclude<TemperatureSpec>,
    IInclude<TemperatureDeltaSpec>;
```

An explicit module target namespace remains available for side-by-side experiments or applications
that want every selected built-in and custom definition under one namespace.

Select units with a regular expression by defining a named unit set:

```csharp
[UnitSet("regex:.*Meter$")]
internal interface MeterUnitSet;

[UnitsNetModule]
internal interface LeanUnits :
    IInclude<LengthSpec, MeterUnitSet>
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
using UnitsNet.Modular.Profiles;

[UnitsNetModule]
internal interface ApplicationUnits :
    IIncludeProfile<AllQuantitiesProfile>,
    IInclude<HowMuchSpec>;
```

`AllQuantitiesProfile` contains the built-in catalog, while `AllSiProfile` selects the SI
relationship sample.
Consumers can define profiles from
`IInclude<TQuantitySpec>` and nest them through `IIncludeProfile<TProfile>`. Profile selections are
defaults: direct selections on the module override a profile's unit selection for the same quantity.
The recommended application architecture has one module marker in its shared units project. Profiles
and direct includes compose the complete generated surface at that boundary.

Custom quantities use JSON definition files. Consumers should include them with Roslyn's native
`AdditionalFiles` item:

```xml
<ItemGroup>
  <AdditionalFiles Include="HowMuch.unitsnet.json"
                   UnitsNetDefinition="true" />
</ItemGroup>
```

The metadata identifies ordinary filenames such as `Length.json` that cannot be recognized by
extension alone. Files named `*.unitsnet.json` are also recognized by convention, but explicit
metadata documents their role and works for either naming scheme.

Package assets under `buildTransitive/` retain `UnitsNetDefinition` and `UnitsNetRelation` as
convenience aliases. A `.targets` file maps those custom items to compiler `AdditionalFiles`, while
a `.props` file makes their metadata compiler-visible. They work with command-line MSBuild, but
native `AdditionalFiles` is the portable public syntax because some IDE project models, including
Rider, ignore custom build actions before running their design-time Roslyn host.

The JSON shape follows the existing UnitsNet quantity definitions and adds an optional `Namespace`
for stable third-party identity; it defaults to `UnitsNet`, allowing files such as the existing
`Length.json` to be consumed unchanged. It supports localized abbreviations, prefix expansion, and
`FromUnitToBaseFunc`/`FromBaseToUnitFunc` expressions. A minimal quantity spec binds type-safe module
selection to the JSON's logical `Namespace.Name` ID:

```csharp
namespace Fictional;

using UnitsNet.Modular;

[QuantityDefinition("Fictional.Measurements.HowMuch")]
public interface HowMuchSpec;

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchSpec>;
```

Definitions are read with `System.Text.Json`. Its .NET Standard support assemblies are bundled
privately beside the analyzer, while the generated/runtime library has no JSON-library dependency.
Conversion expressions are parsed as C# expressions and restricted to numeric literals, `x`,
arithmetic operators, parentheses, `Math.PI`, `Math.E`, and an allowlist of numeric `Math`
functions.
The generator emits the validated expressions directly into conversion switches; it does not compile
expressions or use reflection at runtime. A definition package contains public quantity specs and JSON
definitions while the module that selects them owns the generated runtime types. Its package-local
`build/*.props` file exposes the JSON as compiler `AdditionalFiles` only to the project that
directly references it.

## Projects

- `UnitsNet.Core`: minimal modern value/unit contracts and a self-typed static contract used by
  generated quantities, with UnitsNet adoption explored separately.
- `UnitsNet.Modular`: the lean conversion, parsing, formatting, and unit-metadata runtime.
- `UnitsNet.Modular.Generator`: the incremental generator, spec bootstrap source, built-in catalog,
  diagnostics, and emitters.
- `UnitsNet.Modular.Generator.Tests`: generator-driver coverage for diagnostics, stable output,
  incrementality, and all relationship shapes.
- `UnitsNet.Modular.Tests`: generated API and runtime behavior tests.
- `UnitsNet.Modular.Compatibility.Tests`: linked-output, full-catalog public API, enum, conversion,
  parsing, formatting, behavior, and registry comparisons against unchanged UnitsNet.
- `Samples/UnitsNet.Modular.AllSi.Sample`: the SI quantity chain from Length and Duration through Speed,
  Acceleration, Force, Pressure, Energy, and Power.
- `Samples/UnitsNet.Modular.Representative.Sample`: a varied catalog selection and conditional
  cross-quantity operators.
- `Samples/UnitsNet.Modular.Lean.Sample`: filtered Length and Information unit sets.
- `Samples/UnitsNet.Modular.Compatibility.UnitsNet.Sample`: the shared compatibility consumer using
  UnitsNet v6.
- `Samples/UnitsNet.Modular.Compatibility.Generated.Sample`: the exact same linked consumer source using
  generated quantities.
- `Samples/UnitsNet.Modular.Custom.Sample`: a fictional `HowMuch` quantity in its own namespace.
- `Samples/UnitsNet.Modular.NuGet.Sample`: an isolated real-consumer scenario using only a locally packed
  `PackageReference` and consumer-owned JSON.
- `Samples/DefinitionPackages/Fictional.Measurements.Definitions`: a packable definition-only NuGet
  containing quantity specs, JSON definitions, localization, and structured relationships.
- `Samples/ConsumerOwned/ConsumerOwned.Units`: the package-facing application-owned generation
  boundary. It consumes locally packed runtime and definition packages.
- `Samples/ConsumerOwned/ConsumerOwned.Units.ProjectReferences`: a maintainer-facing twin that
  compiles the same linked module declaration with direct project references and explicit
  definition files.
- `Samples/ConsumerOwned/ConsumerOwned.Domain` and `ConsumerOwned.Reporting`: two downstream
  consumers sharing the exact generated CLR types from `ConsumerOwned.Units`.

Feature and compatibility samples use project references because they exercise generated behavior
inside this repository. `UnitsNet.Modular.NuGet.Sample` and `ConsumerOwned.Units` deliberately cross the
local package boundary: the former covers a minimal consumer-owned definition, while the latter
composes a separately packed definition recipe into a shared application assembly.

The compatibility test project uses aliased references to compare both implementations' selected
public API and unit names without introducing concrete-type ambiguity. It compares against the
unchanged UnitsNet project; Core contract adoption by UnitsNet is tested only on the separate
integration branch. The projects live in their own solution and do not participate in the existing
UnitsNet solution.

## Compatibility boundaries

The linked-source samples establish source compatibility for factories, properties, unit enums,
conversions, parsing, formatting, collection extensions, and operators. Catalog-wide compatibility
tests compare all 129 generated quantities and their unit enums with the unchanged UnitsNet source.
They exercise every unit's conversion through its base unit, base-unit formatting and parsing,
default and strict equality behavior, affine and logarithmic arithmetic, and representative
exceptions.

The declared-public-surface gate compares constructors, properties, methods, and operators. Every
accepted difference is categorized in the test: legacy mutable metadata and setup APIs that are not
part of the clean architecture, or a remaining quantity-specific handwritten UnitsNet API.
`Duration`/`TimeSpan` interoperability, `Area` circle construction, relation-backed mechanics and
chemistry helpers, concentration conversions, apparent-power division, and combustion energy are
represented as explicit built-in recipe augmentations rather than silent exceptions. This also
covers immutable dBV/dBW reference conversions, scalar compound-unit construction, and the
`FeetInches`, `StonePounds`, and `ReferencePressure` companion types. The generator reads
augmentation and companion kinds plus quantity and unit dependencies from immutable embedded data;
dependent APIs are emitted only when all participating quantities and constituent units are
selected. Companion types remain an explicit opt-in recipe with a dedicated emitter; their presence
is never inferred from a quantity or its units. This inventory is a migration tool, not a claim that
every legacy API belongs in the final architecture.

Two handwritten APIs remain intentionally excluded. `Length.ParseFeetInches` and
`TryParseFeetInches` depend on a specialized text grammar, while `Pressure.FromElevation` and
`ToElevation` implement an empirical atmosphere model rather than unit conversion. The
compatibility suite requires every exclusion to identify an existing UnitsNet member and provide a
non-empty rationale, so stale exclusions fail the test.

`UnitsNet.Core.IQuantity<TValue>` exposes only the stored numeric value.
`UnitsNet.Core.IQuantity<TUnit, TValue>` additionally exposes its strongly typed stored unit.
`UnitsNet.Core.IQuantity<TSelf, TUnit, TValue>` adds static semantic identity, base unit,
construction, and a static conversion primitive. Its default instance behavior composes these
members, while concrete quantities still expose generated `As()` and `ToUnit()` methods for normal
strongly typed use. A generic library can therefore consume, create, or convert either
generated implementation. A future UnitsNet integration can implement the same contract even though
its concrete types differ.

The Core capability hierarchy adapts UnitsNet's proven modern generic design without carrying over
`UnitKey`, quantity metadata, setup registries, or obsolete compatibility members:

- `ILinearQuantity<TSelf, TUnit>` advertises conventional arithmetic and additive zero;
- `IAffineQuantity<TSelf, TUnit, TOffset>` identifies offset conversions and expresses differences
  through a linear offset quantity without claiming conventional same-quantity arithmetic;
- `ILogarithmicQuantity<TSelf, TUnit>` identifies logarithmic arithmetic and scaling without
  claiming conventional generic-math semantics.

`QuantityMath.Sum` and `QuantityMath.Average` use those contracts for reusable mixed-unit linear
algorithms over generated quantities. `AffineQuantityMath.Average` averages affine values in an
explicit target unit. `LogarithmicQuantityMath` supplies logarithmic sum and mean semantics.
Generated concrete extension methods expose these algorithms as `Sum`, `Average`,
`ArithmeticMean`, `GeometricMean`, `Abs`, and tolerance-aware `Equals`, so normal application code
does not need generic call syntax. A separate integration branch validates these algorithms with
UnitsNet v6. The capability layer remains `double`-based while numeric storage abstraction is
evaluated separately.

`QuantityId` belongs to the quantity type rather than each value instance. Base-unit conversion is
derived behavior and is intentionally not stored on each instance. Generated relationships and
equality use internal conversion helpers; reusable public conversion behavior belongs in the
self-typed quantity contract and is backed by immutable definition metadata. There is no global
conversion registry: compile-time definition recipes generate the selected converters directly
into the consumer-owned assembly. Internal base values are sufficient for relationships because
all participating recipe quantities are generated into that assembly; independently compiled
modules cannot acquire cross-module operators.

Semantic IDs are namespace-qualified (`Namespace.Name`) and definition-package authors should use
a namespace they own. This makes IDs stable and globally meaningful at registry and serialization
boundaries without adding vendor state to each quantity value.

Each module does have an immutable generated **discovery registry**. It describes only that
module's selected quantities and supports lookup by semantic ID, quantity name, or generated CLR
type. Descriptors expose units, abbreviations, base dimensions, construction, conversion, parsing,
formatting data, and stored value/unit access. Frozen dictionaries make lookup immutable after
module initialization. This registry is not a source of conversion policy and is not a replacement
for the old mutable `UnitsNetSetup` model.

The same descriptors back a generated System.Text.Json converter factory. Its quantity dispatch is
emitted as direct type checks and generic converter construction, with no runtime
`MakeGenericType`, assembly scan, or mutable registration. It is therefore suitable for trimming
and Native AOT. Serialized data still forms an application-owned compatibility boundary; the
registry does not make independently generated CLR types binary compatible.

UnitsNet.Modular deliberately does not emit substitute copies of legacy `UnitsNet.IQuantity` interfaces.
Exact legacy interface identity would require moving those interfaces to a canonical assembly and
coordinating that change with UnitsNet itself. The prototype instead targets concrete source
compatibility and the clean shared contracts.

The legacy compatibility review concluded that common read-only dynamic workflows belong on the
immutable module registry, with a thin owner-scoped `Quantity` facade for familiar static call
shapes. The facade returns `UnitsNet.Core.IQuantity<double>` and delegates to its exposed
`Quantity.Registry`; it does not introduce a second catalog. Construction, type-directed parsing,
metadata discovery, and non-throwing input paths are tested against their UnitsNet counterparts.

The review rejected mutable legacy behavior, not static convenience. `UnitsNetSetup`, mutable
conversion registration, abbreviation-cache mutation, and mutable global defaults express
process-wide runtime policy that conflicts with consumer-owned compile-time definitions.
UnitsNet.Modular instead provides immutable, owner-neutral `UnitSystem` and `BaseUnits` values that are
passed explicitly to generated constructors, `From`, `As`, and `ToUnit`, or to the facade,
descriptors, and registry. Resolution is restricted to selected units. Generated constituent
metadata and SI selection are checked catalog-wide against UnitsNet, including exponent-aware
prefix metadata and legacy first-match ordering. `UnitKey` is unnecessary in strongly typed code;
dynamic and serialized boundaries use semantic quantity IDs plus invariant unit names. The
complete workflow matrix is in `MIGRATION.md`.

The experiment does not provide binary compatibility between concrete quantity structs. CLR type
identity includes the defining assembly, so `UnitsNet.Length` from `UnitsNet.dll` and a type with
the same full name generated into an application assembly are not assignment-compatible.
Projects inside one application share its consumer-owned module. Independent applications exchange
shared contracts or explicit serialized data instead of assuming their generated structs have the
same identity.

The `UnitsNet.Core` project is a separate signed assembly and prerelease package. Local packing
gives Core and UnitsNet.Modular the same unique development version, packs them to the same output
directory, and records Core as a package dependency. This avoids stale same-version Core packages
in the NuGet cache while keeping the real-consumer samples and CI artifacts self-contained.

The package-facing samples import one repository-only MSBuild target that incrementally packs
changed UnitsNet.Modular or generator sources before restore, then refreshes their floating
`6.0.0-local.dev.*` dependencies before compilation. `ConsumerOwned.Units` registers the fictional
definition provider as an additional package, so the automation packs the runtime first and the
definition recipe second with the same unique version. Restore is restricted to the shared
`Artifacts/Nugets` development feed and can never fall back to a published package.

The dependency can also be invoked explicitly:

```powershell
dotnet msbuild `
  UnitsNet.Modular/Samples/UnitsNet.Modular.NuGet.Sample/UnitsNet.Modular.NuGet.Sample.csproj `
  -t:UpdateLocalUnitsNetModularPackages
```

This repository-only automation defaults on for Debug builds and off for other configurations. Set
`UnitsNetModularSampleUpdateLocalPackagesOnBuild=true` or `false` explicitly to override the default.
The older singular property and target names remain aliases for existing local commands.

`RepositoryLocalNuGetFeed` in the root `Directory.Build.props` gives every repository project the
shared `Artifacts/Nugets` path. The repository-level `NuGet.Config` exposes it to solution-wide IDE
package tooling, and generated packages remain gitignored. The UnitsNet.Modular package project supports
a plain `dotnet pack UnitsNet.Modular/UnitsNet.Modular/UnitsNet.Modular.csproj`, which creates a unique
`6.0.0-local.dev.*` package in that feed for the real-consumer samples. The dedicated `dev`
identifier prevents another local prerelease label from shadowing the floating dependency. Local
development versions are prereleases, so enable prerelease packages and refresh the feed in the IDE
after packing. Pass
`-p:UnitsNetModularPackForPublish=true` to create the MinVer-derived publish version instead; CI sets
this explicitly.

Run `pwsh UnitsNet.Modular/Samples/UnitsNet.Modular.NuGet.Sample/run.ps1` from the repository root for the
clean-room check. The script provides an isolated package cache and disables repository
`Directory.Build.*` imports; the sample build dependency performs the pack and restore before
executing the consumer.

## Versioning and CI

The combined `UnitsNet.Modular` package and its `UnitsNet.Core` dependency share one MinVer release
stream with the tag prefix `UnitsNet.Modular/`, a minimum version of `6.0`, and `alpha.0` as the
default prerelease identifiers. Existing `UnitsNet/*`, `JsonNet/*`, and unprefixed tags are ignored.
A release tag such as `UnitsNet.Modular/6.0.0-alpha.1` or `UnitsNet.Modular/6.0.0` becomes the exact
version of both packages. Untagged builds give both packages the same MinVer-generated alpha version
with commit height. Keeping their versions in lockstep makes the package dependency and release
process explicit while Core is shipped as part of the Modular product. `UnitsNet.Modular.Generator`
remains an internal, non-packable project because its generated code requires the runtime shipped in
the combined package.

UnitsNet, UnitsNet.Modular, and UnitsNet.Core share major version 6 to communicate the catalog
generation they belong to. UnitsNet retains its existing explicitly controlled version, while
UnitsNet.Modular and UnitsNet.Core advance together. Third-party definition packages have independent
versions; the fictional sample remains at 1.x when packed directly.

Create an annotated release tag on a green `master` commit and push it:

```powershell
git tag -a UnitsNet.Modular/6.0.0-alpha.1 -m "UnitsNet.Modular 6.0.0-alpha.1"
git push origin UnitsNet.Modular/6.0.0-alpha.1
```

This single tag versions and publishes both packages. Do not create `UnitsNet.Core/*` release tags.

The local package automation passes a timestamped `MinVerVersionOverride` so repeated packages
containing uncommitted changes remain unique. The package includes complete NuGet metadata,
including its README, icon, XML API documentation, repository commit metadata, and portable PDBs
in an `.snupkg`.
GitHub Actions enables `ContinuousIntegrationBuild`, producing deterministic CI packages with
stable source paths
and Source Link metadata for the matching commit. Local development packages retain developer source
paths and may therefore be reported as non-deterministic by NuGet Package Explorer; they are not
publishing artifacts.

The separate `UnitsNet.Modular CI` workflow uses full Git history, builds and tests `UnitsNet.Modular.slnx`,
runs the minimal NuGet consumer with an isolated package cache, packs the combined package with its
MinVer version, and uploads it as a workflow artifact. Upstream pushes to `master` stop there.
`UnitsNet.Modular/*` tag pushes additionally publish the exact tagged version to NuGet.org, and a
manual run from such a tag can opt into publishing for recovery. Before uploading or publishing, CI
verifies that both package filenames contain the exact version declared by the tag. NuGet.org trusted
publishing must authorize the `angularsen/UnitsNet` repository, the `unitsnet-modular-ci.yml`
workflow, and the `Publish` environment.

## Analyzer dependency plumbing

`UnitsNet.Modular/Directory.Packages.props` and `UnitsNet.Modular/Directory.Build.targets` support development
with an analyzer `ProjectReference`; they are not copied into the shipped package. Project
references do not automatically expose private analyzer dependencies. The local target therefore
points Roslyn at the restored `System.Text.Json` support assemblies.

Packaged consumers do not configure any of this. The support assemblies are private files beside
`UnitsNet.Modular.Generator.dll` under `analyzers/dotnet/cs`, and the package declares no runtime
dependency on them. `_UnitsNetModularAnalyzerDependencyDirectory` is evaluated only while packing to
locate those
files; it is not a consumer-facing MSBuild property or API.

## Framework targets

The `UnitsNet.Modular` runtime and `UnitsNet.Core` supply assets for .NET 8, 9, and 10. The standalone
prototype does not modify any UnitsNet target or make UnitsNet reference Core. Modern UnitsNet v6
adoption is maintained as a separate integration experiment.

The generator remains a `netstandard2.0` analyzer solely so current compiler and IDE hosts can load
it regardless of the consumer target. That analyzer target is an implementation constraint, not
runtime support for generated quantity modules.

On all supported runtime targets, generated quantities implement `IParsable<TSelf>` and applicable
Core capability and generic-math interfaces. Linear quantities support conventional arithmetic and
shared aggregation; affine quantities add or subtract linear offsets and produce an offset when
subtracted from one another; logarithmic quantities keep their explicit logarithmic behavior. All
generated quantities support generic comparison.

The runtime and Core projects enable the .NET AOT compatibility analyzers. CI publishes and runs
the lean sample with Native AOT on Linux. The generator remains a managed build-time analyzer and
explicitly does not inherit an application's publish, runtime identifier, trimming, or
self-contained settings. The lean generated consumer targets .NET 8, 9, and 10 so the normal build
also compiles emitted source against every supported runtime target.

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
- affine arithmetic generated with a selected linear offset companion, with `UNM015` reporting a
  missing companion before emission;
- modern .NET generic parsing, comparison, and capability contracts;
- localized unit metadata that delegates shared behavior to the runtime;
- direct, validated conversion switches for affine and nonlinear conversions;
- a module-wide immutable discovery registry and AOT-safe System.Text.Json converter factory.

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
`AdditionalFiles` items marked with `UnitsNetRelation="true"`:

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

`AllQuantitiesProfile` selects all 129 built-in definitions directly from the repository catalog,
without a second handwritten name inventory. `AllSiProfile` exercises the complete SI
relationship chain in a focused sample, while the representative sample provides a faster varied
selection for day-to-day generator iteration. JSON-backed third-party definitions participate in
the same
selection, profile, conversion, localization, and relationship model as built-ins.

The full-catalog generator gate emits 132 source files (129 quantities plus module sources) and
about 3.16 million source characters in roughly 0.63 seconds on the development machine used for
this POC. The budgets in the test are intentionally generous to catch accidental order-of-magnitude
regressions rather than benchmark noise. Running the identical input twice also verifies stable
generated text, while the incremental generator test verifies cached output for an unchanged full
catalog request.

## Deliberate limitations

- This is a design probe for a future architecture, not yet a committed replacement for UnitsNet v6.
- Quantity values use `double` only.
- Generic numeric storage, explicit culture-selection policy, and rich parse ambiguity handling are
  deferred.
- System.Text.Json has an immutable-registry proof of concept; long-term serialized-contract
  versioning and compatibility adapters remain application concerns.
- Regex/glob patterns filter expanded unit names, not abbreviations.
- Prefix expansion uses a common SI/binary prefix table; it does not yet reproduce every
  culture-specific prefix convention from UnitsNet v6.
- Definition packages contain recipes, not quantity structs. Independently generated application
  modules intentionally have distinct CLR type identities.
- The supported application pattern uses one module marker in one consumer-owned units project;
  `UNM014` reports additional module markers before they can emit colliding types.
- Canonical precompiled third-party modules and operators between independently compiled modules are
  outside this prototype's scope.
- Legacy mutable setup, runtime registration, global defaults, and exact legacy interface identity
  remain deliberately unsupported.

## What this POC should prove

1. Omitting a quantity prevents its type and metadata from entering the consumer assembly.
2. Unit patterns reduce the generated enum and typed API.
3. Built-in and custom quantities share the same runtime behavior and strongly typed surface.
4. Cross-quantity APIs can be conditional rather than forcing a monolithic dependency graph.
5. No runtime reflection or assembly scanning is required.
