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
    public class InvoicesController : Controller
    {
        private readonly MatureFashions2Context _context;

        public InvoicesController(MatureFashions2Context context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var matureFashions2Context = _context.Invoices.Include(i => i.FranchiseNoNavigation).Include(i => i.OrderNoNavigation);
            return View(await matureFashions2Context.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices
                .Include(i => i.FranchiseNoNavigation)
                .Include(i => i.OrderNoNavigation)
                .FirstOrDefaultAsync(m => m.InvoiceNo == id);
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo");
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceNo,InvoiceDate,InvoiceDateDue,InvoiceNet,FranchiseNo,OrderNo")] Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", invoices.FranchiseNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", invoices.OrderNo);
            return View(invoices);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices.FindAsync(id);
            if (invoices == null)
            {
                return NotFound();
            }
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", invoices.FranchiseNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", invoices.OrderNo);
            return View(invoices);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("InvoiceNo,InvoiceDate,InvoiceDateDue,InvoiceNet,FranchiseNo,OrderNo")] Invoices invoices)
        {
            if (id != invoices.InvoiceNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicesExists(invoices.InvoiceNo))
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
            ViewData["FranchiseNo"] = new SelectList(_context.Franchises, "FranchiseNo", "FranchiseNo", invoices.FranchiseNo);
            ViewData["OrderNo"] = new SelectList(_context.Orders, "OrderNo", "OrderNo", invoices.OrderNo);
            return View(invoices);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices
                .Include(i => i.FranchiseNoNavigation)
                .Include(i => i.OrderNoNavigation)
                .FirstOrDefaultAsync(m => m.InvoiceNo == id);
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var invoices = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoicesExists(string id)
        {
            return _context.Invoices.Any(e => e.InvoiceNo == id);
        }
    }
}
