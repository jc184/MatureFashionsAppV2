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
    public class PostcodesController : Controller
    {
        private readonly MatureFashions2Context _context;

        public PostcodesController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Postcodes
        public async Task<IActionResult> Index()
        {
            var matureFashions2Context = _context.Postcodes.Include(p => p.FranchiseNoNavigation);
            return View(await matureFashions2Context.ToListAsync());
        }

        // GET: Postcodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcodes = await _context.Postcodes
                .Include(p => p.FranchiseNoNavigation)
                .FirstOrDefaultAsync(m => m.PostcodeArea == id);
            if (postcodes == null)
            {
                return NotFound();
            }

            return View(postcodes);
        }

        // GET: Postcodes/Create
        public IActionResult Create()
        {
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo");
            return View();
        }

        // POST: Postcodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostcodeArea,PostcodeName,FranchiseNo")] Postcodes postcodes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postcodes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", postcodes.FranchiseNo);
            return View(postcodes);
        }

        // GET: Postcodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcodes = await _context.Postcodes.FindAsync(id);
            if (postcodes == null)
            {
                return NotFound();
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", postcodes.FranchiseNo);
            return View(postcodes);
        }

        // POST: Postcodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PostcodeArea,PostcodeName,FranchiseNo")] Postcodes postcodes)
        {
            if (id != postcodes.PostcodeArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postcodes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostcodesExists(postcodes.PostcodeArea))
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
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", postcodes.FranchiseNo);
            return View(postcodes);
        }

        // GET: Postcodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcodes = await _context.Postcodes
                .Include(p => p.FranchiseNoNavigation)
                .FirstOrDefaultAsync(m => m.PostcodeArea == id);
            if (postcodes == null)
            {
                return NotFound();
            }

            return View(postcodes);
        }

        // POST: Postcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var postcodes = await _context.Postcodes.FindAsync(id);
            _context.Postcodes.Remove(postcodes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostcodesExists(string id)
        {
            return _context.Postcodes.Any(e => e.PostcodeArea == id);
        }
    }
}
