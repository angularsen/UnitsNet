﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using UnitsNet.Samples.UnitConverter.Wpf.Properties;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    /// <summary>
    ///     This interface ensures that the view model and the design-time view model are consistent, since the XAML
    ///     intellisense only knows about the design-time type.
    /// </summary>
    public interface IMainWindowVm : INotifyPropertyChanged
    {
        ReadOnlyObservableCollection<string> Quantities { get; }
        ReadOnlyObservableCollection<UnitListItem> Units { get; }
        string SelectedQuantity { get; set; }

        [CanBeNull]
        UnitListItem SelectedFromUnit { get; set; }

        [CanBeNull]
        UnitListItem SelectedToUnit { get; set; }

        string FromHeader { get; }
        string ToHeader { get; }
        QuantityValue FromValue { get; set; }
        QuantityValue ToValue { get; }
        ICommand SwapCommand { get; }
    }
}
