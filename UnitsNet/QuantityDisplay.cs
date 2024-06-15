using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace UnitsNet;

/// <summary>
///     Serves as a debug display proxy for a quantity, providing a convenient way to view various components of the
///     quantity during debugging.
/// </summary>
/// <remarks>
///     This struct provides a structured view of a quantity's components such as abbreviation, unit, value, and convertor
///     during debugging.
///     Each component is represented by a nested struct, which can be expanded in the debugger to inspect its properties.
/// </remarks>
internal readonly struct QuantityDisplay(IQuantity quantity)
{
    public UnitDisplay Unit => new(quantity);
    public AbbreviationDisplay UnitAbbreviation => new(quantity);
    public ValueDisplay Value => new(quantity);
    public QuantityConvertor ValueConvertor => new(quantity);


    [DebuggerDisplay("{DefaultAbbreviation}")]
    internal readonly struct AbbreviationDisplay
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IQuantity _quantity;

        public AbbreviationDisplay(IQuantity quantity)
        {
            _quantity = quantity;
            QuantityInfo quantityQuantityInfo = quantity.QuantityInfo;
            IQuantity baseQuantity = quantity.ToUnit(quantityQuantityInfo.BaseUnitInfo.Value);
            Conversions = quantityQuantityInfo.UnitInfos.Select(x => new ConvertedQuantity(baseQuantity, x.Value)).ToArray();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string DefaultAbbreviation => UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(_quantity.Unit);

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public string[] Abbreviations =>
            UnitsNetSetup.Default.UnitAbbreviations.GetUnitAbbreviations(_quantity.QuantityInfo.UnitType, Convert.ToInt32(_quantity.Unit));

        public ConvertedQuantity[] Conversions { get; }

        [DebuggerDisplay("{Abbreviation}")]
        internal readonly struct ConvertedQuantity(IQuantity baseQuantity, Enum unit)
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public Enum Unit { get; } = unit;

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public IQuantity Quantity => baseQuantity.ToUnit(Unit);

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public string Abbreviation => UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(Unit);

            public override string ToString()
            {
                return Abbreviation;
            }
        }
    }

    [DebuggerDisplay("{Unit}")]
    internal readonly struct UnitDisplay
    {
        public UnitDisplay(IQuantity quantity)
        {
            Unit = quantity.Unit;
            IQuantity baseQuantity = quantity.ToUnit(quantity.QuantityInfo.BaseUnitInfo.Value);
            Conversions = quantity.QuantityInfo.UnitInfos.Select(x => new ConvertedQuantity(baseQuantity, x.Value)).ToArray();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Enum Unit { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public ConvertedQuantity[] Conversions { get; }

        internal readonly struct ConvertedQuantity(IQuantity baseQuantity, Enum unit)
        {
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public IQuantity Quantity => baseQuantity.ToUnit(unit);

            public override string ToString()
            {
                return unit.ToString();
            }
        }
    }

    [DebuggerDisplay("{DoubleValue}")]
    internal readonly struct ValueDisplay(IQuantity quantity)
    {
        public bool IsDecimal => quantity.Value.IsDecimal;
        public double DoubleValue => (double)quantity.Value;
        public decimal DecimalValue => (decimal)quantity.Value;

        public override string ToString()
        {
            return IsDecimal ? DecimalValue.ToString(CultureInfo.CurrentCulture) : DoubleValue.ToString(CultureInfo.CurrentCulture);
        }
    }

    [DebuggerDisplay("{QuantityToString}")]
    internal readonly struct QuantityConvertor
    {
        public QuantityConvertor(IQuantity quantity)
        {
            QuantityToString = new StringFormatsDisplay(quantity);
            QuantityInfo quantityQuantityInfo = quantity.QuantityInfo;
            IQuantity baseQuantity = quantity.ToUnit(quantityQuantityInfo.BaseUnitInfo.Value);
            QuantityToUnit = quantityQuantityInfo.UnitInfos.Select(x => new ConvertedQuantity(baseQuantity.ToUnit(x.Value))).ToArray();
        }

        public StringFormatsDisplay QuantityToString { get; }
        public ConvertedQuantity[] QuantityToUnit { get; }

        [DebuggerDisplay("{ShortFormat}")]
        internal readonly struct StringFormatsDisplay(IQuantity quantity)
        {
            public string GeneralFormat => quantity.ToString("g", CultureInfo.CurrentCulture);
            public string ShortFormat => quantity.ToString("s", CultureInfo.CurrentCulture);
        }

        [DebuggerDisplay("{Quantity}")]
        internal readonly struct ConvertedQuantity(IQuantity quantity)
        {
            public Enum Unit => Quantity.Unit;
            public string Abbreviation => UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(Quantity.Unit);
            public ValueDisplay Value => new(Quantity);
            public IQuantity Quantity { get; } = quantity;

            public override string ToString()
            {
                return Quantity.ToString()!;
            }
        }
    }
}
