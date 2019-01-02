// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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

using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Reflection;

[assembly: InternalsVisibleTo("UnitsNet.Serialization.JsonNet, PublicKey=002400000480000094000000060200000024000052534131000400000100010089abdcb0025f7d1c4c766686dd852b978ca5bb9fd80bba9d3539e8399b01170ae0ea10c0c3baa301b1d13090d5aff770532de00c88b67c4b24669fde7f9d87218f1c6c073a09016cbb2f87119b94227c2301f4e2a096043e30f7c47c872bbd8e0b80d924952e6b36990f13f847e83e9efb107ec2121fe39d7edaaa4e235af8c4")]

// Based on
// https://github.com/StefH/ReflectionBridge/blob/c1e34e57fe3fc93507e83d5cebc1677396645397/ReflectionBridge/src/ReflectionBridge/Extensions/ReflectionBridgeExtensions.cs
// MIT license
namespace UnitsNet.InternalHelpers
{
    internal static class ReflectionBridgeExtensions
    {
        internal static Assembly GetAssembly(this Type type)
        {
#if !(NET40 || NET35 || NET20 || SILVERLIGHT)
            return type.GetTypeInfo().Assembly;
#else
            return type.Assembly;
#endif
        }

        internal static bool IsEnum(this Type type)
        {
#if !(NET40 || NET35 || NET20 || SILVERLIGHT)
            return type.GetTypeInfo().IsEnum;
#else
            return type.IsEnum;
#endif
        }

        internal static bool IsValueType(this Type type)
        {
#if !(NET40 || NET35 || NET20 || SILVERLIGHT)
            return type.GetTypeInfo().IsValueType;
#else
            return type.IsValueType;
#endif
        }

        internal static PropertyInfo GetPropety(this Type type, string name)
        {
#if (NET40 || NET35 || NET20 || SILVERLIGHT)
            return type.GetProperty(name);

#else
            return type.GetTypeInfo().GetDeclaredProperty(name);
#endif
        }

#if !(NET40 || NET35 || NET20 || SILVERLIGHT)
        // Ambiguous method conflict with GetMethods() name when targeting WindowsRuntimeComponent, so use GetDeclaredMethods() instead
        internal static IEnumerable<MethodInfo> GetDeclaredMethods(this Type someType)
        {
            Type t = someType;
            while (t != null)
            {
                TypeInfo ti = t.GetTypeInfo();
                foreach (MethodInfo m in ti.DeclaredMethods)
                    yield return m;
                t = ti.BaseType;
            }
        }
#else
// Ambiguous method conflict with GetMethods() name WindowsRuntimeComponent, so use GetDeclaredMethods() instead
        internal static IEnumerable<MethodInfo> GetDeclaredMethods(this Type someType)
        {
            Type t = someType;
            while (t != null)
            {
                foreach (MethodInfo m in t.GetMethods())
                    yield return m;
                t = t.BaseType;
            }
        }
#endif
    }
}
