using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsNet.OperatorOverloads
{
    public static class ArrayExtensions
    {
        public static int[] ElementwiseSubtract(this int[] left, int[] right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Arrays must have the same length");
            }
            var result = new int[left.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = left[i] - right[i];
            }
            return result;
        }

        public static int[] ElementwiseAdd(this int[] left, int[] right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException("Arrays must have the same length");
            }
            var result = new int[left.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = left[i] + right[i];
            }
            return result;
        }


        public static bool EqualContent<T>(this T[] left, T[] right)
        {
            if (left == default(T[]))
            {
                throw new ArgumentNullException(nameof(left));    
            }
            if (right == default(T[]))
            {
                return false;
            }
            if (left.Length != right.Length)
            {
                return false;
            }
            for (int i = 0; i < left.Length; i++)
            {
                if (!left[i].Equals(right[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
