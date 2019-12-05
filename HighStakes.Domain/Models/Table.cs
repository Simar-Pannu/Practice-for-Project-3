using System.Collections.Generic;

namespace HighStakes.Domain.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public List<Seat> Seats { get; set; }
        public Deck DeckOfCards { get; set; }
        public List<Card> ActiveCards { get; set; }
        public List<Pot> Pots { get; set; }
    }
}