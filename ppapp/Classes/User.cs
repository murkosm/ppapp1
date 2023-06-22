using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppapp.Classes
{
    public class User
    {
        public string Login { get; set;}
        public bool is_admin { get;}

        public string Status => is_admin ? "Admin" : "User";

        public User(string login, bool isAdmin)
        {
            Login = login.Trim();
            is_admin = isAdmin;
        }
    }
}
