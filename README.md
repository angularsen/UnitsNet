[![Build status](https://ci.appveyor.com/api/projects/status/f8qfnqd7enkc6o4k?svg=true)](https://ci.appveyor.com/project/anjdreas/unitsnet) [![Join the chat at https://gitter.im/UnitsNet/Lobby](https://badges.gitter.im/UnitsNet/Lobby.svg)](https://gitter.im/UnitsNet/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
Units.NET
===

Everyone have written their share of trivial conversions - or less obvious ones where you need to Google that magic constant. 

Stop littering your code with unnecessary calculations. Units.NET gives you all the common units of measurement and the conversions between them. It is light-weight, unit tested and supports [PCL](http://msdn.microsoft.com/en-us/library/gg597391.aspx "MSDN PCL").


Installing
---
Run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console) or go to the [NuGet site](https://www.nuget.org/packages/UnitsNet/) for the complete relase history.

![Install-Package UnitsNet](https://raw.githubusercontent.com/anjdreas/UnitsNet/master/Docs/Images/install_package_unitsnet.png "Install-Package UnitsNet")

Build Targets:
* .NET Standard 1.0
* Portable 4.0 Profile328 (.NET 4, Silverlight 5, Win8, WinPhone8.1 + WP Silverlight 8)
* .NET 3.5 Client

Overview
---
* [387 units in 36 unit classes](UnitsNet/GeneratedCode/Enums) generated from [JSON](UnitsNet/UnitDefinitions/) by [Powershell scripts](UnitsNet/Scripts/GenerateUnits.ps1)
* [827 unit tests](http://teamcity.chump.work/viewType.html?guest=1&buildTypeId=UnitsNet_BuildTest) on conversions and localizations
* Immutable structs that implement IEquatable, IComparable
* [Static typing](#static-typing) to avoid ambiguous values or units
* [Operator overloads](#operator-overloads) for arithmetic, also between compatible units
* [Extension methods](#extension-methods) for short-hand creation and conversions
* [Parse and ToString()](#culture) supports cultures and localization
* [Enumerate units](#enumerate-units) for user selection
* [Precision and accuracy](#precision)
* [Serializable with JSON.NET](#serialization)
* Extensible with [custom units](https://github.com/anjdreas/UnitsNet/wiki/Extending-with-Custom-Units)
* [Contribute](#contribute) if you are missing some units
* [Continuous integration](#ci) posts status reports to pull requests and commits
* [Who are using this?](#who-are-using)

<a name="static-typing"></a>Static Typing
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

<a name="operator-overloads"></a>Operator Overloads
---
```C#
// Arithmetic
Length l1 = 2 * Length.FromMeters(1);
Length l2 = Length.FromMeters(1) / 2;
Length l3 = l1 + l2;

// Construct between units
Length distance = Speed.FromKilometersPerHour(80) * TimeSpan.FromMinutes(30);
Acceleration a1 = Speed.FromKilometersPerHour(80) / TimeSpan.FromSeconds(2);
Acceleration a2 = Force.FromNewtons(100) / Mass.FromKilograms(20);
RotationalSpeed r = Angle.FromDegrees(90) / TimeSpan.FromSeconds(2);
```

<a name="extension-methods"></a>Extension Methods
---
All units have associated extension methods for a really compact, expressive way to construct values or do arithmetic.
```C#
using UnitsNet.Extensions.NumberToDuration;
using UnitsNet.Extensions.NumberToLength;
using UnitsNet.Extensions.NumberToTimeSpan;

Speed speed = 30.Kilometers() / 1.Hours(); // 30 km/h (using Duration type)
Length distance = speed * 2.h(); // 60 km (using TimeSpan type)

Acceleration stdGravity = 9.80665.MeterPerSecondSquared();
Force weight = 80.Kilograms() * stdGravity; // 80 kilograms-force or 784.532 newtons
```

<a name="culture"></a>Culture and Localization
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

<a name="enumerate-units"></a>Enumerate Units
---
All units have a unit enum value. Let the user decide what unit of measurement to present the numbers in.
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

<a name="precision"></a>Precision and Accuracy
---
A base unit is chosen for each unit class, represented by a double value (64-bit), and all conversions go via this unit. This means there will always be a small error in both representing other units than the base unit as well as converting between units.

Units.NET was intended for convenience and ease of use, not highly accurate conversions, but I am open to suggestions for improvements.

The tests accept an error up to 1E-5 for most units added so far. Exceptions include units like Teaspoon, where the base unit cubic meter is a lot bigger. In many usecases this is sufficient, but for others this may be a showstopper and something you need to be aware of.

For more details, see [Precision](https://github.com/anjdreas/UnitsNet/wiki/Precision).


<a name="serialization"></a>Serialization
---
* `UnitsNet.Serialization.JsonNet` ([nuget](https://www.nuget.org/packages/UnitsNet.Serialization.JsonNet), [src](https://github.com/anjdreas/UnitsNet/tree/master/UnitsNet.Serialization.JsonNet), [tests](https://github.com/anjdreas/UnitsNet/tree/master/UnitsNet.Serialization.JsonNet.Tests)) for JSON.NET

**Important!** 
We cannot guarantee backwards compatibility, although we will strive to do that on a "best effort" basis and bumping the major nuget version when a change is necessary.

The base unit of any unit should be be treated as volatile as we have changed this several times in the history of this library already. Either to reduce precision errors of common units or to simplify code generation. An example is Mass, where the base unit was first Kilogram as this is the SI unit of mass, but in order to use powershell scripts to generate milligrams, nanograms etc. it was easier to choose Gram as the base unit of Mass.


<a name="contribute"></a>Want To Contribute?
---
This project is still early and many units and conversions are not yet covered. If you are missing something, please help by contributing or [ask for it](https://github.com/anjdreas/UnitsNet/issues) by creating an issue.

Please read the wiki on [Adding a New Unit](https://github.com/anjdreas/UnitsNet/wiki/Adding-a-New-Unit).

Generally adding a unit involves adding or modifying `UnitsNet\UnitDefinitions\*.json` files and running `generate-code.bat` to regenerate the source code and test code stubs, then manually implementing the new unit conversion constants in the test code.

  * [Fork the repo](https://help.github.com/articles/fork-a-repo)
  * Do work on branches such as **feature/add-myunit** and **fix/34**
  * [Create a pull request](https://help.github.com/articles/using-pull-requests)

<a name="ci"></a>Continuous Integration
---
A [TeamCity build server](http://teamcity.chump.work/viewType.html?buildTypeId=UnitsNet&guest=1) performs the following:
* Build and test pull requests. Notifies on success or error.
* Build, test and deploy nuget on master branch.

<a name="who-are-using"></a>Who are Using This?
---
It would be awesome to know who are using this library. If you would like your project listed here, [create an issue](https://github.com/anjdreas/UnitsNet/issues) or edit the [README.md](https://github.com/anjdreas/UnitsNet/edit/master/README.md) and send a pull request. Max logo size is `300x35 pixels` and should be in `.png`, `.gif` or `.jpg` formats.

![Motion Catalyst logo](http://swingcatalyst.s3.amazonaws.com/images/logos/MotionCatalyst_greenblack_35p.png "Motion Catalyst logo")

#### Swing Catalyst and Motion Catalyst, Norway
> Sports performance applications for Windows and iOS, that combine high-speed video with sensor data to bring facts into your training and visualize the invisible forces at work
> 
> Units.NET started here in 2007 when reading strain gauge measurements from force plates and has been very useful in integrating a number of different sensor types into our software and presenting the data in the user's preferred culture and units.

https://www.swingcatalyst.com (for golf)<br>
https://www.motioncatalyst.com (everything else)

*- Andreas Gullberg Larsen, CTO (andreas@motioncatalyst.com)*

![PK Sound logo](https://cloud.githubusercontent.com/assets/17773454/19447800/5c6ec76c-945c-11e6-90f8-3f410e8157b9.jpg)
#### PK Sound, Canada
> Award-winning performers and composers put everything they’ve got into their music. PK Sound makes sure their fans will hear it all – brilliantly, precisely, consistently.
>
> PK Sound uses UnitsNet in Kontrol - the remote control counterpart to Trinity, the world's only robotic line array solution.

http://www.pksound.ca/pk-sound/announcing-the-official-release-of-kontrol/ (for an idea of what the Kontrol project is)<br>
http://www.pksound.ca/trinity/ (the speakers that Kontrol currently controls)<br>
http://www.pksound.ca/ (everything else)

*- Jules LaPrairie, Kontrol software team member*
