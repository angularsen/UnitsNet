// Licensed under MIT No Attribution, see LICENSE file at the root.

using Fictional.Measurements;
using UnitsNet;

namespace SharedUnitsLibrarySample.Domain;

public static class MeasurementService
{
    public static HowMuchDistance MeasureAllocation()
    {
        HowMuch amount = HowMuch.FromLots(3);
        Length distance = Length.FromMeters(4);
        return amount * distance;
    }
}
