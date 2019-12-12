using HighStakes.Domain.Models;
using System.Collections.Generic;
using HighStakes.Storing.Entities;

namespace HighStakes.Storing.Repositories
{
  public class UserRepository
  {
    HighStakesContext db = new HighStakesContext();
    List<DUser> _Users= new List<DUser>();
    public DUser GetUser(int id) { return _Users.Find(x=>x.UserId == id);}
    public List<DUser> GetUsers(){return _Users;}
    public UserRepository()
    {
      _Users.Add(new DUser(){UserId =1, FirstName="Simar", LastName="Pannu", ChipTotal=5000, Account= new DAccount(){AccountId=0,UserName="Simar",Password="Pannu"}});
      _Users.Add(new DUser(){UserId =2, FirstName="Han", LastName="Nguyen", ChipTotal=5000, Account= new DAccount(){AccountId=1,UserName="Han",Password="Nguyen"}});
      _Users.Add(new DUser(){UserId =3, FirstName="James", LastName="Goldsmith", ChipTotal=5000, Account= new DAccount(){AccountId=2,UserName="James",Password="Goldsmith"}});
    }
    public void UpdateChipTotal(int UserId, int Chips){
      _Users.Find(x=>x.UserId==UserId).ChipTotal = Chips;
    }
    public void addUsertoDatabase(DUser User){
     // var Account = 
     _Users.Add(User);
    }
    public bool UserExist(string username, string password){
      bool a;
      foreach (var item in _Users)
      {
          if(item.Account.Username == username && item.Account.Password == password){return true;}
          
      }
      return false;
    }

    /*
      public UserRepository()
    {
      foreach (var item in db.Users)
      {
        foreach (var account in db.Accounts)
        {
         if(item.AccountId == account.AccountId){
           _Users.Add(new DUser(item.UserId,item.FirstName, item.LastName, item.ChipTotal, new DAccount(account.AccountId, account.UserName, account.Password)));
         }  
        }
          
      }


  }


*/
  }
}
