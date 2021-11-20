// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;
using Newtonsoft.Json;
using UnitsNet.Tests.Serialization;

namespace UnitsNet.Serialization.JsonNet.Tests
{
    public abstract class JsonNetSerializationTestsBase : SerializationTestsBase<string>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        protected JsonNetSerializationTestsBase(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        protected JsonNetSerializationTestsBase(params JsonConverter[] converters)
            : this(new JsonSerializerSettings { Converters = converters.ToList()})
        {
        }

        protected override string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }

        protected override T DeserializeObject<T>(string payload)
        {
            return JsonConvert.DeserializeObject<T>(payload, _jsonSerializerSettings);
        }
    }
}
