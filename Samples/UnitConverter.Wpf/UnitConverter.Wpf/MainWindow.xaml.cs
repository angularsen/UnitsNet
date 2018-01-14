using System.ComponentModel;

namespace Wpf_GenericUnitConverter
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
