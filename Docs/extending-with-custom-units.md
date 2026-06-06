# Extending with Custom Units

This article is for when you want to add your own custom quantities and units at runtime, not included in the UnitsNet nuget.

To add new quantities or units to the `UnitsNet` nuget, please see [Adding a New Unit](adding-a-new-unit.md).

## Disclaimer: This is highly experimental and incomplete

You miss out on the statically generated code for members like `Length.FromMeters(1)` and `myLength.Meters`.
Conversion methods like `myLength.As()` and `myLength.ToUnit()` currently only support their respective unit enums, in this case `LengthUnit`.

## Can I add a custom unit to an existing quantity in UnitsNet?

Currently, no.

You can only add new custom quantities with their own units and you can only add it at runtime. No code generation.

See [example quantity `HowMuch` below](#example-custom-quantity-howmuch-with-units-howmuchunit).

Since UnitsNet is so statically typed, your options are limited to:
1. Submit a pull request to [add a new unit](adding-a-new-unit.md) to the UnitsNet nuget
2. Build your own custom version of UnitsNet

## Why add a custom quantity?

Good question.

In its current state, the support for custom quantities and units is limited and provides limited integration with the existing units and code.
We consider it exploratory, to see what is possible, and we welcome ideas on how it can be improved.

### Key benefits

- Reuse functionality that operates on `IQuantity`
  - Dynamically convert to unit with `.As(Enum)`
  - `UnitMath` with min, max, sum, average etc.
  - .NET generic math support, currently sum and average.
- Reuse `UnitConverter` to dynamically convert between units by their enum values
  - Also allows you to dynamically convert between your custom units and the built-in units, such as `CustomLengthUnit.ElbowToThumb` to `LengthUnit.Meter`.
- Reuse `QuantityParser` and `UnitParser` to parse quantity strings like "5 cm" and "cm" for your own quantities and units

### What could be better

- Source generators via nuget, if possible [Using source generators #902](https://github.com/angularsen/UnitsNet/issues/902)
- String-based lookup instead of enum-based for quantity methods like `As()` and `ToUnit()`, required for [XP One nuget per quantity #1181](https://github.com/angularsen/UnitsNet/pull/1181)

Got more ideas? Create a discussion or issue.

## Units.NET structure

Units.NET roughly consists of these parts:
* Quantities like `Length` and `Force`
* Unit enum values like `LengthUnit.Meter` and `ForceUnit.Newton`
* `UnitAbbreviationsCache`, `UnitParser`, `QuantityParser` and `UnitConverter` for parsing and converting quantities and units
* JSON files for defining units, conversion functions and abbreviations
* `CodeGen` console app to generate C# code based on JSON files

## Example: Custom quantity `HowMuch` with units `HowMuchUnit`

### Sample output
```
GetDefaultAbbreviation(): sm, lts, tns
Parse<HowMuchUnit>(): Some, Lots, Tons

Convert 10 tons to:
200 sm
100 lts
10 tns
```

### Map unit enum values to unit abbreviations

```c#
UnitAbbreviationsCache.Default.MapUnitToDefaultAbbreviation(HowMuchUnit.Some, "sm");
UnitAbbreviationsCache.Default.MapUnitToDefaultAbbreviation(HowMuchUnit.Lots, "lts");
UnitAbbreviationsCache.Default.MapUnitToDefaultAbbreviation(HowMuchUnit.Tons, "tns");
```

### Lookup unit abbreviations from enum values

```c#
Console.WriteLine("GetDefaultAbbreviation(): " + string.Join(", ",
    UnitAbbreviationsCache.Default.GetDefaultAbbreviation(HowMuchUnit.Some), // "sm"
    UnitAbbreviationsCache.Default.GetDefaultAbbreviation(HowMuchUnit.Lots), // "lts"
    UnitAbbreviationsCache.Default.GetDefaultAbbreviation(HowMuchUnit.Tons)  // "tns"
));
```

### Parse unit abbreviations back to enum values

```c#
Console.WriteLine("Parse<HowMuchUnit>(): " + string.Join(", ",
    UnitParser.Default.Parse<HowMuchUnit>("sm"),  // Some
    UnitParser.Default.Parse<HowMuchUnit>("lts"), // Lots
    UnitParser.Default.Parse<HowMuchUnit>("tns")  // Tons
));
```

### Convert between units of custom quantity

```c#
var unitConverter = UnitConverter.Default;
unitConverter.SetConversionFunction<HowMuch>(HowMuchUnit.Lots, HowMuchUnit.Some, x => new HowMuch(x.Value * 2, HowMuchUnit.Some));
unitConverter.SetConversionFunction<HowMuch>(HowMuchUnit.Tons, HowMuchUnit.Lots, x => new HowMuch(x.Value * 10, HowMuchUnit.Lots));
unitConverter.SetConversionFunction<HowMuch>(HowMuchUnit.Tons, HowMuchUnit.Some, x => new HowMuch(x.Value * 20, HowMuchUnit.Some));

var from = new HowMuch(10, HowMuchUnit.Tons);
IQuantity Convert(HowMuchUnit toUnit) => unitConverter.GetConversionFunction<HowMuch>(from.Unit, toUnit)(from);

Console.WriteLine($"Convert 10 tons to:");
Console.WriteLine(Convert(HowMuchUnit.Some)); // 200 sm
Console.WriteLine(Convert(HowMuchUnit.Lots)); // 100 lts
Console.WriteLine(Convert(HowMuchUnit.Tons)); // 10 tns
```

### Sample quantity

See the sample implementation in the test suite:
- [HowMuchUnit.cs](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet.Tests/CustomQuantities/HowMuchUnit.cs)
- [HowMuch.cs](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet.Tests/CustomQuantities/HowMuch.cs)
