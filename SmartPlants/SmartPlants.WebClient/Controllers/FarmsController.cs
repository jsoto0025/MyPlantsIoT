using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartPlants.WebClient.Data;
using SmartPlants.WebClient.Models;

namespace SmartPlants.WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FarmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Farms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farm>>> GetFarms()
        {
            return await _context.Farms.ToListAsync();
        }

        // GET: api/Farms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farm>> GetFarm(int id)
        {
            var farm = await _context.Farms.FindAsync(id);

            if (farm == null)
            {
                return NotFound();
            }

            return farm;
        }

        // PUT: api/Farms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarm(int id, Farm farm)
        {
            if (id != farm.FarmId)
            {
                return BadRequest();
            }

            _context.Entry(farm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Farms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Farm>> PostFarm(Farm farm)
        {
            _context.Farms.Add(farm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarm", new { id = farm.FarmId }, farm);
        }

        // DELETE: api/Farms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Farm>> DeleteFarm(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
            {
                return NotFound();
            }

            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();

            return farm;
        }

        private bool FarmExists(int id)
        {
            return _context.Farms.Any(e => e.FarmId == id);
        }
    }
}
