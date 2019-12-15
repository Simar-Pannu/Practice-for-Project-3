using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HighStakes.Domain.Models;
using HighStakes.Storing.Entities;
using Microsoft.EntityFrameworkCore;


namespace HighStakes.Storing.Adapters
{

  public interface ISqlAdapter
  {
   

    DDeck getDeck();
   List<DUser> getUsers(); 

  DDeck BuildDeck();
  List<DUser> BuildUsers();
  void addUser(DUser user);
  void UpdateChips(int UserId, int Chips);

}
}
