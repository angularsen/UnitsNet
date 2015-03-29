using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            get {
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

        public override string ToString()
        {
            // Feet/Inches combos are only used in English speaking countries. So should be safe to use English text
            // here.
            // 
            // Note that it isn't customary to use fractions - one wouldn't say "I am 5 feet and 4.5 inches".
            // So inches are rounded when converting from base units to feet/inches.
            return string.Format("{0} ft {1} in", Feet, Math.Round(Inches));
        }
    }
}
