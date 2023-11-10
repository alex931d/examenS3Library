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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        controller CT = controller.Instance;
        int name = temp.name;
        public MainWindow()
        {
        
            InitializeComponent();
            CT.ConfirmCallback = ShowConfirmationDialog;
            DataContext = CT;
            welcomeLbl.Content = "welcome " + name;
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
