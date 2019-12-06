using System.Collections.Generic;

namespace HighStakes.Domain.Models
{
    public class Hand
    {
        public int HandId { get; set; }
        public List<Card> HandCards { get; set; }
        public int HandValue { get; set; }

        public void Initialize()
        {
            HandCards = new List<Card>();
        }
    }
}