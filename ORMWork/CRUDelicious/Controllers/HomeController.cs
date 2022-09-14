using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private CRUDeliciousContext dbContext;

    public HomeController(CRUDeliciousContext context)
    {
        dbContext = context;
    }
    private readonly ILogger<HomeController> _logger;

    [HttpGet("")]
    public IActionResult Index()
    {
        // List<Dishes> AllDishes = dbContext.Dishes.ToList();
        List<Dish> AllDishes = dbContext.Dishes.ToList();
        ViewBag.Dishes = AllDishes;
        return View();
    }

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

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
