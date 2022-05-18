using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class TrainStation
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public TrainStation() { }

        public TrainStation(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() { 
            return Name;
        }
    }
}
