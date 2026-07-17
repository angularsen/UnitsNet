// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace UnitsNetGen.Generator;

internal static class ConversionExpression
{
    private static readonly ISet<string> AllowedMathMembers = new HashSet<string>(StringComparer.Ordinal)
    {
        "PI",
        "E",
    };

    private static readonly ISet<string> AllowedMathMethods = new HashSet<string>(StringComparer.Ordinal)
    {
        "Abs",
        "Exp",
        "Log",
        "Log10",
        "Pow",
        "Sqrt",
    };

    public static bool TryNormalize(string? source, out string expression, out string error)
    {
        expression = string.Empty;
        error = string.Empty;

        if (string.IsNullOrWhiteSpace(source))
        {
            error = "Conversion expression is required.";
            return false;
        }

        string candidate = source!.Replace("{x}", "x");
        ExpressionSyntax syntax = SyntaxFactory.ParseExpression(candidate);
        if (syntax.ContainsDiagnostics)
        {
            error = string.Join("; ", syntax.GetDiagnostics().Select(diagnostic => diagnostic.GetMessage()));
            return false;
        }

        if (!IsAllowed(syntax, out error))
        {
            return false;
        }

        expression = syntax.NormalizeWhitespace().ToFullString().Replace("Math.", "global::System.Math.");
        return true;
    }

    private static bool IsAllowed(ExpressionSyntax expression, out string error)
    {
        switch (expression)
        {
            case LiteralExpressionSyntax literal when literal.IsKind(SyntaxKind.NumericLiteralExpression):
                error = string.Empty;
                return true;
            case IdentifierNameSyntax identifier when identifier.Identifier.ValueText == "x":
                error = string.Empty;
                return true;
            case ParenthesizedExpressionSyntax parenthesized:
                return IsAllowed(parenthesized.Expression, out error);
            case PrefixUnaryExpressionSyntax unary when unary.IsKind(SyntaxKind.UnaryMinusExpression) || unary.IsKind(SyntaxKind.UnaryPlusExpression):
                return IsAllowed(unary.Operand, out error);
            case BinaryExpressionSyntax binary when IsAllowedBinary(binary.Kind()):
                if (!IsAllowed(binary.Left, out error))
                {
                    return false;
                }

                return IsAllowed(binary.Right, out error);
            case MemberAccessExpressionSyntax memberAccess:
                return IsAllowedMathMember(memberAccess, out error);
            case InvocationExpressionSyntax invocation:
                return IsAllowedMathInvocation(invocation, out error);
            default:
                error = $"Expression syntax '{expression.Kind()}' is not allowed.";
                return false;
        }
    }

    private static bool IsAllowedMathMember(MemberAccessExpressionSyntax memberAccess, out string error)
    {
        if (memberAccess.Expression is IdentifierNameSyntax identifier &&
            identifier.Identifier.ValueText == "Math" &&
            AllowedMathMembers.Contains(memberAccess.Name.Identifier.ValueText))
        {
            error = string.Empty;
            return true;
        }

        error = $"Member access '{memberAccess}' is not allowed.";
        return false;
    }

    private static bool IsAllowedMathInvocation(InvocationExpressionSyntax invocation, out string error)
    {
        if (invocation.Expression is not MemberAccessExpressionSyntax memberAccess ||
            memberAccess.Expression is not IdentifierNameSyntax identifier ||
            identifier.Identifier.ValueText != "Math" ||
            !AllowedMathMethods.Contains(memberAccess.Name.Identifier.ValueText))
        {
            error = $"Method invocation '{invocation.Expression}' is not allowed.";
            return false;
        }

        foreach (ArgumentSyntax argument in invocation.ArgumentList.Arguments)
        {
            if (argument.NameColon is not null || !argument.RefKindKeyword.IsKind(SyntaxKind.None))
            {
                error = "Named, ref, in, and out arguments are not allowed.";
                return false;
            }

            if (!IsAllowed(argument.Expression, out error))
            {
                return false;
            }
        }

        error = string.Empty;
        return true;
    }

    private static bool IsAllowedBinary(SyntaxKind kind)
        => kind is SyntaxKind.AddExpression or
            SyntaxKind.SubtractExpression or
            SyntaxKind.MultiplyExpression or
            SyntaxKind.DivideExpression or
            SyntaxKind.ModuloExpression;
}
