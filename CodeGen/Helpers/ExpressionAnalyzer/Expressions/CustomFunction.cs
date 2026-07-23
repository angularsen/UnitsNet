using System;

namespace CodeGen.Helpers.ExpressionAnalyzer.Expressions;

/// <summary>
///     A custom function f(ax^n + bx^m)
/// </summary>
/// <param name="Name"></param>
/// <param name="Namespace"></param>
/// <param name="Terms"></param>
/// <param name="AdditionalParameters"></param>
/// <remarks>These are functions that we don't directly support, such as Sqrt.</remarks>
internal record CustomFunction(string Namespace, string Name, CompositeExpression Terms, params string[] AdditionalParameters) : IComparable<CustomFunction>, IComparable
{
    #region Overrides of Object

    public override string ToString()
    {
        if(AdditionalParameters.Length == 0)
            return $"{Name}({Terms})";
        return $"{Name}({Terms}, {string.Join(", ", AdditionalParameters)})";
    }

    #endregion

    #region Relational members

    public int CompareTo(CustomFunction? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is CustomFunction other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(CustomFunction)}");
    }

    #endregion
}
