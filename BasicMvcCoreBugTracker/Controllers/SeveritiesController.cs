using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicMvcCoreBugTracker.Data;
using BasicMvcCoreBugTracker.Models;

namespace BasicMvcCoreBugTracker.Controllers
{
    public class SeveritiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeveritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Severities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Severities.ToListAsync());
        }

        // GET: Severities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var severity = await _context.Severities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (severity == null)
            {
                return NotFound();
            }

            return View(severity);
        }

        // GET: Severities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Severities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Severity severity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(severity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(severity);
        }

        // GET: Severities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var severity = await _context.Severities.FindAsync(id);
            if (severity == null)
            {
                return NotFound();
            }
            return View(severity);
        }

        // POST: Severities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Severity severity)
        {
            if (id != severity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(severity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeverityExists(severity.Id))
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
            return View(severity);
        }

        // GET: Severities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var severity = await _context.Severities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (severity == null)
            {
                return NotFound();
            }

            return View(severity);
        }

        // POST: Severities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var severity = await _context.Severities.FindAsync(id);
            _context.Severities.Remove(severity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeverityExists(Guid id)
        {
            return _context.Severities.Any(e => e.Id == id);
        }
    }
}
