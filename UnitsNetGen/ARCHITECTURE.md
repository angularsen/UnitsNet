# UnitsNetGen proof-of-concept architecture

## Goal

UnitsNetGen explores a compile-time composition model for a future UnitsNet architecture. A module author selects only the quantities and units that belong in an assembly, while generated quantity structs keep the strongly typed API and share a small runtime for conversion, parsing, and formatting.

This is intentionally standalone. It does not reference or reuse any existing UnitsNet interface, runtime type, generated type, or code-generation model.

The experiment is inspired by [the modular-package experiment](https://github.com/angularsen/UnitsNet/pull/1181), [the source-generator discussion](https://github.com/angularsen/UnitsNet/issues/902), and the current [Roslyn source-generator model](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md).

## Feasibility conclusions

The idea is viable if the unit of composition is a **module assembly**:

1. A module declares an interface that selects quantity definitions.
2. One incremental generator resolves the selection and emits only the selected quantity and unit types into that module.
3. Applications and libraries reference the module assembly in the normal way.

The module boundary is important because a generated public type has the identity of the assembly into which it is generated. If two unrelated assemblies both generate `Length`, those are distinct CLR types. A reusable library should therefore generate its public quantities once and ship that module, rather than require every downstream consumer to regenerate them.

Roslyn generators are additive and unordered; a generator cannot consume another generator's output in the same compilation. Consequently, UnitsNetGen uses one generator for built-in and custom definitions. Marker attributes and interfaces are constant bootstrap source emitted during post-initialization, while all selected quantity output is produced by the same generation pipeline.

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

Patterns prefixed with `regex:` use case-insensitive, culture-invariant regular expressions with a timeout. Patterns prefixed with `glob:` support `*`, and bare patterns retain glob behavior for convenience. The generator always includes the base unit so every selected quantity remains convertible. It reports compile-time diagnostics for invalid expressions and patterns that match no units.

Custom quantities use JSON definition files. The custom MSBuild item is converted to Roslyn `AdditionalFiles` by a target that the generator package places under `buildTransitive/`:

```xml
<ItemGroup>
  <UnitsNetGenDefinition Include="HowMuch.unitsnet.json" />
</ItemGroup>
```

The JSON shape follows the existing UnitsNet quantity definitions and adds an optional `Namespace` for stable third-party identity; it defaults to `UnitsNetGen`, allowing files such as the existing `Length.json` to be consumed unchanged. It supports localized abbreviations, prefix expansion, and `FromUnitToBaseFunc`/`FromBaseToUnitFunc` expressions. A minimal marker binds type-safe module selection to the JSON's logical `Namespace.Name` ID:

```csharp
namespace Fictional;

using UnitsNetGen.Generation;

[QuantityDefinition("Fictional.Measurements.HowMuch")]
public interface HowMuchDefinition;

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchDefinition>;
```

Conversion expressions are parsed as C# expressions and restricted to numeric literals, `x`, arithmetic operators, parentheses, `Math.PI`, `Math.E`, and an allowlist of numeric `Math` functions. The generator emits the validated expressions directly into conversion switches; it does not compile expressions or use reflection at runtime. A definition package can contain public marker types and JSON definitions while the module that selects them owns the generated runtime types.

## Projects

- `UnitsNetGen`: the lean runtime and the new `IQuantity<TUnit>` contract.
- `UnitsNetGen.Generator`: the incremental generator, marker bootstrap source, built-in catalog, diagnostics, and emitters.
- `UnitsNetGen.Tests`: generated API and runtime behavior tests.
- `Samples/UnitsNetGen.AllSi.Sample`: all ten POC quantities and conditional derived-quantity operators.
- `Samples/UnitsNetGen.Lean.Sample`: Length plus only Mass units matching `regex:.*Gram$`.
- `Samples/UnitsNetGen.Custom.Sample`: a fictional `HowMuch` quantity in its own namespace.

The projects live in their own solution and do not participate in the existing UnitsNet solution.

## Generated surface

For each selected definition, the generator emits:

- a unit enum containing only selected units;
- an immutable strongly typed quantity struct;
- typed `FromXxx()` factories and `.Xxx` conversion properties;
- `As()`, `ToUnit()`, `Parse()`, `TryParse()`, and `ToString()`;
- equality, comparison, same-quantity addition/subtraction, and scalar multiplication/division;
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

The relationship operators work in base units and return the result's base unit. They disappear when a module omits one of the involved quantities, avoiding hidden dependencies.

## POC catalog

The embedded catalog is deliberately small: Length, Mass, Duration, Area, Speed, Acceleration, Force, Pressure, Energy, and Power. JSON-backed custom definitions exercise multiple cultures, multiple abbreviations, prefix expansion, arithmetic conversion expressions, and allowlisted nonlinear `Math` functions.

## Deliberate limitations

- This is a design probe, not a compatibility layer for UnitsNet v6.
- Quantity values use `double` only.
- Serialization, unit systems, generic math, logarithmic quantity semantics, culture selection, and rich parse ambiguity handling are deferred.
- Regex/glob patterns filter expanded unit names, not abbreviations.
- Prefix expansion uses a common SI/binary prefix table; it does not yet reproduce every culture-specific prefix convention from UnitsNet v6.
- Third-party public API authors must ship a generated module to establish stable type identity.
- Multiple module marker interfaces in one project are merged into one generated set. Conflicting selections produce one union.

## What this POC should prove

1. Omitting a quantity prevents its type and metadata from entering the consumer assembly.
2. Unit patterns reduce the generated enum and typed API.
3. Built-in and custom quantities share the same runtime behavior and strongly typed surface.
4. Cross-quantity APIs can be conditional rather than forcing a monolithic dependency graph.
5. No runtime reflection or assembly scanning is required.
