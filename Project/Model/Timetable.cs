using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Timetable
    {
        public int id { get; set; }
        public string startTime { get; set; }
        public string startDate { get; set; }
        public string endTime { get; set; }
        public string endDate { get; set; }
        public Train train { get; set; }

        public Route Route { get; set; }

        public Timetable()
        {

        }

        public Timetable(int id, string startTime, string startDate, string endTime, string endDate, Train train, Route route)
        {
            this.id = id;
            this.startTime = startTime;
            this.startDate = startDate;
            this.endTime = endTime;
            this.endDate = endDate;
            this.train = train;
            this.Route = route;
        }
    }
}
