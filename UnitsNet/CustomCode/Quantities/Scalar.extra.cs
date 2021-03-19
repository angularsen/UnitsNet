// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Scalar
    {
        /// <summary>Defines an implicit conversion of a <see cref="Scalar"/> to a <see cref="double"/>.</summary>
        public static implicit operator double(Scalar scalar)
        {
            return scalar.Amount;
        }
    }
}
