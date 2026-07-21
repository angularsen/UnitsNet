// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNetGen;
using UnitsNetGen.Generation;
using Catalog = UnitsNetGen.BuiltIns;

namespace UnitsNetGen.NetStandard.Sample;

[UnitsNetModule]
internal interface NetStandardUnits :
    IInclude<Catalog.Length>,
    IInclude<Catalog.Temperature>
{
}

/// <summary>Compile-time proof that generated quantities and their runtime work on netstandard2.0.</summary>
public static class CompatibilityProbe
{
    public static Length KilometersToMeters(double value) =>
        Length.FromKilometers(value).ToUnit(LengthUnit.Meter);

    public static bool TryParseLength(string text, out Length length) => Length.TryParse(text, out length);
}
