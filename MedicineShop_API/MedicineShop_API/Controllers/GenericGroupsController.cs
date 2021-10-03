using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicineShop_API.Models;

namespace MedicineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericGroupsController : ControllerBase
    {
        private readonly MedicineDbContext _context;

        public GenericGroupsController(MedicineDbContext context)
        {
            _context = context;
        }

        // GET: api/GenericGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenericGroup>>> GetGenericGroups()
        {
            return await _context.GenericGroups.ToListAsync();
        }

        // GET: api/GenericGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenericGroup>> GetGenericGroup(int id)
        {
            var genericGroup = await _context.GenericGroups.FindAsync(id);

            if (genericGroup == null)
            {
                return NotFound();
            }

            return genericGroup;
        }

        // PUT: api/GenericGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenericGroup(int id, GenericGroup genericGroup)
        {
            if (id != genericGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(genericGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenericGroupExists(id))
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

        // POST: api/GenericGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GenericGroup>> PostGenericGroup(GenericGroup genericGroup)
        {
            _context.GenericGroups.Add(genericGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenericGroup", new { id = genericGroup.Id }, genericGroup);
        }

        // DELETE: api/GenericGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericGroup>> DeleteGenericGroup(int id)
        {
            var genericGroup = await _context.GenericGroups.FindAsync(id);
            if (genericGroup == null)
            {
                return NotFound();
            }

            _context.GenericGroups.Remove(genericGroup);
            await _context.SaveChangesAsync();

            return genericGroup;
        }

        private bool GenericGroupExists(int id)
        {
            return _context.GenericGroups.Any(e => e.Id == id);
        }
    }
}
