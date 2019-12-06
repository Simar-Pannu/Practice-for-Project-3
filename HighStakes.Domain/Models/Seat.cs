using System.Collections.Generic;
using System.Linq;
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
            Player = new User();
            PlayerHand = new Hand();
            Pocket = new List<Card>();
            PlayerHand.Initialize();
        }

        public bool IsPair(List<Card> hand)
        {
            return hand.GroupBy(h => h.Value).Where(g => g.Count() == 2).Count() == 1;
        }
    }
}