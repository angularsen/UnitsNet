// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnitsNet.Serialization.JsonNet
{
    /// <summary>
    /// Base converter for serializing and deserializing UnitsNet types to and from JSON.
    /// Contains shared functionality used by <see cref="UnitsNetIQuantityJsonConverter"/> and <see cref="UnitsNetIComparableJsonConverter"/>
    /// </summary>
    /// <typeparam name="T">The type being converted. Should either be <see cref="IQuantity"/> or <see cref="IComparable"/></typeparam>
    public abstract class UnitsNetBaseJsonConverter<T> : NullableQuantityConverter<T>
    {
        private readonly ConcurrentDictionary<string, (Type Quantity, Type Unit)> _registeredTypes = new();

        /// <summary>
        /// Register custom types so that the converter can instantiate these quantities.
        /// Instead of calling <see cref="Quantity.From(double,System.Enum)"/>, the <see cref="Activator"/> will be used to instantiate the object.
        /// It is therefore assumed that the constructor of <paramref name="quantity"/> is specified with <c>new T(double value, typeof(<paramref name="unit"/>) unit)</c>.
        /// Registering the same <paramref name="unit"/> multiple times, it will overwrite the one registered.
        /// </summary>
        public void RegisterCustomType(Type quantity, Type unit)
        {
            if (!typeof(T).IsAssignableFrom(quantity))
            {
                throw new ArgumentException($"The type {quantity} is not a {typeof(T)}");
            }

            if (!typeof(Enum).IsAssignableFrom(unit))
            {
                throw new ArgumentException($"The type {unit} is not a {nameof(Enum)}");
            }

            _registeredTypes[unit.Name] = (quantity, unit);
        }

        /// <summary>
        /// Reads the "Unit" and "Value" properties from a JSON string
        /// </summary>
        /// <param name="jsonToken">The JSON data to read from</param>
        /// <returns>A <see cref="ValueUnit"/></returns>
        protected ValueUnit? ReadValueUnit(JToken jsonToken)
        {
            // Empty JSON "{}"
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

            if (value.Type != JTokenType.Float && value.Type != JTokenType.Integer)
            {
                return null;
            }

            return new ValueUnit {
                Unit = unit.Value<string>() ?? throw new InvalidOperationException("Unit was not a string."),
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
            if (string.IsNullOrWhiteSpace(valueUnit.Unit))
            {
                throw new NotSupportedException("Unit must be specified.");
            }

            var unit = GetUnit(valueUnit.Unit);
            var registeredQuantity = GetRegisteredType(valueUnit.Unit).Quantity;

            if (registeredQuantity is not null)
            {
                return (IQuantity)Activator.CreateInstance(registeredQuantity, valueUnit.Value, unit)!;
            }

            return Quantity.From(valueUnit.Value, unit);
        }

        private (Type? Quantity, Type? Unit) GetRegisteredType(string unit)
        {
            var (unitEnumTypeName, _) = SplitUnitString(unit);
            if (_registeredTypes.TryGetValue(unitEnumTypeName, out var registeredType))
            {
                return registeredType;
            }

            return (null, null);
        }

        private Enum GetUnit(string unit)
        {
            var (unitEnumTypeName, unitEnumValue) = SplitUnitString(unit);

            // First try to find the name in the list of registered types.
            var unitEnumType = GetRegisteredType(unit).Unit;

            if (unitEnumType is null)
            {
                // "UnitsNet.Units.MassUnit,UnitsNet"
                var unitEnumTypeAssemblyQualifiedName = "UnitsNet.Units." + unitEnumTypeName + ",UnitsNet";

                // -- see http://stackoverflow.com/a/6465096/1256096 for details
                unitEnumType = Type.GetType(unitEnumTypeAssemblyQualifiedName);

                if (unitEnumType is null)
                {
                    var ex = new UnitsNetException("Unable to find enum type.");
                    ex.Data["type"] = unitEnumTypeAssemblyQualifiedName;
                    throw ex;
                }
            }

            var unitValue = (Enum) Enum.Parse(unitEnumType, unitEnumValue); // Ex: MassUnit.Kilogram
            return unitValue;
        }

        private static (string EnumName, string EnumValue) SplitUnitString(string unit)
        {
            var unitParts = unit.Split('.');

            if (unitParts.Length != 2)
            {
                var ex = new UnitsNetException($"\"{unit}\" is not a valid unit.");
                ex.Data["type"] = unit;
                throw ex;
            }

            // "MassUnit.Kilogram" => "MassUnit" and "Kilogram"
            return (unitParts[0], unitParts[1]);
        }

        /// <summary>
        /// Convert an <see cref="IQuantity"/> to a <see cref="ValueUnit"/>
        /// </summary>
        /// <param name="quantity">The quantity to convert</param>
        /// <returns>A serializable object.</returns>
        protected ValueUnit ConvertIQuantity(IQuantity quantity)
        {
            quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));

            return new ValueUnit {Value = (double)quantity.Value, Unit = $"{quantity.QuantityInfo.UnitType.Name}.{quantity.Unit}"};
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
        protected class ValueUnit
        {
            /// <summary>
            ///     The unit of the value.
            /// </summary>
            /// <example>MassUnit.Pound</example>
            /// <example>InformationUnit.Kilobyte</example>
            [JsonProperty(Order = 1)]
            public string Unit { get; set; } = null!;

            /// <summary>
            ///     The value.
            /// </summary>
            [JsonProperty(Order = 2)]
            public double Value { get; set; }
        }
    }
}
