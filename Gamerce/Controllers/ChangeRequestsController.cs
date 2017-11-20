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
    [Authorize]
    public class ChangeRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangeRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ChangeRequests
        public async Task<IActionResult> AllRequests()
        {
            var applicationDbContext = _context.ChangeRequests.Include(c => c.Priority).Include(c => c.Status);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ChangeRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChangeRequests.Include(c => c.Priority).Include(c => c.Status).Where
            (x => x.OwnerID == _userManager.GetUserId(User));

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ChangeRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //linq Query
            ViewBag.OwnerName = (from user in _context.Users
                                 join change in _context.ChangeRequests
                                 on user.Id equals change.OwnerID
                                 where change.ChangeRequestID == id
                                 select user.Email).First();
                
            var changeRequest = await _context.ChangeRequests
                .Include(c => c.Priority)
                .Include(c => c.Status)
                .SingleOrDefaultAsync(m => m.ChangeRequestID == id);
            if (changeRequest == null)
            {
                return NotFound();
            }

            return View(changeRequest);
        }

        // GET: ChangeRequests/Create
        public IActionResult Create()
        {
            ViewData["PriorityID"] = new SelectList(_context.Priorities, "PriorityID", "PriorityLevel");
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "RequestStatus");
            return View();
        }

        // POST: ChangeRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChangeRequestID,Title,BriefDescription,DateOfRequest,RequiredBy,PriorityID,StatusID")] ChangeRequest changeRequest)
        {
            if (ModelState.IsValid)
            {
                changeRequest.OwnerID = _userManager.GetUserId(User);
                _context.Add(changeRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriorityID"] = new SelectList(_context.Priorities, "PriorityID", "PriorityLevel", changeRequest.PriorityID);
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "RequestStatus", changeRequest.StatusID);
            return View(changeRequest);
        }

        // GET: ChangeRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeRequest = await _context.ChangeRequests.SingleOrDefaultAsync(m => m.ChangeRequestID == id);
            if (changeRequest == null)
            {
                return NotFound();
            }
            ViewData["PriorityID"] = new SelectList(_context.Priorities, "PriorityID", "PriorityLevel", changeRequest.PriorityID);
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "RequestStatus", changeRequest.StatusID);
            return View(changeRequest);
        }

        // POST: ChangeRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChangeRequestID,Title,BriefDescription,DateOfRequest,RequiredBy,PriorityID,StatusID")] ChangeRequest changeRequest)
        {
            if (id != changeRequest.ChangeRequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    changeRequest.OwnerID = _userManager.GetUserId(User);
                    _context.Update(changeRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangeRequestExists(changeRequest.ChangeRequestID))
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
            ViewData["PriorityID"] = new SelectList(_context.Priorities, "PriorityID", "PriorityLevel", changeRequest.PriorityID);
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "RequestStatus", changeRequest.StatusID);
            return View(changeRequest);
        }

        // GET: ChangeRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeRequest = await _context.ChangeRequests
                .Include(c => c.Priority)
                .Include(c => c.Status)
                .SingleOrDefaultAsync(m => m.ChangeRequestID == id);
            if (changeRequest == null)
            {
                return NotFound();
            }

            return View(changeRequest);
        }

        // POST: ChangeRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var changeRequest = await _context.ChangeRequests.SingleOrDefaultAsync(m => m.ChangeRequestID == id);
            _context.ChangeRequests.Remove(changeRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChangeRequestExists(int id)
        {
            return _context.ChangeRequests.Any(e => e.ChangeRequestID == id);
        }
    }
}
