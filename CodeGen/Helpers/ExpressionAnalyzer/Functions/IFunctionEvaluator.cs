using System;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;

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
    /// <param name="expressionResolver">Can be used to evaluate the function body expression.</param>
    /// <returns>A <see cref="ExpressionEvaluationTerm" /> that represents the parsed expression.</returns>
    CompositeExpression CreateExpression(ExpressionEvaluationTerm expressionToParse, Func<ExpressionEvaluationTerm, CompositeExpression> expressionResolver);
}
