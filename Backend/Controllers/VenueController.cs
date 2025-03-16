using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bussiness.Model.Data;
using Bussiness.Model.Entities;

namespace Backend.Controllers
{
    [Route("api/venues")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly ArtBookingDbContext _context;
        public VenueController(ArtBookingDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> GetVenues() => await _context.Venues.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Venue>> GetVenue(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null) return NotFound();
            return venue;
        }

        [HttpPost]
        public async Task<ActionResult<Venue>> CreateVenue(Venue venue)
        {
            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVenue), new { id = venue.Id }, venue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenue(int id, Venue venue)
        {
            if (id != venue.Id) return BadRequest();
            _context.Entry(venue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            if (venue == null) return NotFound();
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}