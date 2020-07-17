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
    public class HomesController : Controller
    {
        private readonly MatureFashions2Context _context;

        public HomesController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Homes
        public async Task<IActionResult> Index()
        {
            var matureFashions2Context = _context.Homes.Include(h => h.HometypeCodeNavigation);
            return View(await matureFashions2Context.ToListAsync());
        }

        // GET: Homes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homes = await _context.Homes
                .Include(h => h.HometypeCodeNavigation)
                .FirstOrDefaultAsync(m => m.HomeNo == id);
            if (homes == null)
            {
                return NotFound();
            }

            return View(homes);
        }

        // GET: Homes/Create
        public IActionResult Create()
        {
            ViewData["HometypeCode"] = new SelectList(_context.Hometypes, "HometypeCode", "HometypeCode");
            return View();
        }

        // POST: Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeNo,HomeName,HometypeCode,HomeAddress,HomePostcode,HomeTel")] Homes homes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HometypeCode"] = new SelectList(_context.Hometypes, "HometypeCode", "HometypeCode", homes.HometypeCode);
            return View(homes);
        }

        // GET: Homes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homes = await _context.Homes.FindAsync(id);
            if (homes == null)
            {
                return NotFound();
            }
            ViewData["HometypeCode"] = new SelectList(_context.Hometypes, "HometypeCode", "HometypeCode", homes.HometypeCode);
            return View(homes);
        }

        // POST: Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HomeNo,HomeName,HometypeCode,HomeAddress,HomePostcode,HomeTel")] Homes homes)
        {
            if (id != homes.HomeNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomesExists(homes.HomeNo))
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
            ViewData["HometypeCode"] = new SelectList(_context.Hometypes, "HometypeCode", "HometypeCode", homes.HometypeCode);
            return View(homes);
        }

        // GET: Homes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homes = await _context.Homes
                .Include(h => h.HometypeCodeNavigation)
                .FirstOrDefaultAsync(m => m.HomeNo == id);
            if (homes == null)
            {
                return NotFound();
            }

            return View(homes);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homes = await _context.Homes.FindAsync(id);
            _context.Homes.Remove(homes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomesExists(int id)
        {
            return _context.Homes.Any(e => e.HomeNo == id);
        }
    }
}
