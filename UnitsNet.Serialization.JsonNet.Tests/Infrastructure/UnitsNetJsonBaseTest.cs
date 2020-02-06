// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Newtonsoft.Json;

namespace UnitsNet.Serialization.JsonNet.Tests.Infrastructure
{
    public abstract class UnitsNetJsonBaseTest
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        protected UnitsNetJsonBaseTest()
        {
            _jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
            _jsonSerializerSettings.Converters.Add(new UnitsNetIQuantityJsonConverter());
            _jsonSerializerSettings.Converters.Add(new UnitsNetIComparableJsonConverter());
        }

        protected string SerializeObject(object obj, TypeNameHandling typeNameHandling = TypeNameHandling.None)
        {
            _jsonSerializerSettings.TypeNameHandling = typeNameHandling;

            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings).Replace("\r\n", "\n");
        }

        protected T DeserializeObject<T>(string json, TypeNameHandling typeNameHandling = TypeNameHandling.None)
        {
            _jsonSerializerSettings.TypeNameHandling = typeNameHandling;

            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }
    }
}
