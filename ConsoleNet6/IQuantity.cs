// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace ConsoleNet6
{
    public interface IQuantity<TQuantity> :
            IAdditionOperators<TQuantity, TQuantity, TQuantity>,
            IParseable<TQuantity>,
            IComparisonOperators<TQuantity, TQuantity>,
            IAdditiveIdentity<TQuantity, TQuantity>
        where TQuantity : IQuantity<TQuantity>
    {
        static abstract TQuantity Zero { get; }
    }
}
