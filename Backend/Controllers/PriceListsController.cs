using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bussiness.Model.Data;
using Bussiness.Model.Entities;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceListsController : ControllerBase
    {
        private readonly ArtBookingDbContext _context;

        public PriceListsController(ArtBookingDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceList>>> GetAll()
        {
            return await _context.PriceLists.Include(p => p.PriceEntries).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceList>> Get(int id)
        {
            var priceList = await _context.PriceLists.Include(p => p.PriceEntries).FirstOrDefaultAsync(p => p.Id == id);
            if (priceList == null) return NotFound();
            return priceList;
        }

        [HttpPost]
        public async Task<ActionResult<PriceList>> Create(PriceList priceList)
        {
            _context.PriceLists.Add(priceList);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = priceList.Id }, priceList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PriceList priceList)
        {
            if (id != priceList.Id) return BadRequest("ID mismatch");

            _context.Entry(priceList).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!_context.PriceLists.Any(e => e.Id == id)) return NotFound();
               throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var priceList = await _context.PriceLists.FindAsync(id);
            if (priceList == null) return NotFound();

            _context.PriceLists.Remove(priceList);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}