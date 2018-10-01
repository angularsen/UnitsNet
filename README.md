[![Build status](https://ci.appveyor.com/api/projects/status/f8qfnqd7enkc6o4k/branch/master?svg=true)](https://ci.appveyor.com/project/angularsen/unitsnet/history/branch/master) [![Join the chat at https://gitter.im/UnitsNet/Lobby](https://badges.gitter.im/UnitsNet/Lobby.svg)](https://gitter.im/UnitsNet/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) 
[![Flattr this git repo](https://button.flattr.com/flattr-badge-large.png)](https://flattr.com/submit/auto?fid=g37dpx&url=https://github.com/angularsen/UnitsNet/&title=Units.NET&language=en-US&tags=github&category=software)


## Units.NET

Everyone have written their share of trivial conversions - or less obvious ones where you need to Google that magic constant. 

Stop littering your code with unnecessary calculations, Units.NET gives you all the common units of measurement and the conversions between them. It is lightweight and thoroughly tested.


### Build Targets

* .NET Standard 2.0
* .NET 4.0
* [Windows Runtime Component](https://docs.microsoft.com/en-us/windows/uwp/winrt-components/) for UWP apps (JavaScript, C++ or C#)


### Overview

* [89 quantities with over 750 units](UnitsNet/GeneratedCode/Units) generated from [JSON](Common/UnitDefinitions/) by [Powershell scripts](UnitsNet/Scripts)
* [1900+ unit tests](https://ci.appveyor.com/project/angularsen/unitsnet) on conversions and localizations
* Immutable structs that implement `Equatable`, `IComparable`
* [Static typing](#static-typing) to avoid ambiguous values or units
* [Operator overloads](#operator-overloads) for arithmetic on quantities
* [Parse and ToString()](#culture) supports cultures and localization
* [Example: Creating a unit converter app](#example-app)
* [Example: WPF app using IValueConverter to parse quantities from input](#example-wpf-app-using-ivalueconverter-to-parse-quantities-from-input)
* [Precision and accuracy](#precision)
* [Serializable with JSON.NET](#serialization)
* Extensible with [custom units](https://github.com/angularsen/UnitsNet/wiki/Extending-with-Custom-Units)
* [Contribute](#contribute) if you are missing some units
* [Continuous integration](#ci) posts status reports to pull requests and commits
* [Who are using this?](#who-are-using)


### Installing

Run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console) or go to the [NuGet site](https://www.nuget.org/packages/UnitsNet/) for the complete relase history.

![Install-Package UnitsNet](https://raw.githubusercontent.com/angularsen/UnitsNet/master/Docs/Images/install_package_unitsnet.png "Install-Package UnitsNet")


### <a name="static-typing"></a>Static Typing

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

### <a name="operator-overloads"></a>Operator Overloads

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

### <a name="culture"></a>Culture and Localization

The culture for abbreviations defaults to Thread.CurrentUICulture and falls back to US English if not defined. Thread.CurrentCulture affects number formatting unless a custom culture is specified. The relevant methods are:

* ToString()
* GetAbbreviation()
* Parse/TryParse()
* ParseUnit/TryParseUnit()
```C#
var usEnglish = new CultureInfo("en-US");
var russian = new CultureInfo("ru-RU");
var oneKg = Mass.FromKilograms(1);

// Honors Thread.CurrentUICulture
Thread.CurrentUICulture = russian;
string kgRu = oneKg.ToString(); // "1 кг"

// ToString() with specific culture and string format pattern
string mgUs = oneKg.ToString(MassUnit.Milligram, usEnglish, "{1} {0:0.00}"); // "mg 1.00"
string mgRu = oneKg.ToString(MassUnit.Milligram, russian, "{1} {0:0.00}"); // "мг 1,00"

// Parse measurement from string
Mass kg = Mass.Parse(usEnglish, "1.0 kg");

// Parse unit from string, a unit can have multiple abbreviations
RotationalSpeedUnit rpm1 == RotationalSpeed.ParseUnit("rpm"); // RotationalSpeedUnit.RevolutionPerMinute
RotationalSpeedUnit rpm2 == RotationalSpeed.ParseUnit("r/min");  // RotationalSpeedUnit.RevolutionPerMinute

// Get default abbreviation for a unit
string abbrevKg = Mass.GetAbbreviation(MassUnit.Kilogram); // "kg"
```

#### Gotcha: AmbiguousUnitParseException
Some units of a quantity have the same abbreviation, which means `.Parse()` is not able to know what unit you wanted.
Unfortunately there is no built-in way to avoid this, either you need to ensure you don't pass in input that cannot be parsed or you need to write your own parser that has more knowledge of preferred units or maybe only a subset of the units.

Example:
`Length.Parse("1 pt")` throws `AmbiguousUnitParseException` with message `Cannot parse "pt" since it could be either of these: DtpPoint, PrinterPoint`.


### <a name="example-app"></a>Example: Creating a dynamic unit converter app
[Source code](https://github.com/angularsen/UnitsNet/tree/master/Samples/UnitConverter.Wpf) for `Samples/UnitConverter.Wpf`<br/>
[Download](https://github.com/angularsen/UnitsNet/releases/tag/UnitConverterWpf%2F2018-02-04) (release 2018-02-04 for Windows)

![image](https://user-images.githubusercontent.com/787816/34920961-9b697004-f97b-11e7-9e9a-51ff7142969b.png)


This example shows how you can create a dynamic unit converter, where the user selects the quantity to convert, such as `Length` or `Mass`, then selects to convert from `Meter` to `Centimeter` and types in a value for how many meters.

NOTE: There are still some limitations in the library that requires reflection to enumerate units for quantity and getting the abbreviation for a unit, when we want to dynamically enumerate and convert between units.

### <a name="example-app-hardcoded"></a>Example: Creating a unit converter app with hard coded quantities

If you can live with hard coding what quantities to convert between, then the following code snippet shows you one way to go about it:

```C#
// Get quantities for populating quantity UI selector
QuantityType[] quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().ToArray();

// If Length is selected, get length units for populating from/to UI selectors
LengthUnit[] lengthUnits = Length.Units;

// Perform conversion using input value and selected from/to units
double inputValue; // Obtain from textbox
LengthUnit fromUnit, toUnit; // Obtain from ListBox selections
double resultValue = Length.From(inputValue, fromUnit).As(toUnit);

// Alternatively, you can also convert using string representations of units
double centimeters = UnitConverter.ConvertByName(5, "Length", "Meter", "Centimeter"); // 500
double centimeters2 = UnitConverter.ConvertByAbbreviation(5, "Length", "m", "cm"); // 500
```

### Example: WPF app using IValueConverter to parse quantities from input

Src: [Samples/WpfMVVMSample](https://github.com/angularsen/UnitsNet/tree/master/Samples/WpfMVVMSample)

![wpfmvvmsample_219w](https://user-images.githubusercontent.com/787816/34913417-094332e2-f8fd-11e7-9d8a-92db105fbbc9.png)


The purpose of this app is to show how to create an `IValueConverter` in order to bind XAML to quantities.

NOTE: A lot of reflection and complexity were introduced due to not having a base type. See #371 for discussion on adding base types.

### <a name="precision"></a>Precision and Accuracy

A base unit is chosen for each unit class, represented by a double value (64-bit), and all conversions go via this unit. This means that there will always be a small error in both representing other units than the base unit as well as converting between units.

Units.NET was intended for convenience and ease of use, not highly accurate conversions, but I am open to suggestions for improvements.

The tests accept an error up to 1E-5 for most units added so far. Exceptions include units like Teaspoon, where the base unit cubic meter is a lot bigger. In many usecases this is sufficient, but for others this may be a showstopper and something you need to be aware of.

For more details, see [Precision](https://github.com/angularsen/UnitsNet/wiki/Precision).


### <a name="serialization"></a>Serialization

* `UnitsNet.Serialization.JsonNet` ([nuget](https://www.nuget.org/packages/UnitsNet.Serialization.JsonNet), [src](https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Serialization.JsonNet), [tests](https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Serialization.JsonNet.Tests)) for JSON.NET

**Important!** 
We cannot guarantee backwards compatibility, although we will strive to do that on a "best effort" basis and bumping the major nuget version when a change is necessary.

The base unit of any unit should be treated as volatile as we have changed this several times in the history of this library already. Either to reduce precision errors of common units or to simplify code generation. An example is Mass, where the base unit was first Kilogram as this is the SI unit of mass, but in order to use powershell scripts to generate milligrams, nanograms etc. it was easier to choose Gram as the base unit of Mass.


### <a name="contribute"></a>Want To Contribute?

This project is still early and many units and conversions are not yet covered. If you are missing something, please help by contributing or [ask for it](https://github.com/angularsen/UnitsNet/issues) by creating an issue.

Please read the wiki on [Adding a New Unit](https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit).

Generally adding a unit involves adding or modifying `UnitsNet\UnitDefinitions\*.json` files and running `generate-code.bat` to regenerate the source code and test code stubs, then manually implementing the new unit conversion constants in the test code.

  * [Fork the repo](https://help.github.com/articles/fork-a-repo)
  * Do work on branches such as **feature/add-myunit** and **fix/34**
  * [Create a pull request](https://help.github.com/articles/using-pull-requests)

### <a name="ci"></a>Continuous Integration

[AppVeyor](https://ci.appveyor.com/project/angularsen/unitsnet) performs the following:
* Build and test all branches
* Build and test pull requests, notifies on success or error
* Deploy nugets on master branch, if nuspec versions changed

### <a name="who-are-using"></a>Who are Using This?

It would be awesome to know who are using this library. If you would like your project listed here, [create an issue](https://github.com/angularsen/UnitsNet/issues) or edit the [README.md](https://github.com/angularsen/UnitsNet/edit/master/README.md) and send a pull request. Max logo size is `300x35 pixels` and should be in `.png`, `.gif` or `.jpg` formats.

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

#### Microsoft.IoT.Devices
> Microsoft.IoT.Devices extends Windows IoT Core and makes it easier to support devices like sensors and displays. It provides event-driven access for many digital and analog devices and even provides specialized wrappers for devices like joystick, rotary encoder and graphics display.

http://aka.ms/iotdevices (home page including docs)<br>
http://www.nuget.org/packages/Microsoft.IoT.Devices (NuGet package)

#### Crawlspace
> Software for creating printable hex maps for use in pen and paper RPGs. Both
> a user-friendly app and a high-level library for generating labelled hexmaps.

https://bitbucket.org/MartinEden/Crawlspace

*- Martin Eden, project maintainer*

