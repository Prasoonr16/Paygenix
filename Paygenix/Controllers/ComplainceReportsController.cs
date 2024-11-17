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
    public class ComplainceReportsController : Controller
    {
        private readonly PayGenixDB _context;

        public ComplainceReportsController(PayGenixDB context)
        {
            _context = context;
        }

        // GET: ComplainceReports
        public async Task<IActionResult> Index()
        {
            var payGenixDB = _context.ComplainceReports.Include(c => c.Employee).Include(c => c.GeneratedByUser);
            return View(await payGenixDB.ToListAsync());
        }

        // GET: ComplainceReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complainceReport = await _context.ComplainceReports
                .Include(c => c.Employee)
                .Include(c => c.GeneratedByUser)
                .FirstOrDefaultAsync(m => m.ReportID == id);
            if (complainceReport == null)
            {
                return NotFound();
            }

            return View(complainceReport);
        }

        // GET: ComplainceReports/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Email");
            ViewData["GeneratedBy"] = new SelectList(_context.User, "UserID", "PasswordHash");
            return View();
        }

        // POST: ComplainceReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportID,ReportDate,EmployeeID,PayrollIssued,ComplianceStatus,IssuesFound,ResolvedStatus,GeneratedBy,Comments")] ComplainceReport complainceReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(complainceReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Email", complainceReport.EmployeeID);
            return View(complainceReport);
        }

        // GET: ComplainceReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complainceReport = await _context.ComplainceReports.FindAsync(id);
            if (complainceReport == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Email", complainceReport.EmployeeID);
            return View(complainceReport);
        }

        // POST: ComplainceReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportID,ReportDate,EmployeeID,PayrollIssued,ComplianceStatus,IssuesFound,ResolvedStatus,GeneratedBy,Comments")] ComplainceReport complainceReport)
        {
            if (id != complainceReport.ReportID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complainceReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplainceReportExists(complainceReport.ReportID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Email", complainceReport.EmployeeID);
            return View(complainceReport);
        }

        // GET: ComplainceReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complainceReport = await _context.ComplainceReports
                .Include(c => c.Employee)
                .Include(c => c.GeneratedByUser)
                .FirstOrDefaultAsync(m => m.ReportID == id);
            if (complainceReport == null)
            {
                return NotFound();
            }

            return View(complainceReport);
        }

        // POST: ComplainceReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complainceReport = await _context.ComplainceReports.FindAsync(id);
            if (complainceReport != null)
            {
                _context.ComplainceReports.Remove(complainceReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplainceReportExists(int id)
        {
            return _context.ComplainceReports.Any(e => e.ReportID == id);
        }
    }
}
