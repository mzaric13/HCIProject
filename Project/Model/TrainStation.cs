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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is TrainStation)
            {
                TrainStation ts = (TrainStation)obj;
                return Id == ts.Id && Name == ts.Name;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
