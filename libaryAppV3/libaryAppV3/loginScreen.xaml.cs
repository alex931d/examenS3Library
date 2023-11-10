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
    /// Interaction logic for loginScreen.xaml
    /// </summary>
    public partial class loginScreen : Window
    {
        controller CT = controller.Instance;
        public loginScreen()
        {
            InitializeComponent();
            DataContext = CT;
            CT.LoginStatusChanged += Controller_LoginStatusChanged;
        }
        private void Controller_LoginStatusChanged(object sender, bool isLoggedIn)
        {
         
            if (isLoggedIn)
            {
                MainWindow productsApp = new MainWindow();
                productsApp.Show();
                Close();
            }
            else
            {
                userMenu productsApp = new userMenu();
                productsApp.Show();
                Close();
            }
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int login = int.Parse(username.Text.ToString());
            string password = pasword.Text.ToString();
            if (!string.IsNullOrEmpty(login.ToString()) && !string.IsNullOrEmpty(password))
            {
                if (CT.TryLogin(login, password))
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("worng password or username try again!");
                }
            }
            else
            {
                MessageBox.Show("error try again!");
            }
          
        }
    }
}
