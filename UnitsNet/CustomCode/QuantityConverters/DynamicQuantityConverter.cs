// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UnitsNet;

internal sealed class DynamicQuantityConverter : UnitConverter
{
    private readonly ConcurrentDictionary<UnitConversionKey, ConvertValueDelegate> _unitConversions;
    private readonly ConcurrentDictionary<QuantityConversionKey, QuantityConversionFunction> _quantityConversions;
    private readonly Func<UnitConversionKey, ConvertValueDelegate> _unitConversionExpressionFactory;
    private readonly bool _reduceConstants;

    public DynamicQuantityConverter(UnitParser unitParser,
        IEnumerable<QuantityConversion> quantityConversions,
        IEnumerable<KeyValuePair<UnitConversionKey, ConvertValueDelegate>> unitConversionFunctions,
        IEnumerable<KeyValuePair<QuantityConversionKey, QuantityConversionFunction>> quantityConversionFunctions, bool reduceConstants)
        : base(unitParser, quantityConversions)
    {
        _reduceConstants = reduceConstants;
        _unitConversions = new ConcurrentDictionary<UnitConversionKey, ConvertValueDelegate>(unitConversionFunctions);
        _quantityConversions = new ConcurrentDictionary<QuantityConversionKey, QuantityConversionFunction>(quantityConversionFunctions);
        _unitConversionExpressionFactory = GetConversionExpression;
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
            cachedConversion = _unitConversions.GetOrAdd(conversionKey, fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo, _reduceConstants));
            convertedValue = cachedConversion(value);
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
            return TryConvertValue(conversionFunction.Convert(value), new UnitConversionKey(conversionFunction.TargetUnit, toUnitKey.UnitEnumValue),
                out convertedValue);
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
            ConvertValueDelegate conversionDelegate = GetOrAdd(UnitConversionKey.Create(fromUnitKey, toUnitKey), fromUnitInfo, toUnitInfo);
            convertedValue = conversionDelegate(value);
            return true;
        }

        var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitKey.UnitEnumType);
        if (!_quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction conversionFunction))
        {
            if (ConversionDefined(fromUnitInfo.QuantityInfo, toUnitInfo.QuantityInfo) &&
                fromUnitInfo.TryGetQuantityConversionExpressionTo(toUnitInfo, _reduceConstants, out ConversionExpression? conversionExpression))
            {
                conversionFunction = _quantityConversions.GetOrAdd(defaultConversionKey, new QuantityConversionFunction(conversionExpression, toUnitKey));
            }
            else
            {
                convertedValue = default;
                return false;
            }
        }

        if (conversionFunction.TargetUnit == toUnitKey)
        {
            convertedValue = conversionFunction.Convert(value);
            return true;
        }
        
        ConvertValueDelegate targetToUnitConversion = GetOrAddConversionTo(UnitConversionKey.Create(conversionFunction.TargetUnit, toUnitKey), toUnitInfo);
        convertedValue = targetToUnitConversion(conversionFunction.Convert(value));
        return true;
    }

    public override QuantityValue ConvertValue<TUnit>(QuantityValue value, TUnit fromUnit, TUnit toUnit)
    {
        return ConvertValue(value, UnitConversionKey.Create(fromUnit, toUnit));
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
        
        ConvertValueDelegate conversion = _unitConversions.GetOrAdd(conversionKey, _unitConversionExpressionFactory);
        return conversion(value);
    }

    private QuantityValue ConvertValueFromOneQuantityToAnother(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitKey.UnitEnumType);
        if (_quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction defaultConversion))
        {
            return defaultConversion.TargetUnit.UnitEnumValue == toUnitKey.UnitEnumValue
                ? defaultConversion.Convert(value)
                : ConvertValue(defaultConversion.Convert(value), UnitConversionKey.Create(defaultConversion.TargetUnit, toUnitKey));
        }

        UnitInfo fromUnitInfo = GetUnitInfo(fromUnitKey);
        UnitInfo toUnitInfo = GetUnitInfo(toUnitKey);

        ConvertValueDelegate conversionExpression = GetConversionFromOneQuantityToAnother(fromUnitInfo, toUnitInfo, _reduceConstants);
        QuantityValue convertedValue = conversionExpression(value);
        _quantityConversions.TryAdd(defaultConversionKey, new QuantityConversionFunction(conversionExpression, toUnitKey));
        return convertedValue;
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
            ConvertValueDelegate conversionDelegate = GetOrAdd(UnitConversionKey.Create(fromUnitKey, toUnitKey), fromUnitInfo, toUnitInfo);
            return conversionDelegate(value);
        }

        QuantityConversionFunction conversionFunction = GetOrAdd(new QuantityConversionKey(fromUnitKey, toUnitKey.UnitEnumType), fromUnitInfo, toUnitInfo);
        if (conversionFunction.TargetUnit.UnitEnumValue == toUnitKey.UnitEnumValue)
        {
            return conversionFunction.Convert(value);
        }
        
        ConvertValueDelegate targetToUnitConversion = GetOrAddConversionTo(UnitConversionKey.Create(conversionFunction.TargetUnit, toUnitKey), toUnitInfo);
        return targetToUnitConversion(conversionFunction.Convert(value));
    }

    public override ConvertValueDelegate GetConversionFunction(UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        if (fromUnitKey == toUnitKey)
        {
            return value => value;
        }
        
        if (fromUnitKey.UnitEnumType == toUnitKey.UnitEnumType)
        {
            return _unitConversions.GetOrAdd(UnitConversionKey.Create(fromUnitKey, toUnitKey), _unitConversionExpressionFactory);
        }

        UnitInfo fromUnitInfo = GetUnitInfo(fromUnitKey);
        UnitInfo toUnitInfo = GetUnitInfo(toUnitKey);
        var defaultConversionKey = new QuantityConversionKey(fromUnitKey, toUnitInfo.QuantityInfo.UnitType);
        if (!_quantityConversions.TryGetValue(defaultConversionKey, out QuantityConversionFunction defaultConversion))
        {
            return GetConversionFromOneQuantityToAnother(fromUnitInfo, toUnitInfo);
        }

        if (defaultConversion.TargetUnit == toUnitKey)
        {
            return defaultConversion.Convert;
        }

        // TODO should we be caching the result? (GetOrAddConversionTo)
        // TODO the resulting expression might not be fully reduced if _reduceConstants is false
        if(!_unitConversions.TryGetValue(UnitConversionKey.Create(defaultConversion.TargetUnit, toUnitKey), out ConvertValueDelegate? conversionToTarget))
        {
            conversionToTarget = GetUnitInfo(defaultConversion.TargetUnit).GetUnitConversionExpressionTo(toUnitInfo);
        }
        
        return value => conversionToTarget(defaultConversion.Convert(value));
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
            var conversionKey = UnitConversionKey.Create(fromUnitKey, toUnitKey);
            if (_unitConversions.TryGetValue(conversionKey, out conversionFunction))
            {
                return true;
            }

            if (TryGetUnitInfo(fromUnitKey, out UnitInfo? fromUnitInfo) && TryGetUnitInfo(toUnitKey, out UnitInfo? toUnitInfo))
            {
                conversionFunction = _unitConversions.GetOrAdd(conversionKey, fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo, _reduceConstants));
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
            
            // TODO should we be caching the result? (GetOrAddConversionTo)
            // TODO the resulting expression might not be fully reduced if _reduceConstants is false
            if(!_unitConversions.TryGetValue(UnitConversionKey.Create(defaultConversion.TargetUnit, toUnitKey), out ConvertValueDelegate? conversionToTarget))
            {
                conversionToTarget = GetUnitInfo(defaultConversion.TargetUnit).GetUnitConversionExpressionTo(toUnitInfo);
            }
            
            conversionFunction = value => conversionToTarget(defaultConversion.Convert(value));
            return true;
        }

        conversionFunction = null;
        return false;
    }

    public override bool TryConvertTo<TSourceUnit, TTargetQuantity, TTargetUnit>(QuantityValue value, TSourceUnit fromUnit,
        QuantityInfo<TTargetQuantity, TTargetUnit> targetQuantityInfo,
        [NotNullWhen(true)] out TTargetQuantity? convertedQuantity)
        where TTargetQuantity : default
    {
        var conversionKey = QuantityConversionKey.Create<TSourceUnit, TTargetUnit>(fromUnit);
        if (_quantityConversions.TryGetValue(conversionKey, out QuantityConversionFunction conversionFunction))
        {
            convertedQuantity = targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit.ToUnit<TTargetUnit>());
            return true;
        }

        if (!TryGetUnitInfo(conversionKey.FromUnit, out UnitInfo? fromUnitInfo))
        {
            convertedQuantity = default;
            return false;
        }

        if (ConversionDefined(fromUnitInfo.QuantityInfo, targetQuantityInfo) &&
            targetQuantityInfo.TryGetQuantityConversionFrom(fromUnitInfo, _reduceConstants, out QuantityConversionFunction conversionConstructed))
        {
            conversionFunction = _quantityConversions.GetOrAdd(conversionKey, conversionConstructed);
            convertedQuantity = targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit.ToUnit<TTargetUnit>());
            return true;
        }

        convertedQuantity = default;
        return false;
    }

    public override bool TryConvertTo(QuantityValue value, UnitKey fromUnitKey, QuantityInfo targetQuantityInfo,
        [NotNullWhen(true)] out IQuantity? convertedQuantity)
    {
        var conversionKey = new QuantityConversionKey(fromUnitKey, targetQuantityInfo.UnitType);
        if (_quantityConversions.TryGetValue(conversionKey, out QuantityConversionFunction conversionFunction))
        {
            convertedQuantity = targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit);
            return true;
        }

        if (!TryGetUnitInfo(conversionKey.FromUnit, out UnitInfo? fromUnitInfo))
        {
            convertedQuantity = null;
            return false;
        }

        if (ConversionDefined(fromUnitInfo.QuantityInfo, targetQuantityInfo) &&
            targetQuantityInfo.TryGetQuantityConversionFrom(fromUnitInfo, _reduceConstants, out QuantityConversionFunction conversionConstructed))
        {
            conversionFunction = _quantityConversions.GetOrAdd(conversionKey, conversionConstructed);
            convertedQuantity = targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit);
            return true;
        }

        convertedQuantity = null;
        return false;
    }

    public override TTargetQuantity ConvertTo<TSourceUnit, TTargetQuantity, TTargetUnit>(QuantityValue value, TSourceUnit fromUnit,
        QuantityInfo<TTargetQuantity, TTargetUnit> targetQuantityInfo)
    {
        var conversionKey = QuantityConversionKey.Create<TSourceUnit, TTargetUnit>(fromUnit);
        QuantityConversionFunction conversionFunction = GetOrAdd(conversionKey, targetQuantityInfo);
        // return targetQuantityInfo.Create(conversionFunction.Convert(value), conversionFunction.TargetUnit);
        return targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit.ToUnit<TTargetUnit>());
    }

    public override IQuantity ConvertTo(QuantityValue value, UnitKey fromUnitKey, QuantityInfo targetQuantityInfo)
    {
        var conversionKey = new QuantityConversionKey(fromUnitKey, targetQuantityInfo.UnitType);
        QuantityConversionFunction conversionFunction = GetOrAdd(conversionKey, targetQuantityInfo);
        return targetQuantityInfo.From(conversionFunction.Convert(value), conversionFunction.TargetUnit);
    }
    
    private ConvertValueDelegate GetConversionExpression(UnitConversionKey conversionKey)
    {
        UnitInfo fromUnitInfo = GetUnitInfo(conversionKey.FromUnitKey);
        UnitInfo toUnitInfo = GetUnitInfo(new UnitKey(conversionKey.FromUnitKey.UnitEnumType, conversionKey.ToUnitValue));
        // UnitInfo toUnitInfo = GetUnitInfo(conversionKey.FromUnitKey with { UnitValue = conversionKey.ToUnitValue });
        return fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo, _reduceConstants);
    }
    
    private ConvertValueDelegate GetOrAdd(UnitConversionKey conversionKey, UnitInfo fromUnitInfo, UnitInfo toUnitInfo)
    {
#if NET
        return _unitConversions.GetOrAdd(conversionKey, CreateConversionExpressionForUnits, (fromUnitInfo, toUnitInfo, _reduceConstants));    
        static ConvertValueDelegate CreateConversionExpressionForUnits(UnitConversionKey key, ValueTuple<UnitInfo, UnitInfo, bool> conversion)
        {
            return conversion.Item1.GetUnitConversionExpressionTo(conversion.Item2, conversion.Item3);
        }
#else
        // intentionally not using the factory overload here, as it causes an extra allocation for the Func
        return _unitConversions.TryGetValue(conversionKey, out ConvertValueDelegate? conversionFunction)
            ? conversionFunction
            : _unitConversions.GetOrAdd(conversionKey, fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo, _reduceConstants));
#endif
    }

    private ConvertValueDelegate GetOrAddConversionTo(UnitConversionKey conversionKey, UnitInfo toUnitInfo)
    {
#if NET
        return _unitConversions.GetOrAdd(conversionKey, CreateConversionExpressionForUnit, (this, toUnitInfo));
        static ConvertValueDelegate CreateConversionExpressionForUnit(UnitConversionKey key, ValueTuple<DynamicQuantityConverter, UnitInfo> conversion)
        {
            DynamicQuantityConverter converter = conversion.Item1;
            UnitInfo fromUnitInfo = converter.GetUnitInfo(key.FromUnitKey);
            UnitInfo toUnitInfo = conversion.Item2;
            return fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo, converter._reduceConstants);
        }
#else
        // intentionally not using the factory overload here, as it causes an extra allocation for the Func
        if (!_unitConversions.TryGetValue(conversionKey, out ConvertValueDelegate? targetToUnitConversion))
        {
            UnitInfo fromUnitInfo = GetUnitInfo(conversionKey.FromUnitKey);
            targetToUnitConversion = _unitConversions.GetOrAdd(conversionKey, fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo, _reduceConstants));
        }
        
        return targetToUnitConversion;
#endif
    }

    private QuantityConversionFunction GetOrAdd(QuantityConversionKey conversionKey, UnitInfo fromUnitInfo, UnitInfo toUnitInfo)
    {
#if NET
        return _quantityConversions.GetOrAdd(conversionKey, CreateConversionExpressionForUnits, (fromUnitInfo, toUnitInfo, this));    
        static QuantityConversionFunction CreateConversionExpressionForUnits(QuantityConversionKey key, ValueTuple<UnitInfo, UnitInfo, DynamicQuantityConverter> conversion)
        {
            UnitInfo fromUnitInfo = conversion.Item1;
            UnitInfo toUnitInfo = conversion.Item2;
            DynamicQuantityConverter converter = conversion.Item3;
            ConversionExpression conversionExpression = converter.GetConversionFromOneQuantityToAnother(fromUnitInfo, toUnitInfo, converter._reduceConstants);
            return new QuantityConversionFunction(conversionExpression, toUnitInfo.UnitKey);
        }
#else
        // intentionally not using the factory overload here, as it causes an extra allocation for the Func
        if (_quantityConversions.TryGetValue(conversionKey, out QuantityConversionFunction conversionFunction))
        {
            return conversionFunction;
        }

        ConversionExpression conversionExpression = GetConversionFromOneQuantityToAnother(fromUnitInfo, toUnitInfo, _reduceConstants);
        return _quantityConversions.GetOrAdd(conversionKey, new QuantityConversionFunction(conversionExpression, toUnitInfo.UnitKey));
#endif
    }

    private QuantityConversionFunction GetOrAdd(QuantityConversionKey conversionKey, QuantityInfo targetQuantityInfo)
    {
#if NET
        return _quantityConversions.GetOrAdd(conversionKey, CreateConversionFunction, (this, targetQuantityInfo));
        static QuantityConversionFunction CreateConversionFunction(QuantityConversionKey key, ValueTuple<DynamicQuantityConverter, QuantityInfo> conversion)
        {
            DynamicQuantityConverter converter = conversion.Item1;
            QuantityInfo targetQuantityInfo = conversion.Item2;
            UnitInfo fromUnitInfo = converter.GetUnitInfo(key.FromUnit);
            if (!converter.ConversionDefined(fromUnitInfo.QuantityInfo, targetQuantityInfo))
            {
                throw InvalidConversionException.CreateImplicitConversionException(fromUnitInfo.QuantityInfo, targetQuantityInfo);
            }
            
            return targetQuantityInfo.GetQuantityConversionFrom(fromUnitInfo, converter._reduceConstants);
        }
#else
        // intentionally not using the factory overload here, as it causes an extra allocation for the Func
        if (_quantityConversions.TryGetValue(conversionKey, out QuantityConversionFunction existingConversion))
        {
            return existingConversion;
        }

        UnitInfo fromUnitInfo = GetUnitInfo(conversionKey.FromUnit);
        if (!ConversionDefined(fromUnitInfo.QuantityInfo, targetQuantityInfo))
        {
            throw InvalidConversionException.CreateImplicitConversionException(fromUnitInfo.QuantityInfo, targetQuantityInfo);
        }
        
        QuantityConversionFunction conversionFunction = targetQuantityInfo.GetQuantityConversionFrom(fromUnitInfo, _reduceConstants);
        return _quantityConversions.GetOrAdd(conversionKey, conversionFunction);
#endif
    }
}
