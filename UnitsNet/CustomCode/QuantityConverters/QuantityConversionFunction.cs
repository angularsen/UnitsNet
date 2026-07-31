// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics;

namespace UnitsNet;

/// <summary>
///     Represents the result of a quantity conversion, including the conversion delegate and the target unit.
/// </summary>
[DebuggerDisplay("{TargetUnit.GetDebuggerDisplay(),nq}")]
internal readonly record struct QuantityConversionFunction
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityConversionFunction" /> struct.
    /// </summary>
    /// <param name="conversionFunction">The delegate that performs the conversion.</param>
    /// <param name="targetUnit">The unit to which the quantity is converted.</param>
    public QuantityConversionFunction(ConvertValueDelegate conversionFunction, UnitKey targetUnit)
    {
        Convert = conversionFunction;
        TargetUnit = targetUnit;
    }

    /// <summary>The delegate that performs the conversion.</summary>
    public ConvertValueDelegate Convert { get; }

    /// <summary>The unit to which the quantity is converted.</summary>
    public UnitKey TargetUnit { get; }
}
