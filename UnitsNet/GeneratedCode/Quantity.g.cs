using System;
using System.Linq;
using UnitsNet.Units;

namespace UnitsNet
{
    public static partial class Quantity
    {
        public static IQuantity From(QuantityValue value, Enum unit)
        {
            if (TryFrom(value, unit, out IQuantity quantity))
                return quantity;

            throw new ArgumentException(
                $"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a third-party enum type defined outside UnitsNet library?");
        }

        public static bool TryFrom(QuantityValue value, Enum unit, out IQuantity quantity)
        {
            switch (unit)
            {
                case AngleUnit angleUnit:
                    quantity = Angle.From(value, angleUnit);
                    return true;
                case LengthUnit lengthUnit:
                    quantity = Length.From(value, lengthUnit);
                    return true;
                default:
                {
                    quantity = default(IQuantity);
                    return false;
                }
            }
        }

        public static IQuantity Parse(Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).IsAssignableFrom(quantityType))
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");

            if (quantityType == typeof(Angle)) return Angle.Parse(quantityString);
            if (quantityType == typeof(Length)) return Length.Parse(quantityString);

            throw new ArgumentException(
                $"Type {quantityType} is not a known quantity type. Did you pass in a third-party quantity type defined outside UnitsNet library?");
        }

        public static QuantityInfo GetInfo(QuantityType quantityType)
        {
            return UnitsHelper.QuantityInfos.First(qi => qi.QuantityType == quantityType);
        }
    }
}
