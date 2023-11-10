using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLib
{
    public class users
    {
        public users() { }
        public users(int usernameId, string password)
        {
            UsernameId = usernameId;
            Password = password;
        }

        public int Id { get; set; }
        public int UsernameId { get; set; }
        public string Password { get; set; }
        public roles Role { get; set; }
    }
}
