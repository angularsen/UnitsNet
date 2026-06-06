# Contributing to Units.NET

Guidelines for contributing to the repo.
<!--markdownlint-disable MD026 -->
## We want your help and we are friendly to first-time contributors!

Adding a new unit or a new quantity is easy! See the detailed step-by-step guide:

**[Adding a New Quantity or Unit](Docs/adding-a-new-unit.md)**

We also want the person with the idea, suggestion or bug report to implement the change in code and get a sense of ownership for that piece of the library.
This is to help grow the number of people that can contribute to the project and after someone new lands that first PR we often see more PRs from that person later.

## Coding Conventions

* Match the existing code style, we generally stick to "Visual Studio defaults" and [.NET Foundation Coding Guidelines](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md)
* If you use ReSharper there is a [settings file](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet.sln.DotSettings) that will take effect automatically
* There is an [.editorconfig](https://github.com/angularsen/UnitsNet/blob/master/.editorconfig) to help configure whitespace and C# syntax for your editor if it supports it
* Add the file header to new files you create

### Test Code

* Test class: Use `Tests` suffix for the type you are testing, such as `UnitSystemTests`
* Test method: `<method>_<condition>_<result>` (`Parse_AmbiguousUnits_ThrowsException`)
* If there are many tests for a single method, you can wrap those in an inner class named the same as the method and then you can skip that part of the test method names

## Unit Definitions (.JSON)

For a fairly complete summary of the unit definition JSON schema, see [Meter of Length](https://github.com/angularsen/UnitsNet/blob/master/Common/UnitDefinitions/Length.json). It has prefix units and multiple cultures.

For detailed conventions on conversion functions, abbreviations, base dimensions, and more, see [Adding a New Unit](Docs/adding-a-new-unit.md#1-add-or-modify-json-file-for-a-quantity-class).

### Units

Generally we try to name the units as what is the most widely used.

* Use prefix for country variants, such as `ImperialGallon` and `UsGallon`

**Note:** We should really consider switching variant prefix to suffix, since that plays better with kilo, mega etc.. Currently we have units named `KilousGallon` and `KiloimperialGallon`, these would be better named `KilogallonUs` and `KilogallonImperial`.

## More Documentation

See [Docs/](Docs/README.md) for the full documentation index, including:
- [Precision](Docs/precision.md) — conversion precision and test guidelines
- [Adding Operator Overloads](Docs/adding-operator-overloads.md)
- [Serialization](Docs/serialization.md)
- [Upgrade Guides](Docs/README.md#upgrade-guides)
