using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("user/create")]
    public new IActionResult User()
    {
        return View("NewUser");
    }


    [HttpPost("user/create")]
    public IActionResult CreateUser(User user) {

        if(ModelState.IsValid)
        {
            return RedirectToAction("RegistrationSuccess");
        }
        else
        {
            return View("NewUser");
        }
    }

    [HttpGet("registrationSuccess")]
    public IActionResult RegistrationSuccess()
    {
        return View("RegistrationSuccess");
    }

    public IActionResult Index()
    {
        return View();
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
