using System;

namespace UnitsNet
{
    public partial struct MolarFlow
    {
        /// <summary>Get <see cref="AmountOfSubstance"/> from <see cref="MolarFlow"/> times <see cref="TimeSpan"/>.</summary>
        public static AmountOfSubstance operator *(MolarFlow molarFlow, TimeSpan timeSpan)
        {
            return AmountOfSubstance.FromKilomoles(molarFlow.KilomolesPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="AmountOfSubstance"/> from <see cref="MolarFlow"/> times <see cref="Duration"/>.</summary>
        public static AmountOfSubstance operator *(MolarFlow molarFlow, Duration duration)
        {
            return AmountOfSubstance.FromKilomoles(molarFlow.KilomolesPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="MolarFlow"/> times <see cref="MolarMass"/>.</summary>
        public static MassFlow operator *(MolarFlow molarFlow, MolarMass molecularWeight)
        {
            return MassFlow.FromKilogramsPerSecond(molarFlow.KilomolesPerSecond * molecularWeight.KilogramsPerKilomole);
        }

    }
}
