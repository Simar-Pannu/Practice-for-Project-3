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
      _Deck = sa.getDeck();

    }


  }




}
