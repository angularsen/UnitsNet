using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitsNet.Serialization.JsonNet.Internal
{
    /// <summary>
    ///     Helper for dealing with reflection, abstracting API differences between old and new .NET framework.
    /// </summary>
    internal static class ReflectionHelper
    {
        internal static PropertyInfo GetProperty(this Type type, string name)
        {
#if (NET40)
            return type.GetProperty(name);

#else
            return type.GetTypeInfo().GetDeclaredProperty(name);
#endif
        }

#if NET40
// Ambiguous method conflict with GetMethods() name WindowsRuntimeComponent, so use GetDeclaredMethods() instead
        internal static IEnumerable<MethodInfo> GetDeclaredMethods(this Type someType)
        {
            Type t = someType;
            while (t != null)
            {
                foreach (var m in t.GetMethods())
                    yield return m;
                t = t.BaseType;
            }
        }
#else
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
#endif
    }
}
