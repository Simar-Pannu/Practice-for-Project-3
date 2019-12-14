using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HighStakes.Domain.Models;
using HighStakes.Storing.Entities;
using Microsoft.EntityFrameworkCore;


namespace HighStakes.Storing.Adapters
{

  public class SqlAdapter
  {
     static readonly HighStakesContext db = new HighStakesContext();

    DDeck _Deck;
    List<DUser> _Users = new List<DUser>();
    public DDeck getDeck() { return _Deck;}
    public List<DUser> getUsers() {return _Users;}

    public SqlAdapter(){
    _Deck = BuildDeck();
    _Users = BuildUsers();
    }

    public DDeck BuildDeck(){

      List<DCard> cards = new List<DCard>();
      foreach (var card in db.Card)
      {
          cards.Add(card);
      }
   //   db.Dispose
      return new DDeck(0, cards);
    }
    public List<DUser> BuildUsers(){
     
    List<DUser> _Users= new List<DUser>();
    List<DAccount> _Accounts = new List<DAccount>();
    foreach (var a in db.Account)
    {
        _Accounts.Add(new DAccount(){AccountId=a.AccountId,UserName=a.UserName,Password=a.Password});
    }
        foreach (var u in db.User)
    {
       _Users.Add(new DUser(){UserId= u.UserId,FirstName =u.FirstName, LastName =u.LastName, ChipTotal= u.ChipTotal, AccountId = u.AccountId});
    }
    foreach (var user in _Users)
    {
        foreach (var account in _Accounts)
        {
            if(user.AccountId == account.AccountId){user.Account = account;}
        }
    }
    
    return _Users;
  }
  public void addUser(DUser user){

    db.User.Add(user);
    db.SaveChanges();
  }
  public void UpdateChips(int UserId, int Chips){

   db.User.First(x=>x.UserId==UserId).ChipTotal = Chips;
    db.SaveChanges();
  }
  

}
}
