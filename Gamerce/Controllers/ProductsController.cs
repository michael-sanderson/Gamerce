using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gamerce.Data;
using Gamerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Gamerce.Controllers
{

    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder)
        {
            //ViewBag.DateSortParam = sortOrder == "date" ? "date_desc" : "date";

            //ViewBag.CurrentSort = sortOrder;

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem);

            //switch (sortOrder)
            //{
            //    case "date":
            //        applicationDbContext = applicationDbContext.OrderBy(x => x.PostingDate);
            //        break;

            return View(await applicationDbContext.ToListAsync());

            //}
        }

        // GET: Products by search string
        public async Task<IActionResult> ProductsBySearch(string searchString, string sortOrder)
        {

            // ViewData["currentSearchKey"] = searchString;                  
            if (!string.IsNullOrEmpty(searchString))
            {
                var products = (from c in _context.Products.Include(c => c.Genre).Include(c => c.GameSystem)
                .Include(c => c.SaleStatus).Include(c => c.Condition)
                                join u in _userManager.Users on c.ProductUserName equals u.UserName
                                where (u.PostCode.Equals(searchString) ||
                                c.Title.Contains(searchString) ||
                                c.Genre.ProductGenre.Contains(searchString) ||
                                c.ProductDescription.Contains(searchString))
                                select c).ToListAsync();

                return View("Index", await products);

            }

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        [Authorize]
        // GET: My Products
        public async Task<IActionResult> MyProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.ProductUserName == _userManager.GetUserName(User));
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: New Products
        public async Task<IActionResult> NewProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.Condition.ProductCondition == "New");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PS4 Products
        public async Task<IActionResult> PS4Products()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "PS4");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PC Products
        public async Task<IActionResult> PCProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "PC");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PS Vita Products
        public async Task<IActionResult> PSVitaProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "PS Vita");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PS3 Products
        public async Task<IActionResult> PS3Products()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "PS3");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: XBOX One Products
        public async Task<IActionResult> XboxOneProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "XBOX One");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: XBOX 360 Products
        public async Task<IActionResult> Xbox360Products()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "XBOX 360");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Used Products
        public async Task<IActionResult> UsedProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.Condition.ProductCondition == "Used");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nintendo Switch Products 
        public async Task<IActionResult> NintendoSwitchProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "Nintendo Switch");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nintendo 3DS Products 
        public async Task<IActionResult> Nintendo3DSProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "Nintendo 3DS");
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nintendo Wii U Products 
        public async Task<IActionResult> NintendoWiiUProducts()
        {

            var applicationDbContext = _context.Products.Include(p => p.Condition).Include(p => p.Genre).Include(p => p.SaleStatus)
                                       .Include(p => p.GameSystem).Where(x => x.GameSystem.ProductSystem == "Nintendo Wii U");
            return View(await applicationDbContext.ToListAsync());
        }


        //GET: Products/Details/5
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
        [Authorize]
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
        public async Task<IActionResult> Create([Bind("ProductID,Title,ProductDescription,Price,GenreID,SaleStatusID,ConditionID,GameSystemID,UserID,PostingDate,ProductUserName")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.UserID = _userManager.GetUserId(User);
                product.ProductUserName = _userManager.GetUserName(User);
                product.PostingDate = DateTime.Today.Date;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyProducts));
            }
            ViewData["ConditionID"] = new SelectList(_context.Conditions, "ConditionID", "ProductCondition", product.ConditionID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "ProductGenre", product.GenreID);
            ViewData["SaleStatusID"] = new SelectList(_context.SaleStatuses, "SaleStatusID", "ProductSaleStatus", product.SaleStatusID);
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "ProductSystem", product.GameSystemID);

            return View(product);
        }
        [Authorize]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var checkUser = (from p in _context.Products where p.ProductID == id select p.ProductUserName);

            if (checkUser.First() == _userManager.GetUserName(User))
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
            else { return NotFound(); }
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Title,ProductDescription,Price,GenreID,SaleStatusID,ConditionID,GameSystemID,UserID,PostingDate,ProductUserName")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.ProductUserName = _userManager.GetUserName(User);
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
                return RedirectToAction(nameof(MyProducts));
            }
            ViewData["ConditionID"] = new SelectList(_context.Conditions, "ConditionID", "ProductCondition", product.ConditionID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "ProductGenre", product.GenreID);
            ViewData["SaleStatusID"] = new SelectList(_context.SaleStatuses, "SaleStatusID", "ProductSaleStatus", product.SaleStatusID);
            ViewData["GameSystemID"] = new SelectList(_context.GameSystems, "GameSystemID", "ProductSystem", product.GameSystemID);
            return View(product);
        }

        [Authorize]
        // POST: Products/Buy/
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(int id)
        {
           // Product product = (from p in _context.Products where p.ProductID == id select p).First();
           Product product = await _context.Products
                .Include(p => p.SaleStatus)
                .SingleOrDefaultAsync(m => m.ProductID == id);

            SaleStatus Sold = await _context.SaleStatuses.SingleOrDefaultAsync(p => p.ProductSaleStatus == "Sold");        

            try
            {
                product.SaleStatus = Sold;
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
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [Authorize]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var checkUser = (from p in _context.Products where p.ProductID == id select p.ProductUserName);

            if (checkUser.First() == _userManager.GetUserName(User))
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
            else { return NotFound(); }
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