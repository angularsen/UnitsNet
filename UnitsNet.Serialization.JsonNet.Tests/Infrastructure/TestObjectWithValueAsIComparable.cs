// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Serialization.JsonNet.Tests.Infrastructure
{
    public sealed class TestObjectWithValueAsIComparable : IComparable
    {
        public int Value { get; set; }

        public int CompareTo(object obj)
        {
            return ((IComparable)Value).CompareTo(obj);
        }

        // Needed for verifying that the deserialized object is the same, should not affect the serialization code
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((TestObjectWithValueAsIComparable)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
