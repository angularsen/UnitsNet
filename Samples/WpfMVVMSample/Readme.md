## WPF MVVM Sample
This is a simple sample showing how UnitsNet can be used to create a WPF MVVM application. It performs a simple calculation allowing flexibility in the units used for parameters and results. Units for each parameter are specified in the settings drop down.

A key feature enabling this sample is the UnitToStringConverter class
- If a parameter is entered as a number the unit is assigned automatically
- If a parameter is entered as a unit other than the default is is converted automatically
- If a non compatible unit is used a validation error is triggered

The default unit for each parameter and the result can be changed from the settings pull down.

The number of significant digits displayed can also be changed from settings.