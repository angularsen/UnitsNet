using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using UnitsNet.Samples.UnitConverter.Wpf.Properties;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    public interface IMainWindowVm : INotifyPropertyChanged
    {
        ReadOnlyObservableCollection<QuantityType> Quantities { get; }
        ReadOnlyObservableCollection<UnitPresenter> Units { get; }
        QuantityType SelectedQuantity { get; set; }

        [CanBeNull]
        UnitPresenter SelectedFromUnit { get; set; }

        [CanBeNull]
        UnitPresenter SelectedToUnit { get; set; }

        string FromHeader { get; }
        string ToHeader { get; }
        decimal FromValue { get; set; }
        decimal ToValue { get; }
        ICommand SwapCommand { get; }
    }
}