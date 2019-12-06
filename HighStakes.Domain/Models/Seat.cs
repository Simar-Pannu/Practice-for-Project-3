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

        public bool IsTwoPair(List<Card> hand)
        {
            return hand.GroupBy(h => h.Value).Where(g => g.Count() == 2).Count() == 2;
        }

        public bool IsThreeOfAKind(List<Card> hand)
        {
            return hand.GroupBy(h => h.Value).Where(g => g.Count() == 3).Any();
        }

        public bool IsFourOfAKind(List<Card> hand)
        {
            return hand.GroupBy(h => h.Value).Where(g => g.Count() == 4).Any();
        }

        public bool IsFlush(List<Card> hand)
        {
            return hand.GroupBy(h => h.Suit).Where(g => g.Count() == 5).Any();
        }

        public bool IsFullHouse(List<Card> hand)
        {
            return IsPair(hand) && IsThreeOfAKind(hand);
        }
    }
}