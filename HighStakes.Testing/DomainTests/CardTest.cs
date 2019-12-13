using HighStakes.Domain.Models;
using Xunit;

namespace HighStakes.Testing.DomainTests
{
    public class CardTest
    {
        [Theory]
        [InlineData(14, "Heart", "Ace of Hearts")]
        public void Test_Initialize(int value, string suit, string name)
        {
            var card = new DCard(0,0,"");

            card.Initialize(value, suit, name);

            Assert.True(card.Name.Equals("Ace of Hearts"));
            Assert.True(card.Suit.Equals("Heart"));
            Assert.True(card.Value == 14);
        }
    }
}