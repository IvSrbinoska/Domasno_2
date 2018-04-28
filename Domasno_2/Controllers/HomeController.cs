using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domasno_2.Models;

namespace Domasno_2.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]// Combines to define the route template "Home"
        //[Route("Home")]
        //[Route("Home/Index")]
        [Route("Index")] // Combines to define the route template "Home/Index"
        [Route("/")]     // Doesn't combine, defines the route template ""
        public IActionResult Index()
        {
            ViewData["Message"] = "Home index";
            var url = Url.Action("Index", "Home");
            ViewData["Message"] = "Home index" + "var url = Url.Action; =  " + url;
            
            return View();
        }
        //[Route("Home/About")]
        [Route("About")] // Combines to define the route template "Home/About"
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Route("Home/Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        //[Route("Home/Contact")]
        //public IActionResult MyContact()
        //{
        //    return View("Contact");
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
