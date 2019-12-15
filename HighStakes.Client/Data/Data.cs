using HighStakes.Client.Models;

namespace HighStakes.Client.Data
{
  public static class DataTemp
  {
    public static Table table { get; set; }

    public static Table readData()
    {
      return table;
    }

    public static void writeData(Table table1)
    {
      table = table1;
    }
  }
}