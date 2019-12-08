using System.Collections.Generic;
using HighStakes.Domain.Abstracts;

namespace HighStakes.Domain.Models
{
    public class DTable : AGame
    {
        public int TableId { get; set; }
        public List<DSeat> Seats { get; set; }
        public DDeck DeckOfCards { get; set; }
        public DPot CurrentPot { get; set; }
        public List<DPot> SidePots { get; set; }
        public int SmallBlindAmount { get; set; }
        public int BigBlindAmount { get; set; }

        public void Initialize(int smallBlindAmount, int bigBlindAmount)
        {
            Seats = new List<DSeat>();
            DeckOfCards.Initialize();
            SidePots = new List<DPot>();
            CurrentPot.Initialize();
            SmallBlindAmount = smallBlindAmount;
            BigBlindAmount = bigBlindAmount;
            for (int i = 0; i < 6; i++)
            {
                DSeat seat = new DSeat();
                seat.Initialize();
                Seats.Add(seat);
            }
        }

        public bool JoinGame(DUser player, int buyIn)
        {
            foreach(DSeat seat in Seats)
            {
                if (!seat.Occupied)
                {
                    player.ChipTotal -= buyIn;
                    seat.SitDown(player, buyIn);
                    return true;
                }
            }
            return false;
        }

        public int NumOfActivePlayers()
        {
            int NumberOfPlayers = 0;
            foreach(DSeat seat in Seats)
            {
                if (seat.Occupied)
                    NumberOfPlayers++;
            }
            return NumberOfPlayers;
        }

        public bool StartGame()
        {
            int NumberOfPlayers = 0;
            bool AssignDealer = false;
            bool AssignSmallBlind = false;
            bool AssignBigBlind = false;
            int i = 0;

            NumberOfPlayers = NumOfActivePlayers();

            if (NumberOfPlayers >= 2)
            {
                for (i = 0; i < 6; i++)
                {
                    if (Seats[i].Occupied)
                    {
                        if (!AssignDealer)
                        {
                            Seats[i].Dealer = true;
                            AssignDealer = true;
                            if (NumberOfPlayers == 2)
                            {
                                Seats[i].SmallBlind = true;
                                AssignSmallBlind = true;
                            }
                        } else if (!AssignSmallBlind)
                        {
                            Seats[i].SmallBlind = true;
                            AssignSmallBlind = true;
                        } else if (!AssignBigBlind)
                        {
                            Seats[i].BigBlind = true;
                            AssignBigBlind = true;
                        }
                    }
                }
                return true;
            }
            return false;
        }
    
        public void RunGame()
        {

        }

        public void StartRound()
        {
            int NumberOfPlayers = NumOfActivePlayers();
            DeckOfCards.Initialize();

            foreach (DSeat seat in Seats)
            {
                if (seat.SmallBlind)
                {
                    seat.Bid(SmallBlindAmount);
                }
                if (seat.BigBlind)
                {
                    seat.Bid(BigBlindAmount);
                }
            }

            // going to need to set up pot to handle the side pots before can accept any bids, even small blind big blind

        }
    }
}