// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct LapseRate<T>
    {
        /// <summary>Get <see cref="Length{T}"/> from <see cref="TemperatureDelta{T}"/> divided by <see cref="LapseRate{T}"/>.</summary>
        public static Length<T> operator /(TemperatureDelta<T> left, LapseRate<T> right )
        {
            return Length<T>.FromKilometers(left.Kelvins / right.DegreesCelciusPerKilometer);
        }

        /// <summary>Get <see cref="TemperatureDelta{T}"/> from <see cref="Length{T}"/> times <see cref="LapseRate{T}"/>.</summary>
        public static TemperatureDelta<T> operator *(Length<T> left, LapseRate<T> right ) => right * left;

        /// <summary>Get <see cref="TemperatureDelta{T}"/> from <see cref="LapseRate{T}"/> times <see cref="Length{T}"/>.</summary>
        public static TemperatureDelta<T> operator *(LapseRate<T> left, Length<T> right )
        {
            return TemperatureDelta<T>.FromDegreesCelsius(left.DegreesCelciusPerKilometer * right.Kilometers);
        }
    }
}
