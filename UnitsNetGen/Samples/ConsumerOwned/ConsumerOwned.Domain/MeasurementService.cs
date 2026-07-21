// Licensed under MIT No Attribution, see LICENSE file at the root.

using Fictional.Measurements;
using UnitsNetGen;

namespace ConsumerOwned.Domain;

public static class MeasurementService
{
    public static HowMuchDistance MeasureAllocation()
    {
        HowMuch amount = HowMuch.FromLots(3);
        Length distance = Length.FromMeters(4);
        return amount * distance;
    }
}
