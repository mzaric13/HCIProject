using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Timetable : INotifyPropertyChanged
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _startTime;
        public string startTime
        {
            get { return _startTime; }
            set
            {
                if (value != _startTime)
                {
                    _startTime = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _startDate;
        public string startDate
        {
            get { return _startDate; }
            set
            {
                if (value != _startDate)
                {
                    _startDate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _endTime;
        public string endTime
        {
            get { return _endTime; }
            set
            {
                if (value != _endTime)
                {
                    _endTime = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _endDate;
        public string endDate
        {
            get { return _endDate; }
            set
            {
                if (value != _endDate)
                {
                    _endDate = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Train _train;
        public Train train
        {
            get { return _train; }
            set
            {
                if (value != _train)
                {
                    _train = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Route route;
        public Route Route
        {
            get { return route; }
            set
            {
                if (value != route)
                {
                    route = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
