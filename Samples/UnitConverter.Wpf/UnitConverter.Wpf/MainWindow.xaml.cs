using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

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

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Scroll to view on selection change - fixes issue where on app startup Length was selected but not scrolled to
            var listbox = (ListBox) sender;
            var firstSelectedItem = listbox.SelectedItems.Cast<object>().FirstOrDefault();
            if (firstSelectedItem == null)
            {
                return;
            }

            listbox.ScrollIntoView(firstSelectedItem);
        }
    }
}
