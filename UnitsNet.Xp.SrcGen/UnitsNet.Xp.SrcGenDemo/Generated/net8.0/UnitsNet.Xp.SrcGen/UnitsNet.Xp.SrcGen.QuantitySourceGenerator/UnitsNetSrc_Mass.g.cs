namespace UnitsNetSrcGen
{
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
}