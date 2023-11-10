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
    /// Interaction logic for userReturns.xaml
    /// </summary>
    public partial class userReturns : UserControl
    {
        controller CT = controller.Instance;
        public userReturns()
        {
            InitializeComponent();
            DataContext = CT;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lendings selectedLending = (lendings)returnBooksData.SelectedItem;
            if (selectedLending != null)
            {
                CT.deleteLending(selectedLending,temp.Instance.user);
                MessageBox.Show("book has been returned!");
            }
            else
            {
                MessageBox.Show("error returning try again!");
            }
        }
    }
}
