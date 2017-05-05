using System;

namespace UnitsNet
{
#if WINDOWS_UWP
    public sealed partial class Molarity
#else
    public partial struct Molarity
#endif
    {
#if WINDOWS_UWP
        internal
#else
        public
#endif
            Molarity(Density density, Mass molecularWeight)
            : this()
        {
            _molesPerCubicMeter = density.KilogramsPerCubicMeter / molecularWeight.Kilograms;
        }

        /// <summary>
        ///     Get <see cref="Molarity"/> from <see cref="Density"/>.
        /// </summary>
        /// <param name="density"></param>
        /// <param name="molecularWeight"></param>
        public static Molarity FromDensity(Density density, Mass molecularWeight)
        {
            return new Molarity(density, molecularWeight);
        }

        /// <summary>
        ///     Get <see cref="Density"/> from <see cref="Molarity"/>.
        /// </summary>
        /// <param name="molarity"></param>
        /// <param name="molecularWeight"></param>
        /// <returns></returns>
        public static Density ToDensity(Molarity molarity, Mass molecularWeight)
        {
            return Density.FromKilogramsPerCubicMeter(molarity.MolesPerCubicMeter * molecularWeight.Kilograms);
        }
    }
}
