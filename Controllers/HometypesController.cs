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
    public class HometypesController : Controller
    {
        private readonly MatureFashions2Context _context;

        public HometypesController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Hometypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hometypes.ToListAsync());
        }

        // GET: Hometypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometypes = await _context.Hometypes
                .FirstOrDefaultAsync(m => m.HometypeCode == id);
            if (hometypes == null)
            {
                return NotFound();
            }

            return View(hometypes);
        }

        // GET: Hometypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hometypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HometypeCode,HometypeDescription")] Hometypes hometypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hometypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hometypes);
        }

        // GET: Hometypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometypes = await _context.Hometypes.FindAsync(id);
            if (hometypes == null)
            {
                return NotFound();
            }
            return View(hometypes);
        }

        // POST: Hometypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HometypeCode,HometypeDescription")] Hometypes hometypes)
        {
            if (id != hometypes.HometypeCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hometypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HometypesExists(hometypes.HometypeCode))
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
            return View(hometypes);
        }

        // GET: Hometypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hometypes = await _context.Hometypes
                .FirstOrDefaultAsync(m => m.HometypeCode == id);
            if (hometypes == null)
            {
                return NotFound();
            }

            return View(hometypes);
        }

        // POST: Hometypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hometypes = await _context.Hometypes.FindAsync(id);
            _context.Hometypes.Remove(hometypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HometypesExists(string id)
        {
            return _context.Hometypes.Any(e => e.HometypeCode == id);
        }
    }
}
