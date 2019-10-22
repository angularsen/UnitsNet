// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Force<T>
    {
        /// <summary>Get <see cref="Force{T}"/> from <see cref="Pressure{T}"/> divided by <see cref="Area{T}"/>.</summary>
        public static Force<T> FromPressureByArea(Pressure<T> p, Area<T> area )
        {
            double newtons = p.Pascals * area.SquareMeters;
            return new Force<T>( newtons, ForceUnit.Newton);
        }

        /// <summary>Get <see cref="Force{T}"/> from <see cref="Mass{T}"/> times <see cref="Acceleration{T}"/>.</summary>
        public static Force<T> FromMassByAcceleration(Mass<T> mass, Acceleration<T> acceleration )
        {
            return new Force<T>( mass.Kilograms * acceleration.MetersPerSecondSquared, ForceUnit.Newton);
        }

        /// <summary>Get <see cref="Power{T}"/> from <see cref="Force{T}"/> times <see cref="Speed{T}"/>.</summary>
        public static Power<T> operator *(Force<T> force, Speed<T> speed )
        {
            return Power<T>.FromWatts(force.Newtons * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Power{T}"/> from <see cref="Speed{T}"/> times <see cref="Force{T}"/>.</summary>
        public static Power<T> operator *(Speed<T> speed, Force<T> force )
        {
            return Power<T>.FromWatts(force.Newtons * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Acceleration{T}"/> from <see cref="Force{T}"/> divided by <see cref="Mass{T}"/>.</summary>
        public static Acceleration<T> operator /(Force<T> force, Mass<T> mass )
        {
            return Acceleration<T>.FromMetersPerSecondSquared(force.Newtons / mass.Kilograms);
        }

        /// <summary>Get <see cref="Mass{T}"/> from <see cref="Force{T}"/> divided by <see cref="Acceleration{T}"/>.</summary>
        public static Mass<T> operator /(Force<T> force, Acceleration<T> acceleration )
        {
            return Mass<T>.FromKilograms(force.Newtons / acceleration.MetersPerSecondSquared);
        }

        /// <summary>Get <see cref="Pressure{T}"/> from <see cref="Force{T}"/> divided by <see cref="Area{T}"/>.</summary>
        public static Pressure<T> operator /(Force<T> force, Area<T> area )
        {
            return Pressure<T>.FromPascals(force.Newtons / area.SquareMeters);
        }

        /// <summary>Get <see cref="ForcePerLength{T}"/> from <see cref="Force{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static ForcePerLength<T> operator /(Force<T> force, Length<T> length )
        {
            return ForcePerLength<T>.FromNewtonsPerMeter(force.Newtons / length.Meters);
        }
    }
}
