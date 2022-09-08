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
        public ViewResult HiThere()
        {
            //if no args then it will look for HiThere.cshtml first in the name of our controllers view directory 
            // So for the HomeController it will look in the Home Folder in the Views Folder.  /Views/Home/HiThere.cshtml
            // If it doesn't find it there it will look in /Views/Shared/HiThere.cshtml
            return View();
        }

        [HttpGet("projects")]
        public string Projects()
        {
            return "Here are my Projects";
        }

        [HttpGet("contact")]
        public string Contact()
        {
            return "This is my contact";
        }
    }
}