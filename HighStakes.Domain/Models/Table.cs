using System.Collections.Generic;
using HighStakes.Domain.Abstracts;

namespace HighStakes.Domain.Models
{
    public class DTable : AGame
    {
        public int TableId { get; set; }
        public List<DSeat> Seats { get; set; }
        public DDeck DeckOfCards { get; set; }
        public DPot MainPot { get; set; }
        public List<DPot> SidePots { get; set; }

        public void Initialize()
        {
            Seats = new List<DSeat>();
            DeckOfCards.Initialize();
            SidePots = new List<DPot>();
            MainPot.Initialize();
            for (int i = 0; i < 6; i++)
            {
                DSeat seat = new DSeat();
                seat.Initialize();
                Seats.Add(seat);
            }
        }

        public void JoinGame(DUser player)
        {
            
        }

        public void StartGame()
        {

        }
    }
}