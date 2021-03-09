// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.IO;
using System.Runtime.Serialization.Json;

namespace UnitsNet.Serialization.DataContract.Tests.DataContractJsonSerializerTests
{
    public abstract class DataContractJsonSerializerTestsBase : SerializationTestsBase<string>
    {
        private readonly DataContractJsonSerializerSettings _settings;

        protected DataContractJsonSerializerTestsBase()
        {
        }

        protected DataContractJsonSerializerTestsBase(DataContractJsonSerializerSettings settings)
        {
            _settings = settings;
        }

        protected override string SerializeObject(object obj)
        {
            var serializer = new DataContractJsonSerializer(obj.GetType(), _settings);
            using var stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            using var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        protected override T DeserializeObject<T>(string xml)
        {
            var serializer = new DataContractJsonSerializer(typeof(T), _settings);
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.Write(xml);
            writer.Flush();
            stream.Position = 0;
            return (T) serializer.ReadObject(stream);
        }
    }
}
