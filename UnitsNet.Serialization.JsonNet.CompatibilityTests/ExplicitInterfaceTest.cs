using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace UnitsNet.Serialization.JsonNet.CompatibilityTests
{
    public class ExplicitInterfaceTest
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public ExplicitInterfaceTest()
        {
            _jsonSerializerSettings = new JsonSerializerSettings { Formatting = Formatting.None };
            _jsonSerializerSettings.Converters.Add(new UnitsNetJsonConverter());
        }

        private string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, typeof(IName), _jsonSerializerSettings).Replace("\r\n", "\n");
        }

        public interface IName
        {
            public string Name
            {
                get;
            }
        }

        internal class SomeObject : IName
        {
            public int Id
            {
                get; set;
            }

            public string Name => "Foo";

            string IName.Name => "MyName";
        }

        [Fact]
        public void TestExplicitInterface()
        {
            IName s = new SomeObject()
            {
                Id = 2
            };

            var expectedJson = "{\"Id\":2,\"Name\":\"Foo\"}";

            string json = SerializeObject(s);

            Assert.Equal(expectedJson, json);
        }
    }
}
