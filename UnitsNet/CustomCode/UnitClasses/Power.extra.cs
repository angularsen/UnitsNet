// Copyright(c) 2007 Andreas Gullberg Larsen
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

// Operator overloads not supported in Universal Windows Platform (WinRT Components)
#if !WINDOWS_UWP
using System;

namespace UnitsNet
{
    /// <summary>
    ///     Extension to the generated Length struct.
    ///     Makes it easier to work with Feet/Inches combinations, which are customarily used in the US and UK
    ///     to express body height. For example, someone is 5 feet 3 inches tall.
    /// </summary>
    public partial struct Power
    {
        public static Energy operator *(Power power, TimeSpan time)
        {
            return Energy.FromJoules(power.Watts*time.TotalSeconds);
        }

        public static Energy operator *(TimeSpan time, Power power)
        {
            return Energy.FromJoules(power.Watts*time.TotalSeconds);
        }

        public static Energy operator *(Power power, Duration duration)
        {
            return Energy.FromJoules(power.Watts*duration.Seconds);
        }

        public static Energy operator *(Duration duration, Power power)
        {
            return Energy.FromJoules(power.Watts*duration.Seconds);
        }

        public static Force operator /(Power power, Speed speed)
        {
            return Force.FromNewtons(power.Watts/speed.MetersPerSecond);
        }

        public static Torque operator /(Power power, RotationalSpeed rotationalSpeed)
        {
            return Torque.FromNewtonMeters(power.Watts/rotationalSpeed.RadiansPerSecond);
        }

        public static RotationalSpeed operator /(Power power, Torque torque)
        {
            return RotationalSpeed.FromRadiansPerSecond(power.Watts/torque.NewtonMeters);
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
    }
}
#endif