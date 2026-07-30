using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using UnitsNet.Samples.UnitConverter.Wpf.Properties;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    /// <summary>
    ///     View model for <see cref="MainWindow" />. Provides quantities and units for listboxes and updates the conversion
    ///     result whenever the input value or any unit selection changes.
    /// </summary>
    public sealed class MainWindowVm : IMainWindowVm
    {
        private readonly ObservableCollection<UnitListItem> _units;
        private QuantityValue _fromValue;

        [CanBeNull] private UnitListItem _selectedFromUnit;

        private string _selectedQuantity;

        [CanBeNull] private UnitListItem _selectedToUnit;

        private QuantityValue _toValue;

        public MainWindowVm()
        {
            Quantities = ToReadOnly(Quantity.Infos.Select(i => i.Name));

            _units = new ObservableCollection<UnitListItem>();
            Units = new ReadOnlyObservableCollection<UnitListItem>(_units);
            BindingOperations.EnableCollectionSynchronization(_units, this); // Cross-thread safety

            FromValue = 1;
            SwapCommand = new DelegateCommand(Swap);

            SelectedQuantity = Length.Info.Name;
        }

        public ICommand SwapCommand { get; }

        public ReadOnlyObservableCollection<string> Quantities { get; }
        public ReadOnlyObservableCollection<UnitListItem> Units { get; }

        public string SelectedQuantity
        {
            get => _selectedQuantity;
            set
            {
                if (value == _selectedQuantity) return;
                _selectedQuantity = value;
                OnPropertyChanged();
                OnSelectedQuantity(value);
            }
        }

        [CanBeNull]
        public UnitListItem SelectedFromUnit
        {
            get => _selectedFromUnit;
            set
            {
                if (Equals(value, _selectedFromUnit)) return;
                _selectedFromUnit = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FromHeader));
                UpdateResult();
            }
        }

        [CanBeNull]
        public UnitListItem SelectedToUnit
        {
            get => _selectedToUnit;
            set
            {
                if (Equals(value, _selectedToUnit)) return;
                _selectedToUnit = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ToHeader));
                UpdateResult();
            }
        }

        public string FromHeader => $"Value [{SelectedFromUnit?.Abbreviation}]";

        public string ToHeader => $"Result [{SelectedToUnit?.Abbreviation}]";

        public QuantityValue FromValue
        {
            get => _fromValue;
            set
            {
                if (value == _fromValue) return;
                _fromValue = value;
                OnPropertyChanged();
                UpdateResult();
            }
        }

        public QuantityValue ToValue
        {
            get => _toValue;
            private set
            {
                if (value == _toValue) return;
                _toValue = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Swap()
        {
            UnitListItem oldToUnit = SelectedToUnit;
            QuantityValue oldToValue = ToValue;

            // Setting these will change ToValue
            SelectedToUnit = SelectedFromUnit;
            SelectedFromUnit = oldToUnit;

            FromValue = oldToValue;
        }

        private void UpdateResult()
        {
            if (SelectedFromUnit == null || SelectedToUnit == null) return;

            // note: starting from v6 it is possible to store (and invoke here) a conversion expression
            // ConvertValueDelegate _convertValueToUnit = UnitsNet.UnitConverter.Default.GetConversionFunction(SelectedFromUnit.UnitEnumValue, SelectedToUnit.UnitEnumValue);
            // ToValue = _convertValueToUnit(FromValue);

            // note: as of v6 this can be optimized by working directly with the IUntInfo (or it's UnitKey).
            ToValue = UnitsNet.UnitConverter.Convert(FromValue,
                SelectedFromUnit.UnitEnumValue,
                SelectedToUnit.UnitEnumValue);
        }

        private void OnSelectedQuantity(string quantityName)
        {
            QuantityInfo quantityInfo = Quantity.ByName[quantityName];

            _units.Clear();
            // note: as of v6 approach this approach is not recommended as the unit info no longer stores the boxed version of the unit (as untyped Enum)
            foreach (Enum unitValue in quantityInfo.UnitInfos.Select(ui => ui.Value))
            {
                _units.Add(new UnitListItem(unitValue)); // TODO see about simply passing the UnitInfo (or the UnitKey)
            }
            
            SelectedFromUnit = _units.FirstOrDefault();
            SelectedToUnit = _units.Skip(1).FirstOrDefault() ?? SelectedFromUnit; // Try to pick a different to-unit
        }

        private static ReadOnlyObservableCollection<T> ToReadOnly<T>(IEnumerable<T> items)
        {
            return new ReadOnlyObservableCollection<T>(new ObservableCollection<T>(items));
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
