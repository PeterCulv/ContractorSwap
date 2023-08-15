using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContractorSwap.Data;
using ContractorSwap.Models;

namespace ContractorSwap.Controllers
{
    public class JobListingController : Controller
    {
        private readonly DataContext _context;

        public JobListingController(DataContext context)
        {
            _context = context;
        }

        // GET: JobListing
        public async Task<IActionResult> Index()
        {
              return _context.Jobs != null ? 
                          View(await _context.Jobs.ToListAsync()) :
                          Problem("Entity set 'DataContext.Jobs'  is null.");
        }

        // GET: JobListing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var jobListingModel = await _context.Jobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobListingModel == null)
            {
                return NotFound();
            }

            return View(jobListingModel);
        }

        // GET: JobListing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobListing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,Location,Description,PosterId,ContractorId")] JobListingModel jobListingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobListingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobListingModel);
        }

        // GET: JobListing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var jobListingModel = await _context.Jobs.Include(x => x.Contractor).FirstOrDefaultAsync(x=>x.Id==id);
            if (jobListingModel == null)
            {
                return NotFound();
            }
            return View(jobListingModel);
        }

        // POST: JobListing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobListingModel jobListingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(jobListingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
             return View(jobListingModel);
        }

        // GET: JobListing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var jobListingModel = await _context.Jobs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobListingModel == null)
            {
                return NotFound();
            }

            return View(jobListingModel);
        }

        // POST: JobListing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jobs == null)
            {
                return Problem("Entity set 'DataContext.Jobs'  is null.");
            }
            var jobListingModel = await _context.Jobs.FindAsync(id);
            if (jobListingModel != null)
            {
                _context.Jobs.Remove(jobListingModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobListingModelExists(int id)
        {
          return (_context.Jobs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
