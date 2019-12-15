using System.Collections.Generic;
using System.Linq;
using HighStakes.Domain.Models;
using Xunit;

namespace HighStakes.Testing.DomainTests
{
    public class SeatTest
    {
        [Fact]
        public void Test_NewRound()
        {
            var seat = new DSeat();
            seat.Initialize();
            seat.Pocket = DrawCards(2);
            seat.Flop = DrawCards(5);

            seat.NewRound();

            Assert.True(seat.Pocket.Count == 0 && seat.Flop.Count == 0);
            Assert.True(seat.Active);
            Assert.True(seat.HandValue == 0 && seat.RoundBid == 0);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void Test_Bid(int bid)
        {
            var seat = new DSeat();
            seat.Initialize();
            seat.ChipTotal = 25;

            seat.Bid(bid);
            seat.Bid(bid);

            Assert.True(seat.ChipTotal >= 0);
            Assert.False(seat.ChipTotal == 25);
        }

        [Fact]
        public void Test_Fold()
        {
            var seat = new DSeat();
            seat.Initialize();

            seat.Fold();

            Assert.False(seat.Active);
        }

        [Fact]
        public void Test_SitDown()
        {
            var player = new DUser();
            var seat = new DSeat();

            seat.Initialize();

            seat.SitDown(player, 50);

            Assert.True(seat.ChipTotal == 50);
            Assert.True(seat.Occupied);
            Assert.True(seat.Active);

        }

        [Fact]
        public void Test_StandUp()
        {
            var player = new DUser();
            player.ChipTotal += 50;
            var seat = new DSeat();
            seat.Initialize();
            seat.SitDown(player, 25);

            seat.StandUp();

            Assert.True(seat.ChipTotal == 0);
            Assert.False(seat.Occupied && seat.Active);
            Assert.True(player.ChipTotal == 75);
        }

        [Fact]
        public void Test_AssignHandValue()
        {
            var seat = new DSeat();
            seat.Initialize();
            var hand1 = ReturnHand(1);
            var hand2 = ReturnHand(2);
            var hand3 = ReturnHand(3);
            
            seat.AssignHandValue(hand1);
            Assert.Equal(14, seat.PlayerHand.HandValue);
            seat.AssignHandValue(hand2);
            Assert.Equal(611, seat.PlayerHand.HandValue);
            seat.AssignHandValue(hand3);
            Assert.Equal(900, seat.PlayerHand.HandValue);
        }

        [Fact]
        public void Test_BestHand()
        {
            var seat = new DSeat();
            seat.Initialize();
            SetUpCards(1, seat);
            seat.FindBestHand();
            Assert.True(seat.PlayerHand.HandCards.Count > 0);
            Assert.Equal(612, seat.HandValue);
        }

        public bool SetUpCards(int choice, DSeat seat)
        {
            DDeck deck = new DDeck(0, new List<DCard>());
            deck.Initialize();

            foreach(DCard card in deck.Cards)
            {
                if (choice == 1)
                {
                    if (card.Name.Equals("Two of Clubs") || card.Name.Equals("Jack of Hearts"))
                    {
                        seat.Pocket.Add(card);
                    }
                    if (card.Name.Equals("Queen of Diamonds") || card.Name.Equals("Queen of Spades") || card.Name.Equals("Queen of Clubs") || card.Name.Equals("Jack of Clubs") || card.Name.Equals("Two of Spades"))
                    {
                        seat.Flop.Add(card);
                    }
                }
            }
            return true;
        }

        public List<DCard> ReturnHand(int hand)
        {
            DDeck deck = new DDeck(0, new List<DCard>());
            List<DCard> testHand = new List<DCard>();
            deck.Initialize();
            foreach(DCard card in deck.Cards)
            {
                if (hand == 1) 
                {
                    if (card.Name.Equals("Ace of Clubs") || card.Name.Equals("Ten of Clubs") || card.Name.Equals("Three of Clubs") || card.Name.Equals("Seven of Hearts") || card.Name.Equals("Five of Clubs"))
                    {
                        testHand.Add(card);
                    }
                } else if (hand == 2) 
                {
                    if (card.Name.Equals("Ace of Clubs") || card.Name.Equals("Ace of Hearts") || card.Name.Equals("Jack of Spades") || card.Name.Equals("Jack of Clubs") || card.Name.Equals("Jack of Diamonds"))
                    {
                        testHand.Add(card);
                    }
                } else if (hand == 3)
                {
                    if (card.Name.Equals("Ace of Clubs") || card.Name.Equals("King of Clubs") || card.Name.Equals("Queen of Clubs") || card.Name.Equals("Jack of Clubs") || card.Name.Equals("Ten of Clubs"))
                    {
                        testHand.Add(card);
                    }
                }
            }
            testHand = testHand.OrderByDescending(o => o.Value).ToList();
            return testHand;
        }

        public List<DCard> DrawCards(int amount)
        {
            var deck = new DDeck(0, new List<DCard>());
            List<DCard> returnValue = new List<DCard>();
            deck.Initialize();

            for (int i = 0; i < amount; i++)
            {
                returnValue.Add(deck.Draw());
            }

            return returnValue;
        }
    }
}