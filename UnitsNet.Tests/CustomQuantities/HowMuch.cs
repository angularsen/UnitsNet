﻿using System;

namespace UnitsNet.Tests.CustomQuantities
{
    /// <inheritdoc cref="IQuantity"/>
    /// <summary>
    /// Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
    /// </summary>
    public readonly struct HowMuch : IQuantity
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

        public bool Equals(IQuantity? other, IQuantity tolerance) => throw new NotImplementedException();

        Enum IQuantity.Unit => Unit;
        public HowMuchUnit Unit { get; }

        public double Value { get; }

        #region IQuantity

        private static readonly HowMuch Zero = new HowMuch(0, HowMuchUnit.Some);

        public BaseDimensions Dimensions => BaseDimensions.Dimensionless;

        public static QuantityInfo Info = new(
            nameof(HowMuch),
            typeof(HowMuchUnit),
            new UnitInfo[]
            {
                new UnitInfo<HowMuchUnit>(HowMuchUnit.Some, "Some", BaseUnits.Undefined, nameof(HowMuch)),
                new UnitInfo<HowMuchUnit>(HowMuchUnit.ATon, "Tons", BaseUnits.Undefined, nameof(HowMuch)),
                new UnitInfo<HowMuchUnit>(HowMuchUnit.AShitTon, "ShitTons", BaseUnits.Undefined, nameof(HowMuch)),
            },
            HowMuchUnit.Some,
            Zero,
            BaseDimensions.Dimensionless);

        QuantityInfo IQuantity.QuantityInfo
        {
            get { return Info; }
        }
        
        public UnitKey UnitKey
        {
            get => UnitKey.ForUnit(Unit);
        }

        public double As(Enum unit) => Convert.ToDouble(unit);

        public double As(UnitSystem unitSystem) => throw new NotImplementedException();

        public IQuantity ToUnit(Enum unit)
        {
            if (unit is HowMuchUnit howMuchUnit) return new HowMuch(As(unit), howMuchUnit);
            throw new ArgumentException("Must be of type HowMuchUnit.", nameof(unit));
        }

        public IQuantity ToUnit(UnitSystem unitSystem) => throw new NotImplementedException();

        public override string ToString() => $"{Value} {Unit}";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"HowMuch ({format}, {formatProvider})";

        #endregion
    }
}
