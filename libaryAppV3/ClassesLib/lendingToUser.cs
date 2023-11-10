using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLib
{
    public class lendingToUser
    {
        public lendingToUser() {}

        public lendingToUser(lendings bookLendt, users userLendtTo)
        {
            BookLendt = bookLendt;
            UserLendtTo = userLendtTo;
        }

        public int Id { get; set; }
        public lendings BookLendt { get; set; }
        public users UserLendtTo { get; set; }

    }
}
