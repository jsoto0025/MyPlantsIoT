﻿using System;
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
    public class PlantTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlantTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlantTypes.ToListAsync());
        }

        // GET: PlantTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantType = await _context.PlantTypes
                .FirstOrDefaultAsync(m => m.PlantTypeId == id);
            if (plantType == null)
            {
                return NotFound();
            }

            return View(plantType);
        }

        // GET: PlantTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlantTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] PlantType plantType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantType);
        }

        // GET: PlantTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantType = await _context.PlantTypes.FindAsync(id);
            if (plantType == null)
            {
                return NotFound();
            }
            return View(plantType);
        }

        // POST: PlantTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] PlantType plantType)
        {
            if (id != plantType.PlantTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantTypeExists(plantType.PlantTypeId))
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
            return View(plantType);
        }

        // GET: PlantTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantType = await _context.PlantTypes
                .FirstOrDefaultAsync(m => m.PlantTypeId == id);
            if (plantType == null)
            {
                return NotFound();
            }

            return View(plantType);
        }

        // POST: PlantTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantType = await _context.PlantTypes.FindAsync(id);
            _context.PlantTypes.Remove(plantType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantTypeExists(int id)
        {
            return _context.PlantTypes.Any(e => e.PlantTypeId == id);
        }
    }
}
