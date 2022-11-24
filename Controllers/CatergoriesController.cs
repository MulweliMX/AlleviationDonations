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
    public class CatergoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatergoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catergories
        public async Task<IActionResult> Index()
        {
              return _context.Catergories != null ? 
                          View(await _context.Catergories.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Catergories'  is null.");
        }

        // GET: Catergories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catergories == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergories
                .FirstOrDefaultAsync(m => m.CatergoryId == id);
            if (catergory == null)
            {
                return NotFound();
            }

            return View(catergory);
        }

        // GET: Catergories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catergories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatergoryId,Name,Description,Date")] Catergory catergory)
        {
            ModelState.Remove("Goods"); // This will remove the key 

            if (ModelState.IsValid)
            {
                _context.Add(catergory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catergory);
        }

        // GET: Catergories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catergories == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergories.FindAsync(id);
            if (catergory == null)
            {
                return NotFound();
            }
            return View(catergory);
        }

        // POST: Catergories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatergoryId,Name,Description,Date")] Catergory catergory)
        {
            if (id != catergory.CatergoryId)
            {
                return NotFound();
            }

            ModelState.Remove("Goods"); // This will remove the key 

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catergory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatergoryExists(catergory.CatergoryId))
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
            return View(catergory);
        }

        // GET: Catergories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catergories == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergories
                .FirstOrDefaultAsync(m => m.CatergoryId == id);
            if (catergory == null)
            {
                return NotFound();
            }

            return View(catergory);
        }

        // POST: Catergories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catergories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Catergories'  is null.");
            }
            var catergory = await _context.Catergories.FindAsync(id);
            if (catergory != null)
            {
                _context.Catergories.Remove(catergory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatergoryExists(int id)
        {
          return (_context.Catergories?.Any(e => e.CatergoryId == id)).GetValueOrDefault();
        }
    }
}
