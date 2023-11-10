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
    /// Interaction logic for returnControl.xaml
    /// </summary>
    public partial class returnControl : UserControl
    {
        controller CT = controller.Instance;
        public returnControl()
        {
            InitializeComponent();
            DataContext = CT;
            CT.init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lendings selectedLending = (lendings)datagridLendings.SelectedItem;
            users selectedUser = (users)datagridUsers.SelectedItem;
            if (selectedLending != null && selectedUser != null)
            {
                CT.deleteLending(selectedLending,selectedUser);
               
                MessageBox.Show("the current lending has been returned!");
            }
            else
            {
                MessageBox.Show("no lendings to return");
            }
        }
    }
}
