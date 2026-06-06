# Precision of Conversions and Representations

Units.NET was not designed for high-precision, but rather a tool of convenience and simplicity. As a result, there is usually a small error involved in both representing a value of a unit and converting between units. We are open to ideas how to improve this, while still keeping it simple and convenient.

- A base unit is chosen for all quantities
  - SI base unit is preferred where available, such as `LengthUnit.Meter` and `VolumeUnit.CubicMeter`.
  - `MassUnit.Gram` was chosen to better support SI prefixes like `kilo`, `mega` etc.
- The value is typically represented by a `double` value (64-bit)
- Conversions go via the base unit.
  - Centimeter => Meter => Kilometer
  - As a result, most conversions have a rounding error. The error is larger for units that are way larger or way smaller than the base unit.
  - A rounding error of `1e-5` is accepted for round-trip conversion of most units in the library. In many use cases this is sufficient, but for others this may not be acceptable.
  - There is support for [custom conversion functions](https://github.com/angularsen/UnitsNet#convert-between-units-of-custom-quantity) between unit A to unit B, typically to add 3rd party units. This can also be used to improve the precision for specific conversions since it no longer converts via the base unit.

## Test precision

When adding test values for unit conversions:
- Use **at least 7** [significant figures](https://en.wikipedia.org/wiki/Significant_figures) where possible
- Beyond **16** significant digits is not useful due to `double` precision limits
- Tests accept an error margin of `1e-5` for most units
