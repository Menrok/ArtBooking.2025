using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bussiness.Model.Data;
using Bussiness.Model.Entities;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeatsController : ControllerBase
{
    private readonly ArtBookingDbContext _context;

    public SeatsController(ArtBookingDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Seat>>> GetAll()
    {
        return await _context.Seats.Include(s => s.Area).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Seat>> Get(int id)
    {
        var seat = await _context.Seats.Include(s => s.Area).FirstOrDefaultAsync(s => s.Id == id);
        if (seat == null) return NotFound();
        return seat;
    }

    [HttpPost]
    public async Task<ActionResult<Seat>> Create(Seat seat)
    {
        _context.Seats.Add(seat);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = seat.Id }, seat);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Seat seat)
    {
        if (id != seat.Id) return BadRequest();

        _context.Entry(seat).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Seats.Any(s => s.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var seat = await _context.Seats.FindAsync(id);
        if (seat == null) return NotFound();

        _context.Seats.Remove(seat);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
