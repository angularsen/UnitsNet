# UnitsNetGen

UnitsNetGen is a proof of concept for composing lean, strongly typed quantities and units at compile time. It combines a small runtime with a Roslyn source generator and supports both built-in SI definitions and consumer-owned JSON definitions.

**Experimental:** UnitsNetGen's API and package format may change while the architecture is being explored.

## Select built-in quantities

Reference the package, then declare a module interface:

```csharp
using UnitsNetGen.BuiltIns;
using UnitsNetGen.Generation;

[UnitsNetModule]
internal interface EngineeringUnits :
    IInclude<Length>,
    IInclude<Force>,
    IInclude<Pressure>;
```

Select a subset of units with a regular expression:

```csharp
[UnitSet("regex:.*Gram$")]
internal interface GramUnits;

[UnitsNetModule]
internal interface LeanUnits : IInclude<Mass, GramUnits>;
```

The generated API includes strongly typed quantity structs and unit enums, parsing, formatting, conversion, arithmetic, and localized abbreviations.

## Add custom quantities

Add a UnitsNet-style JSON definition to the project:

```xml
<ItemGroup>
  <UnitsNetGenDefinition Include="HowMuch.unitsnet.json" />
</ItemGroup>
```

Bind a marker to the definition's logical namespace and name, then select it like a built-in quantity:

```csharp
namespace Fictional;

using UnitsNetGen.Generation;

[QuantityDefinition("Fictional.Measurements.HowMuch")]
public interface HowMuchDefinition;

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchDefinition>;
```

Custom definitions support localized abbreviations, prefix expansion, and affine or nonlinear conversion expressions.

## Learn more

See the [proof-of-concept architecture](https://github.com/angularsen/UnitsNet/blob/master/UnitsNetGen/ARCHITECTURE.md) and [sample projects](https://github.com/angularsen/UnitsNet/tree/master/UnitsNetGen/Samples) for the full design and working scenarios.
