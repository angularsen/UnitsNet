// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen.Generation;
using UnitsNetGen.Profiles;

namespace UnitsNetGen.Compatibility;

[UnitsNetModule("UnitsNet")]
internal interface CompatibilityUnits : IIncludeProfile<AllQuantities>
{
}
