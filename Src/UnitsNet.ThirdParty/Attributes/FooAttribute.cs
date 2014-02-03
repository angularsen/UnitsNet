using System;

namespace UnitsNet.ThirdParty.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FooAttribute : ThirdPartyUnitAttribute, IUnitAttribute<FooUnit> 
    {
        /// <summary>
        /// Defines a polynomial function by the coefficients of increasing 'n'.
        /// Example: [5, 0, 4, 0, 3] would represent the function 5 + 0*x + 4*x² + 0*x³ + 3*x⁴ = 3x⁴+4x²+5
        /// </summary>
        /// <param name="constant">Constant 'b' of function y = ax + b, where x is base unit.</param>
        /// <param name="pluralName">Name of unit in pluralt. If null, appends 's' to the name of the unit.</param>
        /// <param name="slope">Slope 'a' of function y = ax + b, where x is base unit.</param>
        public FooAttribute(double slope, double constant = 0, string pluralName = (string)null)
            : base(slope, constant, pluralName)
        {
        }

        public FooUnit BaseUnit
        {
            get { return FooUnit.Foo; }
        }

        public string XmlDocSummary
        {
            get { return "Example unit to illustrate adding third party units to Units.NET."; }
        }

    }
}