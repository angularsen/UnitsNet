// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace CodeGen.JsonTypes
{
    internal class Quantity
    {
        // 0649 Field is never assigned to
#pragma warning disable 0649

        public BaseDimensions BaseDimensions = new(); // Default to empty
        public string ValueType = "double";
        public string BaseUnit = null!;
        public bool GenerateArithmetic = true;
        public bool Logarithmic = false;
        public int LogarithmicScalingFactor = 1;
        public string Name = null!;
        public Unit[] Units = Array.Empty<Unit>();
        public string? XmlDocRemarks;
        public string XmlDocSummary = null!;
        public string? ObsoleteText;

        // 0649 Field is never assigned to
#pragma warning restore 0649
    }
}
