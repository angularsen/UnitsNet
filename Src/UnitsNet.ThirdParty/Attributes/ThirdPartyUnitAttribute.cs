using System;
using UnitsNet.Attributes;

namespace UnitsNet.ThirdParty.Attributes
{
    public abstract class ThirdPartyUnitAttribute : Attribute
    {
        private readonly string _pluralName;
        //private readonly double[] _polynomialFunc;
        private readonly LinearFunction _linearFunction;

        /// <summary>
        /// Defines a polynomial function by the coefficients of increasing 'n'.
        /// Example: [5, 0, 4, 0, 3] would represent the function 5 + 0*x + 4*x² + 0*x³ + 3*x⁴ = 3x⁴+4x²+5
        /// </summary>
        /// <param name="constant">Constant 'b' of function y = ax + b, where x is base unit.</param>
        /// <param name="pluralName">Name of unit in pluralt. If null, appends 's' to the name of the unit.</param>
        /// <param name="slope">Slope 'a' of function y = ax + b, where x is base unit.</param>
        ///// <param name="polynomialFunc">Array of coefficients of increasing 'n', starting with constant.</param>
        protected ThirdPartyUnitAttribute(double slope, double constant = 0, string pluralName = (string)null)//params double[] polynomialFunc)
        {
            _pluralName = pluralName;
            _linearFunction = new LinearFunction(slope, constant);
            //_polynomialFunc = polynomialFunc;
        }

        public string PluralName
        {
            get { return _pluralName; }
        }

        public LinearFunction LinearFunction
        {
            get { return _linearFunction; }
        }

        //public double[] PolynomialFunc
            //{
            //    get { return _polynomialFunc; }
            //}
        }
}