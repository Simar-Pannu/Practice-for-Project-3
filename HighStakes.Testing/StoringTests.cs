using HighStakes.Storing.Repositories;
using Xunit;
namespace HighStakes.Testing
{
public class StoringTests{

[Fact]
  public void Test_CardDeck(){
    DeckRepository dr = new DeckRepository();
    var cardDeck = dr.GetDeck();
    Assert.Equal(cardDeck.Cards.Count, 52);
  }
  [Fact]
  public void Test_GetUser(){
    UserRepository ur = new UserRepository();
    var Users = ur.GetUsers();
    Assert.True(Users.Exists(x=>x.Account.Username == "Simar"));
  }

}    
}
