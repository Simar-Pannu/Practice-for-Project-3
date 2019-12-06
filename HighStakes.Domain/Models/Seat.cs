using System.Collections.Generic;
using HighStakes.Domain.Abstracts;

namespace HighStakes.Domain.Models
{
    public class Seat : AGame
    {
        public int SeatId { get; set; }
        public User Player { get; set; }
        public List<Card> Hand { get; set; }
        public bool BigBlind { get; set; }
        public bool SmallBlind { get; set; }
    }
}