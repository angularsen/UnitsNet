# Migrating dynamic UnitsNet workflows

UnitsNet.Modular targets source compatibility for ordinary strongly typed quantity code. Each
generated module gets a static `Quantity` facade for familiar dynamic call shapes plus an immutable
registry that can be passed explicitly to services and adapters. UnitsNet.Modular does not recreate
UnitsNet's mutable global setup or promise binary compatibility with `UnitsNet.dll`.

Built-in definitions preserve `using UnitsNet;` and `using UnitsNet.Units;` source by default.
Specify an application namespace with `[UnitsNetModule("MyApplication.Units")]` when a separate
generated namespace is preferable.

The POC's clean-slate capability contracts live in `UnitsNet.Core`, while current UnitsNet
interfaces live in `UnitsNet`. Migration code that imports both namespaces can therefore encounter
ambiguous short interface names. Ordinary concrete quantity code does not need
`using UnitsNet.Core;`. Generic migration code should use an alias until a later UnitsNet
integration decides whether the legacy and Core contract sets converge:

```csharp
using CoreQuantity = UnitsNet.Core.IQuantity<double>;

CoreQuantity value = Length.FromMeters(1);
```

With an explicit target namespace, `Quantity` is generated into that namespace. Otherwise, a module
that includes built-ins places it in `UnitsNet`; a custom-only module places it in the namespace
containing the module interface. Since one generated assembly has one module, each code owner
receives exactly one facade for its selected catalog.

## Dynamic workflow mapping

Assume the generated module is available through:

```csharp
using UnitsNet.Modular;
using UnitsNet.Modular.Generated;

QuantityRegistry registry = GeneratedQuantityRegistry.Instance;
```

| UnitsNet workflow | UnitsNet.Modular equivalent | Status |
|---|---|---|
| `Quantity.Names` | `Quantity.Names` or `registry.Names` | Supported, selected module only |
| `Quantity.Infos` | `Quantity.Infos` or `registry.Quantities` | Supported with immutable descriptors |
| `Quantity.ByName[name]` | `Quantity.ByName[name]` or `registry.Get(name)` | Supported, case-insensitive name |
| Lookup by quantity type | `registry.Get(typeof(Length))` | Supported |
| Stable cross-boundary identity | `registry.Get(new QuantityId("UnitsNet.Length"))` | Supported; use namespace-qualified IDs |
| Lookup from a unit enum type | `registry.GetByUnitType(typeof(LengthUnit))` | Supported |
| `Quantity.From(value, quantityName, unitName)` | Same facade call | Returns Core quantity contract |
| `Quantity.From(value, unitEnum)` | Same facade call | Returns Core quantity contract |
| `Quantity.TryFrom(...)` | Same facade call | Returns Core quantity contract |
| `UnitConverter.ConvertByName(...)` | `registry.Convert(value, quantityName, fromName, toName)` | Supported |
| `UnitConverter.Convert(value, fromEnum, toEnum)` | `registry.Convert(value, fromEnum, toEnum)` | Supported for one quantity |
| `UnitConverter.TryConvert...` | `registry.TryConvert(...)` | Supported for one quantity |
| `Quantity.Parse(type, text)` | Same facade call | Returns Core quantity contract |
| `Quantity.TryParse(...)` | Same facade call | Returns Core quantity contract |
| `Quantity.GetQuantitiesWithBaseDimensions(...)` | Same facade call or `registry.FindByBaseDimensions(...)` | Supported, selected module only |
| `QuantityInfo` / `UnitInfo` metadata | `QuantityInfo<TQuantity, TUnit>` / `UnitInfo<TUnit>`; `IQuantityDescriptor` / `UnitDescriptor` when type-erased | Supported as immutable metadata |
| Dynamic formatting through `IQuantity` | `descriptor.Format(value, format, provider)` | Supported with concrete-type validation |
| System.Text.Json converters | `GeneratedQuantityRegistry.JsonConverter` | Supported without assembly scanning |
| Generic quantity algorithms | `UnitsNet.Core.IQuantity<...>` capability contracts | Supported by generated quantities; UnitsNet adoption is a separate integration |
| `UnitKey` | A unit enum in-process; semantic quantity ID plus invariant unit name across boundaries | Deliberately changed |
| `UnitSystem` / `BaseUnits` | `UnitsNet.Modular.UnitSystem` / `UnitsNet.Modular.BaseUnits` | Supported as immutable selected-module policy |
| `UnitsNetSetup` quantity selection | Module interfaces, profiles, and definition packages | Compile-time replacement |
| Runtime abbreviation mutation | Localization in definition metadata | Runtime mutation unsupported |
| Runtime conversion registration | Definition conversion expressions and relation definitions | Runtime mutation unsupported |
| Global `Quantity.FromUnitAbbreviation(...)` | Parse through a known quantity or present units from its descriptor | Deliberately unsupported |
| Legacy `UnitsNet.IQuantity` identity | `UnitsNet.Core.IQuantity<double>` | Deliberately changed |

The `Try*` registry methods return `false` for unselected quantities, unselected or undefined units,
cross-quantity enum conversion, and invalid parse input. Throwing methods distinguish missing
quantities from invalid units with normal lookup and argument exceptions.

## Common examples

Use the owner-scoped facade when familiar static call shapes are useful:

```csharp
UnitsNet.Core.IQuantity<double> byName =
    Quantity.From(1.5, "Length", "Kilometer");
UnitsNet.Core.IQuantity<double> byUnit =
    Quantity.From(1.5, LengthUnit.Kilometer);
UnitsNet.Core.IQuantity<double> parsed =
    Quantity.Parse(typeof(Length), "1.5 km");
```

Use the registry directly when it is an injected dependency or when conversion should remain
type-erased:

```csharp
UnitsNet.Core.IQuantity<double> distance =
    registry.Create(1.5, LengthUnit.Kilometer);
double meters = registry.Convert(1.5, LengthUnit.Kilometer, LengthUnit.Meter);
```

Use an immutable unit system when the same constituent-unit policy should select a unit across
quantities:

```csharp
using UnitSystem = UnitsNet.Modular.UnitSystem;

Length distance = Length.From(1.5, UnitSystem.SI);
double meters = Length.FromKilometers(1.5).As(UnitSystem.SI);
Length normalized = Length.FromFeet(3).ToUnit(UnitSystem.SI);

UnitsNet.Core.IQuantity<double> dynamicDistance =
    Quantity.From(1.5, "Length", UnitSystem.SI);
double dynamicMeters =
    registry.Convert(1.5, "Length", "Kilometer", UnitSystem.SI);
```

`BaseUnits` stores invariant constituent unit names rather than enum values, so it remains neutral
to the generated owner namespace:

```csharp
var imperialLength = new UnitSystem(
    new UnitsNet.Modular.BaseUnits(length: "Foot"));
Length feet = new Length(3, imperialLength);
```

Resolution considers only units selected into the module. Dimensionless quantities use their base
unit; other quantities choose the first invariant-name-ordered unit whose constituent base units
are a subset of the policy, matching UnitsNet behavior. Throwing APIs report a missing match and
`Try*` APIs return `false`. `UnitsNet.Modular.UnitSystem` is intentionally a different immutable type
from `UnitsNet.UnitSystem`; compatibility-mode consumers can use the alias above during migration.

Parse and format after resolving a descriptor:

```csharp
IQuantityDescriptor length = registry.Get(typeof(Length));
UnitsNet.Core.IQuantity<double> distance = registry.Parse(
    typeof(Length),
    "1.5 km",
    System.Globalization.CultureInfo.InvariantCulture);
string display = length.Format(
    distance,
    "0.00",
    System.Globalization.CultureInfo.InvariantCulture);
```

Build a unit picker from immutable metadata. Persist `descriptor.Id` and `unit.Name`, not a localized
display abbreviation:

```csharp
IQuantityDescriptor descriptor = registry.Get("Length");
foreach (UnitDescriptor unit in descriptor.Units)
{
    IEnumerable<string> abbreviations =
        unit.Localizations.SelectMany(localization => localization.Abbreviations);
    Console.WriteLine($"{unit.Name}: {string.Join(", ", abbreviations)}");
}
```

Find the selected quantities that share dimensions:

```csharp
IReadOnlyList<IQuantityDescriptor> distances =
    registry.FindByBaseDimensions(Length.BaseDimensions);
```

## Why the facade stays thin

`UnitsNetSetup`, mutable `UnitConverter` registrations, abbreviation-cache mutation, and mutable
global unit-system defaults are process-wide runtime policy. UnitsNet.Modular instead accepts an
immutable `UnitSystem` explicitly at each typed or dynamic operation. Selected definitions, units,
conversions, relationships, and localization remain compile-time inputs owned by the application.

The generated `Quantity` facade delegates to `Quantity.Registry` and returns
`UnitsNet.Core.IQuantity<double>`. It does not own another catalog, conversion registry, or mutable
configuration. APIs that would pretend to mutate generated code remain absent.

Use an application adapter when a boundary genuinely needs runtime policy. Keep that adapter outside
`UnitsNet.Core` and the generated quantities, and identify values by semantic quantity ID plus
invariant unit name. Existing plugins or assemblies compiled against `UnitsNet.dll` must retain
UnitsNet at that binary boundary and translate explicitly; matching generated full names do not
make the CLR types assignment-compatible.
