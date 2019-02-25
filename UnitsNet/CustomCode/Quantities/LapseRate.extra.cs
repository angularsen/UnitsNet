// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct LapseRate
    {
        public static Length operator /(TemperatureDelta left, LapseRate right)
        {
            return Length.FromKilometers(left.Kelvins / right.DegreesCelciusPerKilometer);
        }

        public static TemperatureDelta operator *(Length left, LapseRate right) => right * left;

        public static TemperatureDelta operator *(LapseRate left, Length right)
        {
            return TemperatureDelta.FromDegreesCelsius(left.DegreesCelciusPerKilometer * right.Kilometers);
        }
    }
}
