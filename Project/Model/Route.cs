using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Route : INotifyPropertyChanged  
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

        private TrainStation startingStation;
        public TrainStation StartingStation
        {
            get { return startingStation; }
            set
            {
                if (value != startingStation)
                {
                    startingStation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private TrainStation endingStation;
        public TrainStation EndingStation
        {
            get { return endingStation; }
            set
            {
                if (value != endingStation)
                {
                    endingStation = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private List<TrainStation> stations;
        public List<TrainStation> Stations
        {
            get { return stations; }
            set 
            { 
                if (value != stations)
                {
                    stations = value;
                    NotifyPropertyChanged();
                }   
            }
        }

        private List<int> prices;
        public List<int> Prices
        {
            get { return prices; }
            set
            {
                if (value != prices)
                {
                    prices = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Route() { }

        public Route(int id, TrainStation startingStation, TrainStation endingStation, List<TrainStation> stations)
        {
            Id = id;
            StartingStation = startingStation;      
            EndingStation = endingStation;
            Stations = stations;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
