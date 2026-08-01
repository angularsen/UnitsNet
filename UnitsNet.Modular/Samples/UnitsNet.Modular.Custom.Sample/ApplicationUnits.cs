// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet.Modular;

namespace Fictional.Measurements;

[QuantitySpec("Fictional.Measurements.HowMuch")]
public interface HowMuchSpec;

[UnitsNetModule]
internal interface FictionalUnits : IInclude<HowMuchSpec>;
