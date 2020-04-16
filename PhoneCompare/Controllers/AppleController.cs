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
    public class AppleController : Controller
    {
        private readonly PhoneCompareContext _context;

        public AppleController(PhoneCompareContext context)
        {
            _context = context;
        }

        // GET: Apple
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apple.ToListAsync());
        }

        // GET: Apple/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apple
                .FirstOrDefaultAsync(m => m.AppleId == id);
            if (apple == null)
            {
                return NotFound();
            }

            return View(apple);
        }

        // GET: Apple/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apple/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppleId,Name,Model,Year")] Apple apple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apple);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apple);
        }

        // GET: Apple/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apple.FindAsync(id);
            if (apple == null)
            {
                return NotFound();
            }
            return View(apple);
        }

        // POST: Apple/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppleId,Name,Model,Year")] Apple apple)
        {
            if (id != apple.AppleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppleExists(apple.AppleId))
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
            return View(apple);
        }

        // GET: Apple/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apple
                .FirstOrDefaultAsync(m => m.AppleId == id);
            if (apple == null)
            {
                return NotFound();
            }

            return View(apple);
        }

        // POST: Apple/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apple = await _context.Apple.FindAsync(id);
            _context.Apple.Remove(apple);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppleExists(int id)
        {
            return _context.Apple.Any(e => e.AppleId == id);
        }
    }
}
