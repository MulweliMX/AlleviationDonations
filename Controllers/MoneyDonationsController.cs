﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;

namespace DisasterAlleviationFoundation.Controllers
{
    public class MoneyDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoneyDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoneyDonations
        public async Task<IActionResult> Index()
        {
              return _context.MoneyDonations != null ? 
                          View(await _context.MoneyDonations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MoneyDonations'  is null.");
        }

        // GET: MoneyDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MoneyDonations == null)
            {
                return NotFound();
            }

            var moneyDonations = await _context.MoneyDonations
                .FirstOrDefaultAsync(m => m.MonetaryDonationId == id);
            if (moneyDonations == null)
            {
                return NotFound();
            }

            return View(moneyDonations);
        }

        // GET: MoneyDonations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoneyDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonetaryDonationId,Date,Amount,DonorName")] MoneyDonations moneyDonations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneyDonations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moneyDonations);
        }

        // GET: MoneyDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MoneyDonations == null)
            {
                return NotFound();
            }

            var moneyDonations = await _context.MoneyDonations.FindAsync(id);
            if (moneyDonations == null)
            {
                return NotFound();
            }
            return View(moneyDonations);
        }

        // POST: MoneyDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonetaryDonationId,Date,Amount,DonorName")] MoneyDonations moneyDonations)
        {
            if (id != moneyDonations.MonetaryDonationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneyDonations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyDonationsExists(moneyDonations.MonetaryDonationId))
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
            return View(moneyDonations);
        }

        // GET: MoneyDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MoneyDonations == null)
            {
                return NotFound();
            }

            var moneyDonations = await _context.MoneyDonations
                .FirstOrDefaultAsync(m => m.MonetaryDonationId == id);
            if (moneyDonations == null)
            {
                return NotFound();
            }

            return View(moneyDonations);
        }

        // POST: MoneyDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MoneyDonations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MoneyDonations'  is null.");
            }
            var moneyDonations = await _context.MoneyDonations.FindAsync(id);
            if (moneyDonations != null)
            {
                _context.MoneyDonations.Remove(moneyDonations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoneyDonationsExists(int id)
        {
          return (_context.MoneyDonations?.Any(e => e.MonetaryDonationId == id)).GetValueOrDefault();
        }
    }
}
