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

using System;
using System.Globalization;
using JetBrains.Annotations;
using UnitsNet.Units;

namespace UnitsNet
{
#if WINDOWS_UWP
    public sealed partial class Mass
#else
    public partial struct Mass
#endif
    {
        public static Mass FromGravitationalForce(Force f)
        {
            return new Mass(f.KilogramsForce);
        }

        /// <summary>
        ///     StonePounds related code makes it easier to work with Stone/Pound combination, which are customarily used in the UK
        ///     to express body weight. For example, someone weighs 11 stone 4 pounds (about 72 kilograms).
        /// </summary>
        private const double StoneToPounds = 14;

        /// <summary>
        ///     Converts the mass to a customary stone/pounds combination.
        /// </summary>
        public StonePounds StonePounds
        {
            get
            {
                double totalPounds = Pounds;
                double wholeStone = Math.Floor(totalPounds/StoneToPounds);
                double pounds = totalPounds%StoneToPounds;

                return new StonePounds(wholeStone, pounds);
            }
        }

        /// <summary>
        ///     Get Mass from combination of stone and pounds.
        /// </summary>
        public static Mass FromStonePounds(double stone, double pounds)
        {
            return FromPounds(StoneToPounds*stone + pounds);
        }

        // Operator overloads not supported in Universal Windows Platform (WinRT Components)
#if !WINDOWS_UWP
        public static MassFlow operator /(Mass mass, TimeSpan timeSpan)
        {
            return MassFlow.FromKilogramsPerSecond(mass.Kilograms/timeSpan.TotalSeconds);
        }

        public static MassFlow operator /(Mass mass, Duration duration)
        {
            return MassFlow.FromKilogramsPerSecond(mass.Kilograms/duration.Seconds);
        }

        public static Density operator /(Mass mass, Volume volume)
        {
            return Density.FromKilogramsPerCubicMeter(mass.Kilograms/volume.CubicMeters);
        }

        public static Force operator *(Mass mass, Acceleration acceleration)
        {
            return Force.FromNewtons(mass.Kilograms*acceleration.MeterPerSecondSquared);
        }

        public static Force operator *(Acceleration acceleration, Mass mass)
        {
            return Force.FromNewtons(mass.Kilograms*acceleration.MeterPerSecondSquared);
        }
#endif
    }

    public sealed class StonePounds
    {
        public StonePounds(double stone, double pounds)
        {
            Stone = stone;
            Pounds = pounds;
        }

        public double Stone { get; }
        public double Pounds { get; }

        public override string ToString()
        {
            return ToString(null);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        string ToString([CanBeNull] IFormatProvider cultureInfo)
        {
            // Note that it isn't customary to use fractions - one wouldn't say "I am 11 stone and 4.5 pounds".
            // So pounds are rounded here.

            UnitSystem unitSystem = UnitSystem.GetCached(cultureInfo);
            string stoneUnit = unitSystem.GetDefaultAbbreviation(MassUnit.Stone);
            string poundUnit = unitSystem.GetDefaultAbbreviation(MassUnit.Pound);

            return string.Format(unitSystem.Culture, "{0:n0} {1} {2:n0} {3}",
                Stone, stoneUnit, Math.Round(Pounds), poundUnit);
        }
    }
}