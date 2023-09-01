// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    /// <summary>
    ///     Represents a quantity with a decimal value.
    /// </summary>
    /// <remarks>
    ///     This interface is obsolete. Please use <see cref="IValueQuantity{Decimal}"/>
    /// </remarks>
    [Obsolete("Use the IValueQuantity<decimal> interface.")]
    public interface IDecimalQuantity : IValueQuantity<decimal>
    {
    }
}
