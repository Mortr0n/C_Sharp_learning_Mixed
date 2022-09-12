using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class MessageController : Controller
    {
        [HttpGet("message")]
        public IActionResult Message()
        {
            Message message = new Message()
            {
                message = "This is a message.  Lookie!"
            };

            return View(message);
        }
    }
}