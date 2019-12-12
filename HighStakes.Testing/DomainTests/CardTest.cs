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

            // var index = home.Index();
            
            // Assert.NotNull(index);
        }
    }
}