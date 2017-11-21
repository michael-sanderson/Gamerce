using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gamerce.Data;
using Gamerce.Models;

namespace Gamerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus).Include(p => p.GameSystem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Condition)
                .Include(p => p.Genre)
                .Include(p => p.SaleStatus)
                .Include(p => p.GameSystem)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ConditionID"] = new SelectList(_context.Conditions, "ConditionID", "ProductCondition");
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "ProductGenre");
            ViewData["SaleStatusID"] = new SelectList(_context.SaleStatuses, "SaleStatusID", "ProductSaleStatus");
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "ProductSystem");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Title,ProductDescription,Price,GenreID,SaleStatusID,ConditionID,GameSystemID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionID"] = new SelectList(_context.Conditions, "ConditionID", "ProductCondition", product.ConditionID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "ProductGenre", product.GenreID);
            ViewData["SaleStatusID"] = new SelectList(_context.SaleStatuses, "SaleStatusID", "ProductSaleStatus", product.SaleStatusID);
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "ProductSystem", product.GameSystemID);

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ConditionID"] = new SelectList(_context.Conditions, "ConditionID", "ProductCondition", product.ConditionID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "ProductGenre", product.GenreID);
            ViewData["SaleStatusID"] = new SelectList(_context.SaleStatuses, "SaleStatusID", "ProductSaleStatus", product.SaleStatusID);
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "ProductSystem", product.GameSystemID);

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Title,ProductDescription,Price,GenreID,SaleStatusID,ConditionID,GameSystemID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["ConditionID"] = new SelectList(_context.Conditions, "ConditionID", "ProductCondition", product.ConditionID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "ProductGenre", product.GenreID);
            ViewData["SaleStatusID"] = new SelectList(_context.SaleStatuses, "SaleStatusID", "ProductSaleStatus", product.SaleStatusID);
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "ProductSystem", product.GameSystemID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Condition)
                .Include(p => p.Genre)
                .Include(p => p.SaleStatus)
                .Include(p => p.GameSystem)
                .SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
