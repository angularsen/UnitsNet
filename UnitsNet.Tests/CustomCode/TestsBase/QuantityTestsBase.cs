namespace UnitsNet.Tests.TestsBase
{
    public abstract class QuantityTestsBase
    {
        /// <summary>
        /// Whether this quantity has one or more units compatible with <see cref="UnitSystem.SI"/>.
        /// This is used to test whether methods methods accepting this unit system value will throw an exception or produce a value.
        /// </summary>
        protected abstract bool SupportsSIUnitSystem { get; }
    }
}
