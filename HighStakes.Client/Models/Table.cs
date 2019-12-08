using System;
using System.Collections.Generic;

namespace HighStakes.Client.Models
{
  [Serializable]
  public class Table
  {
    public const int MAX_PLAYER = 8;
    public int Counter { get; set; }

    public List<Player> Players { get; set; }

    public Table()
    {
      Players = new List<Player>();
    }

  }
}
