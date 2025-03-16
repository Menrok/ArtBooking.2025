using Microsoft.AspNetCore.Mvc;
using Bussiness.Model.Data;
using Bussiness.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/artevents")]
    [ApiController]
    public class ArtEventController : ControllerBase
    {
        private readonly ArtBookingDbContext _context;
        public ArtEventController(ArtBookingDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtEvent>>> GetArtEvents() => await _context.ArtEvents.ToListAsync();


        [HttpGet("{id}")]
        public async Task<ActionResult<ArtEvent>> GetArtEvent(int id)
        {
            var artEvent = await _context.ArtEvents.FindAsync(id);
            if (artEvent == null) return NotFound();
            return artEvent;
        }

        [HttpPost]
        public async Task<ActionResult<ArtEvent>> CreateArtEvent(ArtEvent artEvent)
        {
            _context.ArtEvents.Add(artEvent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArtEvent), new { id = artEvent.Id }, artEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtEvent(int id, ArtEvent artEvent)
        {
            if (id != artEvent.Id) return BadRequest();
            _context.Entry(artEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtEvent(int id)
        {
            var artEvent = await _context.ArtEvents.FindAsync(id);
            if (artEvent == null) return NotFound();
            _context.ArtEvents.Remove(artEvent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
