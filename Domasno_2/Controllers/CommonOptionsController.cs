using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domasno_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Domasno_2.Controllers
{
    public class CommonOptionsController : Controller
    {
        //private CommonOptions _options;
        //public CommonOptionsController(IOptions<CommonOptions> options)
        //{
        //    _options = options.Value;
        //    
        //}


        // GET: CommonOptions
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommonOptions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommonOptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommonOptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommonOptions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommonOptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommonOptions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommonOptions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}