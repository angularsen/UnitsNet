// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;

namespace UnitsNet;

/// <summary>
///     Selects the quantities used to construct an isolated UnitsNet component or setup.
/// </summary>
public sealed class QuantitiesSelector
{
    private readonly Func<IEnumerable<QuantityInfo>> _defaultQuantities;
    private IEnumerable<QuantityInfo>? _additionalQuantities;

    internal QuantitiesSelector(Func<IEnumerable<QuantityInfo>> defaultQuantities)
    {
        _defaultQuantities = defaultQuantities ?? throw new ArgumentNullException(nameof(defaultQuantities));
    }

    /// <summary>
    ///     Appends external quantity definitions to the current selection.
    /// </summary>
    /// <param name="quantities">The quantity definitions to append.</param>
    /// <returns>This selector, for method chaining.</returns>
    public QuantitiesSelector WithAdditionalQuantities(IEnumerable<QuantityInfo> quantities)
    {
        if (quantities is null) throw new ArgumentNullException(nameof(quantities));

        _additionalQuantities = _additionalQuantities?.Concat(quantities) ?? quantities;
        return this;
    }

    internal IEnumerable<QuantityInfo> GetQuantityInfos()
    {
        IEnumerable<QuantityInfo> quantities = _defaultQuantities();
        return _additionalQuantities is null ? quantities : quantities.Concat(_additionalQuantities);
    }
}
