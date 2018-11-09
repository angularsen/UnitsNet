using Prism.Unity;
using System.Windows;
using CommonServiceLocator;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;
using WpfMVVMSample.Settings;

namespace WpfMVVMSample
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<SettingsManager>(new ContainerControlledLifetimeManager());//singleton
        }

        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();

            var serviceLocator = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);

        }
    }
}
