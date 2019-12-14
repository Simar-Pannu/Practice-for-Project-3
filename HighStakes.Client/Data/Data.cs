using System;
using System.Collections.Generic;
using System.IO;
using HighStakes.Client.Models;
using Newtonsoft.Json;

namespace HighStakes.Client.Data
{
  public class DataTemp
  {
    private const string FILE = "Data/game.json";
    public static Table table;

    public static Table readData()
    {
      // StreamReader reader = new StreamReader(FILE);
      // var stringData = reader.ReadToEnd();

      // if (string.IsNullOrEmpty(stringData))
      // {
      //   Console.WriteLine("Yes, this is null");
      //   return null;
      // } else
      // {
      //   Console.WriteLine("Not, null");
      // }

      // Table table = JsonConvert.DeserializeObject<Table>(stringData);



      return table;
    }

    public static void writeData(Table table1)
    {
      // string jsonString = JsonConvert.SerializeObject(table1);

      // StreamWriter writer = new StreamWriter(FILE);
      // writer.Write(jsonString);
      // writer.Close();
      table = table1;

    }
  }
}