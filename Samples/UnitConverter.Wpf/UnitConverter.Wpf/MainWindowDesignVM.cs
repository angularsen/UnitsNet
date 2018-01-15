using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    public sealed class MainWindowDesignVm : IMainWindowVm
    {
        public MainWindowDesignVm()
        {
            Quantities = ToReadOnly(Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().Skip(1));
            Units = ToReadOnly(Length.Units.Select(u => new UnitPresenter(u)));
            SelectedQuantity = QuantityType.Length;
            SelectedFromUnit = Units[1];
            SelectedToUnit = Units[2];
        }

        public ReadOnlyObservableCollection<QuantityType> Quantities { get; }
        public ReadOnlyObservableCollection<UnitPresenter> Units { get; }
        public QuantityType SelectedQuantity { get; set; }
        public UnitPresenter SelectedFromUnit { get; set; }
        public UnitPresenter SelectedToUnit { get; set; }

        public string FromHeader { get; } = "Value [cm]";
        public string ToHeader { get; } = "Result [dm]";
        public decimal FromValue { get; set; } = 14.5m;
        public decimal ToValue { get; } = 1.45m;

        public ICommand SwapCommand { get; } = new RoutedCommand();

        public event PropertyChangedEventHandler PropertyChanged;

        private static ReadOnlyObservableCollection<T> ToReadOnly<T>(IEnumerable<T> items)
        {
            return new ReadOnlyObservableCollection<T>(new ObservableCollection<T>(items));
        }
    }
}