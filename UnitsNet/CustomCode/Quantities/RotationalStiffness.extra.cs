// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct RotationalStiffness<T>
    {
        /// <summary>Get <see cref="Torque{T}"/> from <see cref="RotationalStiffness{T}"/> times <see cref="Angle{T}"/>.</summary>
        public static Torque<T> operator *(RotationalStiffness<T> rotationalStiffness, Angle<T> angle )
        {
            return Torque<T>.FromNewtonMeters(rotationalStiffness.NewtonMetersPerRadian * angle.Radians);
        }

        /// <summary>Get <see cref="RotationalStiffnessPerLength{T}"/> from <see cref="RotationalStiffness{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static RotationalStiffnessPerLength<T> operator /(RotationalStiffness<T> rotationalStiffness, Length<T> length )
        {
            return RotationalStiffnessPerLength<T>.FromNewtonMetersPerRadianPerMeter(rotationalStiffness.NewtonMetersPerRadian / length.Meters);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="RotationalStiffness{T}"/> divided by <see cref="RotationalStiffnessPerLength{T}"/>.</summary>
        public static Length<T> operator /(RotationalStiffness<T> rotationalStiffness, RotationalStiffnessPerLength<T> rotationalStiffnessPerLength )
        {
            return Length<T>.FromMeters(rotationalStiffness.NewtonMetersPerRadian / rotationalStiffnessPerLength.NewtonMetersPerRadianPerMeter);
        }
    }
}
