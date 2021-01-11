using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorization
{
    public class User
    {
        public  int id { get; set; }
        private string login;
        private string password;
        private string email;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public User() 
        {
        }

        public User(string login, string email, string password) 
        {
            this.login = login;
            this.email = email;
            this.password = password;
        }

        public override string ToString()
        {
            return "User: " + Login + ". Email: " + Email;
        }


    }

}
