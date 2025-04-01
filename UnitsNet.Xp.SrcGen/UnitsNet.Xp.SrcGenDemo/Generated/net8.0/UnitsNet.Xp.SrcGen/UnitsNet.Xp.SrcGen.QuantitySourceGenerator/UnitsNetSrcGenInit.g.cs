[System.AttributeUsage(System.AttributeTargets.Assembly, AllowMultiple = false)]
internal sealed class UnitsNetSrcGenInitAttribute : System.Attribute
{
    public string[] QuantityNames { get; }

    public UnitsNetSrcGenInitAttribute(string quantityNames)
        => (QuantityNames) = (quantityNames.Split(',').Select(str => str.Trim()).ToArray());
}