using System.ComponentModel.DataAnnotations;
using System.Linq;
using HighStakes.Domain.Models;
using HighStakes.Storing.Entities;
using HighStakes.Storing.Repositories;
using PizzaBox.Client.Validations;

namespace HighStakes.Client.Models
{
  public class Player
  {
    // HighStakesContext _hsc = new HighStakesContext();
    public DUser user { get; set; }
    // public DHand PlayerHand { get; set; }      delete later
    public int userID { get; set; }
    [NameAttribute(ErrorMessage = "the name must be letters only")]
    [StringLength(50)]
    [Required]
    public string username { get; set; }
    [NameAttribute(ErrorMessage = "the name must be letters only")]
    [StringLength(50)]
    [Required]
    public string password { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public int chip { get; set; }


    public void LoadUser()
    {
      this.user = new DUser();
      User storingUser = UserRepository.GetUsers().FirstOrDefault(o => o.UserId == this.userID);

      this.user.UserId = storingUser.UserId;
      this.user.FirstName = storingUser.FirstName;
      this.user.LastName = storingUser.LastName;
      this.user.ChipTotal = storingUser.ChipTotal;

      DAccount account = new DAccount(){AccountId=storingUser.Account.AccountId, UserName=storingUser.Account.UserName, Password=storingUser.Account.Password};
      this.user.Account = account;
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