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
    public class XiaomiController : Controller
    {
        private readonly PhoneCompareContext _context;

        public XiaomiController(PhoneCompareContext context)
        {
            _context = context;
        }

        // GET: Xiaomi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Xiaomi.ToListAsync());
        }

        // GET: Xiaomi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xiaomi = await _context.Xiaomi
                .FirstOrDefaultAsync(m => m.XiaomiId == id);
            if (xiaomi == null)
            {
                return NotFound();
            }

            return View(xiaomi);
        }

        // GET: Xiaomi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Xiaomi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("XiaomiId,Name,Model,Year")] Xiaomi xiaomi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xiaomi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(xiaomi);
        }

        // GET: Xiaomi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xiaomi = await _context.Xiaomi.FindAsync(id);
            if (xiaomi == null)
            {
                return NotFound();
            }
            return View(xiaomi);
        }

        // POST: Xiaomi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("XiaomiId,Name,Model,Year")] Xiaomi xiaomi)
        {
            if (id != xiaomi.XiaomiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xiaomi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XiaomiExists(xiaomi.XiaomiId))
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
            return View(xiaomi);
        }

        // GET: Xiaomi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xiaomi = await _context.Xiaomi
                .FirstOrDefaultAsync(m => m.XiaomiId == id);
            if (xiaomi == null)
            {
                return NotFound();
            }

            return View(xiaomi);
        }

        // POST: Xiaomi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var xiaomi = await _context.Xiaomi.FindAsync(id);
            _context.Xiaomi.Remove(xiaomi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XiaomiExists(int id)
        {
            return _context.Xiaomi.Any(e => e.XiaomiId == id);
        }
    }
}
