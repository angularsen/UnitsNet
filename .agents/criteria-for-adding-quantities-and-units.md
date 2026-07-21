# Criteria for adding quantities and units

See also: [Docs/adding-a-new-unit.md](../Docs/adding-a-new-unit.md#great-but-before-you-start) for the full contributor guide.

To avoid bloating the library, we want to ensure quantities and units are widely used and well defined.
Avoid little used units that are obscure or too domain specific.
Ask for justification and use cases if this is not clear.

### A quantity is a good fit to add, if it

- [x] Is well documented and unambiguous, e.g. has a wiki page and generally easy to find on Google
- [x] Is widely used, preferably across domains
- [x] Has multiple units to convert between (e.g. `Length` has kilometer, feet, nanometer etc.)
- [x] Can convert to other quantities (e.g. `Length x Length = Area`)
- [x] Can be represented by a `double` numeric value, integer values are not well supported and may suffer from precision errors
- [x] Is not [dimensionless/unitless](https://en.wikipedia.org/wiki/Dimensionless_quantity) (consider using `Ratio`)

Single-unit quantities are the exception. If a proposed quantity has only one unit, it needs stronger justification: the quantity must be widely used as a typed quantity representation on its own, not just as a unit abbreviation with no conversions.

### A unit is a good fit to add to a quantity, if it

- [x] Is well documented and unambiguous, e.g. has a wiki page or found in online unit converters
- [x] Is widely used
- [x] Can be converted to other units of the same quantity
- [x] The conversion function is well established without ambiguous competing standards

### Review test values for new units

- [x] Test values use literal constants, not expressions that repeat the JSON conversion functions
- [x] Test values preferably cite a verifiable source, such as an online converter, standard, or reference table
- [x] Test values have at least 7 significant figures where possible, but no more precision than `double` can usefully represent
- [x] The expected value independently sanity-checks the conversion function instead of mirroring its implementation

### Review abbreviations for new units

- [x] The primary abbreviation is the technically precise one when there is a clear distinction, such as `lbf`, `ozf`, or `gf` for force-derived compound units
- [x] Common shorthand variants such as `lb`, `oz`, or `g` are only secondary abbreviations, and only when they are widely used and unambiguous for that quantity
- [x] Shorthand aliases do not create ambiguity with another unit in the same quantity
- [x] Common shorthand aliases that fit multiple quantities are mapped to each relevant quantity, e.g. `ft-lb` for torque and energy, or `oz·in` for torque and static unbalance
- [x] Singular unit symbols such as `lb` and `oz` are preferred over pluralized forms such as `lbs` and `ozs`; pluralized forms should only be secondary aliases when they are strong domain conventions

### Avoid X-per-Y units

There are many variations of unit A over unit B, such as `LengthPerAngle` and we want to avoid adding these unless they are very common.
