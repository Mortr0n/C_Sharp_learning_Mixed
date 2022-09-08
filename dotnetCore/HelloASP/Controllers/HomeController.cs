using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASP
{
    public class HomeController : Controller
    {
        [HttpGet("")]  // Can collapse the 2 square items into one by providing the parenthesis inside the verb item.  See below "wow" route for non-collapsed version.
        public string Index()
        {
            return "Hello from the HomeController";
        }

        // Below route is the verb and route separated
        [HttpGet]
        [Route("wow")] //Works with or without the preceding slash so far.
        public string Wow()
        {
            return "Wow! Look ma, no hands!";
        }

        // localhost:5000/users/???  the ??? would be the route parameter and it's named username
        [HttpGet("users/{username}/{location}")]
        public string HelloUser(string username, string location)
        {
            if(location == "Missoula")
            {
                return $"Missoula, what a city!  Thanks for stopping by {username}";
            } 
            else 
            {
                return $"Hello there {username} from {location}!";
            }
            
        }
    }
}