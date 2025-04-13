// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Text;

namespace UnitsNet;

/// <summary>
///     Represents a method that converts a <see cref="QuantityValue" />.
/// </summary>
/// <param name="sourceValue">The source value to be converted.</param>
/// <returns>The converted <see cref="QuantityValue" />.</returns>
public delegate QuantityValue ConvertValueDelegate(QuantityValue sourceValue);

/// <summary>
///     Represents a conversion function, expressed as an equation of the form:
///     <code>
/// f(x) = a * g(x)^n + b
///     </code>
///     where:
///     <c>a</c> and <c>b</c> are constants of type <see cref="QuantityValue" />.
///     <c>g(x)</c> is an optional custom function applied to the input <c>x</c> (of type <see cref="QuantityValue" />).
///     <c>n</c> is an integer exponent.
/// </summary>
/// <remarks>
///     Note: In order for the equality contract to work properly, <c>f(x)</c> should be invertible. Irrational functions,
///     such as <c>sqrt</c>, should be handled with care, ensuring consistent rounding precision is used.
///     <para>
///         For all quantities shipped with UnitsNet, <c>g(x)</c> defaults to <c>x</c> and the exponent <c>n</c> is either
///         1 or -1.
///     </para>
///     <para>
///         Conversions from degrees to radians are currently handled using an approximation of PI to the 16th digit.
///     </para>
/// </remarks>
public readonly record struct ConversionExpression
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ConversionExpression" /> struct.
    /// </summary>
    /// <param name="coefficient">
    ///     The coefficient <c>a</c> in the conversion equation.
    /// </param>
    /// <param name="nestedFunction">
    ///     An optional custom function <c>g(x)</c> applied to the input.
    /// </param>
    /// <param name="exponent">
    ///     The exponent <c>n</c> in the conversion equation.
    /// </param>
    /// <param name="constantTerm">
    ///     The constant term <c>b</c> in the conversion equation.
    /// </param>
    public ConversionExpression(QuantityValue coefficient, ConvertValueDelegate? nestedFunction = null, int exponent = 1, QuantityValue constantTerm = default)
    {
        Coefficient = coefficient;
        Exponent = exponent;
        ConstantTerm = constantTerm;
        NestedFunction = nestedFunction;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitsNet.ConversionExpression" /> struct with the specified
    ///     coefficient and constant term.
    /// </summary>
    /// <param name="coefficient">The coefficient <c>a</c> in the conversion equation.</param>
    /// <param name="constantTerm">The constant term <c>b</c> in the conversion equation.</param>
    public ConversionExpression(QuantityValue coefficient, QuantityValue constantTerm)
        : this(coefficient, null, 1, constantTerm)
    {
    }

    /// <summary>
    ///     Gets the coefficient <c>a</c> in the conversion expression.
    /// </summary>
    /// <value>
    ///     The coefficient <c>a</c> of type <see cref="QuantityValue" />.
    /// </value>
    /// <remarks>
    ///     This coefficient is used in the conversion function:
    ///     <code>
    /// f(x) = a * g(x)^n + b
    /// </code>
    /// </remarks>
    public QuantityValue Coefficient { get; }

    /// <summary>
    ///     Gets an optional custom function applied to the input <see cref="QuantityValue" />.
    /// </summary>
    /// <remarks>
    ///     This function, if provided, is represented as <c>g(x)</c> in the conversion equation:
    ///     <code>
    /// f(x) = a * g(x)^n + b
    /// </code>
    ///     where <c>a</c> and <c>b</c> are constants, and <c>n</c> is an integer exponent.
    ///     If the function is not specified, <c>g(x)</c> defaults to <c>x</c>.
    /// </remarks>
    public ConvertValueDelegate? NestedFunction { get; }

    /// <summary>
    ///     Gets the integer exponent <c>n</c> in the conversion function equation.
    /// </summary>
    /// <remarks>
    ///     The exponent is used in the equation:
    ///     <code>
    /// f(x) = a * g(x)^n + b
    /// </code>
    ///     where <c>n</c> is the exponent applied to the optional custom function <c>g(x)</c>.
    /// </remarks>
    public int Exponent { get; }

    /// <summary>
    ///     Gets the constant term <c>b</c> in the conversion expression equation.
    /// </summary>
    /// <value>
    ///     The constant term of type <see cref="QuantityValue" />.
    /// </value>
    /// <remarks>
    ///     This term represents the constant offset added to the result of the conversion function.
    /// </remarks>
    public QuantityValue ConstantTerm { get; }

    /// <summary>
    ///     Evaluates the conversion expression for a given input value.
    /// </summary>
    /// <param name="value">The input value to be converted.</param>
    /// <returns>The result of the conversion expression.</returns>
    /// <remarks>
    ///     The conversion expression is evaluated as:
    ///     <code>
    /// f(x) = a * g(x)^n + b
    /// </code>
    ///     where:
    ///     <list type="bullet">
    ///         <item>
    ///             <description><c>a</c> is the <see cref="Coefficient" />.</description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <c>g(x)</c> is the <see cref="NestedFunction" /> applied to the input
    ///                 <paramref name="value" />.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description><c>n</c> is the <see cref="Exponent" />.</description>
    ///         </item>
    ///         <item>
    ///             <description><c>b</c> is the <see cref="ConstantTerm" />.</description>
    ///         </item>
    ///     </list>
    ///     If <see cref="NestedFunction" /> is null, <c>g(x)</c> defaults to <paramref name="value" />.
    /// </remarks>
    public QuantityValue Evaluate(QuantityValue value)
    {
        QuantityValue x = NestedFunction?.Invoke(value) ?? value;
        return Exponent switch
        {
            1 => Coefficient * x + ConstantTerm,
            -1 => Coefficient * QuantityValue.Inverse(x) + ConstantTerm,
            _ => Coefficient * QuantityValue.Pow(x, Exponent) + ConstantTerm
        };
    }

    /// <summary>
    ///     Evaluates the current <see cref="ConversionExpression" /> using the specified intermediate expression.
    /// </summary>
    /// <param name="intermediateExpression">The intermediate <see cref="ConversionExpression" /> to be evaluated.</param>
    /// <param name="reduceConstants">
    ///     A boolean value indicating whether to reduce constants during the evaluation.
    ///     If true, the constants in the expressions will be reduced.
    /// </param>
    /// <returns>A new <see cref="ConversionExpression" /> that represents the result of the evaluation.</returns>
    /// <remarks>
    ///     The evaluation combines the coefficients, constant terms, and exponents of the current and intermediate
    ///     expressions.
    ///     If either expression has a nested function, the resulting expression will include a nested function that combines
    ///     them.
    /// </remarks>
    public ConversionExpression Evaluate(ConversionExpression intermediateExpression, bool reduceConstants = false)
    {
        if (NestedFunction is { } thisNestedFunction)
        {
            return new ConversionExpression(Coefficient, value => thisNestedFunction(intermediateExpression.Evaluate(value)), Exponent, ConstantTerm);
        }

        if (reduceConstants)
        {
            return Exponent switch
            {
                1 => new ConversionExpression(QuantityValue.Reduce(Coefficient * intermediateExpression.Coefficient), intermediateExpression.NestedFunction,
                    intermediateExpression.Exponent, QuantityValue.Reduce(ConstantTerm + Coefficient * intermediateExpression.ConstantTerm)),
                -1 when intermediateExpression.ConstantTerm == QuantityValue.Zero => new ConversionExpression(
                    QuantityValue.Reduce(Coefficient * QuantityValue.Inverse(intermediateExpression.Coefficient)), intermediateExpression.NestedFunction,
                    -intermediateExpression.Exponent,
                    ConstantTerm),
                _ => new ConversionExpression(Coefficient, intermediateExpression.Evaluate, Exponent, ConstantTerm)
            };
        }

        return Exponent switch
        {
            1 => new ConversionExpression(Coefficient * intermediateExpression.Coefficient, intermediateExpression.NestedFunction,
                intermediateExpression.Exponent, ConstantTerm + Coefficient * intermediateExpression.ConstantTerm),
            -1 when intermediateExpression.ConstantTerm == QuantityValue.Zero => new ConversionExpression(
                Coefficient * QuantityValue.Inverse(intermediateExpression.Coefficient), intermediateExpression.NestedFunction,
                -intermediateExpression.Exponent,
                ConstantTerm),
            _ => new ConversionExpression(Coefficient, intermediateExpression.Evaluate, Exponent, ConstantTerm)
        };
    }

    /// <summary>
    ///     Implicitly converts a <see cref="QuantityValue" /> to a <see cref="ConversionExpression" />.
    /// </summary>
    /// <param name="coefficient">The coefficient of type <see cref="QuantityValue" /> to be converted.</param>
    /// <returns>A new instance of <see cref="ConversionExpression" /> initialized with the specified coefficient.</returns>
    public static implicit operator ConversionExpression(QuantityValue coefficient)
    {
        return new ConversionExpression(coefficient);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="QuantityValue" /> to a <see cref="ConversionExpression" />.
    /// </summary>
    /// <param name="coefficient">The coefficient of type <see cref="QuantityValue" /> to be converted.</param>
    /// <returns>A new instance of <see cref="ConversionExpression" /> initialized with the specified coefficient.</returns>
    public static implicit operator ConversionExpression(int coefficient)
    {
        return new ConversionExpression(coefficient);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="QuantityValue" /> to a <see cref="ConversionExpression" />.
    /// </summary>
    /// <param name="coefficient">The coefficient of type <see cref="QuantityValue" /> to be converted.</param>
    /// <returns>A new instance of <see cref="ConversionExpression" /> initialized with the specified coefficient.</returns>
    public static implicit operator ConversionExpression(long coefficient)
    {
        return new ConversionExpression(coefficient);
    }

    /// <summary>
    ///     Implicitly converts a <see cref="ConversionExpression" /> to a <see cref="Func{QuantityValue,QuantityValue}" />.
    /// </summary>
    /// <param name="expression">The <see cref="ConversionExpression" /> to convert.</param>
    /// <returns>
    ///     A function that takes a <see cref="QuantityValue" /> and returns a <see cref="QuantityValue" /> based on the
    ///     conversion expression.
    /// </returns>
    public static implicit operator ConvertValueDelegate(ConversionExpression expression)
    {
        QuantityValue coefficient = expression.Coefficient;
        var exponent = expression.Exponent;
        ConvertValueDelegate? nestedFunction = expression.NestedFunction;
        QuantityValue constantTerm = expression.ConstantTerm;
        switch (exponent)
        {
            case 1:
            {
                if (nestedFunction is null)
                {
                    if (coefficient == QuantityValue.One)
                    {
                        // scaleFunction = value => value;
                        return constantTerm == QuantityValue.Zero ? value => value : value => value + constantTerm;
                    }

                    // scaleFunction = value => value * coefficient;
                    return constantTerm == QuantityValue.Zero
                        ? value => value * coefficient
                        : value => value * coefficient + constantTerm;
                }

                if (coefficient == QuantityValue.One)
                {
                    // scaleFunction = nestedFunction;
                    return constantTerm == QuantityValue.Zero
                        ? nestedFunction
                        : value => nestedFunction(value) + constantTerm;
                }

                // scaleFunction = value => nestedFunction(value) * coefficient;
                return constantTerm == QuantityValue.Zero
                    ? value => nestedFunction(value) * coefficient
                    : value => nestedFunction(value) * coefficient + constantTerm;
            }
            case -1:
            {
                if (nestedFunction is null)
                {
                    if (coefficient == QuantityValue.One)
                    {
                        // scaleFunction = QuantityValue.Inverse;
                        return constantTerm == QuantityValue.Zero ? QuantityValue.Inverse : value => QuantityValue.Inverse(value) + constantTerm;
                    }

                    // scaleFunction = value => QuantityValue.Inverse(value) * coefficient;
                    return constantTerm == QuantityValue.Zero
                        ? value => QuantityValue.Inverse(value) * coefficient
                        : value => QuantityValue.Inverse(value) * coefficient + constantTerm;
                }

                if (coefficient == QuantityValue.One)
                {
                    // scaleFunction = QuantityValue.Inverse(expression.NestedFunction);
                    return constantTerm == QuantityValue.Zero
                        ? value => QuantityValue.Inverse(nestedFunction(value))
                        : value => QuantityValue.Inverse(nestedFunction(value)) + constantTerm;
                }

                // scaleFunction = value => QuantityValue.Inverse(nestedFunction(value)) * coefficient;
                return constantTerm == QuantityValue.Zero
                    ? value => QuantityValue.Inverse(nestedFunction(value)) * coefficient
                    : value => QuantityValue.Inverse(nestedFunction(value)) * coefficient + constantTerm;
            }
            default:
            {
                if (nestedFunction is null)
                {
                    if (coefficient == QuantityValue.One)
                    {
                        // scaleFunction = value => QuantityValue.Pow(value, exponent);
                        return constantTerm == QuantityValue.Zero
                            ? value => QuantityValue.Pow(value, exponent)
                            : value => QuantityValue.Pow(value, exponent) + constantTerm;
                    }

                    // scaleFunction = value => QuantityValue.Pow(value, exponent) * coefficient;
                    return constantTerm == QuantityValue.Zero
                        ? value => QuantityValue.Pow(value, exponent) * coefficient
                        : value => QuantityValue.Pow(value, exponent) * coefficient + constantTerm;
                }

                if (coefficient == QuantityValue.One)
                {
                    // scaleFunction = QuantityValue.Pow(nestedFunction, exponent);
                    return constantTerm == QuantityValue.Zero
                        ? value => QuantityValue.Pow(nestedFunction(value), exponent)
                        : value => QuantityValue.Pow(nestedFunction(value), exponent) + constantTerm;
                }

                // scaleFunction = value => QuantityValue.Pow(nestedFunction(value), exponent) * coefficient;
                return constantTerm == QuantityValue.Zero
                    ? value => QuantityValue.Pow(nestedFunction(value), exponent) * coefficient
                    : value => QuantityValue.Pow(nestedFunction(value), exponent) * coefficient + constantTerm;
            }
        }
    }

    /// <summary>
    ///     Negates the given <see cref="ConversionExpression" />.
    /// </summary>
    /// <param name="expression">The <see cref="ConversionExpression" /> to negate.</param>
    /// <returns>A new <see cref="ConversionExpression" /> with negated values.</returns>
    public static ConversionExpression operator -(ConversionExpression expression)
    {
        return new ConversionExpression(-expression.Coefficient, expression.NestedFunction, expression.Exponent, -expression.ConstantTerm);
    }

    #region ToString

    /// <inheritdoc />
    public override string ToString()
    {
        var x = NestedFunction is null ? "x" : "g(x)";
        var firstTerm = Exponent switch
        {
            1 => Coefficient == QuantityValue.One ? x : Coefficient == -1 ? $"-{x}" : $"{Coefficient} * {x}",
            -1 => Coefficient == QuantityValue.One ? $"1 / {x}" : Coefficient == -1 ? $"-1 / {x}" : $"{Coefficient} / {x}",
            _ => Coefficient == QuantityValue.One ? $"{x}^{Exponent}" : Coefficient == -1 ? $"-{x}^{Exponent}" : $"{Coefficient} * {x}^{Exponent}"
        };

        if (ConstantTerm == QuantityValue.Zero)
        {
            return firstTerm;
        }

        return ConstantTerm > 0 ? firstTerm + " + " + ConstantTerm : firstTerm + " - " + -ConstantTerm;
    }

    private bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"Coefficient = {Coefficient}, ");
        builder.Append($"Exponent = {Exponent}, ");
        builder.Append($"ConstantTerm = {ConstantTerm}");
        if (NestedFunction != null)
        {
            builder.Append($", NestedFunction = {NestedFunction.Method.Name}");
        }

        return true;
    }

    #endregion
}
