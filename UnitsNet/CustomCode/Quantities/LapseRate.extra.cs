// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct LapseRate
    {
        /// <summary>Get <see cref="Length"/> from <see cref="TemperatureDelta"/> divided by <see cref="LapseRate"/>.</summary>
        public static Length operator /(TemperatureDelta left, LapseRate right)
        {
            return Length.FromKilometers(left.Kelvins / right.DegreesCelciusPerKilometer);
        }

        /// <summary>Get <see cref="TemperatureDelta"/> from <see cref="Length"/> times <see cref="LapseRate"/>.</summary>
        public static TemperatureDelta operator *(Length left, LapseRate right) => right * left;

        /// <summary>Get <see cref="TemperatureDelta"/> from <see cref="LapseRate"/> times <see cref="Length"/>.</summary>
        public static TemperatureDelta operator *(LapseRate left, Length right)
        {
            return TemperatureDelta.FromDegreesCelsius(left.DegreesCelciusPerKilometer * right.Kilometers);
        }
    }
}
