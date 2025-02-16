﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.EF.DBContext;
using DataAccess.EF.Models;

namespace AppTicketV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly AppTicketDBContext _context;

        public OperatorsController(AppTicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Operators
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Operator>>> GetOperator()
        //{
        //    return await _context.Operator.ToListAsync();
        //}

        //// GET: api/Operators/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Operator>> GetOperator(int id)
        //{
        //    var @operator = await _context.Operator.FindAsync(id);

        //    if (@operator == null)
        //    {
        //        return NotFound();
        //    }

        //    return @operator;
        //}

        //// PUT: api/Operators/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOperator(int id, Operator @operator)
        //{
        //    if (id != @operator.OperatorID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(@operator).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OperatorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Operators
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Operator>> PostOperator(Operator @operator)
        //{
        //    _context.Operator.Add(@operator);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOperator", new { id = @operator.OperatorID }, @operator);
        //}

        //// DELETE: api/Operators/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOperator(int id)
        //{
        //    var @operator = await _context.Operator.FindAsync(id);
        //    if (@operator == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Operator.Remove(@operator);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool OperatorExists(int id)
        //{
        //    return _context.Operator.Any(e => e.OperatorID == id);
        //}
    }
}
