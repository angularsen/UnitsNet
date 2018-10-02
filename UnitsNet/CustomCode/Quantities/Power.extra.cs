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

using System;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class Power
#else
    public partial struct Power
#endif
    {
        /// <summary>
        ///     Gets a <see cref="PowerRatio" /> from this <see cref="Power" /> relative to one watt.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a power to a power ratio (relative to 1 watt).
        ///     <example>
        ///         <c>var powerRatio = power.ToPowerRatio();</c>
        ///     </example>
        /// </remarks>
        public PowerRatio ToPowerRatio()
        {
            return PowerRatio.FromPower(this);
        }

        // Windows Runtime Component does not allow operator overloads: https://msdn.microsoft.com/en-us/library/br230301.aspx
#if !WINDOWS_UWP
        public static Energy operator *(Power power, TimeSpan time)
        {
            return Energy.FromJoules(power.Watts * time.TotalSeconds);
        }

        public static Energy operator *(TimeSpan time, Power power)
        {
            return Energy.FromJoules(power.Watts * time.TotalSeconds);
        }

        public static Energy operator *(Power power, Duration duration)
        {
            return Energy.FromJoules(power.Watts * duration.Seconds);
        }

        public static Energy operator *(Duration duration, Power power)
        {
            return Energy.FromJoules(power.Watts * duration.Seconds);
        }

        public static Force operator /(Power power, Speed speed)
        {
            return Force.FromNewtons(power.Watts / speed.MetersPerSecond);
        }

        public static Torque operator /(Power power, RotationalSpeed rotationalSpeed)
        {
            return Torque.FromNewtonMeters(power.Watts / rotationalSpeed.RadiansPerSecond);
        }

        public static RotationalSpeed operator /(Power power, Torque torque)
        {
            return RotationalSpeed.FromRadiansPerSecond(power.Watts / torque.NewtonMeters);
        }

        public static MassFlow operator *(Power power, BrakeSpecificFuelConsumption bsfc)
        {
            return MassFlow.FromKilogramsPerSecond(bsfc.KilogramsPerJoule * power.Watts);
        }

        public static SpecificEnergy operator /(Power power, MassFlow massFlow)
        {
            return SpecificEnergy.FromJoulesPerKilogram(power.Watts / massFlow.KilogramsPerSecond);
        }

        public static MassFlow operator /(Power power, SpecificEnergy specificEnergy)
        {
            return MassFlow.FromKilogramsPerSecond(power.Watts / specificEnergy.JoulesPerKilogram);
        }

        public static HeatFlux operator /(Power power, Area area)
        {
            return HeatFlux.FromWattsPerSquareMeter(power.Watts / area.SquareMeters);
        }

        public static Area operator /(Power power, HeatFlux heatFlux)
        {
            return Area.FromSquareMeters( power.Watts / heatFlux.WattsPerSquareMeter );
        }
#endif
    }
}
