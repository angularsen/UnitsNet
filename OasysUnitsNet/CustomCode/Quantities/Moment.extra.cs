// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace OasysUnitsNet
{
    public partial struct Moment
    {
        /// <summary>Get <see cref="Force"/> from <see cref="Moment"/> times <see cref="Length"/>.</summary>
        public static Force operator /(Moment moment, Length length)
        {
            return Force.FromNewtons(moment.NewtonMeters / length.Meters);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Moment"/> times <see cref="Force"/>.</summary>
        public static Length operator /(Moment moment, Force force)
        {
            return Length.FromMeters(moment.NewtonMeters / force.Newtons);
        }

        /// <summary>Get <see cref="BendingStiffness"/> from <see cref="Moment"/> divided by <see cref="Curvature"/>.</summary>
        public static BendingStiffness operator /(Moment moment, Curvature curvature)
        {
            return BendingStiffness.FromNewtonSquareMeters(moment.NewtonMeters / curvature.PerMeters);
        }

        /// <summary>Get <see cref="Curvature"/> from <see cref="Moment"/> divided by <see cref="BendingStiffness"/>.</summary>
        public static Curvature operator /(Moment moment, BendingStiffness bendingStiffness)
        {
            return Curvature.FromPerMeters(moment.NewtonMeters / bendingStiffness.NewtonSquareMeters);
        }
    }
}
