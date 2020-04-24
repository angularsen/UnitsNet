// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Force
    {
        /// <summary>Get <see cref="Force"/> from <see cref="Pressure"/> divided by <see cref="Area"/>.</summary>
        public static Force FromPressureByArea(Pressure p, Area area)
        {
            double newtons = p.Pascals * area.SquareMeters;
            return new Force(newtons, ForceUnit.Newton);
        }

        /// <summary>Get <see cref="Force"/> from <see cref="Mass"/> times <see cref="Acceleration"/>.</summary>
        public static Force FromMassByAcceleration(Mass mass, Acceleration acceleration)
        {
            return new Force(mass.Kilograms * acceleration.MetersPerSecondSquared, ForceUnit.Newton);
        }

        /// <summary>Get <see cref="Power"/> from <see cref="Force"/> times <see cref="Speed"/>.</summary>
        public static Power operator *(Force force, Speed speed)
        {
            return Power.FromWatts(force.Newtons * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Power"/> from <see cref="Speed"/> times <see cref="Force"/>.</summary>
        public static Power operator *(Speed speed, Force force)
        {
            return Power.FromWatts(force.Newtons * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Acceleration"/> from <see cref="Force"/> divided by <see cref="Mass"/>.</summary>
        public static Acceleration operator /(Force force, Mass mass)
        {
            return Acceleration.FromMetersPerSecondSquared(force.Newtons / mass.Kilograms);
        }

        /// <summary>Get <see cref="Mass"/> from <see cref="Force"/> divided by <see cref="Acceleration"/>.</summary>
        public static Mass operator /(Force force, Acceleration acceleration)
        {
            return Mass.FromKilograms(force.Newtons / acceleration.MetersPerSecondSquared);
        }

        /// <summary>Get <see cref="Pressure"/> from <see cref="Force"/> divided by <see cref="Area"/>.</summary>
        public static Pressure operator /(Force force, Area area)
        {
            return Pressure.FromPascals(force.Newtons / area.SquareMeters);
        }

        /// <summary>Get <see cref="ForcePerLength"/> from <see cref="Force"/> divided by <see cref="Length"/>.</summary>
        public static ForcePerLength operator /(Force force, Length length)
        {
            return ForcePerLength.FromNewtonsPerMeter(force.Newtons / length.Meters);
        }
    }
}
