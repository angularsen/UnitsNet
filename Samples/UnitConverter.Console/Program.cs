using UnitsNet;
using static System.Console;
using static UnitsNet.Units.LengthUnit;

WriteLine(Length.FromMeters(1).ToUnit(Centimeter)); // 100 cm
WriteLine(Length.Parse("100 cm").ToUnit(Meter)); // 1 m
