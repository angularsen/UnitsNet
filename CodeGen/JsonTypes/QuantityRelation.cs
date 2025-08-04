// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace CodeGen.JsonTypes
{
    internal record QuantityRelation : IComparable<QuantityRelation>
    {
        public bool NoInferredDivision = false;

        /// <summary>Whether this is a relation between two quantities that are the inverse of each other, such as <c>double = Length.Meter * ReciprocalLength.InverseMeter -- Inverse</c>.</summary>
        public bool IsInverse = false;

        /// <summary>Whether this relation is derived from another relation, such as obtaining division from a multiplication definition. Can be used to treat the original definitions differently.</summary>
        public bool IsDerived = false;

        public string Operator = null!;

        public Quantity LeftQuantity = null!;
        public Unit LeftUnit = null!;

        public Quantity RightQuantity = null!;
        public Unit RightUnit = null!;

        public Quantity ResultQuantity = null!;
        public Unit ResultUnit = null!;

        public string SortString => ResultQuantity.Name + PrependDot(ResultUnit.SingularName)
                                  + " = "
                                  + LeftQuantity.Name + PrependDot(LeftUnit.SingularName)
                                  + " " + Operator + " "
                                  + RightQuantity.Name + PrependDot(RightUnit.SingularName);

        public int CompareTo(QuantityRelation? other)
        {
            return string.Compare(SortString, other?.SortString, StringComparison.Ordinal);
        }

        private static string PrependDot(string? s) => s == null ? string.Empty : "." + s;
    }
}
