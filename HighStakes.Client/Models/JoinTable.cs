using System.ComponentModel.DataAnnotations;
using System.Linq;
using HighStakes.Domain.Models;
using HighStakes.Storing.Entities;
using HighStakes.Storing.Repositories;

namespace HighStakes.Client.Models
{
  public class JoinTable
  {
    [Required]
    public int userID { get; set; }
    [Required]
    public int buyIn { get; set; }
    public DUser user { get; set; }


    // Duplicate codes, refactor later
    public void LoadUser()
    {
      // this.user = new DUser();
      UserRepository _ur = new UserRepository();
      // DUser storingUser = _ur.GetUsers().FirstOrDefault(o => o.UserId == this.userID);
      DUser storingUser = _ur.GetUser(this.userID);
      this.user = _ur.GetUser(this.userID);
    }

  }
}