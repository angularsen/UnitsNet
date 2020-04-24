// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;

namespace UnitsNet.Tests
{
    public static class EnumUtils
    {
        public static T[] GetEnumValues<T>()
        {
            return Enum.GetValues(typeof (T)).Cast<T>().ToArray();
        }
    }
}
