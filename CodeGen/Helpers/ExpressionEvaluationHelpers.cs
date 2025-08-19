using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CodeGen.Helpers.ExpressionAnalyzer;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using CodeGen.JsonTypes;
using Fractions;

namespace CodeGen.Helpers;

internal static class ExpressionEvaluationHelpers
{
    private record struct Factor(BigInteger Number, int Power, BigInteger Value)
    {
        public static Factor FromNumber(BigInteger number) => new(number, 1, number);
        
        private sealed class ValueRelationalComparer : IComparer<Factor>
        {
            public int Compare(Factor x, Factor y)
            {
                return x.Value.CompareTo(y.Value);
            }
        }

        public static IComparer<Factor> ValueComparer { get; } = new ValueRelationalComparer();
    };

    private static List<Factor> ExtractFactors(this BigInteger number)
    {
        number = BigInteger.Abs(number);
        var factors = new List<Factor>();
        if (number.IsPowerOfTwo)
        {
            var exponent = (int)(number.GetBitLength() - 1);
            var divisor = BigInteger.Pow(2, exponent);
            factors.Add(new Factor(2, exponent, divisor));
            return factors;
        }

        var factorsToTryFirst = new BigInteger[] {10, 2, 3, 5, 7};
        foreach (BigInteger divisor in factorsToTryFirst)
        {
            if (TryGetFactors(number, divisor, out number, out Factor factor))
            {
                factors.Add(factor);
                if (number.IsOne)
                {
                    return factors;
                }
                
                if (number <= long.MaxValue)
                {
                    factors.Add(Factor.FromNumber(number));
                    return factors;
                }
            }
        }

        BigInteger currentDivisor = 11;
        do
        {
            if (TryGetFactors(number, currentDivisor, out number, out Factor factor))
            {
                factors.Add(factor);
            }

            currentDivisor++;
        } while (number > long.MaxValue && number > currentDivisor);
        
        if (!number.IsOne)
        {
            factors.Add(Factor.FromNumber(number));
        }
        
        return factors;
    }

    private static bool TryGetFactors(BigInteger number, BigInteger divisor, out BigInteger quotient, out Factor factor)
    {
        quotient = number;
        var power = 0;
        while (true)
        {
            var nextQuotient = BigInteger.DivRem(quotient, divisor, out BigInteger remainder);
            if (remainder.IsZero)
            {
                quotient = nextQuotient;
                power++;
            }
            else
            {
                factor = new Factor(divisor, power, BigInteger.Pow(divisor, power));
                return power > 0;
            }
        } 
    }

    private static SortedSet<Factor> MergeFactors(this IEnumerable<Factor> factorsToMerge)
    {
        var factors = new SortedSet<Factor>(factorsToMerge, Factor.ValueComparer);
        while (factors.Count > 1)
        {
            // try to merge the next two factors
            Factor smallestFactor = factors.First();
            Factor secondSmallestFactor = factors.Skip(1).First();
            var mergedFactor = Factor.FromNumber(smallestFactor.Value * secondSmallestFactor.Value);
            if (mergedFactor.Value > long.MaxValue)
            {
                return factors; // we've got the smallest possible set
            }

            // replace the two factors with their merged version
            factors.Remove(smallestFactor);
            factors.Remove(secondSmallestFactor);
            factors.Add(mergedFactor);
        }
        
        return factors;
    }

    private static string GetConstantFormat(this Factor factor)
    {
        if (factor.Power == 1)
        {
            return $"new BigInteger({factor.Value})";
        }
        else if (factor.Number == 10)
        {
            return $"QuantityValue.PowerOfTen({factor.Power})";
        }
        else
        {
            return $"BigInteger.Pow({factor.Number}, {factor.Power})";
        }
    }
    
    private static string GetConstantMultiplicationFormat(this IEnumerable<Factor> factors, bool negate = false)
    {
        var expression = string.Join(" * ", factors.Select(x => x.GetConstantFormat()));
        if (negate)
        {
            expression = "-" + expression;
        }

        return expression;
    }

    private static string GetConstantFormat(this Fraction coefficient)
    {
        if (coefficient == Fraction.One)
        {
            return "1";
        }

        return coefficient.Denominator.IsOne
            ? coefficient.Numerator.ToString()
            : $"new QuantityValue({coefficient.Numerator}, {coefficient.Denominator})";
    }
    
    private static string GetLongConstantFormat(this Fraction coefficient)
    {
        var numeratorExpression = coefficient.Numerator > long.MaxValue || coefficient.Numerator < long.MinValue
            ? coefficient.Numerator.ExtractFactors().MergeFactors().GetConstantMultiplicationFormat(coefficient.IsNegative)
            : coefficient.Numerator.ToString();
        var denominatorExpression = coefficient.Denominator > long.MaxValue
            ? coefficient.Denominator.ExtractFactors().MergeFactors().GetConstantMultiplicationFormat()
            : coefficient.Denominator.ToString();
        var expandedExpression = $"new QuantityValue({numeratorExpression}, {denominatorExpression})";
        return expandedExpression;
    }

    private static string GetFractionalConstantFormat(this Fraction coefficient)
    {
        coefficient = coefficient.Reduce();
        // making sure that neither the Numerator nor the Denominator contain a value that cannot be represented as a compiler constant
        if (coefficient.Numerator >= long.MinValue && coefficient.Numerator <= long.MaxValue && coefficient.Denominator <= long.MaxValue)
        {
            return coefficient.GetConstantFormat();
        }

        // need to represent the fraction in terms of two terms: "a * b" 
        return coefficient.GetLongConstantFormat();
    }

    private static string GetConstantExpression(this Fraction coefficient, string csharpParameter)
    {
        if (coefficient == Fraction.One)
        {
            return csharpParameter;
        }

        if (coefficient.Denominator.IsOne)
        {
            return $"{csharpParameter} * {coefficient.Numerator}";
        }

        if (coefficient.Numerator.IsOne)
        {
            return $"{csharpParameter} / {coefficient.Denominator}";
        }

        if (coefficient.Numerator == BigInteger.MinusOne)
        {
            return $"{csharpParameter} / -{coefficient.Denominator}";
        }

        return $"{csharpParameter} * new QuantityValue({coefficient.Numerator}, {coefficient.Denominator})";
    }

    private static string GetFractionalExpressionFormat(this Fraction coefficient, string csharpParameter)
    {
        coefficient = coefficient.Reduce();
        // making sure that neither the Numerator nor the Denominator contain a value that cannot be represented as a compiler constant
        if (coefficient.Numerator >= long.MinValue && coefficient.Numerator <= long.MaxValue && coefficient.Denominator <= long.MaxValue)
        {
            return coefficient.GetConstantExpression(csharpParameter);
        }

        // need to represent the fraction in terms of two (or more) terms: "x * a * b"
        return $"{csharpParameter} * {coefficient.GetLongConstantFormat()}";
    }


    public static string GetExpressionFormat(this CustomFunction customFunction, string csharpParameter)
    {
        // TODO see about redirecting these to a static method in the quantity's class which is responsible for handling the required operations (efficiently)
        var mainArgument = $"({customFunction.Terms.GetExpressionFormat(csharpParameter)}).ToDouble()";
        var functionArguments = string.Join(", ", customFunction.AdditionalParameters.Prepend(mainArgument));
        return $"QuantityValue.FromDoubleRounded({customFunction.Namespace}.{customFunction.Name}({functionArguments}))";
    }

    public static string GetConstantExpressionFormat(this CustomFunction customFunction)
    {
        // TODO see about redirecting these to a static method in the quantity's class which is responsible for handling the required operations (efficiently)
        var functionArguments = string.Join(", ", customFunction.AdditionalParameters);
        return $"QuantityValue.FromDoubleRounded({customFunction.Namespace}.{customFunction.Name}({functionArguments}))";
    }

    public static string GetExponentFormat(this Fraction exponent, string csharpParameter)
    {
        if (exponent == Fraction.One)
        {
            return csharpParameter;
        }
        
        // alternatively this could be an operator: e.g. $"({csharpParameter} ^ {exponent.ToInt32()})"
        return exponent.Denominator.IsOne
            ? $"QuantityValue.Pow({csharpParameter}, {exponent.ToInt32()})"
            : $"QuantityValue.FromDoubleRounded(Math.Pow({csharpParameter}.ToDouble(), {exponent.ToDouble()}))";
    }

    public static string GetExpressionFormat(this ExpressionTerm term, string csharpParameter)
    {
        if (term.IsConstant)
        {
            return term.Coefficient.GetFractionalConstantFormat();
        }
        
        if (term is { NestedFunction: not null, Exponent.IsZero: true })
        {
            return term.NestedFunction.GetConstantExpressionFormat();
        }

        var expressionFormat = term.NestedFunction is null ? csharpParameter : term.NestedFunction.GetExpressionFormat(csharpParameter);
        return term.Coefficient.GetFractionalExpressionFormat(term.Exponent.GetExponentFormat(expressionFormat));
    }

    public static string GetExpressionFormat(this CompositeExpression expression, string csharpParameter)
    {
        return string.Join(" + ", expression.Terms.Select(x => x.GetExpressionFormat(csharpParameter)));
    }

    private static string GetStringExpression(string expression, string csharpParameter, string jsonParameter = "{x}")
    {
        CompositeExpression compositeExpression = ExpressionEvaluator.Evaluate(expression, jsonParameter);
        var expectedFormat = compositeExpression.GetExpressionFormat(csharpParameter);
        return expectedFormat;
    }

    public static string GetConversionExpressionFormat(this CompositeExpression expression, string csharpParameter = "value")
    {
        string? coefficientTermFormat = null;
        string? exponentFormat = null;
        string? customConversionFunctionFormat = null;
        string? constantTermValue = null;
        
        foreach (ExpressionTerm expressionTerm in expression.Terms)
        {
            if (expressionTerm.IsConstant)
            {
                constantTermValue = expressionTerm.Coefficient.GetFractionalConstantFormat();
            }
            else if (expressionTerm.Exponent == 0)
            {
                throw new InvalidOperationException("The ConversionExpression class does not support custom functions as the constant term.");
            }
            else
            {
                if (coefficientTermFormat is not null || exponentFormat is not null || customConversionFunctionFormat is not null)
                {
                    throw new InvalidOperationException("The ConversionExpression class does not support more than 2 terms");
                }
                
                coefficientTermFormat = expressionTerm.Coefficient.GetFractionalConstantFormat();

                if (expressionTerm.NestedFunction is not null)
                {
                    customConversionFunctionFormat = expressionTerm.NestedFunction.GetExpressionFormat(csharpParameter);
                }

                if (expressionTerm.Exponent == Fraction.One)
                {
                    continue;
                }

                if (expressionTerm.Exponent.Denominator.IsOne)
                {
                    exponentFormat = expressionTerm.Exponent.Numerator.ToString();
                }
                else if (customConversionFunctionFormat is null)
                {
                    customConversionFunctionFormat = expressionTerm.Exponent.GetExponentFormat(csharpParameter);
                }
                else // create a composition between the two functions
                {
                    customConversionFunctionFormat = expressionTerm.Exponent.GetExponentFormat(customConversionFunctionFormat);
                }
            }
        }

        coefficientTermFormat ??= "1";
        
        if (constantTermValue is not null && exponentFormat is null && customConversionFunctionFormat is null)
        {
            return $"new ConversionExpression({coefficientTermFormat}, {constantTermValue})";
        }

        if (customConversionFunctionFormat is not null)
        {
            return $"new ConversionExpression({coefficientTermFormat}, {csharpParameter} => {customConversionFunctionFormat}, {exponentFormat ?? "1"}, {constantTermValue ?? "0"})";
        }
        
        if (constantTermValue is not null)
        {
            return $"new ConversionExpression({coefficientTermFormat}, null, {exponentFormat ?? "1"}, {constantTermValue})";
        }
        
        if (exponentFormat is not null)
        {
            return $"new ConversionExpression({coefficientTermFormat}, null, {exponentFormat})";
        }

        // return $"new ConversionExpression({coefficientTermFormat})";
        return coefficientTermFormat; // using the implicit constructor from QuantityValue
    }

    private static string GetConversionExpressionFormat(string expression, string csharpParameter = "value", string jsonParameter = "{x}")
    {
        CompositeExpression compositeExpression = ExpressionEvaluator.Evaluate(expression, jsonParameter);
        var expectedFormat = compositeExpression.GetConversionExpressionFormat(csharpParameter);
        return expectedFormat;
    }

    /// <summary>
    ///     Gets the format of the conversion from the unit to the base unit.
    /// </summary>
    /// <param name="unit">The unit for which to get the conversion format.</param>
    /// <param name="csharpParameter">The C# parameter to be used in the conversion expression.</param>
    /// <returns>A string representing the format of the conversion from the unit to the base unit.</returns>
    internal static string GetUnitToBaseConversionFormat(this Unit unit, string csharpParameter = "value")
    {
        return GetStringExpression(unit.FromUnitToBaseFunc, csharpParameter);
    }

    /// <summary>
    ///     Gets the format of the conversion from the base unit to the specified unit.
    /// </summary>
    /// <param name="unit">The unit to which the conversion format is to be obtained.</param>
    /// <param name="csharpParameter">The C# parameter to be used in the conversion expression.</param>
    /// <returns>A string representing the format of the conversion from the base unit to the specified unit.</returns>
    internal static string GetFromBaseToUnitConversionFormat(this Unit unit, string csharpParameter = "value")
    {
        return GetStringExpression(unit.FromBaseToUnitFunc, csharpParameter);
    }

    /// <summary>
    ///     Gets the format of the conversion from the unit to the base unit using a <c>ConversionExpression</c>.
    /// </summary>
    /// <param name="unit">The unit for which to get the conversion format.</param>
    /// <param name="csharpParameter">The C# parameter to be used in the conversion expression.</param>
    /// <returns>A string representing the constructor of a <c>ConversionExpression</c> from the unit to the base unit.</returns>
    internal static string GetUnitToBaseConversionExpressionFormat(this Unit unit, string csharpParameter = "value")
    {
        return GetConversionExpressionFormat(unit.FromUnitToBaseFunc, csharpParameter);
    }

    /// <summary>
    ///     Gets the format of the conversion from the base unit to the specified unit using a <c>ConversionExpression</c>.
    /// </summary>
    /// <param name="unit">The unit to which the conversion format is to be obtained.</param>
    /// <param name="csharpParameter">The C# parameter to be used in the conversion expression.</param>
    /// <returns>A string representing the constructor of a <c>ConversionExpression</c> from the base unit to the specified unit.</returns>
    internal static string GetFromBaseToUnitConversionExpressionFormat(this Unit unit, string csharpParameter = "value")
    {
        return GetConversionExpressionFormat(unit.FromBaseToUnitFunc, csharpParameter);
    }

    /// <summary>
    ///     Generates a dictionary of conversion expressions for a given quantity, mapping each unit to its conversion
    ///     expressions with other units.
    /// </summary>
    /// <param name="quantity">The quantity for which conversion expressions are generated.</param>
    /// <param name="jsonParameter">
    ///     An optional JSON parameter used in the evaluation of conversion expressions. Defaults to
    ///     "{x}".
    /// </param>
    /// <returns>
    ///     A dictionary where each key is a unit and the value is another dictionary mapping other units to their
    ///     respective conversion expressions.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if the calculated conversion expression does not match the expected
    ///     conversion expression.
    /// </exception>
    internal static Dictionary<Unit, Dictionary<Unit, CompositeExpression>> GetConversionExpressions(this Quantity quantity, string jsonParameter = "{x}")
    {
        var conversionsFromBase = new Dictionary<Unit, CompositeExpression>();
        var conversionsToBase = new Dictionary<Unit, CompositeExpression>();
        Unit baseUnit = quantity.Units.First(unit => unit.SingularName == quantity.BaseUnit);
        foreach (Unit unit in quantity.Units)
        {
            if (unit == baseUnit) continue;
            CompositeExpression conversionFromBase = conversionsFromBase[unit] = ExpressionEvaluator.Evaluate(unit.FromBaseToUnitFunc, jsonParameter);
            if (conversionFromBase.Terms.Count == 1 && conversionFromBase.Degree.Abs() == Fraction.One)
            {
                // as long as there aren't any complex functions we can just invert the expression
                conversionsToBase[unit] = conversionFromBase.SolveForY();  
            }
            else 
            {
                // complex conversion functions require an explicit expression in both directions
                conversionsToBase[unit] = ExpressionEvaluator.Evaluate(unit.FromUnitToBaseFunc, jsonParameter);
            }
        }

        var conversionsFrom = new Dictionary<Unit, Dictionary<Unit, CompositeExpression>> { [baseUnit] = conversionsToBase };
        foreach ((Unit fromUnit, CompositeExpression expressionFromBase) in conversionsFromBase)
        {
            Dictionary<Unit, CompositeExpression> fromUnitConversion = conversionsFrom[fromUnit] = new Dictionary<Unit, CompositeExpression>();
            foreach ((Unit otherUnit, CompositeExpression expressionToBase) in conversionsToBase)
            {
                if (fromUnit == otherUnit) continue;
                fromUnitConversion[otherUnit] = expressionFromBase.Evaluate(expressionToBase);
            }

            fromUnitConversion[baseUnit] = conversionsFromBase[fromUnit];
        }
        
        return conversionsFrom;
    }
}
