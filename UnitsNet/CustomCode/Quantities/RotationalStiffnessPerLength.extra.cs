// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    public partial struct RotationalStiffnessPerLength<T>
    {
        /// <summary>Get <see cref="RotationalStiffness{T}"/> from <see cref="RotationalStiffnessPerLength{T}"/> times <see cref="Length{T}"/>.</summary>
        public static RotationalStiffness<T> operator *(RotationalStiffnessPerLength<T> rotationalStiffness, Length<T> length )
        {
            return RotationalStiffness<T>.FromNewtonMetersPerRadian(rotationalStiffness.NewtonMetersPerRadianPerMeter * length.Meters);
        }
    }
}
