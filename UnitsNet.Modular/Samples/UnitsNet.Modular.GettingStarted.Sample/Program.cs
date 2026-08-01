// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet;
using UnitsNet.Units;

Length route = Length.FromKilometers(1.2);
Length remaining = Length.Parse("500 m");
Length total = route + remaining;
Speed pace = total / Duration.FromMinutes(2);

Console.WriteLine($"Total: {total.ToUnit(LengthUnit.Meter):F0}");
Console.WriteLine($"Pace: {pace:F1}");
