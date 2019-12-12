using HighStakes.Domain.Models;
using Xunit;

namespace HighStakes.Testing.DomainTests
{
    public class CardTest
    {
        [Fact]
        public void Test_Initialize()
        {
            var card = new DCard(0,0,"");

            card.Initialize(14, "Heart", "Ace of Hearts");

            Assert.IsType<DCard>(card);
            Assert.True(card.Name.Equals("Ace of Hearts"));
            Assert.True(card.Suit.Equals("Heart"));
            Assert.True(card.Value == 14);
        }
    }
}