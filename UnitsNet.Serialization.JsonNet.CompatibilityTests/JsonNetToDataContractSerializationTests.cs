// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NETFRAMEWORK
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using UnitsNet.Serialization.Surrogates;
using UnitsNet.Tests.Serialization;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.CompatibilityTests
{
    public class JsonNetToDataContractSerializationTests : SerializationTestsBase<string>
    {
        private readonly DataContractJsonSerializerSettings _dataContractJsonSerializerSettings;

        private readonly JsonSerializerSettings _jsonNetSerializerSettings;

        public JsonNetToDataContractSerializationTests()
        {
            _jsonNetSerializerSettings = new JsonSerializerSettings();
            _jsonNetSerializerSettings.Converters.Add(new UnitsNetJsonConverter());
            _dataContractJsonSerializerSettings = new DataContractJsonSerializerSettings {DataContractSurrogate = new BasicQuantityContractSurrogate()};
        }

        protected override string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonNetSerializerSettings);
        }

        protected override T DeserializeObject<T>(string payload)
        {
            var serializer = new DataContractJsonSerializer(typeof(T), _dataContractJsonSerializerSettings);
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.Write(payload);
            writer.Flush();
            stream.Position = 0;
            return (T) serializer.ReadObject(stream);
        }
        
        [Fact(Skip = "Arrays are currently not supported by the UnitsNetJsonConverter")]
        public override void ArrayOfDoubleValueQuantities_SerializationRoundTrips()
        {
            base.ArrayOfDoubleValueQuantities_SerializationRoundTrips();
        }
        
        [Fact(Skip = "Arrays are currently not supported by the UnitsNetJsonConverter")]
        public override void ArrayOfDecimalValueQuantities_SerializationRoundTrips()
        {
            base.ArrayOfDecimalValueQuantities_SerializationRoundTrips();
        }
        
        [Fact(Skip = "Arrays are currently not supported by the UnitsNetJsonConverter")]
        public override void EmptyArray_RoundTripsEmpty()
        {
            base.EmptyArray_RoundTripsEmpty();
        }

        [Fact(Skip = "Tuples are currently not supported by the UnitsNetJsonConverter")]
        public override void TupleOfMixedValueQuantities_SerializationRoundTrips()
        {
            base.TupleOfMixedValueQuantities_SerializationRoundTrips();
        }

        [Fact(Skip = "Tuples are currently not supported by the UnitsNetJsonConverter")]
        public override void TupleOfDoubleAndNullQuantities_SerializationRoundTrips()
        {
            base.TupleOfDoubleAndNullQuantities_SerializationRoundTrips();
        }

        [Fact(Skip = "Tuples are currently not supported by the UnitsNetJsonConverter")]
        public override void TupleOfDecimalAndNullQuantities_SerializationRoundTrips()
        {
            base.TupleOfDecimalAndNullQuantities_SerializationRoundTrips();
        }
    }
}
#endif
