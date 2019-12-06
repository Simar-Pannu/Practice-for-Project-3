using System.Collections.Generic;
using HighStakes.Domain.Abstracts;

namespace HighStakes.Domain.Models
{
    public class Seat : AGame
    {
        public int SeatId { get; set; }
        public User Player { get; set; }
        public int ChipTotal { get; set; }
        public List<Card> Pocket { get; set; }
        public Hand PlayerHand { get; set; }
        public bool BigBlind { get; set; }
        public bool SmallBlind { get; set; }

        public void Initialize()
        {
            Pocket = new List<Card>();
            PlayerHand.Initialize();
        }

        
    }
}