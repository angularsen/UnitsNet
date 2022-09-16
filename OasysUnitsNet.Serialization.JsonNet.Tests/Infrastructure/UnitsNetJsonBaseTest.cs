// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/OasysUnitsNet.

using Newtonsoft.Json;

namespace OasysUnitsNet.Serialization.JsonNet.Tests.Infrastructure
{
    public abstract class OasysUnitsNetJsonBaseTest
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        protected OasysUnitsNetJsonBaseTest()
        {
            _jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
            _jsonSerializerSettings.Converters.Add(new OasysUnitsNetIQuantityJsonConverter());
            _jsonSerializerSettings.Converters.Add(new OasysUnitsNetIComparableJsonConverter());
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
