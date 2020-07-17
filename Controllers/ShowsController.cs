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
    public class ShowsController : Controller
    {
        private readonly MatureFashions2Context _context;

        public ShowsController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var matureFashions2Context = _context.Shows.Include(s => s.FranchiseNoNavigation).Include(s => s.HomeNoNavigation);
            return View(await matureFashions2Context.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows
                .Include(s => s.FranchiseNoNavigation)
                .Include(s => s.HomeNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (shows == null)
            {
                return NotFound();
            }

            return View(shows);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo");
            ViewData["HomeNo"] = new SelectList(_context.Homes, "HomeNo", "HomeAddress");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseNo,HomeNo,ShowDate,ShowTime,ShowTotalSale")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shows);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", shows.FranchiseNo);
            ViewData["HomeNo"] = new SelectList(_context.Homes, "HomeNo", "HomeAddress", shows.HomeNo);
            return View(shows);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows.FindAsync(id);
            if (shows == null)
            {
                return NotFound();
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", shows.FranchiseNo);
            ViewData["HomeNo"] = new SelectList(_context.Homes, "HomeNo", "HomeAddress", shows.HomeNo);
            return View(shows);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchiseNo,HomeNo,ShowDate,ShowTime,ShowTotalSale")] Shows shows)
        {
            if (id != shows.FranchiseNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shows);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowsExists(shows.FranchiseNo))
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
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", shows.FranchiseNo);
            ViewData["HomeNo"] = new SelectList(_context.Homes, "HomeNo", "HomeAddress", shows.HomeNo);
            return View(shows);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows
                .Include(s => s.FranchiseNoNavigation)
                .Include(s => s.HomeNoNavigation)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (shows == null)
            {
                return NotFound();
            }

            return View(shows);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var shows = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(shows);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowsExists(string id)
        {
            return _context.Shows.Any(e => e.FranchiseNo == id);
        }
    }
}
