using ContractorSwap.Data;
using ContractorSwap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ContractorSwap.Controllers
{

    public class ContractorController : Controller
    {
        private readonly DataContext _context;       

        public ContractorController(DataContext context)
        {
            _context = context;
        }

        public void CreateUser(string userName, string password)
        {
            if (Request.Cookies.ContainsKey("UserCookie") && Request.Cookies.ContainsKey("PasswordCookie"))
            {
                // Remove the existing cookies
                Response.Cookies.Delete("UserCookie");
                Response.Cookies.Delete("PasswordCookie");
            }

            CookieOptions userCookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(24)
            };

            // Create new cookies with the updated information
            Response.Cookies.Append("UserCookie", userName, userCookieOptions);
            Response.Cookies.Append("PasswordCookie", password, userCookieOptions);
            Program.LoggedIn = true;
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

            var contractorModel = await _context.Contractors.Include(j => j.JobListings).FirstOrDefaultAsync(m => m.Id == id);
            if (contractorModel == null)
            {
                return NotFound();
            }

            return View(contractorModel);
        }
        public async Task<IActionResult> MyDetails(int? id)
        {
            if (Request.Cookies.ContainsKey("UserCookie") && Request.Cookies.ContainsKey("PasswordCookie"))
            {
                string userName = Request.Cookies["UserCookie"];
                string password = Request.Cookies["PasswordCookie"];
                var contractorModel = await _context.Contractors.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
                return View(contractorModel);
            }

            else { return RedirectToAction(nameof(Login)); }




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
                _context.Add(contractorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractorModel);
        }
        public IActionResult Register()
        {
            return View();
        }

        // POST: Contractor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Name,Specialties,Location,UserName,Password")] ContractorModel contractorModel)
        {
            if (Request.Cookies.ContainsKey("UserCookie") && Request.Cookies.ContainsKey("PasswordCookie"))
            {
                return RedirectToAction(nameof(MyDetails));
            }
            foreach (ContractorModel contractor in _context.Contractors)
            {
                if (contractor.UserName == contractorModel.UserName && contractor.Password == contractorModel.Password)
                {                    
                    Program.HasAccount = true;
                    return RedirectToAction("Login", "Contractor");
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(contractorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(contractorModel);
        }
        public IActionResult Login()
        {
            if (Request.Cookies.ContainsKey("UserCookie") && Request.Cookies.ContainsKey("PasswordCookie"))
            {
                return RedirectToAction(nameof(MyDetails));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ContractorModel contractorModel)
        {

            foreach(ContractorModel contractor in _context.Contractors)
            {
                if (contractor.UserName == contractorModel.UserName && contractor.Password == contractorModel.Password)
                {
                        CreateUser(contractorModel.UserName, contractorModel.Password);
                        return RedirectToAction("Index", "Home");  
                }
            }           
            return View(contractorModel);
        }
        public async Task<IActionResult> Logout()
        {
            if (Request.Cookies.ContainsKey("UserCookie") && Request.Cookies.ContainsKey("PasswordCookie"))
            {
                // Remove the existing cookies
                Response.Cookies.Delete("UserCookie");
                Response.Cookies.Delete("PasswordCookie");
                Program.LoggedIn = false;
                return RedirectToAction("Index", "Home");
                
            }
            return RedirectToAction(nameof(Login));

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
                return RedirectToAction(nameof(MyDetails));
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
