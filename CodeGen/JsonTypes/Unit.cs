// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace CodeGen.JsonTypes
{
    internal class Unit
    {
        // 0649 Field is never assigned to
#pragma warning disable 0649

        public BaseUnits? BaseUnits;
        public string FromBaseToUnitFunc = null!;
        public string FromUnitToBaseFunc = null!;
        public Localization[] Localization = Array.Empty<Localization>();
        public string PluralName = null!;
        public Prefix[] Prefixes = Array.Empty<Prefix>();
        public string SingularName = null!;
        public string? XmlDocRemarks;
        public string XmlDocSummary = null!;
        public string? ObsoleteText;
        public bool SkipConversionGeneration;
        public bool AllowAbbreviationLookup = true;

        // 0649 Field is never assigned to
#pragma warning restore 0649
    }
}
