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
    public class NilaisController : Controller
    {
        private readonly AdministrasiSekolahContext _context;

        public NilaisController(AdministrasiSekolahContext context)
        {
            _context = context;
        }

        // GET: Nilais
        public async Task<IActionResult> Index()
        {
            var administrasiSekolahContext = _context.Nilais.Include(n => n.IdGuruNavigation).Include(n => n.IdMapelNavigation).Include(n => n.IdSiswaNavigation);
            return View(await administrasiSekolahContext.ToListAsync());
        }

        // GET: Nilais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nilai = await _context.Nilais
                .Include(n => n.IdGuruNavigation)
                .Include(n => n.IdMapelNavigation)
                .Include(n => n.IdSiswaNavigation)
                .FirstOrDefaultAsync(m => m.IdNilai == id);
            if (nilai == null)
            {
                return NotFound();
            }

            return View(nilai);
        }

        // GET: Nilais/Create
        public IActionResult Create()
        {
            ViewData["IdGuru"] = new SelectList(_context.Gurus, "IdGuru", "IdGuru");
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel");
            ViewData["IdSiswa"] = new SelectList(_context.Siswas, "IdSiswa", "IdSiswa");
            return View();
        }

        // POST: Nilais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNilai,JumlahNilai,Kkm,IdSiswa,IdMapel,IdGuru,Keterangan")] Nilai nilai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nilai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGuru"] = new SelectList(_context.Gurus, "IdGuru", "IdGuru", nilai.IdGuru);
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", nilai.IdMapel);
            ViewData["IdSiswa"] = new SelectList(_context.Siswas, "IdSiswa", "IdSiswa", nilai.IdSiswa);
            return View(nilai);
        }

        // GET: Nilais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nilai = await _context.Nilais.FindAsync(id);
            if (nilai == null)
            {
                return NotFound();
            }
            ViewData["IdGuru"] = new SelectList(_context.Gurus, "IdGuru", "IdGuru", nilai.IdGuru);
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", nilai.IdMapel);
            ViewData["IdSiswa"] = new SelectList(_context.Siswas, "IdSiswa", "IdSiswa", nilai.IdSiswa);
            return View(nilai);
        }

        // POST: Nilais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNilai,JumlahNilai,Kkm,IdSiswa,IdMapel,IdGuru,Keterangan")] Nilai nilai)
        {
            if (id != nilai.IdNilai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nilai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NilaiExists(nilai.IdNilai))
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
            ViewData["IdGuru"] = new SelectList(_context.Gurus, "IdGuru", "IdGuru", nilai.IdGuru);
            ViewData["IdMapel"] = new SelectList(_context.Mapels, "IdMapel", "IdMapel", nilai.IdMapel);
            ViewData["IdSiswa"] = new SelectList(_context.Siswas, "IdSiswa", "IdSiswa", nilai.IdSiswa);
            return View(nilai);
        }

        // GET: Nilais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nilai = await _context.Nilais
                .Include(n => n.IdGuruNavigation)
                .Include(n => n.IdMapelNavigation)
                .Include(n => n.IdSiswaNavigation)
                .FirstOrDefaultAsync(m => m.IdNilai == id);
            if (nilai == null)
            {
                return NotFound();
            }

            return View(nilai);
        }

        // POST: Nilais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nilai = await _context.Nilais.FindAsync(id);
            _context.Nilais.Remove(nilai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NilaiExists(int id)
        {
            return _context.Nilais.Any(e => e.IdNilai == id);
        }
    }
}
