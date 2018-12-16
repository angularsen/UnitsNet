using System.Windows;
using Prism.Ioc;
using WpfMVVMSample.Settings;

namespace WpfMVVMSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<SettingsManager>();
        }

        protected override Window CreateShell()
        {
            return new MainWindow();
        }
    }
}
