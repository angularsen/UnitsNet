// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnitsNet.Serialization.JsonNet
{
    /// <inheritdoc />
    /// <summary>
    ///     A JSON.net <see cref="T:Newtonsoft.Json.JsonConverter" /> for converting to/from JSON and Units.NET
    ///     units like <see cref="T:UnitsNet.Length" /> and <see cref="T:UnitsNet.Mass" />.
    /// </summary>
    /// <remarks>
    ///     Relies on reflection and the type names and namespaces as of 3.x.x of Units.NET.
    ///     Assumptions by reflection code in the converter:
    ///     * Unit classes are of type UnitsNet.Length etc.
    ///     * Unit enums are of type UnitsNet.Units.LengthUnit etc.
    ///     * Unit class has a BaseUnit property returning the base unit, such as LengthUnit.Meter
    /// </remarks>
    public class UnitsNetJsonConverter : JsonConverter
    {
        /// <summary>
        ///     Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        ///     The object value.
        /// </returns>
        /// <exception cref="UnitsNetException">Unable to parse value and unit from JSON.</exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.ValueType != null)
                return reader.Value;

            object obj = TryDeserializeIComparable(reader, serializer);
            // A null System.Nullable value or a comparable type was deserialized so return this
            if (!(obj is ValueUnit vu))
                return obj;

            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            string unitEnumTypeName = vu.Unit.Split('.')[0];
            string unitEnumValue = vu.Unit.Split('.')[1];

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

        private static object TryDeserializeIComparable(JsonReader reader, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (!token.HasValues || token[nameof(ValueUnit.Unit)] == null || token[nameof(ValueUnit.Value)] == null)
            {
                JsonSerializer localSerializer = new JsonSerializer()
                {
                    TypeNameHandling = serializer.TypeNameHandling,
                };
                return token.ToObject<IComparable>(localSerializer);
            }
            else
            {
                return new ValueUnit()
                {
                    Unit = token[nameof(ValueUnit.Unit)].ToString(),
                    Value = token[nameof(ValueUnit.Value)].ToObject<double>()
                };
            }
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The value to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <exception cref="UnitsNetException">Can't serialize 'null' value.</exception>
        public override void WriteJson(JsonWriter writer, object obj, JsonSerializer serializer)
        {
            Type quantityType = obj.GetType();

            // ValueUnit should be written as usual (but read in a custom way)
            if(quantityType == typeof(ValueUnit))
            {
                JsonSerializer localSerializer = new JsonSerializer()
                {
                    TypeNameHandling = serializer.TypeNameHandling,
                };
                JToken t = JToken.FromObject(obj, localSerializer);

                t.WriteTo(writer);
                return;
            }

            IQuantity quantity = obj as IQuantity;

            serializer.Serialize(writer, new ValueUnit
            {
                // See ValueUnit about precision loss for quantities using decimal type.
                Value = quantity.Value,
                Unit = $"{quantity.QuantityInfo.UnitType.Name}.{quantity.Unit}" // Example: "MassUnit.Kilogram"
            } );
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

        #region Can Convert

        /// <summary>
        ///     Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            if (IsNullable(objectType))
                return CanConvertNullable(objectType);

            return objectType.Namespace != null &&
                (objectType.Namespace.Equals(nameof(UnitsNet)) ||
                objectType == typeof(ValueUnit) ||
                // All unit types implement IComparable
                objectType == typeof(IComparable));
        }

        /// <summary>
        ///     Determines whether the specified object type is actually a <see cref="System.Nullable" /> type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if the object type is nullable; otherwise <c>false</c>.</returns>
        private static bool IsNullable(Type objectType)
        {
            return Nullable.GetUnderlyingType(objectType) != null;
        }

        /// <summary>
        ///     Determines whether this instance can convert the specified nullable object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if the object type is a nullable container for a UnitsNet type; otherwise <c>false</c>.</returns>
        protected virtual bool CanConvertNullable(Type objectType)
        {
            // Need to look at the FullName in order to determine if the nullable type contains a UnitsNet type.
            // For example: FullName = 'System.Nullable`1[[UnitsNet.Frequency, UnitsNet, Version=3.19.0.0, Culture=neutral, PublicKeyToken=null]]'
            return objectType.FullName != null && objectType.FullName.Contains(nameof(UnitsNet) + ".");
        }

        #endregion
    }
}
