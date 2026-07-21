# UnitsNetGen

UnitsNetGen is a proof of concept for composing lean, strongly typed quantities and units at compile time. It combines a small runtime with a Roslyn source generator and supports both built-in SI definitions and consumer-owned JSON definitions.

Generated quantities and UnitsNet v6 quantities implement the shared
`UnitsNet.Core.IQuantity<TUnit, TValue>` contract. This enables generic source and data interoperation
without claiming that concrete structs generated into different assemblies have the same CLR type.

**Experimental:** UnitsNetGen's API and package format may change while the architecture is being explored.

## Select built-in quantities

Reference the package, then declare a module interface:

```csharp
using UnitsNetGen.BuiltIns;
using UnitsNetGen.Generation;

[UnitsNetModule]
internal interface EngineeringUnits :
    IInclude<Length>,
    IInclude<Temperature>,
    IInclude<Information>;
```

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

The generated API includes strongly typed quantity structs and unit enums, parsing, formatting, conversion, arithmetic, and localized abbreviations.

Generate the selected API in the established `UnitsNet` and `UnitsNet.Units` namespaces with
`[UnitsNetModule("UnitsNet")]`. The compatibility samples compile the exact same linked consumer
source against UnitsNet v6 and UnitsNetGen.

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

Custom definitions can also contribute relationships using the same equation format as the built-in
`Common/UnitRelations.json` catalog:

```xml
<ItemGroup>
  <UnitsNetGenRelation Include="HowMuch.unitsnet.relations.json" />
</ItemGroup>
```

```json
[
  "HowMuch.Lots = HowMuch.Some * HowMuch.Some -- NoInferredDivision"
]
```

Multiplication is expanded in both operand orders, and division relationships are inferred unless
the equation ends in `-- NoInferredDivision`. An operator is emitted only when its quantities and
the equation's units are selected in the same generated namespace.

## Learn more

See the [proof-of-concept architecture](https://github.com/angularsen/UnitsNet/blob/master/UnitsNetGen/ARCHITECTURE.md) and [sample projects](https://github.com/angularsen/UnitsNet/tree/master/UnitsNetGen/Samples) for the full design and working scenarios.
