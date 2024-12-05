using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppTicketV2.EF.DBContext;
using AppTicketV2.EF.Models;

namespace AppTicketV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalsController : ControllerBase
    {
        private readonly AppTicketDBContext _context;

        public PortalsController(AppTicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Portals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portal>>> GetPortal()
        {
            return await _context.Portal.ToListAsync();
        }

        // GET: api/Portals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Portal>> GetPortal(int id)
        {
            var portal = await _context.Portal.FindAsync(id);

            if (portal == null)
            {
                return NotFound();
            }

            return portal;
        }

        // PUT: api/Portals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortal(int id, Portal portal)
        {
            if (id != portal.PortalID)
            {
                return BadRequest();
            }

            _context.Entry(portal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortalExists(id))
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

        // POST: api/Portals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Portal>> PostPortal(Portal portal)
        {
            _context.Portal.Add(portal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortal", new { id = portal.PortalID }, portal);
        }

        // DELETE: api/Portals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortal(int id)
        {
            var portal = await _context.Portal.FindAsync(id);
            if (portal == null)
            {
                return NotFound();
            }

            _context.Portal.Remove(portal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PortalExists(int id)
        {
            return _context.Portal.Any(e => e.PortalID == id);
        }
    }
}
