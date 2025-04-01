using UnitsNetSrcGen;

var l = new Length {Value = 10, Unit = LengthUnit.Centimeter};
var m = new Mass { Value = 20, Unit = MassUnit.Kilogram };

Console.WriteLine($"Length: {l.Value} {l.Unit}");
Console.WriteLine($"Mass: {m.Value} {m.Unit}");
