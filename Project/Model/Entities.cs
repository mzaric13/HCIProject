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
        public List<Timetable> systemTimetables { get; set; }
        public List<Route> systemRoutes { get; set; }

        public List<TrainStation> systemStations { get; set; }
        public Entities()
        {
            systemUsers = new Dictionary<string, User>
            {
                { "marko@gmail.com", new User("Marko", "Markovic", "marko@gmail.com", "sifra123", UserType.Client) },
                { "jovan@gmail.com", new User("Jovan", "Jovanovic", "jovan@gmail.com", "sifra123", UserType.Manager) }
            };

            systemTrains = new List<Train>
            {
                new Train(1, "BrzaPtica"),
                new Train(2, "BrzaPtica"),
                new Train(3, "BrzaPtica"),
                new Train(4, "BrzaPtica"),
                new Train(5, "SamoVozovi"),
                new Train(6, "SamoVozovi"),
                new Train(7, "SamoVozovi"),
                new Train(8, "SamoVozovi")
            };

            systemTimetables = new List<Timetable>
            {
                new Timetable(1, "12:00", "25.05.2022.", "14:00", "25.05.2022", new Train(001, "BrzaPtica")),
                new Timetable(2, "12:00", "26.05.2022.", "14:00", "26.05.2022", new Train(001, "BrzaPtica")),
                new Timetable(3, "11:00", "27.05.2022.", "13:00", "27.05.2022", new Train(001, "BrzaPtica")),
                new Timetable(4, "12:00", "25.05.2022.", "14:00", "25.05.2022", new Train(002, "BrzaPtica")),
                new Timetable(5, "12:00", "30.05.2022.", "14:00", "30.05.2022", new Train(002, "BrzaPtica")),
                new Timetable(6, "15:00", "31.05.2022.", "17:00", "31.05.2022", new Train(002, "BrzaPtica")),
                new Timetable(7, "20:00", "25.05.2022.", "23:30", "25.05.2022", new Train(005, "SamoVozovi")),
                new Timetable(8, "09:00", "26.05.2022.", "11:00", "26.05.2022", new Train(006, "SamoVozovi")),
                new Timetable(9, "12:00", "25.05.2022.", "14:00", "25.05.2022", new Train(007, "SamoVozovi")),
            };

            TrainStation ts1 = new TrainStation(1, "Beograd");
            TrainStation ts2 = new TrainStation(2, "Zemun");
            TrainStation ts3 = new TrainStation(3, "Stara Pazova");
            TrainStation ts4 = new TrainStation(4, "Indjija");
            TrainStation ts5 = new TrainStation(5, "Beska");
            TrainStation ts6 = new TrainStation(6, "Sremski Karlovci");
            TrainStation ts7 = new TrainStation(7, "Petrovaradin");
            TrainStation ts8 = new TrainStation(8, "Novi Sad");
            TrainStation ts9 = new TrainStation(9, "Vrbas");
            TrainStation ts10 = new TrainStation(10, "Subotica");

            systemStations = new List<TrainStation>
            {
                ts1,
                ts2,
                ts3,
                ts4,
                ts5,
                ts6,
                ts7,
                ts8,
                ts9,
                ts10
            };

            systemRoutes = new List<Route>
            {
                new Route(1, ts1, ts8, new List<TrainStation>{ts2, ts3, ts4, ts5, ts6, ts7}),
                new Route(2, ts8, ts1, new List<TrainStation>{ts2, ts3, ts4, ts5, ts6, ts7}),
                new Route(3, ts1, ts8, new List<TrainStation> { }),
                new Route(4, ts8, ts1, new List<TrainStation>{ }),
                new Route(5, ts8, ts10, new List<TrainStation>{ts9}),
                new Route(6, ts10, ts8, new List<TrainStation>{ts9})
            };
        }
         
    }
}
