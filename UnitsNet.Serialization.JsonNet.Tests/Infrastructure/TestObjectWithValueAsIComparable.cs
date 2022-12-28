// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics.CodeAnalysis;

namespace UnitsNet.Serialization.JsonNet.Tests.Infrastructure
{
    public sealed class TestObjectWithValueAsIComparable : IComparable
    {
        public int Value { get; set; }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
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

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
