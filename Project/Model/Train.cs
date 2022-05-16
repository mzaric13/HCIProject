using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Train
    {
        public int Number { get; set; }
        public string Operator { get; set; }

        public Train()
        {

        }

        public Train(int Number, string Operator)
        {
            this.Number = Number;
            this.Operator = Operator;
        }
    }
}
