using System;

namespace UnitsNet.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public abstract class UnitAttribute : Attribute
    {
        /// <summary>
        ///     Base unit of unit class. This is the unit that unit classes store their value as internally.
        ///     Conversions between two units go via the base unit to simplify defining the constants, requiring only N constants
        ///     instead of N².
        /// </summary>
        public abstract Unit BaseUnit { get; }

        /// <summary>
        ///     Name of unit in plural form. Will be used as property name such as Force.FromNewtonmeters().
        /// </summary>
        public readonly string PluralName;

        /// <summary>
        ///     Ratio of unit to base unit. For example, <see cref="Unit.Kilometer" /> is 1000:1 of the base unit
        ///     <see cref="Unit.Meter" />.
        /// </summary>
        public readonly double Ratio;

        /// <summary>
        ///     XML doc summary for unit class. Will be inserted when generating the class from T4 template.
        /// </summary>
        public abstract string XmlDocSummary { get; }

        public UnitAttribute(string pluralName, double ratio)
        {
            Ratio = ratio;
            PluralName = pluralName;
        }
    }
}