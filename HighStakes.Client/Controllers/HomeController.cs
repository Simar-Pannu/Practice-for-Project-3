using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using HighStakes.Client.Models;
using Newtonsoft.Json;
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

    public IActionResult Table()
    {
      Table tableSample;

      if (string.IsNullOrEmpty(HttpContext.Session.GetString("table")))
      {
        tableSample = new Table();
        tableSample.Counter = 10;
      } else {
        tableSample = JsonConvert.DeserializeObject<Table>(HttpContext.Session.GetString("table"));
        // tableSample.Counter++;
      }

      var jsonString = JsonConvert.SerializeObject(tableSample);
      HttpContext.Session.SetString("table", jsonString);
      return View("Table", tableSample);
    }

    public IActionResult Register()
    {
      return View();
    }
    [HttpPost()]
    public IActionResult Lobby(Player player)
    {
      HighStakesContext _hsc = new HighStakesContext();
      Account account = _hsc.Accounts.FirstOrDefault(o => o.UserName == player.username && o.Password == player.password);

      if (account == null)
      {
        return RedirectToAction("Index", "Home");
      }
      //populate domain user with info
      User user = _hsc.Users.FirstOrDefault(o => o.AccountId == account.AccountId);
      player.LoadUser(user);
      return View("Lobby, player");

    }

    public IActionResult Payment()
    {
      return View();
    }
    [HttpGet("{num}")]
    public Table Add(string num)
    {
      int intFromString;
      int addTo = 0;
      if (Int32.TryParse(num, out intFromString))
      {
        addTo = intFromString;
      }
      var tableSample = JsonConvert.DeserializeObject<Table>(HttpContext.Session.GetString("table"));
      tableSample.Counter += addTo;
      var jsonString = JsonConvert.SerializeObject(tableSample);
      HttpContext.Session.SetString("table", jsonString);
      return tableSample;
      // return View("Table");
    }
    [HttpGet]
    public Table Add()
    {
      var tableSample = JsonConvert.DeserializeObject<Table>(HttpContext.Session.GetString("table"));
      return tableSample;
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
