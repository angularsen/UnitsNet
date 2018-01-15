using System.ComponentModel;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {

            }
            else
            {
                DataContext = new MainWindowVm();
            }
        }
    }
}
