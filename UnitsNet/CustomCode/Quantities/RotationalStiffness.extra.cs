// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct RotationalStiffness
    {
        /// <summary>Get <see cref="Torque"/> from <see cref="RotationalStiffness"/> times <see cref="Angle"/>.</summary>
        public static Torque operator *(RotationalStiffness rotationalStiffness, Angle angle)
        {
            return Torque.FromNewtonMeters(rotationalStiffness.NewtonMetersPerRadian * angle.Radians);
        }

        /// <summary>Get <see cref="RotationalStiffnessPerLength"/> from <see cref="RotationalStiffness"/> divided by <see cref="Length"/>.</summary>
        public static RotationalStiffnessPerLength operator /(RotationalStiffness rotationalStiffness, Length length)
        {
            return RotationalStiffnessPerLength.FromNewtonMetersPerRadianPerMeter(rotationalStiffness.NewtonMetersPerRadian / length.Meters);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="RotationalStiffness"/> divided by <see cref="RotationalStiffnessPerLength"/>.</summary>
        public static Length operator /(RotationalStiffness rotationalStiffness, RotationalStiffnessPerLength rotationalStiffnessPerLength)
        {
            return Length.FromMeters(rotationalStiffness.NewtonMetersPerRadian / rotationalStiffnessPerLength.NewtonMetersPerRadianPerMeter);
        }
    }
}
