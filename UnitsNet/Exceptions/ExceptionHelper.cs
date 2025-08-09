using System;

namespace UnitsNet;

internal static class ExceptionHelper
{
    internal static ArgumentException CreateArgumentException<TQuantity>(object obj, string argumentName)
        where TQuantity : IQuantity
    {
        return new ArgumentException($"The given object is of type {obj.GetType()}. The expected type is {typeof(TQuantity)}.", argumentName);
    }

    internal static ArgumentException CreateArgumentOutOfRangeExceptionForNegativeTolerance(string argumentName)
    {
        return new ArgumentOutOfRangeException(argumentName, "The tolerance must be greater than or equal to 0.");
    }

    internal static InvalidOperationException CreateInvalidOperationOnEmptyCollectionException()
    {
        return new InvalidOperationException("Sequence contains no elements.");
    }
    
    internal static InvalidCastException CreateInvalidCastException<TSource, TOther>()
    {
        return CreateInvalidCastException<TSource>(typeof(TOther));
    }
    
    internal static InvalidCastException CreateInvalidCastException<TSource>(Type targetType)
    {
        return new InvalidCastException($"Converting {typeof(TSource)} to {targetType} is not supported.");
    }
}
