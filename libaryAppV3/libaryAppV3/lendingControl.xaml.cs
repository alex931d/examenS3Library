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
    /// Interaction logic for lendingControl.xaml
    /// </summary>
    public partial class lendingControl : UserControl
    {
        controller CT = controller.Instance;
        public lendingControl()
        {
            InitializeComponent();
            DataContext = CT;
            CT.init();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lendingDatePicker.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            lendingDatePicker.Visibility = Visibility.Collapsed;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users selectedUser = (users)datagridUsers.SelectedItem;
            bookss selectedPitch = (bookss)reservateBooks.SelectedItem;
            if (selectedUser != null && selectedPitch != null)
            {

                int amount = int.Parse(amountBox.Text.ToString());
                lendings newlending = new lendings();
                if ((bool)checkBoxDate.IsChecked)
                {
                   newlending = new lendings((DateTime)lendingDatePicker.SelectedDate, selectedUser, selectedPitch, amount);
                }
                else
                {
                    newlending = new lendings(DateTime.Now, selectedUser, selectedPitch, amount);
             
                }
  
                    CT.addLending(newlending, selectedUser);
                    MessageBox.Show("sucessfully lended the book!" + " " + "you have til " + DateTime.Now.AddDays(30) + " to return the book");
                    selectedUser = null;
                    selectedPitch = null;
         

            }
        }

        private void reservateBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bookss selectedBook = (bookss)reservateBooks.SelectedItem;
            users selectedUser = (users)datagridUsers.SelectedItem;
            if (selectedBook != null && selectedUser != null)
            {
                CT.UpdateBlackoutDates(selectedBook, selectedUser.Id);
                foreach (var date in CT.BlackoutDates)
                {
                    CalendarDateRange dateRange = new CalendarDateRange(date);
                    lendingDatePicker.BlackoutDates.Add(dateRange);
                }
            }
        }

        private void datagridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bookss selectedBook = (bookss)reservateBooks.SelectedItem;
            users selectedUser = (users)datagridUsers.SelectedItem;
            if (selectedBook != null && selectedUser != null)
            {
                CT.UpdateBlackoutDates(selectedBook, selectedUser.Id);
                foreach (var date in CT.BlackoutDates)
                {
                    CalendarDateRange dateRange = new CalendarDateRange(date);
                    lendingDatePicker.BlackoutDates.Add(dateRange);
                }
            }
        }
    }
}
