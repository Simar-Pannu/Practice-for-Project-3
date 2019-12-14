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
    HighStakesContext db = new HighStakesContext();
    public DDeck getDeck() { return BuildDeck();}
    public List<DUser> getUsers() {return BuildUsers();}

    public DDeck BuildDeck(){
      List<DCard> cards = new List<DCard>();
      foreach (var card in db.Card)
      {
          cards.Add(card);
      }
      return new DDeck(0, cards);
    }
    public List<DUser> BuildUsers(){

    List<DUser> _Users= new List<DUser>();
      foreach (var u in db.User)
      {
        foreach (var a in db.Account)
        {
         if(u.AccountId == a.AccountId){
           _Users.Add(new DUser(){UserId= u.UserId,FirstName =u.FirstName, LastName =u.LastName, ChipTotal= u.ChipTotal, AccountId = u.AccountId , Account = new DAccount(){AccountId=a.AccountId,UserName=a.UserName,Password=a.Password}});
         }  
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
