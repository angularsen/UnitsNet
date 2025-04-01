
/*
 * Dummy sources for copy & paste into c# source generator strings in UnitsNet.Xp.SrcGen/QuantitySourceGenerator.cs.
 */
// ReSharper disable once CheckNamespace
namespace UnitsNet.Xp.SrcGen;

/// <summary>
///     Represents a quantity.
/// </summary>
public interface ISrcQuantity<TUnitEnum> where TUnitEnum : System.Enum
{
    double Value { get; }
    TUnitEnum Unit { get; }
}

public enum LengthUnit
{
    Centimeter,
    Meter,
}

public struct Length : ISrcQuantity<LengthUnit>
{
    public Length(double value, LengthUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public required double Value { get; init; }
    public required LengthUnit Unit { get; init; }
}

public enum MassUnit
{
    Gram,
    Kilogram,
}

public struct Mass : ISrcQuantity<MassUnit>
{
    public Mass(double value, MassUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public required double Value { get; init; }
    public required MassUnit Unit { get; init; }
}

