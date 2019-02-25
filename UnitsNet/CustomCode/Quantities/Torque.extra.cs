// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Torque
    {
        public static Force operator /(Torque torque, Length length)
        {
            return Force.FromNewtons(torque.NewtonMeters / length.Meters);
        }

        public static Length operator /(Torque torque, Force force)
        {
            return Length.FromMeters(torque.NewtonMeters / force.Newtons);
        }

        public static RotationalStiffness operator /(Torque torque, Angle angle)
        {
            return RotationalStiffness.FromNewtonMetersPerRadian(torque.NewtonMeters / angle.Radians);
        }

        public static Angle operator /(Torque torque, RotationalStiffness rotationalStiffness)
        {
            return Angle.FromRadians(torque.NewtonMeters / rotationalStiffness.NewtonMetersPerRadian);
        }
    }
}
