using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer;

/// <summary>
///     A term of the form "P^n" where P is a term that hasn't been parsed, raised to the given power.
/// </summary>
/// <param name="Expression">The actual expression to parse</param>
/// <param name="Exponent">The exponent to use on the parsed expression (default is 1)</param>
/// <remarks>
///     Since we're tokenizing the expressions from top to bottom, the first step is parsing the exponent of the
///     expression: e.g. Math.Pow(P, 2)
/// </remarks>
public record ExpressionEvaluationTerm(string Expression, Fraction Exponent);
