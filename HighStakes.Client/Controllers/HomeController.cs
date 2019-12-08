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
