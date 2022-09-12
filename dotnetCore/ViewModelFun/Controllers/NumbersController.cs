using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class NumbersController : Controller
    {
        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            Numbers numbers = new Numbers()
            {
                numberArray = new int[] { 1,4,7,85,43,54}
            };

            return View(numbers);
        }
    }
}