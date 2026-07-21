# UnitsNet.Core

`UnitsNet.Core` contains experimental shared quantity contracts used by both UnitsNet v6 and
UnitsNetGen during the source-generation proof of concept.

The package deliberately contains no quantity catalog, parser registry, or generated quantity types.
Its contracts identify a quantity semantically and expose its stored and base-unit values without
requiring the concrete quantity struct to have the same CLR identity.
