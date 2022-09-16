// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Runtime.Serialization;

namespace CodeGen.Exceptions
{
    internal class OasysUnitsNetCodeGenException : Exception
    {
        public OasysUnitsNetCodeGenException()
        {
        }

        protected OasysUnitsNetCodeGenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public OasysUnitsNetCodeGenException(string message) : base(message)
        {
        }

        public OasysUnitsNetCodeGenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
