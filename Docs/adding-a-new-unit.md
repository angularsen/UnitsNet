# Adding a New Quantity or Unit

So you want to add a quantity or unit that is not yet part of Units.NET?

- [Great, but before you start!](#great-but-before-you-start)
- [Requirements](#requirements)
- [Quick Summary of Steps](#quick-summary-of-steps)
- [Detailed steps](#detailed-steps)
  - [1. Add or modify JSON file for a quantity class](#1-add-or-modify-json-file-for-a-quantity-class)
  - [2. Run generate-code.bat](#2-run-generate-codebat)
  - [3. Reopen solution to load all new files](#3-reopen-solution-to-load-all-new-files)
  - [4. Fix generated test stubs to resolve compile errors](#4-fix-generated-test-stubs-to-resolve-compile-errors)
  - [5. Run tests](#5-run-tests)
  - [6. Create pull request](#6-create-pull-request)
- [Logarithmic Units](#logarithmic-units)
- [Code Style](#code-style)

## Great, but before you start!

Sometimes we just have to say no, sorry! We simply want to avoid bloating the library.

### A quantity is a good fit to add, if it

- [x] Is well documented and unambiguous, e.g. has a wiki page and generally easy to find on Google
- [x] Is widely used, preferably across domains
- [x] Has multiple units to convert between (e.g. `Length` has kilometer, feet, nanometer etc.)
- [x] Can convert to other quantities (e.g. `Length x Length = Area`)
- [x] Can be represented by a `double` numeric value, integer values are not well supported and may suffer from precision errors
- [x] Is not [dimensionless/unitless](https://en.wikipedia.org/wiki/Dimensionless_quantity) (consider using `Ratio`)

Single-unit quantities are the exception. If a proposed quantity has only one unit, it needs stronger justification: the quantity must be widely used as a typed quantity representation on its own, not just as a unit abbreviation with no conversions.

### A unit is a good fit to add to a quantity, if it

- [x] Is well documented and unambiguous, e.g. has a wiki page or found in online unit converters
- [x] Is widely used
- [x] Can be converted to other units of the same quantity
- [x] The conversion function is well established without ambiguous competing standards

### A note on X-per-Y units

There are extremely many variations of unit A over unit B, such as [LengthPerAngle](https://github.com/angularsen/UnitsNet/issues/1519).
Generally speaking, we are less inclined to add these unless they are very common and not too domain specific.

We have made some exceptions to all the above "rules" so [start a discussion with us](https://github.com/angularsen/UnitsNet/issues/new?assignees=&labels=enhancement&template=feature_request.md&title=) if you still think it belongs in the library.

Ok, enough of that. Let's move on!

## Requirements

* [`.NET 9 SDK`](https://dotnet.microsoft.com/download) to generate and build code

## Quick Summary of Steps

Units.NET uses [CodeGen](https://github.com/angularsen/UnitsNet/tree/master/CodeGen), a C# command line app that reads [JSON files with quantity and unit definitions](https://github.com/angularsen/UnitsNet/tree/master/Common/UnitDefinitions) and generates C# code.

To add a quantity or a unit:

- Add or change a quantity JSON file.
- Run `generate-code.bat` file.
- Specify test values for the new units in the generated test code.

Not too difficult. Below are the detailed steps.

## Detailed steps

### 1. Add or modify JSON file for a quantity class

* Place in [Common/UnitDefinitions](https://github.com/angularsen/UnitsNet/tree/master/Common/UnitDefinitions)
* See [Length.json](https://github.com/angularsen/UnitsNet/tree/master/Common/UnitDefinitions/Length.json) as an example.
* Use reliable references, such as [UN/ECE Recommendation No. 21](https://unece.org/fileadmin/DAM/cefact/recommendations/rec20/rec20_rev3_Annex2e.pdf), Google, Wolfram Alpha or online converters.

#### Conversion function conventions

* Prefer multiplication (`*`) for `FromUnitToBaseFunc` and division (`/`) for `FromBaseToUnitFunc`. As an example, `Length.Centimeter` is defined as `"FromUnitToBaseFunc": "{x} / 100"` and `"FromBaseToUnitFunc": "{x} * 100"`, instead of `{x} * 0.01` and `{x} / 0.01`.
* Prefer `1e3` and `1e-5` notation instead of `1000` and `0.00001`
* Prefer a constant if the conversion factor is finite and well known (`Inch FromUnitToBase: {x} * 2.54e-2`)
* Prefer a calculation if the conversion factor is infinite (`PrinterPoint FromUnitToBase: ({x} / 72.27) * 2.54e-2`). If the calculation is not available, specify the most precise constant you can. `double` numeric type can represent [15-17 significant decimal digits](https://en.wikipedia.org/wiki/Double-precision_floating-point_format#IEEE_754_double-precision_binary_floating-point_format:_binary64)
* Use exact constituent constants instead of pre-computed decimals -- e.g. `{x} * 4.4482216152605 / 9.290304e-2` instead of `{x} * 47.880258980335840277`, so the physical constants remain visible and no precision is lost

#### Abbreviation naming conventions

Prefer the most widely used abbreviation in the domain, but try to adapt to our conventions.

* Use superscript (`cm²`, `m³`) instead of `cm^2`, `m^3`
* Use `∆` for delta (not `▲`)
* Use `·` for products (`N·m` instead of `Nm`, `N*m` or `N.m`)
* Use `/` over `⁻¹`, such as `km/h` and `J/(mol·K)`
* Use `h` for hours, `min` for minutes and `s` for seconds (`m` is ambiguous with meters)
* Use abbreviations defined by [SI Unit System](https://en.wikipedia.org/wiki/International_System_of_Units), such as `l` instead of `L` for liters
* For force-derived compound units, prefer the technically precise force abbreviation as the primary abbreviation: `lbf`, `ozf`, `gf`, etc. Common shorthand variants such as `lb`, `oz`, or `g` may be added as secondary abbreviations when they are widely used and unambiguous for that quantity. For example, `lbf·ft` should be the primary abbreviation for pound-force foot torque, but `lb·ft` can be accepted as a parsing alias. Do not add shorthand aliases if they would be ambiguous within the same quantity.
* If a common shorthand abbreviation fits multiple quantities, add it to each relevant quantity, e.g. `ft-lb` for torque and energy, or `oz·in` for torque and static unbalance if both are supported. Global parsing should be ambiguous, while quantity-specific parsing still works.
* Prefer singular unit symbols such as `lb` and `oz`, not pluralized forms such as `lbs` and `ozs`. A pluralized form can be accepted as a secondary abbreviation if it is a strong domain convention, but it should not normally be the primary abbreviation.
* Use suffixes to distinguish variants of similar units, such as `gal (U.S.)` vs `gal (imp.)` for gallons
  * `(U.S.)` for United States
  * `(imp.)` for imperial / British units
* Add other popular variants to be able to parse those too, e.g. `[ "tsp", "t", "ts", "tspn", "t.", "ts.", "tsp.", "tspn.", "teaspoon" ]` for `VolumeUnit.MetricTeaspoon` where `tsp` is used by default in `ToString()`

#### `BaseDimensions`

The base unit dimensions of the quantity, such as `"L": 1` for `Length` and `"L": 2` for `Area` (`Length*Length`).

The [7 SI base units](https://en.wikipedia.org/wiki/SI_base_unit#Seven_SI_base_units) are:
- `L` - Length
- `M` - Mass
- `T` - Time
- `I` - ElectricCurrent
- `Theta` - Temperature
- `N` - AmountOfSubstance
- `J` - LuminousIntensity

#### `BaseUnit` - the intermediate unit of a quantity

When converting from one unit to another with `FromUnitToBaseFunc` and `FromBaseToUnitFunc` conversion functions. It is typically chosen as an SI derived unit (`Meter`, `Newtonmeter`, `Squaremeter` etc). This choice affects the precision of conversions for much bigger/smaller units than `BaseUnit`.

#### `BaseUnits` (optional) - the [SI base units](https://en.wikipedia.org/wiki/SI_base_unit#Seven_SI_base_units) of a unit

Don't confuse this with the quantity's `BaseUnit`, which is [discussed to be renamed](https://github.com/angularsen/UnitsNet/issues/563#issuecomment-467029946).

If specified, you can create quantities with consistent units for a given unit system:
```c#
new Length(1, UnitSystem.SI).ToString() // "1 m"
new Length(1, myBritishEngineeringUnitSystem).ToString() // "1 ft"
```

Examples on `BaseUnits` values:
- `LengthUnit.Inch` has `{ "L": "Inch" }` (L=1)
- `AreaUnit.SquareCentimeter` has `{ "L": "Centimeter" }`, because we ignore dimensions (L=2)
- `VolumeUnit.Cubicfeet` has `{ "L": "Foot" }`, because we ignore dimensions (L=3)
- `ForceUnit.Newton` has `{ "L": "Meter", "M": "Kilogram", "T": "Second" }`, because `N = 1 kg * 1 m / s^2 = Kilogram * Meter / Second^2` and we ignore the dimensions
- `ForceUnit.PoundForce` has `{ "L": "Foot", "M": "Pound", "T": "Second" }`, because `N = 1 lbm * 1 ft / s^2 = Pound * Foot / Second^2` and we ignore the dimensions
- `MassConcentrationUnit.GramPerDeciliter` has `{ "L": "Centimeter", "M": "Gram" }`, because `Deciliter = 1 cm * 1cm * 1cm = Centimeter^3` and we ignore the dimensions

Examples of units with no meaningful mapping to SI base units:
The only consequence of not specifying `BaseUnits` is that you cannot construct these units by passing a `UnitSystem` to the quantity constructor as in the example above.

- `VolumeUnit.ImperialGallon` has no `BaseUnits`, because `Volume = Length^3` and there is no length unit that when multiplied three times would result in imperial gallon.
- `RatioUnit.DecimalFraction` has no `BaseUnits`, because dimensionless units are not made up by any SI base units.

### 2. Run [generate-code.bat](https://github.com/angularsen/UnitsNet/blob/master/generate-code.bat)

To generate unit classes, unit enumerations and base class for tests.

### 3. Reopen solution to load all new files

This step _might_ no longer be necessary with modern Visual Studio and the new .csproj format.

### 4. Fix generated test stubs to resolve compile errors

* Override the missing abstract properties in the unit test class (ex: [LengthTests.cs](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet.Tests/CustomCode/LengthTests.cs))
* Specify value as a constant, not a calculation, with preferably **at least 7** [significant figures](https://en.wikipedia.org/wiki/Significant_figures) where possible. Beyond 16 significant digits is not useful due to `double` precision limits.
* Triple-check the number you write here, this is **the most important piece** as it verifies your conversion function in the .JSON file
* If possible, add a comment next to the value with a URL to where the value can be verified.
* Example: `InchesInOneMeter` in [LengthTests.cs](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet.Tests/CustomCode/LengthTests.cs)
  * I find the conversion factor to be `39.37007874` from an online unit conversion calculator, it has 10 significant figures so that is plenty
  * I override the `InchesInOneMeter` property (see below snippet)
  * I Google to double-check: `Inches In 1 Meter` and it tells me `1 Meter = 39.3701 Inches` (Google typically has fewer significant figures)
  * If Google can't help me, I find a second source to confirm the conversion factor (another conversion website, wikipedia, Wolfram Alpha etc)
  * I check again by intuition, is there really around 40 inches in a meter? Yes, sounds about right.

Example code snippet:
```cs
/// <summary>https://link-to-where-i-found-the-value.com</summary>
protected override double InchesInOneMeter => 39.37007874;
```

### 5. Run tests

Make sure all the tests pass.
Either run [build.bat](https://github.com/angularsen/UnitsNet/blob/master/build.bat) or run the tests from within Visual Studio with ReSharper or the built-in test runner.

### 6. Create pull request

Please see [GitHub: Creating a pull request](https://help.github.com/articles/creating-a-pull-request/). If you still have any questions, you can reach out in [Discussion](https://github.com/angularsen/UnitsNet/discussions).

There are many ways to do this, here is one way:
- Click the Fork button to get a copy of this repo on `https://github.com/your_user/UnitsNet`
- Go to your fork and clone it to a directory on your PC (see instructions in the **Code button**)
- Create a branch, e.g. `add-somenewunit`
- Do your work, including generating code, commit and push to your fork where you have full write-access
- Visit your fork on github.com with a browser, then create a pull request from your branch to the angularsen/UnitsNet repo.

For one-offs, this is enough.
If you need to create multiple pull requests based on the latest `master` branch, or simply keep your fork's branches up to date with the main repo's `master` branch, then you need to add the angularsen/UnitsNet repo as a remote to your git clone and fetch it.

```sh
# Add main repo as a remote named 'angularsen'
git remote add angularsen https://github.com/angularsen/UnitsNet

# Fetch branches/tags from all your remotes
git fetch

# Create and checkout new branch based on latest master
git checkout -b add-another-unit angularsen/master

# With multiple remotes, you need to tell it what remote a branch should push/pull to, assuming 'origin' is your fork.
git branch --set-upstream-to=origin/add-another-unit

# Do your work, stage changes, commit and push to your fork.
git add -A
git commit -m "My commit message"
git push

# If you need to keep your branch up to date, merge in angularsen's master branch to the current branch you are on. Also push this to your fork.
git merge angularsen/master
git push

# Then visit your fork at https://github.com/your_user/UnitsNet to create a pull request.
```

## Logarithmic Units

Units.NET supports logarithmic units by adding `Logarithmic` and `LogarithmicScalingFactor` (optional) properties.

* `LogarithmicScalingFactor` is used to provide a scaling factor in the logarithmic conversion. For example, a scaling factor of `2` is required when implementing the ratio of the squares of two field amplitude quantities such as voltage. In most cases `LogarithmicScalingFactor` will be `1`.

To create a logarithmic unit, follow the same steps from the previous section making the following adjustments:

Step 1. Add property `"Logarithmic": "True"` to the JSON file, just after `BaseUnit`. `LogarithmicScalingFactor` defaults to `1` if not defined.

Step 4. Provide custom implementations for logarithmic addition and subtraction unit tests. See [LevelTests.cs](https://github.com/angularsen/UnitsNet/blob/master/UnitsNet.Tests/CustomCode/LevelTests.cs) for an example.

Refer to [Level.json](https://github.com/angularsen/UnitsNet/tree/master/Common/UnitDefinitions/Level.json) as an example implementation of logarithmic units.

## Code Style

* If you have the [ReSharper plugin](https://www.jetbrains.com/resharper) installed, there are code formatting settings checked into the repository that will take effect automatically.
* If you don't use ReSharper, at least follow the same conventions as in the existing code.
