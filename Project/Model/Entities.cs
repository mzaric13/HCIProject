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
        public List<Train> systemTrains { get; set; }
        public List<Timetable> systemTimetables { get; set; }
        public List<Route> systemRoutes { get; set; }
        public List<TrainStation> systemTrainStations { get; set; }
        public List<BoardingCard> systemBoardingCards { get; set; }
        public List<string> months { get; set; }
        public Dictionary<string, string> monthNumbers { get; set; }

        public Entities()
        {
            months = new List<string>
            {
                "Januar",
                "Februar",
                "Mart",
                "April",
                "Maj",
                "Jun",
                "Jul",
                "Avgust",
                "Septembar",
                "Oktobar",
                "Novembar",
                "Decembar"
            };

            monthNumbers = new Dictionary<string, string>();
            monthNumbers.Add("Januar", "1");
            monthNumbers.Add("Februar", "2");
            monthNumbers.Add("Mart", "3");
            monthNumbers.Add("April", "4");
            monthNumbers.Add("Maj", "5");
            monthNumbers.Add("Jun", "6");
            monthNumbers.Add("Jul", "7");
            monthNumbers.Add("Avgust", "8");
            monthNumbers.Add("Septembar", "9");
            monthNumbers.Add("Oktobar", "10");
            monthNumbers.Add("Novembar", "11");
            monthNumbers.Add("Decembar", "12");

            User u1 = new User("Marko", "Markovic", "marko@gmail.com", "sifra123", UserType.Client);
            User u2 = new User("Jovan", "Jovanovic", "jovan@gmail.com", "sifra123", UserType.Manager);
            User u3 = new User("Pera", "Peric", "pera@gmail.com", "sifra123", UserType.Client);
            systemUsers = new Dictionary<string, User>
            {
                { "marko@gmail.com", u1 },
                { "jovan@gmail.com", u2 },
                { "pera@gmail.com", u3 }
            };

            Train t1 = new Train(1, "Soko");
            Train t2 = new Train(2, "Soko");
            Train t3 = new Train(3, "RegioEkspres");
            Train t4 = new Train(4, "RegioEkspres");

            systemTrains = new List<Train>
            {
                t1,
                t2,
                t3,
                t4,
            };

            TrainStation ts1 = new TrainStation(1, "Beograd", 340, 120);
            TrainStation ts2 = new TrainStation(2, "Zemun", 325, 115);
            TrainStation ts3 = new TrainStation(3, "Stara Pazova", 310, 110);
            TrainStation ts4 = new TrainStation(4, "Indjija", 305, 100);
            TrainStation ts5 = new TrainStation(5, "Beska", 295, 90);
            TrainStation ts6 = new TrainStation(6, "Sremski Karlovci", 285, 85);
            TrainStation ts7 = new TrainStation(7, "Petrovaradin", 265, 80);
            TrainStation ts8 = new TrainStation(8, "Novi Sad", 250, 80);
            TrainStation ts9 = new TrainStation(9, "Vrbas", 260, 60);
            TrainStation ts10 = new TrainStation(10, "Subotica", 230, 30);

            systemTrainStations = new List<TrainStation>
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

            Route r1 = new Route(1, ts1, ts8, new List<TrainStation> { ts2, ts3, ts4, ts5, ts6, ts7 });
            r1.Prices = new List<int> { 50, 100, 150, 200, 250, 300, 350 };
            Route r2 = new Route(2, ts8, ts1, new List<TrainStation> { ts7, ts6, ts5, ts4, ts3, ts2 });
            r2.Prices = new List<int> { 50, 100, 150, 200, 250, 300, 350 };
            Route r3 = new Route(3, ts1, ts8, new List<TrainStation> { });
            r3.Prices = new List<int> { 300 };
            Route r4 = new Route(4, ts8, ts1, new List<TrainStation> { });
            r4.Prices = new List<int> { 300 };
            Route r5 = new Route(5, ts8, ts10, new List<TrainStation> { ts9 });
            r5.Prices = new List<int> { 150, 300 };
            Route r6 = new Route(6, ts10, ts8, new List<TrainStation> { ts9 });
            r6.Prices = new List<int> { 150, 300};

            systemRoutes = new List<Route>
            {
                r1,
                r2,
                r3,
                r4,
                r5,
                r6
            };

            Timetable tt1 = new Timetable(1, "12:00", "15.06.2022.", "14:00", "15.06.2022.", t3, r1);
            Timetable tt2 = new Timetable(2, "14:00", "15.06.2022.", "16:00", "15.06.2022.", t3, r1);
            Timetable tt3 = new Timetable(3, "11:00", "15.06.2022.", "13:00", "15.06.2022.", t4, r2);
            Timetable tt4 = new Timetable(4, "12:00", "16.06.2022.", "14:00", "16.06.2022.", t4, r1);
            Timetable tt5 = new Timetable(5, "14:00", "16.06.2022.", "16:00", "16.06.2022.", t4, r1);
            Timetable tt6 = new Timetable(6, "17:00", "15.06.2022.", "17:30", "15.06.2022.", t1, r3);
            Timetable tt7 = new Timetable(7, "13:00", "16.06.2022.", "15:00", "16.06.2022.", t3, r2);
            Timetable tt8 = new Timetable(8, "17:00", "15.06.2022.", "17:30", "15.06.2022.", t2, r4);
            Timetable tt9 = new Timetable(9, "14:30", "15.06.2022.", "15:30", "15.06.2022.", t3, r5);
            Timetable tt10 = new Timetable(10, "15:30", "15.06.2022.", "16:30", "15.06.2022.", t3, r6);
            Timetable tt11 = new Timetable(11, "14:30", "16.06.2022.", "15:30", "16.06.2022.", t3, r5);
            Timetable tt12 = new Timetable(12, "15:30", "16.06.2022.", "16:30", "16.06.2022.", t3, r6);

            systemTimetables = new List<Timetable>
            {
                tt1,
                tt2,
                tt3,
                tt4,
                tt5,
                tt6,
                tt7,
                tt8,
                tt9,
                tt10,
                tt11,
                tt12
            };

            BoardingCard bc1 = new BoardingCard(u1, new List<Timetable>() { tt1 }, ts1, ts8, "10.06.2022.", BoardingCardState.BOUGHT, 350);
            BoardingCard bc2 = new BoardingCard(u3, new List<Timetable>() { tt1 }, ts1, ts8, "10.06.2022.", BoardingCardState.BOUGHT, 350);
            BoardingCard bc3 = new BoardingCard(u3, new List<Timetable>() { tt3 }, ts6, ts1, "10.06.2022.", BoardingCardState.RESERVED, 250);

            systemBoardingCards = new List<BoardingCard>
            {
                bc1,
                bc2,
                bc3
            };
        }

    }
}
