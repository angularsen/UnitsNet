using System;
using System.Globalization;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    /// Extension to the generated Length struct.
    /// Makes it easier to work with Feet/Inches combinations, which are customarily used in the US and UK
    /// to express body height. For example, someone is 5 feet 3 inches tall.
    /// </summary>
    public partial struct Length
    {
        private const double FeetToInches = 12;

        /// <summary>
        /// Converts the length to a customary feet/inches combination.
        /// </summary>
        public FeetInches FeetInches
        {
            get
            {
                double totalInches = Inches;
                double wholeFeet = Math.Floor(totalInches / FeetToInches);
                double inches = totalInches % FeetToInches;

                return new FeetInches(wholeFeet, inches); 
            }
        }

        /// <summary>
        ///     Get length from combination of feet and inches.
        /// </summary>
        public static Length FromFeetInches(double feet, double inches)
        {
            return FromInches((FeetToInches * feet) + inches);
        }

        public static Speed operator/ (Length length, TimeSpan timeSpan)
        {
            return Speed.FromMetersPerSecond(length.Meters / timeSpan.TotalSeconds);
        }
        public static Area operator*(Length length1, Length length2)
        {
            return Area.FromSquareMeters(length1.Meters * length2.Meters);
        }
        public static Volume operator*(Area area, Length length)
        {
            return Volume.FromCubicMeters(area.SquareMeters * length.Meters);
        }
        public static Volume operator *(Length length, Area area)
        {
            return Volume.FromCubicMeters(area.SquareMeters * length.Meters);
        }
        public static Torque operator*(Force force, Length length)
        {
            return Torque.FromNewtonMeters(force.Newtons * length.Meters);
        }

        public static Torque operator *(Length length, Force force)
        {
            return Torque.FromNewtonMeters(force.Newtons * length.Meters);
        }

    }

    public class FeetInches
    {
        public double Feet { get; private set; }
        public double Inches { get; private set; }

        public FeetInches(double feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }

        public string ToString(IFormatProvider cultureInfo = null)
        {
            // Note that it isn't customary to use fractions - one wouldn't say "I am 5 feet and 4.5 inches".
            // So inches are rounded when converting from base units to feet/inches.

            var unitSystem = UnitSystem.GetCached(cultureInfo);
            string footUnit = unitSystem.GetDefaultAbbreviation(LengthUnit.Foot);
            string inchUnit = unitSystem.GetDefaultAbbreviation(LengthUnit.Inch);

            return string.Format((cultureInfo == null) ? CultureInfo.CurrentCulture : cultureInfo, "{0:n0} {1} {2:n0} {3}", Feet, footUnit, Math.Round(Inches), inchUnit);
        }
    }
}
