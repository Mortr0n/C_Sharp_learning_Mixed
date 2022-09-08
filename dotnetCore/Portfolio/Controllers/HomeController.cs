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
        public string Index()
        {
            return "Index";
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