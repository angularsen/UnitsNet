// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;

namespace UnitsNet.Serialization.SystemTextJson.Tests.Infrastructure
{
    public abstract class UnitsNetJsonBaseTest
    {
        private readonly JsonSerializerOptions  _jsonSerializerSettings;

        protected UnitsNetJsonBaseTest()
        {
            _jsonSerializerSettings = new JsonSerializerOptions  { WriteIndented = true };
            _jsonSerializerSettings.Converters.Add(new UnitsNetIQuantityJsonConverterFactory());
        }

        protected string SerializeObject(object obj)
        {
            return JsonSerializer.Serialize(obj, _jsonSerializerSettings).Replace("\r\n", "\n");
        }

        protected T DeserializeObject<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, _jsonSerializerSettings);
        }
    }
}
