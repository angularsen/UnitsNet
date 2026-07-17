// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Generic;

namespace UnitsNetGen.Generator;

internal sealed class QuantityDefinition
{
    public QuantityDefinition(string name, string targetNamespace, string baseUnit, IReadOnlyList<UnitDefinition> units)
    {
        Name = name;
        TargetNamespace = targetNamespace;
        BaseUnit = baseUnit;
        Units = units;
    }

    public string Name { get; }

    public string TargetNamespace { get; }

    public string BaseUnit { get; }

    public IReadOnlyList<UnitDefinition> Units { get; }
}

internal sealed class UnitDefinition
{
    public UnitDefinition(string singularName, string pluralName, string abbreviation, double scaleToBase, double offsetToBase = 0)
    {
        SingularName = singularName;
        PluralName = pluralName;
        Abbreviation = abbreviation;
        ScaleToBase = scaleToBase;
        OffsetToBase = offsetToBase;
    }

    public string SingularName { get; }

    public string PluralName { get; }

    public string Abbreviation { get; }

    public double ScaleToBase { get; }

    public double OffsetToBase { get; }
}

internal sealed class QuantitySelection
{
    public QuantitySelection(QuantityDefinition definition, IReadOnlyList<UnitDefinition> units)
    {
        Definition = definition;
        Units = units;
    }

    public QuantityDefinition Definition { get; }

    public IReadOnlyList<UnitDefinition> Units { get; }
}
