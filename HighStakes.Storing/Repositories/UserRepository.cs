using HighStakes.Domain.Models;
using System.Collections.Generic;
using HighStakes.Storing.Entities;
using HighStakes.Storing.Adapters;

namespace HighStakes.Storing.Repositories
{
  public class UserRepository
  {
    List<DUser> _Users= new List<DUser>();
    SqlAdapter sa = new SqlAdapter();
    public DUser GetUser(int id) { return _Users.Find(x=>x.UserId == id);}
    public List<DUser> GetUsers(){return _Users;}
    public UserRepository()
    {
      sa.BuildUsers();
    }
    public void UpdateChipTotal(int UserId, int Chips){
      _Users.Find(x=>x.UserId==UserId).ChipTotal = Chips;
    }
    public void addUsertoDatabase(DUser User){
     // var Account = 
     _Users.Add(User);
    }
    public bool UserExist(string username, string password){
    
      foreach (var item in _Users)
      {
          if(item.Account.UserName == username && item.Account.Password == password){return true;}
          
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
