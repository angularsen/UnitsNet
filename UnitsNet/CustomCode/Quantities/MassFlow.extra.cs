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
    public sealed partial class MassFlow
#else
    public partial struct MassFlow
#endif
    {
#if !WINDOWS_UWP
        public static Mass operator *(MassFlow massFlow, TimeSpan time)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }

        public static Mass operator *(TimeSpan time, MassFlow massFlow)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }

        public static Mass operator *(MassFlow massFlow, Duration duration)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * duration.Seconds);
        }

        public static Mass operator *(Duration duration, MassFlow massFlow)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * duration.Seconds);
        }

        public static Power operator /(MassFlow massFlow, BrakeSpecificFuelConsumption bsfc)
        {
            return Power.FromWatts(massFlow.KilogramsPerSecond / bsfc.KilogramsPerJoule);
        }

        public static BrakeSpecificFuelConsumption operator /(MassFlow massFlow, Power power)
        {
            return BrakeSpecificFuelConsumption.FromKilogramsPerJoule(massFlow.KilogramsPerSecond / power.Watts);
        }

        public static Power operator *(MassFlow massFlow, SpecificEnergy specificEnergy)
        {
            return Power.FromWatts(massFlow.KilogramsPerSecond * specificEnergy.JoulesPerKilogram);
        }

        public static MassFlux operator /(MassFlow massFlow, Area area)
        {
            return MassFlux.FromKilogramsPerSecondPerSquareMeter(massFlow.KilogramsPerSecond / area.SquareMeters);
        }

        public static Area operator /(MassFlow massFlow, MassFlux massFlux)
        {
            return Area.FromSquareMeters(massFlow.KilogramsPerSecond / massFlux.KilogramsPerSecondPerSquareMeter);
        }

        public static Density operator /(MassFlow massFlow, VolumeFlow volumeFlow)
        {
            return Density.FromKilogramsPerCubicMeter(massFlow.KilogramsPerSecond / volumeFlow.CubicMetersPerSecond);
        }

        public static VolumeFlow operator /(MassFlow massFlow, Density density)
        {
            return VolumeFlow.FromCubicMetersPerSecond(massFlow.KilogramsPerSecond / density.KilogramsPerCubicMeter);
        }
#endif
    }
}
