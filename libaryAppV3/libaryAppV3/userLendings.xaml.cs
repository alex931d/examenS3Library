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
    /// Interaction logic for userLendings.xaml
    /// </summary>
    public partial class userLendings : UserControl
    {
        controller CT = controller.Instance;
        public userLendings()
        {
            InitializeComponent();
            DataContext = CT;
            CT.init();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                bookss selectedPitch = (bookss)reservateBooks.SelectedItem;
                if (selectedPitch != null)
                {
                    int amount = int.Parse(amountBox.Text.ToString());
                    lendings newlending = new lendings(DateTime.Now, temp.Instance.user, selectedPitch, amount);
                    try
                    {
                        CT.addLending(newlending, temp.Instance.user);
                        MessageBox.Show("sucessfully lended the book!" + " " + "you have 30 days to return the book");
                        selectedPitch = null;
                    }
                    catch (Exception)
                    {
                    MessageBox.Show("unsucessful something happened!");
                    throw;
                    }


                }
            
        }
    }
}
