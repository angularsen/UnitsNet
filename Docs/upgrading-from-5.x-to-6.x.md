# Upgrading from 5.x to 6.x

Before upgrading to a new major version, first upgrade to the latest minor version and follow instructions on any build warnings by code marked as obsolete. This can make it easier to migrate.

## Summary of changes in v6

The biggest change is removing support for `decimal` quantities and converting `Power`, `Information`, `BitRate` from `decimal` to `double`.
The value holder type `QuantityValue` is replaced by `double`.

The motivation was to remove a lot of complexity in the code base. Decimal was initially added for precision issues, but this was later fixed by storing both value and unit. Only `Information` still had any real benefit from `decimal`, to better represent `Bit` as an integer type and avoid rounding errors.

If there is still enough demand for representing bits as an integer or avoiding rounding errors in `Information` and other quantities, then we can approach that in a simpler way like `TimeSpan.Ticks` vs `TimeSpan.TotalSeconds`.

If there is sufficient demand for supporting any number type like `float`, `decimal` or even `Half`, then a more holistic approach is required using generics, which brings its own challenges.

## New

- Allow `NaN`, `Inf` values for quantities with `double` value type #1289

## Breaking changes

### Binary incompatible

- Remove `decimal` support in quantities #1359, everything is now `double`
    - Convert quantities `Power`, `Information`, `BitRate` from `decimal` to `double` #1195, #1353
    - Remove `QuantityValue`, replaced with `double`
- Remove `TValueType` from interfaces
    - Remove `IQuantity<TUnitType, out TValueType>`
    - Remove `IValueQuantity<out TValueType>`
    - Change `IQuantity<TSelf, TUnitType, out TValueType>` to `IQuantity<TSelf, TUnitType>`
    - Change `IArithmeticQuantity<TSelf, TUnitType, TValueType>` to `IArithmeticQuantity<TSelf, TUnitType>`
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

### Source incompatible

- `IQuantity.UnitInfo` is now a interface default member on .NET5+, and may compete with any custom property implemented in third party quantities #1649

### Behavioral change

None.

### Description of different kinds of incompatible changes

https://learn.microsoft.com/en-us/dotnet/core/compatibility/8.0

> Binary incompatible - When run against the new runtime or component, existing binaries may encounter a breaking change in behavior, such as failure to load or execute, and if so, require recompilation.
>
> Source incompatible - When recompiled using the new SDK or component or to target the new runtime, existing source code may require source changes to compile successfully.
>
> Behavioral change - Existing code and binaries may behave differently at run time. If the new behavior is undesirable, existing code would need to be updated and recompiled.

## JSON unit definition schema changes

- Removed `"ValueType": "decimal"` used for `decimal` quantities
