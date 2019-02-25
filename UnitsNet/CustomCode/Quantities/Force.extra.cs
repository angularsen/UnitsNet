// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Force
    {
        public static Force FromPressureByArea(Pressure p, Area area)
        {
            double newtons = p.Pascals * area.SquareMeters;
            return new Force(newtons, ForceUnit.Newton);
        }

        public static Force FromMassByAcceleration(Mass mass, Acceleration acceleration)
        {
            return new Force(mass.Kilograms * acceleration.MetersPerSecondSquared, ForceUnit.Newton);
        }

        public static Power operator *(Force force, Speed speed)
        {
            return Power.FromWatts(force.Newtons * speed.MetersPerSecond);
        }

        public static Power operator *(Speed speed, Force force)
        {
            return Power.FromWatts(force.Newtons * speed.MetersPerSecond);
        }

        public static Acceleration operator /(Force force, Mass mass)
        {
            return Acceleration.FromMetersPerSecondSquared(force.Newtons / mass.Kilograms);
        }

        public static Mass operator /(Force force, Acceleration mass)
        {
            return Mass.FromKilograms(force.Newtons / mass.MetersPerSecondSquared);
        }

        public static Pressure operator /(Force force, Area area)
        {
            return Pressure.FromPascals(force.Newtons / area.SquareMeters);
        }

        public static ForcePerLength operator /(Force force, Length length)
        {
            return ForcePerLength.FromNewtonsPerMeter(force.Newtons / length.Meters);
        }
    }
}
