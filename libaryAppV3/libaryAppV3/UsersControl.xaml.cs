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
    /// Interaction logic for UsersControl.xaml
    /// </summary>
    public partial class UsersControl : UserControl
    {
        controller CT = controller.Instance;
        public UsersControl()
        {
            InitializeComponent();
            DataContext = CT;
            CT.init();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IdBox.Text.ToString());
            string password = passwordsBox.Text.ToString();
            if (string.IsNullOrEmpty(id.ToString()) || password != null)
            {
                try
                {
                    users newuser = new users(id, password);
                    CT.AddUser(newuser);
                    MessageBox.Show("User has been created!" + " " + "as " + newuser.UsernameId);
                }
                catch (Exception)
                {

                    throw;
                }
               
            }
            else
            {
                MessageBox.Show("error creating user");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users selectedUser = (users)usersGrid.SelectedItem;
            if (selectedUser != null)
            {
                int id = int.Parse(IdBox.Text.ToString());
                string password = passwordsBox.Text.ToString();
                if (string.IsNullOrEmpty(id.ToString()) || password != null)
                {
                    CT.UpdateUser(selectedUser, id, password);
                }
                else
                {
                    MessageBox.Show("error updating user");
                }
                   
            }
            else
            {
                MessageBox.Show("no selected row");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            users selectedUser = (users)usersGrid.SelectedItem;
            if (selectedUser != null)
            {
                CT.DeleteUser(selectedUser);
            }
            else
            {
                MessageBox.Show("no selected row");
            }
        }
    }
}
