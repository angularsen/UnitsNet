# Precision of Conversions and Representations

Units.NET was not designed for high-precision, but rather a tool of convenience and simplicity. As a result, there is usually a small error involved in both representing a value of a unit and converting between units. We are open to ideas how to improve this, while still keeping it simple and convenient.

- A base unit is chosen for all quantities
  - SI base unit is preferred where available, such as `LengthUnit.Meter` and `VolumeUnit.CubicMeter`.
  - See the [`BaseUnit` schema reference](quantity-and-unit-definition-schema.md#quantity-object) for how it is declared.
  - `MassUnit.Gram` was chosen to better support SI prefixes like `kilo`, `mega` etc.
- The value is typically represented by a `double` value (64-bit)
- Conversions go via the base unit.
  - Centimeter => Meter => Kilometer
  - As a result, most conversions have a rounding error. The error is larger for units that are way larger or way smaller than the base unit.
  - A rounding error of `1e-5` is accepted for round-trip conversion of most units in the library. In many use cases this is sufficient, but for others this may not be acceptable.
  - In v6, unit conversion definitions can be customized before the converter is built. This can be used to override a built-in conversion factor or add conversion functions for custom quantities.

## Overriding built-in unit conversions

Built-in unit definitions can be customized through `UnitsNetSetup.ConfigureDefaults()` before the default setup is used:

```csharp
UnitsNetSetup.ConfigureDefaults(builder => builder.ConfigureQuantity(() =>
    Pressure.PressureInfo.CreateDefault(units =>
        units.Configure(PressureUnit.InchOfWaterColumn, unit =>
            unit.WithConversionFactorFromBase(999)))));

var pressure = Pressure.FromPascals(1);
double value = pressure.As(PressureUnit.InchOfWaterColumn); // 999
```

For isolated conversions, create a custom `QuantityInfo` and pass it to a custom `UnitConverter` instead of changing the global defaults. See `Samples/UnitsNetSetup.Configuration/ConfigureWithCustomConversions.cs` for a complete example.

## Test precision

When adding test values for unit conversions:
- Use **at least 7** [significant figures](https://en.wikipedia.org/wiki/Significant_figures) where possible
- Beyond **16** significant digits is not useful due to `double` precision limits
- Tests accept an error margin of `1e-5` for most units
