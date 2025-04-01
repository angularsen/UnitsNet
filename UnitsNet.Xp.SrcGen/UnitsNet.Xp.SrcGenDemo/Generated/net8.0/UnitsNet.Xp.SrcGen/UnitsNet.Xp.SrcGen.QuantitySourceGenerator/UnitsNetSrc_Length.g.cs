namespace UnitsNetSrcGen
{
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
        }