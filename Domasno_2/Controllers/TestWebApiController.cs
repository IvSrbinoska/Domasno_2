using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domasno_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Domasno_2.Controllers
{

    public class TestWebApiController : Controller
    {
        private readonly ILogger<TestWebApiController> _logger;

        public TestWebApiController(ILogger<TestWebApiController> logger)
        {
            
            _logger = logger;
            
        }



        // GET: TestWebApi
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestWebApi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestWebApi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestWebApi/Create
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

        // GET: TestWebApi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestWebApi/Edit/5
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

        // GET: TestWebApi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestWebApi/Delete/5
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

        [HttpGet]
        public async Task<IActionResult> Show(string stockSymbol)
        {
            MarketData obj = new MarketData();

            string dataApi = "";
            using (var webClient = new WebClient())
            {
                string url = "https://api.iextrading.com/1.0";
                url += String.Format("/stock/{0}/quote", stockSymbol);
                try
                {
                    dataApi = await webClient.DownloadStringTaskAsync(url);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Get stock data failed");

                }
            }
            if (dataApi.Length > 0)
            {
                try
                {
                    var dataJson = JObject.Parse(dataApi);
                    //decimal priceClose = dataJson.SelectToken("latestPrice").Value<decimal>();
                    obj.PriceClose = dataJson.SelectToken("latestPrice").Value<decimal>();
                    //ViewBag.price = obj.PriceClose;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Get stock data failed! symbol={0}", stockSymbol);
                }
            }

            return View(obj);
        }


    }
}