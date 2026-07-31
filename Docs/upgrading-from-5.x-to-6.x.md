# Upgrading from 5.x to 6.x

Before upgrading to a new major version, first upgrade to the latest minor version and follow instructions on any build warnings by code marked as obsolete. This can make it easier to migrate.

## Summary of changes in v6

The main change is that all quantities now use the fraction-backed `QuantityValue` type instead of `double` or `decimal`.
Unit definitions are also generated as exact conversion expressions. This preserves exact relationships such as inches to
centimeters and avoids accumulating floating-point error through intermediate conversions.

`QuantityValue` interoperates with the standard numeric types: numeric values convert implicitly to `QuantityValue`, and
`QuantityValue` converts implicitly to `double`. Code that explicitly declares `double` variables will therefore often
continue to compile, while code using `var` will now infer `QuantityValue`. Unit conversions and arithmetic remain exact
while values stay as `QuantityValue`; converting a value to `double` is the boundary where values that cannot be represented
as binary floating point lose precision.

## New

- Allow `NaN` and infinity values in quantities #1289
- Exact fractional values, arithmetic and generated unit conversions with `QuantityValue` #1544
- `UnitsNet.Serialization.SystemTextJson`, with configurable quantity, unit and value converters #1544

## Breaking changes

### Binary incompatible

- Rework `QuantityValue` as a fraction-backed number and use it for every quantity value #1544
    - `IQuantity.Value`, generated unit properties, `.As()`, ratio methods and related conversion APIs now return `QuantityValue`
    - Quantity factories and constructors now accept `QuantityValue`; standard numeric arguments continue to work through implicit conversions
    - `Power`, `Information` and `BitRate` no longer have a separate `decimal` value type
- Rework `UnitConverter` configuration and conversion APIs around exact generated conversion expressions #1544
- Remove `TValueType` from interfaces
    - Remove `IQuantity<TUnitType, out TValueType>`
    - Remove `IValueQuantity<out TValueType>`
    - Change `IQuantity<TSelf, TUnitType, out TValueType>` to `IQuantity<TSelf, TUnitType>`
    - Change `IArithmeticQuantity<TSelf, TUnitType, TValueType>` to `IArithmeticQuantity<TSelf, TUnitType>`
- Move `IQuantity.As()` and `IQuantity.ToUnit()` from the quantity interfaces to `QuantityExtensions` #1696
- Remove obsolete units #1372
    - `CoefficientOfThermalExpansion.InverseKelvin`, `InverseDegreeCelsius`, `InverseDegreeFahrenheit`
    - `HeatTransferCoefficient.BtuPerSquareFootDegreeFahrenheit`
- Fix typo in plural form of several units #1347, #1351
    - `TemperatureGradient.DegreesCelsiusPerMeter`
    - `Density.GramsPerDeciliter`
    - `ElectricPotentialChangeRate.VoltsPerSecond`, `VoltsPerMicrosecond`, `VoltsPerMinute`, `VoltsPerHour`
    - `FuelEfficiency.KilometersPerLiter`
    - `Speed.MetersPerMinute`
- Moved 29 operator overloads for multiply or division to another type ([details](https://github.com/angularsen/UnitsNet/pull/1329#discussion_r1451794868)), e.g. `Energy op_Multiply(Duration, Power)` moved from `Power` to `Duration` #1329
- Rename or remove ambiguous prefixed cubic units #1617, #1645, #1700
    - `SpecificVolumeUnit.MillicubicMeterPerKilogram` -> `SpecificVolumeUnit.CubicMillimeterPerKilogram`
    - Remove `VolumeUnit.HectocubicMeter`; use `VolumeUnit.CubicMeter` for 100 m³ values
    - `VolumeUnit.KilocubicMeter` -> `VolumeUnit.ThousandCubicMeter`
    - `VolumeUnit.HectocubicFoot` -> `VolumeUnit.HundredCubicFoot`
    - `VolumeUnit.KilocubicFoot` -> `VolumeUnit.ThousandCubicFoot`
    - `VolumeUnit.MegacubicFoot` -> `VolumeUnit.MillionCubicFoot`

### Source incompatible

- `IQuantity.UnitInfo` is now a interface default member on .NET5+, and may compete with any custom property implemented in third party quantities #1649
- Custom quantity implementations must expose `QuantityValue` from `IQuantity.Value` and accept it in their quantity factories. #1544
- Expressions inferred with `var`, such as `var value = quantity.Value` or `var value = quantity.As(unit)`, now have type `QuantityValue`. Cast to `double` when a floating-point result is specifically required. #1544
- Custom quantities that explicitly implement `IQuantity.As()`, `IQuantity.ToUnit()`, `IQuantity<TUnitType>.As()` or `IQuantity<TUnitType>.ToUnit()` must remove those explicit interface implementations. The methods may remain as ordinary members if they are also part of the custom quantity's public API. #1696

### Behavioral change

- Exact rational conversions and arithmetic may produce results that differ from the previous `double` implementation in the least significant digits. Precision can be lost when a `QuantityValue` is converted to `double`; perform that conversion only at boundaries where floating-point behavior is required. #1544
- Calls to `.As()` and `.ToUnit()` through an `IQuantity` or `IQuantity<TUnitType>` reference now use the `QuantityExtensions` methods and `UnitConverter.Default`. They no longer dispatch to type-specific methods defined by a custom quantity. Custom quantities that need these calls to support conversion must register their conversion functions with `UnitConverter.Default`. #1696
- Calling these extension methods with an incompatible unit type now throws `UnitNotFoundException` instead of `ArgumentException`. Code that catches `ArgumentException` around interface-based conversions may need to be updated. #1696
- `SpecificVolume` abbreviation `mm³/kg` now parses as true cubic millimeters per kilogram (`1e-9 m³/kg`) instead of millesimal cubic meters per kilogram.
- `Volume` abbreviations `hm³` and `km³` now parse unambiguously as true cubic hectometers and cubic kilometers.
- Thousand cubic meters now formats as `10³·m³`, with `kcm` and `Kcm` as parsing aliases.
- Count-style cubic-foot volume units now format as `Ccf`, `Mcf`, and `MMcf`.

### Serialization

The serialized form of a quantity can change because its `Value` is now a `QuantityValue`. Review persisted payloads and
choose an explicit value format when compatibility matters:

- `UnitsNet.Serialization.JsonNet` uses `DecimalPrecision` when writing and `ExactNumber` when reading by default. It also
  supports double precision, exact round-tripping and custom value converters through `QuantityValueFormatOptions`.
- The new `UnitsNet.Serialization.SystemTextJson` package provides converters for concrete quantities, `IQuantity`, units
  and several `QuantityValue` representations.
- The default `DataContractSerializer` representation exposes the internal `BigInteger` fields of the fraction's
  numerator and denominator. Use `QuantityValueSurrogateSerializationProvider` for a compact, stable numerator and
  denominator representation in XML.
- `DataContractJsonSerializer` cannot apply that surrogate provider to nested `QuantityValue` instances due to
  [dotnet/runtime#100553](https://github.com/dotnet/runtime/issues/100553). Use the Json.NET or System.Text.Json package
  instead.

See [Serialization](serialization.md) for examples.

### Ambiguous prefixed cubic units

Previous versions generated some cubic units from metric prefixes where the prefix applied to the generated unit name,
but users would reasonably read the abbreviation as applying before cubing the length unit. For example, `km³` should
mean `(1000 m)³`, not `1000 m³`.

In v6, `hm³` and `km³` are reserved for the existing `CubicHectometer` and `CubicKilometer` units. The old
`HectocubicMeter` API was removed. For 100 cubic meters, use `Volume.FromCubicMeters(100)` or
`volume.As(VolumeUnit.CubicMeter)` instead.

The old `KilocubicMeter` API represented 1000 cubic meters, which is a real count-style unit in some domains. It was
renamed to `ThousandCubicMeter` and formats as `10³·m³`. It also accepts `kcm` and `Kcm` as aliases.

For cubic feet, the generated prefix names were renamed to count-style names:

- `HectocubicFoot` -> `HundredCubicFoot`, default abbreviation `Ccf`
- `KilocubicFoot` -> `ThousandCubicFoot`, default abbreviation `Mcf`
- `MegacubicFoot` -> `MillionCubicFoot`, default abbreviation `MMcf`

The old generated cubic-foot abbreviations such as `hft³`, `kft³`, and `Mft³` are still accepted as aliases where they
do not conflict with another unit.

### Description of different kinds of incompatible changes

https://learn.microsoft.com/en-us/dotnet/core/compatibility/8.0

> Binary incompatible - When run against the new runtime or component, existing binaries may encounter a breaking change in behavior, such as failure to load or execute, and if so, require recompilation.
>
> Source incompatible - When recompiled using the new SDK or component or to target the new runtime, existing source code may require source changes to compile successfully.
>
> Behavioral change - Existing code and binaries may behave differently at run time. If the new behavior is undesirable, existing code would need to be updated and recompiled.

## JSON unit definition schema changes

- Removed `"ValueType": "decimal"` used for `decimal` quantities
