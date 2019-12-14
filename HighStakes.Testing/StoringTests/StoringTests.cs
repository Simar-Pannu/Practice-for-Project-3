using System.Linq;
using HighStakes.Storing.Entities;
using HighStakes.Storing.Repositories;
using Xunit;

namespace HighStakes.Testing.StoringTests
{
public class StoringTests{


[Fact]
public void Test_DbContext(){
  HighStakesContext db = new HighStakesContext();
  var Users = db.User;
  foreach (var item in Users)
  {
    System.Console.WriteLine(item.FirstName);
  }
  Assert.True(Users.Count()>2);

}
[Fact]
public void Test_DbContextSpecfic(){
  HighStakesContext db = new HighStakesContext();
  var Users = db.User;
  
  
  Assert.Equal(Users.First(y=>y.FirstName=="Simar").LastName,"Pannu");
}
[Fact]
public void Test_TestDbContextAddition(){
  HighStakesContextTest db = new HighStakesContextTest();
  var Users = db.User;
  Assert.Equal(Users.First(y=>y.FirstName=="Han").LastName,"Nguyen");
}
[Fact]
public void Test_TestDbContextCards(){
  HighStakesContext db = new HighStakesContext();
  var cards = db.Card;
  
  Assert.True(cards.Count()==52);

}





}    
}
