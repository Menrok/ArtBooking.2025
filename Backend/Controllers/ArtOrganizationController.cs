using Bussiness.Model.Data;
using Bussiness.Model.Entities;
using Microsoft.AspNetCore.Mvc;
 
namespace Backend.Controllers;
 
/// <summary>
/// Controller for managing user accounts
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ArtOrganizationController : ControllerBase
{
    private readonly ArtBookingDbContext _dbContext;
    public ArtOrganizationController(ArtBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<ArtOrganization> CreateOrganization(ArtOrganization organization)
    {
        _dbContext.Add(organization);
        _dbContext.SaveChanges();

        return Ok(organization);
    }

    [HttpGet]
    public ActionResult<ArtOrganization> GetOrganization(int id)
    {
        var org = _dbContext.ArtOrganizations.Find(id);

        return Ok(org);
    }
}