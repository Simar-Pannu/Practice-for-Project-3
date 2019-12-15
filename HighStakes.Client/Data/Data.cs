using HighStakes.Client.Models;

namespace HighStakes.Client.Data
{
  public class DataTemp
  {
    public static Table table;

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