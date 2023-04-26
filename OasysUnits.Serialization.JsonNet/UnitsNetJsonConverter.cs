// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OasysUnits.Serialization.JsonNet.Internal;

namespace OasysUnits.Serialization.JsonNet
{
    /// <inheritdoc />
    /// <summary>
    ///     A JSON.net <see cref="T:Newtonsoft.Json.JsonConverter" /> for converting to/from JSON and Units.NET
    ///     units like <see cref="T:OasysUnits.Length" /> and <see cref="T:OasysUnits.Mass" />.
    /// </summary>
    /// <remarks>
    ///     Relies on reflection and the type names and namespaces as of 3.x.x of Units.NET.
    ///     Assumptions by reflection code in the converter:
    ///     * Unit classes are of type OasysUnits.Length etc.
    ///     * Unit enums are of type OasysUnits.Units.LengthUnit etc.
    ///     * Unit class has a BaseUnit property returning the base unit, such as LengthUnit.Meter
    /// </remarks>
    [Obsolete("Replaced by OasysUnitsIQuantityJsonConverter and OasysUnitsIComparableJsonConverter (if you need support for IComparable)")]
    public class OasysUnitsJsonConverter : JsonConverter
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
        /// <exception cref="OasysUnitsException">Unable to parse value and unit from JSON.</exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.ValueType != null)
                return reader.Value;

            object obj = TryDeserializeIComparable(reader, serializer);
            if (obj is Array values)
            {

                // Create array with the requested type, such as `Length[]` or `Frequency[]` or multi-dimensional arrays like `Length[,]` or `Frequency[,,]` 
                var arrayOfQuantities = Array.CreateInstance(objectType.GetElementType(), MultiDimensionalArrayHelpers.LastIndex(values));

                // Fill array with parsed quantities
                int[] index = MultiDimensionalArrayHelpers.FirstIndex(values);
                while (index != null)
                {
                    arrayOfQuantities.SetValue(values.GetValue(index), index);
                }

                return arrayOfQuantities;
            }
            else
            {
                return obj is ValueUnit valueUnit ? ParseValueUnit(valueUnit) : obj;
            }
        }

        private static IQuantity ParseValueUnit(ValueUnit vu)
        {
            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            string unitEnumTypeName = vu.Unit.Split('.')[0];
            string unitEnumValue = vu.Unit.Split('.')[1];

            // "OasysUnits.Units.MassUnit,OasysUnits"
            string unitEnumTypeAssemblyQualifiedName = "OasysUnits.Units." + unitEnumTypeName + ",OasysUnits";

            // -- see http://stackoverflow.com/a/6465096/1256096 for details
            Type unitEnumType = Type.GetType(unitEnumTypeAssemblyQualifiedName);
            if (unitEnumType == null)
            {
                var ex = new OasysUnitsException("Unable to find enum type.");
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

            if (token is JArray)
            {
                object[] results = token.Children().Select(item => TryDeserializeIComparable(item, serializer)).ToArray();
                return results;
            }
            else
            {
                return TryDeserializeIComparable(token, serializer);
            }
        }

        private static object TryDeserializeIComparable(JToken token, JsonSerializer serializer)
        {
            if (!token.HasValues || token[nameof(ValueUnit.Unit)] == null || token[nameof(ValueUnit.Value)] == null)
            {
                var localSerializer = new JsonSerializer
                {
                    TypeNameHandling = serializer.TypeNameHandling,
                };
                return token.ToObject<IComparable>(localSerializer);
            }
            else
            {
                return new ValueUnit
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
        /// <exception cref="OasysUnitsException">Can't serialize 'null' value.</exception>
        public override void WriteJson(JsonWriter writer, object obj, JsonSerializer serializer)
        {
            // ValueUnit should be written as usual (but read in a custom way)
            if (obj is ValueUnit valueUnit)
            {
                var localSerializer = new JsonSerializer
                {
                    TypeNameHandling = serializer.TypeNameHandling,
                };

                var t = JToken.FromObject(valueUnit, localSerializer);
                t.WriteTo(writer);
            }
            else if (obj is Array values)
            {

                var results = Array.CreateInstance(typeof(ValueUnit), MultiDimensionalArrayHelpers.LastIndex(values));
                var ind = MultiDimensionalArrayHelpers.FirstIndex(values);

                while (ind != null)
                {
                    results.SetValue((IQuantity)values.GetValue(ind), ind);
                    ind = MultiDimensionalArrayHelpers.NextIndex(results, ind);
                }

                serializer.Serialize(writer, results);
            }
            else if (obj is IQuantity quantity)
            {
                serializer.Serialize(writer, ToValueUnit(quantity));
            }
            else
            {
                throw new NotSupportedException($"Unsupported type: {obj.GetType()}");
            }
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
            return IsNullable(objectType)
                ? CanConvertNullable(objectType)
                : objectType.Namespace != null &&
                (objectType.Namespace.Equals(nameof(OasysUnits)) ||
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
        /// <returns><c>true</c> if the object type is a nullable container for a OasysUnits type; otherwise <c>false</c>.</returns>
        protected virtual bool CanConvertNullable(Type objectType)
        {
            // Need to look at the FullName in order to determine if the nullable type contains a OasysUnits type.
            // For example: FullName = 'System.Nullable`1[[OasysUnits.Frequency, OasysUnits, Version=3.19.0.0, Culture=neutral, PublicKeyToken=null]]'
            return objectType.FullName != null && objectType.FullName.Contains(nameof(OasysUnits) + ".");
        }

        #endregion

    }
}
