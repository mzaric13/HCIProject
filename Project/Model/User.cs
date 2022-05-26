using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public enum UserType
    {
       Client,
       Manager
    }

    public class User
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UserType userType { get; set; }

        public User()
        {

        }

        public User(string name, string surname, string email, string password, UserType userType)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
            this.userType = userType;
        }

        public override string ToString()
        {
            return name + " " + surname;
        }
    }
}
