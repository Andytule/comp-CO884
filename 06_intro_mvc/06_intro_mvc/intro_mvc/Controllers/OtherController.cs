using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using intro_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace intro_mvc.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            var stuff = new Stuff
            {
                Title = "Heading From Controller",
                Name = "Bob Loblaw",
                Served = DateTime.Now
            };
            return View(stuff);
        }

        [Route("stuff/{year:min(2018)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            return new ContentResult { Content = $"Hello from OtherController / Post, year={year}, month={month}, key={key}" };
        }
    }
}
