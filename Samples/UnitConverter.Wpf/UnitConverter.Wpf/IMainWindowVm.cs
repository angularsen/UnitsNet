using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using UnitsNet;
using Wpf_GenericUnitConverter.Annotations;

namespace Wpf_GenericUnitConverter
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
        decimal FromValue { get; }
        decimal ToValue { get; }
        ICommand SwapCommand { get; }
    }
}