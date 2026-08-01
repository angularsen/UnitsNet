// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NETSTANDARD2_0

namespace System.Diagnostics.CodeAnalysis;

/// <summary>Describes the syntax used by a string.</summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal sealed class StringSyntaxAttribute : Attribute
{
    /// <summary>The syntax identifier for numeric format strings.</summary>
    public const string NumericFormat = nameof(NumericFormat);

    /// <summary>Creates an attribute describing <paramref name="syntax" />.</summary>
    public StringSyntaxAttribute(string syntax)
    {
        Syntax = syntax;
        Arguments = [];
    }

    /// <summary>Creates an attribute describing <paramref name="syntax" /> with additional arguments.</summary>
    public StringSyntaxAttribute(string syntax, params object?[] arguments)
    {
        Syntax = syntax;
        Arguments = arguments;
    }

    /// <summary>Gets the syntax identifier.</summary>
    public string Syntax { get; }

    /// <summary>Gets optional syntax-specific arguments.</summary>
    public object?[] Arguments { get; }
}

#endif
