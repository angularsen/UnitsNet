using System;
using UnitsNet.Units;

namespace UnitsNet.Tests.CustomQuantities
{
    /// <inheritdoc cref="IQuantity"/>
    /// <summary>
    /// Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
    /// </summary>
    public readonly struct HowMuch : IQuantity<HowMuch, HowMuchUnit>
    {
        public HowMuch(double value, HowMuchUnit unit)
        {
            Unit = unit;
            Value = value;
        }

        public static HowMuch From(double value, HowMuchUnit unit)
        {
            return new HowMuch(value, unit);
        }

        public HowMuchUnit Unit { get; }

        public double Value { get; }

        #region IQuantity
        
        public static QuantityInfo<HowMuch, HowMuchUnit> Info { get; } = new(
            nameof(HowMuch),
            HowMuchUnit.Some,
            new UnitDefinition<HowMuchUnit>[]
            {
                new(HowMuchUnit.Some, "Some", BaseUnits.Undefined),
                new(HowMuchUnit.ATon, "Tons", new BaseUnits(mass: MassUnit.Tonne)),
                new(HowMuchUnit.AShitTon, "ShitTons", BaseUnits.Undefined)
            },
            new HowMuch(0, HowMuchUnit.Some),
            new BaseDimensions(0, 1, 0, 0, 0, 0, 0),
            From);

        QuantityInfo<HowMuch, HowMuchUnit> IQuantity<HowMuch, HowMuchUnit>.QuantityInfo
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
        IQuantityInstanceInfo<HowMuch> IQuantityOfType<HowMuch>.QuantityInfo => Info;

        Enum IQuantity.Unit => Unit;
#endif
        #endregion
    }
}
