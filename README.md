Units.NET
========

Data structures and methods that make life working with units just a little bit better.

What Is It?
===========

Everyone has written their share of trivial conversions between meters and centimeters, or less trivial conversions like Pascal and PSI where most mortals need a quick Google to find that magic constant.

Stop littering your code with unnecessary calculations. Units.NET gives you all the common units and conversions. It is light-weight, unit tested and open source.


Features
========

* Structs for most standard units of measurement, such as Length, Mass, Force and Pressure. See full list [here](http://TODO "TODO").
* Has most standard units in the metric and imperial systems. See full list [here](http://TODO "TODO").

Convert Between Units of Measurement
------------------------------------
```C#
// Convert between units of measurement.
Length.FromMeters(1).Centimeters == 100

// Convert between metric and imperial units.
Length.FromMeters(1).Yards == 1.09361
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
* It does not dynamically figure out the units after a calculation.

Work In Progress
================

* Write tests for all conversions.
* Example code.

Want To Contribute?
===================
I will try my best to consider all pull requests.
