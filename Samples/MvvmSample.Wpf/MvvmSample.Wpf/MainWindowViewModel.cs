using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;
using UnitsNet.Units;
using WpfMVVMSample.Converters;
using WpfMVVMSample.Properties;
using WpfMVVMSample.Settings;

namespace WpfMVVMSample
{
    public class MainWindowViewModel: BindableBase
    {
        public MainWindowViewModel(SettingsManager settings)
        {
            Settings = settings;
            PropertyChanged += MainWindowViewModel_PropertyChanged;
            Settings.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("");//refresh all bindings on this viewmodel
        }

        private void MainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName==nameof(ObjectMass)||e.PropertyName==nameof(G))
            {
                Calculate();
            }
        }

        private SettingsManager _settings;
        public SettingsManager Settings
        {
            get { return _settings; }
            set { SetProperty(ref _settings, value); }
        }

        private Force _weight;
        public Force Weight
        {
            get { return _weight; }
            set { SetProperty(ref _weight, value); }
        }

        private Mass _objectMass;
        public Mass ObjectMass
        {
            get { return _objectMass; }
            set { SetProperty(ref _objectMass, value); }
        }

        private Acceleration _g;
        public Acceleration G
        {
            get { return _g; }
            set { SetProperty(ref _g, value); }
        }

        void Calculate()
        {
            _weight = _objectMass*_g;
            RaisePropertyChanged(nameof(Weight));
        }
    }
}
