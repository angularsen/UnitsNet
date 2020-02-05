using System;
using Newtonsoft.Json;

namespace UnitsNet.Serialization.JsonNet.Tests.CustomQuantities
{
    /// <inheritdoc cref="IQuantity"/>
    /// <summary>
    /// Example of a custom/third-party quantity implementation, for plugging in quantities and units at runtime.
    /// </summary>
    public struct HowMuch : IQuantity<HowMuchUnit>
    {
        public HowMuch(double value, Enum unit) : this()
        {
            Unit = (HowMuchUnit)unit;
            Value = value;
        }

        static HowMuch()
        {
            BaseUnit = HowMuchUnit.Some;
            Info = new QuantityInfo<HowMuchUnit>
            (
                QuantityType.Ratio,
                new[]
                {
                    new UnitInfo<HowMuchUnit>(HowMuchUnit.Some, BaseUnits.Undefined),
                    new UnitInfo<HowMuchUnit>(HowMuchUnit.ATon, BaseUnits.Undefined),
                    new UnitInfo<HowMuchUnit>(HowMuchUnit.AShitTon, BaseUnits.Undefined),
                },
                BaseUnit,
                Zero,
                BaseDimensions,
                new CustomQuantityOptions(TryParse, TryCreate)
            );
        }

        private static bool TryParse(IFormatProvider formatProvider, string str, out IQuantity quantity)
        {
            // Dummy implementation
            if (str == "a ton")
            {
                quantity = From(1, HowMuchUnit.ATon);
                return true;
            }
            else
            {
                quantity = default;
                return false;
            }
        }

        private static bool TryCreate(QuantityValue value, Enum unit, out IQuantity quantity)
        {
            if (Enum.IsDefined(typeof(HowMuchUnit), unit))
            {
                quantity = From(value, (HowMuchUnit)unit);
                return true;
            }
            else
            {
                quantity = default;
                return false;
            }
        }

        double IQuantity<HowMuchUnit>.As(HowMuchUnit unit)
        {
            return As(unit);
        }

        QuantityInfo<HowMuchUnit> IQuantity<HowMuchUnit>.QuantityInfo => Info;

        public HowMuchUnit Unit { get; }
        public double Value { get; }

        public static HowMuch From(QuantityValue value, HowMuchUnit fromUnit)
        {
            return new HowMuch((double)value,fromUnit);
        }

        public static HowMuchUnit BaseUnit { get; }
        public static HowMuch Zero { get; } = new HowMuch(0, BaseUnit);


        public QuantityType Type => QuantityType.Ratio;
        public static BaseDimensions BaseDimensions => BaseDimensions.Dimensionless;
        public BaseDimensions Dimensions => BaseDimensions;
        [JsonIgnore]
        public QuantityInfo QuantityInfo => Info;

        public static QuantityInfo<HowMuchUnit> Info { get; }

        public double As(Enum unit) => Convert.ToDouble(unit);

        #region Crud to satisfy IQuantity, but not really used for anything
        public double As(UnitSystem unitSystem) => throw new NotImplementedException();
        Enum IQuantity.Unit => Unit;

        public IQuantity ToUnit(Enum unit) => new HowMuch(As(unit), unit);
        IQuantity<HowMuchUnit> IQuantity<HowMuchUnit>.ToUnit(UnitSystem unitSystem)
        {
            throw new NotImplementedException();
        }

        public IQuantity<HowMuchUnit> ToUnit(HowMuchUnit unit)
        {
            throw new NotImplementedException();
        }

        public IQuantity ToUnit(UnitSystem unitSystem) => throw new NotImplementedException();

        public string ToString(string format, IFormatProvider formatProvider) => $"HowMuch ({format}, {formatProvider})";
        public string ToString(IFormatProvider provider) => $"HowMuch ({provider})";
        public string ToString(IFormatProvider provider, int significantDigitsAfterRadix) => $"HowMuch ({provider}, {significantDigitsAfterRadix})";
        public string ToString(IFormatProvider provider, string format, params object[] args) => $"HowMuch ({provider}, {string.Join(", ", args)})";

        #endregion
    }
}
