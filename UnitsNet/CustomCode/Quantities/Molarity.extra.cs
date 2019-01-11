using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class Molarity
#else
    public partial struct Molarity
#endif
    {
        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            Molarity(Density density, Mass molecularWeight)
            : this()
        {
            _value = density.KilogramsPerCubicMeter / molecularWeight.Kilograms;
            _unit = MolarityUnit.MolesPerCubicMeter;
        }

        /// <summary>
        ///     Get a <see cref="Density"/> from this <see cref="Molarity"/>.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public Density ToDensity(Mass molecularWeight)
        {
            return Density.FromKilogramsPerCubicMeter(MolesPerCubicMeter * molecularWeight.Kilograms);
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Molarity"/> from <see cref="Density"/>.
        /// </summary>
        /// <param name="density"></param>
        /// <param name="molecularWeight"></param>
        public static Molarity FromDensity(Density density, Mass molecularWeight)
        {
            return new Molarity(density, molecularWeight);
        }

        #endregion
    }
}
