using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductViewer.Data;
using ProductViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



public class IzvjestajController : Controller
{
    private readonly ApplicationDbContext _context;

    public IzvjestajController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Izvjestaji.Include(i => i.Proizvod).ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var izvjestaj = await _context.Izvjestaji.Include(i => i.Proizvod).FirstOrDefaultAsync(m => m.Id == id);
        if (izvjestaj == null) return NotFound();

        return View(izvjestaj);
    }

    public IActionResult Create()
    {
        ViewData["ProizvodID"] = new SelectList(_context.Proizvodi, "ProizvodID", "Naziv");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ProizvodID,DatumIzvjestaja,NiskaKolicina,RokIsteka15Dana,RokIsteka30Dana,Napomena")] Izvjestaj izvjestaj)
    {
        if (ModelState.IsValid)
        {
            _context.Add(izvjestaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ProizvodID"] = new SelectList(_context.Proizvodi, "ProizvodID", "Naziv", izvjestaj.ProizvodID);
        return View(izvjestaj);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var izvjestaj = await _context.Izvjestaji.FindAsync(id);
        if (izvjestaj == null) return NotFound();

        ViewData["ProizvodID"] = new SelectList(_context.Proizvodi, "ProizvodID", "Naziv", izvjestaj.ProizvodID);
        return View(izvjestaj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProizvodID,DatumIzvjestaja,NiskaKolicina,RokIsteka15Dana,RokIsteka30Dana,Napomena")] Izvjestaj izvjestaj)
    {
        if (id != izvjestaj.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(izvjestaj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Izvjestaji.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["ProizvodID"] = new SelectList(_context.Proizvodi, "ProizvodID", "Naziv", izvjestaj.ProizvodID);
        return View(izvjestaj);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var izvjestaj = await _context.Izvjestaji.Include(i => i.Proizvod).FirstOrDefaultAsync(m => m.Id == id);
        if (izvjestaj == null) return NotFound();

        return View(izvjestaj);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var izvjestaj = await _context.Izvjestaji.FindAsync(id);
        if (izvjestaj != null)
        {
            _context.Izvjestaji.Remove(izvjestaj);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}

