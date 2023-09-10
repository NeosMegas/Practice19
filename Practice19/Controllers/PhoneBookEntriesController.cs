using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice19.Data;
using Practice19.Models;

namespace Practice19.Controllers
{
    public class PhoneBookEntriesController : Controller
    {
        private readonly Practice19Context _context;

        public PhoneBookEntriesController(Practice19Context context)
        {
            _context = context;
        }

        // GET: PhoneBookEntries
        public async Task<IActionResult> Index()
        {
              return _context.PhoneBookEntry != null ? 
                          View(await _context.PhoneBookEntry.ToListAsync()) :
                          Problem("Entity set 'Practice19Context.PhoneBookEntry'  is null.");
        }

        // GET: PhoneBookEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhoneBookEntry == null)
            {
                return NotFound();
            }

            var phoneBookEntry = await _context.PhoneBookEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneBookEntry == null)
            {
                return NotFound();
            }

            return View(phoneBookEntry);
        }

        // GET: PhoneBookEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneBookEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,MiddleName,PhoneNumber,Address,Description")] PhoneBookEntry phoneBookEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneBookEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneBookEntry);
        }

        // GET: PhoneBookEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhoneBookEntry == null)
            {
                return NotFound();
            }

            var phoneBookEntry = await _context.PhoneBookEntry.FindAsync(id);
            if (phoneBookEntry == null)
            {
                return NotFound();
            }
            return View(phoneBookEntry);
        }

        // POST: PhoneBookEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,MiddleName,PhoneNumber,Address,Description")] PhoneBookEntry phoneBookEntry)
        {
            if (id != phoneBookEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneBookEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneBookEntryExists(phoneBookEntry.Id))
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
            return View(phoneBookEntry);
        }

        // GET: PhoneBookEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhoneBookEntry == null)
            {
                return NotFound();
            }

            var phoneBookEntry = await _context.PhoneBookEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneBookEntry == null)
            {
                return NotFound();
            }

            return View(phoneBookEntry);
        }

        // POST: PhoneBookEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhoneBookEntry == null)
            {
                return Problem("Entity set 'Practice19Context.PhoneBookEntry'  is null.");
            }
            var phoneBookEntry = await _context.PhoneBookEntry.FindAsync(id);
            if (phoneBookEntry != null)
            {
                _context.PhoneBookEntry.Remove(phoneBookEntry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneBookEntryExists(int id)
        {
          return (_context.PhoneBookEntry?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
