using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domasno_2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Domasno_2.Services;

namespace Domasno_2.Controllers
{
    public class AdresaController : Controller
    {
        private readonly Domasno_2Context _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AdresaController> _logger;
        private readonly CommonOptions _options;
        public AdresaController(Domasno_2Context context, IConfiguration configuration, 
            ILogger<AdresaController> logger, IOptions<CommonOptions> options)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
            _options = options.Value;
        }

        // GET: Adresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Address.ToListAsync());
        }

        // GET: Adresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tmp = _configuration["Common:WebSiteUrl"];
            string tst2 = _configuration["testiranje"];
            _logger.LogError("********************   proba za logiranje vo fajl");


            //var address = await _context.Address.SingleOrDefaultAsync(m => m.ID == id);
            //var address = _context.Address.Include(m => m.Publisher).Include(m => m.Customer).ToList();
            //var address = _context.Address.SingleOrDefault(b => b.ID == 1);
            //address.City = "London";
            //_context.SaveChanges();

            //var address = await _context.Address.AsNoTracking().ToListAsync();
            //var address = await _context.Address.FromSql("SELECT * FROM dbo.Address").ToListAsync();


            //var searchTerm = "adr";

            //var address = _context.Address
            //.FromSql($"SELECT * FROM dbo.Address({searchTerm})").ToList();
            //.Where(b => b.Rating > 3)
            //.OrderByDescending(b => b.Rating)
            //.ToList();



            //var address = _context.Address.FromSql("SELECT * FROM dbo.Address").OrderBy(b => b.City);
            //var searchTerm = "ivana";
            //var address = _context.Address.FromSql($"SELECT * FROM [dbo].[Address]({searchTerm})");
            //var address = await _context.Address.FromSql("SELECT * FROM dbo.Address").Where(b => b.City == "Skopje")
            //.OrderByDescending(b => b.FirstName).ToListAsync();
            //var address = await _context.Address.FromSql("SELECT * FROM dbo.Address").Where(b => b.City == "Skopje")
            //.OrderBy(b => b.FirstName).ToListAsync();


            var address =await _context.Address.FromSql("SELECT * FROM Address").Select(b => new
            {
                FirstName = b.FirstName,
                City = b.City
            }).ToListAsync();


            if (address == null)
            {
                return NotFound();
            }

            //return View(address);
            //return RedirectToAction("Index", "Customer");
            //return RedirectToAction("Index", "Customer", new { name = "ivana" });
            //return RedirectToAction("Show", "TestWebApi", new { stockSymbol = "aapl" });
            //var objectController = new TestWebApiController(null);

            //var ret = await objectController.Show("aapl");
            var servis = new MoiServisi();
            int c = servis.Soberi(2, 3);
            int p = await servis.Pomnozi(4, 5);
            decimal price = await servis.GetStockPriceAsync("aapl");
            
            return View(address);
        }

        // GET: Adresa/Create
        public IActionResult Create()
        {
            //_logger.LogInformation("info proba za logiranje vo fajl");
            _logger.LogDebug("debug proba za logiranje vo fajl");
            return View();
        }

        // POST: Adresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Address1,Address2,City,PostalCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                

            }
            return View(address);
        }

        // GET: Adresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address.SingleOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // POST: Adresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Address1,Address2,City,PostalCode")] Address address)
        {
            if (id != address.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Adresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .SingleOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Adresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Address.SingleOrDefaultAsync(m => m.ID == id);
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.ID == id);
        }

    }
}
