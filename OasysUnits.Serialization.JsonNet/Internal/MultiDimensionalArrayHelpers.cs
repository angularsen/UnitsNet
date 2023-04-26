using System;
using System.Linq;

namespace OasysUnits.Serialization.JsonNet.Internal
{

    /// <summary>
    ///     Helper class for working with and manipulating multi-dimension arrays based on their generic index.
    /// </summary>
    internal static class MultiDimensionalArrayHelpers
    {

        /// <summary>
        /// Returns a new array of same Rank and Length as <paramref name="array"/> but with each element converted to <typeparamref name="TResult"/>
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static Array ConvertArrayElements<TResult>(Array array)
        {
            var ret = Array.CreateInstance(typeof(TResult), LastIndex(array));
            var ind = FirstIndex(array);

            while (ind != null)
            {
                ret.SetValue((TResult)array.GetValue(ind), ind);
                ind = NextIndex(array, ind);
            }

            return ret;
        }

        /// <summary>
        /// Returns the index for the 'first' element in a multidimensional array.
        ///
        /// 'First' is defined as the <see cref="Array.GetLowerBound(int)"/> for each rank of the <paramref name="array"/>
        ///
        /// E.g., for a zero-based 5x5x5 array this method would return [0, 0, 0].
        /// </summary>
        /// <param name="array"></param>
        /// <returns>1D integer array specifying the location of the first element in the multidimensional array</returns>
        public static int[] FirstIndex(Array array)
        {
            return Enumerable.Range(0, array.Rank).Select(x => array.GetLowerBound(x)).ToArray();
        }

        /// <summary>
        /// Returns the index for the 'last' element in a multidimensional array.
        ///
        /// 'Last' is defined as the <see cref="Array.GetUpperBound(int)"/> for each rank of the <paramref name="array"/>
        ///
        /// E.g., for a zero-based 5x5x5 array this method would return [4, 4, 4].
        /// </summary>
        /// <param name="array"></param>
        /// <returns>1D integer array specifying the location of the last element in the multidimensional array</returns>
        public static int[] LastIndex(Array array)
        {
            return Enumerable.Range(0, array.Rank).Select(x => array.GetUpperBound(x) + 1).ToArray();
        }

        /// <summary>
        /// Returns the 'next' index after the specified multidimensional <paramref name="index"/>
        ///
        /// The 'next' index is determined by first looping through all elements in the first dimension of the array, then moving on to the next dimension and repeating        
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns>Returns the index location of the next element in <paramref name="array"/> after <paramref name="index"/> as a 1D array of integers.  If there is no next index, returns null</returns>
        public static int[]? NextIndex(Array array, int[] index)
        {
            for (var i = 0; i < index.Length; i++)
            {
                index[i] += 1;

                if (index[i] <= array.GetUpperBound(i))
                {
                    return index;
                }
                else
                {
                    index[i] = array.GetLowerBound(i);
                }
            }

            return null;
        }
    }
}
