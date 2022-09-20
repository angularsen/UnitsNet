// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Newtonsoft.Json;

namespace OasysUnits.Serialization.JsonNet.Tests.Infrastructure
{
    public abstract class OasysUnitsJsonBaseTest
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        protected OasysUnitsJsonBaseTest()
        {
            _jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
            _jsonSerializerSettings.Converters.Add(new OasysUnitsIQuantityJsonConverter());
            _jsonSerializerSettings.Converters.Add(new OasysUnitsIComparableJsonConverter());
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
