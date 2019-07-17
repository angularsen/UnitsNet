using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class QuantityTypeGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;

        public QuantityTypeGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Lists all generated quantities with the same name as the quantity struct type,
    ///     such as Length, Mass, Force etc.
    ///     This is useful for populating options in the UI, such as creating a generic conversion
    ///     tool with inputValue, quantityName, fromUnit and toUnit selectors.
    /// </summary>
    public enum QuantityType
    {
// Missing XML comment for public type or member
#pragma warning disable CS1591
        Undefined = 0,");
            foreach (var quantity in _quantities)
                Writer.WL($@"
        {quantity.Name},");
            Writer.WL(@"
// Missing XML comment for public type or member
#pragma warning restore CS1591
    }
}");
            return Writer.ToString();
        }
    }
}
