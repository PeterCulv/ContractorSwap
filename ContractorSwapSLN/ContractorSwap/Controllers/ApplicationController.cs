using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContractorSwap.Data;
using ContractorSwap.Models;
using System.Linq.Expressions;

namespace ContractorSwap.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly DataContext _context;

        public ApplicationController(DataContext context)
        {
            _context = context;
        }

        // GET: Application
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Applications.Include(a => a.Contractor);
            return View(await dataContext.ToListAsync());
        }
        public async Task<IActionResult> MyIndex()
        {
            string userName = Request.Cookies["UserCookie"];
            string password = Request.Cookies["PasswordCookie"];
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var applications = await _context.Applications.Include(a=>a.JobListing).Include(a => a.Contractor).Where(x => x.Contractor.UserName == userName && x.Contractor.Password == password).ToListAsync(); ;
            return View(applications);

            }
            else
            {
                // Redirect or display an error message if the cookies are not set
                return RedirectToAction("Register", "Contractor"); // Replace with appropriate action and controller names
            }

        }

        // GET: Application/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Applications == null)
            {
                return NotFound();
            }

            var applicationModel = await _context.Applications
                .Include(a => a.Contractor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationModel == null)
            {
                return NotFound();
            }

            return View(applicationModel);
        }

        // GET: Application/Create
        public IActionResult Create(int jobListingId)
        {
            ApplicationModel app = new ApplicationModel();
            app.JobListingId = jobListingId;
            return View();
        }

        // POST: Application/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationModel applicationModel)
        {
            if (ModelState.IsValid)
            {
                string userName = Request.Cookies["UserCookie"];
                string password = Request.Cookies["PasswordCookie"];
                ContractorModel contractor = new ContractorModel();
                contractor = _context.Contractors.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
                applicationModel.ContractorId = contractor.Id;
               
                
                _context.Applications.Add(applicationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyIndex));
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "Id", "Location", applicationModel.ContractorId);
            return View(applicationModel);
        }

        // GET: Application/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Applications == null)
            {
                return NotFound();
            }

            var applicationModel = await _context.Applications.FindAsync(id);
            if (applicationModel == null)
            {
                return NotFound();
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "Id", "Location", applicationModel.ContractorId);
            return View(applicationModel);
        }

        // POST: Application/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicationModel applicationModel)
        {
            if (id != applicationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationModelExists(applicationModel.Id))
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
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "Id", "Location", applicationModel.ContractorId);
            return View(applicationModel);
        }

        // GET: Application/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Applications == null)
            {
                return NotFound();
            }

            var applicationModel = await _context.Applications
                .Include(a => a.Contractor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationModel == null)
            {
                return NotFound();
            }

            return View(applicationModel);
        }

        // POST: Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Applications == null)
            {
                return Problem("Entity set 'DataContext.Applications'  is null.");
            }
            var applicationModel = await _context.Applications.FindAsync(id);
            if (applicationModel != null)
            {
                _context.Applications.Remove(applicationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationModelExists(int id)
        {
          return (_context.Applications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
