using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductViewer.Data;
using ProductViewer.Models;

namespace ProductViewer.Controllers
{
    public class TipKategorijeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipKategorijeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipKategorije
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipKategorije.ToListAsync());
        }

        // GET: TipKategorije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipKategorije = await _context.TipKategorije
                .FirstOrDefaultAsync(m => m.tipID == id);
            if (tipKategorije == null)
            {
                return NotFound();
            }

            return View(tipKategorije);
        }

        // GET: TipKategorije/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipKategorije/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tipID,Tip")] TipKategorije tipKategorije)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipKategorije);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipKategorije);
        }

        // GET: TipKategorije/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipKategorije = await _context.TipKategorije.FindAsync(id);
            if (tipKategorije == null)
            {
                return NotFound();
            }
            return View(tipKategorije);
        }

        // POST: TipKategorije/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tipID,Tip")] TipKategorije tipKategorije)
        {
            if (id != tipKategorije.tipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipKategorije);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipKategorijeExists(tipKategorije.tipID))
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
            return View(tipKategorije);
        }

        // GET: TipKategorije/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipKategorije = await _context.TipKategorije
                .FirstOrDefaultAsync(m => m.tipID == id);
            if (tipKategorije == null)
            {
                return NotFound();
            }

            return View(tipKategorije);
        }

        // POST: TipKategorije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipKategorije = await _context.TipKategorije.FindAsync(id);
            if (tipKategorije != null)
            {
                _context.TipKategorije.Remove(tipKategorije);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipKategorijeExists(int id)
        {
            return _context.TipKategorije.Any(e => e.tipID == id);
        }
    }
}
