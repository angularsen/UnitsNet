using System;
using UnitsNet.Attributes;

namespace UnitsNet.Templating
{
    public class UnitEnumValueInfo
    {
        public readonly IUnitAttribute UnitAttribute;
        public readonly Type UnitEnumType;
        public readonly Enum Value;

        public UnitEnumValueInfo(IUnitAttribute unitAttribute, Type unitEnumType, Enum value)
        {
            UnitAttribute = unitAttribute;
            UnitEnumType = unitEnumType;
            Value = value;
        }
    }
}