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
        public IActionResult Create()
        {
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "Id", "Location");
            return View();
        }

        // POST: Application/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bid,accepted,ContractorId")] ApplicationModel applicationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bid,accepted,ContractorId")] ApplicationModel applicationModel)
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
