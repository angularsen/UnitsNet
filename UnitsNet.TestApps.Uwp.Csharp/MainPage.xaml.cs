using Windows.UI.Xaml.Controls;
using UnitsNet;
using UnitsNet.Units;

namespace UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        ///     Example of public property returning WinRT component compatible type.
        /// </summary>
        public Temperature MyTemperature { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Test some variations, From() constructors, Parse(), As()
            string celsius = Temperature.FromDegreesCelsius(100).ToString(TemperatureUnit.DegreeCelsius);
            string fahrenheit = Temperature.Parse("100 °C").ToString(TemperatureUnit.DegreeFahrenheit);
            string kelvin = Temperature.FromDegreesCelsius(Temperature.Parse(fahrenheit).As(TemperatureUnit.DegreeCelsius)).ToString(TemperatureUnit.Kelvin);

            // Arithmetic operators not allowed in WinRT Components, but SHOULD be allowed in UWP C# apps
            // new Temperature(5) + new Temperature(6)

            MyTextBlock.Text = $"{celsius} = {fahrenheit} = {kelvin}";
        }
    }
}
