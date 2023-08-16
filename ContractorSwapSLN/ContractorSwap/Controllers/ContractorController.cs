using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContractorSwap.Data;
using ContractorSwap.Models;
using Microsoft.AspNetCore.Http;

namespace ContractorSwap.Controllers
{

    public class ContractorController : Controller
    {
        private readonly DataContext _context;

        public ContractorController(DataContext context)
        {
            _context = context;
        }

        public void CreateUser(string password, string username)
        {
            CookieOptions user = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(24)
            };

            Response.Cookies.Append(password, username, user);
        }



        // GET: Contractor
        public async Task<IActionResult> Index()
        {
              return _context.Contractors != null ? 
                          View(await _context.Contractors.ToListAsync()) :
                          Problem("Entity set 'DataContext.Contractors'  is null.");
        }

        // GET: Contractor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contractors == null)
            {
                return NotFound();
            }

            var contractorModel = await _context.Contractors.Include(j=> j.JobListings).FirstOrDefaultAsync(m => m.Id == id);
            if (contractorModel == null)
            {
                return NotFound();
            }

            return View(contractorModel);
        }

        // GET: Contractor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contractor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Specialties,Location,UserName,Password")] ContractorModel contractorModel)
        {
            if (ModelState.IsValid)
            {
                CreateUser(contractorModel.Password, contractorModel.UserName);

                _context.Add(contractorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractorModel);
        }

        // GET: Contractor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contractors == null)
            {
                return NotFound();
            }

            var contractorModel = await _context.Contractors.FindAsync(id);
            if (contractorModel == null)
            {
                return NotFound();
            }
            return View(contractorModel);
        }

        // POST: Contractor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Specialties,Location,UserName,Password")] ContractorModel contractorModel)
        {
            if (id != contractorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractorModelExists(contractorModel.Id))
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
            return View(contractorModel);
        }

        // GET: Contractor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contractors == null)
            {
                return NotFound();
            }

            var contractorModel = await _context.Contractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractorModel == null)
            {
                return NotFound();
            }

            return View(contractorModel);
        }

        // POST: Contractor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contractors == null)
            {
                return Problem("Entity set 'DataContext.Contractors'  is null.");
            }
            var contractorModel = await _context.Contractors.FindAsync(id);
            if (contractorModel != null)
            {
                _context.Contractors.Remove(contractorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractorModelExists(int id)
        {
          return (_context.Contractors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
