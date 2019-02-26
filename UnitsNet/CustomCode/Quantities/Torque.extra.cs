// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Torque
    {
        /// <summary>Get <see cref="Force"/> from <see cref="Torque"/> times <see cref="Length"/>.</summary>
        public static Force operator /(Torque torque, Length length)
        {
            return Force.FromNewtons(torque.NewtonMeters / length.Meters);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Torque"/> times <see cref="Force"/>.</summary>
        public static Length operator /(Torque torque, Force force)
        {
            return Length.FromMeters(torque.NewtonMeters / force.Newtons);
        }

        /// <summary>Get <see cref="RotationalStiffness"/> from <see cref="Torque"/> times <see cref="Angle"/>.</summary>
        public static RotationalStiffness operator /(Torque torque, Angle angle)
        {
            return RotationalStiffness.FromNewtonMetersPerRadian(torque.NewtonMeters / angle.Radians);
        }

        /// <summary>Get <see cref="Angle"/> from <see cref="Torque"/> times <see cref="RotationalStiffness"/>.</summary>
        public static Angle operator /(Torque torque, RotationalStiffness rotationalStiffness)
        {
            return Angle.FromRadians(torque.NewtonMeters / rotationalStiffness.NewtonMetersPerRadian);
        }
    }
}
