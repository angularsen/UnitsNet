namespace UnitsNet.CustomCode.Extensions
{
    public static class MolarityExtensions
    {
        public static Density ToDensity(this Molarity molarity, Mass molecularWeight)
        {
            return Molarity.ToDensity(molarity, molecularWeight);
        }
    }
}
