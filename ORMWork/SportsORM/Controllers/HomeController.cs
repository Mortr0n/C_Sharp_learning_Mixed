using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();
            

            ViewBag.Hockey = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();

            ViewBag.NotFootball = _context.Leagues
                .Where(l => !l.Sport.Contains("Football"))
                .ToList();

            ViewBag.Conferences = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();

            ViewBag.Atlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            
            ViewBag.Dallas = _context.Teams
                .Where(team => team.Location.Equals("Dallas"))
                .ToList();
            
            ViewBag.Raptors = _context.Teams
                .Where(team => team.TeamName.Equals("Raptors"))
                .ToList();
            
            ViewBag.City = _context.Teams
                .Where(team => team.Location.Contains("City"))
                .ToList();

            ViewBag.TStart = _context.Teams
                .Where(team => team.TeamName.StartsWith("T"))
                .ToList();

            ViewBag.AllTeams = _context.Teams
                .OrderBy(team => team.Location)
                .ToList();

            ViewBag.ReverseAlphabeticAllTeams = _context.Teams
                .OrderByDescending(team => team.Location)
                .ToList();

            ViewBag.Cooper = _context.Players
                .Where(player => player.LastName.Equals("Cooper"))
                .ToList();

            ViewBag.Joshua = _context.Players
                .Where(player => player.FirstName.Equals("Joshua"))
                .ToList();

            List<Player> cooper = _context.Players.Where(Player => Player.LastName.Equals("Cooper")).ToList();
            
            ViewBag.CoopMinusJosh = _context.Players
                .Where(player => player.LastName.Equals("Cooper") && !player.FirstName.Equals("Joshua"))
                .ToList();
            
            ViewBag.AlexanderAndWyatt = _context.Players
                .Where(player => player.FirstName.Equals("Alexander") || player.FirstName.Equals("Wyatt"))
                .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}