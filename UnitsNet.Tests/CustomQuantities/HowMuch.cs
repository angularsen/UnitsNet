namespace UnitsNet.Tests.CustomQuantities;

/// <inheritdoc cref="IQuantity" />
/// <summary>
///     Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
/// </summary>
public readonly struct HowMuch : IQuantity<HowMuch, HowMuchUnit>
{
    public HowMuch(QuantityValue value, HowMuchUnit unit)
    {
        Unit = unit;
        Value = value;
    }

    public static HowMuch From(QuantityValue value, HowMuchUnit unit)
    {
        return new HowMuch(value, unit);
    }

    public HowMuchUnit Unit { get; }

    public QuantityValue Value { get; }
    
    public static readonly QuantityInfo<HowMuch, HowMuchUnit> Info = new(
        nameof(HowMuch),
        HowMuchUnit.Some,
        new UnitDefinition<HowMuchUnit>[]
        {
            new(HowMuchUnit.Some, "Some", BaseUnits.Undefined),
            new(HowMuchUnit.ATon, "Tons", new BaseUnits(mass: MassUnit.Tonne), new QuantityValue(1, 10)),
            new(HowMuchUnit.AShitTon, "ShitTons", BaseUnits.Undefined, new QuantityValue(1, 100))
        },
        new HowMuch(0, HowMuchUnit.Some),
        new BaseDimensions(0, 1, 0, 0, 0, 0, 0),
        From);

    public BaseDimensions Dimensions => Info.BaseDimensions;

    QuantityInfo<HowMuch, HowMuchUnit> IQuantity<HowMuch, HowMuchUnit>.QuantityInfo
    {
        get => Info;
    }

    UnitKey IQuantity.UnitKey
    {
        get => UnitKey.ForUnit(Unit);
    }

    public override string ToString()
    {
        return $"{Value} {Unit}";
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return $"HowMuch ({format}, {formatProvider})";
    }

#if !NET
    //  all the following methods have a default interface implementation for net8.0 and above
    IQuantityInstanceInfo<HowMuch> IQuantityOfType<HowMuch>.QuantityInfo
    {
        get => Info;
    }

    QuantityInfo<HowMuchUnit> IQuantity<HowMuchUnit>.QuantityInfo
    {
        get => Info;
    }

    QuantityInfo IQuantity.QuantityInfo
    {
        get => Info;
    }

    Enum IQuantity.Unit
    {
        get => Unit;
    }
#endif
}
