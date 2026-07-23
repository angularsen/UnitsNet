# UnitsNet.Core

`UnitsNet.Core` contains experimental shared quantity contracts used by both UnitsNet v6 and
UnitsNetGen during the source-generation proof of concept.

The package deliberately contains no quantity catalog, parser registry, or generated quantity
types. Its minimal instance contracts expose stored values and strongly typed units. Its modern
self-typed contract exposes semantic identity, base unit, construction, and conversion without
requiring independently generated structs to have the same CLR identity.

Capability interfaces distinguish linear, affine, and logarithmic quantities. Linear quantities
advertise conventional generic-math operators and an additive zero; affine quantities avoid
claiming same-quantity arithmetic; logarithmic quantities identify their distinct scaling and
arithmetic semantics without claiming conventional generic math. `QuantityMath` provides shared
`Sum` and `Average` algorithms that work for both UnitsNet and UnitsNetGen linear quantities,
including mixed-unit sequences.

The capability layer is intentionally `double`-based for this POC. Generic numeric storage remains
a separate design experiment.

The contracts target .NET 8, 9, and 10. UnitsNet's `netstandard2.0` asset retains its existing API
without implementing these experimental contracts.
