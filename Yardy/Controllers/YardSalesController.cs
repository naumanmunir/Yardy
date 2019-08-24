using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yardy.Models;

namespace Yardy.Controllers
{
    [EnableCors("Public")]
    [Route("api/[controller]")]
    [ApiController]
    public class YardSalesController : ControllerBase
    {
        private readonly YardyDbContext _context;

        public YardSalesController(YardyDbContext context)
        {
            _context = context;
        }

        // GET: api/YardSales
        [HttpGet]
        public IEnumerable<YardSale> GetYardSales()
        {
            return _context.YardSales;
        }

        // GET: api/YardSales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetYardSale([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yardSale = await _context.YardSales.FindAsync(id);

            if (yardSale == null)
            {
                return NotFound();
            }

            return Ok(yardSale);
        }

        // PUT: api/YardSales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYardSale([FromRoute] int id, [FromBody] YardSale yardSale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yardSale.Id)
            {
                return BadRequest();
            }

            _context.Entry(yardSale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YardSaleExists(id))
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

        // POST: api/YardSales
        [HttpPost]
        public async Task<IActionResult> PostYardSale([FromBody] YardSale yardSale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            yardSale.Active = true;
            yardSale.Created = DateTime.Now;

            _context.YardSales.Add(yardSale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYardSale", new { id = yardSale.Id }, yardSale);
        }

        // DELETE: api/YardSales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYardSale([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yardSale = await _context.YardSales.FindAsync(id);
            if (yardSale == null)
            {
                return NotFound();
            }

            _context.YardSales.Remove(yardSale);
            await _context.SaveChangesAsync();

            return Ok(yardSale);
        }

        private bool YardSaleExists(int id)
        {
            return _context.YardSales.Any(e => e.Id == id);
        }
    }
}