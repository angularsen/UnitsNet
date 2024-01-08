// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace CodeGen.JsonTypes
{
    internal record QuantityRelation
    {
        public string Operator = null!;

        public Quantity LeftQuantity = null!;
        public Unit LeftUnit = null!;

        public Quantity RightQuantity = null!;
        public Unit RightUnit = null!;

        public Quantity ResultQuantity = null!;
        public Unit ResultUnit = null!;
    }
}