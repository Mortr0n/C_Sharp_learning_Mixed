using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet("users")]
        public IActionResult Users() 
        {
            Users people = new Users()
            {
                names = new List<User> 
                {
                    new User ("Sandra", "Sanderson"),
                    new User ("Shelly", "Campbell"),
                    new User ("Chris", "Morton"),
                    new User ("Lenny", "Lannister")
                }
            };
            return View(people);
        }
    }
}