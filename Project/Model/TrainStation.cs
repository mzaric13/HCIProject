using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class TrainStation : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double x;
        public double X
        {
            get { return x; }
            set
            {
                if (value != x)
                {
                    x = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TrainStation() { }

        public TrainStation(int id, string name)
        {
            Id = id;
            Name = name;
            X = -1;
            Y = -1;
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
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
