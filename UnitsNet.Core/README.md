# UnitsNet.Core

`UnitsNet.Core` contains experimental shared quantity contracts used by both UnitsNet v6 and
UnitsNetGen during the source-generation proof of concept.

The package deliberately contains no quantity catalog, parser registry, or generated quantity
types. Its minimal instance contracts expose stored values and strongly typed units. Its modern
self-typed contract exposes semantic identity, base unit, and construction as static members of the
quantity type without requiring independently generated structs to have the same CLR identity.

The contracts target .NET 8, 9, and 10. UnitsNet's `netstandard2.0` asset retains its existing API
without implementing these experimental contracts.
