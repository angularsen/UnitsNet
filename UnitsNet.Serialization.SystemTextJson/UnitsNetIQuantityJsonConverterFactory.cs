// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Serialization.SystemTextJson
{
    /// <summary>
    /// System.Text.Json converter factory for IQuantity subtypes (e.g. all units in UnitsNet)
    /// Use this converter to serialize and deserialize UnitsNet types to and from JSON
    /// </summary>
    /// <remarks>Supports polymorphic deserialization of IQuantity subtypes</remarks>
    public class UnitsNetIQuantityJsonConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Base converter functionality
        /// </summary>
        private readonly QuantityConverter _baseConverter = new();

        /// <inheritdoc cref="QuantityConverter.RegisterCustomType"/>
        public void RegisterCustomType(Type quantity, Type unit)
        {
            _baseConverter.RegisterCustomType(quantity, unit);
        }

        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(IQuantity).IsAssignableFrom(typeToConvert);
        }

        /// <inheritdoc />
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(UnitsNetIQuantityJsonConverter<>).MakeGenericType(typeToConvert);
            // passing baseConverter to concrete converter instance so that is can deserialize to a custom unit
            // if typeToConvert is one of the registered custom type quantities
            var converter = (JsonConverter)Activator.CreateInstance(converterType, _baseConverter);

            return converter;
        }
    }
}
