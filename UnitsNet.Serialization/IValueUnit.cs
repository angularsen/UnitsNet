// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Serialization
{
    /// <summary>
    ///     A structure used to serialize/deserialize Units.NET unit instances.
    /// </summary>
    public interface IValueUnit
    {
        /// <summary>
        ///     The unit of the value.
        /// </summary>
        /// <example>MassUnit.Pound</example>
        /// <example>InformationUnit.Kilobyte</example>
        public string Unit { get; }

        /// <summary>
        ///     The value.
        /// </summary>
        public double Value { get; }
    }

    /// <summary>
    ///     A structure used to serialize/deserialize non-double Units.NET unit instances.
    /// </summary>
    /// <remarks>
    ///     This type was added for lossless serialization of quantities with <see cref="decimal"/> values.
    ///     The <see cref="decimal"/> type distinguishes between 100 and 100.00 but Json.NET does not, therefore we serialize decimal values as string.
    /// </remarks>
    public interface IExtendedValueUnit: IValueUnit
    {
        /// <summary>
        ///     The value as a string.
        /// </summary>
        public string ValueString { get; }

        /// <summary>
        ///     The type of the value, e.g. "decimal".
        /// </summary>
        public string ValueType { get; }
    }
}
