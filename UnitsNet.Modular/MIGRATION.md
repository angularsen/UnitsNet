# Migrate from UnitsNet to UnitsNet.Modular

UnitsNet.Modular preserves the familiar strongly typed UnitsNet programming model, but changes
where quantities come from and who owns them. UnitsNet provides a precompiled catalog in
`UnitsNet.dll`. UnitsNet.Modular generates the selected catalog into an assembly owned by the
consumer.

That distinction enables smaller, application-specific catalogs, custom quantities in the same
type system, and trimming and Native AOT-friendly discovery without assembly scanning. It also
means that UnitsNet.Modular is not a drop-in binary replacement for UnitsNet and that some dynamic,
metadata, and runtime-configuration APIs require migration.

> **Experimental:** UnitsNet.Modular is an alpha proof of concept. Its API, package structure, and
> compatibility guarantees may change as the architecture is evaluated.

## How the two packages differ

| Concern | UnitsNet | UnitsNet.Modular |
|---|---|---|
| Quantity implementation | Precompiled types supplied by `UnitsNet.dll` | Source-generated types compiled into a consumer-owned assembly |
| Catalog | The complete UnitsNet catalog | Only the quantities and units selected by the module |
| Namespaces | `UnitsNet` and `UnitsNet.Units` | The same by default for built-ins, or an application namespace selected by the module |
| Custom quantities | Separate from the built-in generated catalog | Built-in, application, and third-party definitions generate together |
| Configuration | Runtime setup and mutable global registrations | Compile-time selection and immutable generated metadata |
| Dynamic discovery | Process-wide UnitsNet catalog | One immutable registry for the selected module |
| Unit-system policy | `UnitsNet.UnitSystem` stores constituent unit enums | `UnitsNet.UnitSystem` keeps the familiar source name but stores invariant names so it is neutral to the generated assembly |
| Deployment | Consumers share the types in `UnitsNet.dll` | Consumers must reference the same assembly containing the generated types |
| Compatibility | Established UnitsNet API and binary identity | Common strongly typed APIs target source compatibility; binary compatibility is not a goal |

## Why use UnitsNet.Modular?

UnitsNet.Modular is a good fit when an application wants one or more of these properties:

- generate only the quantities and units it uses;
- combine UnitsNet definitions with application-specific or third-party definitions;
- generate relationships and operators across built-in and custom quantities;
- own a single units assembly shared by the application's domain, persistence, API, and UI projects;
- avoid runtime assembly scanning and mutable global registration;
- use generated, trimming and Native AOT-friendly discovery and System.Text.Json integration.

UnitsNet remains the simpler choice when an application needs binary compatibility with libraries
compiled against `UnitsNet.dll`, depends heavily on runtime mutation, or cannot establish one
generation boundary shared by all consumers. UnitsNet.Modular is currently a design probe, not a
committed replacement for UnitsNet.

## Migration steps

### 1. Choose the assembly that owns the generated types

A generated public type belongs to the assembly into which it is generated. For a multi-project
application, create or choose one units project, generate the module there, and reference that
project everywhere else:

```text
MyApplication.Units       -> UnitsNet.Modular + module declaration
MyApplication.Domain      -> MyApplication.Units
MyApplication.Persistence -> MyApplication.Units
MyApplication.Api         -> MyApplication.Units
```

Do not generate the same quantity independently in several projects. Two generated types named
`UnitsNet.Length` in two assemblies are different CLR types.

### 2. Replace the package in the owning project

Remove the `UnitsNet` package reference and add the prerelease `UnitsNet.Modular` package:

```shell
dotnet remove package UnitsNet
dotnet add package UnitsNet.Modular --prerelease
```

Remove direct `UnitsNet` references from the other application projects and reference the owning
units project instead. A project cannot use the precompiled and generated `UnitsNet.Length` types
as though they were the same type.

### 3. Declare the module

For the lowest-friction migration, generate all built-in quantities:

```csharp
using UnitsNet.Modular;
using UnitsNet.Modular.Profiles;

[UnitsNetModule]
internal interface ApplicationUnits : IIncludeProfile<AllQuantitiesProfile>;
```

Built-in definitions use `UnitsNet` and `UnitsNet.Units` by default, so existing imports such as
these remain valid:

```csharp
using UnitsNet;
using UnitsNet.Units;
```

To generate a smaller catalog, replace the profile with explicit selections:

```csharp
using UnitsNet.Modular;
using Catalog = UnitsNet.Modular.BuiltIns;

[UnitsNetModule]
internal interface ApplicationUnits :
    IInclude<Catalog.LengthSpec>,
    IInclude<Catalog.DurationSpec>,
    IInclude<Catalog.SpeedSpec>;
```

Select every quantity participating in an operator or relationship. Affine quantities such as
`Temperature` also require their offset quantity; generator diagnostics identify missing inputs.
See [Configure generation](README.md#configure-generation) for profiles and unit filters.

### 4. Build and fix source-incompatible APIs

Build before changing ordinary quantity code. Construction, conversion, parsing, formatting,
arithmetic, and many quantity-specific helpers should continue to compile. Use the two quick
reference tables below to identify code that needs an adapter or API change.

### 5. Migrate dynamic and serialized boundaries

Resolve dynamic quantities through the generated module registry, and use semantic quantity IDs
plus invariant unit names at persistence, message, plugin, or service boundaries. Register the
module's generated System.Text.Json converter instead of relying on runtime discovery:

```csharp
using System.Text.Json;
using UnitsNet;

var options = new JsonSerializerOptions();
options.Converters.Add(GeneratedQuantityRegistry.JsonConverter);
```

Existing assemblies compiled against `UnitsNet.dll` must keep UnitsNet at that boundary. Translate
to the application's generated quantities explicitly by numeric value and invariant unit name.

### 6. Verify behavior, then reduce the catalog

Run application tests with particular attention to persisted payloads, culture-sensitive parsing
and formatting, unit-system selection, dynamic lookup, and plugin or reflection boundaries. After
the full-catalog migration is stable, replace `AllQuantitiesProfile` with the quantities and unit
sets the application actually needs.

## Quick reference: source-compatible APIs

Here, **source-compatible** means the same consumer source compiles against UnitsNet.Modular when:

- built-ins use their default `UnitsNet` and `UnitsNet.Units` namespaces;
- every referenced quantity and unit is selected; and
- all projects reference the same assembly containing the generated types.

| API area | Examples that remain source-compatible | Notes |
|---|---|---|
| Quantity and unit names | `Length`, `Mass`, `LengthUnit.Meter` | The full built-in catalog preserves quantity names, unit enum names, and enum values. |
| Construction | `new Length(1, LengthUnit.Meter)`, `Length.From(1, unit)`, `Length.FromMeters(1)` | Generated quantity values currently use `double`. |
| Value access | `length.Value`, `length.Unit`, `length.Meters`, `Length.Zero` | Code that explicitly names UnitsNet's `QuantityValue` type must change to `double`. |
| Conversion | `length.As(unit)`, `length.ToUnit(unit)` | Conversion behavior is generated from the selected definitions. Modular also adds `Length.Convert(value, from, to)` for raw values. |
| Parsing | `Length.Parse(text)`, `Length.TryParse(...)`, `Length.ParseUnit(...)` | Selected units and localization determine accepted input. |
| Formatting | `length.ToString(...)`, `Length.GetAbbreviation(unit, provider)` | Culture-aware built-in abbreviations and formatting are generated. |
| Arithmetic and comparison | `a + b`, `a - b`, `a * 2`, `a / b`, comparisons and equality | Quantity semantics remain linear, affine, or logarithmic as appropriate. |
| Cross-quantity relationships | `Length / Duration`, `Mass * Acceleration`, `Force / Area` | Emitted only when all participating quantities are selected. |
| Aggregation | `values.Sum()`, `values.Average()`, logarithmic aggregation helpers | Generated extensions delegate to reusable `UnitsNet` algorithms. |
| Built-in companion APIs | `FeetInches`, `StonePounds`, `ReferencePressure`, `Duration`/`TimeSpan` helpers | Included when their owning built-in quantities are selected. |

## Quick reference: incompatible or changed APIs

These APIs are not source-compatible even when the full catalog is generated.

| UnitsNet API or assumption | UnitsNet.Modular replacement | Migration action |
|---|---|---|
| Types come from `UnitsNet.dll` | Types are generated into a consumer-owned assembly | Recompile consumers and make them reference one shared generated assembly; keep an adapter at binary boundaries. |
| `UnitsNet.IQuantity` and legacy generic quantity contracts | `UnitsNet.IQuantity<double>` and the generated-runtime capability contracts | Change generic constraints and declared dynamic types, or keep concrete quantity types where possible. The namespace is source-compatible, but the assembly identity and interface shapes differ. |
| Explicit `QuantityValue` usage | `double` | Change explicitly declared values, parameters, and generic arguments to `double`. |
| Legacy metadata shapes and `Length.QuantityInfo` | Typed `Length.Info`, or `IQuantityDescriptor` and `UnitDescriptor` from the registry | Read `Length.Info.BaseUnit`, `Length.Info.Units`, and `Length.Info.BaseDimensions` when the quantity is known; use the registry for type-erased workflows. |
| `Quantity.Names`, `Quantity.Infos`, and `Quantity.ByName` imply the complete process-wide catalog | The same facade names describe only the selected module | Audit code that assumes every UnitsNet quantity is present. Use the registry when dependency injection or explicit ownership is clearer. |
| `Quantity.From`, `TryFrom`, `Parse`, and `TryParse` return legacy `UnitsNet.IQuantity` | The familiar call shapes return `UnitsNet.IQuantity<double>` from the Modular runtime | Change the receiving interface shape or use `var`; concrete typed parsing remains unchanged. |
| `UnitConverter` and runtime conversion registration | Generated `QuantityType.Convert(...)` or `QuantityRegistry.Convert(...)` | Move conversions into definitions and use typed conversion when the quantity is known. |
| `UnitsNetSetup` quantity selection and runtime registration | Module interfaces, profiles, unit sets, JSON definitions, and relation definitions | Move configuration to compile time. Rebuild when the catalog changes. |
| Runtime abbreviation mutation | Localization in definition metadata | Add abbreviations to a definition; runtime mutation is unsupported. |
| Global `Quantity.FromUnitAbbreviation(...)` | Parse through a known quantity or inspect its descriptor | Carry quantity identity at the boundary instead of inferring it from a potentially ambiguous abbreviation. |
| `UnitKey` as a stable boundary identifier | Semantic `QuantityId` plus invariant unit name | Persist or transmit both values; unit enums are suitable only inside one generated module. |
| Mutable or enum-backed assumptions about `UnitsNet.UnitSystem` and `UnitsNet.BaseUnits` | Immutable Modular implementations under the same `UnitsNet` namespace | Calls such as `UnitSystem.SI` remain source-compatible; construct custom policies with invariant constituent unit names. |
| Legacy `BaseDimensions` shape in generic/dynamic code | Modular `UnitsNet.BaseDimensions` | The namespace remains the same; adapt shape-dependent code and access it through `Length.Info.BaseDimensions` or an `IQuantityDescriptor`. |
| Polymorphic JSON inferred from runtime type discovery | `GeneratedQuantityRegistry.JsonConverter` for selected concrete quantities | Register the generated converter. Resolve polymorphic interfaces by semantic quantity ID at the boundary. |
| `Length.ParseFeetInches` and `Length.TryParseFeetInches` | No specialized compound parser | Keep a presentation-layer parser or translate the input into ordinary `Length` operations. |
| `Pressure.FromElevation` and `Pressure.ToElevation` | No generated elevation model | Keep the empirical atmosphere model in application code and return/accept `Pressure`. |
| Runtime additions to a catalog | New or changed definition inputs | Update the module or definition package and rebuild. |

## Common fixes

### Dynamic quantity contracts

Change code that explicitly receives a UnitsNet interface:

```csharp
// UnitsNet
IQuantity distance = Quantity.From(1.5, "Length", "Kilometer");

// UnitsNet.Modular package
UnitsNet.IQuantity<double> distance =
    Quantity.From(1.5, "Length", "Kilometer");
```

The namespace remains `UnitsNet`, but the Modular interface has a deliberately slimmer shape:

```csharp
UnitsNet.IQuantity<double> distance = Length.FromMeters(1);
```

### Global conversion

Replace dynamic conversion by name with the registry:

```csharp
// UnitsNet
QuantityValue meters = UnitConverter.ConvertByName(
    1.5, "Length", "Kilometer", "Meter");

// UnitsNet.Modular package
using UnitsNet;

var registry = GeneratedQuantityRegistry.Instance;
double meters = registry.Convert(
    1.5,
    "Length",
    "Kilometer",
    "Meter");
```

When the quantity is known, prefer the generated typed API:

```csharp
double meters = Length.Convert(
    1.5,
    LengthUnit.Kilometer,
    LengthUnit.Meter);
```

The registry also supports enum-based conversion when both units belong to one selected quantity.

### Metadata and unit pickers

Replace mutable/global metadata assumptions with a descriptor from the selected module:

```csharp
using UnitsNet;

IQuantityDescriptor descriptor =
    GeneratedQuantityRegistry.Instance.Get("Length");

foreach (UnitDescriptor unit in descriptor.Units)
{
    Console.WriteLine(unit.Name);
}
```

| UnitsNet workflow | UnitsNet.Modular equivalent | Status |
|---|---|---|
| `Quantity.Names` | `Quantity.Names` or `registry.Names` | Supported, selected module only |
| `Quantity.Infos` | `Quantity.Infos` or `registry.Quantities` | Supported with immutable descriptors |
| `Quantity.ByName[name]` | `Quantity.ByName[name]` or `registry.Get(name)` | Supported, case-insensitive name |
| Lookup by quantity type | `registry.Get(typeof(Length))` | Supported |
| Stable cross-boundary identity | `registry.Get(new QuantityId("UnitsNet.Length"))` | Supported; use namespace-qualified IDs |
| Lookup from a unit enum type | `registry.GetByUnitType(typeof(LengthUnit))` | Supported |
| `Quantity.From(value, quantityName, unitName)` | Same facade call | Returns Modular quantity contract |
| `Quantity.From(value, unitEnum)` | Same facade call | Returns Modular quantity contract |
| `Quantity.TryFrom(...)` | Same facade call | Returns Modular quantity contract |
| `UnitConverter.ConvertByName(...)` | `registry.Convert(value, quantityName, fromName, toName)` | Supported |
| `UnitConverter.Convert(value, fromEnum, toEnum)` | `registry.Convert(value, fromEnum, toEnum)` | Supported for one quantity |
| `UnitConverter.TryConvert...` | `registry.TryConvert(...)` | Supported for one quantity |
| `Quantity.Parse(type, text)` | Same facade call | Returns Modular quantity contract |
| `Quantity.TryParse(...)` | Same facade call | Returns Modular quantity contract |
| `Quantity.GetQuantitiesWithBaseDimensions(...)` | Same facade call or `registry.FindByBaseDimensions(...)` | Supported, selected module only |
| `QuantityInfo` / `UnitInfo` metadata | `QuantityInfo<TQuantity, TUnit>` / `UnitInfo<TUnit>`; `IQuantityDescriptor` / `UnitDescriptor` when type-erased | Supported as immutable metadata |
| Dynamic formatting through `IQuantity` | `descriptor.Format(value, format, provider)` | Supported with concrete-type validation |
| System.Text.Json converters | `GeneratedQuantityRegistry.JsonConverter` | Supported without assembly scanning |
| Generic quantity algorithms | `UnitsNet.IQuantity<...>` capability contracts | Supported by generated quantities; the familiar namespace does not imply binary identity with legacy UnitsNet contracts |
| `UnitKey` | A unit enum in-process; semantic quantity ID plus invariant unit name across boundaries | Deliberately changed |
| `UnitSystem` / `BaseUnits` | `UnitsNet.UnitSystem` / `UnitsNet.BaseUnits` | Supported as immutable selected-module policy |
| `UnitsNetSetup` quantity selection | Module interfaces, profiles, and definition packages | Compile-time replacement |
| Runtime abbreviation mutation | Localization in definition metadata | Runtime mutation unsupported |
| Runtime conversion registration | Definition conversion expressions and relation definitions | Runtime mutation unsupported |
| Global `Quantity.FromUnitAbbreviation(...)` | Parse through a known quantity or present units from its descriptor | Deliberately unsupported |
| Legacy `UnitsNet.IQuantity` identity | Modular `UnitsNet.IQuantity<double>` | Namespace preserved; assembly identity and interface shape deliberately changed |

Persist `descriptor.Id` and `unit.Name`, not a localized abbreviation. Abbreviations are for parsing
and display and may be shared by unrelated quantities.

### Unit-system policy

The two packages expose intentionally different `UnitSystem` implementations under the same
source-compatible namespace. Since the packages cannot be referenced together, ordinary calls do
not need Modular-specific qualification:

```csharp
Length distance = Length.From(1.5, UnitSystem.SI);
double meters = Length.FromKilometers(1.5).As(UnitSystem.SI);
Length normalized = Length.FromFeet(3).ToUnit(UnitSystem.SI);
```

To define an application policy, use invariant constituent unit names:

```csharp
var imperial = new UnitSystem(
    new BaseUnits(length: "Foot"));

Length distance = new Length(3, imperial);
```

Resolution considers only units selected into the module.

### Dynamic creation, parsing, and formatting

The generated static `Quantity` facade is useful while preserving familiar call shapes:

```csharp
UnitsNet.IQuantity<double> byName =
    Quantity.From(1.5, "Length", "Kilometer");
UnitsNet.IQuantity<double> byUnit =
    Quantity.From(1.5, LengthUnit.Kilometer);
UnitsNet.IQuantity<double> parsed =
    Quantity.Parse(typeof(Length), "1.5 km");
```

For injected services and type-erased operations, depend on the registry:

```csharp
QuantityRegistry registry = GeneratedQuantityRegistry.Instance;
IQuantityDescriptor length = registry.Get(typeof(Length));
UnitsNet.IQuantity<double> parsed = registry.Parse(
    typeof(Length),
    "1.5 km",
    System.Globalization.CultureInfo.InvariantCulture);

string display = length.Format(
    parsed,
    "0.00",
    System.Globalization.CultureInfo.InvariantCulture);
```

`Try*` registry methods return `false` for unselected quantities, unselected or undefined units,
cross-quantity enum conversion, and invalid parse input.

## Migration checklist

- One assembly owns each generated quantity type used by the application.
- Built-ins use the default namespaces unless a deliberate application namespace is desired.
- All quantities, units, affine companions, and relationship participants are selected.
- No migrated project accidentally depends on both precompiled and generated types with the same
  full name.
- Dynamic code uses Modular contracts and the generated module registry.
- Runtime setup and registrations have moved to definitions and module selection.
- Persisted and external boundaries use semantic quantity IDs and invariant unit names.
- JSON, localization, parsing, formatting, conversion, and unit-system behavior have application
  tests.
- Binary consumers of `UnitsNet.dll` remain behind an explicit adapter.

```csharp
IReadOnlyList<IQuantityDescriptor> distances =
    registry.FindByBaseDimensions(Length.Info.BaseDimensions);
```

## Why the facade stays thin

`UnitsNetSetup`, mutable `UnitConverter` registrations, abbreviation-cache mutation, and mutable
global unit-system defaults are process-wide runtime policy. UnitsNet.Modular instead accepts an
immutable `UnitSystem` explicitly at each typed or dynamic operation. Selected definitions, units,
conversions, relationships, and localization remain compile-time inputs owned by the application.

The generated `Quantity` facade delegates to `Quantity.Registry` and returns
`UnitsNet.IQuantity<double>`. It does not own another catalog, conversion registry, or mutable
configuration. APIs that would pretend to mutate generated code remain absent.

Use an application adapter when a boundary genuinely needs runtime policy. Keep that adapter outside
`UnitsNet.Modular` and the generated quantities, and identify values by semantic quantity ID plus
invariant unit name. Existing plugins or assemblies compiled against `UnitsNet.dll` must retain
UnitsNet at that binary boundary and translate explicitly; matching generated full names do not
make the CLR types assignment-compatible.

For module configuration, custom definitions, diagnostics, and current limitations, continue with
the [UnitsNet.Modular README](README.md).
