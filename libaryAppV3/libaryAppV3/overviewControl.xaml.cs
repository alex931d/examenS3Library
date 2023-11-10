using ClassesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace libaryAppV3
{
    /// <summary>
    /// Interaction logic for overviewControl.xaml
    /// </summary>
    public partial class overviewControl : UserControl
    {
        controller CT = controller.Instance;
        public overviewControl()
        {
            InitializeComponent();
            DataContext = CT;
        }

        private void overviewComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content == null)
                return;
           
         CT.updateOverview(selectedItem.Content.ToString());
        }
    }
}
