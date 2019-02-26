// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct SpecificWeight
    {
        /// <summary>Get <see cref="Pressure"/> from <see cref="SpecificWeight"/> times <see cref="Length"/>.</summary>
        public static Pressure operator *(SpecificWeight specificWeight, Length length)
        {
            return new Pressure(specificWeight.NewtonsPerCubicMeter * length.Meters, UnitsNet.Units.PressureUnit.Pascal);
        }

        /// <summary>Get <see cref="Acceleration"/> from <see cref="SpecificWeight"/> divided by <see cref="Density"/>.</summary>
        public static Acceleration operator /(SpecificWeight specificWeight, Density density)
        {
            return new Acceleration(specificWeight.NewtonsPerCubicMeter / density.KilogramsPerCubicMeter, UnitsNet.Units.AccelerationUnit.MeterPerSecondSquared);
        }

        /// <summary>Get <see cref="Density"/> from <see cref="SpecificWeight"/> divided by <see cref="Acceleration"/>.</summary>
        public static Density operator /(SpecificWeight specific, Acceleration acceleration)
        {
            return new Density(specific.NewtonsPerCubicMeter / acceleration.MetersPerSecondSquared, UnitsNet.Units.DensityUnit.KilogramPerCubicMeter);
        }
    }
}
