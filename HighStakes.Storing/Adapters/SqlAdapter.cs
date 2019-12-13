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
    DDeck _Deck;
    List<DUser> _Users= new List<DUser>();
    public DDeck getDeck() { return _Deck; }
    public List<DUser> getUsers() {return _Users;}
    public SqlAdapter()
    {}
    public DDeck BuildDeck(){
      List<DCard> cards = new List<DCard>();
      var cardId = 0;
      foreach (var suit in new[] { "Spades", "Hearts", "Clubs", "Diamonds", })
      {
        for (var Value = 2; Value <= 14; Value++)
        {
          cards.Add(new DCard(cardId, Value, suit));
          cardId++;
        }
      }
      return new DDeck(0, cards);
    }
    public List<DUser> BuildUsers(){

      _Users.Add(new DUser(){UserId =1, FirstName="Simar", LastName="Pannu", ChipTotal=5000, Account= new DAccount(){AccountId=0,UserName="Simar",Password="Pannu"}});
      _Users.Add(new DUser(){UserId =2, FirstName="Han", LastName="Nguyen", ChipTotal=5000, Account= new DAccount(){AccountId=1,UserName="Han",Password="Nguyen"}});
      _Users.Add(new DUser(){UserId =3, FirstName="James", LastName="Goldsmith", ChipTotal=5000, Account= new DAccount(){AccountId=2,UserName="James",Password="Goldsmith"}});

    return _Users;
    }
  }

}
