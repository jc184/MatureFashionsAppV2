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
    public class SaleitemsController : Controller
    {
        private readonly MatureFashions2Context _context;

        public SaleitemsController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Saleitems
        public async Task<IActionResult> Index()
        {
            var matureFashions2Context = _context.Saleitems.Include(s => s.ItemNoNavigation).Include(s => s.Shows);
            return View(await matureFashions2Context.ToListAsync());
        }

        // GET: Saleitems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleitems = await _context.Saleitems
                .Include(s => s.ItemNoNavigation)
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (saleitems == null)
            {
                return NotFound();
            }

            return View(saleitems);
        }

        // GET: Saleitems/Create
        public IActionResult Create()
        {
            ViewData["ItemNo"] = new SelectList(_context.Items, "ItemNo", "ItemNo");
            ViewData["FranchiseNo"] = new SelectList(_context.Shows, "FranchiseNo", "FranchiseNo");
            return View();
        }

        // POST: Saleitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FranchiseNo,HomeNo,ShowDate,ItemNo,SaleQuantity")] Saleitems saleitems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleitems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemNo"] = new SelectList(_context.Items, "ItemNo", "ItemNo", saleitems.ItemNo);
            ViewData["FranchiseNo"] = new SelectList(_context.Shows, "FranchiseNo", "FranchiseNo", saleitems.FranchiseNo);
            return View(saleitems);
        }

        // GET: Saleitems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleitems = await _context.Saleitems.FindAsync(id);
            if (saleitems == null)
            {
                return NotFound();
            }
            ViewData["ItemNo"] = new SelectList(_context.Items, "ItemNo", "ItemNo", saleitems.ItemNo);
            ViewData["FranchiseNo"] = new SelectList(_context.Shows, "FranchiseNo", "FranchiseNo", saleitems.FranchiseNo);
            return View(saleitems);
        }

        // POST: Saleitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FranchiseNo,HomeNo,ShowDate,ItemNo,SaleQuantity")] Saleitems saleitems)
        {
            if (id != saleitems.FranchiseNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleitems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleitemsExists(saleitems.FranchiseNo))
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
            ViewData["ItemNo"] = new SelectList(_context.Items, "ItemNo", "ItemNo", saleitems.ItemNo);
            ViewData["FranchiseNo"] = new SelectList(_context.Shows, "FranchiseNo", "FranchiseNo", saleitems.FranchiseNo);
            return View(saleitems);
        }

        // GET: Saleitems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleitems = await _context.Saleitems
                .Include(s => s.ItemNoNavigation)
                .Include(s => s.Shows)
                .FirstOrDefaultAsync(m => m.FranchiseNo == id);
            if (saleitems == null)
            {
                return NotFound();
            }

            return View(saleitems);
        }

        // POST: Saleitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var saleitems = await _context.Saleitems.FindAsync(id);
            _context.Saleitems.Remove(saleitems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleitemsExists(string id)
        {
            return _context.Saleitems.Any(e => e.FranchiseNo == id);
        }
    }
}
