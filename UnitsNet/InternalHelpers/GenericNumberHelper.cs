// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;

namespace UnitsNet.InternalHelpers
{
    /// <summary>
    /// Helpers for working with generic numbers.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class GenericNumberHelper<T> where T : struct
    {
        private static readonly Dictionary<Type, GenericNumberInfo> TypeToInfo;

        static GenericNumberHelper()
        {
            TypeToInfo = new Dictionary<Type, GenericNumberInfo>
            {
                {typeof(int), new GenericNumberInfo(int.MaxValue, int.MinValue)},
                {typeof(long), new GenericNumberInfo(long.MaxValue, long.MinValue)},
                {typeof(double), new GenericNumberInfo(double.MaxValue, double.MinValue)},
                {typeof(decimal), new GenericNumberInfo(decimal.MaxValue, decimal.MinValue)},
            };
        }

        public static T MaxValue => (T) TypeToInfo[typeof(T)].MaxValue;
        public static T MinValue => (T) TypeToInfo[typeof(T)].MinValue;

        private class GenericNumberInfo
        {
            public GenericNumberInfo(object maxValue, object minValue)
            {
                MaxValue = maxValue;
                MinValue = minValue;
            }

            public object MaxValue { get; }
            public object MinValue { get; }
        }
    }
}
