// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Serialization.JsonNet.Tests.Infrastructure
{
    public sealed class TestObjectWithValueAndUnitAsIComparable : IComparable
    {
        public double Value { get; set; }
        public string Unit { get; set; }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }
    }
}
