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
    public class WidgetsController : ControllerBase
    {
        private readonly AppTicketDBContext _context;

        public WidgetsController(AppTicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Widgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Widget>>> GetWidget()
        {
            return await _context.Widget.ToListAsync();
        }

        // GET: api/Widgets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Widget>> GetWidget(int id)
        {
            var widget = await _context.Widget.FindAsync(id);

            if (widget == null)
            {
                return NotFound();
            }

            return widget;
        }

        // PUT: api/Widgets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWidget(int id, Widget widget)
        {
            if (id != widget.WidgetID)
            {
                return BadRequest();
            }

            _context.Entry(widget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WidgetExists(id))
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

        // POST: api/Widgets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Widget>> PostWidget(Widget widget)
        {
            _context.Widget.Add(widget);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWidget", new { id = widget.WidgetID }, widget);
        }

        // DELETE: api/Widgets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWidget(int id)
        {
            var widget = await _context.Widget.FindAsync(id);
            if (widget == null)
            {
                return NotFound();
            }

            _context.Widget.Remove(widget);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WidgetExists(int id)
        {
            return _context.Widget.Any(e => e.WidgetID == id);
        }
    }
}
