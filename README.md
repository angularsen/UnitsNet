[![Build status](https://ci.appveyor.com/api/projects/status?id=yx8690rtkhk2g1fs)](https://ci.appveyor.com/project/initialforce-unitsnet)

Units.NET
========
Everyone have written their share of trivial conversions - or less obvious ones where you need to Google that magic constant. 

Stop littering your code with unnecessary calculations. Units.NET gives you all the common units of measurement and the conversions between them. It is light-weight, unit tested and supports [PCL](http://msdn.microsoft.com/en-us/library/gg597391.aspx "MSDN PCL").


Install
=======
To install Units.NET, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console) or go to the [NuGet site](https://www.nuget.org/packages/UnitsNet/ "NuGet site") for the complete relase history.

![Install-Package UnitsNet](https://raw.github.com/InitialForce/UnitsNet/master/Docs/Images/install_package_unitsnet.png "Install-Package UnitsNet")

Build Targets:
* .NET 3.5 Client
* Silverlight 4
* WinRT / .NET Core 4.5
* Portable Class Library (.NET 4.0 + Silverlight 4 + Windows Phone 7 + Xbox 360)

Features
========

* Immutable structs for units of measurement, such as Length, Mass, Force and Pressure. See full list [here](https://github.com/InitialForce/UnitsNet/blob/master/Src/UnitsNet/ "Data structures").
* Convert between most popular units in the metric and imperial systems. See full list [here](https://github.com/InitialForce/UnitsNet/blob/master/Src/UnitsNet/Unit.cs "Unit.cs").
* Choose between static (Length, Mass, Force etc.) or dynamic (UnitValue) representations for units of measurement.
* Parse abbreviation string to unit taking culture into account.
* Get abbreviation string for unit in different cultures.

Static Representation and Explicit Conversion
-----------------------------------------------
```C#
// Stop postfixing your variables and method names with the unit...
double weightKg = GetPersonWeightInKg();
UpdatePersonWeightInGrams(weightKg * 1000);

// ...and start using a static representation for the measurement then 
// explicitly convert to the unit of choice - when you need it.
Mass weight = GetPersonWeight();
UpdatePersonWeightInGrams(weight.Grams);

// Convert between compatible units of measurement...
Force scaleMeasurement = Force.FromNewtons(850);
Mass personWeight = Mass.FromGravitationalForce(scaleMeasurement);
double weightKg = personWeight.Kilograms;

// ...while avoiding confusing conversions, such as between weight and mass.
Mass weight = GetPersonWeight();
double weightNewtons = weight.Newtons; // No such thing.

// Some popular conversions.
Length meter = Length.FromMeters(1);
double cm = meter.Centimeters; // 100
double yards = meter.Yards; // 1.09361
double feet = meter.Feet; // 3.28084
double inches = meter.Inches; // 39.3701

Pressure p = Pressure.FromPascal(1);
double kpa = p.KiloPascals; // 1×10-3
double bar = p.Bars; // 1×10-5
double atm = p.Atmosphere; // 9.86923267×10-6
double psi = p.Psi; // 1.45037738×10-4
```

Dynamic Representation and Conversion
------------------
```C#
// Explicitly
double m = UnitConverter.Convert(1, Unit.Kilometer, Unit.Meter); // 1000
double mi = UnitConverter.Convert(1, Unit.Kilometer, Unit.Mile); // 0.621371
double yds = UnitConverter.Convert(1, Unit.Meter, Unit.Yard); // 1.09361

// Or dynamically.
UnitValue val = GetUnknownValueAndUnit();

// Returns false if conversion was not possible.
double cm;
val.TryConvert(Unit.Centimeter, out cm);
```

Helper Methods to Construct Measurements
----------------------------------------
```C#
var f = Force.FromPressureByArea(Pressure p, Length2d area);
var f = Force.FromMassAcceleration(Mass mass, double metersPerSecondSquared);
```

Parse and Get Culture-Specific Abbreviations
-------------------------------------------------
```C#
var us = new CultureInfo("en-US");
var norwegian = new CultureInfo("nb-NO");
  
Unit.Tablespoon == UnitSystem.Create(us).Parse("tbsp");
Unit.Tablespoon == UnitSystem.Create(norwegian).Parse("ss");

"T" == UnitSystem.GetDefaultAbbreviation(Unit.Tablespoon, us);
"ss" == UnitSystem.GetDefaultAbbreviation(Unit.Tablespoon, norwegian);
```

Precision
=========
A base unit is chosen for all classes of units, which is represented by a double value (64-bit), and all conversions go via this unit.
This means there will always be a small error in both representing other units than the base unit as well as converting between units.

In the unit tests I accept an error less than 1E-5 for all units I've added so far. In many usecases this is sufficient, but for some usecases this is definitely not OK and something you need to be aware of.
For more details, see [Precision](https://github.com/InitialForce/UnitsNet/wiki/Precision).


What It Is Not
==============

* It is not an equation solver. 
* It does not figure out the units after a calculation.

Frequently Asked Questions
==========================
Q: Why is the conversion not perfectly accurate? 
As an example, when converting 1 PoundForce (lbF) to KilogramForce (kgF) I expected the result to be 0.45359237 and instead I got​0.45359240790780886 using the following for the conversion:

```C# 
double kg = UnitConverter.Convert(1, Unit.PoundForce, Unit.KilogramForce);
```

A: There are a few concerns here.
* For several unit conversions there is no one perfect answer. Some units depend on constants such as the standard gravity, where different precisions are used in different contexts. Other constants depend on the environment, such as the temperature or altitude.
* By design, Units.NET was not intended for high-accuracy conversions but rather convenience and simplicity. I am open to suggestions for improvements. If you want to know more, see the [Precision](https://github.com/InitialForce/UnitsNet/wiki/Precision) article.


Want To Contribute?
===================
This project is still early and many units and conversions are not yet covered. If you are missing something, please help by contributing or [ask](https://github.com/InitialForce/UnitsNet/issues) for it by creating an issue.

Before adding new units, please read the wiki on [Adding a New Unit](https://github.com/InitialForce/UnitsNet/wiki/Adding-a-New-Unit). Other than that, we could always use more/better tests and documentation.

[Contact me](https://github.com/anjdreas) if you have any questions.
