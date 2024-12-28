// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet;

public partial struct RadiationEquivalentDoseRate
{
    /// <summary>Get <see cref="RadiationEquivalentDose"/> from <see cref="RadiationEquivalentDoseRate"/> times <see cref="TimeSpan"/>.</summary>
    public static RadiationEquivalentDose operator *(RadiationEquivalentDoseRate rate, TimeSpan timeSpan)
    {
        return RadiationEquivalentDose.FromSieverts(rate.SievertsPerHour * timeSpan.TotalHours);
    }

    /// <summary>Get <see cref="RadiationEquivalentDose"/> from <see cref="RadiationEquivalentDoseRate"/> times <see cref="Duration"/>.</summary>
    public static RadiationEquivalentDose operator *(RadiationEquivalentDoseRate rate, Duration duration)
    {
        return RadiationEquivalentDose.FromSieverts(rate.SievertsPerHour * duration.Hours);
    }
}
