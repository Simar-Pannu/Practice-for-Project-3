using System.Collections.Generic;
using HighStakes.Domain.Abstracts;

namespace HighStakes.Domain.Models
{
    public class DTable : AGame
    {
        public int TableId { get; set; }
        public List<DSeat> Seats { get; set; }
        public DDeck DeckOfCards { get; set; }
        public List<DPot> Pots { get; set; }
    }
}