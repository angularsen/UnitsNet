// Licensed under MIT No Attribution, see LICENSE file at the root.

using NuGetConsumer.Measurements;
using UnitsNet;
using UnitsNet.Modular;
using UnitsNet.Units;
using Catalog = UnitsNet.Modular.BuiltIns;

Length distance = Length.FromKilometers(2);
HowMuch amount = HowMuch.Parse("10 lots");

Console.WriteLine($"{distance} = {distance.ToUnit(LengthUnit.Meter)}");
Console.WriteLine($"{amount} = {amount.ToUnit(HowMuchUnit.Some)}");

[QuantitySpec("NuGetConsumer.Measurements.HowMuch")]
internal interface HowMuchSpec;

[UnitsNetModule]
internal interface ConsumerUnits : IInclude<Catalog.LengthSpec>, IInclude<HowMuchSpec>;
