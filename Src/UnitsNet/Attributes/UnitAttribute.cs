using System;

namespace UnitsNet.Attributes
{
    public struct LinearFunction
    {
        /// <summary>
        /// Slope of function, a, in y(x) = ax + b.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public readonly double a;

        /// <summary>
        /// Y-intercept of function, b, in y(x) = ax + b.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public readonly double b;

        /// <summary>
        /// Create linear function by its slope and y-intercept constants.
        /// </summary>
        /// <param name="a">Slope of function, a, in y(x) = ax + b.</param>
        /// <param name="b">Y-intercept of function, b, in y(x) = ax + b.</param>
        public LinearFunction(double a, double b)
        {
            this.b = b;
            this.a = a;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public abstract class UnitAttribute : Attribute
    {
        ///// <summary>
        /////     Base unit of unit class. This is the unit that unit classes store their value as internally.
        /////     Conversions between two units go via the base unit to simplify defining the constants, requiring only N constants
        /////     instead of N².
        ///// </summary>
        //public abstract Unit BaseUnit { get; }

        /// <summary>
        ///     Name of unit in plural form. Will be used as property name such as Force.FromNewtonmeters().
        /// </summary>
        public string PluralName { get; private set; }

        /// <summary>
        ///     Ratio of unit to base unit. For example, <see cref="Unit.Kilometer" /> is 1000:1 of the base unit
        ///     <see cref="Unit.Meter" />.
        /// </summary>
        public LinearFunction LinearFunction { get; private set; }

        /// <summary>
        ///     XML doc summary for unit class. Will be inserted when generating the class from T4 template.
        /// </summary>
        public abstract string XmlDocSummary { get; }

        public UnitAttribute(string pluralName, double slope, double offset)
        {
            // Example: Kilometer has slope 1000, meaning for every kilometer the base unit increases with 1000 meters.
            // a: 1000
            // b: 0
            // y: base unit value in meters
            // x: unit value in kilometers
            // new Length(2000).Kilometers => (y - b) / a = (2000 - 0) / 1000 = 2km
            // Length.FromKilometers(2) => y = ax + b = 1000*2 + 0 = 2000m
            double a = slope;
            double b = offset;
            LinearFunction = new LinearFunction(a, b);
            PluralName = pluralName;
        }
    }
}