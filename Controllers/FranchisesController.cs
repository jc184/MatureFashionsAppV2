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
    public class FranchisesController : Controller
    {
        private readonly MatureFashions2Context _context;

        public FranchisesController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Franchises
        public async Task<IActionResult> Index()
        {
            var matureFashions2Context = _context.Franchises.Include(f => f.FranchisorNoNavigation);
            return View(await matureFashions2Context.ToListAsync());
        }

        // GET: Franchises/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchises = await _context.Franchises
                .Include(f => f.FranchisorNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (franchises == null)
            {
                return NotFound();
            }

            return View(franchises);
        }

        // GET: Franchises/Create
        public IActionResult Create()
        {
            ViewData["FranchisorNo"] = new SelectList(_context.Franchisors, "FranchisorNo", "FranchisorNo");
            return View();
        }

        // POST: Franchises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseNo,FranchiseName,FranchiseAddress,FranchisePostcode,FranchiseTel,FranchiseFax,FranchiseStartdate,FranchisorNo")] Franchises franchises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchisorNo"] = new SelectList(_context.Franchisors, "FranchisorNo", "FranchisorNo", franchises.FranchisorNo);
            return View(franchises);
        }

        // GET: Franchises/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchises = await _context.Franchises.FindAsync(id);
            if (franchises == null)
            {
                return NotFound();
            }
            ViewData["FranchisorNo"] = new SelectList(_context.Franchisors, "FranchisorNo", "FranchisorNo", franchises.FranchisorNo);
            return View(franchises);
        }

        // POST: Franchises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchiseNo,FranchiseName,FranchiseAddress,FranchisePostcode,FranchiseTel,FranchiseFax,FranchiseStartdate,FranchisorNo")] Franchises franchises)
        {
            if (id != franchises.FranchiseNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchisesExists(franchises.FranchiseNo))
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
            ViewData["FranchisorNo"] = new SelectList(_context.Franchisors, "FranchisorNo", "FranchisorNo", franchises.FranchisorNo);
            return View(franchises);
        }

        // GET: Franchises/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchises = await _context.Franchises
                .Include(f => f.FranchisorNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (franchises == null)
            {
                return NotFound();
            }

            return View(franchises);
        }

        // POST: Franchises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var franchises = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchisesExists(string id)
        {
            return _context.Franchises.Any(e => e.FranchiseNo == id);
        }
    }
}
