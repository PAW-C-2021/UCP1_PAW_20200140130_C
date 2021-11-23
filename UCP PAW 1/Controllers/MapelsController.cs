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
    public class MapelsController : Controller
    {
        private readonly AdministrasiSekolahContext _context;

        public MapelsController(AdministrasiSekolahContext context)
        {
            _context = context;
        }

        // GET: Mapels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mapels.ToListAsync());
        }

        // GET: Mapels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapel = await _context.Mapels
                .FirstOrDefaultAsync(m => m.IdMapel == id);
            if (mapel == null)
            {
                return NotFound();
            }

            return View(mapel);
        }

        // GET: Mapels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mapels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMapel,NamaMapel")] Mapel mapel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mapel);
        }

        // GET: Mapels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapel = await _context.Mapels.FindAsync(id);
            if (mapel == null)
            {
                return NotFound();
            }
            return View(mapel);
        }

        // POST: Mapels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMapel,NamaMapel")] Mapel mapel)
        {
            if (id != mapel.IdMapel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapelExists(mapel.IdMapel))
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
            return View(mapel);
        }

        // GET: Mapels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapel = await _context.Mapels
                .FirstOrDefaultAsync(m => m.IdMapel == id);
            if (mapel == null)
            {
                return NotFound();
            }

            return View(mapel);
        }

        // POST: Mapels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mapel = await _context.Mapels.FindAsync(id);
            _context.Mapels.Remove(mapel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapelExists(int id)
        {
            return _context.Mapels.Any(e => e.IdMapel == id);
        }
    }
}
