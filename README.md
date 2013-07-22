Units.NET
========

Data structures and methods that make life working with units just a little bit better.

Everyone have written their share of trivial conversions between meters and centimeters, or less obvious conversions to units like Pascal and PSI where most mortals need a quick Google to find that magic constant.

Stop littering your code with unnecessary calculations. Units.NET gives you all the common units and conversions. It is light-weight, unit tested and supports [PCL](http://msdn.microsoft.com/en-us/library/gg597391.aspx "MSDN PCL").


Features
========

* Structs for most standard units of measurement, such as Length, Mass, Force and Pressure. See full list [here](https://github.com/InitialForce/UnitsNet/blob/master/Src/UnitsNet/ "Data structures").
* Enumeration of and conversion between most standard units in the metric and imperial systems. See full list [here](https://github.com/InitialForce/UnitsNet/blob/master/Src/UnitsNet/Unit.cs "Unit.cs").

Explicit Representation and Conversion of Units
-----------------------------------------------
```C#
// Stop postfixing your variables and method names with the unit...
double weightKg = GetPersonWeightInKg();
double weightGrams = weightKg * 1000;
double weightTonnes = weightKg / 1000;

// ...and start using an explicit representation for the measurement then 
// explicitly convert to the unit of choice - when you need it.
Mass weight = GetPersonWeight();
double weightGrams = weight.Grams;
double weightTonnes = weight.Tonnes;

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
double kpa = p.KiloPascals; // 1000
double bar = p.Bars; // 1 × 10-5
double atm = p.Atmosphere; // 9.86923267 × 10-6
double psi = p.Psi; // 1.45037738 × 10-4
```

Dynamic Conversions
-------------------
```C#
double m = UnitConverter.Convert(1, Unit.Kilometer, Unit.Meter); // 1000
double mi = UnitConverter.Convert(1, Unit.Kilometer, Unit.Mile); // 0.621371
double yds = UnitConverter.Convert(1, Unit.Meter, Unit.Yard); // 1.09361
```

UnitValue Representation and Conversion
--------------------------------------
```C#
UnitValue val = GetUnknownValueAndUnit();

// Returns false if conversion was not possible.
double cm;
val.TryConvert(LengthUnit.Centimeter, out cm);
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
  
  Unit.Tablespoon == UnitSystem.Create(us).Parse("tbsp")
  Unit.Tablespoon == UnitSystem.Create(norwegian).Parse("ss")  

  "T" == UnitSystem.GetDefaultAbbreviation(Unit.Tablespoon, us)
  "ss" == UnitSystem.GetDefaultAbbreviation(Unit.Tablespoon, norwegian)
```

What It Is Not
==============

* It is not an equation solver. 
* It does not figure out the units after a calculation.

Work In Progress
================

* Not all conversions are unit tested yet.
* Parsing and getting textual representations are not fully functional.
* Document all the data structures, units and conversions.

Want To Contribute?
===================
* The documentation could need some help.
* Add new units and conversions. Make sure to add unit tests for it.

Just send a pull request and I will try my best to get it in.
