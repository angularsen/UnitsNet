[![Build Status](https://dev.azure.com/unitsnet/Units.NET/_apis/build/status/UnitsNet?branchName=master)](https://dev.azure.com/unitsnet/Units.NET/_build/latest?definitionId=1&branchName=master)
[![codecov](https://codecov.io/gh/angularsen/UnitsNet/branch/master/graph/badge.svg)](https://codecov.io/gh/angularsen/UnitsNet)
[![StandWithUkraine](https://raw.githubusercontent.com/vshymanskyy/StandWithUkraine/main/badges/StandWithUkraine.svg)](https://github.com/vshymanskyy/StandWithUkraine/blob/main/docs/README.md)

## Units.NET

Add strongly typed quantities to your code and get merrily on with your life.

No more magic constants found on Stack Overflow, no more second-guessing the unit of parameters and variables.

[Upgrading from 4.x to 5.x](https://github.com/angularsen/UnitsNet/wiki/Upgrading-from-4.x-to-5.x)<br>
[Upgrading from 5.x to 6.x](https://github.com/angularsen/UnitsNet/wiki/Upgrading-from-5.x-to-6.x) (still in prerelease and may yet change)

### Overview

* [Overview](#overview)
* [Installing via NuGet](#installing-via-nuget)
* [Static Typing](#static-typing)
* [Operator Overloads](#operator-overloads)
* [Culture and Localization](#culture-and-localization)
* [Dynamically Parse Quantities and Convert to Units](#dynamically-parse-quantities-and-convert-to-units)
* [Custom units](#custom-units)
* [Example: Unit converter app](#example-unit-converter-app)
* [Example: WPF app using IValueConverter to parse input](#example-wpf-app-using-ivalueconverter-to-parse-input)
* [Precision and Accuracy](#precision-and-accuracy)
* [Serialize to JSON, XML and more](#serialize-to-json-xml-and-more)
* [Want To Contribute?](#want-to-contribute)
* [Continuous Integration](#continuous-integration)
* [Who are Using This?](#who-are-using-this)
* [Top Usages by GitHub Repos](#top-usages-by-gitHub-repos)
* [Units.NET on other platforms](#unitsnet-on-other-platforms)

### Installing via NuGet

Add it via CLI

    dotnet add package UnitsNet

or go to [NuGet Gallery | UnitsNet](https://www.nuget.org/packages/UnitsNet) for detailed instructions.


#### Build Targets

* .NET Standard 2.0
* [.NET nanoFramework](https://www.nanoframework.net/)

### Static Typing

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

### Operator Overloads

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

### Culture and Localization

The culture for abbreviations defaults to Thread.CurrentCulture and falls back to US English if not defined. Thread.CurrentCulture affects number formatting unless a custom culture is specified. The relevant methods are:

* ToString()
* GetAbbreviation()
* Parse/TryParse()
* ParseUnit/TryParseUnit()
```C#
var usEnglish = new CultureInfo("en-US");
var russian = new CultureInfo("ru-RU");
var oneKg = Mass.FromKilograms(1);

// ToString() uses CurrentCulture for abbreviation language number formatting. This is consistent with the behavior of the .NET Framework,
// where DateTime.ToString() uses CurrentCulture for the whole string, likely because mixing an english date format with a russian month name might be confusing.
Thread.CurrentThread.CurrentCulture = russian;
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

### Dynamically Parse Quantities and Convert to Units
Sometimes you need to work with quantities and units at runtime, such as parsing user input.

There are a handful of classes to help with this:

- [Quantity](UnitsNet/CustomCode/Quantity.cs) for parsing and constructing quantities as well as looking up units, names and quantity information dynamically
- [UnitConverter](UnitsNet/UnitConverter.cs) for converting values to a different unit, with only strings or enum values
- [UnitParser](UnitsNet/CustomCode/UnitParser.cs) for parsing unit abbreviation strings, such as `"cm"` to `LengthUnit.Centimeter`

#### Quantity - Enumerate quantities and units at runtime
Use `Quantity` class for looking up `QuantityInfo` and `UnitInfo` at runtime.

```c#
string[] names = Quantity.Names;     // ["Length", "Mass", ...]
QuantityInfo[] qis = Quantity.Infos; // All quantities and their units, types, values.

// Look up quantity by name.
QuantityInfo lengthInfo = Quantity.ByName["Length"];
UnitInfo[] lengthUnits = lengthInfo.UnitInfos;

// Look up unit by enum value (note: for extensibility, will instead look up by name in the future)
UnitInfo cmInfo = Quantity.GetUnitInfo(LengthUnit.Centimeter);
```

#### QuantityInfo - Information about a quantity
`QuantityInfo` makes it easy to get names, units, types and values for a quantity.
This is useful for populating lists of quantities and units for the user to choose.

```c#
// Different ways to look up the quantity info.
QuantityInfo lengthInfo = Quantity.ByName["Length"];
lengthInfo = Length.Info;
lengthInfo = Length.FromMeters(1).QuantityInfo;

// The quantity information.
lengthInfo.Name;            // "Length"
lengthInfo.UnitInfos;       // UnitInfo[] for its units Centimeter, Meter, etc.
lengthInfo.BaseUnitInfo;    // UnitInfo for LengthUnit.Meter
lengthInfo.BaseDimensions;  // {"Length": 1, "Mass": 0, ...}
lengthInfo.UnitType;        // typeof(LengthUnit)
lengthInfo.ValueType;       // typeof(Length)
lengthInfo.Zero;            // Length.Zero
```

#### UnitInfo - Information about a unit
`UnitInfo` describes a unit, such as its enum value, names and its representation in SI base units.

```c#
// Different ways to look up the unit info.
var cm = Quantity.GetUnitInfo(LengthUnit.Centimeter);

if (Quantity.TryGetUnitInfo(LengthUnit.Centimeter, out UnitInfo tryGetCm)) {
    cm = tryGetCm;
}

// The unit information.
cm.Value;       // Enum value: LengthUnit.Centimeter
cm.Name;        // "Centimeter"
cm.PluralName;  // "Centimeters"
cm.BaseUnits;   // {"Length": Centimeter, "Mass": null, "Time": null, ...}
```

#### Construct quantity
All you need is the value and the unit enum value.

```c#
IQuantity quantity = Quantity.From(3, LengthUnit.Centimeter); // Length

if (Quantity.TryFrom(3, LengthUnit.Centimeter, out IQuantity quantity2))
{
}
```

You can also construct from strings, such as mapping between DTO types in an API:
```c#
IQuantity quantity = Quantity.From(value: 3, quantityName: "Length", unitName: "Centimeter");

if (Quantity.TryFrom(value: 3, quantityName: "Length", unitName: "Centimeter", out IQuantity? quantity2))
{
}
```

Or create by just the unit abbreviation, as long as there is exactly one unit with this abbreviation.
```c#
// Length with unit LengthUnit.Centimeter
IQuantity quantity = Quantity.FromUnitAbbreviation(3, "cm");

if (Quantity.TryFromUnitAbbreviation(3, "cm", out IQuantity? quantity2))
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

### Custom units

Units.NET allows you to add your own units and quantities at runtime, to represent as `IQuantity` and reusing Units.NET for parsing and converting between units.

Read more at [Extending-with-Custom-Units](https://github.com/angularsen/UnitsNet/wiki/Extending-with-Custom-Units).

#### Map between unit enum values and unit abbreviations
```c#
// Map unit enum values to unit abbreviations
UnitAbbreviationsCache.Default.MapUnitToDefaultAbbreviation(HowMuchUnit.Some, "sm");
UnitAbbreviationsCache.Default.GetDefaultAbbreviation(HowMuchUnit.Some); // "sm"
UnitParser.Default.Parse<HowMuchUnit>("sm");  // HowMuchUnit.Some
```

#### Convert between units of custom quantity
```c#
var unitConverter = UnitConverter.Default;
unitConverter.SetConversionFunction<HowMuch>(HowMuchUnit.Lots, HowMuchUnit.Some, x => new HowMuch(x.Value * 2, HowMuchUnit.Some));
unitConverter.SetConversionFunction<HowMuch>(HowMuchUnit.Tons, HowMuchUnit.Lots, x => new HowMuch(x.Value * 10, HowMuchUnit.Lots));
unitConverter.SetConversionFunction<HowMuch>(HowMuchUnit.Tons, HowMuchUnit.Some, x => new HowMuch(x.Value * 20, HowMuchUnit.Some));

var from = new HowMuch(10, HowMuchUnit.Tons);
IQuantity Convert(HowMuchUnit toUnit) => unitConverter.GetConversionFunction<HowMuch>(from.Unit, toUnit)(from);

Console.WriteLine($"Convert 10 tons to:");
Console.WriteLine(Convert(HowMuchUnit.Some)); // 200 sm
Console.WriteLine(Convert(HowMuchUnit.Lots)); // 100 lts
Console.WriteLine(Convert(HowMuchUnit.Tons)); // 10 tns
```

#### Parse custom quantity
[QuantityParser](UnitsNet/CustomCode/QuantityParser.cs) parses quantity strings to `IQuantity` by providing a `UnitAbbreviationsCache` with custom units and unit abbreviations.

```c#
// Alternatively, manipulate the global UnitAbbreviationsCache.Default.
var unitAbbreviationsCache = new UnitAbbreviationsCache();
unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.Some, "sm");
unitAbbreviationsCache.MapUnitToAbbreviation(HowMuchUnit.ATon, "tn");

var quantityParser = new QuantityParser(unitAbbreviationsCache);

// 1 Some
HowMuch q = quantityParser.Parse<HowMuch, HowMuchUnit>(
    str: "1 sm",
    formatProvider: null,
    fromDelegate: (value, unit) => new HowMuch((double) value, unit));
```


### Example: Unit converter app
[Source code](https://github.com/angularsen/UnitsNet/tree/master/Samples/UnitConverter.Wpf) for `Samples/UnitConverter.Wpf`<br/>
[Download](https://github.com/angularsen/UnitsNet/releases/tag/UnitConverterWpf%2F2018-11-09) (release 2018-11-09 for Windows)

![image](https://user-images.githubusercontent.com/787816/34920961-9b697004-f97b-11e7-9e9a-51ff7142969b.png)

This example shows how you can create a dynamic unit converter, where the user selects the quantity to convert, such as `Temperature`, then selects to convert from `DegreeCelsius` to `DegreeFahrenheit` and types in a numeric value for how many degrees Celsius to convert.
The quantity list box contains quantity names, such as `"Length"`. The two unit list boxes contain `Enum` values, such as `LengthUnit.Meter`.

#### Populate quantity selector
Use `Quantity` to enumerate all quantity names, such as `"Length"` and `"Mass"`.

```c#
this.Quantities = Quantity.Names; // string[]

// or
this.Quantities = Quantity.Infos.Select(i => i.Name).ToList();
```

#### Update unit lists when selecting new quantity
So user can only choose from/to units compatible with the quantity type.

```c#
QuantityInfo quantityInfo = Quantity.ByName[quantityName];

_units.Clear();
foreach (Enum unitValue in quantityInfo.UnitInfos.Select(ui => ui.Value))
{
    _units.Add(new UnitListItem(unitValue));
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

### Example: WPF app using IValueConverter to parse input

Src: [Samples/MvvmSample.Wpf](https://github.com/angularsen/UnitsNet/tree/master/Samples/MvvmSample.Wpf)
                             
![wpfmvvmsample_219w](https://user-images.githubusercontent.com/787816/34913417-094332e2-f8fd-11e7-9d8a-92db105fbbc9.png)

The purpose of this app is to show how to create an `IValueConverter` in order to bind XAML to quantities.

### Precision and Accuracy

A base unit is chosen for each unit class, represented by a double value (64-bit), and all conversions go via this unit. This means that there will always be a small error in both representing other units than the base unit as well as converting between units.

Units.NET was intended for convenience and ease of use, not highly accurate conversions, but I am open to suggestions for improvements.

The tests accept an error up to 1E-5 for most units added so far. Exceptions include units like Teaspoon, where the base unit cubic meter is a lot bigger. In many usecases this is sufficient, but for others this may be a showstopper and something you need to be aware of.

For more details, see [Precision](https://github.com/angularsen/UnitsNet/wiki/Precision).

### Serialize to JSON, XML and more

Read the wiki on [Serializing to JSON, XML and more](https://github.com/angularsen/UnitsNet/wiki/Serializing-to-JSON,-XML-and-more).


### Want To Contribute?

- [Adding a New Unit](https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit) is fairly easy to do and we are happy to help.
- Want a new feature or to report a bug? [Create an issue](https://github.com/angularsen/UnitsNet/issues/new/choose) or start a [discussion](https://github.com/angularsen/UnitsNet/discussions).

### Continuous Integration

[Azure DevOps](https://dev.azure.com/unitsnet/Units.NET/) performs the following:
* Build and test all branches
* Build and test pull requests, notifies on success or error
* Deploy nugets on master branch, if nuspec versions changed


### Who are Using UnitsNet?

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

<img src="https://cdn.harringtonhoists.com/assets/harringtonhoists/logo-60629cc144429045d4c85740ab225e219add75b2c5c1e2c444ffa9500347a414.png" height="35">

#### Harrington Hoists, Inc. (A Subsidiary of KITO Americas, Inc.)
> Harrington Hoists, Inc. is located in Manheim, PA, Elizabethtown, PA, South Holland, IL and Corona, CA. Harrington is a leading manufacturer of manual, electric and air chain hoists as well as wire rope hoists and crane products serving the North American material handling industry.

Harrington uses UnitsNet in their internal software to perform many different calculations related to crane dimensioning, girder strength, electrical safety verification, etc.

https://www.harringtonhoists.com<br>
https://kito.com

*- Luke Westfall, Design Automation Engineer*

#### Structural Analysis Format - SDK project
<img src="https://gblobscdn.gitbook.com/spaces%2F-M__87HTlQktMqcjAf65%2Favatar-1620901174483.png?alt=media" height="35" />

> The Structural Analysis Format (SAF) has been created to allow structural engineering applications to exchange data using a straight forward and simple to understand format.
> While inspired by IFC, SAF has its benefits that it's **easily modifyable** by the end-user _(it's an xlsx file)_, **well documented** and **easy to understand**.
> UnitsNet is used by the SDK provided by SCIA to facilitate import / export between metric & imperial systems

https://www.saf.guide
https://github.com/StructuralAnalysisFormat/StructuralAnalysisFormat-SDK

*- Dirk Schuermans, Software Engineer for [SCIA nv](https://www.scia.net)*

### Top Usages by GitHub Repos

Produced with [ghtopdep](https://github.com/github-tooling/ghtopdep).

| Repo                                                            | Stars   |
|-----------------------------------------------------------------|---------|
| https://github.com/microsoft/PowerToys                          | 105K    |
| https://github.com/dotnet/iot                                   | 2.1K    |
| https://github.com/genielabs/HomeGenie                          | 388     |
| https://github.com/raspberry-sharp/raspberry-sharp-io           | 340     |
| https://github.com/nanoframework/nanoFramework.IoT.Device       | 202     |
| https://github.com/porrey/Virtual-ZPL-Printer                   | 166     |
| https://github.com/chino-os/chino-os                            | 147     |
| https://github.com/BriefFiniteElementNet/BriefFiniteElement.Net | 143     |
| https://github.com/WhiteBlackGoose/UnitsOfMeasure               | 57      |
| https://github.com/pi-top/pi-top-4-.NET-SDK                     | 48      |


### Units.NET on other platforms

Get the same strongly typed units on other platforms, based on the same [unit definitions](/Common/UnitDefinitions).

| Language                   | Name        | Package                                          | Repository                                           | Maintainers  |
|----------------------------|-------------|--------------------------------------------------|------------------------------------------------------|--------------|
| JavaScript /<br>TypeScript | unitsnet-js | [npm](https://www.npmjs.com/package/unitsnet-js) | [github](https://github.com/haimkastner/unitsnet-js) | @haimkastner |
| Python                     | unitsnet-py | [pypi](https://pypi.org/project/unitsnet-py)     | [github](https://github.com/haimkastner/unitsnet-py) | @haimkastner |
