using UnitsNet.Units;

namespace UnitsNet.Tests.TestsBase
{
    public abstract class QuantityTestsBase
    {
        /// <summary>
        /// Whether this quantity has one or more units compatible with <see cref="UnitSystem.SI"/>.
        /// This is used to test whether methods accepting this unit system value will throw an exception or produce a value.
        /// </summary>
        protected virtual bool SupportsSIUnitSystem { get; } = true;

        /// <summary>
        ///     Gets a predefined instance of <see cref="BaseUnits" /> representing unsupported or invalid base units.
        /// </summary>
        /// <remarks>
        ///     This property is initialized with invalid unit values, represented by negative enumerations of
        ///     <see cref="LengthUnit" />, <see cref="MassUnit" />, <see cref="DurationUnit" />, <see cref="ElectricCurrentUnit" />,
        ///     <see cref="TemperatureUnit" />, <see cref="AmountOfSubstanceUnit" />, and <see cref="LuminousIntensityUnit" />.
        ///     It is intended for use in scenarios where base units are not supported or need to be explicitly marked as invalid.
        /// </remarks>
        protected static BaseUnits UnsupportedBaseUnits { get; } = new(
            (LengthUnit)(-1),
            (MassUnit)(-1),
            (DurationUnit)(-1),
            (ElectricCurrentUnit)(-1),
            (TemperatureUnit)(-1),
            (AmountOfSubstanceUnit)(-1),
            (LuminousIntensityUnit)(-1));
    }
}
