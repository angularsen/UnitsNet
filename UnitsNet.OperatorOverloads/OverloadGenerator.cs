using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsNet.OperatorOverloads
{
    public class OverloadGenerator
    {
        private readonly Quantity[] _quantities;

        public OverloadGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public IEnumerable<Overload> GetDivisionOverloads(Quantity quantity)
        {
            foreach (Quantity q in _quantities)
            {
                if (!quantity.Name.Equals(q.Name,StringComparison.OrdinalIgnoreCase))
                {
                    var newSiArray = quantity.SiArray.ElementwiseSubtract(q.SiArray);

                    Quantity matchingQuantity = _quantities.SingleOrDefault(x => x.SiArray.EqualContent(newSiArray));
                    if (matchingQuantity != null)
                    {
                        yield return new Overload(matchingQuantity, q, quantity);
                    }
                }
            }
        }

        public IEnumerable<Overload> GetMultiplicationOverloads(Quantity quantity)
        {
            foreach (Quantity q in _quantities)
            {
                if (!quantity.Name.Equals(q.Name, StringComparison.OrdinalIgnoreCase))
                {
                    var newSiArray = quantity.SiArray.ElementwiseAdd(q.SiArray);

                    Quantity matchingQuantity = _quantities.SingleOrDefault(x => x.SiArray.EqualContent(newSiArray));
                    if (matchingQuantity != null)
                    {
                        yield return new Overload(matchingQuantity, q, quantity);
                    }
                }
            }
        }

        public IEnumerable<Overload> GetOverloads(Quantity quantity)
        {
            var multiplications = GetMultiplicationOverloads(quantity);
            foreach (var multiplication in multiplications)
            {
                yield return multiplication;
                yield return new Overload(multiplication.Result, multiplication.Right, multiplication.Left);
            }
            var divisions = GetDivisionOverloads(quantity);
            foreach (var division in divisions)
            {
                yield return division;
            }
        }
    }
}
