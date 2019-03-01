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

        /// <summary>Get <see cref="Energy"/> from <see cref="Power"/> times <see cref="TimeSpan"/>.</summary>
        public static Energy operator *(Power power, TimeSpan time)
        {
            return Energy.FromJoules(power.Watts * time.TotalSeconds);
        }

        /// <summary>Get <see cref="Energy"/> from <see cref="TimeSpan"/> times <see cref="Power"/>.</summary>
        public static Energy operator *(TimeSpan time, Power power)
        {
            return Energy.FromJoules(power.Watts * time.TotalSeconds);
        }

        /// <summary>Get <see cref="Energy"/> from <see cref="Power"/> times <see cref="Duration"/>.</summary>
        public static Energy operator *(Power power, Duration duration)
        {
            return Energy.FromJoules(power.Watts * duration.Seconds);
        }

        /// <summary>Get <see cref="Energy"/> from <see cref="Duration"/> times <see cref="Power"/>.</summary>
        public static Energy operator *(Duration duration, Power power)
        {
            return Energy.FromJoules(power.Watts * duration.Seconds);
        }

        /// <summary>Get <see cref="Force"/> from <see cref="Power"/> divided by <see cref="Speed"/>.</summary>
        public static Force operator /(Power power, Speed speed)
        {
            return Force.FromNewtons(power.Watts / speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Torque"/> from <see cref="Power"/> divided by <see cref="RotationalSpeed"/>.</summary>
        public static Torque operator /(Power power, RotationalSpeed rotationalSpeed)
        {
            return Torque.FromNewtonMeters(power.Watts / rotationalSpeed.RadiansPerSecond);
        }

        /// <summary>Get <see cref="RotationalSpeed"/> from <see cref="Power"/> divided by <see cref="Torque"/>.</summary>
        public static RotationalSpeed operator /(Power power, Torque torque)
        {
            return RotationalSpeed.FromRadiansPerSecond(power.Watts / torque.NewtonMeters);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="Power"/> times <see cref="BrakeSpecificFuelConsumption"/>.</summary>
        public static MassFlow operator *(Power power, BrakeSpecificFuelConsumption bsfc)
        {
            return MassFlow.FromKilogramsPerSecond(bsfc.KilogramsPerJoule * power.Watts);
        }

        /// <summary>Get <see cref="SpecificEnergy"/> from <see cref="Power"/> divided by <see cref="MassFlow"/>.</summary>
        public static SpecificEnergy operator /(Power power, MassFlow massFlow)
        {
            return SpecificEnergy.FromJoulesPerKilogram(power.Watts / massFlow.KilogramsPerSecond);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="Power"/> divided by <see cref="SpecificEnergy"/>.</summary>
        public static MassFlow operator /(Power power, SpecificEnergy specificEnergy)
        {
            return MassFlow.FromKilogramsPerSecond(power.Watts / specificEnergy.JoulesPerKilogram);
        }

        /// <summary>Get <see cref="HeatFlux"/> from <see cref="Power"/> divided by <see cref="Area"/>.</summary>
        public static HeatFlux operator /(Power power, Area area)
        {
            return HeatFlux.FromWattsPerSquareMeter(power.Watts / area.SquareMeters);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="Power"/> divided by <see cref="HeatFlux"/>.</summary>
        public static Area operator /(Power power, HeatFlux heatFlux)
        {
            return Area.FromSquareMeters( power.Watts / heatFlux.WattsPerSquareMeter );
        }
    }
}
