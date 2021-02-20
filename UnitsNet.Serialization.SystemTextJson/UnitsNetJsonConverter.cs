using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace UnitsNet.Serialization.SystemTextJson
{
    public class UnitsNetJsonConverter : JsonConverter<IQuantity>
    {
        public override IQuantity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueUnit = JsonSerializer.Deserialize<ValueUnit>(ref reader,options);
            return ParseValueUnit(valueUnit);
        }

        public override void Write(Utf8JsonWriter writer, IQuantity value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, ToValueUnit(value), options);
        }

        private static ValueUnit ToValueUnit(IQuantity value)
        {
            return new ValueUnit
            {
                // See ValueUnit about precision loss for quantities using decimal type.
                Value = value.Value,
                Unit = $"{value.QuantityInfo.UnitType.Name}.{value.Unit}"
            };
        }

        private static IQuantity ParseValueUnit(ValueUnit vu)
        {
            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            string[] splitted = vu.Unit.Split('.');
            string unitEnumTypeName = splitted[0];
            string unitEnumValue = splitted[1];

            // "UnitsNet.Units.MassUnit,UnitsNet"
            string unitEnumTypeAssemblyQualifiedName = "UnitsNet.Units." + unitEnumTypeName + ",UnitsNet";

            // -- see http://stackoverflow.com/a/6465096/1256096 for details
            Type unitEnumType = Type.GetType(unitEnumTypeAssemblyQualifiedName);
            if (unitEnumType == null)
            {
                var ex = new UnitsNetException("Unable to find enum type.");
                ex.Data["type"] = unitEnumTypeAssemblyQualifiedName;
                throw ex;
            }

            double value = vu.Value;
            Enum unitValue = (Enum)Enum.Parse(unitEnumType, unitEnumValue); // Ex: MassUnit.Kilogram

            return Quantity.From(value, unitValue);
        }

        /// <summary>
        ///     A structure used to serialize/deserialize Units.NET unit instances.
        /// </summary>
        /// <remarks>
        ///     Quantities may use decimal, long or double as base value type and this might result
        ///     in a loss of precision when serializing/deserializing to decimal.
        ///     Decimal is the highest precision type available in .NET, but has a smaller
        ///     range than double.
        ///
        ///     Json: Support decimal precision #503
        ///     https://github.com/angularsen/UnitsNet/issues/503
        /// </remarks>
        private class ValueUnit
        {
            public string Unit { get; [UsedImplicitly] set; }
            public double Value { get; [UsedImplicitly] set; }
        }
    }
}
