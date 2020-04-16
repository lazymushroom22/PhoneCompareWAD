using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneCompare;
using PhoneCompare.Models;

namespace PhoneCompare.Controllers
{
    public class SamsungController : Controller
    {
        private readonly PhoneCompareContext _context;

        public SamsungController(PhoneCompareContext context)
        {
            _context = context;
        }

        // GET: Samsung
        public async Task<IActionResult> Index()
        {
            return View(await _context.Samsung.ToListAsync());
        }

        // GET: Samsung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samsung = await _context.Samsung
                .FirstOrDefaultAsync(m => m.SamsungId == id);
            if (samsung == null)
            {
                return NotFound();
            }

            return View(samsung);
        }

        // GET: Samsung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Samsung/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SamsungId,Name,Model,Year")] Samsung samsung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samsung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(samsung);
        }

        // GET: Samsung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samsung = await _context.Samsung.FindAsync(id);
            if (samsung == null)
            {
                return NotFound();
            }
            return View(samsung);
        }

        // POST: Samsung/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SamsungId,Name,Model,Year")] Samsung samsung)
        {
            if (id != samsung.SamsungId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samsung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamsungExists(samsung.SamsungId))
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
            return View(samsung);
        }

        // GET: Samsung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samsung = await _context.Samsung
                .FirstOrDefaultAsync(m => m.SamsungId == id);
            if (samsung == null)
            {
                return NotFound();
            }

            return View(samsung);
        }

        // POST: Samsung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var samsung = await _context.Samsung.FindAsync(id);
            _context.Samsung.Remove(samsung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamsungExists(int id)
        {
            return _context.Samsung.Any(e => e.SamsungId == id);
        }
    }
}
