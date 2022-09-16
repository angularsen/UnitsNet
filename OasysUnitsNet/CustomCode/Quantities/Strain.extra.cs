// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace OasysUnitsNet
{
    public partial struct Strain
    {
        /// <summary>Get <see cref="AxialStiffness"/> from <see cref="Force"/> divided by <see cref="Strain"/>.</summary>
        public static AxialStiffness operator /(Force force, Strain strain)
        {
            return AxialStiffness.FromNewtons(force.Newtons / strain.Ratio);
        }
    }
}
