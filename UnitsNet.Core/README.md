# UnitsNet.Core

`UnitsNet.Core` contains experimental quantity contracts used by UnitsNetGen during the
source-generation proof of concept. The contracts are designed so UnitsNet v6 can adopt them later,
but the standalone prototype does not change or add a dependency to the existing UnitsNet package.

The package deliberately contains no quantity catalog, parser registry, or generated quantity
types. Its minimal instance contracts expose stored values and strongly typed units. Its modern
self-typed contract exposes semantic identity, base unit, construction, and conversion without
requiring independently generated structs to have the same CLR identity. Its static `Convert`
primitive enables generic conversion without a global registry, while generated instance `As` and
`ToUnit` members retain the natural strongly typed API.

Capability interfaces distinguish linear, affine, and logarithmic quantities. Linear quantities
advertise conventional generic-math operators and an additive zero; affine quantities add and
subtract a named linear offset and produce that offset when two values are subtracted; logarithmic
quantities identify their distinct scaling and arithmetic semantics without claiming conventional
generic math. `QuantityMath` provides shared `Sum` and `Average` algorithms for linear quantities,
while `AffineQuantityMath.Average` averages affine values in an explicit target unit. The algorithms
work for generated UnitsNetGen quantities. A separate integration experiment validates the same
algorithms against UnitsNet v6 quantities.

The capability layer is intentionally `double`-based for this POC. Generic numeric storage remains
a separate design experiment.

The contracts target .NET 8, 9, and 10. UnitsNet's `netstandard2.0` asset retains its existing API
without implementing these experimental contracts.
