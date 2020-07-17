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
    public class OrderlinesController : Controller
    {
        private readonly MatureFashions2Context _context;

        public OrderlinesController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Orderlines
        public async Task<IActionResult> Index()
        {
            var matureFashions2Context = _context.Orderlines.Include(o => o.ItemNoNavigation).Include(o => o.OrderNoNavigation);
            return View(await matureFashions2Context.ToListAsync());
        }

        // GET: Orderlines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderlines = await _context.Orderlines
                .Include(o => o.ItemNoNavigation)
                .Include(o => o.OrderNoNavigation)
                .FirstOrDefaultAsync(m => m.OrderNo == id);
            if (orderlines == null)
            {
                return NotFound();
            }

            return View(orderlines);
        }

        // GET: Orderlines/Create
        public IActionResult Create()
        {
            ViewData["ItemNo"] = new SelectList(_context.Items, "ItemNo", "ItemNo");
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo");
            return View();
        }

        // POST: Orderlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderNo,ItemNo,OrderQuantity")] Orderlines orderlines)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderlines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemNo"] = new SelectList(_context.Items, "ItemNo", "ItemNo", orderlines.ItemNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", orderlines.OrderNo);
            return View(orderlines);
        }

        // GET: Orderlines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderlines = await _context.Orderlines.FindAsync(id);
            if (orderlines == null)
            {
                return NotFound();
            }
            ViewData["ItemNo"] = new SelectList(_context.Items, "ItemNo", "ItemNo", orderlines.ItemNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", orderlines.OrderNo);
            return View(orderlines);
        }

        // POST: Orderlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderNo,ItemNo,OrderQuantity")] Orderlines orderlines)
        {
            if (id != orderlines.OrderNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderlines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderlinesExists(orderlines.OrderNo))
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
            ViewData["ItemNo"] = new SelectList(_context.Items, "ItemNo", "ItemNo", orderlines.ItemNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", orderlines.OrderNo);
            return View(orderlines);
        }

        // GET: Orderlines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderlines = await _context.Orderlines
                .Include(o => o.ItemNoNavigation)
                .Include(o => o.OrderNoNavigation)
                .FirstOrDefaultAsync(m => m.OrderNo == id);
            if (orderlines == null)
            {
                return NotFound();
            }

            return View(orderlines);
        }

        // POST: Orderlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var orderlines = await _context.Orderlines.FindAsync(id);
            _context.Orderlines.Remove(orderlines);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderlinesExists(string id)
        {
            return _context.Orderlines.Any(e => e.OrderNo == id);
        }
    }
}
