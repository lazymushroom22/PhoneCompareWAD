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
    public class HuaweiController : Controller
    {
        private readonly PhoneCompareContext _context;

        public HuaweiController(PhoneCompareContext context)
        {
            _context = context;
        }

        // GET: Huawei
        public async Task<IActionResult> Index()
        {
            return View(await _context.Huawei.ToListAsync());
        }

        // GET: Huawei/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huawei = await _context.Huawei
                .FirstOrDefaultAsync(m => m.HuaweiId == id);
            if (huawei == null)
            {
                return NotFound();
            }

            return View(huawei);
        }

        // GET: Huawei/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Huawei/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HuaweiId,Name,Model,Year")] Huawei huawei)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huawei);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(huawei);
        }

        // GET: Huawei/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huawei = await _context.Huawei.FindAsync(id);
            if (huawei == null)
            {
                return NotFound();
            }
            return View(huawei);
        }

        // POST: Huawei/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HuaweiId,Name,Model,Year")] Huawei huawei)
        {
            if (id != huawei.HuaweiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huawei);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuaweiExists(huawei.HuaweiId))
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
            return View(huawei);
        }

        // GET: Huawei/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huawei = await _context.Huawei
                .FirstOrDefaultAsync(m => m.HuaweiId == id);
            if (huawei == null)
            {
                return NotFound();
            }

            return View(huawei);
        }

        // POST: Huawei/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huawei = await _context.Huawei.FindAsync(id);
            _context.Huawei.Remove(huawei);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuaweiExists(int id)
        {
            return _context.Huawei.Any(e => e.HuaweiId == id);
        }
    }
}
