// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet.Modular;
using UnitsNet.Modular.Profiles;

namespace UnitsNet.Modular.Compatibility;

[UnitsNetModule]
internal interface CompatibilityUnits : IIncludeProfile<AllQuantities>
{
}
