using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeShopsController : ControllerBase
    {
        private readonly CafeContext _context;

        public CafeShopsController(CafeContext context)
        {
            _context = context;
        }

        // GET: api/CafeShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CafeShop>>> GetCafeShops()
        {
          if (_context.CafeShops == null)
          {
              return NotFound();
          }
            return await _context.CafeShops.ToListAsync();
        }

        // GET: api/CafeShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CafeShop>> GetCafeShop(int? id)
        {
          if (_context.CafeShops == null)
          {
              return NotFound();
          }
            var cafeShop = await _context.CafeShops.FindAsync(id);

            if (cafeShop == null)
            {
                return NotFound();
            }

            return cafeShop;
        }

        // PUT: api/CafeShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCafeShop(int? id, CafeShop cafeShop)
        {
            if (id != cafeShop.CafeId)
            {
                return BadRequest();
            }

            _context.Entry(cafeShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeShopExists(id))
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

        // POST: api/CafeShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CafeShop>> PostCafeShop(CafeShop cafeShop)
        {
          if (_context.CafeShops == null)
          {
              return Problem("Entity set 'CafeContext.CafeShops'  is null.");
          }
            _context.CafeShops.Add(cafeShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCafeShop", new { id = cafeShop.CafeId }, cafeShop);
        }

        // DELETE: api/CafeShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafeShop(int? id)
        {
            if (_context.CafeShops == null)
            {
                return NotFound();
            }
            var cafeShop = await _context.CafeShops.FindAsync(id);
            if (cafeShop == null)
            {
                return NotFound();
            }

            _context.CafeShops.Remove(cafeShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CafeShopExists(int? id)
        {
            return (_context.CafeShops?.Any(e => e.CafeId == id)).GetValueOrDefault();
        }
    }
}
