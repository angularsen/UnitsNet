// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Power
    {
        /// <summary>
        ///     Gets a <see cref="PowerRatio" /> from this <see cref="Power" /> relative to one watt.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a power to a power ratio (relative to 1 watt).
        ///     <example>
        ///         <c>var powerRatio = power.ToPowerRatio();</c>
        ///     </example>
        /// </remarks>
        public PowerRatio ToPowerRatio()
        {
            return PowerRatio.FromPower(this);
        }

        public static Energy operator *(Power power, TimeSpan time)
        {
            return Energy.FromJoules(power.Watts * time.TotalSeconds);
        }

        public static Energy operator *(TimeSpan time, Power power)
        {
            return Energy.FromJoules(power.Watts * time.TotalSeconds);
        }

        public static Energy operator *(Power power, Duration duration)
        {
            return Energy.FromJoules(power.Watts * duration.Seconds);
        }

        public static Energy operator *(Duration duration, Power power)
        {
            return Energy.FromJoules(power.Watts * duration.Seconds);
        }

        public static Force operator /(Power power, Speed speed)
        {
            return Force.FromNewtons(power.Watts / speed.MetersPerSecond);
        }

        public static Torque operator /(Power power, RotationalSpeed rotationalSpeed)
        {
            return Torque.FromNewtonMeters(power.Watts / rotationalSpeed.RadiansPerSecond);
        }

        public static RotationalSpeed operator /(Power power, Torque torque)
        {
            return RotationalSpeed.FromRadiansPerSecond(power.Watts / torque.NewtonMeters);
        }

        public static MassFlow operator *(Power power, BrakeSpecificFuelConsumption bsfc)
        {
            return MassFlow.FromKilogramsPerSecond(bsfc.KilogramsPerJoule * power.Watts);
        }

        public static SpecificEnergy operator /(Power power, MassFlow massFlow)
        {
            return SpecificEnergy.FromJoulesPerKilogram(power.Watts / massFlow.KilogramsPerSecond);
        }

        public static MassFlow operator /(Power power, SpecificEnergy specificEnergy)
        {
            return MassFlow.FromKilogramsPerSecond(power.Watts / specificEnergy.JoulesPerKilogram);
        }

        public static HeatFlux operator /(Power power, Area area)
        {
            return HeatFlux.FromWattsPerSquareMeter(power.Watts / area.SquareMeters);
        }

        public static Area operator /(Power power, HeatFlux heatFlux)
        {
            return Area.FromSquareMeters( power.Watts / heatFlux.WattsPerSquareMeter );
        }
    }
}
