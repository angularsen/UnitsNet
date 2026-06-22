# Upgrading from 3.x to 4.x

The 4.0 release addresses a long wishlist of breaking changes accumulated over the years. The main theme was about binary size so we removed a lot of code we considered unnecessary syntactic sugar, such as number extension methods and nullable factory methods. We also heavily restructured some core types such as splitting up the `UnitSystem` God-class and addressed behavior we considered incorrect or not optimal.

This document lists the most common upgrade paths we expect you to come across when upgrading.

## UnitSystem removed

`UnitSystem` was first split up and removed into more specific classes. Later an entirely new `UnitSystem` was added to represent a choice of base unit dimensions.

### UnitSystem abbreviations => UnitAbbreviationsCache

For looking up or mapping custom unit abbreviations for unit enum types only known at runtime, use `UnitAbbreviationsCache` instead of `UnitSystem`:
```c#
var abbreviations = UnitAbbreviationsCache.Default;
abbreviations.GetAllUnitAbbreviationsForQuantity(typeof(LengthUnit)); // ["cm", "dm",...]
abbreviations.GetUnitAbbreviations(typeof(LengthUnit), 6); // ["ft", "'", "`"]
abbreviations.GetDefaultAbbreviation(typeof(LengthUnit), 1); // "cm"
abbreviations.MapUnitToAbbreviation(typeof(LengthUnit), 1, new CultureInfo("en-US"), "foo"); // add custom abbreviation for centimeter
```

Looking up abbreviations for static quantity types, you can use `Length.Units` as before.

### UnitSystem parsing => UnitParser

Dynamic parsing of unit abbreviations, where unit enum type is only known at runtime, is now done by `UnitParser`:
```c#
var parser = UnitParser.Default;
parser.Parse("cm", typeof(LengthUnit)); // 1
parser.TryParse("cm", typeof(LengthUnit), out object val); // returns true, val = 1
```

For static parsing, you can use `Length.ParseUnit("cm")` as before.

### UnitSystem.DefaultCulture => GlobalConfiguration.DefaultCulture

To change the default culture used by `ToString()` in quantities:
```c#
GlobalConfiguration.DefaultCulture = new CultureInfo("en-US"); // instead of UnitSystem.DefaultCulture
```

### Removed static methods on UnitSystem

Use `UnitParser.Default` or `UnitAbbreviationsCache.Default` instead, or create an instance for the culture of your own choice.

## Quantity types

### Nullable From-methods removed

```c#
int? val = null;

// Instead of this
Length? l = Length.FromMeters(val);

// Do this, or create your own convenience factory method
Length? l = val == null ? (Length?)null : Length.FromMeters(val.Value);
```

### Remove unit parameter from ToString() methods

```c#
// Instead of
myLength.ToString(LengthUnit.Centimeter); // "100 cm"

// Do this
myLength.ToUnit(LengthUnit.Centimeter).ToString(); // "100 cm"
```

### Stricter parsing

```c#
// Instead of
var l = Length.Parse("5ft 3in"); // Throws FormatException

// Do this, special case for feet/inches
var l = Length.ParseFeetInches("5ft 3in");

// Everything else only supports these formats
var l = Length.Parse("1cm");
var l = Length.Parse("1 cm");
var l = Length.Parse("1  cm"); // Multi-space allowed
var l = Length.Parse(" 1 cm "); // Input is trimmed
```

## Length2d removed

Provide your own or use `Area` if applicable.

## Number extension methods removed

Either create your own or use From factory methods.
```c#
Length m = 1.Meters(); // No longer possible
Length m = Length.FromMeters(1); // Use this instead
```

## Do not allow NaN or Infinity

```c#
// Instead of
Length m = new Length(double.NaN, LengthUnit.Meter); // Throws ArgumentException
if(double.IsNaN(m.Value))
  // handle NaN

// Do this
Length? m = null;
if(m == null)
  // handle null
```

## UnitsNet.Serialization.JsonNet 1.x to 4.x

There are no breaking changes in this version jump, the change only reflects a new versioning strategy to share major semver version with UnitsNet. This means consumers need to upgrade this library to 4.x to use UnitsNet 4.x, but no other actions or migrations are needed.
