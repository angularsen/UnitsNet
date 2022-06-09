// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;

namespace CodeGen.Helpers.UnitEnumValueAllocation
{
    /// <summary>
    ///     Data structure to allocate unique unit enum values that are preserved when adding new units.
    ///     <br/><br/>
    ///     Updating transitive UnitsNet dependency cause wrong unit · Issue #1068 · angularsen/UnitsNet
    ///     https://github.com/angularsen/UnitsNet/issues/1068
    /// </summary>
    internal class QuantityNameToUnitEnumValues : Dictionary<string, UnitEnumNameToValue>
    {
    }
}
