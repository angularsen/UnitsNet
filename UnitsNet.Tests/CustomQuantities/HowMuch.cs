using System;

namespace UnitsNet.Tests.CustomQuantities
{
    /// <inheritdoc cref="IQuantity"/>
    /// <summary>
    /// Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
    /// </summary>
    public struct HowMuch : IQuantity
    {
        public HowMuch(double value, Enum unit) : this()
        {
            Unit = unit;
            Value = value;
        }

        public Enum Unit { get; }
        public double Value { get; }

        #region Crud to satisfy IQuantity, but not really used for anything

        private static readonly HowMuch Zero = new HowMuch(0, HowMuchUnit.Some);

        public QuantityType Type => QuantityType.Undefined;
        public BaseDimensions Dimensions => BaseDimensions.Dimensionless;

        public QuantityInfo QuantityInfo => new QuantityInfo(Type,
            new UnitInfo[]
            {
                new UnitInfo<HowMuchUnit>(HowMuchUnit.Some, BaseUnits.Undefined),
                new UnitInfo<HowMuchUnit>(HowMuchUnit.ATon, BaseUnits.Undefined),
                new UnitInfo<HowMuchUnit>(HowMuchUnit.AShitTon, BaseUnits.Undefined),
            },
            HowMuchUnit.Some,
            Zero,
            BaseDimensions.Dimensionless);

        public double As(Enum unit) => Convert.ToDouble(unit);

        public double As(UnitSystem unitSystem) => throw new NotImplementedException();

        public IQuantity ToUnit(Enum unit) => new HowMuch(As(unit), unit);

        public IQuantity ToUnit(UnitSystem unitSystem) => throw new NotImplementedException();

        public string ToString(string format, IFormatProvider formatProvider) => $"HowMuch ({format}, {formatProvider})";
        public string ToString(IFormatProvider provider) => $"HowMuch ({provider})";
        public string ToString(IFormatProvider provider, int significantDigitsAfterRadix) => $"HowMuch ({provider}, {significantDigitsAfterRadix})";
        public string ToString(IFormatProvider provider, string format, params object[] args) => $"HowMuch ({provider}, {string.Join(", ", args)})";

        #endregion
    }
}
