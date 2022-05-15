using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Users
    {
        public Dictionary<string, User> systemUsers { get; set; }

        public Users()
        {
            systemUsers = new Dictionary<string, User>
            {
                { "marko@gmail.com", new User("Marko", "Markovic", "marko@gmail.com", "sifra123", UserType.Client) },
                { "jovan@gmail.com", new User("Jovan", "Jovanovic", "jovan@gmail.com", "sifra123", UserType.Manager) }
            };
        }
    }
}
