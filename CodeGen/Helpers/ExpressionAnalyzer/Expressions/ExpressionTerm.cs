using System;
using System.Collections.Generic;
using System.Numerics;
using CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Expressions;

/// <summary>
///     A term of the form "a * f(x)^n".
/// </summary>
/// <param name="Coefficient">The constant coefficient (a)</param>
/// <param name="Exponent">The degree of the term (n)</param>
/// <param name="NestedFunction">f(x) if one is available</param>
/// <remarks>When there is no nested function f(x) = x</remarks>
internal record ExpressionTerm(Fraction Coefficient, Fraction Exponent, CustomFunction? NestedFunction = null) : IComparable<ExpressionTerm>, IComparable
{
    public bool IsRational => NestedFunction is null && Exponent.Denominator <= BigInteger.One;

    public bool IsConstant => NestedFunction is null && Exponent == Fraction.Zero;

    public ExpressionTerm Negate()
    {
        return this with { Coefficient = Coefficient.Invert() };
    }

    public ExpressionTerm Invert()
    {
        return this with { Exponent = Exponent.Invert(), Coefficient = 1 / Coefficient };
    }

    public ExpressionTerm Multiply(ExpressionTerm otherTerm)
    {
        if (NestedFunction != null && otherTerm.NestedFunction != null &&
            NestedFunction != otherTerm.NestedFunction) // there aren't any cases of this in the code-base
        {
            throw new NotSupportedException(
                "Multiplying terms with different functions is currently not supported"); // if we need to, we should use a collection or create some function-composition
        }

        return new ExpressionTerm(Coefficient * otherTerm.Coefficient, Exponent + otherTerm.Exponent, NestedFunction ?? otherTerm.NestedFunction);
    }

    public ExpressionTerm Divide(ExpressionTerm otherTerm)
    {
        return Multiply(otherTerm.Invert());
    }

    public static ExpressionTerm Constant(Fraction coefficient)
    {
        return new ExpressionTerm(coefficient, Fraction.Zero);
    }

    #region Overrides of Object

    public override string ToString()
    {
        var coefficientFormat = Coefficient == Fraction.One ? "" :
            Coefficient == Fraction.MinusOne ? "-" : $"{Coefficient.ToDouble()} * ";
        if (NestedFunction == null)
        {
            if (Exponent == Fraction.Zero)
            {
                return $"{Coefficient.ToDouble()}";
            }

            if (Exponent == Fraction.One)
            {
                return $"{coefficientFormat}x";
            }

            return $"{coefficientFormat}x^{Exponent.ToDouble()}";
        }

        return $"{coefficientFormat}{NestedFunction}";
    }

    #endregion

    public ExpressionTerm Evaluate(Fraction x)
    {
        if (NestedFunction != null || Exponent.IsZero)
        {
            return this;
        }

        return IsRational
            ? Constant(Coefficient * Fraction.Pow(x, Exponent.ToInt32()))
            : Constant(Coefficient * FractionExtensions.FromDoubleRounded(Math.Pow(x.ToDouble(), Exponent.ToDouble())));
    }

    #region Relational members

    public int CompareTo(ExpressionTerm? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        var exponentComparison = Exponent.CompareTo(other.Exponent);
        if (exponentComparison != 0) return exponentComparison;
        var nestedFunctionComparison = Comparer<CustomFunction?>.Default.Compare(NestedFunction, other.NestedFunction);
        if (nestedFunctionComparison != 0) return nestedFunctionComparison;
        return Coefficient.CompareTo(other.Coefficient);
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is ExpressionTerm other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(ExpressionTerm)}");
    }

    #endregion
}
