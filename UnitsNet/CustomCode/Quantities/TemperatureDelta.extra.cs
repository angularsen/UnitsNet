// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct TemperatureDelta
    {
        /// <summary>Get <see cref="TemperatureGradient"/> from <see cref="TemperatureDelta"/> divided by <see cref="Length"/>.</summary>
        public static TemperatureGradient operator /(TemperatureDelta left, Length right)
        {
            return TemperatureGradient.FromKelvinsPerMeter(left.Kelvins / right.Meters);
        }

        /// <summary>Get <see cref="SpecificEnergy"/> from <see cref="SpecificEntropy"/> times <see cref="TemperatureDelta"/>.</summary>
        public static SpecificEnergy operator *(SpecificEntropy specificEntropy, TemperatureDelta temperatureDelta)
        {
            return SpecificEnergy.FromJoulesPerKilogram(specificEntropy.JoulesPerKilogramKelvin * temperatureDelta.Kelvins);
        }

        /// <summary>Get <see cref="SpecificEnergy"/> from <see cref="TemperatureDelta"/> times <see cref="SpecificEntropy"/>.</summary>
        public static SpecificEnergy operator *(TemperatureDelta temperatureDelta, SpecificEntropy specificEntropy)
        {
            return specificEntropy * temperatureDelta;
        }

        /// <summary>Get <see cref="Energy"/> from <see cref="Entropy"/> times <see cref="TemperatureDelta"/>.</summary>
        public static Energy operator *(Entropy entropy, TemperatureDelta temperatureDelta)
        {
            return Energy.FromJoules(entropy.JoulesPerKelvin * temperatureDelta.Kelvins);
        }
        
        /// <summary>Get <see cref="Energy"/> from <see cref="TemperatureDelta"/> times <see cref="Entropy"/>.</summary>
        public static Energy operator *(TemperatureDelta temperatureDelta, Entropy entropy)
        {
            return Energy.FromJoules(entropy.JoulesPerKelvin * temperatureDelta.Kelvins);
        }

        /// <summary>Get a scalar from a <see cref="TemperatureDelta"/> multiplied by a <see cref="CoefficientOfThermalExpansion"/>.</summary>
        public static double operator *(TemperatureDelta temperatureDelta, CoefficientOfThermalExpansion cte)
        {
            return temperatureDelta.Kelvins * cte.PerKelvin;
        }

        /// <summary> Get <see cref="TemperatureChangeRate"/> from <see cref="TemperatureDelta"/> divided by <see cref="TimeSpan"/>.</summary>
        public static TemperatureChangeRate operator /(TemperatureDelta temperatureDelta, TimeSpan timespan)
        {
            return TemperatureChangeRate.FromDegreesCelsiusPerSecond(temperatureDelta.Kelvins / timespan.TotalSeconds);
        }

        /// <summary> Get <see cref="TemperatureChangeRate"/> from <see cref="TemperatureDelta"/> divided by <see cref="Duration"/>.</summary>
        public static TemperatureChangeRate operator /(TemperatureDelta temperatureDelta, Duration duration)
        {
            return TemperatureChangeRate.FromDegreesCelsiusPerSecond(temperatureDelta.Kelvins / duration.Seconds);
        }
    }
}
