[![Build status](https://ci.appveyor.com/api/projects/status/f8qfnqd7enkc6o4k/branch/master?svg=true)](https://ci.appveyor.com/project/angularsen/unitsnet/history/branch/master) [![Join the chat at https://gitter.im/UnitsNet/Lobby](https://badges.gitter.im/UnitsNet/Lobby.svg)](https://gitter.im/UnitsNet/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![codecov](https://codecov.io/gh/angularsen/UnitsNet/branch/master/graph/badge.svg)](https://codecov.io/gh/angularsen/UnitsNet)

## Units.NET

Add strongly typed quantities to your code and get merrily on with your life. 

No more magic constants found on Stack Overflow, no more second-guessing the unit of parameters and variables.

Units.NET gives you all the common units of measurement and the conversions between them. It is lightweight and thoroughly tested. If you have read this far, it is exactly what you are looking for and then some.

### Upgrading from 3.x to 4.x?
See [Upgrading from 3.x to 4.x](https://github.com/angularsen/UnitsNet/wiki/Upgrading-from-3.x-to-4.x).

### Build Targets

* .NET Standard 2.0
* .NET 4.0
* [Windows Runtime Component](https://docs.microsoft.com/en-us/windows/uwp/winrt-components/) for UWP apps (WinJS or C++)

### Overview

* [95 quantities with 1000+ units](UnitsNet/GeneratedCode/Units) generated from [JSON](Common/UnitDefinitions/) by [C# CLI app](CodeGen)
* [2500+ unit tests](https://ci.appveyor.com/project/angularsen/unitsnet) on conversions and localizations
* Conforms to [Microsoft's open-source library guidance](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/), in particular:
  * [SourceLink](https://github.com/dotnet/sourcelink) to step into source code of NuGet package while debugging
  * [Strong naming](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/get-started#strong-naming) to make the library available to all developers
* Immutable structs that implement `IEquatable`, `IComparable`
* [Statically typed quantities and units](#static-typing) to avoid mistakes and communicate intent
* [Operator overloads](#operator-overloads) for arithmetic on quantities
* [Parse and ToString()](#culture) supports cultures and localization
* [Dynamically parse and convert](#dynamic-parsing) quantities and units
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
// Construct            
Length meter = Length.FromMeters(1);
Length twoMeters = new Length(2, LengthUnit.Meter);
          
// Convert
double cm = meter.Centimeters;         // 100
double yards = meter.Yards;            // 1.09361
double feet = meter.Feet;              // 3.28084
double inches = meter.Inches;          // 39.3701

// Pass quantity types instead of values to avoid conversion mistakes and communicate intent
string PrintPersonWeight(Mass weight)
{
    // Compile error! Newtons belong to Force, not Mass. A common source of confusion.
    double weightNewtons = weight.Newtons; 
    
    // Convert to the unit of choice - when you need it
    return $"You weigh {weight.Kilograms:F1} kg.";
}
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

// ToString() uses CurrentUICulture for abbreviation language and CurrentCulture for number formatting
Thread.CurrentThread.CurrentUICulture = russian;
string kgRu = oneKg.ToString(); // "1 кг"

// ToString() with specific culture and custom string format pattern
string mgUs = oneKg.ToUnit(MassUnit.Milligram).ToString(usEnglish, "unit: {1}, value: {0:F2}"); // "unit: mg, value: 1.00"
string mgRu = oneKg.ToUnit(MassUnit.Milligram).ToString(russian, "unit: {1}, value: {0:F2}"); // "unit: мг, value: 1,00"

// Parse measurement from string
Mass kg = Mass.Parse("1.0 kg", usEnglish);

// Parse unit from string, a unit can have multiple abbreviations
RotationalSpeedUnit rpm1 = RotationalSpeed.ParseUnit("rpm"); // RotationalSpeedUnit.RevolutionPerMinute
RotationalSpeedUnit rpm2 = RotationalSpeed.ParseUnit("r/min");  // RotationalSpeedUnit.RevolutionPerMinute

// Get default abbreviation for a unit, the first if more than one is defined in Length.json for Kilogram unit
string kgAbbreviation = Mass.GetAbbreviation(MassUnit.Kilogram); // "kg"
```

#### Gotcha: AmbiguousUnitParseException
Some units of a quantity have the same abbreviation, which means `.Parse()` is not able to know what unit you wanted.
Unfortunately there is no built-in way to avoid this, either you need to ensure you don't pass in input that cannot be parsed or you need to write your own parser that has more knowledge of preferred units or maybe only a subset of the units.

Example:
`Length.Parse("1 pt")` throws `AmbiguousUnitParseException` with message `Cannot parse "pt" since it could be either of these: DtpPoint, PrinterPoint`.

### <a name="dynamic-parsing"></a>Dynamically Parse Quantities and Convert to Units
Sometimes you need to work with quantities and units at runtime, such as parsing user input.

There are a handful of classes to help with this:

- [Quantity](UnitsNet/CustomCode/Quantity.cs) for parsing and constructing quantities as well as looking up units, names and quantity information dynamically
- [UnitConverter](UnitsNet/UnitConverter.cs) for converting values to a different unit, with only strings or enum values
- [UnitParser](UnitsNet/CustomCode/UnitParser.cs) for parsing unit abbreviation strings, such as `"cm"` to `LengthUnit.Centimeter`

#### Enumerate quantities and units
`Quantity` is the go-to class for looking up information about quantities at runtime.
```c#
string[] Quantity.Names;       // ["Length", "Mass", ...]
QuantityType[] Quantity.Types; // [QuantityType.Length, QuantityType.Mass, ...]
QuantityInfo[] Quantity.Infos; // Information about all quantities and their units, types, values etc., see more below

QuantityInfo Quantity.GetInfo(QuantityType.Length); // Get information about Length
```

#### Information about quantity type
`QuantityInfo` makes it easy to enumerate names, units, types and values for the quantity type.
This is useful for populating lists of quantities and units for the user to choose.

```c#
QuantityInfo lengthInfo = Quantity.GetInfo(QuantityType.Length); // You can get it statically here
lengthInfo = Length.Info;                                        // or statically per quantity
lengthInfo = Length.Zero.QuantityInfo;                           // or dynamically from quantity instances

lengthInfo.Name;         // "Length"
lengthInfo.QuantityType; // QuantityType.Length
lengthInfo.UnitNames;    // ["Centimeter", "Meter", ...]
lengthInfo.Units;        // [LengthUnit.Centimeter, LengthUnit.Meter, ...]
lengthInfo.UnitType;     // typeof(LengthUnit)
lengthInfo.ValueType;    // typeof(Length)
lengthInfo.Zero;         // Length.Zero
```

#### Construct quantity
All you need is the value and the unit enum value.

```c#
IQuantity quantity = Quantity.From(3, LengthUnit.Centimeter); // Length

if (Quantity.TryFrom(3, LengthUnit.Centimeter, out IQuantity quantity2))
{	
}
```
#### Parse quantity
Parse any string to a quantity instance of the given the quantity type.

```c#
IQuantity quantity = Quantity.Parse(typeof(Length), "3 cm"); // Length

if (Quantity.TryParse(typeof(Length), "3cm", out IQuantity quantity2)
{
}
```

#### Parse unit
[UnitParser](UnitsNet/CustomCode/UnitParser.cs) parses unit abbreviation strings to unit enum values.

```c#
Enum unit = UnitParser.Default.Parse("cm", typeof(LengthUnit)); // LengthUnit.Centimeter

if (UnitParser.Default.TryParse("cm", typeof(LengthUnit), out Enum unit2))
{
    // Use unit2 as LengthUnit.Centimeter
}
```

#### Convert quantity to unit - IQuantity and Enum
Convert any `IQuantity` instance to a different unit by providing a target unit enum value.
```c#
// Assume these are passed in at runtime, we don't know their values or type
Enum userSelectedUnit = LengthUnit.Millimeter;
IQuantity quantity = Length.FromCentimeters(3);

// Later we convert to a unit
quantity.ToUnit(userSelectedUnit).Value;      // 30
quantity.ToUnit(userSelectedUnit).Unit;       // LengthUnit.Millimeter
quantity.ToUnit(userSelectedUnit).ToString(); // "30 mm"
quantity.ToUnit(PressureUnit.Pascal);         // Throws exception, not compatible
quantity.As(userSelectedUnit);                // 30
```

#### Convert quantity to unit - From/To Enums
Useful when populating lists with unit enum values for the user to choose.

```c#
UnitConverter.Convert(1, LengthUnit.Centimeter, LengthUnit.Millimeter); // 10 mm
```

#### Convert quantity to unit - Names or abbreviation strings
Sometimes you only have strings to work with, that works too!

```c#
UnitConverter.ConvertByName(1, "Length", "Centimeter", "Millimeter"); // 10 mm
UnitConverter.ConvertByAbbreviation(1, "Length", "cm", "mm"); // 10 mm
```

### <a name="example-app"></a>Example: Creating a dynamic unit converter app
[Source code](https://github.com/angularsen/UnitsNet/tree/master/Samples/UnitConverter.Wpf) for `Samples/UnitConverter.Wpf`<br/>
[Download](https://github.com/angularsen/UnitsNet/releases/tag/UnitConverterWpf%2F2018-11-09) (release 2018-11-09 for Windows)

![image](https://user-images.githubusercontent.com/787816/34920961-9b697004-f97b-11e7-9e9a-51ff7142969b.png)


This example shows how you can create a dynamic unit converter, where the user selects the quantity to convert, such as `Temperature`, then selects to convert from `DegreeCelsius` to `DegreeFahrenheit` and types in a numeric value for how many degrees Celsius to convert.
The quantity list box contains `QuantityType` values such as `QuantityType.Length` and the two unit list boxes contain `Enum` values, such as `LengthUnit.Meter`.

#### Populate quantity selector
Use `Quantity` to enumerate all quantity type enum values, such as `QuantityType.Length` and `QuantityType.Mass`.

```c#
this.Quantities = Quantity.Types; // QuantityType[]
```

#### Update unit lists when selecting new quantity
So user can only choose from/to units compatible with the quantity type.

```c#
QuantityInfo quantityInfo = Quantity.GetInfo(quantityType);

_units.Clear();
foreach (Enum unitValue in quantityInfo.Units)
{
    _units.Add(unitValue);
}
```

#### Update calculation on unit selection changed
Using `UnitConverter` to convert by unit enum values as given by the list selection `"Length"` and unit names like `"Centimeter"` and `"Meter"`.

```c#
double convertedValue = UnitConverter.Convert(
    FromValue,                      // numeric value
    SelectedFromUnit.UnitEnumValue, // Enum, such as LengthUnit.Meter
    SelectedToUnit.UnitEnumValue);  // Enum, such as LengthUnit.Centimeter
```

### Example: WPF app using IValueConverter to parse quantities from input

Src: [Samples/WpfMVVMSample](https://github.com/angularsen/UnitsNet/tree/master/Samples/WpfMVVMSample)

![wpfmvvmsample_219w](https://user-images.githubusercontent.com/787816/34913417-094332e2-f8fd-11e7-9d8a-92db105fbbc9.png)

The purpose of this app is to show how to create an `IValueConverter` in order to bind XAML to quantities.

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

Generally adding a unit involves adding or modifying [Common/UnitDefinitions/*.json](Common/UnitDefinitions/) files and running [generate-code.bat](generate-code.bat) to regenerate the source code and test code stubs, then manually implementing the new unit conversion constants in the test code.

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

![ANSYS, Inc. Logo](https://www.ansys.com/-/media/ansys/global/brandings/logo-ansys.jpg "ANSYS, Inc. Logo")

#### ANSYS, Inc. (ANSYS Discovery Live)
> ANSYS Discovery Live provides instantaneous 3D simulation, tightly coupled with direct geometry modeling, to enable interactive design exploration and rapid product innovation. It is an interactive experience in which you can manipulate geometry, material types or physics inputs, then instantaneously see changes in performance.

https://www.ansys.com
https://www.ansys.com/products/3d-design/ansys-discovery-live

*- Tristan Milnthorp, Principal Software Architect (tristan.milnthorp@ansys.com)*

#### Primoris Sigma Stargen
Stargen is a decades old software to create realistic planets and satellites from a given Star. It's based on work from various scientists and been used for years. Primoris Sigma Stargen is a C# port of the utility that makes it a Framework to extend it with new algorithms for planetary formation and physics equations. 

https://github.com/ebfortin/primoris.universe.stargen
