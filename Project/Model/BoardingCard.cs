using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{

    public enum BoardingCardState
    {
        RESERVED, BOUGHT
    }

    public class BoardingCard
    {
        public User User { get; set; }

        public List<Timetable> Timetable { get; set; }

        public string DateOfPurchase { get; set; }

        public BoardingCardState State { get; set; }

        public int Price { get; set; }

        public BoardingCard() { }

        public BoardingCard(User user, List<Timetable> timetables, string dateOfPurchase, BoardingCardState state)
        {
            User = user;
            Timetable = timetables;
            DateOfPurchase = dateOfPurchase;
            State = state;
        }
    }
}
