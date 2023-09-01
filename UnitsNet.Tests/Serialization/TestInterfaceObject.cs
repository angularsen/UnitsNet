// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Runtime.Serialization;

namespace UnitsNet.Tests.Serialization
{
    /// <summary>
    ///     A test object used for testing the serialization schema to and from an object containing a <i>generic</i> quantity
    ///     (see <see cref="IQuantity" />).
    ///     <remarks>
    ///         The [KnownAttributes] are required for the DataContractSerializers. You could also provide those to the
    ///         serializer settings: e.g. KnownTypes = Quantity.Infos.Select(x => x.ValueType)
    ///     </remarks>
    /// </summary>
    [DataContract]
    [KnownType(typeof(Mass))]
    [KnownType(typeof(Information))]
    public class TestInterfaceObject
    {
        [DataMember]
        public IQuantity Quantity { get; set; } = null!;
    }
}
