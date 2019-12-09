using System.Collections.Generic;
using System.Linq;
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
        public List<DSeat> SeatsInTurnOrder { get; set; }
        public bool RoundStarted { get; set; }

        public void Initialize(int smallBlindAmount, int bigBlindAmount)
        {
            Seats = new List<DSeat>();
            DeckOfCards.Initialize();
            SidePots = new List<DPot>();
            CurrentPot.Initialize();
            SeatsInTurnOrder = new List<DSeat>();
            SmallBlindAmount = smallBlindAmount;
            BigBlindAmount = bigBlindAmount;
            RoundStarted = false;
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
                    if (RoundStarted)
                    {
                        seat.Active = false;
                    }
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

        public void GetTurnOrder()
        {
            int startIndex = 0;
            SeatsInTurnOrder.Clear();
            foreach(DSeat seat in Seats)
            {
                if (seat.SmallBlind)
                {
                    startIndex = Seats.IndexOf(seat);
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (startIndex >= 6)
                {
                    startIndex = 0;
                }
                if (Seats[startIndex].Occupied)
                {
                    SeatsInTurnOrder.Add(Seats[startIndex]);
                }
                startIndex++;
            }
        }

        public void EndRound()
        {
            int PotTotal = 0;
            int NewPot = 0;
            DSeat winningSeat = new DSeat();
            List<DSeat> PeopleWhoCanWinMoney = new List<DSeat>();
            List<DSeat> NewPotPeople = new List<DSeat>();
            List<DSeat> MatchingHandValues = new List<DSeat>();
            GetTurnOrder();
            foreach (DSeat seat in SeatsInTurnOrder)
            {
                if (seat.Occupied && seat.Active && seat.RoundBid > 0)
                {
                    PeopleWhoCanWinMoney.Add(seat);
                }
            }
            foreach (DSeat seat in SeatsInTurnOrder)
            {
                if (seat.Occupied)
                {
                    PotTotal += seat.RoundBid;
                }
            }
            if (PeopleWhoCanWinMoney.Count == 1)
            {
                PeopleWhoCanWinMoney[0].ChipTotal += PotTotal;
                return;
            }
            foreach (DSeat seat in PeopleWhoCanWinMoney)
            {
                seat.FindBestHand();
            }
            do {
                PeopleWhoCanWinMoney = PeopleWhoCanWinMoney.OrderByDescending(h => h.HandValue).ToList();
                if (PeopleWhoCanWinMoney[0].HandValue > PeopleWhoCanWinMoney[1].HandValue)
                {
                    for (int i = 1; i < PeopleWhoCanWinMoney.Count; i++)
                    {
                        if (PeopleWhoCanWinMoney[i].RoundBid > PeopleWhoCanWinMoney[0].RoundBid)
                        {
                            NewPotPeople.Add(PeopleWhoCanWinMoney[i]);
                        }
                    }
                    if (NewPotPeople.Count == 0)
                    {
                        PeopleWhoCanWinMoney[0].ChipTotal += PotTotal;
                    } else {
                        foreach (DSeat seat in NewPotPeople)
                        {
                            NewPot += seat.RoundBid - PeopleWhoCanWinMoney[0].RoundBid;
                        }
                        PotTotal -= NewPot;
                        PeopleWhoCanWinMoney[0].ChipTotal += PotTotal;
                        PeopleWhoCanWinMoney = new List<DSeat>(NewPotPeople);
                        NewPotPeople.Clear();
                        PotTotal = NewPot;
                        NewPot = 0;
                    }
                } else {
                    //get list of people who have matching hand values
                    MatchingHandValues.Add(PeopleWhoCanWinMoney[0]);
                    for (int i = 1; i < PeopleWhoCanWinMoney.Count; i++)
                    {
                        if (PeopleWhoCanWinMoney[i].HandValue == PeopleWhoCanWinMoney[0].HandValue)
                        {
                            MatchingHandValues.Add(PeopleWhoCanWinMoney[i]);
                        }
                    }
                    //run through the cards one by one to see if someone has a high value
                    for (int i = 0; i < 5; i++)
                    {
                        foreach (DSeat seat in MatchingHandValues)
                        {
                            seat.HandValue += seat.PlayerHand.HandCards[i].Value;
                        }
                        MatchingHandValues = MatchingHandValues.OrderByDescending(h => h.HandValue).ToList();
                        if (MatchingHandValues[0].HandValue > MatchingHandValues[1].HandValue)
                        {
                            break;
                        }
                    }
                    //if someone has the highest value
                    if (MatchingHandValues[0].HandValue > MatchingHandValues[1].HandValue)
                    {
                        PeopleWhoCanWinMoney = PeopleWhoCanWinMoney.OrderByDescending(h => h.HandValue).ToList();
                        for (int i = 1; i < PeopleWhoCanWinMoney.Count; i++)
                        {
                            if (PeopleWhoCanWinMoney[i].RoundBid > PeopleWhoCanWinMoney[0].RoundBid)
                            {
                                NewPotPeople.Add(PeopleWhoCanWinMoney[i]);
                            }
                        }
                        if (NewPotPeople.Count == 0)
                        {
                            PeopleWhoCanWinMoney[0].ChipTotal += PotTotal;
                        } else {
                            foreach (DSeat seat in NewPotPeople)
                            {
                                NewPot += seat.RoundBid - PeopleWhoCanWinMoney[0].RoundBid;
                            }
                            PotTotal -= NewPot;
                            PeopleWhoCanWinMoney[0].ChipTotal += PotTotal;
                            PeopleWhoCanWinMoney = new List<DSeat>(NewPotPeople);
                            NewPotPeople.Clear();
                            PotTotal = NewPot;
                            NewPot = 0;
                        }
                    } else {
                        // may have matching hand levels but different pot levels
                        int smallWinnerIndex = -1;
                        // check if any of the matched values have different bid levels
                        // check if out of all the people who can win if there are bid levels higher
                        // 
                    }
                    //else if they all match
                }
            } while (NewPotPeople.Count > 0);
        }

        public void StartRound()
        {
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

            GetTurnOrder();

            foreach(DSeat seat in SeatsInTurnOrder)
            {
                seat.NewRound();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach(DSeat seat in SeatsInTurnOrder)
                {
                    seat.Pocket.Add(DeckOfCards.Draw());
                }
            }
        }

        // people who join in the middle of the round
    }
}