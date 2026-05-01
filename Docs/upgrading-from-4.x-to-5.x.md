# Upgrading from 4.x to 5.x

Most of the removed code was marked as obsolete for a long time in v4 before removed in v5 with details on what to replace the usage with.

## Breaking changes

1. Localization is based on `CultureInfo.CurrentCulture` instead of `CurrentUICulture` (#795, #986)
1. `IQuantity` returns `QuantityValue` instead of `double` (#1074)
1. Decimal based quantities return `decimal` instead of `double` (`Power`, `BitRate` and `Information`) (#1074)
1. Equality changed to strict equality so BOTH unit and value must match exactly. 100 cm != 1 m. [Read more on why.](https://github.com/angularsen/UnitsNet/issues/1193#issuecomment-1424843242) **Fix: Use `Equals(other, tolerance, comparisonType)`.**

## New

1. `QuantityValue`: Implement IEquality, IComparable, IFormattable
1. `QuantityValue`: 16 bytes instead of 40 bytes (#1084)
1. Add `[DataContract]` annotations (#972)

## Removed

1. Remove targets: net40, net47, Windows Runtime Component. **Fix: Use netstandard2.0.**
1. Remove `Undefined` enum value for all unit enum types. **Fix: Use `null`.**
1. Remove `QuantityType` enum. **Fix: Use strings.**
1. Remove `IQuantity.Units` and `.UnitNames`. **Fix: Use QuantityInfo.**
1. Remove `GlobalConfiguration`. **Fix: Change CultureInfo.CurrentCulture.**
1. Remove `Molarity` ctor and operator overloads. **Fix: Use MassConcentration.FromMolarity(), ToMolarity().**
1. Remove `MinValue`, `MaxValue` per quantity due to ambiguity. **Fix: Define your own min/max quantity values.**
1. Remove string format specifiers: "v", "s". **Fix: Use `Value` property and standard .NET numeric format strings.**
1. json: Remove UnitsNetJsonConverter. **Fix: Use UnitsNetIQuantityJsonConverter or AbbreviatedUnitsConverter.**

## JSON unit definition schema changes

Rename `BaseType` to `ValueType`, for values "double" and "decimal".
Rename `XmlDoc` to `XmlDocSummary`.
