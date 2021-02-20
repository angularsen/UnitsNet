using System.Text.Json;

namespace UnitsNet.Serialization.SystemTextJson.Tests
{
    public abstract class UnitsNetJsonBaseTest
    {
        private readonly JsonSerializerOptions _jsonSerializerSettings;

        protected UnitsNetJsonBaseTest()
        {
            _jsonSerializerSettings = new JsonSerializerOptions {WriteIndented = true};
            _jsonSerializerSettings.Converters.Add(new UnitsNetJsonConverterFactory());
            //_jsonSerializerSettings.Converters.Add(new UnitsNetIQuantityJsonConverter());
            //_jsonSerializerSettings.Converters.Add(new UnitsNetIComparableJsonConverter());
        }

        protected string SerializeObject(object obj)
        {
            return JsonSerializer.Serialize(obj, _jsonSerializerSettings).Replace("\r\n", "\n");
        }

        protected T DeserializeObject<T>(string json)
        { return JsonSerializer.Deserialize<T>(json, _jsonSerializerSettings);
        }
    }
}