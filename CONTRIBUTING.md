# Contributing to Units.NET

Guidelines for contributing to the repo.

## We want your help and we are friendly to first-time contributors!
Adding a new unit or a new quantity is easy! We have detailed the steps here and if you need any assistance we are happy to help!

https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit

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

## Unit definitions (.JSON)
For a fairly complete summary of the unit definition JSON schema, see [Meter of Length](https://github.com/angularsen/UnitsNet/blob/master/Common/UnitDefinitions/Length.json). It has prefix units and multiple cultures.

### Conversion functions
Converting from unit A to B is achieved by first converting from unit A to the base unit, then from the base unit to unit B. To achieve this, each unit defines two conversion functions.

* Prefer multiplication for `FromUnitToBaseFunc` (`x*2.54e-2` for `Inch` to `Meter`)
* Prefer division for `FromBaseToUnitFunc` (`x/2.54e-2` for `Meter` to `Inch`)
* Prefer scientific notation `1e3` and `1e-5` instead of `1000` and `0.00001`
* Prefer a constant if the conversion factor is finite (`x*2.54e-2` for `Inch`)
* Prefer a calculation if the conversion factor is infinite (`(x/72.27)*2.54e-2` for `PrinterPoint`)

### Units
Generally we try to name the units as what is the most widely used.

* Use prefix for country variants, such as `ImperialGallon` and `UsGallon`

**Note:** We should really consider switching variant prefix to suffix, since that plays better with kilo, mega etc.. Currently we have units named `KilousGallon` and `KiloimperialGallon`, these would be better named `KilogallonUs` and `KilogallonImperial`.

### Unit abbreviations
A unit can have multiple abbreviations per culture/language, the first one is used by `ToString()` while all of them are used by `Parse()`.

* Prefer the most widely used abbreviation in the domain, but try to adapt to our conventions
* Add other popular variants to be able to parse those too, but take care to avoid abbreviation conflicts of units of the same quantity
* Use superscript (`cm²`, `m³`) instead of `cm^2`, `m^3`
* Use `∆` for delta (not `▲`)
* Use `·` for products (`N·m` instead of `Nm`, `N*m` or `N.m`)
* Prefer `/` over `⁻¹`, such as `km/h` and `J/(mol·K)`
* Use `h` for hours, `min` for minutes and `s` for seconds (`m` is ambiguous with meters)
* Use suffixes to distinguish variants of similar units, such as `gal (U.S.)` vs `gal (imp.)` for gallons
  * `(U.S.)` for United States
  * `(imp.)` for imperial / British units
