using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domasno_2.Models;

namespace Domasno_2.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly Domasno_2Context _context;

        public CustomerController(Domasno_2Context context)
        {
            _context = context;
        }


        // GET: Customer
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Customer.ToListAsync());
            
        }

        //[Route("")]
        //[Route("Customer")]
        //[Route("Customer/Details")]
        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }




            //var customer = await _context.Customer.SingleOrDefaultAsync(m => m.Age == 35);
            //var customer = await _context.Customer.FirstOrDefaultAsync(m => m.Age == 35);
            //var customer = await _context.Customer.Include(a => a.Addresses).FirstOrDefaultAsync(b=>b.ID==2004);
            //var customer = await _context.Customer.Include(a => a.Addresses).FirstOrDefaultAsync(b => b.Gender == "female");
            //var customer = await _context.Customer.SingleAsync(b => b.ID == 9876);
            //var customer = await  _context.Customer.ToListAsync();
            //var customer = _context.Customer.Where(b => b.FullName.Contains("Iv")).ToList();
            //var customer = await _context.Customer.CountAsync();
            //var customer = await _context.Customer.FirstAsync(a => a.Gender=="male");

            //string FullName = "zoki";
            //string sql = $"Select * from Customer where FullName = '{FullName}'";
            //var customer = await _context.Customer
            //                    .FromSql(sql)
            //                    .ToListAsync();

            //var customer = _context.Customer
            //      .FromSql("Select * from Customer where FullName = 'zoki'")
            //      .ToList();



            //var customer = _context.Customer.Include(b => b.Addresses).Select(b => new
            //{
            //    Id = b.ID,
            //    A = b.Age
            //}).ToList();


            //string sql = $"exec spCustomerGet";
            //var customer = await _context.Customer
            //                    .FromSql(sql)
            //                    .ToListAsync();

            string sql = $"exec spCustomerGet";
            var customer = await _context.Address
                                .FromSql(sql)
                                .ToListAsync();

            var user = "ivona";
            string sql1 = $"exec spCustomerGetByFullName {user}";
            var customer1 = _context.Customer
                .FromSql(sql)
                .ToListAsync();


            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
            
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FullName,Gender,Age,Active")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                //return RedirectToAction(nameof(Create));
                return RedirectToAction("Create");
            }
            return View(customer);
            
        }

        [HttpGet("{id}")] // Matches '/Products/Edit/{id}'
        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FullName,Gender,Age,Active")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
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
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
            //return RedirectToAction("Create");
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.ID == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.ID == id);
        }
    }
}
