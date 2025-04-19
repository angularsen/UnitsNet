// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET
using System.Collections.Frozen;
#else
using System.Linq;
#endif
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UnitsNet;

internal sealed class FrozenQuantityConverter : UnitConverter
{
#if NET
    private readonly FrozenDictionary<UnitConversionKey, ConvertValueDelegate> _unitConversions;
    private readonly FrozenDictionary<QuantityConversionKey, QuantityConversionFunction> _quantityConversions;
#else
    private readonly Dictionary<UnitConversionKey, ConvertValueDelegate> _unitConversions;
    private readonly Dictionary<QuantityConversionKey, QuantityConversionFunction> _quantityConversions;
#endif

    public FrozenQuantityConverter(UnitParser unitParser,
        IEnumerable<QuantityConversion> quantityConversions,
        IEnumerable<KeyValuePair<UnitConversionKey, ConvertValueDelegate>> unitConversionFunctions,
        IEnumerable<KeyValuePair<QuantityConversionKey, QuantityConversionFunction>> quantityConversionFunctions)
        : base(unitParser, quantityConversions)
    {
#if NET
        _unitConversions = unitConversionFunctions.ToFrozenDictionary();
        _quantityConversions = quantityConversionFunctions.ToFrozenDictionary();
#else
        _unitConversions = unitConversionFunctions.ToDictionary(pair => pair.Key, pair => pair.Value);
        _quantityConversions = quantityConversionFunctions.ToDictionary(pair => pair.Key, pair => pair.Value);
#endif
    }

    public override bool TryConvertValue<TUnit>(QuantityValue value, TUnit fromUnit, TUnit toUnit, out QuantityValue convertedValue)
    {
        return TryConvertValue(value, UnitConversionKey.Create(fromUnit, toUnit), out convertedValue);
    }

    public override bool TryConvertValue(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey, out QuantityValue convertedValue)
    {
        return fromUnitKey.UnitEnumType == toUnitKey.UnitEnumType
            ? TryConvertValue(value, UnitConversionKey.Create(fromUnitKey, toUnitKey), out convertedValue)
            : TryConvertValueFromOneQuantityToAnother(value, fromUnitKey, toUnitKey, out convertedValue);
    }

    private bool TryConvertValue(QuantityValue value, UnitConversionKey conversionKey, out QuantityValue convertedValue)
    {
        if (conversionKey.HasSameUnits)
        {
            convertedValue = value;
            return true;
        }

        if (_unitConversions.TryGetValue(conversionKey, out ConvertValueDelegate? cachedConversion))
        {
            convertedValue = cachedConversion(value);
            return true;
        }

        if (TryGetUnitInfo(conversionKey.FromUnitKey, out UnitInfo? fromUnitInfo) &&
            TryGetUnitInfo(new UnitKey(conversionKey.FromUnitKey.UnitEnumType, conversionKey.ToUnitValue), out UnitInfo? toUnitInfo))
            // TryGetUnitInfo(conversionKey.FromUnitKey with { UnitValue = conversionKey.ToUnitValue }, out UnitInfo? toUnitInfo))
        {
            convertedValue = toUnitInfo.GetValueFrom(value, fromUnitInfo);
            return true;
        }

        convertedValue = default;
        return false;
    }
    
    private bool TryConvertValueFromOneQuantityToAnother(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey, out QuantityValue convertedValue)
    {
        var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitKey.UnitEnumType);
        if (_quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction conversionFunction))
        {
            return TryConvertValue(conversionFunction.Convert(value), new UnitConversionKey(conversionFunction.TargetUnit, toUnitKey.UnitEnumValue), out convertedValue);
        }
        
        if (TryGetUnitInfo(fromUnitKey, out UnitInfo? fromUnitInfo) && TryGetUnitInfo(toUnitKey, out UnitInfo? toUnitInfo))
        {
            return TryConvertValueFromOneQuantityToAnother(value, fromUnitInfo, toUnitInfo, out convertedValue);
        }

        convertedValue = default;
        return false;
    }

    protected override bool TryConvertValueInternal(QuantityValue value, UnitInfo fromUnitInfo, UnitInfo toUnitInfo, out QuantityValue convertedValue)
    {
        if (fromUnitInfo == toUnitInfo)
        {
            // TODO see about this: the only possible route in is from TryConvertValueByName
            convertedValue = value;
            return true;
        }

        UnitKey fromUnitKey = fromUnitInfo.UnitKey;
        UnitKey toUnitKey = toUnitInfo.UnitKey;
        if (fromUnitKey.UnitEnumType == toUnitKey.UnitEnumType)
        {
            convertedValue = _unitConversions.TryGetValue(UnitConversionKey.Create(fromUnitKey, toUnitKey), out ConvertValueDelegate? cachedConversion)
                ? cachedConversion(value)
                : toUnitInfo.GetValueFrom(value, fromUnitInfo);
            return true;
        }
        
        var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitKey.UnitEnumType);
        if (!_quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction defaultConversion))
        {
            return TryConvertValueFromOneQuantityToAnother(value, fromUnitInfo, toUnitInfo, out convertedValue);
        }

        if (defaultConversion.TargetUnit == toUnitKey)
        {
            convertedValue = defaultConversion.Convert(value);
            return true;
        }

        QuantityValue valueInDefaultUnit = defaultConversion.Convert(value);
        convertedValue = _unitConversions.TryGetValue(UnitConversionKey.Create(defaultConversion.TargetUnit, toUnitKey), out ConvertValueDelegate? toTargetUnitConversion)
                ? toTargetUnitConversion(valueInDefaultUnit)
                : toUnitInfo.GetValueFrom(valueInDefaultUnit, GetUnitInfo(defaultConversion.TargetUnit));
        return true;
    }

    public override QuantityValue ConvertValue<TUnit>(QuantityValue value, TUnit fromUnit, TUnit toUnit)
    {
        var conversionKey = UnitConversionKey.Create(fromUnit, toUnit);
        return ConvertValue(value, conversionKey);
    }

    public override QuantityValue ConvertValue(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        return fromUnitKey.UnitEnumType == toUnitKey.UnitEnumType
            ? ConvertValue(value, UnitConversionKey.Create(fromUnitKey, toUnitKey))
            : ConvertValueFromOneQuantityToAnother(value, fromUnitKey, toUnitKey);
    }

    private QuantityValue ConvertValue(QuantityValue value, UnitConversionKey conversionKey)
    {
        if (conversionKey.HasSameUnits)
        {
            return value;
        }

        if (_unitConversions.TryGetValue(conversionKey, out ConvertValueDelegate? cachedConversion))
        {
            return cachedConversion(value);
        }

        UnitInfo fromUnitInfo = GetUnitInfo(conversionKey.FromUnitKey);
        UnitInfo toUnitInfo = GetUnitInfo(new UnitKey(conversionKey.FromUnitKey.UnitEnumType, conversionKey.ToUnitValue));
        // UnitInfo toUnitInfo = GetUnitInfo(conversionKey.FromUnitKey with { UnitValue = conversionKey.ToUnitValue });
        return toUnitInfo.GetValueFrom(value, fromUnitInfo);
    }
    
    private QuantityValue ConvertValueFromOneQuantityToAnother(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitKey.UnitEnumType);
        return _quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction defaultConversionFunction)
            ? ConvertValue(defaultConversionFunction.Convert(value), new UnitConversionKey(defaultConversionFunction.TargetUnit, toUnitKey.UnitEnumValue))
            : ConvertValueFromOneQuantityToAnother(value, GetUnitInfo(fromUnitKey), GetUnitInfo(toUnitKey));
    }

    protected override QuantityValue ConvertValueInternal(QuantityValue value, UnitInfo fromUnitInfo, UnitInfo toUnitInfo)
    {
        if (fromUnitInfo == toUnitInfo)
        {
            return value;
        }

        UnitKey fromUnitKey = fromUnitInfo.UnitKey;
        UnitKey toUnitKey = toUnitInfo.UnitKey;
        if (fromUnitKey.UnitEnumType == toUnitKey.UnitEnumType)
        {
            return _unitConversions.TryGetValue(UnitConversionKey.Create(fromUnitKey, toUnitKey), out ConvertValueDelegate? cachedConversion)
                ? cachedConversion(value)
                : toUnitInfo.GetValueFrom(value, fromUnitInfo);
        }

        var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitInfo.QuantityInfo.UnitType);
        if (!_quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction defaultConversion))
        {
            return ConvertValueFromOneQuantityToAnother(value, fromUnitInfo, toUnitInfo);
        }
        
        if (defaultConversion.TargetUnit == toUnitKey)
        {
            return defaultConversion.Convert(value);
        }
        
        QuantityValue valueInDefaultUnit = defaultConversion.Convert(value);
        return _unitConversions.TryGetValue(UnitConversionKey.Create(defaultConversion.TargetUnit, toUnitKey), out ConvertValueDelegate? toTargetUnitConversion)
            ? toTargetUnitConversion(valueInDefaultUnit)
            : toUnitInfo.GetValueFrom(valueInDefaultUnit, GetUnitInfo(defaultConversion.TargetUnit));
    }

    public override ConvertValueDelegate GetConversionFunction(UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        if (fromUnitKey == toUnitKey)
        {
            return value => value;
        }

        if (fromUnitKey.UnitEnumType == toUnitKey.UnitEnumType)
        {
            return _unitConversions.TryGetValue(UnitConversionKey.Create(fromUnitKey, toUnitKey), out ConvertValueDelegate? conversionFunction)
                ? conversionFunction
                : GetUnitInfo(fromUnitKey).GetUnitConversionExpressionTo(GetUnitInfo(toUnitKey));
        }

        UnitInfo fromUnitInfo = GetUnitInfo(fromUnitKey);
        UnitInfo toUnitInfo = GetUnitInfo(toUnitKey);
        var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitInfo.QuantityInfo.UnitType);
        if (_quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction defaultConversion))
        {
            if (defaultConversion.TargetUnit == toUnitKey)
            {
                return defaultConversion.Convert;
            }

            ConvertValueDelegate conversionToTarget =
                _unitConversions.TryGetValue(UnitConversionKey.Create(defaultConversion.TargetUnit, toUnitKey), out ConvertValueDelegate? conversionFunction)
                    ? conversionFunction
                    : GetUnitInfo(defaultConversion.TargetUnit).GetUnitConversionExpressionTo(toUnitInfo);
            return value => conversionToTarget(defaultConversion.Convert(value));
        }

        return GetConversionFromOneQuantityToAnother(fromUnitInfo, toUnitInfo);
    }

    public override bool TryGetConversionFunction(UnitKey fromUnitKey, UnitKey toUnitKey, [NotNullWhen(true)] out ConvertValueDelegate? conversionFunction)
    {
        if (fromUnitKey == toUnitKey)
        {
            conversionFunction = value => value;
            return true;
        }

        if (fromUnitKey.UnitEnumType == toUnitKey.UnitEnumType)
        {
            if (_unitConversions.TryGetValue(UnitConversionKey.Create(fromUnitKey, toUnitKey), out conversionFunction))
            {
                return true;
            }

            if (TryGetUnitInfo(fromUnitKey, out UnitInfo? fromUnitInfo) && TryGetUnitInfo(toUnitKey, out UnitInfo? toUnitInfo))
            {
                conversionFunction = fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo);
                return true;
            }
        }
        else if (TryGetUnitInfo(fromUnitKey, out UnitInfo? fromUnitInfo) && TryGetUnitInfo(toUnitKey, out UnitInfo? toUnitInfo))
        {
            var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitInfo.QuantityInfo.UnitType);
            if (!_quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction defaultConversion))
            {
                return TryGetConversionFromOneQuantityToAnother(fromUnitInfo, toUnitInfo, out conversionFunction);
            }

            if (defaultConversion.TargetUnit == toUnitKey)
            {
                conversionFunction = defaultConversion.Convert;
                return true;
            }

            ConvertValueDelegate conversionToTarget =
                _unitConversions.TryGetValue(UnitConversionKey.Create(defaultConversion.TargetUnit, toUnitKey), out ConvertValueDelegate? conversion)
                    ? conversion
                    : GetUnitInfo(defaultConversion.TargetUnit).GetUnitConversionExpressionTo(toUnitInfo);
            conversionFunction = value => conversionToTarget(defaultConversion.Convert(value));
            return true;
        }

        conversionFunction = null;
        return false;
    }

    public override TTargetQuantity ConvertTo<TSourceUnit, TTargetQuantity, TTargetUnit>(QuantityValue value, TSourceUnit fromUnit, QuantityInfo<TTargetQuantity, TTargetUnit> targetQuantityInfo)
    {
        if (_quantityConversions.TryGetValue(QuantityConversionKey.Create<TSourceUnit, TTargetUnit>(fromUnit), out QuantityConversionFunction conversionFunction))
        {
            return targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit.ToUnit<TTargetUnit>());
        }
        
        return base.ConvertTo(value, fromUnit, targetQuantityInfo);
    }

    public override IQuantity ConvertTo(QuantityValue value, UnitKey fromUnitKey, QuantityInfo targetQuantityInfo)
    {
        if (_quantityConversions.TryGetValue(new QuantityConversionKey(fromUnitKey, targetQuantityInfo.UnitType),
                out QuantityConversionFunction conversionFunction))
        {
            return targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit);
        }

        return base.ConvertTo(value, fromUnitKey, targetQuantityInfo);
    }


    public override bool TryConvertTo<TSourceUnit, TTargetQuantity, TTargetUnit>(QuantityValue value, TSourceUnit fromUnit,
        QuantityInfo<TTargetQuantity, TTargetUnit> targetQuantityInfo,
        [NotNullWhen(true)] out TTargetQuantity? convertedQuantity)
        where TTargetQuantity : default
    {
        if (_quantityConversions.TryGetValue(QuantityConversionKey.Create<TSourceUnit, TTargetUnit>(fromUnit),
                out QuantityConversionFunction conversionFunction))
        {
            convertedQuantity = targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit.ToUnit<TTargetUnit>());
            return true;
        }

        return base.TryConvertTo(value, fromUnit, targetQuantityInfo, out convertedQuantity);
    }

    public override bool TryConvertTo(QuantityValue value, UnitKey fromUnitKey, QuantityInfo targetQuantityInfo,
        [NotNullWhen(true)] out IQuantity? convertedQuantity)
    {
        if (_quantityConversions.TryGetValue(new QuantityConversionKey(fromUnitKey, targetQuantityInfo.UnitType),
                out QuantityConversionFunction conversionFunction))
        {
            convertedQuantity = targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit);
            return true;
        }

        return base.TryConvertTo(value, fromUnitKey, targetQuantityInfo, out convertedQuantity);
    }
}
