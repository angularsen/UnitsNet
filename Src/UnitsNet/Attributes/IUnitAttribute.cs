
namespace UnitsNet.Attributes
{
    public interface IUnitAttribute
    {
        /// <summary>
        ///     Name of unit in plural form. Will be used as property and method names, such as Force.FromNewtonmeters().
        /// </summary>
        string PluralName { get; }

        /// <summary>
        ///     XML doc summary for unit class. Will be inserted when generating the class from T4 template.
        /// </summary>
        string XmlDocSummary { get; }

        /// <summary>
        /// Linear function y = ax + b, where x is base unit.
        /// </summary>
        LinearFunction LinearFunction { get; }

        string BaseUnitName { get; }
    }

    public interface IUnitAttribute<out TUnit> : IUnitAttribute
    {
        ///// <summary>
        /////     Base unit of unit class. This is the unit that unit classes store their value as internally.
        /////     Conversions between two units go via the base unit to simplify defining the constants, requiring only N constants
        /////     instead of N².
        ///// </summary>
        //TUnit BaseUnit { get; }
    }
}