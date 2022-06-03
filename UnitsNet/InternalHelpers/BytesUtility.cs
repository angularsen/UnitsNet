// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Runtime.InteropServices;

namespace UnitsNet.InternalHelpers
{
    /// <summary>
    ///     Utility methods for working with the byte representation of structs.
    /// </summary>
    internal static class BytesUtility
    {
        /// <summary>
        ///     Converts the given <paramref name="value"/> to an array of its underlying bytes.
        /// </summary>
        /// <typeparam name="T">The struct type.</typeparam>
        /// <param name="value">The struct value to convert.</param>
        /// <returns>A byte array representing a copy of <paramref name="value"/>s bytes.</returns>
        internal static byte[] GetBytes<T>(T value) where T : struct
        {
            int size = Marshal.SizeOf(value);
            byte[] array = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(value, ptr, true);
                Marshal.Copy(ptr, array, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return array;
        }
    }
}
