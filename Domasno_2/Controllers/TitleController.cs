﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domasno_2.Models;

namespace Domasno_2.Controllers
{
    public class TitleController : Controller
    {
        private readonly Domasno_2Context _context;

        public TitleController(Domasno_2Context context)
        {
            _context = context;
        }

        // GET: Title
        public async Task<IActionResult> Index()
        {
            return View(await _context.Title.ToListAsync());
        }

        // GET: Title/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title
                .SingleOrDefaultAsync(m => m.ID == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // GET: Title/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Title/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TitleName,PublicationYear")] Title title)
        {
            if (ModelState.IsValid)
            {
                _context.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(title);
        }

        // GET: Title/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title.SingleOrDefaultAsync(m => m.ID == id);
            if (title == null)
            {
                return NotFound();
            }
            return View(title);
        }

        // POST: Title/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TitleName,PublicationYear")] Title title)
        {
            if (id != title.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(title);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleExists(title.ID))
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
            return View(title);
        }

        // GET: Title/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title
                .SingleOrDefaultAsync(m => m.ID == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // POST: Title/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var title = await _context.Title.SingleOrDefaultAsync(m => m.ID == id);
            _context.Title.Remove(title);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleExists(int id)
        {
            return _context.Title.Any(e => e.ID == id);
        }
    }
}
