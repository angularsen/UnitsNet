using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsNet.OperatorOverloads
{
    public class Overload
    {
        public Quantity Result { get; }
        public Quantity Left { get; }
        public Quantity Right { get; }

        public Overload(Quantity result, Quantity left, Quantity right)
        {
            Result = result;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return $"{nameof(Result)}: {Result}, {nameof(Left)}: {Left}, {nameof(Right)}: {Right}";
        }
    }
}
