using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WADAssignment1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Our Story";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please see the below information in order to contact us with regards to queries.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
