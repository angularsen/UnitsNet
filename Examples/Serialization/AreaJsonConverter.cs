namespace UnitsNet.Tests.Examples.Serialization
{
    /// <summary>
    /// Example Area JsonConverter using SquareMeters for the serialization
    /// </summary>
    public class AreaJsonConverter : UnitsNetJsonConverter<Area>
    {
        public AreaJsonConverter()
        {
            Init(area => area.SquareMeters, d => Area.FromSquareMeters(d));
        }
    }
}