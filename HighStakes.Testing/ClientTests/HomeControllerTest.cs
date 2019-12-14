using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using HighStakes.Client.Models;
using Newtonsoft.Json;
using HighStakes.Storing.Repositories;
using HighStakes.Storing.Entities;
using HighStakes.Client.Data;
using HighStakes.Domain.Models;
// using HighStakes.Storing.Entities;

namespace HighStakes.Client.Controllers
{

  [Route("/[controller]/[action]")]
  public class HomeController : Controller
  {

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Table(JoinTable newPlayer)
    {
      // Table tableOne;
      // Console.WriteLine("\n");
      // Console.WriteLine(newPlayer.buyIn);
      // Console.WriteLine(newPlayer.userID);
      // Console.WriteLine("\n");

      Table tableOne = DataTemp.readData();

      if (tableOne == null)
      {
        tableOne = new Table();
        tableOne.nextTurn = 0;
        Console.WriteLine("\nI am  is null\n");
      }


      if (tableOne.table.NumOfActivePlayers() >= 6)
      {
        // room is full
        return View("Index");
      }
      newPlayer.LoadUser();
      if (tableOne.table.Seats.FirstOrDefault(o => o.Player.UserId == newPlayer.userID) == null)
      {

        tableOne.table.JoinGame(newPlayer.user, newPlayer.buyIn);

        if (tableOne.table.NumOfActivePlayers() == 2) {

          tableOne.table.StartGame();
          tableOne.StartRound();
          // tableOne.subround = 1;
        }
      }

      DataTemp.writeData(tableOne);

      return View("Table", tableOne);
    }

    public IActionResult Register()
    {
      return View();
    }
    [HttpPost()]
    public IActionResult Lobby(Player player)
    {
      if (!ModelState.IsValid)
      {
        return View("Index");
      }

      if (player.firstname != null) {
        player.CreateUser();
      }

      // HighStakesContext _hsc = new HighStakesContext();
      // UserRepository.Create();
      UserRepository _ur = new UserRepository();
      DUser loginUser = _ur.GetUsers().FirstOrDefault(o => o.Account.UserName == player.username && o.Account.Password == player.password);

      if (loginUser == null)
      {
        return RedirectToAction("Index", "Home");
      }

      //populate domain user with info
      player.userID = loginUser.UserId;
      player.LoadUser();
      ViewData["userTemp"] = loginUser.UserId;
      return View();

    }

    public IActionResult Payment()
    {
      return View();
    }
    [HttpGet]
    public string Update()
    {
      return JsonConvert.SerializeObject(DataTemp.readData());
    }

    [HttpGet("{userId}/{bid}")]
    public string Bid(string userId, string bid)
    {

      int intUserId;
      int intBid;
      if (!Int32.TryParse(userId, out intUserId) || !Int32.TryParse(bid, out intBid))
      {
        return null;
      }

      Table table = DataTemp.readData();
      DSeat currentSeat = table.table.Seats.FirstOrDefault(o => o.Player.UserId == intUserId);
      currentSeat.Bid(intBid);
      table.table.CurrentPot.PotValue += intBid;

      table.incrementTurn();

      DataTemp.writeData(table);
      return "";
    }
    [HttpGet("{userId}/{bid}")]
    public string Raise(string userId, string bid)
    {
      int intUserId;
      int intBid;
      if (!Int32.TryParse(userId, out intUserId) || !Int32.TryParse(bid, out intBid))
      {
        return null;
      }

      Table table = DataTemp.readData();
      DSeat currentSeat = table.seatsOrder.FirstOrDefault(o => o.Player.UserId == intUserId);
      currentSeat.Bid(intBid);
      table.HighBid = currentSeat.RoundBid;
      table.table.CurrentPot.PotValue += intBid;

      table.nextTurn = 1;
      var indexSeat = table.table.Seats.IndexOf(currentSeat);
      List<DSeat> reorderedList = new List<DSeat>();

      reorderedList.AddRange(table.seatsOrder.GetRange(indexSeat, table.seatsOrder.Count() - indexSeat));
      reorderedList.AddRange(table.seatsOrder.GetRange(0, indexSeat));
      table.seatsOrder = reorderedList;

      DataTemp.writeData(table);
      return "";
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
