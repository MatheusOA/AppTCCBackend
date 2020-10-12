using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EyeTractorAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace EyeTractorAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SellingPointsController : ControllerBase
    {
        private readonly DataContext _context;

        public SellingPointsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SellingPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellingPoints>>> GetSellingPoints()
        {
            return await _context.SellingPoints.ToListAsync();
        }

        // GET: api/SellingPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellingPoints>> GetSellingPoint(long id)
        {
            var sellingPoint = await _context.SellingPoints.FindAsync(id);

            if (sellingPoint == null)
            {
                return NotFound();
            }

            return sellingPoint;
        }

        // PUT: api/SellingPoints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellingPoint(long id, SellingPoints sellingPoint)
        {
            if (id != sellingPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(sellingPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellingPointExists(id))
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

        // POST: api/SellingPoints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SellingPoints>> PostSellingPoint(SellingPoints sellingPoint)
        {
            _context.SellingPoints.Add(sellingPoint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SellingPointExists(sellingPoint.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetSellingPoint), new { id = sellingPoint.Id }, sellingPoint);
        }

        // DELETE: api/SellingPoints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SellingPoints>> DeleteSellingPoint(long id)
        {
            var sellingPoint = await _context.SellingPoints.FindAsync(id);
            if (sellingPoint == null)
            {
                return NotFound();
            }

            _context.SellingPoints.Remove(sellingPoint);
            await _context.SaveChangesAsync();

            return sellingPoint;
        }

        private bool SellingPointExists(long id)
        {
            return _context.SellingPoints.Any(e => e.Id == id);
        }
    }
}
