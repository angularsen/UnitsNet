// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    /// <summary>
    ///     The base type for UnitsNet exceptions.
    /// </summary>
    public class UnitsNetException : Exception
    {
        /// <summary>
        ///     Key used in <see cref="Exception.Data" /> for stable UnitsNet error codes.
        /// </summary>
        public const string ErrorCodeDataKey = "errorCode";

        /// <inheritdoc />
        public UnitsNetException()
        {
            HResult = 1;
        }

        /// <inheritdoc />
        public UnitsNetException(string message) : base(message)
        {
            HResult = 1;
        }

        /// <inheritdoc />
        public UnitsNetException(string message, Exception innerException) : base(message, innerException)
        {
            HResult = 1;
        }
    }
}
