// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Power<T>
    {
        /// <summary>
        ///     Gets a <see cref="PowerRatio{T}" /> from this <see cref="Power{T}" /> relative to one watt.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a power to a power ratio (relative to 1 watt).
        ///     <example>
        ///         <c>var powerRatio = power.ToPowerRatio();</c>
        ///     </example>
        /// </remarks>
        public PowerRatio<T> ToPowerRatio()
        {
            return PowerRatio<T>.FromPower(this);
        }

        /// <summary>Get <see cref="Energy{T}"/> from <see cref="Power{T}"/> times <see cref="TimeSpan"/>.</summary>
        public static Energy<T> operator *(Power<T> power, TimeSpan time)
        {
            return Energy<T>.FromJoules(power.Watts * time.TotalSeconds);
        }

        /// <summary>Get <see cref="Energy{T}"/> from <see cref="TimeSpan"/> times <see cref="Power{T}"/>.</summary>
        public static Energy<T> operator *(TimeSpan time, Power<T> power )
        {
            return Energy<T>.FromJoules(power.Watts * time.TotalSeconds);
        }

        /// <summary>Get <see cref="Energy{T}"/> from <see cref="Power{T}"/> times <see cref="Duration"/>.</summary>
        public static Energy<T> operator *(Power<T> power, Duration<T> duration )
        {
            return Energy<T>.FromJoules(power.Watts * duration.Seconds);
        }

        /// <summary>Get <see cref="Energy{T}"/> from <see cref="Duration{T}"/> times <see cref="Power{T}"/>.</summary>
        public static Energy<T> operator *(Duration<T> duration, Power<T> power )
        {
            return Energy<T>.FromJoules(power.Watts * duration.Seconds);
        }

        /// <summary>Get <see cref="Force{T}"/> from <see cref="Power{T}"/> divided by <see cref="Speed{T}"/>.</summary>
        public static Force<T> operator /(Power<T> power, Speed<T> speed )
        {
            return Force<T>.FromNewtons(power.Watts / speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Torque{T}"/> from <see cref="Power{T}"/> divided by <see cref="RotationalSpeed{T}"/>.</summary>
        public static Torque<T> operator /(Power<T> power, RotationalSpeed<T> rotationalSpeed )
        {
            return Torque<T>.FromNewtonMeters(power.Watts / rotationalSpeed.RadiansPerSecond);
        }

        /// <summary>Get <see cref="RotationalSpeed{T}"/> from <see cref="Power{T}"/> divided by <see cref="Torque{T}"/>.</summary>
        public static RotationalSpeed<T> operator /(Power<T> power, Torque<T> torque )
        {
            return RotationalSpeed<T>.FromRadiansPerSecond(power.Watts / torque.NewtonMeters);
        }

        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="Power{T}"/> times <see cref="BrakeSpecificFuelConsumption{T}"/>.</summary>
        public static MassFlow<T> operator *(Power<T> power, BrakeSpecificFuelConsumption<T> bsfc )
        {
            return MassFlow<T>.FromKilogramsPerSecond(bsfc.KilogramsPerJoule * power.Watts);
        }

        /// <summary>Get <see cref="SpecificEnergy{T}"/> from <see cref="Power{T}"/> divided by <see cref="MassFlow{T}"/>.</summary>
        public static SpecificEnergy<T> operator /(Power<T> power, MassFlow<T> massFlow )
        {
            return SpecificEnergy<T>.FromJoulesPerKilogram(power.Watts / massFlow.KilogramsPerSecond);
        }

        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="Power{T}"/> divided by <see cref="SpecificEnergy{T}"/>.</summary>
        public static MassFlow<T> operator /(Power<T> power, SpecificEnergy<T> specificEnergy )
        {
            return MassFlow<T>.FromKilogramsPerSecond(power.Watts / specificEnergy.JoulesPerKilogram);
        }

        /// <summary>Get <see cref="HeatFlux{T}"/> from <see cref="Power{T}"/> divided by <see cref="Area{T}"/>.</summary>
        public static HeatFlux<T> operator /(Power<T> power, Area<T> area )
        {
            return HeatFlux<T>.FromWattsPerSquareMeter(power.Watts / area.SquareMeters);
        }

        /// <summary>Get <see cref="Area{T}"/> from <see cref="Power{T}"/> divided by <see cref="HeatFlux{T}"/>.</summary>
        public static Area<T> operator /(Power<T> power, HeatFlux<T> heatFlux )
        {
            return Area<T>.FromSquareMeters( power.Watts / heatFlux.WattsPerSquareMeter );
        }
    }
}
