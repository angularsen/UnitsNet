namespace UnitsNet.Attributes
{
    public interface IUnitAttribute<out TUnit>
    {
        /// <summary>
        ///     Base unit of unit class. This is the unit that unit classes store their value as internally.
        ///     Conversions between two units go via the base unit to simplify defining the constants, requiring only N constants
        ///     instead of N².
        /// </summary>
        TUnit BaseUnit { get; }

        /// <summary>
        ///     Name of unit in plural form. Will be used as property and method names, such as Force.FromNewtonmeters().
        /// </summary>
        string PluralName { get; }

        ///// <summary>
        /////     Ratio of unit to base unit.
        ///// </summary>
        //LinearFunction? LinearFunc { get; }

        /// <summary>
        ///     XML doc summary for unit class. Will be inserted when generating the class from T4 template.
        /// </summary>
        string XmlDocSummary { get; }

        ///// <summary>
        ///// Defines a polynomial function by the coefficients of increasing 'n'.
        ///// Example: [5, 0, 4, 0, 3] would represent the function 'y = 5 + 0*x + 4*x² + 0*x³ + 3*x⁴ = 3x⁴+4x²+5'
        ///// </summary>
        //double[] PolynomialFunc { get; }

        /// <summary>
        /// Linear function y = ax + b, where x is base unit.
        /// </summary>
        LinearFunction LinearFunction { get; }
    }
}