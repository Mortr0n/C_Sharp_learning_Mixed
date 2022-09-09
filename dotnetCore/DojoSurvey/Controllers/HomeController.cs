using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string[] locations = new string[]{"Missoula", "Bozeman", "Billings", "Kallispell"};
            ViewBag.locations = locations;
            string[] languages = new string[]{"C#", "C++", "Python", "Java", "JavaScript"};
            ViewBag.languages = languages;
            return View();
        }

        [HttpPost("SubmitInfo")]
        public IActionResult SubmitInfo(string yourName, string location, string language, string comment)
        {
            return RedirectToAction("Result", new{Name = yourName, Location = location, Language = language, Comment = comment});
        }

        [HttpGet("result")]
        public IActionResult Result(string Name, string Location, string Language, string Comment)
        {
            IDictionary<string, string> yourInfo = new Dictionary<string, string>();
            yourInfo.Add("name", Name);
            yourInfo.Add("yourLocation", Location);
            yourInfo.Add("favoriteLanguage", Language);
            yourInfo.Add("yourComment", Comment);
            ViewBag.YourInfo = yourInfo;
            return View("Result");
        }
    }
}