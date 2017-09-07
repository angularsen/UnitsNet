using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitsNet.OperatorOverloads
{
    public class OverloadGenerator
    {
        private readonly Quantity[] _quantities;

        public OverloadGenerator(string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*.json");
            _quantities = files.Select(f => JsonConvert.DeserializeObject<Quantity>(File.ReadAllText(f))).ToArray();
            if (_quantities.Length == 0)
            {
                throw new InvalidOperationException($"{files}");
            }
        }

        public OverloadGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public IEnumerable<Overload> GetDivisionOverloads(Quantity quantity)
        {
            if (quantity.SiArray == null)
                yield break;
            foreach (Quantity q in _quantities)
            {
                if (q.SiArray == null)
                    continue;
                if (!quantity.Name.Equals(q.Name,StringComparison.OrdinalIgnoreCase))
                {
                    var newSiArray = quantity.SiArray.ElementwiseSubtract(q.SiArray);

                    Quantity matchingQuantity = _quantities.SingleOrDefault(x => x.SiArray.EqualContent(newSiArray));
                    if (matchingQuantity != null)
                    {
                        yield return new Overload(matchingQuantity, quantity, q);
                    }
                }
            }
        }

        public IEnumerable<Overload> GetMultiplicationOverloads(Quantity quantity)
        {
            if (quantity.SiArray == null)
                yield break;
            foreach (Quantity q in _quantities)
            {
                if (!quantity.Name.Equals(q.Name, StringComparison.OrdinalIgnoreCase))
                {
                    if (q.SiArray == null)
                        continue;
                    var newSiArray = quantity.SiArray.ElementwiseAdd(q.SiArray);

                    Quantity matchingQuantity = _quantities.SingleOrDefault(x => x.SiArray.EqualContent(newSiArray));
                    if (matchingQuantity != null)
                    {
                        yield return new Overload(matchingQuantity, q, quantity);
                    }

                }
            }
        }

        public IReadOnlyList<Quantity> Quantities => _quantities;

        public int NumberOfQuantities => _quantities.Length;

        public Quantity GetQuantityByName(string name)
        {
            return _quantities.Single(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
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
