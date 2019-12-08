// using HighStakes.Domain.Models;

namespace HighStakes.Client.Models
{
  public class Player
  {
    public DUser user { get; set; }
    public DHand PlayerHand { get; set; }
    public string username { get; set; }
    public string password { get; set; }


    // public DUser()
    // {
    //   PlayerHand.Initialize();
    // }
    public void LoadUser(User storingUser)
    {
      user.UserId = storingUser.UserId;
      user.AccountId = storingUser.AccountId;
      user.FirstName = storingUser.FirstName;
      user.LastName = storingUser.LastName;
      user.ChipTotal = storingUser.ChipTotal;
    }
  }
}