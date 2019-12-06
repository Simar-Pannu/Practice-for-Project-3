using System.Collections.Generic;
using HighStakes.Domain.Abstracts;

namespace HighStakes.Domain.Models
{
    public class Table : AGame
    {
        public int TableId { get; set; }
        public List<Seat> Seats { get; set; }
        public Deck DeckOfCards { get; set; }
        public List<Pot> Pots { get; set; }
    }
}