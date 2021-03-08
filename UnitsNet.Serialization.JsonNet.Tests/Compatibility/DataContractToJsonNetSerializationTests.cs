// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NETFRAMEWORK
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using UnitsNet.Serialization.Surrogates;
using UnitsNet.Tests.Serialization;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.Tests.Compatibility
{
    public class DataContractToJsonNetSerializationTests : SerializationTestsBase<string>
    {
        private readonly DataContractJsonSerializerSettings _dataContractJsonSerializerSettings;

        private readonly JsonSerializerSettings _jsonNetSerializerSettings;

        public DataContractToJsonNetSerializationTests()
        {
            _jsonNetSerializerSettings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.None};
            _jsonNetSerializerSettings.Converters.Add(new UnitsNetIQuantityJsonConverter());
            _dataContractJsonSerializerSettings = new DataContractJsonSerializerSettings {DataContractSurrogate = new ExtendedQuantityDataContractSurrogate()};
        }

        protected override string SerializeObject(object obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType(), _dataContractJsonSerializerSettings);
            using var stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            using var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        protected override T DeserializeObject<T>(string payload)
        {
            return JsonConvert.DeserializeObject<T>(payload, _jsonNetSerializerSettings);
        }


        [Fact(Skip = "Tuples are currently not supported by the UnitsNetIQuantityJsonConverter")]
        public override void TupleOfMixedValueQuantities_SerializationRoundTrips()
        {
            base.TupleOfMixedValueQuantities_SerializationRoundTrips();
        }

        [Fact(Skip = "Tuples are currently not supported by the UnitsNetIQuantityJsonConverter")]
        public override void TupleOfDoubleAndNullQuantities_SerializationRoundTrips()
        {
            base.TupleOfDoubleAndNullQuantities_SerializationRoundTrips();
        }

        [Fact(Skip = "Tuples are currently not supported by the UnitsNetIQuantityJsonConverter")]
        public override void TupleOfDecimalAndNullQuantities_SerializationRoundTrips()
        {
            base.TupleOfDecimalAndNullQuantities_SerializationRoundTrips();
        }
    }
}
#endif
