// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

/// <inheritdoc />
public sealed class NoCachingConverter : UnitConverter
{
    /// <inheritdoc />
    public NoCachingConverter(UnitParser unitParser)
        : base(unitParser)
    {
    }
}
