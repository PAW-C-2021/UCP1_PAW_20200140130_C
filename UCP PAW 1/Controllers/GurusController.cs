using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP_PAW_1.Models;

namespace UCP_PAW_1.Controllers
{
    public class GurusController : Controller
    {
        private readonly AdministrasiSekolahContext _context;

        public GurusController(AdministrasiSekolahContext context)
        {
            _context = context;
        }

        // GET: Gurus
        public async Task<IActionResult> Index()
        {
            var administrasiSekolahContext = _context.Gurus.Include(g => g.IdMapelNavigation);
            return View(await administrasiSekolahContext.ToListAsync());
        }

        // GET: Gurus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Gurus
                .Include(g => g.IdMapelNavigation)
                .FirstOrDefaultAsync(m => m.IdGuru == id);
            if (guru == null)
            {
                return NotFound();
            }

            return View(guru);
        }

        // GET: Gurus/Create
        public IActionResult Create()
        {
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel");
            return View();
        }

        // POST: Gurus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGuru,Nip,NamaGuru,AlamatGuru,NoHp,IdMapel,Keterangan")] Guru guru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", guru.IdMapel);
            return View(guru);
        }

        // GET: Gurus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Gurus.FindAsync(id);
            if (guru == null)
            {
                return NotFound();
            }
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", guru.IdMapel);
            return View(guru);
        }

        // POST: Gurus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGuru,Nip,NamaGuru,AlamatGuru,NoHp,IdMapel,Keterangan")] Guru guru)
        {
            if (id != guru.IdGuru)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuruExists(guru.IdGuru))
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
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", guru.IdMapel);
            return View(guru);
        }

        // GET: Gurus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guru = await _context.Gurus
                .Include(g => g.IdMapelNavigation)
                .FirstOrDefaultAsync(m => m.IdGuru == id);
            if (guru == null)
            {
                return NotFound();
            }

            return View(guru);
        }

        // POST: Gurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guru = await _context.Gurus.FindAsync(id);
            _context.Gurus.Remove(guru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuruExists(int id)
        {
            return _context.Gurus.Any(e => e.IdGuru == id);
        }
    }
}
