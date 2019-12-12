using System.ComponentModel.DataAnnotations;
using System.Linq;
using HighStakes.Domain.Models;
using HighStakes.Storing.Entities;
using HighStakes.Storing.Repositories;
using PizzaBox.Client.Validations;

namespace HighStakes.Client.Models
{
  public class JoinTable
  {
    [NameAttribute(ErrorMessage = "the name must be letters only")]
    [StringLength(50)]
    [Required]
    public int userID { get; set; }
    [Required]
    public int buyInerID { get; set; }
    public DUser user { get; set; }


    // Duplicate codes, refactor later
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

  }
}