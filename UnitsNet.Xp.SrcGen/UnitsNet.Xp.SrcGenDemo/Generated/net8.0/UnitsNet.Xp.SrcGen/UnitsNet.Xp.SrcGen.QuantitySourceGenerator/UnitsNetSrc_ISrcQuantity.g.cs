namespace UnitsNetSrcGen
{
    public interface ISrcQuantity<TUnitEnum> where TUnitEnum : System.Enum
    {
        double Value { get; }
        TUnitEnum Unit { get; }
    }
}