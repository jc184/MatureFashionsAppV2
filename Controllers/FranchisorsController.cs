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
    public class FranchisorsController : Controller
    {
        private readonly MatureFashions2Context _context;

        public FranchisorsController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Franchisors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Franchisors.ToListAsync());
        }

        // GET: Franchisors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchisors = await _context.Franchisors
                .FirstOrDefaultAsync(m => m.FranchisorNo == id);
            if (franchisors == null)
            {
                return NotFound();
            }

            return View(franchisors);
        }

        // GET: Franchisors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Franchisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchisorNo,FranchisorName,FranchisorAddress,FranchisorPostcode,FranchisorTel,FranchisorFax")] Franchisors franchisors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchisors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(franchisors);
        }

        // GET: Franchisors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchisors = await _context.Franchisors.FindAsync(id);
            if (franchisors == null)
            {
                return NotFound();
            }
            return View(franchisors);
        }

        // POST: Franchisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchisorNo,FranchisorName,FranchisorAddress,FranchisorPostcode,FranchisorTel,FranchisorFax")] Franchisors franchisors)
        {
            if (id != franchisors.FranchisorNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchisors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchisorsExists(franchisors.FranchisorNo))
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
            return View(franchisors);
        }

        // GET: Franchisors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var franchisors = await _context.Franchisors
                .FirstOrDefaultAsync(m => m.FranchisorNo == id);
            if (franchisors == null)
            {
                return NotFound();
            }

            return View(franchisors);
        }

        // POST: Franchisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var franchisors = await _context.Franchisors.FindAsync(id);
            _context.Franchisors.Remove(franchisors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchisorsExists(string id)
        {
            return _context.Franchisors.Any(e => e.FranchisorNo == id);
        }
    }
}
