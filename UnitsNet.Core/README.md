# UnitsNet.Core

`UnitsNet.Core` contains the contracts and immutable runtime foundation used by UnitsNet.Modular
during the source-generation proof of concept. The contracts are designed so UnitsNet v6 can adopt
them later, but the standalone prototype does not change or add a dependency to the existing
UnitsNet package.

The package deliberately contains no quantity catalog or generated quantity types. Its minimal
instance contract exposes a stored value and type-erased unit. The numeric-value-type self-typed
contract adds a strongly typed unit plus construction and conversion primitives. The
`IQuantity<TSelf, TUnit>` composite used by generated `double` quantities also requires their static
canonical `Info` object. This keeps identity, base-unit, dimension, and localization metadata off
each quantity instance while making it available to generic code through the same Core contract.

Core also owns the immutable metadata and shared conversion, parsing, and formatting foundation.
UnitsNet.Modular adds module registries, serialization integration, and source-generator packaging;
it does not define a second quantity interface.

Capability interfaces distinguish linear, affine, and logarithmic quantities. Linear quantities
advertise conventional generic-math operators and an additive zero; affine quantities add and
subtract a named linear offset and produce that offset when two values are subtracted; logarithmic
quantities identify their distinct scaling and arithmetic semantics without claiming conventional
generic math. `QuantityMath` provides shared `Sum` and `Average` algorithms for linear quantities,
while `AffineQuantityMath.Average` averages affine values in an explicit target unit. The algorithms
work for generated UnitsNet.Modular quantities. A separate integration experiment validates the same
algorithms against UnitsNet v6 quantities.

The capability layer is intentionally `double`-based for this POC. Generic numeric storage remains
a separate design experiment.

The contracts target .NET 8, 9, and 10. UnitsNet's `netstandard2.0` asset retains its existing API
without implementing these experimental contracts.
