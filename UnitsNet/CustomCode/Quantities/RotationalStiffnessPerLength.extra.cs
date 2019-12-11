// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    public partial struct RotationalStiffnessPerLength
    {
        /// <summary>Get <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessPerLength"/> times <see cref="Length"/>.</summary>
        public static RotationalStiffness operator *(RotationalStiffnessPerLength rotationalStiffness, Length length)
        {
            return RotationalStiffness.FromNewtonMetersPerRadian(rotationalStiffness.NewtonMetersPerRadianPerMeter * length.Meters);
        }
    }
}
