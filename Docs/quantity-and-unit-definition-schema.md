# Quantity and Unit Definition Schema

Units.NET quantity and unit definitions are JSON files in
[`Common/UnitDefinitions`](../Common/UnitDefinitions). Each file describes one quantity, the units that belong to it,
their conversions, abbreviations, and optional code-generation behavior.

This is the contributor-facing schema reference for those files. The deserialization types in
[`CodeGen/JsonTypes`](../CodeGen/JsonTypes) and the code generator are the implementation source of truth.

> [!IMPORTANT]
> The current JSON deserializer is permissive: unknown properties are ignored and some missing properties are not
> rejected until generated code is compiled or tested. Treat properties marked as required here as required, and do
> not rely on unknown properties being accepted.

For the contribution workflow and style conventions, see
[Adding a New Quantity or Unit](adding-a-new-unit.md).

## Minimal definition

The following is a minimal definition of a linear quantity with one unit:

```json
{
  "Name": "Length",
  "BaseUnit": "Meter",
  "XmlDocSummary": "Length is a measure of distance.",
  "BaseDimensions": {
    "L": 1
  },
  "Units": [
    {
      "SingularName": "Meter",
      "PluralName": "Meters",
      "BaseUnits": {
        "L": "Meter"
      },
      "FromUnitToBaseFunc": "{x}",
      "FromBaseToUnitFunc": "{x}",
      "Localization": [
        {
          "Culture": "en-US",
          "Abbreviations": [ "m" ]
        }
      ]
    }
  ]
}
```

By convention, the filename is `<Name>.json`, such as `Length.json`. Quantity and unit names use PascalCase and must
be valid C# identifiers because they become generated type and member names.

## Quantity object

The root JSON object represents a quantity.

| Property | Type | Required/default | Description |
|---|---|---|---|
| `Name` | string | Required | PascalCase quantity name used for the generated quantity type and unit enum. Conventionally matches the filename. |
| `BaseUnit` | string | Required | `SingularName` of the unit through which conversions are performed. It must identify exactly one entry in `Units`. |
| `XmlDocSummary` | string | Required | XML documentation summary for the generated quantity type. XML documentation elements such as `<c>` may be used. |
| `XmlDocRemarks` | string | Optional | Additional XML documentation remarks for the generated quantity type. Often contains a reference URL. |
| `BaseDimensions` | object | All exponents default to `0` | Exponents of the seven SI base dimensions. See [Base dimensions](#base-dimensions). |
| `AffineOffsetType` | string | Optional | Marks an affine quantity and names the quantity used to represent differences, such as `TemperatureDelta` for `Temperature`. |
| `Logarithmic` | boolean-like | `false` | Generates logarithmic arithmetic and implements `ILogarithmicQuantity`. Existing definitions use the legacy string `"True"`; a JSON boolean is also accepted by the current deserializer. |
| `LogarithmicScalingFactor` | integer-like | `1` | Multiplier applied to the conventional factor of 10 for logarithmic arithmetic. Existing definitions use strings such as `"1"` and `"2"`; JSON integers are also accepted. Only meaningful when `Logarithmic` is true. See [Logarithmic quantities](#logarithmic-quantities). |
| `ObsoleteText` | string | Optional | Generates an `Obsolete` attribute with this message for the quantity and its generated numeric extension methods. |
| `Units` | array of unit objects | Required | Units belonging to the quantity. At least one unit is required, and one must match `BaseUnit`. |

`AffineOffsetType` and `Logarithmic` describe different arithmetic models and must not be combined.

### Base dimensions

`BaseDimensions` maps SI dimension symbols to integer exponents. Missing dimensions have exponent zero.

| Key | Dimension | Example |
|---|---|---|
| `L` | Length | `Length`: `{ "L": 1 }` |
| `M` | Mass | `Density`: `{ "M": 1, "L": -3 }` |
| `T` | Time | `Frequency`: `{ "T": -1 }` |
| `I` | Electric current | `ElectricCurrent`: `{ "I": 1 }` |
| `Θ` | Thermodynamic temperature | `Temperature`: `{ "Θ": 1 }` |
| `N` | Amount of substance | `AmountOfSubstance`: `{ "N": 1 }` |
| `J` | Luminous intensity | `LuminousIntensity`: `{ "J": 1 }` |

The temperature key is the Greek capital theta `Θ`, not the word `Theta`. Dimensionless quantities may omit
`BaseDimensions` or use an empty object.

`BaseDimensions` describes the quantity's dimensional exponents. It is distinct from:

- `BaseUnit`, the intermediate unit used for conversions.
- A unit's `BaseUnits`, the concrete SI base-unit choices used for unit-system selection.

## Unit object

Each entry in `Units` represents one unit.

| Property | Type | Required/default | Description |
|---|---|---|---|
| `SingularName` | string | Required | PascalCase singular unit name. Becomes an enum member and part of generated factory and conversion member names. Must be unique within the quantity. |
| `PluralName` | string | Required | PascalCase plural unit name. Used in generated member names such as `Length.Meters`. |
| `FromUnitToBaseFunc` | string | Required | C# expression that converts `{x}` from this unit to the quantity's `BaseUnit`. |
| `FromBaseToUnitFunc` | string | Required | Inverse C# expression that converts `{x}` from the quantity's `BaseUnit` to this unit. |
| `BaseUnits` | object | Optional | Concrete SI base-unit names used to match this unit to a `UnitSystem`. See [Base units](#base-units). |
| `Prefixes` | array of strings | Empty | Prefix names for which CodeGen generates additional units. See [Prefixes](#prefixes). |
| `Localization` | array of localization objects | Required | Culture-specific abbreviations. Every unit should define `en-US`. |
| `XmlDocSummary` | string | Optional | XML documentation summary for the generated unit enum member. |
| `XmlDocRemarks` | string | Optional | Additional XML documentation remarks for the generated unit enum member. Often contains a reference URL. |
| `ObsoleteText` | string | Optional | Generates an `Obsolete` attribute with this message for the unit and its generated numeric extension methods. |

The base-unit entry should use identity conversion expressions:

```json
"FromUnitToBaseFunc": "{x}",
"FromBaseToUnitFunc": "{x}"
```

### Conversion expressions

Conversions always go through the quantity's `BaseUnit`:

```text
source unit --FromUnitToBaseFunc--> BaseUnit --FromBaseToUnitFunc--> target unit
```

The conversion properties contain C# numeric expressions. CodeGen replaces every `{x}` placeholder with the input
value and emits the expression into generated C# code. Expressions may use numeric literals, arithmetic operators,
parentheses, and available APIs such as `Math.PI`.

The two expressions must be inverses. For example, with meters as the base unit:

```json
{
  "SingularName": "Centimeter",
  "PluralName": "Centimeters",
  "FromUnitToBaseFunc": "{x} / 100",
  "FromBaseToUnitFunc": "{x} * 100"
}
```

Affine units include an offset:

```json
{
  "SingularName": "DegreeCelsius",
  "PluralName": "DegreesCelsius",
  "FromUnitToBaseFunc": "{x} + 273.15",
  "FromBaseToUnitFunc": "{x} - 273.15"
}
```

Use `{x}` exactly, preserve exact constituent constants where possible, and follow the
[conversion function conventions](adding-a-new-unit.md#conversion-function-conventions). Since expressions are C#
source rather than a language-neutral expression format, other platform generators must translate the supported
expression syntax.

### Base units

`BaseUnits` maps the same seven dimension keys to singular unit names from the corresponding SI base quantities.
It allows APIs such as `new Length(1, UnitSystem.SI)` to select a suitable unit.

For example, the newton has:

```json
"BaseUnits": {
  "L": "Meter",
  "M": "Kilogram",
  "T": "Second"
}
```

Only the concrete unit choice is stored; dimensional exponents come from the quantity's `BaseDimensions`. For example,
an area unit can use `{ "L": "Centimeter" }` even though the length dimension has exponent 2.

`BaseUnits` may be omitted when no meaningful mapping exists, such as for a gallon or a dimensionless ratio.

### Prefixes

`Prefixes` tells CodeGen to derive additional units from the current unit. For example:

```json
"Prefixes": [ "Milli", "Kilo", "Mega" ]
```

For each prefix, CodeGen:

- Creates singular and plural names by prepending the prefix.
- Adjusts both conversion expressions by the prefix factor.
- Prefixes each localized abbreviation, unless an explicit override is configured.
- Attempts to infer prefixed `BaseUnits`.

Accepted metric prefixes are:

`Yocto`, `Zepto`, `Atto`, `Femto`, `Pico`, `Nano`, `Micro`, `Milli`, `Centi`, `Deci`, `Deca`, `Hecto`, `Kilo`,
`Mega`, `Giga`, `Tera`, `Peta`, `Exa`, `Zetta`, and `Yotta`.

Accepted binary prefixes are:

`Kibi`, `Mebi`, `Gibi`, `Tebi`, `Pebi`, and `Exbi`.

Do not also define a generated prefixed unit explicitly.

## Localization object

Each `Localization` entry configures abbreviations for one culture.

| Property | Type | Required/default | Description |
|---|---|---|---|
| `Culture` | string | Required | .NET culture name, such as `en-US`, `ru-RU`, or `zh-CN`. |
| `Abbreviations` | array of strings | Empty | Unit symbols and parsing aliases. The first abbreviation is the default used for formatting. Empty is valid for units such as `Ratio.DecimalFraction`. |
| `AbbreviationsForPrefixes` | object | Optional | Explicit abbreviations for selected generated prefixes. Each key is a configured prefix name and each value is a string or array of strings. |

By default, CodeGen prepends the localized prefix symbol to every abbreviation. Use `AbbreviationsForPrefixes` when
that would produce the wrong symbol or symbol order:

```json
{
  "Culture": "en-US",
  "Abbreviations": [ "∆°C" ],
  "AbbreviationsForPrefixes": {
    "Milli": "∆m°C"
  }
}
```

Follow the [abbreviation naming conventions](adding-a-new-unit.md#abbreviation-naming-conventions). Abbreviation
ambiguity across different quantities is allowed, but aliases must not make two units of the same quantity
indistinguishable.

## Specialized quantity models

### Linear quantities

A quantity is linear when both `AffineOffsetType` and `Logarithmic` are omitted. Generated arithmetic operates
directly on converted values. This is the default and applies to quantities such as `Length`, `Mass`, and `Power`.

### Affine quantities

An affine quantity represents points on a scale where differences use a separate quantity type. Set
`AffineOffsetType` to that difference quantity:

```json
"AffineOffsetType": "TemperatureDelta"
```

[`Temperature.json`](../Common/UnitDefinitions/Temperature.json) is the current example. Its unit conversions include
scale offsets, while [`TemperatureDelta.json`](../Common/UnitDefinitions/TemperatureDelta.json) defines conversions
between differences without absolute-scale offsets.

### Logarithmic quantities

Set `Logarithmic` on a quantity to generate logarithmic arithmetic:

```json
"Logarithmic": "True",
"LogarithmicScalingFactor": "2"
```

The string representation above is retained by existing definitions for compatibility. The values deserialize to a
Boolean and an integer respectively.

Let `n` be the JSON `LogarithmicScalingFactor`. CodeGen exposes and uses the effective scaling factor:

```text
S = 10 × n
logarithmic value = S × log10(linear value)
linear value      = 10^(logarithmic value / S)
```

Therefore:

| Quantity model | JSON value | Effective factor | Typical relationship |
|---|---:|---:|---|
| Power or generic level | `1` | `10` | `10 × log10(P/P₀)` |
| Field amplitude, such as voltage | `2` | `20` | `20 × log10(V/V₀)` |

The factor is used when generated operators and `LogarithmicQuantityExtensions` convert values to linear space for
addition, subtraction, sums, and means. It is not automatically applied to `FromUnitToBaseFunc` or
`FromBaseToUnitFunc`; those expressions still define conversion between the logarithmic units and their reference
levels. For example, converting dBm to dBW subtracts 30.

Current examples are:

- [`Level.json`](../Common/UnitDefinitions/Level.json) — generic decibels and nepers, factor 1.
- [`PowerRatio.json`](../Common/UnitDefinitions/PowerRatio.json) — dBW and dBm, factor 1.
- [`AmplitudeRatio.json`](../Common/UnitDefinitions/AmplitudeRatio.json) — voltage-referenced levels, factor 2.

Logarithmic quantities require custom arithmetic test values; see the
[contribution workflow](adding-a-new-unit.md#logarithmic-units).

## Quantity relations

Cross-quantity multiplication, division, and inverse relations are not properties of an individual quantity
definition. They are declared separately in [`Common/UnitRelations.json`](../Common/UnitRelations.json).

Each entry has this form:

```text
ResultQuantity.ResultUnit = LeftQuantity.LeftUnit * RightQuantity.RightUnit
```

For example:

```json
"Force.Newton = Mass.Kilogram * Acceleration.MeterPerSecondSquared"
```

CodeGen infers commutative multiplication and corresponding division operators. Append `-- NoInferredDivision` when
the inferred division would be ambiguous. Use `1` as the result for inverse relationships and `double` for a unitless
numeric operand.

## Internal and reserved properties

The deserialization model contains two unit properties that are not used by normal definitions:

- `SkipConversionGeneration` defaults to `false` and suppresses generated convenience conversion members, numeric
  extensions, and related tests. No current unit definition uses it.
- `AllowAbbreviationLookup` defaults to `true`, but the current generators do not consume it. Setting it has no
  observable effect.

Do not use these properties in contributor definitions without a corresponding CodeGen change and tests.
`Quantity.Relations` is also internal generated state populated from `Common/UnitRelations.json`, not a property to
set in a quantity definition.

Some existing definitions contain historical properties such as `XmlDoc`, `XmlDocsRemarks`, `BaseType`, or
`OmitExtensionMethod`. The current deserialization model does not recognize them, so they have no effect and must not
be copied into new definitions.

## Validation workflow

After changing a definition:

1. Run `generate-code.bat` or `dotnet run --project CodeGen`.
2. Inspect the generated changes.
3. Add or update independently sourced conversion test values.
4. Run `build.bat` or `dotnet build UnitsNet.slnx`.
5. Run the relevant tests.

Generated files under `GeneratedCode` must not be edited manually.
