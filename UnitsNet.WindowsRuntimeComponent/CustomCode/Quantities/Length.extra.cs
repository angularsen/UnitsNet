// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
    public sealed partial class Length
    {
        private const double InchesInOneFoot = 12;

        /// <summary>
        ///     Converts the length to a customary feet/inches combination.
        /// </summary>
        public FeetInches FeetInches
        {
            get
            {
                var inInches = Inches;
                var feet = Math.Truncate(inInches / InchesInOneFoot);
                var inches = inInches % InchesInOneFoot;

                return new FeetInches(feet, inches);
            }
        }

        /// <summary>
        ///     Get length from combination of feet and inches.
        /// </summary>
        public static Length FromFeetInches(double feet, double inches)
        {
            return FromInches(InchesInOneFoot*feet + inches);
        }
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

        public string ToString([CanBeNull] string cultureInfo)
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
