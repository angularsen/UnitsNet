// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity with a decimal value.
    /// </summary>
    public interface IDecimalQuantity
    {
        /// <summary>
        ///     The decimal value this quantity was constructed with.
        /// </summary>
        decimal Value { get; }
    }
}
