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
    public class LenovoController : Controller
    {
        private readonly PhoneCompareContext _context;

        public LenovoController(PhoneCompareContext context)
        {
            _context = context;
        }

        // GET: Lenovo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lenovo.ToListAsync());
        }

        // GET: Lenovo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lenovo = await _context.Lenovo
                .FirstOrDefaultAsync(m => m.LenovoId == id);
            if (lenovo == null)
            {
                return NotFound();
            }

            return View(lenovo);
        }

        // GET: Lenovo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lenovo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LenovoId,Name,Model,Year")] Lenovo lenovo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lenovo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lenovo);
        }

        // GET: Lenovo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lenovo = await _context.Lenovo.FindAsync(id);
            if (lenovo == null)
            {
                return NotFound();
            }
            return View(lenovo);
        }

        // POST: Lenovo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LenovoId,Name,Model,Year")] Lenovo lenovo)
        {
            if (id != lenovo.LenovoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lenovo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LenovoExists(lenovo.LenovoId))
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
            return View(lenovo);
        }

        // GET: Lenovo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lenovo = await _context.Lenovo
                .FirstOrDefaultAsync(m => m.LenovoId == id);
            if (lenovo == null)
            {
                return NotFound();
            }

            return View(lenovo);
        }

        // POST: Lenovo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lenovo = await _context.Lenovo.FindAsync(id);
            _context.Lenovo.Remove(lenovo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LenovoExists(int id)
        {
            return _context.Lenovo.Any(e => e.LenovoId == id);
        }
    }
}
