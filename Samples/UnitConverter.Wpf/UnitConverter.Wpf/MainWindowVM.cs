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
        private decimal _fromValue;

        [CanBeNull] private UnitListItem _selectedFromUnit;

        private QuantityType _selectedQuantity;

        [CanBeNull] private UnitListItem _selectedToUnit;

        private decimal _toValue;

        public MainWindowVm()
        {
            Quantities = ToReadOnly(Quantity.Types);

            _units = new ObservableCollection<UnitListItem>();
            Units = new ReadOnlyObservableCollection<UnitListItem>(_units);
            BindingOperations.EnableCollectionSynchronization(_units, this); // Cross-thread safety

            FromValue = 1;
            SwapCommand = new DelegateCommand(Swap);

            OnSelectedQuantity(QuantityType.Length);
        }

        public ICommand SwapCommand { get; }

        public ReadOnlyObservableCollection<QuantityType> Quantities { get; }
        public ReadOnlyObservableCollection<UnitListItem> Units { get; }

        public QuantityType SelectedQuantity
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

        public decimal FromValue
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

        public decimal ToValue
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
            decimal oldToValue = ToValue;

            // Setting these will change ToValue
            SelectedToUnit = SelectedFromUnit;
            SelectedFromUnit = oldToUnit;

            FromValue = oldToValue;
        }

        private void UpdateResult()
        {
            if (SelectedFromUnit == null || SelectedToUnit == null) return;

            double convertedValue = UnitsNet.UnitConverter.Convert(FromValue,
                SelectedFromUnit.UnitEnumValue,
                SelectedToUnit.UnitEnumValue);

            ToValue = Convert.ToDecimal(convertedValue);
        }

        private void OnSelectedQuantity(QuantityType quantityType)
        {
            QuantityInfo quantityInfo = Quantity.GetInfo(quantityType);

            _units.Clear();
            foreach (Enum unitValue in quantityInfo.Units)
            {
                _units.Add(new UnitListItem(unitValue));
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
