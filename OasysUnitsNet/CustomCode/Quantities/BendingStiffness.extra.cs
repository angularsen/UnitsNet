// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace OasysUnitsNet
{
    public partial struct BendingStiffness
    {
        /// <summary>Get <see cref="Moment"/> from <see cref="BendingStiffness"/> times <see cref="Curvature"/>.</summary>
        public static Moment operator *(BendingStiffness bendingStiffness, Curvature curvature)
        {
            return Moment.FromNewtonMeters(bendingStiffness.NewtonSquareMeters * curvature.PerMeters);
        }
    }
}

