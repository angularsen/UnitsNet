// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen;

/// <summary>Runtime metadata for one generated unit.</summary>
public sealed class UnitInfo<TUnit>
    where TUnit : struct, Enum
{
    public UnitInfo(TUnit unit, string singularName, string pluralName, string abbreviation, double scaleToBase, double offsetToBase)
    {
        Unit = unit;
        SingularName = singularName;
        PluralName = pluralName;
        Abbreviation = abbreviation;
        ScaleToBase = scaleToBase;
        OffsetToBase = offsetToBase;
    }

    public TUnit Unit { get; }

    public string SingularName { get; }

    public string PluralName { get; }

    public string Abbreviation { get; }

    public double ScaleToBase { get; }

    public double OffsetToBase { get; }

    public double ToBase(double value) => (value * ScaleToBase) + OffsetToBase;

    public double FromBase(double value) => (value - OffsetToBase) / ScaleToBase;
}
