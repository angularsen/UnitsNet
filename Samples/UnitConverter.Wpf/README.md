## Unit Converter WPF Sample App

This is a simple sample showing how UnitsNet can be used to create a generic unit converter, using all the quantities and units available in the UnitsNet library.

![image](https://user-images.githubusercontent.com/787816/34920961-9b697004-f97b-11e7-9e9a-51ff7142969b.png)

It allows you to convert a value from one unit to another, by first selecting the quantity (`Length`), then selecting the from/to units (`Meter` to `Centimeter`) and finally typing the numeric value (`15.3`).
The resulting value (`1530`) is computed instantly and reacts to whenever the numeric value or the from/to unit selection changes.

This sample also highlights a limitation in the library that requires reflection in order to enumerate units for a selected quantity and to get the abbreviation for a unit, since the library does not provide a generic means to retrieve these without referencing types like `Length` and `LengthUnit` directly. There is definitely room for improvement in the library here.

### Dependencies
http://mahapps.com/ - UI toolkit for WPF