namespace UnitsNet.Core.Tests.CustomQuantities
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

        Enum IQuantity.Unit => Unit;
        public HowMuchUnit Unit { get; }

        public QuantityValue Value { get; }

        #region IQuantity

        private static readonly HowMuch Zero = new HowMuch(0, HowMuchUnit.Some);

        public BaseDimensions Dimensions => BaseDimensions.Dimensionless;

        public static QuantityInfo Info => new(
            nameof(HowMuch),
            typeof(HowMuchUnit),
            new UnitInfo[]
            {
                new UnitInfo<HowMuchUnit>(HowMuchUnit.Some, "Some", new[] { "sm", "some" }, BaseUnits.Undefined),
                new UnitInfo<HowMuchUnit>(HowMuchUnit.ATon, "Tons", new[] { "tns", "tons" }, BaseUnits.Undefined),
                new UnitInfo<HowMuchUnit>(HowMuchUnit.AShitTon, "ShitTons", new[] { "st", "shitn" }, BaseUnits.Undefined),
            },
            HowMuchUnit.Some,
            Zero,
            BaseDimensions.Dimensionless,
            From);

        public QuantityInfo QuantityInfo => Info;

        public static IQuantity From(QuantityValue value, Enum unit) => new HowMuch((double)value, (HowMuchUnit)unit);

        public double As(Enum unit) => Convert.ToDouble(unit);

        // public double As(UnitSystem unitSystem) => throw new NotImplementedException();

        public IQuantity ToUnit(Enum unit)
        {
            if (unit is HowMuchUnit howMuchUnit) return new HowMuch(As(unit), howMuchUnit);
            throw new ArgumentException("Must be of type HowMuchUnit.", nameof(unit));
        }

        // public IQuantity ToUnit(UnitSystem unitSystem) => throw new NotImplementedException();

        public override string ToString() => $"{Value} {Unit}";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"HowMuch ({format}, {formatProvider})";
        public string ToString(IFormatProvider? provider) => $"HowMuch ({provider})";

        #endregion
    }
}
