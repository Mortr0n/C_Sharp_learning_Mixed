using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }
        
        [HttpGet("HiThere")]
        public ViewResult HiThere()
        {
            //if no args then it will look for HiThere.cshtml first in the name of our controllers view directory 
            // So for the HomeController it will look in the Home Folder in the Views Folder.  /Views/Home/HiThere.cshtml
            // If it doesn't find it there it will look in /Views/Shared/HiThere.cshtml
            // If there are 2 of the same named file it will grab the first one that it finds.
            return View();
        }

        [HttpGet("projects")]
        public IActionResult Projects()
        {
            return View("Projects");
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }

        [HttpGet("{testResponse}")]
        // IActionResult will take any of our return types.  It's less performant, but ususally will do the job.
        public IActionResult Test(string testResponse)
        {
            if(testResponse == "Redirect")
            {
                Console.WriteLine("Redirecting...");
                return RedirectToAction("Index");
            }
            else if(testResponse == "Json")
            {
                return Json(new {TestResponse = testResponse});
            }
            return View();
        }
    }
}