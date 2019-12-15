// using System.Linq;
// using HighStakes.Storing.Entities;
// using HighStakes.Storing.Repositories;
// using Xunit;

// namespace HighStakes.Testing.StoringTests
// {
// public class StoringTests{


// [Fact]
// public void Test_DbContext(){
//   HighStakesContext db = new HighStakesContext();
//   var Users = db.User;
//   foreach (var item in Users)
//   {
//     System.Console.WriteLine(item.FirstName);
//   }
//   Assert.True(Users.Count()>2);

// }
// [Fact]
// public void Test_DbContextSpecfic(){
//   HighStakesContext db = new HighStakesContext();
//   var Users = db.User;
//   Assert.True(Users.First(y=>y.FirstName=="Simar").LastName == "Pannu");
// }

// [Fact]
// public void Test_TestDbContextCards(){
//   HighStakesContext db = new HighStakesContext();
//   var cards = db.Card;
  
//   Assert.True(cards.Count()==52);

// }
// [Fact]
// public void Test_UserRepository(){
// UserRepository ur = new UserRepository();
// var exists = ur.UserExist("Simar","Pannu");
// Assert.True(exists);
// }


// [Fact]
// public void Test_DeckRepository(){
// DeckRepository dr = new DeckRepository();
// var cards = dr.GetDeck();
// Assert.NotNull(cards.Cards.FirstOrDefault(c=>c.Suit=="Hearts" && c.Value ==11));
// }






// }    
// }
