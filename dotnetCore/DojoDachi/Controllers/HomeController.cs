using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoDachi.Models;
using Microsoft.AspNetCore.Http;

namespace DojoDachi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public int energyScore = 0;
    public int fullScore = 0;
    public int happyScore = 0;
    public int mealScore = 0;

    public void SetBaseScores() 
    {
        if(HttpContext.Session.GetInt32("FullScore") == null) 
            HttpContext.Session.SetInt32("FullScore", 20);
        if(HttpContext.Session.GetInt32("HappyScore") == null) 
            HttpContext.Session.SetInt32("HappyScore", 20);
        if(HttpContext.Session.GetInt32("MealScore") == null) 
            HttpContext.Session.SetInt32("MealScore", 3);
        if(HttpContext.Session.GetInt32("EnergyScore") == null) 
            HttpContext.Session.SetInt32("EnergyScore", 50);
        if(HttpContext.Session.GetString("Message") == null)
            HttpContext.Session.SetString("Message", "Dachi is blah right now.");
        energyScore = HttpContext.Session.GetInt32("EnergyScore").GetValueOrDefault();
        fullScore = HttpContext.Session.GetInt32("FullScore").GetValueOrDefault();
        happyScore = HttpContext.Session.GetInt32("HappyScore").GetValueOrDefault();
        mealScore = HttpContext.Session.GetInt32("MealScore").GetValueOrDefault();
    }

    [HttpGet("Reset")]
    public IActionResult Reset()
    {
        HttpContext.Session.SetInt32("FullScore", 20);
        HttpContext.Session.SetInt32("HappyScore", 20);
        HttpContext.Session.SetInt32("MealScore", 3);
        HttpContext.Session.SetInt32("EnergyScore", 50);
        HttpContext.Session.SetString("Message", "Dachi is blah right now.");
        HttpContext.Session.SetString("Lose", "False");
        Console.WriteLine("In the Reset!");
        return RedirectToAction("Index");
    }

    public void SetViewBagItems()
    {
        ViewBag.FullScore = HttpContext.Session.GetInt32("FullScore");
        ViewBag.HappyScore = HttpContext.Session.GetInt32("HappyScore");
        ViewBag.MealScore = HttpContext.Session.GetInt32("MealScore");
        ViewBag.EnergyScore = HttpContext.Session.GetInt32("EnergyScore");
        ViewBag.Message = HttpContext.Session.GetString("Message");
        ViewBag.Lose = HttpContext.Session.GetString("Lose");
    }

    public IActionResult Index()
    {
        SetBaseScores();
        SetViewBagItems();
        return View();
    }

    public Random rand = new Random();
    [HttpGet("Feed")]
    public IActionResult Feed()
    {
        int mealsLeft = HttpContext.Session.GetInt32("MealScore").GetValueOrDefault();
        int fullScore = HttpContext.Session.GetInt32("FullScore").GetValueOrDefault();
        if(ItsGoneBad())
        {
            fullScore -= 5;
            HttpContext.Session.SetInt32("FullScore", fullScore);
            HttpContext.Session.SetInt32("MealScore", mealsLeft--);
            HttpContext.Session.SetString("Message", "Dachi didn't like his food and throws it all up.");
            return RedirectToAction("Index");
        }
        if(mealsLeft > 0)
        {
            mealsLeft--;
            if(fullScore < 120) 
            {
                int fullnessToAdd = rand.Next(5,11);
                HttpContext.Session.SetInt32("FullScore", fullScore + fullnessToAdd);
                HttpContext.Session.SetInt32("MealScore", mealsLeft);
                if(HttpContext.Session.GetInt32("FullScore") < 100)
                {
                    HttpContext.Session.SetString("Message", "Dachi eats a meal and is a little less hungry.");
                }
                else
                {
                    HttpContext.Session.SetString("Message", "After Eating, Dachi is stuffed!");
                }
            }
            
        }
        else
        {
            HttpContext.Session.SetString("Message", "Oh noes!  You're out of food.");
        }
        CheckWin();
        Console.WriteLine(mealsLeft.ToString(), fullScore.ToString());
        return RedirectToAction("Index");
    }

    [HttpGet("Work")]
    public IActionResult Work()
    {
        int energyScore = HttpContext.Session.GetInt32("EnergyScore").GetValueOrDefault();
        int mealScore = HttpContext.Session.GetInt32("MealScore").GetValueOrDefault();
        if(energyScore - 5 >= 0) 
        {
            int mealsEarned = rand.Next(1,4);
            mealScore += mealsEarned;
            energyScore -= 5;
            HttpContext.Session.SetInt32("MealScore", mealScore);
            HttpContext.Session.SetInt32("EnergyScore", energyScore);
            HttpContext.Session.SetString("Message", $"Dachi works his tail off and earns {mealsEarned} meals.");
        }
        else
        {
            HttpContext.Session.SetString("Message", $"Dachi is all out of energy!");
        }
        CheckWin();
        CheckLose();
        return RedirectToAction("Index");
    }

    

    public void GetScores()
    {
        energyScore = HttpContext.Session.GetInt32("EnergyScore").GetValueOrDefault();
        fullScore = HttpContext.Session.GetInt32("FullScore").GetValueOrDefault();
        happyScore = HttpContext.Session.GetInt32("HappyScore").GetValueOrDefault();
    }

    [HttpGet("Sleep")]
    public IActionResult Sleep()
    {
        int energyScore = HttpContext.Session.GetInt32("EnergyScore").GetValueOrDefault();
        int fullScore = HttpContext.Session.GetInt32("FullScore").GetValueOrDefault();
        int happyScore = HttpContext.Session.GetInt32("HappyScore").GetValueOrDefault();
        if(energyScore + 15 <= 120)
        {
            energyScore += 15;
            fullScore -= 5;
            happyScore -= 5;
            HttpContext.Session.SetInt32("FullScore", fullScore);
            HttpContext.Session.SetInt32("HappyScore", happyScore);
            HttpContext.Session.SetInt32("EnergyScore", energyScore);
            HttpContext.Session.SetString("Message", "Dachi gets some rest and feels refreshed.");
        }
        else
        {
            HttpContext.Session.SetString("Message", "Dachi is not tired enough to rest.");
        }
        CheckWin();
        CheckLose();
        return RedirectToAction("Index");
    }

    [HttpGet("Play")]
    public IActionResult Play()
    {
        int energyScore = HttpContext.Session.GetInt32("EnergyScore").GetValueOrDefault();
        int happyScore = HttpContext.Session.GetInt32("HappyScore").GetValueOrDefault();
        if(ItsGoneBad())
        {
            energyScore -= 5;
            HttpContext.Session.SetInt32("EnergyScore", energyScore);
            HttpContext.Session.SetString("Message", $"Dachi isn't feeling like playing right now and pouts so hard he loses energy.");
            return RedirectToAction("Index");
        }
        if(energyScore - 5 >= 0)
        {
            energyScore -= 5;
            int happyAmount = rand.Next(5,11);
            happyScore += happyAmount;
            HttpContext.Session.SetInt32("HappyScore", happyScore);
            HttpContext.Session.SetInt32("EnergyScore", energyScore);
            HttpContext.Session.SetString("Message", $"Dachi gets some of his energy out while having a blast.  He earns {happyScore} points.");
        }
        else
        {
            HttpContext.Session.SetString("Message", "Dachi is much too tired to play!");
        }
        CheckWin();
        CheckLose();
        return RedirectToAction("Index");
    }

    public bool CheckWin()
    {
        energyScore = HttpContext.Session.GetInt32("EnergyScore").GetValueOrDefault();
        fullScore = HttpContext.Session.GetInt32("FullScore").GetValueOrDefault();
        happyScore = HttpContext.Session.GetInt32("HappyScore").GetValueOrDefault();
        mealScore = HttpContext.Session.GetInt32("MealScore").GetValueOrDefault();
        if(energyScore >= 100 && happyScore >= 100 && fullScore >= 100)
        {
            HttpContext.Session.SetString("Message", "Dachi explodes with happiness!  You win!");
        }
        return true;
    }

    public bool CheckLose()
    {
        energyScore = HttpContext.Session.GetInt32("EnergyScore").GetValueOrDefault();
        fullScore = HttpContext.Session.GetInt32("FullScore").GetValueOrDefault();
        happyScore = HttpContext.Session.GetInt32("HappyScore").GetValueOrDefault();
        mealScore = HttpContext.Session.GetInt32("MealScore").GetValueOrDefault();
        if(energyScore <= 0 || fullScore <= 0 || happyScore <= 0)
        {
            HttpContext.Session.SetString("Message", "Dachi died from lack of proper care.  You Lose!");
            HttpContext.Session.SetString("Lose", "True");
        }        
        return true;
    }

    public bool ItsGoneBad()
    {
        if(rand.Next(1,5) == 1)
        {
            return true;
        }
        return false;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
