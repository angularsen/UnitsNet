// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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

using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class Density
#else
    public partial struct Density
#endif
    {
        /// <summary>
        ///     Gets <see cref="Molarity" /> from this <see cref="Density" />.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public Molarity ToMolarity(Mass molecularWeight)
        {
            return Molarity.FromMolesPerCubicMeter(KilogramsPerCubicMeter / molecularWeight.Kilograms);
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Density" /> from <see cref="Molarity" />.
        /// </summary>
        /// <param name="molarity"></param>
        /// <param name="molecularWeight"></param>
        public static Density FromMolarity(Molarity molarity, Mass molecularWeight)
        {
            return new Density(molarity.MolesPerCubicMeter * molecularWeight.Kilograms, DensityUnit.KilogramPerCubicMeter);
        }

        #endregion

        // Windows Runtime Component does not allow operator overloads: https://msdn.microsoft.com/en-us/library/br230301.aspx
#if !WINDOWS_UWP
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

        public static MassFlux operator *(Density density, Speed speed)
        {
            return MassFlux.FromKilogramsPerSecondPerSquareMeter(density.KilogramsPerCubicMeter * speed.MetersPerSecond);
        }

        public static SpecificWeight operator *(Density density, Acceleration acceleration)
        {
            return new SpecificWeight(density.KilogramsPerCubicMeter * acceleration.MetersPerSecondSquared, SpecificWeightUnit.NewtonPerCubicMeter);
        }
#endif
    }
}
