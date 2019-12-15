using System.ComponentModel.DataAnnotations;
using HighStakes.Domain.Models;
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
      UserRepository _ur = new UserRepository();
      this.user = _ur.GetUser(this.userID);
    }

  }
}