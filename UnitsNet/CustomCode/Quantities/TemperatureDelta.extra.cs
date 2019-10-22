// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct TemperatureDelta<T>
    {
        /// <summary>Get <see cref="LapseRate{T}"/> from <see cref="TemperatureDelta{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static LapseRate<T> operator /(TemperatureDelta<T> left, Length<T> right )
        {
            return LapseRate<T>.FromDegreesCelciusPerKilometer(left.DegreesCelsius / right.Kilometers);
        }

        /// <summary>Get <see cref="SpecificEnergy{T}"/> from <see cref="SpecificEntropy{T}"/> times <see cref="TemperatureDelta{T}"/>.</summary>
        public static SpecificEnergy<T> operator *(SpecificEntropy<T> specificEntropy, TemperatureDelta<T> temperatureDelta )
        {
            return SpecificEnergy<T>.FromJoulesPerKilogram(specificEntropy.JoulesPerKilogramKelvin * temperatureDelta.Kelvins);
        }

        /// <summary>Get <see cref="SpecificEnergy{T}"/> from <see cref="TemperatureDelta{T}"/> times <see cref="SpecificEntropy{T}"/>.</summary>
        public static SpecificEnergy<T> operator *(TemperatureDelta<T> temperatureDelta, SpecificEntropy<T> specificEntropy )
        {
            return specificEntropy * temperatureDelta;
        }
    }
}
