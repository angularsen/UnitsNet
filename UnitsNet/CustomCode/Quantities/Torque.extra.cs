// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Torque<T>
    {
        /// <summary>Get <see cref="Force{T}"/> from <see cref="Torque{T}"/> times <see cref="Length{T}"/>.</summary>
        public static Force<T> operator /(Torque<T> torque, Length<T> length )
        {
            return Force<T>.FromNewtons(torque.NewtonMeters / length.Meters);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="Torque{T}"/> times <see cref="Force{T}"/>.</summary>
        public static Length<T> operator /(Torque<T> torque, Force<T> force )
        {
            return Length<T>.FromMeters(torque.NewtonMeters / force.Newtons);
        }

        /// <summary>Get <see cref="RotationalStiffness{T}"/> from <see cref="Torque{T}"/> times <see cref="Angle{T}"/>.</summary>
        public static RotationalStiffness<T> operator /(Torque<T> torque, Angle<T> angle )
        {
            return RotationalStiffness<T>.FromNewtonMetersPerRadian(torque.NewtonMeters / angle.Radians);
        }

        /// <summary>Get <see cref="Angle{T}"/> from <see cref="Torque{T}"/> times <see cref="RotationalStiffness{T}"/>.</summary>
        public static Angle<T> operator /(Torque<T> torque, RotationalStiffness<T> rotationalStiffness )
        {
            return Angle<T>.FromRadians(torque.NewtonMeters / rotationalStiffness.NewtonMetersPerRadian);
        }
    }
}
