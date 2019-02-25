// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct SpecificWeight
    {
        public static Pressure operator *(SpecificWeight specificWeight, Length length)
        {
            return new Pressure(specificWeight.NewtonsPerCubicMeter * length.Meters, UnitsNet.Units.PressureUnit.Pascal);
        }

        public static Acceleration operator /(SpecificWeight specificWeight, Density density)
        {
            return new Acceleration(specificWeight.NewtonsPerCubicMeter / density.KilogramsPerCubicMeter, UnitsNet.Units.AccelerationUnit.MeterPerSecondSquared);
        }

        public static Density operator /(SpecificWeight specific, Acceleration acceleration)
        {
            return new Density(specific.NewtonsPerCubicMeter / acceleration.MetersPerSecondSquared, UnitsNet.Units.DensityUnit.KilogramPerCubicMeter);
        }
    }
}
