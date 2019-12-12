using HighStakes.Domain.Models;
using System.Collections.Generic;
using HighStakes.Storing.Entities;

namespace HighStakes.Storing.Repositories
{
  public class DeckRepository
  {
    HighStakesContext db = new HighStakesContext();
    DDeck _Deck;
    public DDeck GetDeck() { return _Deck; }
    public DeckRepository()
    {
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
      _Deck = new DDeck(0,cards);
    
    }

    /*
      public DeckRepository()
    {
      List<DCard> cards = new List<DCard>();
     foreach(var i in db.Cards){
       cards.add(new DCard(i.CardId, i. Value, i.Suit));
     }
     _Deck = new Deck (0,cards);
    }
    

*/
  }




}
