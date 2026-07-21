# UnitsNetGen agent handoff

Continue the UnitsNetGen proof of concept in the UnitsNet repository.

## Repository setup

From the repository root:

```text
git fetch origin
git switch agl/unitsnetgen-poc
git pull --ff-only origin agl/unitsnetgen-poc
```

Read `AGENTS.md` first, then use these as the authoritative design context:

- `UnitsNetGen/README.md`
- `UnitsNetGen/ARCHITECTURE.md`
- `UnitsNetGen/MIGRATION.md`
- `UnitsNetGen/IMPLEMENTATION_PLAN.md`

## Current branch

Work on:

```text
agl/unitsnetgen-poc
```

Recent logical changes cover:

- avoiding materialization in logarithmic and affine aggregation;
- documenting the full-catalog architecture;
- validating modern .NET and Native AOT;
- generating the full catalog and immutable module metadata;
- completing affine quantity offset semantics;
- diagnosing multiple generation modules;
- generating owner-scoped `Quantity` facades over `UnitsNet.Core.IQuantity<double>`;
- retaining exact catalog-wide `BaseUnits` metadata and resolving immutable `UnitSystem` policy;
- establishing the modular UnitsNetGen source-generator prototype.

Use `git log --oneline` for the current commit hashes rather than assuming this document's revision is
the branch tip.

## Core architectural decisions

### Consumer-owned generation

Consumer-owned generation is the primary model. An application generates quantities once in an
application-owned units project. Other application projects reference that assembly so they share
exact CLR type identity.

### Definition packages

Third-party packages are normally definition packages, or recipes. They provide:

- public definition markers;
- UnitsNet-style JSON definitions;
- localizations;
- conversion expressions;
- structured quantity relationships.

They generally do not ship compiled quantity structs. The consuming units project selects and
generates the definitions.

### Modern .NET targets

- `UnitsNetGen`: .NET 8, 9, and 10
- `UnitsNet.Core`: .NET 8, 9, and 10
- `UnitsNetGen.Generator`: .NET Standard 2.0 only for Roslyn and IDE host compatibility

Do not restore generated-runtime .NET Standard 2.0 support without a new design discussion.

### Immutable compile-time conversion

Each generated quantity owns:

- `Convert(value, fromUnit, toUnit)`;
- `As(unit)`;
- `ToUnit(unit)`;
- immutable generated conversion metadata.

There is no mutable global conversion registry.

### Immutable discovery registry

`UnitsNetGen.Generated.UnitsNetGenRegistry` describes only the quantities selected into its module.
It supports lookup by:

- `QuantityId`;
- definition name;
- generated CLR type.

Descriptors expose selected units, abbreviations, base dimensions, construction, conversion,
parsing, and stored value/unit access.

This registry supports dynamic application features. It does not control conversion policy and is
not a replacement for `UnitsNetSetup`.

All public dynamic quantity values use `UnitsNet.Core.IQuantity<double>`. Do not regress descriptor,
registry, or facade creation, parsing, inspection, or formatting contracts back to `object`.

### Serialization

System.Text.Json uses the generated registry. The converter factory dispatches through direct
generated type checks without assembly scanning or `MakeGenericType`. The design is trimming and
Native AOT friendly.

### Clean shared contracts

`UnitsNet.Core` contains:

- `IQuantity<TValue>`;
- `IQuantity<TUnit, TValue>`;
- `IQuantity<TSelf, TUnit, TValue>`;
- linear, affine, and logarithmic capability interfaces.

`QuantityId` is static on the self-typed quantity interface. `BaseValue` is not public interface
state. Shared algorithms live in Core, while generated concrete extension methods provide familiar
consumer syntax.

### Compatibility boundary

Concrete source compatibility is the primary compatibility goal. Compatibility-mode quantities use
the `UnitsNet` and `UnitsNet.Units` namespaces, and the same linked consumer source compiles against
UnitsNet and UnitsNetGen.

Binary compatibility is not promised because concrete structs generated into different assemblies
have different CLR identities.

### Complete catalog

`AllQuantities` selects all current definitions directly from:

```text
Common/UnitDefinitions/*.json
```

There is no second handwritten catalog inventory. `AllSi` remains the focused SI
relationship-chain sample. The representative sample remains useful for fast iteration, but
documentation must describe the intended complete catalog.

### Catalog relationships

`Common/UnitRelations.json` remains the source of truth. The generator:

- resolves stable semantic quantity IDs;
- emits commutative multiplication in both directions;
- infers division unless `NoInferredDivision` is set;
- supports scalar and reciprocal/inverse relationships;
- accepts structured third-party relation files;
- emits operators only when participating quantities are selected.

### Numeric types

Numeric-type abstraction is outside this branch. Do not mix the earlier
decimal/Fraction/configurable numeric-storage spike into `agl/unitsnetgen-poc`. That work must remain
separately reviewable.

## Current functionality

- Full built-in quantity generation
- Stable unit enum names and values
- Linear, affine, and logarithmic semantics
- Prefix expansion and localization
- Regex/glob unit selection
- Custom JSON definitions and relationships
- Consumer-defined and built-in profiles
- Quantity and unit parsing, formatting, and abbreviations
- Base dimensions and immutable `Units` collections
- Cross-quantity, scalar, and reciprocal relationships
- `Sum`, `Average`, selector, and target-unit extensions
- Logarithmic `Sum`, `ArithmeticMean`, and `GeometricMean`
- `Abs` and tolerance-aware `Equals`
- Data-driven built-in API augmentations for high-value handwritten quantity helpers
- Immutable generated module registry
- Immutable registry conveniences for common legacy dynamic workflows
- Immutable owner-neutral `BaseUnits` / `UnitSystem` policy with typed and dynamic conveniences
- AOT-safe System.Text.Json converter factory
- NuGet and ProjectReference consumer samples
- Full-catalog compatibility and generator-performance gates

## Latest augmentation work

Built-in handwritten API augmentations are selected from immutable embedded JSON instead of
semantic-ID conditionals in `QuantityEmitter`. Augmentations declare their participating quantity
dependencies and are emitted only when those quantities are selected into the module.

The augmentation emitter is isolated from the main quantity emitter. Current recipes cover:

- `Duration`/`TimeSpan` interoperability;
- `Area` circle construction;
- `MassFraction`/`Mass`, `Force` factories, and gravitational-force conversion;
- the exact Avogadro constant and `AmountOfSubstance.FromMass`;
- mass, molar, and volume concentration conversions;
- apparent-power division;
- combustion energy from energy density, volume, and ratio;
- immutable amplitude-, power-ratio, and `Level` reference conversions;
- scalar `FromFeetInches` and `FromStonePounds` factories when their units are selected;
- the `FeetInches`, `StonePounds`, and `ReferencePressure` companion types.

Augmentations can require constituent units as well as quantities. This prevents a filtered
meters-only or kilograms-only module from silently regaining feet/inches or stone/pounds concepts.

Companion types use a parallel explicit recipe catalog. Each recipe names its semantic owner,
prerequisite quantities and units, and a dedicated emitter kind. The generator does not infer
wrappers from compound units or naming conventions. Adding another useful wrapper is therefore a
small, reviewable catalog-and-emitter change without turning wrappers into a general convention.

The remaining handwritten exclusions are explicit and reasoned in the compatibility test:

- `Length.ParseFeetInches` and `TryParseFeetInches` depend on a specialized text grammar;
- `Pressure.FromElevation` and `ToElevation` are an empirical atmosphere model, not unit conversion.

The compatibility suite verifies that every exclusion still exists in UnitsNet, remains absent from
UnitsNetGen, and carries a non-empty reason. Stale exclusions therefore fail the test.

## Latest aggregation work

Logarithmic `Sum`, `ArithmeticMean`, and `GeometricMean` no longer materialize their source. They
read the first quantity and unit, then continue through the same enumerator.

Affine first-unit `Average` follows the same one-pass pattern. Generated affine extensions no
longer call `ToArray()`.

The regression test uses a read-only `ICollection<T>` that enumerates normally but throws from
`CopyTo()`. This directly detects attempts to materialize through LINQ `ToArray()`.

Generated `Unit` access compares the concrete enum with `default` using `==` instead of
`Enum.Equals`, avoiding boxing on frequently used conversion paths.

## Compatibility status

`UnitsNetGen.Compatibility.Tests` validates:

- the complete quantity inventory;
- unit enum names and numeric values;
- every unit's conversion through its base unit;
- base-unit formatting and parsing;
- abbreviations and `ParseUnit`;
- default-value behavior;
- strict UnitsNet equality behavior;
- representative affine and logarithmic behavior;
- registry completeness, unit counts, and base dimensions;
- declared constructors, properties, methods, and operators.

Every accepted missing member is explicitly categorized as either:

- legacy mutable metadata/setup behavior intentionally outside the clean model; or
- a remaining quantity-specific handwritten UnitsNet API.

The clean immutable conveniences and selected companion types are implemented as explicit recipes.
Remaining exclusions require specialized parsing or empirical atmosphere policy.

## Legacy compatibility review

`IMPLEMENTATION_PLAN.md` step 19 is complete. The workflow matrix and migration examples live in
`MIGRATION.md`.

Common read-only dynamic workflows are supported directly by the immutable registry:

- lookup by semantic ID, quantity name, quantity type, or unit-enum type;
- dynamic creation and same-quantity conversion by invariant names or generated unit enums;
- type-directed parsing and validated formatting;
- base-dimension discovery;
- non-throwing `TryCreate`, `TryConvert`, and `TryParse` paths.

Each generated owner also gets a partial static `Quantity` facade. An explicit module target
namespace owns the facade; otherwise the module interface's namespace owns it. Compatibility mode
therefore emits `UnitsNet.Quantity`. `Names`, `Infos`, `ByName`, `From`, `TryFrom`, `Parse`,
`TryParse`, and dimension discovery delegate to the registry, and dynamic values use
`UnitsNet.Core.IQuantity<double>`.

The compatibility suite compares representative facade and registry workflows directly with
UnitsNet `Quantity` and `UnitConverter` behavior.

Do not extend the facade with mutable legacy behavior. `UnitsNetSetup`, runtime conversion
registration, abbreviation-cache mutation, and mutable global defaults represent process-wide
policy that conflicts with consumer-owned compile-time definitions. Immutable
`UnitsNetGen.UnitSystem` values are supported explicitly by generated quantities, the facade,
descriptors, and the registry, and resolution considers only selected units. Persistent or plugin
boundaries should use semantic quantity IDs plus invariant unit names; existing binaries compiled
against `UnitsNet.dll` must translate at that boundary.

## Likely next areas

### Intentional handwritten exclusions

The remaining exclusions are enforced in:

```text
UnitsNetGen/UnitsNetGen.Compatibility.Tests/CompatibilityTests.cs
```

Do not recreate the specialized feet/inches parser or empirical elevation model merely to empty the
list. Revisit an exclusion only when there is a clean UnitsNetGen-native design that materially
reduces migration friction without weakening unit selection or immutable metadata.

### Application-specific adapters

Add an adapter only in response to a concrete application boundary that needs runtime policy.
Keep it separate from Core and generated quantities, and preserve the immutable registry as the
source of selected quantity metadata.

### Evidence-based performance work

Potential areas include:

- allocation-free span parsing and formatting;
- UTF-8 parsing and formatting;
- generated source size;
- static initialization size;
- IDE/Rider generator reload behavior;
- remaining boxing or reflection paths.

### Documentation accuracy

Do not claim complete compatibility while handwritten APIs remain allowlisted. Do not describe the
architecture as limited to the representative sample. Preserve examples of the full relationship
catalog.

## Validation

Run the complete POC suite from the repository root:

```text
dotnet test UnitsNetGen.slnx \
  --configuration Release \
  --no-restore \
  -p:UnitsNetGenSampleUpdateLocalPackagesOnBuild=false \
  -m:1
```

On PowerShell, use backticks instead of backslashes if desired.

Validate the isolated NuGet consumer:

```text
pwsh UnitsNetGen/Samples/UnitsNetGen.NuGet.Sample/run.ps1
```

Create publish-style packages:

```text
dotnet pack UnitsNetGen/UnitsNetGen/UnitsNetGen.csproj \
  --configuration Release \
  --no-build \
  --output Artifacts/UnitsNetGen.Validation \
  -p:UnitsNetGenPackForPublish=true
```

## Native AOT

The project graph reaches the NativeAOT platform-linker stage correctly. The original Windows
environment lacked the Visual C++ linker workload, so local publishing stopped at that external
prerequisite.

The UnitsNetGen GitHub Actions workflow publishes and runs the lean sample using Linux NativeAOT.
The generator project prevents application `PublishAot`, trimming, self-contained, and runtime
identifier properties from propagating into the .NET Standard 2.0 analyzer project.

## Required Git workflow

The user explicitly authorizes committing and pushing work to:

```text
agl/unitsnetgen-poc
```

Before committing:

1. Inspect `git status`.
2. Inspect staged and unstaged diffs.
3. Preserve unrelated user changes.
4. Stage only the intended logical change.
5. Run focused tests and then the full UnitsNetGen solution.

Create logical commits with concise imperative subjects. Do not combine unrelated architectural
experiments.

After validation:

```text
git push origin agl/unitsnetgen-poc
```

Do not leave completed work only in the local worktree. Confirm the final commit hashes, test
results, clean worktree, and successful push in the handoff.
