// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Reflection;
#if NET40 || NET35 || NET20 || SILVERLIGHT
using UniformTypeInfo = System.Type;
#else
using UniformTypeInfo = System.Reflection.TypeInfo;
#endif

// Based on
// https://github.com/StefH/ReflectionBridge/blob/c1e34e57fe3fc93507e83d5cebc1677396645397/ReflectionBridge/src/ReflectionBridge/Extensions/ReflectionBridgeExtensions.cs
// MIT license
namespace UnitsNet.InternalHelpers
{
    internal struct TypeWrapper
    {
        private readonly Type _type;

        public TypeWrapper(Type type)
        {
            _type = type;
        }

        internal Assembly Assembly => _type.ToUniformType().Assembly;
        internal bool IsEnum => _type.ToUniformType().IsEnum;
        internal bool IsClass => _type.ToUniformType().IsClass;
        internal bool IsAssignableFrom(Type other) => _type.ToUniformType().IsAssignableFrom(other.ToUniformType());
        internal bool IsValueType => _type.ToUniformType().IsValueType;

        internal PropertyInfo GetProperty(string name)
        {
#if NET40 || NET35 || NET20 || SILVERLIGHT
            return _type.GetProperty(name);
#else
            return _type.GetTypeInfo().GetDeclaredProperty(name);
#endif
        }

        internal IEnumerable<MethodInfo> GetDeclaredMethods()
        {
            var t = _type.ToUniformType();
            while (t != null)
            {
#if NET40 || NET35 || NET20 || SILVERLIGHT
                foreach (MethodInfo m in t.GetMethods())
#else
                foreach (MethodInfo m in t.DeclaredMethods)
#endif
                    yield return m;

                t = t.BaseType?.ToUniformType();
            }
        }
    }

    internal static class ReflectionBridgeExtensions
    {
        /// <summary>
        ///     Wrap the type to make it .NET agnostic using Type for old targets and the newer TypeInfo for newer targets.
        /// </summary>
        public static TypeWrapper Wrap(this Type type)
        {
            return new TypeWrapper(type);
        }

        /// <summary>
        ///     Returns the type or type info object depending on compile target, such as TypeInfo for .NET 4.5+ and Type for .NET
        ///     4.0 and older.
        ///     The APIs of these two objects are similar, but obtaining them is slightly different.
        ///     The idea is to get fewer #if pragma statements in the code.
        /// </summary>
        public static UniformTypeInfo ToUniformType(this Type type)
        {
#if NET40 || NET35 || NET20 || SILVERLIGHT
            return type;
#else
            return type.GetTypeInfo();
#endif
        }
    }
}
