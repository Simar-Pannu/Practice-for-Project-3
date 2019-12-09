using HighStakes.Domain.Models;

namespace HighStakes.Client.Models
{
  public class Player
  {
    HighStakesContext _hsc = new HighStakesContext();
    public DUser user { get; set; }
    public DHand PlayerHand { get; set; }
    public int AccountNum { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public int chip { get; set; }


    // public DUser()
    // {
    //   PlayerHand.Initialize();
    // }
    public void LoadUser()
    {

      User storingUser = _hsc.Users.FirstOrDefault(o => o.AccountId == this.AccountNum);
      user.UserId = storingUser.UserId;
      user.AccountId = storingUser.AccountId;
      user.FirstName = storingUser.FirstName;
      user.LastName = storingUser.LastName;
      user.ChipTotal = storingUser.ChipTotal;
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