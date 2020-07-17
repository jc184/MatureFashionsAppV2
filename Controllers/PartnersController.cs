using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatureFashionsAppV2.Models.DB;

namespace MatureFashionsAppV2.Controllers
{
    public class PartnersController : Controller
    {
        private readonly MatureFashions2Context _context;

        public PartnersController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Partners
        public async Task<IActionResult> Index()
        {
            var matureFashions2Context = _context.Partners.Include(p => p.FranchiseNoNavigation);
            return View(await matureFashions2Context.ToListAsync());
        }

        // GET: Partners/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partners = await _context.Partners
                .Include(p => p.FranchiseNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (partners == null)
            {
                return NotFound();
            }

            return View(partners);
        }

        // GET: Partners/Create
        public IActionResult Create()
        {
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo");
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseNo,PartnerName")] Partners partners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", partners.FranchiseNo);
            return View(partners);
        }

        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partners = await _context.Partners.FindAsync(id);
            if (partners == null)
            {
                return NotFound();
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", partners.FranchiseNo);
            return View(partners);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchiseNo,PartnerName")] Partners partners)
        {
            if (id != partners.FranchiseNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnersExists(partners.FranchiseNo))
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
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", partners.FranchiseNo);
            return View(partners);
        }

        // GET: Partners/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partners = await _context.Partners
                .Include(p => p.FranchiseNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (partners == null)
            {
                return NotFound();
            }

            return View(partners);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var partners = await _context.Partners.FindAsync(id);
            _context.Partners.Remove(partners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnersExists(string id)
        {
            return _context.Partners.Any(e => e.FranchiseNo == id);
        }
    }
}
