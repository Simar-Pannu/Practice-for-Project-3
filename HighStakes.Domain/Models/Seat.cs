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

        public bool IsStraight(List<Card> hand)
        {
            List<Card> orderedHand = hand.OrderBy(h => h.Value).ToList();
            int curVal = 0;
            foreach(Card card in orderedHand)
            {
                if (curVal == 0)
                {
                    curVal = card.Value;
                } else {
                    if (curVal != card.Value - 1)
                    {
                        return false;
                    }
                    curVal++;
                }
            }
            return true;
        }    

        public bool IsStraightFlush(List<Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        public bool IsRoyalStraightFlush(List<Card> hand)
        {
            return IsStraightFlush(hand) && hand.Exists(c => c.Value == 14);
        }

        public void AssignHandValue(List<Card> hand)
        {
            List<Card> orderedHand = hand.OrderByDescending(h => h.Value).ToList();
            if (IsRoyalStraightFlush(hand))
            {
                PlayerHand.HandValue = 900;
            } else if (IsStraightFlush(hand))
            {
                PlayerHand.HandValue = 800;
                PlayerHand.HandValue += orderedHand[0].Value;
            } else if (IsFourOfAKind(hand))
            {
                PlayerHand.HandValue = 700;
                foreach(Card card in orderedHand)
                {
                    PlayerHand.HandValue += card.Value;
                }
            } else if (IsFullHouse(hand))
            {
                PlayerHand.HandValue = 600;
                PlayerHand.HandValue += orderedHand[2].Value;

            } else if (IsFlush(hand))
            {
                PlayerHand.HandValue = 500;
                PlayerHand.HandValue += orderedHand[0].Value;
            } else if (IsStraight(hand))
            {
                PlayerHand.HandValue = 400;
                PlayerHand.HandValue += orderedHand[0].Value;
            } else if (IsThreeOfAKind(hand))
            {
                PlayerHand.HandValue = 300;
                PlayerHand.HandValue += orderedHand[2].Value;
            } else if (IsTwoPair(hand))
            {
                PlayerHand.HandValue = 200;
            } else if (IsPair(hand))
            {
                PlayerHand.HandValue = 100;
            } else 
            {
                PlayerHand.HandValue += orderedHand[0].Value;
            }
        }
    }
}