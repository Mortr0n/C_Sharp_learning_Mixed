using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

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

    // public IActionResult Users()
    // {
    //     User userOne = new User()
    //     {
    //         FirstName = "Sally",
    //         LastName = "Sanderson"
    //     };

    //     User userTwo = new User()
    //     {
    //         FirstName = "Billy",
    //         LastName = "Brown"
    //     };

    //     User userThree = new User()
    //     {
    //         FirstName = "Terrance",
    //         LastName = "Nightengale"
    //     };

    //     User userFour = new User()
    //     {
    //         FirstName = "Moose",
    //         LastName = "Montgomery"
    //     };
        
    //     List<User> usersViewModel = new List<User>()
    //     {
    //         userOne, userTwo, userThree, userFour
    //     };
    //     return View(usersViewModel);
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
