using System.Collections.Generic;
using System.Linq;
using HighStakes.Domain.Abstracts;

namespace HighStakes.Domain.Models
{
    public class DSeat : AGame
    {
        public int SeatId { get; set; }
        public DUser Player { get; set; }
        public int ChipTotal { get; set; }
        public List<DCard> Pocket { get; set; }
        public DHand PlayerHand { get; set; }
        public bool BigBlind { get; set; }
        public bool SmallBlind { get; set; }

        public void Initialize()
        {
            Player = new DUser();
            PlayerHand = new DHand();
            Pocket = new List<DCard>();
            PlayerHand.Initialize();
        }

        public IEnumerable<DCard[]> Combinations(int m, int n)
        {
                DCard[] result = new DCard[m];
                Stack<DCard> stack = new Stack<DCard>();
                stack.Push(new DCard(0,0,""));
    
            while (stack.Count > 0)
            {
                    int index = stack.Count - 1;
                    DCard value = stack.Pop();
    
                while (value < n) 
                {
                    result[index++] = ++value;
                    stack.Push(value);

                    if (index == m) 
                    {
                        yield return result;
                        break;
                    }
                 }
            }
        }

        // public void FindBestHand()
        // {
        //     List<DCard> AllCards = new List<DCard>();
        //     foreach(DCard card in Flop)
        //     {
        //         AllCards.Add(card);
        //     }
        //     foreach(DCard card in Pocket)
        //     {
        //         AllCards.Add(card);
        //     }
        //     AllCards = AllCards.OrderBy(h => h.Value).ToList();

        //     AllCards.   
        // }

        //public List<DCard> AllHandCombinations()
        // {

        // }

        public bool IsPair(List<DCard> hand)
        {
            return hand.GroupBy(h => h.Value).Where(g => g.Count() == 2).Count() == 1;
        }

        public bool IsTwoPair(List<DCard> hand)
        {
            return hand.GroupBy(h => h.Value).Where(g => g.Count() == 2).Count() == 2;
        }

        public bool IsThreeOfAKind(List<DCard> hand)
        {
            return hand.GroupBy(h => h.Value).Where(g => g.Count() == 3).Any();
        }

        public bool IsFourOfAKind(List<DCard> hand)
        {
            return hand.GroupBy(h => h.Value).Where(g => g.Count() == 4).Any();
        }

        public bool IsFlush(List<DCard> hand)
        {
            return hand.GroupBy(h => h.Suit).Where(g => g.Count() == 5).Any();
        }

        public bool IsFullHouse(List<DCard> hand)
        {
            return IsPair(hand) && IsThreeOfAKind(hand);
        }

        public bool IsStraight(List<DCard> hand)
        {
            List<DCard> orderedHand = hand.OrderBy(h => h.Value).ToList();
            int curVal = 0;
            foreach(DCard card in orderedHand)
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

        public bool IsStraightFlush(List<DCard> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        public bool IsRoyalStraightFlush(List<DCard> hand)
        {
            return IsStraightFlush(hand) && hand.Exists(c => c.Value == 14);
        }

        public void AssignHandValue(List<DCard> hand)
        {
            List<DCard> orderedHand = hand.OrderByDescending(h => h.Value).ToList();
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
                foreach(DCard card in orderedHand)
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