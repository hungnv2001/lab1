using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab1.Models;
using lab1.Models.Context;

namespace lab1.Controllers
{
    public class InformationController : Controller
    {
        private readonly MyContext _context;

        public InformationController(MyContext context)
        {
            _context = context;
        }

        // GET: Information
        public async Task<IActionResult> Index()
        {
              return _context.Informations != null ? 
                          View(await _context.Informations.ToListAsync()) :
                          Problem("Entity set 'MyContext.Informations'  is null.");
        }

        // GET: Information/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Informations == null)
            {
                return NotFound();
            }

            var information = await _context.Informations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (information == null)
            {
                return NotFound();
            }

            return View(information);
        }

        // GET: Information/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Information/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,License,Establshied,Revenue")] Information information)
        {
            if (ModelState.IsValid)
            {
                _context.Add(information);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(information);
        }

        // GET: Information/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Informations == null)
            {
                return NotFound();
            }

            var information = await _context.Informations.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }
            return View(information);
        }

        // POST: Information/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,License,Establshied,Revenue")] Information information)
        {
            if (id != information.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(information);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformationExists(information.Id))
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
            return View(information);
        }

        // GET: Information/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Informations == null)
            {
                return NotFound();
            }

            var information = await _context.Informations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (information == null)
            {
                return NotFound();
            }

            return View(information);
        }

        // POST: Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Informations == null)
            {
                return Problem("Entity set 'MyContext.Informations'  is null.");
            }
            var information = await _context.Informations.FindAsync(id);
            if (information != null)
            {
                _context.Informations.Remove(information);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformationExists(int id)
        {
          return (_context.Informations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
