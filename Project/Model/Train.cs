using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Train : INotifyPropertyChanged
    {
        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (value != number)
                {
                    number = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _operator;
        public string Operator
        {
            get { return _operator; }
            set
            {
                if (value != _operator)
                {
                    _operator = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Train()
        {

        }

        public Train(int Number, string Operator)
        {
            this.Number = Number;
            this.Operator = Operator;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
