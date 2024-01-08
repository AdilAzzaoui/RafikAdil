using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TpPrepa.Models;

namespace TpPrepa.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Hello()
    {
        string nom = "rafik";
        int age = 23;
        string nom2 = "manar";
        int age2 = 23;
        Dictionary<string, int> test = new Dictionary<string, int>();//Decalaration d'un dictionnaire en ASP core mvc
        test.Add( nom, age);
        test.Add(nom2, age2);

        return View(test) ;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

