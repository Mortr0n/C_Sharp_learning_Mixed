using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("user")]
        public IActionResult User()
        {
            User sally = new User("Sally", "Sanderson");
            return View(sally);
        }
    }
}