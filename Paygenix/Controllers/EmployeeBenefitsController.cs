using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paygenix.Models;

namespace Paygenix.Controllers
{
    public class EmployeeBenefitsController : Controller
    {
        private readonly PayGenixDB _context;

        public EmployeeBenefitsController(PayGenixDB context)
        {
            _context = context;
        }

        // GET: EmployeeBenefits
        public async Task<IActionResult> Index()
        {
            var payGenixDB = _context.EmployeeBenefits.Include(e => e.Benefit).Include(e => e.Employee);
            return View(await payGenixDB.ToListAsync());
        }

        // GET: EmployeeBenefits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeBenefit = await _context.EmployeeBenefits
                .Include(e => e.Benefit)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeBenefitID == id);
            if (employeeBenefit == null)
            {
                return NotFound();
            }

            return View(employeeBenefit);
        }

        // GET: EmployeeBenefits/Create
        public IActionResult Create()
        {
            ViewData["BenefitID"] = new SelectList(_context.Benefits, "BenefitID", "BenefitName");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Email");
            return View();
        }

        // POST: EmployeeBenefits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeBenefitID,EmployeeID,BenefitID,EnrolledDate")] EmployeeBenefit employeeBenefit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeBenefit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenefitID"] = new SelectList(_context.Benefits, "BenefitID", "BenefitName", employeeBenefit.BenefitID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Email", employeeBenefit.EmployeeID);
            return View(employeeBenefit);
        }

        // GET: EmployeeBenefits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeBenefit = await _context.EmployeeBenefits.FindAsync(id);
            if (employeeBenefit == null)
            {
                return NotFound();
            }
            ViewData["BenefitID"] = new SelectList(_context.Benefits, "BenefitID", "BenefitName", employeeBenefit.BenefitID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Email", employeeBenefit.EmployeeID);
            return View(employeeBenefit);
        }

        // POST: EmployeeBenefits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeBenefitID,EmployeeID,BenefitID,EnrolledDate")] EmployeeBenefit employeeBenefit)
        {
            if (id != employeeBenefit.EmployeeBenefitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeBenefit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeBenefitExists(employeeBenefit.EmployeeBenefitID))
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
            ViewData["BenefitID"] = new SelectList(_context.Benefits, "BenefitID", "BenefitName", employeeBenefit.BenefitID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Email", employeeBenefit.EmployeeID);
            return View(employeeBenefit);
        }

        // GET: EmployeeBenefits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeBenefit = await _context.EmployeeBenefits
                .Include(e => e.Benefit)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeBenefitID == id);
            if (employeeBenefit == null)
            {
                return NotFound();
            }

            return View(employeeBenefit);
        }

        // POST: EmployeeBenefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeBenefit = await _context.EmployeeBenefits.FindAsync(id);
            if (employeeBenefit != null)
            {
                _context.EmployeeBenefits.Remove(employeeBenefit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeBenefitExists(int id)
        {
            return _context.EmployeeBenefits.Any(e => e.EmployeeBenefitID == id);
        }
    }
}
