# String formatting

Quantity formatting applies a .NET numeric format string to the value and appends the localized
abbreviation of the quantity's current unit.

```csharp
Length length = Length.FromCentimeters(Math.PI);

length.ToString();                                      // 3.141592653589793 cm
length.ToString("F2", CultureInfo.InvariantCulture);   // 3.14 cm
$"Length: {length:N3}";                                // Length: 3.142 cm with an en-US current culture
```

The parameterless overload uses the general (`G`) numeric format. Formatting honors the supplied
`IFormatProvider`, or `CultureInfo.CurrentCulture` when none is supplied.

```csharp
length.ToString(CultureInfo.GetCultureInfo("nb-NO")); // 3,141592653589793 cm
length.ToString(CultureInfo.GetCultureInfo("ru-RU")); // 3,141592653589793 см
```

Convert the quantity before formatting when a different unit is required:

```csharp
Length meters = length.ToUnit(LengthUnit.Meter);
string text = meters.ToString("G3", CultureInfo.InvariantCulture); // 0.0314 m
```

## Numeric formats

UnitsNet accepts standard and custom .NET numeric formats, including:

| Intent | Format | Example |
|---|---|---|
| General notation with a precision | `G3` | `3.14 cm` |
| Fixed decimal places | `F2` | `3.14 cm` |
| Grouped number with fixed decimals | `N2` | `1,234.50 cm` |
| Scientific notation | `E2` | `3.14E+000 cm` |
| Up to two decimal places | `0.##` | `3.14 cm` |
| Grouped with up to two decimal places | `#,##0.##` | `1,234.5 cm` |

Currency (`C`) and percent (`P`) formats are rejected because adding currency or percent symbols to
a physical quantity is misleading.

See [.NET standard numeric format strings](https://learn.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings)
and [.NET custom numeric format strings](https://learn.microsoft.com/dotnet/standard/base-types/custom-numeric-format-strings)
for the complete syntax.

## Unit abbreviations

Use the generated quantity API to get the primary localized abbreviation explicitly:

```csharp
string abbreviation = Length.GetAbbreviation(LengthUnit.Foot);
string localized = Length.GetAbbreviation(LengthUnit.Meter, CultureInfo.GetCultureInfo("ru-RU"));
```

Use the configured abbreviation cache when every accepted abbreviation is needed. This includes
runtime customizations made through `UnitsNetSetup`:

```csharp
IReadOnlyList<string> abbreviations = UnitsNetSetup.Default.UnitAbbreviations
    .GetUnitAbbreviations(LengthUnit.Foot, CultureInfo.InvariantCulture);
// "ft", "'", "′"
```

## v6 quantity-format cleanup

UnitsNet v6 accepts numeric format strings only. The remaining proprietary quantity formats were
removed together with the formats already retired during the v6 redesign:

| Removed format | Replacement |
|---|---|
| `A`, `A0`, `A1`, ... | `Length.GetAbbreviation(unit)` or `UnitAbbreviationsCache.GetUnitAbbreviations(unit)` |
| `S`, `S2`, ... | An explicit numeric format such as `G3`, `F2`, `N2`, `E2`, or `0.##` |
| `U` | The quantity's `Unit` property |
| `V` | The quantity's `Value` property, optionally formatted separately |
| `Q` | Static quantity metadata such as `Length.Info.Name` |

This keeps formatting compatible with standard .NET tooling and enables IDE assistance through
`StringSyntaxAttribute.NumericFormat`.
