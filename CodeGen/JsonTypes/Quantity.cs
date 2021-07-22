// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
#pragma warning disable 8618 // 8618 Non-nullable field is uninitialized
#pragma warning disable 0649 // 0649 Field is never assigned to
namespace CodeGen.JsonTypes
{
    internal class Quantity
    {
        public BaseDimensions BaseDimensions = new BaseDimensions(); // Default to empty
        public string BaseType = "double"; // TODO Rename to ValueType
        public string BaseUnit; // TODO Rename to DefaultUnit or IntermediateConversionUnit to avoid confusion with Unit.BaseUnits
        public bool GenerateArithmetic = true;
        public bool Logarithmic = false;
        public int LogarithmicScalingFactor = 1;
        public string Name;
        public Unit[] Units = Array.Empty<Unit>();
        public UnitSystemMapping[] UnitSystems = Array.Empty<UnitSystemMapping>();
        public string XmlDocRemarks;
        public string XmlDoc; // TODO Rename to XmlDocSummary
        public string ObsoleteText;
    }
}
