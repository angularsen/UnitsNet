using System.Collections.ObjectModel;
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
        ReadOnlyObservableCollection<QuantityType> Quantities { get; }
        ReadOnlyObservableCollection<UnitListItem> Units { get; }
        QuantityType SelectedQuantity { get; set; }

        [CanBeNull]
        UnitListItem SelectedFromUnit { get; set; }

        [CanBeNull]
        UnitListItem SelectedToUnit { get; set; }

        string FromHeader { get; }
        string ToHeader { get; }
        decimal FromValue { get; set; }
        decimal ToValue { get; }
        ICommand SwapCommand { get; }
    }
}
