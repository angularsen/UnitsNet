using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class StaticQuantityGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;

        public StaticQuantityGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
using System.Collections.Generic;

#nullable enable

namespace UnitsNet;

/// <summary>
///     Dynamically parse or construct quantities when types are only known at runtime.
/// </summary>
public partial class Quantity
{
    /// <summary>
    ///     Serves as a repository for predefined quantity conversion mappings, facilitating the automatic generation and retrieval of unit conversions in the UnitsNet library.
    /// </summary>
    internal static class Provider
    {
        /// <summary>
        ///     All QuantityInfo instances that are present in UnitsNet by default.
        /// </summary>
        internal static IReadOnlyList<QuantityInfo> DefaultQuantities => new QuantityInfo[]
        {");
            foreach (var quantity in _quantities)
                Writer.WL($@"
            {quantity.Name}.Info,");
            Writer.WL(@"
        };

        /// <summary>
        ///     All implicit quantity conversions that exist by default.
        /// </summary>
        internal static readonly IReadOnlyList<QuantityConversionMapping> DefaultConversions = new QuantityConversionMapping[]
        {");
            foreach (var quantityRelation in _quantities.SelectMany(quantity => quantity.Relations.Where(x => x.Operator == "inverse")).Distinct(new CumulativeRelationshipEqualityComparer()).OrderBy(relation => relation.LeftQuantity.Name))
                Writer.WL($@"
            new (typeof({quantityRelation.LeftQuantity.Name}), typeof({quantityRelation.RightQuantity.Name})),");
            Writer.WL(@"
        };
    }
}");
            return Writer.ToString();
        }
    }

    internal class CumulativeRelationshipEqualityComparer: IEqualityComparer<QuantityRelation>{
        public bool Equals(QuantityRelation? x, QuantityRelation? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            return
                x.ResultQuantity == y.ResultQuantity && (
                    (x.LeftQuantity.Equals(y.LeftQuantity) && x.RightQuantity.Equals(y.RightQuantity))
                    || (x.LeftQuantity.Equals(y.RightQuantity) && x.RightQuantity.Equals(y.LeftQuantity)));
        }

        public int GetHashCode(QuantityRelation obj)
        {
            return obj.LeftQuantity.GetHashCode() ^ obj.RightQuantity.GetHashCode();
        }
    }
}
