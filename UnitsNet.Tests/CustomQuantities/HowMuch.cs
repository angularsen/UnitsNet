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

        public double As(HowMuchUnit unit)
        {
            throw new NotImplementedException();
        }

        public HowMuchUnit Unit { get; }

        public double Value { get; }

        #region IQuantity
        
        public static readonly QuantityInfo<HowMuch, HowMuchUnit> Info = new(
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

        public BaseDimensions Dimensions => Info.BaseDimensions;


        UnitKey IQuantity.UnitKey
        {
            get => UnitKey.ForUnit(Unit);
        }

        public double As(Enum unit) => Convert.ToDouble(unit);
        public double As(UnitKey unitKey)
        {
            return As(unitKey.ToUnit<HowMuchUnit>());
        }

        public IQuantity ToUnit(Enum unit)
        {
            if (unit is HowMuchUnit howMuchUnit) return new HowMuch(As(unit), howMuchUnit);
            throw new ArgumentException("Must be of type HowMuchUnit.", nameof(unit));
        }

        public IQuantity<HowMuchUnit> ToUnit(HowMuchUnit unit)
        {
            throw new NotImplementedException();
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

        QuantityInfo IQuantity.QuantityInfo
        {
            get { return Info; }
        }

        Enum IQuantity.Unit => Unit;
#endif
        #endregion
    }
}
