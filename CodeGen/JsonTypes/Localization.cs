// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace CodeGen.JsonTypes
{
    internal class Localization
    {
        // 0649 Field is never assigned to
#pragma warning disable 0649
        public string[] Abbreviations = Array.Empty<string>();
        public string[] AbbreviationsWithPrefixes = Array.Empty<string>();
        public string Culture;
        // 0649 Field is never assigned to
#pragma warning restore 0649
    }
}
