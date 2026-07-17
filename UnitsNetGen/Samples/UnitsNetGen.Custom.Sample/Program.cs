// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen.Generation;

namespace Fictional.Measurements;

[QuantityDefinition("Fictional.Measurements.HowMuch")]
public interface HowMuchDefinition
{
}

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchDefinition>
{
}

internal static class Program
{
    public static void Main()
    {
        HowMuch amount = HowMuch.Parse("10 tons");
        Console.WriteLine($"{amount} = {amount.Lots} lots = {amount.Some} sm");
        Console.WriteLine($"3 magnitudes = {HowMuch.FromMagnitudes(3).Some} sm");
        Console.WriteLine($"Generated in custom namespace: {typeof(HowMuch).FullName}");
    }
}
