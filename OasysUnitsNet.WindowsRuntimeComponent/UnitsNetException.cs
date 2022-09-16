// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace OasysUnitsNet
{
    internal class OasysUnitsNetException : Exception
    {
        public OasysUnitsNetException()
        {
            HResult = 1;
        }

        public OasysUnitsNetException(string message) : base(message)
        {
            HResult = 1;
        }

        public OasysUnitsNetException(string message, Exception innerException) : base(message, innerException)
        {
            HResult = 1;
        }
    }
}
