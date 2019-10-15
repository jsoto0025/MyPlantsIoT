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
    public class ReservoirsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservoirsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservoirs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservoir>>> GetReservoirs()
        {
            return await _context.Reservoirs.ToListAsync();
        }

        // GET: api/Reservoirs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservoir>> GetReservoir(int id)
        {
            var reservoir = await _context.Reservoirs.FindAsync(id);

            if (reservoir == null)
            {
                return NotFound();
            }

            return reservoir;
        }

        // PUT: api/Reservoirs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservoir(int id, Reservoir reservoir)
        {
            if (id != reservoir.ReservoirId)
            {
                return BadRequest();
            }

            _context.Entry(reservoir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservoirExists(id))
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

        // POST: api/Reservoirs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Reservoir>> PostReservoir(Reservoir reservoir)
        {
            _context.Reservoirs.Add(reservoir);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservoir", new { id = reservoir.ReservoirId }, reservoir);
        }

        // DELETE: api/Reservoirs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservoir>> DeleteReservoir(int id)
        {
            var reservoir = await _context.Reservoirs.FindAsync(id);
            if (reservoir == null)
            {
                return NotFound();
            }

            _context.Reservoirs.Remove(reservoir);
            await _context.SaveChangesAsync();

            return reservoir;
        }

        private bool ReservoirExists(int id)
        {
            return _context.Reservoirs.Any(e => e.ReservoirId == id);
        }
    }
}
