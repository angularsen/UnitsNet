## WPF MVVM Sample
This is a simple sample showing how UnitsNet can be used to create a WPF MVVM application. I have used this strategy in a few simple engineering apps and thought I would share it as a sample to see if others might offer improvements.

It performs a simple calculation allowing flexibility in the units for parameters and results. Default units for each are specified in the settings drop down.

A key feature enabling this sample is the [UnitToStringConverter](https://github.com/dayewah/UnitsNet/blob/master/Samples/WpfMVVMSample/WpfMVVMSample/Converters/UnitToStringConverter.cs) class
- If a parameter is entered as a number the unit is assigned automatically
- If a parameter is entered as a unit other than the default it is converted automatically
- If a non-compatible unit is used a validation error is triggered

The default unit for each parameter and the result can be changed from the settings pull down.

The number of significant digits displayed can also be changed from settings.