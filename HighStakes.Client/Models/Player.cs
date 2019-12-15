using System.ComponentModel.DataAnnotations;
using HighStakes.Domain.Models;
using HighStakes.Storing.Repositories;

namespace HighStakes.Client.Models
{
  public class Player
  {
    public DUser user { get; set; }
    public int userID { get; set; }

    [StringLength(50)]
    [Required]

    public string username { get; set; }
    [StringLength(50)]
    [Required]
    public string password { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public int chip { get; set; }


    public void LoadUser()
    {
      this.user = new DUser();
      UserRepository _ur = new UserRepository();
      this.user = _ur.GetUser(this.userID);
    }
    public void CreateUser()
    {
      DUser newUser = new DUser();
      // Need to create Account in User
      // need to save it database
      newUser.FirstName = this.firstname;
      newUser.LastName = this.lastname;
      newUser.ChipTotal = this.chip;

    }
  }
}