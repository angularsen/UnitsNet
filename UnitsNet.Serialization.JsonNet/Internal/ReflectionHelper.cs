// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
#if (NET40 || NET35 || NET20 || SILVERLIGHT)
            return type.GetProperty(name);

#else
            return type.GetTypeInfo().GetDeclaredProperty(name);
#endif
        }

        internal static IEnumerable<MethodInfo> GetDeclaredMethods(this Type someType)
        {
            var t = someType;
            while (t != null)
            {
#if (NET40 || NET35 || NET20 || SILVERLIGHT)
                foreach (var m in t.GetMethods())
                {
                    yield return m;
                }

                t = t.BaseType;
#else
                var ti = t.GetTypeInfo();
                foreach (var m in ti.DeclaredMethods)
                {
                    yield return m;
                }

                t = ti.BaseType;
#endif
            }
        }
    }
}
