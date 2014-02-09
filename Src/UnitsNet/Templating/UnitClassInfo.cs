using System;
using System.Collections.Generic;

namespace UnitsNet.Templating
{
    public class UnitClassInfo
    {
        public readonly string UnitClassName;
        public readonly string UnitClassXmlDoc; 
        public readonly Type UnitEnumType;
        public readonly string BaseUnitName;
        public readonly string BaseUnitPluralName;
        public readonly ICollection<UnitInfo> OrderedUnits;

        public UnitClassInfo(string unitClassName, string unitClassXmlDoc, string baseUnitName, string baseUnitPluralName, ICollection<UnitInfo> orderedUnits, Type unitEnumType)
        {
            UnitClassName = unitClassName;
            UnitClassXmlDoc = unitClassXmlDoc;
            BaseUnitName = baseUnitName;
            BaseUnitPluralName = baseUnitPluralName;
            OrderedUnits = orderedUnits;
            UnitEnumType = unitEnumType;
        }

    }
}