using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions;

/// <summary>
///     Defines the contract for a function evaluator that can parse and create expressions.
/// </summary>
/// <remarks>
///     Implementations of this interface are used to evaluate specific mathematical functions.
/// </remarks>
internal interface IFunctionEvaluator
{
    /// <summary>
    ///     Gets the name of the function that this evaluator can handle.
    /// </summary>
    string FunctionName { get; }

    /// <summary>
    ///     Parses the given expression and returns a pending term.
    /// </summary>
    /// <param name="expressionToParse">The expression to parse.</param>
    /// <param name="exponent">The exponent to use in the parsing process.</param>
    /// <returns>A <see cref="ExpressionEvaluationTerm" /> that represents the parsed expression.</returns>
    ExpressionEvaluationTerm GetFunctionBody(string expressionToParse, Fraction exponent);

    /// <summary>
    ///     Creates a composite expression from the given parameters.
    /// </summary>
    /// <param name="coefficient">The coefficient to use in the expression.</param>
    /// <param name="exponent">The exponent to use in the expression.</param>
    /// <param name="functionBody">The body of the function to use in the expression.</param>
    /// <returns>A <see cref="CompositeExpression" /> that represents the created expression.</returns>
    CompositeExpression CreateExpression(Fraction coefficient, Fraction exponent, CompositeExpression functionBody);
}
