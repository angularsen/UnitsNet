# UnitsNetGen

UnitsNetGen is a proof of concept for composing lean, strongly typed quantities and units at compile
time. It combines a small runtime with a Roslyn source generator and supports both built-in catalog
definitions and consumer-selected third-party definition packages.

Generated quantities implement the self-typed
`UnitsNet.Core.IQuantity<TSelf, TUnit, TValue>` contract. It exposes stored value, unit, and
conversion as instance behavior, with semantic identity, base unit, and construction on the
quantity type. Linear, affine, and logarithmic capability interfaces mirror their different
arithmetic semantics. A separate integration branch explores implementing these contracts in
UnitsNet v6; the standalone proof of concept leaves the existing UnitsNet project and package
unchanged.

Each generated quantity owns a static `Convert(value, fromUnit, toUnit)` primitive and the familiar
instance `As(unit)` and `ToUnit(unit)` members. Conversion uses immutable generated metadata rather
than runtime registration or a global quantity lookup.

**Experimental:** UnitsNetGen's API and package format may change while the architecture is being
explored.

## Select built-in quantities

Reference the package, then declare a module interface:

```csharp
using UnitsNetGen.BuiltIns;
using UnitsNetGen.Generation;

[UnitsNetModule]
internal interface EngineeringUnits :
    IInclude<Length>,
    IInclude<Temperature>,
    IInclude<TemperatureDelta>,
    IInclude<Information>;
```

Affine quantities name a linear offset quantity in their definition. Select both together;
`UNG015` reports a missing offset selection before source emission.

Select a subset of units with a regular expression:

```csharp
[UnitSet("regex:.*Meter$")]
internal interface MeterUnits;

[UnitsNetModule]
internal interface LeanUnits : IInclude<Length, MeterUnits>;
```

Select the available catalog with a profile and add individual quantities alongside it:

```csharp
using UnitsNetGen.Profiles;

[UnitsNetModule]
internal interface ApplicationUnits :
    IIncludeProfile<AllQuantities>,
    IInclude<MyCustomDefinition>;
```

Profiles provide defaults. A direct `IInclude<TQuantity, TUnitSet>` on the module overrides that
profile's unit selection for the same quantity. Profiles can be consumer-defined and nested.

The generated API includes strongly typed quantity structs and unit enums, parsing, formatting,
conversion, arithmetic, localized abbreviations, base dimensions, and familiar collection
extensions. `AllQuantities` currently selects all 129 definitions in the UnitsNet catalog.

Generated extension methods give ordinary consumer code the familiar API while delegating to
shared Core algorithms. The separate UnitsNet integration branch verifies that the same algorithms
can operate on UnitsNet v6 quantities:

```csharp
Length total = new[]
{
    Length.FromKilometers(1),
    Length.FromMeters(500),
}.Sum();

Temperature midpoint = new[]
{
    Temperature.FromDegreesCelsius(0),
    Temperature.FromDegreesFahrenheit(212),
}.Average(TemperatureUnit.DegreeCelsius);
```

Built-in handwritten APIs that remain valuable are modeled as explicit augmentation recipes.
`Duration`/`TimeSpan` interoperability and the `Area.FromCircleDiameter`/`FromCircleRadius` helpers
are the first examples. The same mechanism provides relation-backed mechanics, chemistry,
concentration, apparent-power, energy-density, and logarithmic reference conversions. Scalar
`FromFeetInches` and `FromStonePounds` factories are emitted only when their constituent units are
selected. Explicit companion recipes preserve the useful `FeetInches`, `StonePounds`, and
`ReferencePressure` wrappers; unit-dependent companions follow the same selection rule. The
generator does not infer companion types for other quantities. Any augmentation that refers to
another quantity is emitted only when that quantity is selected into the same module.

Generate the selected API in the established `UnitsNet` and `UnitsNet.Units` namespaces with
`[UnitsNetModule("UnitsNet")]`. The compatibility samples compile the exact same linked consumer
source against UnitsNet v6 and UnitsNetGen.

## Own the generated application module

Generate quantities once in an application-owned units library and reference that library from the
rest of the application. This gives domain, persistence, UI, and service projects the same CLR type
identity without giving up consumer control over the selection.

Third-party NuGets should normally be definition packages. They contribute public definition
markers, JSON definitions, localizations, and relationships, but no compiled quantity structs. The
application units project references those packages and selects their definitions alongside the
built-in catalog.

### Intended solution structure

The application has one project that owns generation. Every other application project references
that project instead of running UnitsNetGen independently:

```text
MyApplication.slnx
└── src
    ├── MyApplication.Units
    │   ├── MyApplication.Units.csproj
    │   └── ApplicationUnits.cs
    ├── MyApplication.Domain
    │   └── MyApplication.Domain.csproj      -> MyApplication.Units
    ├── MyApplication.Persistence
    │   └── MyApplication.Persistence.csproj -> MyApplication.Units
    ├── MyApplication.Api
    │   └── MyApplication.Api.csproj         -> MyApplication.Units
    └── MyApplication.Cli
        └── MyApplication.Cli.csproj         -> MyApplication.Units
```

`MyApplication.Units` references `UnitsNetGen` and any third-party definition packages. Its module
marker selects the built-in and third-party definitions the application needs. The generated
quantity structs, unit enums, conversions, formatting, parsing, and cross-quantity operators all
become part of `MyApplication.Units.dll`.

```mermaid
flowchart LR
    BuiltIns["UnitsNetGen built-in catalog<br/>recipe"]
    PackageA["Acme.Measurements.Definitions<br/>third-party recipe package"]
    PackageB["Other.Definitions<br/>third-party recipe package"]
    Module["MyApplication.Units<br/>selection + source generation"]
    Types["MyApplication.Units.dll<br/>application-owned quantity types"]
    Domain["Domain"]
    Persistence["Persistence"]
    Api["API / UI"]
    Cli["CLI / services"]

    BuiltIns --> Module
    PackageA --> Module
    PackageB --> Module
    Module --> Types
    Types --> Domain
    Types --> Persistence
    Types --> Api
    Types --> Cli
```

The packages on the left are recipes: they describe quantities, units, localizations, conversions,
and relationships. The application project in the middle decides which recipes to combine and owns
the resulting CLR types. This single generation boundary is what lets every project on the right
exchange the same strongly typed values.

### Package models

There are two possible models for distributing third-party quantities:

1. A **compiled quantity package** generates and ships its own quantity structs and unit enums.
   This is convenient for a fixed, standalone API, but the package author chooses the available
   quantities and units. Two packages that independently compile the same logical quantity create
   different CLR types. A consumer also cannot freely compose operators across those package
   boundaries, because neither independently compiled assembly owns both operand types.
2. A **definition package** ships public marker interfaces together with JSON definitions,
   localizations, conversion expressions, and relationships. It does not ship compiled quantity
   structs. The consuming application selects the definitions and generates them once in its own
   units project.

UnitsNetGen chooses the definition-package model for third-party extensibility. It preserves the
consumer's ability to bring only the quantities and units it needs, makes built-in and third-party
relationships visible to one generator, and gives all generated types one predictable assembly
identity inside the application. It also avoids forcing a third party's selection and generation
policy on every consumer.

A compiled module can still be useful when an organization deliberately wants to publish one
canonical quantity assembly for several applications. That is a deployment choice rather than the
primary composition model, and independently compiled modules do not gain type identity or operator
interoperability merely because their definitions have the same names.

### Module registry and serialization

Every generated module owns one immutable registry containing only its selected quantities. It
supports dynamic lookup by semantic quantity ID, generated CLR type, or quantity name, together
with construction, conversion, parsing, unit metadata, abbreviations, and base dimensions:

```csharp
using UnitsNetGen.Generated;

UnitsNet.Core.IQuantity<double> dynamicValue =
    Quantity.From(1.5, "Length", "Kilometer");
UnitsNet.Core.IQuantity<double> parsed =
    Quantity.Parse(typeof(Length), "1.5 km");

UnitsNetGen.IQuantityDescriptor length = UnitsNetGenRegistry.Instance.Get("Length");
UnitsNet.Core.IQuantity<double> value =
    length.Parse("1.5 km", System.Globalization.CultureInfo.InvariantCulture);
double meters = length.Convert(1.5, "Kilometer", "Meter");

double dynamicMeters = UnitsNetGenRegistry.Instance.Convert(
    1.5,
    LengthUnit.Kilometer,
    LengthUnit.Meter);

Length siLength = Length.From(1.5, UnitsNetGen.UnitSystem.SI);
double siMeters = Length.FromKilometers(1.5).As(UnitsNetGen.UnitSystem.SI);
UnitsNet.Core.IQuantity<double> dynamicSiLength =
    Quantity.From(1.5, "Length", UnitsNetGen.UnitSystem.SI);
```

The generator emits one partial static `Quantity` facade per code owner. It is placed in an explicit
module target namespace, or in the module interface's namespace when definitions retain their own
namespaces. Compatibility mode therefore emits `UnitsNet.Quantity`. The facade preserves familiar
`Names`, `Infos`, `ByName`, `From`, `TryFrom`, `Parse`, `TryParse`, and dimension-query call shapes,
returning `UnitsNet.Core.IQuantity<double>` instead of the legacy interface.

The registry is generated data backed by frozen dictionaries. It does not scan assemblies and
cannot be mutated at runtime. This keeps compile-time recipes authoritative while still supporting
dynamic application features such as editors, persistence boundaries, and generic unit pickers.
It also provides `TryCreate`, `TryConvert`, type-directed parsing and formatting, unit-enum lookup,
and base-dimension discovery for common migrations from UnitsNet's static dynamic APIs.

`UnitsNetGen.UnitSystem` and `UnitsNetGen.BaseUnits` are immutable, owner-neutral policy values.
Each generated unit retains its constituent base-unit metadata. Typed constructors, `From`, `As`,
and `ToUnit`, plus the facade, descriptors, and registry, resolve a policy only against units
selected into the module. This preserves useful unit-system workflows without recreating mutable
global defaults.

The generated registry also exposes an AOT-safe System.Text.Json converter factory:

```csharp
var options = new JsonSerializerOptions();
options.Converters.Add(UnitsNetGenRegistry.JsonConverter);
string json = JsonSerializer.Serialize(Length.FromKilometers(1.5), options);
```

The serialized shape is `{ "Value": 1.5, "Unit": "Kilometer" }`. Applications still own
versioning and compatibility of serialized contracts; semantic IDs make explicit adapters
possible, but generated structs in independently compiled modules remain different CLR types.

The `Samples/ConsumerOwned` scenario shows both repository integration modes side by side:

- `ConsumerOwned.Units` is the canonical package-facing project. It consumes locally packed
  `UnitsNetGen` and `Fictional.Measurements.Definitions` packages and receives the recipe files
  through the definition package's `build/*.props`.
- `ConsumerOwned.Units.ProjectReferences` compiles the exact same linked module declaration using
  direct project references. It includes the definition files explicitly because NuGet build
  content does not flow through a `ProjectReference`.

Feature-focused samples use project references for a fast repository development loop. The two
NuGet-facing scenarios validate package integration: `UnitsNetGen.NuGet.Sample` covers a minimal
consumer-owned JSON file, while `ConsumerOwned.Units` composes a separate definition package into
an application-owned shared assembly.

See `Samples/DefinitionPackages/Fictional.Measurements.Definitions` and
`Samples/ConsumerOwned` for the complete packable-provider and shared-consumer scenario.

See [MIGRATION.md](MIGRATION.md) for a workflow-by-workflow mapping from `Quantity`,
`UnitConverter`, `QuantityInfo`, `UnitsNetSetup`, `UnitSystem`, `UnitKey`, and legacy `IQuantity`.

## Add custom quantities

Add a UnitsNet-style JSON definition to the project:

```xml
<ItemGroup>
  <AdditionalFiles Include="HowMuch.unitsnet.json"
                   UnitsNetGenDefinition="true" />
</ItemGroup>
```

Use Roslyn's native `AdditionalFiles` item for consistent command-line and IDE design-time
generation. The package also retains `UnitsNetGenDefinition` as a convenience alias, but Rider does
not currently pass that custom build action to its design-time Roslyn host.

Bind a marker to the definition's logical namespace and name, then select it like a built-in
quantity:

```csharp
namespace Fictional;

using UnitsNetGen.Generation;

[QuantityDefinition("Fictional.Measurements.HowMuch")]
public interface HowMuchDefinition;

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchDefinition>;
```

Custom definitions support localized abbreviations, prefix expansion, and affine or nonlinear
conversion expressions.

Custom definitions can also contribute relationships. Third-party packages should use structured
semantic quantity IDs so relationships remain unambiguous across generated namespaces:

```xml
<ItemGroup>
  <AdditionalFiles Include="HowMuch.unitsnet.relations.json"
                   UnitsNetGenRelation="true" />
</ItemGroup>
```

```json
[
  {
    "result": {
      "quantity": "Fictional.Measurements.HowMuchDistance",
      "unit": "SomeMeter"
    },
    "left": {
      "quantity": "Fictional.Measurements.HowMuch",
      "unit": "Some"
    },
    "operator": "*",
    "right": {
      "quantity": "UnitsNet.Length",
      "unit": "Meter"
    }
  }
]
```

Multiplication is expanded in both operand orders, and division relationships are inferred unless
disabled by the relation. Operators are emitted when their participating quantities are selected,
even when they use different generated namespaces or omit the relation's anchor units from their
public unit enums. Existing UnitsNet string equations remain supported for the built-in catalog.

## Learn more

See the
[proof-of-concept architecture](https://github.com/angularsen/UnitsNet/blob/master/UnitsNetGen/ARCHITECTURE.md)
and [sample projects](https://github.com/angularsen/UnitsNet/tree/master/UnitsNetGen/Samples) for the
full design and working scenarios.
