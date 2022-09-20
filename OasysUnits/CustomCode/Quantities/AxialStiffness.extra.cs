// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace OasysUnits
{
    public partial struct AxialStiffness
    {
        /// <summary>Get <see cref="Force"/> from <see cref="AxialStiffness"/> times <see cref="Strain"/>.</summary>
        public static Force operator *(AxialStiffness axialStiffness, Strain strain)
        {
            return Force.FromNewtons(axialStiffness.Newtons * strain.Ratio);
        }

        /// <summary>Get <see cref="Strain"/> from <see cref="Force"/> divided by <see cref="AxialStiffness"/>.</summary>
        public static Strain operator /(Force force, AxialStiffness axialStiffness)
        {
            return Strain.FromRatio(force.Newtons / axialStiffness.Newtons);
        }
    }
}
