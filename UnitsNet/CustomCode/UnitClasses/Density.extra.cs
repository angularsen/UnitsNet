// Copyright © 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
// https://github.com/anjdreas/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.




namespace UnitsNet
{
#if WINDOWS_UWP
    public sealed partial class Density
#else
    public partial struct Density
#endif
    {

#if WINDOWS_UWP
        internal
#else
        public
#endif
            Density(Molarity molarity, Mass molecularWeight)
                : this()
        {
            _kilogramsPerCubicMeter = molarity.MolesPerCubicMeter * molecularWeight.Kilograms;
        }

        /// <summary>
        ///     Get <see cref="Density"/> from <see cref="Molarity"/>.
        /// </summary>
        /// <param name="molarity"></param>
        /// <param name="molecularWeight"></param>
        public static Density FromMolarity(Molarity molarity, Mass molecularWeight)
        {
            return new Density(molarity, molecularWeight);
        }

        public static Molarity ToMolarity(Density density, Mass molecularWeight)
        {
            return Molarity.FromMolesPerCubicMeter(density.KilogramsPerCubicMeter / molecularWeight.Kilograms);
        }

#if !WINDOWS_UWP
        // Operator overloads not supported in Universal Windows Platform (WinRT Components)

        public static Mass operator *(Density density, Volume volume)
        {
            return Mass.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        public static Mass operator *(Volume volume, Density density)
        {
            return Mass.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        public static DynamicViscosity operator *(Density density, KinematicViscosity kinematicViscosity)
        {
            return DynamicViscosity.FromNewtonSecondsPerMeterSquared(kinematicViscosity.SquareMetersPerSecond * density.KilogramsPerCubicMeter);
        }
#endif

    }
}