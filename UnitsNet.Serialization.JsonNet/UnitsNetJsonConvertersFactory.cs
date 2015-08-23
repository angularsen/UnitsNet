// Copyright Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace UnitsNet.Serialization.JsonNet
{
    /// <summary>
    /// A factory for creating a collection of all available UnitsNet JSON converters.
    /// </summary>
    public class UnitsNetJsonConvertersFactory
    {
        private static IList<JsonConverter> _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitsNetJsonConvertersFactory"/> class.
        /// </summary>
        public UnitsNetJsonConvertersFactory()
        {
            _cache = new List<JsonConverter>();
        }

        /// <summary>
        /// Creates a collection of UnitsNet JSON converters.
        /// </summary>
        public IEnumerable<JsonConverter> Create()
        {
            if (_cache.Count == 0)
                BuildCache();

            return _cache;
        }

        #region Helper Methods

        /// <summary>
        /// Builds the cache of UnitsNet JSON converters by loading the currently executing assembly in order to use reflection 
        /// to find all types inherited from <see cref="JsonConverter"/>. Each type is then constructed and added to <see cref="_cache"/>.
        /// </summary>
        protected void BuildCache()
        {
            foreach (var type in GetJsonConverterTypes())
            {
                var unitsNetJsonConverter = CreateJsonConverter(type);
                if (unitsNetJsonConverter == null)
                    continue;

                _cache.Add(unitsNetJsonConverter);
            }
        }

        /// <summary>
        /// Gets a collection of types representing UnitsNet JSON converters.
        /// </summary>
        protected virtual IEnumerable<Type> GetJsonConverterTypes()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            return assembly.GetTypes()
                           .Where(t => t.BaseType.IsAssignableFrom(typeof(JsonConverter)));
        }

        /// <summary>
        /// Creates a <see cref="JsonConverter"/> instance from the specified type.
        /// </summary>
        /// <param name="type">The type representing a UnitsNet JSON converter.</param>
        protected virtual JsonConverter CreateJsonConverter(Type type)
        {
            return Activator.CreateInstance(type) as JsonConverter;
        }

        #endregion
    }
}
