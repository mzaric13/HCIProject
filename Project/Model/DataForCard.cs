using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    internal class DataForCard
    {
        public List<Timetable> Timetables { get; set; }

        public string StartingStation { get; set; }

        public string EndingStation { get; set; }

        public string StartingTime { get; set; }

        public string EndingTime { get; set; }

        public string TrainName { get; set; }

        public int Price { get; set; }

        public int NumOfCards = 1;

        public DataForCard() { }

        public DataForCard(List<Timetable> timetables, string startingStation, string endingStation,string startingTime, string endingTime, string trainName, int price)
        {
            Timetables = timetables;
            StartingStation = startingStation;
            EndingStation = endingStation;
            StartingTime = startingTime;
            EndingTime = endingTime;
            TrainName = trainName;
            Price = price;
        }

        public DataForCard(Timetable timetable, string startingStation, string endingStation, string startingTime, string endingTime, string trainName, int price)
        {
            Timetables = new List<Timetable> { timetable };
            StartingStation = startingStation;
            EndingStation = endingStation;
            StartingTime = startingTime;
            EndingTime = endingTime;
            TrainName = trainName;
            Price = price;
        }
    }
}
