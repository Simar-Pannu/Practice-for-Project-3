using System;
using System.Collections.Generic;
using HighStakes.Domain.Models;

namespace HighStakes.Client.Models
{
  [Serializable]
  public class Table
  {
    public DTable table;
    public int nextTurn;
    public int HighBid;
    public int subround;
    public List<DSeat> seatsOrder;
    public int PotValue { get; set; }

    public Table()
    {
      this.table = new DTable();
      this.table.Initialize(10, 20);
    }

    public void StartRound()
    {
      table.StartRound();
      this.subround = 0;
      this.HighBid = this.table.SmallBlindAmount;
      this.table.Flop = new List<DCard>();
      for (int i = 0; i < 5; i++)
      {
        this.table.Flop.Add(this.table.DeckOfCards.Draw());
      }
      this.seatsOrder = this.table.SeatsInTurnOrder;
      this.PotValue = 0;

    }
    public bool incrementTurn()
    {
      if (nextTurn < this.table.NumOfActivePlayers() - 1)
      {
        Console.WriteLine("From Turn true");
        nextTurn++;
        return true;
      } else
      {
        this.subround++;
        if (this.subround == 4) {
          table.EndRound();
          StartRound();
          this.subround = 0;
        }
        Console.WriteLine("From Turn false");
        nextTurn = 0;
        return false;
      }
    }

  }
}
