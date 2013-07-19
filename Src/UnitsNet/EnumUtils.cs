// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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
using System.Linq;
using System.Reflection;

namespace UnitsNet
{
    /// <summary>
    /// </summary>
    /// <remarks>WinRT does not support Enum enumeration.</remarks>
    public static class EnumUtils
    {
        public static T[] GetEnumValues<T>()
        {
#if NETFX_CORE
            return GetEnumValuesWinRT<T>();
#else
            Type type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("Type '" + type.Name + "' is not an enum");

            return (
                       from field in type.GetFields(BindingFlags.Public | BindingFlags.Static)
                       where field.IsLiteral
                       select (T)field.GetValue(null)
                   ).ToArray();
#endif
        }

        private static T[] GetEnumValuesWinRT<T>()
        {
#if NETFX_CORE
            // using System.Reflection;
            var values = typeof (T)
                .GetRuntimeProperties()
                .Select(c => (T) c.GetValue(null));

            return values.ToArray(); 
#else
            throw new NotImplementedException();
#endif
        }

        //public static string[] GetEnumNames<T>()
        //{
        //    // using System.Reflection;
        //    var names = typeof (T)
        //        .GetRuntimeProperties()
        //        .Select(c => c.Name);

        //    return names.ToArray();
        //}
    }
}