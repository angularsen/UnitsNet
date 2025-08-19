using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Expressions;

/// <summary>
///     A set of terms, ordered by their degree: "P(x)^2 + P(x) + 1"
/// </summary>
internal class CompositeExpression : IEnumerable<ExpressionTerm>
{
    private readonly SortedSet<ExpressionTerm> _terms;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CompositeExpression" /> class.
    /// </summary>
    /// <remarks>
    ///     This constructor creates an empty CompositeExpression with terms sorted in descending order.
    /// </remarks>
    public CompositeExpression()
    {
        _terms = new SortedSet<ExpressionTerm>(DescendingOrderComparer);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="CompositeExpression" /> class with a single term.
    /// </summary>
    /// <param name="term">The initial term of the composite expression.</param>
    /// <remarks>
    ///     This constructor creates a CompositeExpression with a single term, sorted in descending order.
    /// </remarks>
    public CompositeExpression(ExpressionTerm term)
    {
        _terms = new SortedSet<ExpressionTerm>(DescendingOrderComparer) { term };
    }

    private CompositeExpression(IEnumerable<ExpressionTerm> terms)
    {
        _terms = new SortedSet<ExpressionTerm>(terms, DescendingOrderComparer);
    }

    public Fraction Degree => _terms.Min?.Exponent ?? Fraction.Zero;

    public bool IsConstant => Degree == Fraction.Zero;

    public IReadOnlyCollection<ExpressionTerm> Terms => _terms;

    public void Add(ExpressionTerm term)
    {
        if (_terms.TryGetValue(term, out ExpressionTerm? sameDegreeTerm))
        {
            // merge the two terms
            term = term with { Coefficient = sameDegreeTerm.Coefficient + term.Coefficient };
            _terms.Remove(sameDegreeTerm);
        }

        _terms.Add(term);
    }

    public void AddTerms(IEnumerable<ExpressionTerm> expressionTerms)
    {
        foreach (ExpressionTerm term in expressionTerms)
        {
            Add(term);
        }
    }


    public static implicit operator CompositeExpression(ExpressionTerm term)
    {
        return new CompositeExpression(term);
    }

    public static explicit operator ExpressionTerm(CompositeExpression term)
    {
        return term._terms.Max!;
    }

    public CompositeExpression Negate()
    {
        return new CompositeExpression(_terms.Select(term => term.Negate()));
    }

    public CompositeExpression Invert()
    {
        return new CompositeExpression(_terms.Select(term => term.Invert()));
    }
    
    public CompositeExpression SolveForY()
    {
        if (_terms.Count == 0)
        {
            throw new InvalidOperationException("The expression is empty");
        }

        if (_terms.Count > 2)
        {
            throw new NotImplementedException("Solving is only supported for expressions of first degree");
        }

        ExpressionTerm degreeTerm = _terms.Min!;
        if (degreeTerm.Exponent == Fraction.One)
        {
            return new CompositeExpression(_terms.Where(x => x.IsConstant).Select(x => x with { Coefficient = x.Coefficient.Negate() / degreeTerm.Coefficient })
                .Prepend(new ExpressionTerm(degreeTerm.Coefficient.Reciprocal(), 1)));
        }

        if (degreeTerm.Exponent == Fraction.MinusOne)
        {
            return new CompositeExpression(_terms.Where(x => x.IsConstant).Select(x => x with { Coefficient = degreeTerm.Coefficient / x.Coefficient.Negate() })
                .Prepend(new ExpressionTerm(degreeTerm.Coefficient, -1)));
        }

        throw new NotImplementedException("Solving is only supported for expressions of first degree");
    }

    public CompositeExpression Multiply(CompositeExpression other)
    {
        var result = new CompositeExpression();
        foreach (ExpressionTerm otherTerm in other)
        {
            result.AddTerms(_terms.Select(x => x.Multiply(otherTerm)));
        }

        return result;
    }

    public CompositeExpression Divide(CompositeExpression other)
    {
        var result = new CompositeExpression();
        foreach (ExpressionTerm otherTerm in other)
        {
            result.AddTerms(_terms.Select(x => x.Divide(otherTerm)));
        }

        return result;
    }

    public static CompositeExpression operator *(CompositeExpression left, CompositeExpression right)
    {
        return left.Multiply(right);
    }

    public static CompositeExpression operator /(CompositeExpression left, CompositeExpression right)
    {
        return left.Divide(right);
    }

    public override string ToString()
    {
        return string.Join(" + ", _terms);
    }

    public CompositeExpression Evaluate(Fraction x)
    {
        var result = new CompositeExpression();
        result.AddTerms(_terms.Select(t => t.Evaluate(x)));
        return result;
    }

    public CompositeExpression Evaluate(CompositeExpression expression)
    {
        var result = new CompositeExpression();
        foreach (ExpressionTerm expressionTerm in _terms)
        {
            if (expressionTerm.IsConstant)
            {
                result.Add(expressionTerm);
            }
            else
            {
                result.AddTerms(expression.Terms.Select(term => expressionTerm.Evaluate(term)));
            }
        }
        
        return result;
    }

    #region TermComparer

    private sealed class DescendingOrderTermComparer : IComparer<ExpressionTerm>
    {
        public int Compare(ExpressionTerm? y, ExpressionTerm? x)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            var nestedFunctionComparison = Comparer<CustomFunction?>.Default.Compare(x.NestedFunction, y.NestedFunction);
            if (nestedFunctionComparison != 0) return nestedFunctionComparison;
            return x.Exponent.Abs().CompareTo(y.Exponent.Abs());
        }
    }

    public static IComparer<ExpressionTerm> DescendingOrderComparer { get; } = new DescendingOrderTermComparer();

    #endregion

    #region Implementation of IEnumerable

    public IEnumerator<ExpressionTerm> GetEnumerator()
    {
        return _terms.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}
