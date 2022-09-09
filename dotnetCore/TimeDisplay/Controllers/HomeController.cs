using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            DateTime today = DateTime.Now;
            ViewBag.Today = today;
            return View("Index");
        }
    }
}