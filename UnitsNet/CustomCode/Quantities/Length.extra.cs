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
using JetBrains.Annotations;
using UnitsNet.Units;

#if WINDOWS_UWP
using Culture=System.String;
#else
using Culture=System.IFormatProvider;
#endif

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class Length
#else
    public partial struct Length
#endif
    {
        private const double FeetToInches = 12;

        /// <summary>
        ///     Converts the length to a customary feet/inches combination.
        /// </summary>
        public FeetInches FeetInches
        {
            get
            {
                double totalInches = Inches;
                double wholeFeet = Math.Floor(totalInches/FeetToInches);
                double inches = totalInches%FeetToInches;

                return new FeetInches(wholeFeet, inches);
            }
        }

        /// <summary>
        ///     Get length from combination of feet and inches.
        /// </summary>
        public static Length FromFeetInches(double feet, double inches)
        {
            return FromInches(FeetToInches*feet + inches);
        }

        // Windows Runtime Component does not allow operator overloads: https://msdn.microsoft.com/en-us/library/br230301.aspx
#if !WINDOWS_UWP
        public static Speed operator /(Length length, TimeSpan timeSpan)
        {
            return Speed.FromMetersPerSecond(length.Meters/timeSpan.TotalSeconds);
        }

        public static Speed operator /(Length length, Duration duration)
        {
            return Speed.FromMetersPerSecond(length.Meters/duration.Seconds);
        }

        public static Duration operator /(Length length, Speed speed)
        {
            return Duration.FromSeconds(length.Meters/speed.MetersPerSecond);
        }

        public static Area operator *(Length length1, Length length2)
        {
            return Area.FromSquareMeters(length1.Meters*length2.Meters);
        }

        public static Volume operator *(Area area, Length length)
        {
            return Volume.FromCubicMeters(area.SquareMeters*length.Meters);
        }

        public static Volume operator *(Length length, Area area)
        {
            return Volume.FromCubicMeters(area.SquareMeters*length.Meters);
        }

        public static Torque operator *(Force force, Length length)
        {
            return Torque.FromNewtonMeters(force.Newtons*length.Meters);
        }

        public static Torque operator *(Length length, Force force)
        {
            return Torque.FromNewtonMeters(force.Newtons*length.Meters);
        }

        public static KinematicViscosity operator *(Length length, Speed speed)
        {
            return KinematicViscosity.FromSquareMetersPerSecond(length.Meters*speed.MetersPerSecond);
        }

        public static Pressure operator *(Length length, SpecificWeight specificWeight)
        {
            return new Pressure(length.Meters * specificWeight.NewtonsPerCubicMeter, PressureUnit.Pascal);
        }
#endif
    }

    public sealed class FeetInches
    {
        public FeetInches(double feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public double Feet { get; }
        public double Inches { get; }

        public override string ToString()
        {
            return ToString(null);
        }

        public string ToString([CanBeNull] Culture cultureInfo)
        {
            // Note that it isn't customary to use fractions - one wouldn't say "I am 5 feet and 4.5 inches".
            // So inches are rounded when converting from base units to feet/inches.
            var footUnit = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(LengthUnit.Foot);
            var inchUnit = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(LengthUnit.Inch);

            return string.Format(GlobalConfiguration.DefaultCulture, "{0:n0} {1} {2:n0} {3}", Feet, footUnit, Math.Round(Inches),
                inchUnit);
        }
    }
}
