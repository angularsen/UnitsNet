// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnitsNet.Serialization.JsonNet
{
    /// <summary>
    /// Base converter for serializing and deserializing UnitsNet types to and from JSON.
    /// Contains shared functionality used by <see cref="UnitsNetIQuantityJsonConverter"/> and <see cref="UnitsNetIComparableJsonConverter"/>
    /// </summary>
    /// <typeparam name="T">The type being converted. Should either be <see cref="IQuantity"/> or <see cref="IComparable"/></typeparam>
    public abstract class UnitsNetBaseJsonConverter<T> : JsonConverter<T>
    {
         /// <summary>
        /// Reads the "Unit" and "Value" properties from a JSON string
        /// </summary>
        /// <param name="jsonToken">The JSON data to read from</param>
        /// <returns>A <see cref="ValueUnit"/></returns>
        protected ValueUnit ReadValueUnit(JToken jsonToken)
        {
            if (!jsonToken.HasValues)
            {
                return null;
            }

            var jsonObject = (JObject) jsonToken;

            var unit = jsonObject.GetValue(nameof(ValueUnit.Unit), StringComparison.OrdinalIgnoreCase);
            var value = jsonObject.GetValue(nameof(ValueUnit.Value), StringComparison.OrdinalIgnoreCase);

            if (unit == null || value == null)
            {
                return null;
            }

            return new ValueUnit()
            {
                Unit = unit.Value<string>(),
                Value = value.Value<double>()
            };
        }

        /// <summary>
        /// Convert a <see cref="ValueUnit"/> to an <see cref="IQuantity"/>
        /// </summary>
        /// <param name="valueUnit">The value unit to convert</param>
        /// <exception cref="UnitsNetException">Thrown when an invalid Unit has been provided</exception>
        /// <returns>An IQuantity</returns>
        protected IQuantity ConvertValueUnit(ValueUnit valueUnit)
        {
            if (valueUnit == null || string.IsNullOrWhiteSpace(valueUnit.Unit))
            {
                return null;
            }

            var unitParts = valueUnit.Unit.Split('.');

            if (unitParts.Length != 2)
            {
                var ex = new UnitsNetException($"\"{valueUnit.Unit}\" is not a valid unit.");
                ex.Data["type"] = valueUnit.Unit;
                throw ex;
            }

            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            var unitEnumTypeName = unitParts[0];
            var unitEnumValue = unitParts[1];

            // "UnitsNet.Units.MassUnit,UnitsNet"
            var unitEnumTypeAssemblyQualifiedName = "UnitsNet.Units." + unitEnumTypeName + ",UnitsNet";

            // -- see http://stackoverflow.com/a/6465096/1256096 for details
            var unitEnumType = Type.GetType(unitEnumTypeAssemblyQualifiedName);
            if (unitEnumType == null)
            {
                var ex = new UnitsNetException("Unable to find enum type.");
                ex.Data["type"] = unitEnumTypeAssemblyQualifiedName;
                throw ex;
            }

            var value = valueUnit.Value;
            var unitValue = (Enum)Enum.Parse(unitEnumType, unitEnumValue); // Ex: MassUnit.Kilogram

            return Quantity.From(value, unitValue);
        }

        /// <summary>
        /// Convert an <see cref="IQuantity"/> to a <see cref="ValueUnit"/>
        /// </summary>
        /// <param name="quantity">The quantity to convert</param>
        /// <returns></returns>
        protected ValueUnit ConvertIQuantity(IQuantity quantity)
        {
            quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));

            return new ValueUnit
            {
                // See ValueUnit about precision loss for quantities using decimal type.
                Value = quantity.Value,
                Unit = $"{quantity.QuantityInfo.UnitType.Name}.{quantity.Unit}"
            };
        }

        /// <summary>
        /// Create a copy of a serializer, retaining any settings but leaving out a converter to prevent loops
        /// </summary>
        /// <param name="serializer">The serializer to copy</param>
        /// <param name="currentConverter">The converter to leave out</param>
        /// <returns>A serializer with the same settings and all converters except the current one.</returns>
        protected JsonSerializer CreateLocalSerializer(JsonSerializer serializer, JsonConverter currentConverter)
        {
            var localSerializer = new JsonSerializer()
            {
                Culture = serializer.Culture,
                CheckAdditionalContent = serializer.CheckAdditionalContent,
                Context = serializer.Context,
                ContractResolver = serializer.ContractResolver,
                TypeNameHandling = serializer.TypeNameHandling,
                TypeNameAssemblyFormatHandling = serializer.TypeNameAssemblyFormatHandling,
                Formatting = serializer.Formatting,
                ConstructorHandling =  serializer.ConstructorHandling,
                DateFormatHandling = serializer.DateFormatHandling,
                DateFormatString = serializer.DateFormatString,
                DateParseHandling = serializer.DateParseHandling,
                DateTimeZoneHandling = serializer.DateTimeZoneHandling,
                DefaultValueHandling = serializer.DefaultValueHandling,
                EqualityComparer = serializer.EqualityComparer,
                FloatFormatHandling  = serializer.FloatFormatHandling,
                FloatParseHandling = serializer.FloatParseHandling,
                MaxDepth = serializer.MaxDepth,
                MetadataPropertyHandling = serializer.MetadataPropertyHandling,
                MissingMemberHandling = serializer.MissingMemberHandling,
                NullValueHandling = serializer.NullValueHandling,
                ObjectCreationHandling = serializer.ObjectCreationHandling,
                PreserveReferencesHandling = serializer.PreserveReferencesHandling,
                ReferenceLoopHandling = serializer.ReferenceLoopHandling,
                ReferenceResolver = serializer.ReferenceResolver,
                SerializationBinder = serializer.SerializationBinder,
                StringEscapeHandling = serializer.StringEscapeHandling,
                TraceWriter = serializer.TraceWriter
            };

            foreach (var converter in serializer.Converters.Where(x => x != currentConverter))
            {
                localSerializer.Converters.Add(converter);
            }

            return localSerializer;
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
        protected sealed class ValueUnit
        {
            /// <summary>
            /// The name of the unit
            /// </summary>
            /// <example>MassUnit.Pound</example>
            /// <example>InformationUnit.Kilobyte</example>
            public string Unit { get; [UsedImplicitly] set; }

            /// <summary>
            /// The value of the unit
            /// </summary>
            public double Value { get; [UsedImplicitly] set; }
        }
    }
}
