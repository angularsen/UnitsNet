// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Serialization.SystemTextJson
{
    public class UnitsNetJsonConverterFactory:JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(IQuantity).IsAssignableFrom(typeToConvert);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return new UnitsNetJsonConverter();
        }
    }
}
