using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartPlantsMvc.Data;
using SmartPlantsMvc.Models;

namespace SmartPlantsMvc.Controllers
{
    public class ReservoirsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservoirsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservoirs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservoirs.Include(r => r.Module);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservoirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservoir = await _context.Reservoirs
                .Include(r => r.Module)
                .FirstOrDefaultAsync(m => m.ReservoirId == id);
            if (reservoir == null)
            {
                return NotFound();
            }

            return View(reservoir);
        }

        // GET: Reservoirs/Create
        public IActionResult Create()
        {
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId");
            return View();
        }

        // POST: Reservoirs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservoirId,ModuleId,Capacity")] Reservoir reservoir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservoir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", reservoir.ModuleId);
            return View(reservoir);
        }

        // GET: Reservoirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservoir = await _context.Reservoirs.FindAsync(id);
            if (reservoir == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", reservoir.ModuleId);
            return View(reservoir);
        }

        // POST: Reservoirs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservoirId,ModuleId,Capacity")] Reservoir reservoir)
        {
            if (id != reservoir.ReservoirId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservoir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservoirExists(reservoir.ReservoirId))
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
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", reservoir.ModuleId);
            return View(reservoir);
        }

        // GET: Reservoirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservoir = await _context.Reservoirs
                .Include(r => r.Module)
                .FirstOrDefaultAsync(m => m.ReservoirId == id);
            if (reservoir == null)
            {
                return NotFound();
            }

            return View(reservoir);
        }

        // POST: Reservoirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservoir = await _context.Reservoirs.FindAsync(id);
            _context.Reservoirs.Remove(reservoir);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservoirExists(int id)
        {
            return _context.Reservoirs.Any(e => e.ReservoirId == id);
        }
    }
}
