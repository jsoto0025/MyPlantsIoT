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
    public class PlantTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlantTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PlantTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantType>>> GetPlantTypes()
        {
            return await _context.PlantTypes.ToListAsync();
        }

        // GET: api/PlantTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantType>> GetPlantType(int id)
        {
            var plantType = await _context.PlantTypes.FindAsync(id);

            if (plantType == null)
            {
                return NotFound();
            }

            return plantType;
        }

        // PUT: api/PlantTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantType(int id, PlantType plantType)
        {
            if (id != plantType.PlantTypeId)
            {
                return BadRequest();
            }

            _context.Entry(plantType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantTypeExists(id))
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

        // POST: api/PlantTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlantType>> PostPlantType(PlantType plantType)
        {
            _context.PlantTypes.Add(plantType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantType", new { id = plantType.PlantTypeId }, plantType);
        }

        // DELETE: api/PlantTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlantType>> DeletePlantType(int id)
        {
            var plantType = await _context.PlantTypes.FindAsync(id);
            if (plantType == null)
            {
                return NotFound();
            }

            _context.PlantTypes.Remove(plantType);
            await _context.SaveChangesAsync();

            return plantType;
        }

        private bool PlantTypeExists(int id)
        {
            return _context.PlantTypes.Any(e => e.PlantTypeId == id);
        }
    }
}
