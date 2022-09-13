using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoSurvey.Models;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // string[] locations = new string[]{"Missoula", "Bozeman", "Billings", "Kallispell"};
            // ViewBag.locations = locations;
            // string[] languages = new string[]{"C#", "C++", "Python", "Java", "JavaScript"};
            // ViewBag.languages = languages;
            return View();
        }

        [HttpPost("SubmitInfo")]
        public IActionResult SubmitInfo(Survey survey)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Result");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("result")]
        public IActionResult Result(Survey survey)
        {
            return View(survey);
        }
        // public IActionResult Result(string Name, string Location, string Language, string Comment)
        // {
        //     IDictionary<string, string> yourInfo = new Dictionary<string, string>();
        //     yourInfo.Add("name", Name);
        //     yourInfo.Add("yourLocation", Location);
        //     yourInfo.Add("favoriteLanguage", Language);
        //     yourInfo.Add("yourComment", Comment);
        //     ViewBag.YourInfo = yourInfo;
        //     return View("Result");
        // }
    }
}