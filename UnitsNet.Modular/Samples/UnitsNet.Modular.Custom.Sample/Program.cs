// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet.Modular;

namespace Fictional.Measurements;

[QuantitySpec("Fictional.Measurements.HowMuch")]
public interface HowMuchSpec
{
}

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchSpec>
{
}

internal static class Program
{
    public static void Main()
    {
        HowMuch amount = HowMuch.Parse("10 tons");
        HowMuch magnitude = HowMuch.FromMagnitudes(3);

        Console.WriteLine($"{amount} = {amount.ToUnit(HowMuchUnit.Lots)} = {amount.ToUnit(HowMuchUnit.Some)}");
        Console.WriteLine($"{magnitude} = {magnitude.ToUnit(HowMuchUnit.Some)}");
        Console.WriteLine($"Generated in custom namespace: {typeof(HowMuch).FullName}");
    }
}
