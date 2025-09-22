# Criteria for adding quantities and units

Related wiki page: https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit#a-quantity-is-a-good-fit-to-add-if-it

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

### A unit is a good fit to add to a quantity, if it

- [x] Is well documented and unambiguous, e.g. has a wiki page or found in online unit converters
- [x] Is widely used
- [x] Can be converted to other units of the same quantity
- [x] The conversion function is well established without ambiguous competing standards

### Avoid X-per-Y units

There are many variations of unit A over unit B, such as `LengthPerAngle` and we want to avoid adding these unless they are very common.