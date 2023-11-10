using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ClassesLib
{
    public class bookss : INotifyPropertyChanged
    {
        public bookss() { }
        public bookss(string author, string title, string publisher, DateTime year, int count, Int32 isbn)
        {
            Author = author;
            Publisher = publisher;
            Year = year;
            Count = count;
            ISBN = isbn;

        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime Year { get; set; }

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                if (count != value)
                {
                    count = value;
                    NotifyPropertyChanged(nameof(Count));
                }
            }
        }
        public int ISBN { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
