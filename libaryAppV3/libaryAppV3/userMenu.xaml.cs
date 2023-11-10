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
using System.Windows.Shapes;

namespace libaryAppV3
{
    /// <summary>
    /// Interaction logic for userMenu.xaml
    /// </summary>
    public partial class userMenu : Window
    {
        controller CT = controller.Instance;
        public userMenu()
        {
            InitializeComponent();
            CT.ConfirmCallback = ShowConfirmationDialog;
            welcomeLbl.Content = "welcome User: " + temp.name;
        }
        private bool ShowConfirmationDialog(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CT.logout();

            loginScreen login = new loginScreen();
            login.Show();
            Close();
        }
    }
}
