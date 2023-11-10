using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLib
{
    public class lendings
    {
        public lendings() { }

        public lendings(DateTime date, users user, bookss book, int count)
        {
            Date = date;
            User = user;
            Book = book;
            Count = count;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public users User { get; set; }
        public bookss Book { get; set; }
        public int Count { get; set; }
    }
}
