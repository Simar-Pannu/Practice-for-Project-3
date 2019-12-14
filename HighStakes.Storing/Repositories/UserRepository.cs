using HighStakes.Domain.Models;
using System.Collections.Generic;
using HighStakes.Storing.Entities;
using HighStakes.Storing.Adapters;

namespace HighStakes.Storing.Repositories
{
  public class UserRepository
  {
    List<DUser> _Users;
    SqlAdapter sa = new SqlAdapter();
    public DUser GetUser(int id) { return _Users.Find(x=>x.UserId == id);}
    public List<DUser> GetUsers(){return _Users;}
    public UserRepository()
    {
      _Users = sa.getUsers();
    }
    public void UpdateChipTotal(int UserId, int Chips){
      sa.UpdateChips(UserId, Chips);
     
    }
    public void addUsertoDatabase(DUser User){
      sa.addUser(User);
     _Users.Add(User);
    }
    public bool UserExist(string username, string password){
    
      foreach (var item in _Users)
      {
          if(item.Account.UserName == username && item.Account.Password == password){return true;}
          
      }
      return false;
    }

    
  }
}
