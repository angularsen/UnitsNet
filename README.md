[![Build Status](http://teamcity.tjomp.com/app/rest/builds/buildType:(id:UnitsNet_Master)/statusIcon)](http://teamcity.tjomp.com/viewType.html?buildTypeId=UnitsNet_Master&guest=1 "Build Status")
Units.NET
===
Everyone have written their share of trivial conversions - or less obvious ones where you need to Google that magic constant. 

Stop littering your code with unnecessary calculations. Units.NET gives you all the common units of measurement and the conversions between them. It is light-weight, unit tested and supports [PCL](http://msdn.microsoft.com/en-us/library/gg597391.aspx "MSDN PCL").


Installing
===
Run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console) or go to the [NuGet site](https://www.nuget.org/packages/UnitsNet/) for the complete relase history.

![Install-Package UnitsNet](https://raw.githubusercontent.com/anjdreas/UnitsNet/master/Docs/Images/install_package_unitsnet.png "Install-Package UnitsNet")

Build Targets:
* Portable 4.0 Profile328 (.NET 4, Silverlight 5, Win8, WinPhone8.1 + WP Silverlight 8)
* .NET 3.5 Client

Features
===
* [370 units of measurement in 35 classes](https://github.com/anjdreas/UnitsNet/tree/master/UnitsNet/GeneratedCode/Enums)
* Generated code for uniform implementations and fewer bugs
* Immutable structs implementing IEquatable, IComparable and operator overloads
* Parse unit abbreviations in multiple cultures
* ToString() variants for custom cultures and format patterns
* Extensible with [custom units](https://github.com/anjdreas/UnitsNet/wiki/Extending-with-Custom-Units)
* [Serializable with JSON.NET](https://www.nuget.org/packages/UnitsNet.Serialization.JsonNet)
* 688 unit tests to ensure conversions and localizations are in order

Static Typing
---
```C#
// Convert to the unit of choice - when you need it
Mass weight = GetPersonWeight();
Console.WriteLine("You weigh {0:0.#} kg.", weight.Kilograms);

// Avoid confusing conversions, such as between weight (force) and mass
double weightNewtons = weight.Newtons; // No such thing

// Some popular conversions
Length meter = Length.FromMeters(1);
double cm = meter.Centimeters; // 100
double yards = meter.Yards; // 1.09361
double feet = meter.Feet; // 3.28084
double inches = meter.Inches; // 39.3701
```

Unit Enumeration
---
All units have a corresponding unit enum value. This is useful when selecting the unit representation at runtime, such as presenting a choice of units to the user.
```C#
/// <summary>Convert the previous height to the new unit.</summary>
void OnUserChangedHeightUnit(LengthUnit prevUnit, double prevValue, LengthUnit newUnit)
{
    // Construct from dynamic unit and value
    var prevHeight = Length.From(prevValue, prevUnit);

    // Convert to the new unit
    double newHeightValue = prevHeight.As(newUnit);

    // Update UI with the converted value and the newly selected unit
    UpdateHeightUI(newHeightValue, newUnit);
}
```

Culture and Localization
---
The culture for abbreviations defaults to Thread.CurrentUICulture and falls back to US English if not defined. Thread.CurrentCulture affects number formatting unless a custom culture is specified. The relevant methods are:

* ToString()
* GetAbbreviation()
* Parse/TryParse()
* ParseUnit/TryParseUnit()
```C#
var usEnglish = new CultureInfo("en-US");
var russian = new CultureInfo("ru-RU");
var oneKg = Mass.FromKilograms(1);

// ToString() with Thread.CurrentUICulture as US English and Russian respectively
"1 kg" == oneKg.ToString();
"1 кг" == oneKg.ToString();

// ToString() with specific culture and string format pattern
"mg 1.00" == oneKg.ToString(MassUnit.Milligram, usEnglish, "{1} {0:0.00}");
"мг 1,00" == oneKg.ToString(MassUnit.Milligram, russian, "{1} {0:0.00}");

// Parse measurement from string
Mass kg = Mass.Parse(usEnglish, "1.0 kg");
Mass kg = Mass.Parse(russian, "1,0 кг");

// Parse unit from string, a unit can have multiple abbreviations
RotationalSpeedUnit.RevolutionPerMinute == RotationalSpeed.ParseUnit("rpm");
RotationalSpeedUnit.RevolutionPerMinute == RotationalSpeed.ParseUnit("r/min");

// Get default abbreviation for a unit
"kg" == Mass.GetAbbreviation(MassUnit.Kilogram);
```

Helper Construction Methods
---
Construct measurements with various helper methods for convenience and readability.
```C#
Force.FromPressureByArea(Pressure p, Length2d area)
Force.FromMassAcceleration(Mass mass, double metersPerSecondSquared)
```

Precision and Accuracy
===
A base unit is chosen for each unit class, represented by a double value (64-bit), and all conversions go via this unit. This means there will always be a small error in both representing other units than the base unit as well as converting between units.

Units.NET was intended for convenience and ease of use, not highly accurate conversions, but I am open to suggestions for improvements.

The tests accept an error up to 1E-5 for most units added so far. Exceptions include units like Teaspoon, where the base unit cubic meter is a lot bigger. In many usecases this is sufficient, but for others this may be a showstopper and something you need to be aware of.

For more details, see [Precision](https://github.com/anjdreas/UnitsNet/wiki/Precision).

Serialization
===
* `UnitsNet.Serialization.JsonNet` ([nuget](https://www.nuget.org/packages/UnitsNet.Serialization.JsonNet), [src](https://github.com/anjdreas/UnitsNet/tree/master/UnitsNet.Serialization.JsonNet), [tests](https://github.com/anjdreas/UnitsNet/tree/master/UnitsNet.Serialization.JsonNet.Tests)) for JSON.NET

**Important!** 
We cannot guarantee backwards compatibility, although we will strive to do that on a "best effort" basis and bumping the major nuget version when a change is necessary.

The base unit of any unit should be be treated as volatile as we have changed this several times in the history of this library already. Either to reduce precision errors of common units or to simplify code generation. An example is Mass, where the base unit was first Kilogram as this is the SI unit of mass, but in order to use powershell scripts to generate milligrams, nanograms etc. it was easier to choose Gram as the base unit of Mass.

What It Is Not
===
* It is not an equation solver
* It does not figure out the units after a calculation

Want To Contribute?
==
This project is still early and many units and conversions are not yet covered. If you are missing something, please help by contributing or [ask for it](https://github.com/anjdreas/UnitsNet/issues) by creating an issue.

Please read the wiki on [Adding a New Unit](https://github.com/anjdreas/UnitsNet/wiki/Adding-a-New-Unit).

Generally adding a unit involves adding or modifying `UnitsNet\Scripts\UnitDefinitions\*.json` files and running `UnitsNet\Scripts\GenerateUnits.bat` to regenerate the source code and test code stubs, then manually implementing the new unit conversion constants in the test code.

  * [Fork the repo](https://help.github.com/articles/fork-a-repo)
  * Do work on branches such as **feature/add-myunit** and **fix/34**
  * [Create a pull request](https://help.github.com/articles/using-pull-requests)

Continuous Integration
===
A [TeamCity build server](http://teamcity.tjomp.com/viewType.html?buildTypeId=UnitsNet&guest=1) performs the following:
* Build and test pull requests. Notifies on success or error.
* Build, test and deploy nuget on master branch.

[Contact me](https://github.com/anjdreas) if you have any questions.
