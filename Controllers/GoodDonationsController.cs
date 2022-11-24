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
    public class GoodDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodDonations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GoodDonations.Include(g => g.Catergory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GoodDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoodDonations == null)
            {
                return NotFound();
            }

            var goodDonations = await _context.GoodDonations
                .Include(g => g.Catergory)
                .FirstOrDefaultAsync(m => m.GoodDonationId == id);
            if (goodDonations == null)
            {
                return NotFound();
            }

            return View(goodDonations);
        }

        // GET: GoodDonations/Create
        public IActionResult Create()
        {
            ViewData["CatergoryId"] = new SelectList(_context.Catergories, "CatergoryId", "Name");
            return View();
        }

        // POST: GoodDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodDonationId,NumberOfItems,Date,Description,Donor,CatergoryId")] GoodDonations goodDonations)
        {
            ModelState.Remove("Catergory"); // This will remove the key 

            if (ModelState.IsValid)
            {
                _context.Add(goodDonations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatergoryId"] = new SelectList(_context.Catergories, "CatergoryId", "Name", goodDonations.CatergoryId);
            return View(goodDonations);
        }

        // GET: GoodDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoodDonations == null)
            {
                return NotFound();
            }

            var goodDonations = await _context.GoodDonations.FindAsync(id);
            if (goodDonations == null)
            {
                return NotFound();
            }
            ViewData["CatergoryId"] = new SelectList(_context.Catergories, "CatergoryId", "Name", goodDonations.CatergoryId);
            return View(goodDonations);
        }

        // POST: GoodDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodDonationId,NumberOfItems,Date,Description,Donor,CatergoryId")] GoodDonations goodDonations)
        {
            if (id != goodDonations.GoodDonationId)
            {
                return NotFound();
            }

            ModelState.Remove("Catergory"); // This will remove the key 

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodDonations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodDonationsExists(goodDonations.GoodDonationId))
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
            ViewData["CatergoryId"] = new SelectList(_context.Catergories, "CatergoryId", "Name", goodDonations.CatergoryId);
            return View(goodDonations);
        }

        // GET: GoodDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoodDonations == null)
            {
                return NotFound();
            }

            var goodDonations = await _context.GoodDonations
                .Include(g => g.Catergory)
                .FirstOrDefaultAsync(m => m.GoodDonationId == id);
            if (goodDonations == null)
            {
                return NotFound();
            }

            return View(goodDonations);
        }

        // POST: GoodDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoodDonations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GoodDonations'  is null.");
            }
            var goodDonations = await _context.GoodDonations.FindAsync(id);
            if (goodDonations != null)
            {
                _context.GoodDonations.Remove(goodDonations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodDonationsExists(int id)
        {
          return (_context.GoodDonations?.Any(e => e.GoodDonationId == id)).GetValueOrDefault();
        }
    }
}
