using Bussiness.Model.Data;
using Bussiness.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;
 
[ApiController]
[Route("api/[controller]")]
public class ArtOrganizationController : ControllerBase
{
    private readonly ArtBookingDbContext _dbContext;
    public ArtOrganizationController(ArtBookingDbContext dbContext) => _dbContext = dbContext;

    [HttpPost]
    public ActionResult<ArtOrganization> CreateOrganization([FromBody] ArtOrganization organization)
    {
        if (organization == null)
            return BadRequest("Nieprawidłowe dane organizacji.");

        _dbContext.ArtOrganizations.Add(organization);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetOrganization), new { id = organization.ArtOrganizationId }, organization);
    }

     [HttpGet("{id}")]
    public ActionResult<ArtOrganization> GetOrganization(int id)
    {
        var org = _dbContext.ArtOrganizations.Find(id);
        if (org == null)
            return NotFound($"Nie znaleziono organizacji o identyfikatorze {id}.");

        return Ok(org);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ArtOrganization>> GetAllOrganizations()
    {
        var organizations = _dbContext.ArtOrganizations.ToList();
        return Ok(organizations);
    }

     [HttpPut("{id}")]
    public ActionResult<ArtOrganization> UpdateOrganization(int id, [FromBody] ArtOrganization updatedOrganization)
    {
        if (updatedOrganization == null || id != updatedOrganization.ArtOrganizationId)
        {
            return BadRequest("Nieprawidłowe dane organizacji.");
        }

        var existingOrg = _dbContext.ArtOrganizations.Find(id);
        if (existingOrg == null)
        {
            return NotFound($"Nie znaleziono organizacji o identyfikatorze {id}.");
        }

        existingOrg.Name = updatedOrganization.Name;
        existingOrg.Description = updatedOrganization.Description;
        existingOrg.Email = updatedOrganization.Email;
        existingOrg.PhoneNumber = updatedOrganization.PhoneNumber;
        existingOrg.website = updatedOrganization.website;

        _dbContext.ArtOrganizations.Update(existingOrg);
        _dbContext.SaveChanges();

        return Ok(existingOrg);
    }

     [HttpDelete("{id}")]
    public ActionResult DeleteOrganization(int id)
    {
        var org = _dbContext.ArtOrganizations.Find(id);
        if (org == null)
        {
            return NotFound($"Nie znaleziono organizacji o identyfikatorze {id}.");
        }

        _dbContext.ArtOrganizations.Remove(org);
        _dbContext.SaveChanges();

        return NoContent();
    }
}