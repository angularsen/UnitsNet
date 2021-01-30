// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct MolarFlow
    {
        /// <summary>Get <see cref="AmountOfSubstance"/> from <see cref="MolarFlow"/> times <see cref="TimeSpan"/>.</summary>
        public static AmountOfSubstance operator *(MolarFlow molarFlow, TimeSpan time)
        {
            return AmountOfSubstance.FromMoles(molarFlow.MolesPerSecond * time.TotalSeconds);
        }

        /// <summary>Get <see cref="AmountOfSubstance"/> from <see cref="TimeSpan"/> times <see cref="MolarFlow"/>.</summary>
        public static AmountOfSubstance operator *(TimeSpan time, MolarFlow molarFlow)
        {
            return AmountOfSubstance.FromMoles(molarFlow.MolesPerSecond * time.TotalSeconds);
        }

        /// <summary>Get <see cref="AmountOfSubstance"/> from <see cref="MolarFlow"/> times <see cref="Duration"/>.</summary>
        public static AmountOfSubstance operator *(MolarFlow molarFlow, Duration duration)
        {
            return AmountOfSubstance.FromMoles(molarFlow.MolesPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="AmountOfSubstance"/> from <see cref="Duration"/> times <see cref="MolarFlow"/>.</summary>
        public static AmountOfSubstance operator *(Duration duration, MolarFlow molarFlow)
        {
            return AmountOfSubstance.FromMoles(molarFlow.MolesPerSecond * duration.Seconds);
        }
    }
}
