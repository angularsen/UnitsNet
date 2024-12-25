// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet;

public partial struct RadiationEquivalentDose
{
    /// <summary>Get <see cref="RadiationEquivalentDoseRate"/> from <see cref="RadiationEquivalentDose"/> divided by <see cref="TimeSpan"/>.</summary>
    public static RadiationEquivalentDoseRate operator /(RadiationEquivalentDose dose, TimeSpan timeSpan)
    {
        return RadiationEquivalentDoseRate.FromSievertsPerHour(dose.Sieverts / timeSpan.TotalHours);
    }

    /// <summary>Get <see cref="RadiationEquivalentDoseRate"/> from <see cref="RadiationEquivalentDose"/> divided by <see cref="Duration"/>.</summary>
    public static RadiationEquivalentDoseRate operator /(RadiationEquivalentDose dose, Duration duration)
    {
        return RadiationEquivalentDoseRate.FromSievertsPerHour(dose.Sieverts / duration.Hours);
    }
}
