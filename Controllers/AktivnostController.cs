using Microsoft.AspNetCore.Authorization;
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



public class AktivnostController : Controller
{
    private readonly ApplicationDbContext _context;
   

    public AktivnostController(ApplicationDbContext context)
    {
        _context = context;
      
    }

    public async Task<IActionResult> Index()
    {
        

       
            var aktivnosti = _context.Aktivnosti
                .OrderByDescending(o => o.Vrijeme)
                .Include(a => a.Proizvod);
            return View(await aktivnosti.ToListAsync());
        

      
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var aktivnost = await _context.Aktivnosti.Include(a => a.Proizvod).FirstOrDefaultAsync(m => m.Id == id);
        if (aktivnost == null) return NotFound();

        return View(aktivnost);
    }

    public IActionResult Create()
    {
        ViewData["ProizvodID"] = new SelectList(_context.Proizvodi, "ProizvodID", "Naziv");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ProizvodID,Vrijeme,Opis")] Aktivnost aktivnost)
    {
        if (ModelState.IsValid)
        {
            _context.Add(aktivnost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ProizvodID"] = new SelectList(_context.Proizvodi, "ProizvodID", "Naziv", aktivnost.ProizvodID);
        return View(aktivnost);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var aktivnost = await _context.Aktivnosti.FindAsync(id);
        if (aktivnost == null) return NotFound();

        ViewData["ProizvodID"] = new SelectList(_context.Proizvodi, "ProizvodID", "Naziv", aktivnost.ProizvodID);
        return View(aktivnost);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProizvodID,Vrijeme,Opis")] Aktivnost aktivnost)
    {
        if (id != aktivnost.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(aktivnost);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Aktivnosti.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["ProizvodID"] = new SelectList(_context.Proizvodi, "ProizvodID", "Naziv", aktivnost.ProizvodID);
        return View(aktivnost);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var aktivnost = await _context.Aktivnosti.Include(a => a.Proizvod).FirstOrDefaultAsync(m => m.Id == id);
        if (aktivnost == null) return NotFound();

        return View(aktivnost);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var aktivnost = await _context.Aktivnosti.FindAsync(id);
        if (aktivnost != null)
        {
            _context.Aktivnosti.Remove(aktivnost);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
