// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnitsNet.Attributes;

namespace UnitsNet
{
    public enum OtherUnit
    {
        [I18n("en-US", "(undefined)")]
        [I18n("ru-RU", "(нет ед.изм.)")]
        [I18n("nb-NO", "(ingen)")]
        Undefined = 0,

        // Generic / Other
        [I18n("en-US", "piece", "pieces", "pcs", "pcs.", "pc", "pc.", "pce", "pce.")]
        [I18n("ru-RU", "штук")] 
        [I18n("nb-NO", "stk", "stk.", "x")]
        Piece,

        [I18n("en-US", "%")]
        Percent,

        // Cooking units
        // TODO Move to volume?
        [I18n("en-US", "Tbsp", "Tbs", "T", "tb", "tbs", "tbsp", "tblsp", "tblspn", "Tbsp.", "Tbs.", "T.", "tb.", "tbs.", "tbsp.", "tblsp.", "tblspn.", "tablespoon", "Tablespoon")]
        [I18n("ru-RU", "столовая ложка")] 
        [I18n("nb-NO", "ss", "ss.", "SS", "SS.")] 
        Tablespoon,

        [I18n("en-US", "tsp","t", "ts", "tspn", "t.", "ts.", "tsp.", "tspn.", "teaspoon")]
        [I18n("ru-RU", "чайная ложка")] 
        [I18n("nb-NO", "ts", "ts.")]
        Teaspoon,
    }
}