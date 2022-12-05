using Prism.Mvvm;
using System;
using System.Collections.Generic;
using UnitsNet.Units;

namespace WpfMVVMSample.Settings
{
    public class SettingsManager : BindableBase
    {
        private readonly Dictionary<Type, Func<Enum>> _defaultUnitProviders;
        public SettingsManager()
        {
            DefaultMassUnit = MassUnit.Kilogram;
            DefaultAccelerationUnit = AccelerationUnit.MeterPerSecondSquared;
            DefaultForceUnit = ForceUnit.Newton;

            _defaultUnitProviders = new Dictionary<Type, Func<Enum>>
            {
                {typeof(MassUnit), () => DefaultMassUnit},
                {typeof(AccelerationUnit), () => DefaultAccelerationUnit},
                {typeof(ForceUnit), () => DefaultForceUnit},
            };
        }

        private MassUnit _defaultMassUnit;
        public MassUnit DefaultMassUnit
        {
            get { return _defaultMassUnit; }
            set { SetProperty(ref _defaultMassUnit, value); }
        }

        private AccelerationUnit _defaultAccelerationUnit;
        public AccelerationUnit DefaultAccelerationUnit
        {
            get { return _defaultAccelerationUnit; }
            set { SetProperty(ref _defaultAccelerationUnit, value); }
        }

        private ForceUnit _defaultForceUnit;
        public ForceUnit DefaultForceUnit
        {
            get { return _defaultForceUnit; }
            set { SetProperty(ref _defaultForceUnit, value); }
        }

        public Enum GetDefaultUnit(Type unitType)
        {
            if (_defaultUnitProviders.ContainsKey(unitType))
            {
                var provider = _defaultUnitProviders[unitType];
                return provider();
            }
            else
                return null;
        }

        private int _significantDigits = 1;

        public int SignificantDigits
        {
            get { return _significantDigits; }
            set { SetProperty(ref _significantDigits, value); }
        }
    }
}
