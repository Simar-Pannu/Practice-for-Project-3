using System;
using
using System.Collections.Generic;

namespace HighStakes.Client.Models
{
  [Serializable]
  public class Table
  {
    public DTable table;

    public Table()
    {
      this.table = new DTable();
      this.table.Initialize(600, 1200);
    }

  }
}
