// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
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
        private readonly QuantityFactory _quantityFactory;

        /// <summary>
        /// Creates a JSON converter using the default <see cref="QuantityFactory"/>.
        /// </summary>
        public UnitsNetJsonConverter() : this(QuantityFactory.Default)
        {

        }

        /// <summary>
        /// Creates a JSON converter using the given quantity factory.
        /// </summary>
        /// <param name="quantityFactory">The quantity factory to use when constructing IQuantity objects.</param>
        public UnitsNetJsonConverter(QuantityFactory quantityFactory)
        {
            _quantityFactory = quantityFactory;
        }

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
            if (obj is Array values)
            {
                // Create array with the requested type, such as `Length[]` or `Frequency[]`
                var arrayOfQuantities = Array.CreateInstance(objectType.GetElementType(), values.Length);

                // Fill array with parsed quantities
                var i = 0;
                foreach (ValueUnit valueUnit in values)
                {
                    IQuantity quantity = ParseValueUnit(valueUnit);
                    arrayOfQuantities.SetValue(quantity, i++);
                }

                return arrayOfQuantities;
            }
            else if (obj is ValueUnit valueUnit)
            {
                return ParseValueUnit(valueUnit);
            }
            else
            {
                return obj;
            }
        }

        private IQuantity ParseValueUnit(ValueUnit vu)
        {
            return _quantityFactory.FromValueAndUnit(vu.Value, vu.Unit);
        }

        private object TryDeserializeIComparable(JsonReader reader, JsonSerializer serializer)
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

        private object TryDeserializeIComparable(JToken token, JsonSerializer serializer)
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
        /// <exception cref="UnitsNetException">Can't serialize 'null' value.</exception>
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
                var results = values.Cast<IQuantity>().Select(ToValueUnit);
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
            // Example: "Length"
            var quantityName = value.QuantityInfo.Name;

            return new ValueUnit
            {
                // See ValueUnit about precision loss for quantities using decimal type.
                Value = value.Value,
                Unit = $"{quantityName}Unit.{value.Unit}"
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
            if (IsNullable(objectType))
                return CanConvertNullable(objectType);

            return objectType.Namespace != null &&
                (_quantityFactory.IsQuantityTypeConfigured(objectType) ||
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
