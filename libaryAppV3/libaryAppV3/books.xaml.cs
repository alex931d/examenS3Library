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
    /// Interaction logic for books.xaml
    /// </summary>
    public partial class books : UserControl
    {
        controller CT = controller.Instance;
        public books()
        {
            InitializeComponent();
            DataContext = CT;
            CT.init();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DateTime? date = datepickerYear.SelectedDate;
            string author = authorBox.Text.ToString();
            string title = titleBox.Text.ToString();
            string publisher = publisherBox.Text.ToString();
            DateTime year = date.Value;

            int count = int.Parse(countBox.Text.ToString());
            int ISBN = int.Parse(ISBNBox.Text.ToString());
            bookss newbook = new bookss(author, title, publisher, year, count,ISBN);
            try
            {
                CT.addBooks(newbook);
                MessageBox.Show("the book has been created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "book creation error");
            }
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bookss selectedBook = (bookss)BooksGrid.SelectedItem;
            DateTime? date = datepickerYear.SelectedDate;
            if (selectedBook != null)
            {

                string author = authorBox.Text.ToString();
                string title = titleBox.Text.ToString();
                string publisher = publisherBox.Text.ToString();
                DateTime year = date.Value;
                int count = int.Parse(countBox.Text.ToString());
                int ISBN = int.Parse(ISBNBox.Text.ToString());

         
                    try
                    {
                       CT.updateBook(selectedBook, author, title, publisher, year, count, ISBN);
                        BooksGrid.Items.Refresh();
                        MessageBox.Show("the book has been updated");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "book update error");
                    }
                }
                else
                {
                    MessageBox.Show("please select a book to update!");
                }
            }
       
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bookss selectedBook = (bookss)BooksGrid.SelectedItem;
            if (selectedBook != null)
            {
                try
                {
                    CT.deleteBook(selectedBook);
                    MessageBox.Show("the book has been deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "book delete error");
                }
        
            }
            else
            {
                MessageBox.Show("no selected row");
            }
        }
    }
}
