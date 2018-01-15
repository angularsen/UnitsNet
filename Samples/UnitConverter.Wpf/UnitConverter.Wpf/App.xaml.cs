using System.Windows;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // BEGIN WORKAROUND
            // HACK to fix issue trying to type "1.5" in the Value textbox when bound to a decimal, since "1." is not a valid decimal value
            // it will prevent you from typing that.
            // We could use Delay=500 in the binding, but it feels weird to only see the updated result value some time after typing
            // in a new value.
            System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;
            // END WORKAROUND

            base.OnStartup(e);
        }
    }
}