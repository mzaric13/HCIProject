using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Entities
    {
        public Dictionary<string, User> systemUsers { get; set; }
        public User loggedUser { get; set; }

        public string currentError { get; set; }
        public List<Train> systemTrains { get; set; }

        public Entities()
        {
            systemUsers = new Dictionary<string, User>
            {
                { "marko@gmail.com", new User("Marko", "Markovic", "marko@gmail.com", "sifra123", UserType.Client) },
                { "jovan@gmail.com", new User("Jovan", "Jovanovic", "jovan@gmail.com", "sifra123", UserType.Manager) }
            };

            systemTrains = new List<Train>
            {
                new Train(001, "BrzaPtica"),
                new Train(002, "BrzaPtica"),
                new Train(003, "BrzaPtica"),
                new Train(004, "BrzaPtica"),
                new Train(005, "SamoVozovi"),
                new Train(006, "SamoVozovi"),
                new Train(007, "SamoVozovi"),
                new Train(008, "SamoVozovi")
            };
        }
         
    }
}
