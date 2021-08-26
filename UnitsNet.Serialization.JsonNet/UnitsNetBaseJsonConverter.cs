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
        /// Base converter functionality
        /// </summary>
        protected readonly QuantityConverter<IQuantity> BaseConverter = new();

        /// <inheritdoc cref="QuantityConverter{TQuantity}.RegisterCustomType"/>
        public void RegisterCustomType(Type quantity, Type unit)
        {
            BaseConverter.RegisterCustomType(quantity, unit);
        }

        /// <summary>
        /// Factory method to create a <see cref="ValueUnit"/>
        /// </summary>
        protected static ValueUnit CreateValueUnit(string unit, double value) => new ValueUnit { Unit = unit, Value = value };

        /// <summary>
        /// Factory method to create a <see cref="ExtendedValueUnit"/>
        /// </summary>
        protected static ExtendedValueUnit CreateExtendedValueUnit(string unit, double value, string valueString, string valueType)
            => new ExtendedValueUnit { Unit = unit, Value = value, ValueString = valueString, ValueType = valueType};

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
            var valueType = jsonObject.GetValue(nameof(ExtendedValueUnit.ValueType), StringComparison.OrdinalIgnoreCase);
            var valueString = jsonObject.GetValue(nameof(ExtendedValueUnit.ValueString), StringComparison.OrdinalIgnoreCase);

            if (unit == null || value == null)
            {
                return null;
            }

            if (valueType == null)
            {
                if (value.Type != JTokenType.Float && value.Type != JTokenType.Integer)
                {
                    return null;
                }

                return new ValueUnit {Unit = unit.Value<string>(), Value = value.Value<double>()};
            }

            if (valueType.Type != JTokenType.String)
            {
                return null;
            }

            return new ExtendedValueUnit
            {
                Unit = unit.Value<string>(),
                Value = value.Value<double>(),
                ValueType = valueType.Value<string>(),
                ValueString = valueString?.Value<string>()
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

        /// <inheritdoc cref="IValueUnit"/>
        protected class ValueUnit: IValueUnit
        {
            /// <inheritdoc cref="IValueUnit.Unit"/>
            [JsonProperty(Order = 1)]
            public string Unit { get; [UsedImplicitly] set; }

            /// <inheritdoc cref="IValueUnit.Value"/>
            [JsonProperty(Order = 2)]
            public double Value { get; [UsedImplicitly] set; }
        }

        /// <inheritdoc cref="IExtendedValueUnit"/>
        protected sealed class ExtendedValueUnit : ValueUnit, IExtendedValueUnit
        {
            /// <inheritdoc cref="IExtendedValueUnit.ValueString"/>
            [JsonProperty(Order = 3)]
            public string ValueString { get; [UsedImplicitly] set; }

            /// <inheritdoc cref="IExtendedValueUnit.ValueType"/>
            [JsonProperty(Order = 4)]
            public string ValueType { get; [UsedImplicitly] set; }
        }
    }
}
