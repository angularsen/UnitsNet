using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    /// <summary>
    ///     Design-time view model for <see cref="MainWindow" />.
    ///     Provides sample data for the view shown in the XAML designer.
    /// </summary>
    public sealed class MainWindowDesignVm : IMainWindowVm
    {
        public MainWindowDesignVm()
        {
            Quantities = ToReadOnly(Quantity.Types);
            Units = ToReadOnly(Length.Units.Select(u => new UnitListItem(u)));
            SelectedQuantity = QuantityType.Length;
            SelectedFromUnit = Units[1];
            SelectedToUnit = Units[2];
        }


        public ReadOnlyObservableCollection<QuantityType> Quantities { get; }
        public ReadOnlyObservableCollection<UnitListItem> Units { get; }
        public QuantityType SelectedQuantity { get; set; }
        public UnitListItem SelectedFromUnit { get; set; }
        public UnitListItem SelectedToUnit { get; set; }

        public string FromHeader { get; } = "Value [cm]";
        public string ToHeader { get; } = "Result [dm]";
        public decimal FromValue { get; set; } = 14.5m;
        public decimal ToValue { get; } = 1.45m;

        public ICommand SwapCommand { get; } = new RoutedCommand();

        // Is never used
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        private static ReadOnlyObservableCollection<T> ToReadOnly<T>(IEnumerable<T> items)
        {
            return new ReadOnlyObservableCollection<T>(new ObservableCollection<T>(items));
        }
    }
}
