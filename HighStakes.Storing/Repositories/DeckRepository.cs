using HighStakes.Domain.Models;
using System.Collections.Generic;
using HighStakes.Storing.Entities;
using HighStakes.Storing.Adapters;

namespace HighStakes.Storing.Repositories
{
  public class DeckRepository
  {
    SqlAdapter sa = new SqlAdapter();
    DDeck _Deck;

    public DDeck GetDeck() { return _Deck; }
    public DeckRepository()
    {
      _Deck = sa.BuildDeck();

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
