# String Formatting

## Common examples

Assuming computer running with US English culture.
```c#
var length = Length.FromCentimeters(3.14159265358979);

// Typical formats
length.ToString(); // 3.14 cm
length.ToString("s4"); // 3.1416 cm

// Localized
length.ToString(new CultureInfo("nb-NO")); // 3,14 cm
length.ToString(new CultureInfo("ru-RU")); // 3,14 sm (Cyrillic)

// Converted
length.As(LengthUnit.Meters).ToString(); // 0.13 m

// Use .NET's built-in formatting methods
Console.WriteLine("Length is {0:v} {0:a}", l); // "Length is 3.14159265358979 ft"
string.Format("Length is {0:v} {0:a}", l); // "Length is 3.14159265358979 ft"
$"Length is {l:v} {l:a}"; // "Length is 3.14159265358979 ft"
```

## Standard Quantity Format Strings

| Format specifier | Description | Examples |
|------------------|-------------|---------|
| "g" | General quantity pattern. Equivalent to parameterless `ToString()`. Rounds to 2 significant digits after the radix. | `Length.FromFeet(Math.PI).ToString("g")` -> 3.14 ft |
| `f`, `f2`, ... `e`, `e3`, ... `r` `#.0` `00000.0` | [Standard numeric formatting](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers) of value, with unit appended. | `Length.FromFeet(Math.PI).ToString("f")` -> 3.140 ft, `Length.FromFeet(Math.PI).ToString("f1")` -> 3.1 ft, `Length.FromFeet(Math.PI).ToString("r")` -> 3.141592653589793 ft, `Length.FromFeet(Math.PI).ToString("e2")` -> 3.14e+000 ft, `Length.FromFeet(Math.PI).ToString("#.0")` -> 3.1 ft, `Length.FromFeet(Math.PI).ToString("00.0")` -> 003.1 ft |
| "aXX" | Unit abbreviation pattern. If more than one abbreviation is defined for the unit, then XX specifies the zero-indexed position in the array of abbreviations. XX defaults to 0. If the position is not found, `System.FormatException` is thrown. | `Length.FromFeet(Math.PI).ToString("a")` -> ft, `Length.FromFeet(Math.PI).ToString("a0")` -> ft, `Length.FromFeet(Math.PI).ToString("a1")` -> ', `Length.FromFeet(Math.PI).ToString("a2")` -> prime symbol, `Length.FromFeet(Math.PI).ToString("a3")` -> System.FormatException |
| "q" | Quantity name pattern. Outputs the corresponding QuantityType enum name. | `Length.FromFeet(Math.PI).ToString("q")` -> Length, `Mass.FromTonnes(Math.PI).ToString("u")` -> Mass |
| "u" | Unit name pattern. Each quantity type has a corresponding unit enum, such as `Length` quantity having `LengthUnit` unit enum with values `Meter`, `Centimeter` etc. This pattern outputs the unit enum name. | `Length.FromFeet(Math.PI).ToString("u")` -> Foot, `Mass.FromTonnes(Math.PI).ToString("u")` -> Tonne |

There are three different overloads of the ToString() method to provide a string representation of a value and its units.

## Number Formatting

For "g" pattern (or if no pattern is specified), the number will be formatted with scientific notation for very small or very large values to increase readability. We did not find .NET's default behavior to work well for this so we created our own rules.

| Interval | Format | Examples |
|-----------|-----------|-------------|
| `(-inf <= x < 1e-03]` | scientific notation | 1e-04; 2.13e-05 |
| `[1e-03 <= x < 1e+03]` | fixed point notation | 0.001; 0.01; 100 |
| `[1e+03 <= x < 1e+06]` | fixed point notation with digit grouping | 1,000; 10,000; 100,000 |
| `[1e+06 <= x <= +inf)` | scientific notation | 1.1e+06; 3.14e+07 |

The symbols used for digit grouping and radix point are culture-sensitive. The above examples use `CultureInfo.InvariantCulture`.

For more examples, refer to the unit tests in [UnitsNet/UnitFormatter.cs](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet/UnitFormatter.cs).
