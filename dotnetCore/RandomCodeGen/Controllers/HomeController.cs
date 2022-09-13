using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomCodeGen.Models;
using Microsoft.AspNetCore.Http;

namespace RandomCodeGen.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Count = HttpContext.Session.GetInt32("Count");
        ViewBag.Code = HttpContext.Session.GetString("Code");
        return View();
    }

    

    [HttpGet("GenerateCode")]
    public IActionResult GenerateCode()
    {
        
        if(HttpContext.Session.GetInt32("Count") == null)
        {
            HttpContext.Session.SetInt32("Count", 1);
        }
        else if(HttpContext.Session.GetInt32("Count") != null)
        {
            
            int currentCount =  HttpContext.Session.GetInt32("Count").GetValueOrDefault();
            HttpContext.Session.SetInt32("Count", currentCount+=1);
            Console.WriteLine(currentCount);
        }
        string newString = RandomString.GenerateRandomCodeString();
        HttpContext.Session.SetString("Code", newString);
        Console.WriteLine(newString);
        return RedirectToAction("Index");
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

public class RandomString
{
    private static Random random = new Random();

    public static string GenerateRandomCodeString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 14).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
