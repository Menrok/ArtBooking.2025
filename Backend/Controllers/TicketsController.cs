using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bussiness.Model.Data;
using Bussiness.Model.Entities;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ArtBookingDbContext _context;

    public TicketsController(ArtBookingDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetAll()
    {
        return await _context.Tickets
            .Include(t => t.ScheduleItem)
            .Include(t => t.Seat)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> Get(int id)
    {
        var ticket = await _context.Tickets
            .Include(t => t.ScheduleItem)
            .Include(t => t.Seat)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (ticket == null) return NotFound();
        return ticket;
    }

    [HttpPost]
    public async Task<ActionResult<Ticket>> Create(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticket);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Ticket ticket)
    {
        if (id != ticket.Id) return BadRequest();

        _context.Entry(ticket).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tickets.Any(t => t.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null) return NotFound();

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}