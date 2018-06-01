using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domasno_2.Models;
using AutoMapper;
using System.Net;

namespace Domasno_2.Controllers
{
    [Route("[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly Domasno_2Context _context;
        private readonly IMapper _mapper;
        //private object _dataManager;

        public CustomerController(Domasno_2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: Customer
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AgeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "age_desc" : "";
            //ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;



            var customers = from c in _context.Customer
                           select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.FullName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(c => c.FullName);
                    break;
                case "Gender":
                    customers = customers.OrderBy(c => c.Gender);
                    break;
                case "age_desc":
                    customers = customers.OrderByDescending(c => c.Age);
                    break;
                case "Active":
                    customers = customers.OrderBy(c => c.Active);
                    break;
                default:
                    customers = customers.OrderBy(c => c.FullName);
                    break;
            }
            int pageSize = 4;
            return View(await PaginatedList<Customer>.CreateAsync(customers.AsNoTracking(), page ?? 1, pageSize));
        }
        //[Route("")]
        //[Route("Customer")]
        //[Route("Customer/Details")]
        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            Employee emp = new Employee();
            emp.FirstName = "Ivana";
            emp.LastName = "Srbinoska";
            emp.Salary = 100;
            var person =_mapper.Map<Person>(emp);

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

        //[HttpGet("{id}")] // Matches '/Products/Edit/{id}'
        //GET: Customer/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Customer customer = await _context.Customer.SingleOrDefaultAsync(m => m.ID == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(customer);
        //}

        
        //POST: Customer/Edit/5
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,FullName,Gender,Age,Active")] Customer customer)
        //{
        //    if (id != customer.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(customer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomerExists(customer.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            Customer item = await _context.Customer.SingleOrDefaultAsync(m => m.ID == id);
            if (item == null)
            { return NotFound();
            }
            Customer_VM vm = _mapper.Map<Customer_VM>(item);
            return View("EditVM", vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer_VM vm)
        {

            if (ModelState.IsValid)
            {
                int id = vm.ID;
                Customer item = await _context.Customer.SingleOrDefaultAsync(m => m.ID == id);
                _mapper.Map(vm, item);
                _context.Update(item);
                int updated = await _context.SaveChangesAsync();
                if (updated > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Update failed.");

                }

            }
            return View(vm);
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

        //public async Task<IActionResult> Edit(int? id)
        //{

        //    if (id == null)
        //    {
        //        return StatusCode((int)HttpStatusCode.BadRequest);
        //    }
        //    int sID = (int)id;
        //    //object _dataManager = null;
            
        //    var item = await _context.Customer.Get(sID);
        //    if (item == null) { return NotFound(); }
        //    var vm = _mapper.Map<Address_ViewModel>(item);
        //    return View(vm);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Address_ViewModel vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var itemDb = await _dataManager.Get(vm.);
        //        _mapper.Map(vm, itemDb);
        //        var updated = await _dataManager.Update(itemDb);
        //        if (updated > 0)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Update failed.");
        //            foreach (var err in _dataManager.GetErrors())
        //            {
        //                ModelState.AddModelError("system", err);
        //            }
        //        }

        //    }
        //    return View(vm);
        //}



    }
}
