using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductViewer.Data;
using ProductViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProductViewer.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public ProizvodController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Proizvodi.Include(p => p.Korisnik).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var proizvod = await _context.Proizvodi.Include(p => p.Korisnik).FirstOrDefaultAsync(p => p.ProizvodID == id);
            if (proizvod == null) return NotFound();

            return View(proizvod);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naziv,Dobavljac,Kolicina,DatumProizvodnje,DatumIsteka,Kategorija,SlikaUrl")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {

                _context.Add(proizvod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvod);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var proizvod = await _context.Proizvodi.FindAsync(id);
            if (proizvod == null) return NotFound();

            return View(proizvod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProizvodID,Naziv,Dobavljac,Kolicina,DatumProizvodnje,DatumIsteka,Kategorija,SlikaUrl")] Proizvod proizvod)
        {
            if (id != proizvod.ProizvodID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Proizvodi.Any(p => p.ProizvodID == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proizvod);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var proizvod = await _context.Proizvodi.Include(p => p.Korisnik).FirstOrDefaultAsync(m => m.ProizvodID == id);
            if (proizvod == null) return NotFound();

            return View(proizvod);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvod = await _context.Proizvodi.FindAsync(id);
            if (proizvod != null)
            {
                _context.Proizvodi.Remove(proizvod);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}