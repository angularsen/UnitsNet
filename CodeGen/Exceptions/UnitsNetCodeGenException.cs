// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Runtime.Serialization;

namespace CodeGen.Exceptions
{
    internal class UnitsNetCodeGenException : Exception
    {
        public UnitsNetCodeGenException()
        {
        }

        protected UnitsNetCodeGenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnitsNetCodeGenException(string message) : base(message)
        {
        }

        public UnitsNetCodeGenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
