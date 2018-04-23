using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domasno_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domasno_2.Controllers
{
    public class AddressController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            //Address adr = new Address
            //{
            //    ID = 1,
            //    FirstName = "John",
            //    LastName = "Smith",
            //    Address1 = "23 NW 13th St",
            //    Address2 = "#134",
            //    City = "Miami",
            //    PostalCode = 22431
            //};
            ////ViewData["Message"] = adr;
            //return View(adr);

            var adrress = new List<Address>
            {
                new Address
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Address1 = "23 NW 13th St",
                    Address2 = "#134",
                    City = "Miami",
                    PostalCode = "22431" },
                new Address
                {
                    FirstName = "Phil",
                    LastName = "Jones",
                    Address1 = "25 NW 20th St",
                    Address2 = "#200",
                    City = "Texas",
                    PostalCode = "34521"
                },

                new Address
                {
                    FirstName = "Petar",
                    LastName = "Petrovski",
                    Address1 = "Leninova",
                    Address2 = "#250",
                    City = "Skopje",
                    PostalCode = "1000"
                }
            };
           // adrress.ForEach(d => context.Movies.Add(d));
           return View(adrress);
        }
    }
}