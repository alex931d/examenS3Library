using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLib
{
    public class roles
    {
      public roles() { }

        public roles(string role)
        {
            Role = role;
        }

        public int Id { get; set; }
        public string Role { get; set; }

    }
}
