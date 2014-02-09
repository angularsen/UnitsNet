[![Build Status](http://anj.no:8500/app/rest/builds/buildType:(id:UnitsNet_ReleaseBuilds)/statusIcon)](http://anj.no:8500/viewType.html?buildTypeId=UnitsNet_ReleaseBuilds&guest=1 "Build Status")
Units.NET
===
Everyone have written their share of trivial conversions - or less obvious ones where you need to Google that magic constant. 

Stop littering your code with unnecessary calculations. Units.NET gives you all the common units of measurement and the conversions between them. It is light-weight, unit tested and supports [PCL](http://msdn.microsoft.com/en-us/library/gg597391.aspx "MSDN PCL").


Installing
===
Run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console) or go to the [NuGet site](https://www.nuget.org/packages/UnitsNet/) for the complete relase history.

![Install-Package UnitsNet](https://raw.github.com/InitialForce/UnitsNet/develop/Docs/Images/install_package_unitsnet.png "Install-Package UnitsNet")

Build Targets:
* Portable Class Library (.NET 4.0 + Silverlight 5 + Win8/WinPhone8)
* .NET 3.5 Client

Features
===
* 15+ units of measurement, [see full list](https://github.com/InitialForce/UnitsNet/tree/develop/Src/UnitsNet/Units)
* Generated code for uniform implementations and fewer bugs
* Immutable structs implementing IEquatable, IComparable and operator overloads
* Extendable with [custom units](https://github.com/InitialForce/UnitsNet/wiki/Extending-with-Custom-Units)
* Localization of abbreviations
* ToString() variants for custom cultures and format patterns
* Over 220 tests to ensure conversions and localizations are in order

Statically Typed Units
---
```C#
// Convert to the unit of choice - when you need it.
Mass weight = GetPersonWeight();
UpdatePersonWeightInGrams(weight.Grams);

// Avoid confusing conversions, such as between weight and mass.
Mass weight = GetPersonWeight();
double weightNewtons = weight.Newtons; // No such thing

// Some popular conversions.
Length meter = Length.FromMeters(1);
double cm = meter.Centimeters; // 100
double yards = meter.Yards; // 1.09361
double feet = meter.Feet; // 3.28084
double inches = meter.Inches; // 39.3701
```

Unit Enumeration
---
All units have a corresponding unit enum value, in fact the unit classes are generated from these. This is useful when you want to let the user choose the unit, such as when editing the height in his user profile.
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
The culture defaults to Thread.CurrentUICulture and affects localization of unit abbreviations as well as number formatting. The relevant methods are:

* ToString()
* GetAbbreviation()
* Parse/TryParse()
* ParseUnit/TryParseUnit() support cultures. 

The abbreviations support localization, but currently only US English, Russian and Norwegian are implemented. Localization defaults to US English if no localization for the current/specified culture is found.

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
A base unit is chosen for each unit class, represented by a double value (64-bit), and all conversions go via this unit. This means there will always be a small error in both representing other units than the base unit as well as converting between units. Also, some conversions may use different constants in different contexts, such as the air temperature or the standard gravity.

Units.NET was intended for convenience and ease of use, not highly accurate conversions, but I am open to suggestions for improvements.

The tests accept an error up to 1E-5 for all the units added so far. In many usecases this is sufficient, but for others this may be a showstopper and something you need to be aware of.

For more details, see [Precision](https://github.com/InitialForce/UnitsNet/wiki/Precision).


What It Is Not
===
* It is not an equation solver. 
* It does not figure out the units after a calculation.

Want To Contribute?
==
This project is still early and many units and conversions are not yet covered. If you are missing something, please help by contributing or [ask for it](https://github.com/InitialForce/UnitsNet/issues) by creating an issue.

Please read the wiki on [Adding a New Unit](https://github.com/InitialForce/UnitsNet/wiki/Adding-a-New-Unit).

The repo uses [git-flow](https://github.com/nvie/gitflow) branch structure. 
In practice this means:
  * [Fork the repo](https://help.github.com/articles/fork-a-repo) as normal
  * Checkout the default **develop** branch. There is no master branch.
  * Do work on branches such as **feature/add-myunit** and **fix-some-bug**
  * [Create a pull request](https://help.github.com/articles/using-pull-requests) as normal.

Continuous Integration
===
A [TeamCity build server](http://anj.no:8500/project.html?projectId=UnitsNet&tab=projectOverview&guest=1) performs the following:
* Build and test pull requests. Notifies on success or error.
* Build, test and publish nuget on commits to **stable** branch.

[Contact me](https://github.com/anjdreas) if you have any questions.
