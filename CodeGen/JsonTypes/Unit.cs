// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
#pragma warning disable 8618 // 8618 Non-nullable field is uninitialized
#pragma warning disable 0649 // 0649 Field is never assigned to
namespace CodeGen.JsonTypes
{
    internal class Unit
    {

        public BaseUnits? BaseUnits;
        public string FromBaseToUnitFunc;
        public string FromUnitToBaseFunc;
        public Localization[] Localization = Array.Empty<Localization>();
        public string PluralName;
        public Prefix[] Prefixes = Array.Empty<Prefix>();
        public string[] UnitSystems = Array.Empty<string>();
        public string SingularName;
        public string XmlDocRemarks;
        public string XmlDocSummary;
        public string ObsoleteText;
    }
}
