using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLib
{
   public class temp
    {
        public static int UserId { get; set; }
        public static int name { get; set; }
        private static temp instance;
        public event EventHandler UserChanged;
        private temp() { }
        public static temp Instance

        {
            get
            {
                if (instance == null)
                {
                    instance = new temp();
                }
                return instance;
            }
        }

        private users _user;

        public users user
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    UserChanged?.Invoke(this, EventArgs.Empty); // Raise the event
                }
            }
        }
    }

    
}
