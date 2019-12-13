using System.Collections.Generic;
using HighStakes.Domain.Models;
using Xunit;

namespace HighStakes.Testing.DomainTests
{
    public class DeckTest
    {
        [Fact]
        public void Test_Initialize()
        {
            var deck = new DDeck(0, new List<DCard>());

            deck.Initialize();

            Assert.True(deck.Cards.Count == 52);
        }

        [Fact]
        public void Test_Draw()
        {
            var deck = new DDeck(0, new List<DCard>());
            deck.Initialize();

            var card = deck.Draw();

            Assert.True(card.Value > 1);
        }

        [Fact]
        public void Test_Shuffle()
        {
            var deck = new DDeck(0, new List<DCard>());
            deck.Initialize();
            
            var card1 = deck.Cards[0].Name;
            var card2 = deck.Cards[1].Name;
            var card3 = deck.Cards[2].Name;

            deck.Shuffle();

            // Assert.False(card1.Equals(deck.Cards[0]))
        }
    }
}