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
    public class KelasController : Controller
    {
        private readonly AdministrasiSekolahContext _context;

        public KelasController(AdministrasiSekolahContext context)
        {
            _context = context;
        }

        // GET: Kelas
        public async Task<IActionResult> Index()
        {
            var administrasiSekolahContext = _context.Kelas.Include(k => k.IdMapelNavigation);
            return View(await administrasiSekolahContext.ToListAsync());
        }

        // GET: Kelas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kela = await _context.Kelas
                .Include(k => k.IdMapelNavigation)
                .FirstOrDefaultAsync(m => m.IdKelas == id);
            if (kela == null)
            {
                return NotFound();
            }

            return View(kela);
        }

        // GET: Kelas/Create
        public IActionResult Create()
        {
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel");
            return View();
        }

        // POST: Kelas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKelas,NamaKelas,IdMapel")] Kela kela)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", kela.IdMapel);
            return View(kela);
        }

        // GET: Kelas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kela = await _context.Kelas.FindAsync(id);
            if (kela == null)
            {
                return NotFound();
            }
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", kela.IdMapel);
            return View(kela);
        }

        // POST: Kelas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKelas,NamaKelas,IdMapel")] Kela kela)
        {
            if (id != kela.IdKelas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kela);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KelaExists(kela.IdKelas))
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
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", kela.IdMapel);
            return View(kela);
        }

        // GET: Kelas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kela = await _context.Kelas
                .Include(k => k.IdMapelNavigation)
                .FirstOrDefaultAsync(m => m.IdKelas == id);
            if (kela == null)
            {
                return NotFound();
            }

            return View(kela);
        }

        // POST: Kelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kela = await _context.Kelas.FindAsync(id);
            _context.Kelas.Remove(kela);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KelaExists(int id)
        {
            return _context.Kelas.Any(e => e.IdKelas == id);
        }
    }
}
