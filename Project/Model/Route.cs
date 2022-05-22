using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Route
    {

        public int Id { get; set; }
        public TrainStation StartingStation { get; set; }

        public TrainStation EndingStation { get; set; }

        public List<TrainStation> Stations { get; set; }

        public Route() { }

        public Route(int id, TrainStation startingStation, TrainStation endingStation, List<TrainStation> stations)
        {
            Id = id;
            StartingStation = startingStation;      
            EndingStation = endingStation;
            Stations = stations;
        }
    }
}
