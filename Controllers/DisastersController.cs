using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;

namespace DisasterAlleviationFoundation.Controllers
{
    public class DisastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disasters
        public async Task<IActionResult> Index()
        {
              return _context.Disasters != null ? 
                          View(await _context.Disasters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Disasters'  is null.");
        }

        // GET: Disasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disasters = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisasterId == id);
            if (disasters == null)
            {
                return NotFound();
            }

            return View(disasters);
        }

        // GET: Disasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisasterId,Start,End,Location,Description,AidTypes")] Disasters disasters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disasters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disasters);
        }

        // GET: Disasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disasters = await _context.Disasters.FindAsync(id);
            if (disasters == null)
            {
                return NotFound();
            }
            return View(disasters);
        }

        // POST: Disasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisasterId,Start,End,Location,Description,AidTypes")] Disasters disasters)
        {
            if (id != disasters.DisasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disasters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisastersExists(disasters.DisasterId))
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
            return View(disasters);
        }

        // GET: Disasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disasters == null)
            {
                return NotFound();
            }

            var disasters = await _context.Disasters
                .FirstOrDefaultAsync(m => m.DisasterId == id);
            if (disasters == null)
            {
                return NotFound();
            }

            return View(disasters);
        }

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disasters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Disasters'  is null.");
            }
            var disasters = await _context.Disasters.FindAsync(id);
            if (disasters != null)
            {
                _context.Disasters.Remove(disasters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisastersExists(int id)
        {
          return (_context.Disasters?.Any(e => e.DisasterId == id)).GetValueOrDefault();
        }
    }
}
