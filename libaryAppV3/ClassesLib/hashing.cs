using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLib
{
    public class hashing
    {
        public string hashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }
        public bool comparePassword(string password, string hashedPassword)
        {
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            if (passwordMatch)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
