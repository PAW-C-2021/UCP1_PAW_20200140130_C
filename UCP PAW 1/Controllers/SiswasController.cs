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
    public class SiswasController : Controller
    {
        private readonly AdministrasiSekolahContext _context;

        public SiswasController(AdministrasiSekolahContext context)
        {
            _context = context;
        }

        // GET: Siswas
        public async Task<IActionResult> Index()
        {
            var administrasiSekolahContext = _context.Siswas.Include(s => s.IdKelasNavigation);
            return View(await administrasiSekolahContext.ToListAsync());
        }

        // GET: Siswas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswas
                .Include(s => s.IdKelasNavigation)
                .FirstOrDefaultAsync(m => m.IdSiswa == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // GET: Siswas/Create
        public IActionResult Create()
        {
            ViewData["IdKelas"] = new SelectList(_context.Kelas, "IdKelas", "IdKelas");
            return View();
        }

        // POST: Siswas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSiswa,Nis,NamaSiswa,AlamatSiswa,NoHp,IdKelas")] Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKelas"] = new SelectList(_context.Kelas, "IdKelas", "IdKelas", siswa.IdKelas);
            return View(siswa);
        }

        // GET: Siswas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswas.FindAsync(id);
            if (siswa == null)
            {
                return NotFound();
            }
            ViewData["IdKelas"] = new SelectList(_context.Kelas, "IdKelas", "IdKelas", siswa.IdKelas);
            return View(siswa);
        }

        // POST: Siswas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSiswa,Nis,NamaSiswa,AlamatSiswa,NoHp,IdKelas")] Siswa siswa)
        {
            if (id != siswa.IdSiswa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiswaExists(siswa.IdSiswa))
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
            ViewData["IdKelas"] = new SelectList(_context.Kelas, "IdKelas", "IdKelas", siswa.IdKelas);
            return View(siswa);
        }

        // GET: Siswas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siswa = await _context.Siswas
                .Include(s => s.IdKelasNavigation)
                .FirstOrDefaultAsync(m => m.IdSiswa == id);
            if (siswa == null)
            {
                return NotFound();
            }

            return View(siswa);
        }

        // POST: Siswas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siswa = await _context.Siswas.FindAsync(id);
            _context.Siswas.Remove(siswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiswaExists(int id)
        {
            return _context.Siswas.Any(e => e.IdSiswa == id);
        }
    }
}
