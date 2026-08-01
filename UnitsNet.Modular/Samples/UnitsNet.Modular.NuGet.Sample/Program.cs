// Licensed under MIT No Attribution, see LICENSE file at the root.

using NuGetConsumer.Measurements;
using UnitsNet.Units;
using Catalog = UnitsNet.Modular.BuiltIns;

namespace UnitsNet.Modular.NuGet.Sample;

[QuantitySpec("NuGetConsumer.Measurements.HowMuch")]
internal interface HowMuchSpec;

[UnitsNetModule]
internal interface ConsumerUnits : IInclude<Catalog.LengthSpec>, IInclude<HowMuchSpec>;

internal static class Program
{
    public static void Main()
    {
        Length distance = Length.FromKilometers(2);
        HowMuch amount = HowMuch.Parse("10 lots");

        Console.WriteLine($"{distance} = {distance.ToUnit(LengthUnit.Meter)}");
        Console.WriteLine($"{amount} = {amount.ToUnit(HowMuchUnit.Some)}");
    }
}
